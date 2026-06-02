open System

type OI = {
    Nm : string
    Pr : float
}

let print(t : float) =
    System.Console.WriteLine ("Total food cost: {0:C}", t)
    System.Console.WriteLine ("Press any key to close")
    System.Console.ReadKey() |> ignore

let t(t, r) =
    t * (1.0 + ((float)r / 100.0))

let ad(c) =
    if (DateTime.Now.DayOfWeek = DayOfWeek.Sunday) then
        c * 0.9
    else
        c

let c(ol : OI list) =
    let mutable c = 0.0
    for o in ol do
        c <- c + o.Pr
    ad(c)
        
let o() =
    let c = { Nm = "Coke"; Pr = 1.50 }
    let b = { Nm = "Beer"; Pr = 4.50 }
    [c; b]

let f() =
    let v = { Nm = "Vegetable Pakora"; Pr = 3.00 }
    let c = { Nm = "Chicken Tikka Masala"; Pr = 5.00}
    [v; c]

[<EntryPoint>]
let main argv = 
    let r = 10

    let f = f()
    let fb = c(f)

    let d = o()    
    let db = c(d)

    let wt = t(fb, r)
    print(wt)

    // Expected £15:40
    // Actual £8:80
    0
