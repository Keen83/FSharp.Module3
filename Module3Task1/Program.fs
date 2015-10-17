// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System
  
let phi = 1.6180339887

let calcGr num =
    (num, float num * phi)

let readValue() = 
    Console.WriteLine("Enter the number: ")
    let str = Console.ReadLine()
    int str

let shouldContinue() = 
    Console.WriteLine("Need more number (y/n)?")
    Console.ReadLine().ToLower() = "y"

let rec getResult() = 
    // let newValue = readValue |> calcGr
    let num = readValue()
    let newValue = calcGr num
    let needAnotherValue = shouldContinue

    // pattern matching would be better
    if needAnotherValue() then 
        newValue :: getResult()
    else [newValue]

let print x = 
    printfn "%A" x

let rec printList (list: (int * float) list) =
    if not list.IsEmpty then
        print list.Head
        printList list.Tail

[<EntryPoint>]
let main argv = 
    let result = getResult()

    printList result

    let a = Console.ReadKey()
    0 // return an integer exit code
