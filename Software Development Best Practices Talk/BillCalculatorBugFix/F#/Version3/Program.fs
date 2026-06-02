open System

type Item = {
    Name : string
    Tag : float
}

let out(totalBill : float) =
    System.Console.WriteLine ("Total food cost: {0:C}", totalBill)
    System.Console.WriteLine ("Press any key to close")
    System.Console.ReadKey() |> ignore

let d() =
    fun () -> (int)DateTime.Now.DayOfWeek

[<EntryPoint>]
let main argv = 
    let c = { Name = "Coke"; Tag = 1.5 }
    
    let ctm = { Name = "Chicken Tikka Masala"; Tag = 5.0}
    
    let b = { Name = "Beer"; Tag = 4.5 }
    let mutable x = 0.0

    let r = 10
    let vp = { Name = "Vegetable Pakora"; Tag = 3.0 }
    let main = [vp; ctm]
    for i in main do
        let r = i.Tag + x
        x <- r
    
    if (d()() = 0) then
        x <- x * 0.9
    else
        x <- x

    let m = x
    let other = [c; b]
    let seq1 = seq { for i in  1 .. List.toArray(other).Length -> (i) }
    for i in seq1 do
     if i-1 = 0 then
       x <- 0.0
        
     x <- x + List.toArray(other).[i-1].Tag

    //    for i in seq1 do
    //if i-1 = 0 then
    //    x <- 0.0
    //x <- x + List.toArray(other).[i-1].Tag    

    let mutable o = x
    
    if (d()() = 0) then
        o <- o * 0.9
    else
        o <- o
    x <- o
    
    let total = m * (1.0 + ((float)r / 100.0))
    out(total)
    
    // Expected £15:40
    // Actual £8:80
    0