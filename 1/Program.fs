open System
open System.IO

let toElfInventories (input: string) =
    input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun x ->
        x.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
        |> Array.map int)

let calculateTotal (inventory: int []) = Array.sum inventory

let input = File.ReadAllText "input.txt"

let elvesSortedByCalories =
    input
    |> toElfInventories
    |> Array.map calculateTotal
    |> Array.sortDescending

let elfMostCalories = Array.head elvesSortedByCalories
printfn $"Part 1: {elfMostCalories}"

let top3Total = elvesSortedByCalories |> Array.take 3 |> Array.sum
printfn $"Part 2: {top3Total}"
