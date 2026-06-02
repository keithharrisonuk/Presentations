type OrderItem = {
    Name : string
    Price : float
}

type ActionTypes =
| AddPercentage
| SumScalers
| SumListToScaler

type Actions<'a> =
    | AddPercentage of int * Actions<'a>
    | SumList of 'a list * ('a -> float)
    | SumActions of Actions<'a> List

let rec runEngine(actions : Actions<'a>) =
    match actions with
    | SumList(itemsList, getValueFunc) ->
        itemsList |> List.sumBy getValueFunc
    | SumActions(actions) ->
        actions |> List.sumBy (fun action -> runEngine(action))
    | AddPercentage(percentage, actions) ->
        runEngine(actions) * (1.0 + ((float)percentage / 100.0))

let printBill(totalBill : float) =
    System.Console.WriteLine ("Total food cost: {0:C}", totalBill)
    System.Console.WriteLine ("Press any key to close")
    System.Console.ReadKey() |> ignore
        
let getDrinksOrder() =
    let coke = { Name = "Coke"; Price = 1.50 }
    let beer = { Name = "Beer"; Price = 4.50 }
    [coke; beer]

let getFoodOrder() =
    let vegetablePakora = { Name = "Vegetable Pakora"; Price = 3.00 }
    let chickenTikkaMasala = { Name = "Chicken Tikka Masala"; Price = 5.00}
    [vegetablePakora; chickenTikkaMasala]

let getPrice(orderItem) = orderItem.Price

[<EntryPoint>]
let main argv = 
    let tipRate = 10

    let foodOrder = getFoodOrder()
    let sumFoodOrderActions = SumList(foodOrder, getPrice)
    let foodWithTip = AddPercentage(tipRate, sumFoodOrderActions)

    let drinksOrder = getDrinksOrder()
    let drinksOrderActions = SumList(drinksOrder, getPrice)
    let drinksWithTip = AddPercentage(tipRate, drinksOrderActions)

    let calculateTotalAction = SumActions([foodWithTip])
    
    let foodBillWithTip = runEngine(calculateTotalAction)
    printBill(foodBillWithTip)

    // Expected £15:40
    // Actual £8:80
    0
