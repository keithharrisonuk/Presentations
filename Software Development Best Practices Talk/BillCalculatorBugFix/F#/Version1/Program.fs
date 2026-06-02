open System

type OrderItem = {
    Name : string
    Price : float
}

let printBill(totalBill : float) =
    System.Console.WriteLine ("Total food cost: {0:C}", totalBill)
    System.Console.WriteLine ("Press any key to close")
    System.Console.ReadKey() |> ignore

let calculateBillWithTip(totalBill, tipRate) =
    totalBill * (1.0 + ((float)tipRate / 100.0))

let calculateTotalCost(orderItemList : OrderItem list) =
    let mutable cost = 0.0
    for orderItem in orderItemList do
        cost <- cost + orderItem.Price
    cost
        
let getDrinksOrder() =
    let coke = { Name = "Coke"; Price = 1.50 }
    let beer = { Name = "Beer"; Price = 4.50 }
    [coke; beer]

let getFoodOrder() =
    let vegetablePakora = { Name = "Vegetable Pakora"; Price = 3.00 }
    let chickenTikkaMasala = { Name = "Chicken Tikka Masala"; Price = 5.00}
    [vegetablePakora; chickenTikkaMasala]

[<EntryPoint>]
let main argv = 
    let tipRate = 10

    let foodOrder = getFoodOrder()
    let foodBill = calculateTotalCost(foodOrder)

    let drinksOrder = getDrinksOrder()    
    let drinksBill = calculateTotalCost(drinksOrder)

    let foodBillWithTip = calculateBillWithTip(foodBill, tipRate)
    printBill(foodBillWithTip)

    // Expected £15:40
    // Actual £8:80
    0
