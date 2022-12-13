open System
open System.IO

let toElfInventories (input: string) =
    input.Split(Environment.NewLine + Environment.NewLine)
    |> Array.map (fun inventoryString ->
        inventoryString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
        |> Array.map int)

let calculateTotal (inventory: int []) = Array.sum inventory

let input = File.ReadAllText "input.txt"

let elvesSortedByCalories =
    input
    |> toElfInventories
    |> Array.map calculateTotal
    |> Array.sortDescending

let topCalories = Array.head elvesSortedByCalories
printfn $"Part 1: {topCalories}"

let top3Total = elvesSortedByCalories |> Array.take 3 |> Array.sum
printfn $"Part 2: {top3Total}"
