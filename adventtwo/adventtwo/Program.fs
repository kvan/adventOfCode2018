// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
namespace AdventTwo

module ProblemOne =

    let letterDistributions (s:string) =
        s.ToCharArray()
        |> Seq.groupBy(fun c -> c)
        |> Map.ofSeq
        |> Map.map(fun k v -> Seq.length v)
    
    let hasNumber (s:string) (n:int) =
        letterDistributions s
        |> Map.tryPick(fun k v -> if v = n then Some(k) else None)

    let checksum (boxes) =
        let twos = boxes |> Seq.map(fun s -> hasNumber s 2) |> Seq.choose id
        let threes = boxes |> Seq.map(fun s -> hasNumber s 3) |> Seq.choose id
        Seq.length twos * Seq.length threes

open System.IO
open ProblemOne

module Main =
    [<EntryPoint>]
    let main argv = 
        match argv with
        | [||] -> 
            printfn "Need a filename."
            1
        | [| x |] ->
            if File.Exists x then
                let lines = File.ReadAllLines x
                printfn "Checksum is %i" (checksum lines)
                0 // return an integer exit code
            else
                printfn "File not found: %s" x
                1
        | _ ->
            printfn "Need a filename only."
            1
