﻿namespace AdventTwo

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

module ProblemTwo =

    let commonLetters (x:string) (y:string) =
            Array.zip (x.ToCharArray()) (y.ToCharArray())
            |> Array.filter(fun x -> fst x = snd x)
            |> Array.map(fun x -> fst x)
            |> System.String

    let allOneDistances box boxes =
        boxes
        |> Seq.map(fun x -> (x, commonLetters x box))
        |> Seq.filter(fun x -> String.length (fst x) - String.length (snd x) = 1)

    let getCommonLetters boxes =
        boxes
        |> Seq.map(fun box -> allOneDistances box boxes)
        |> Seq.filter(fun x -> Seq.length x > 0)
        |> Seq.map(fun x -> snd (Seq.head x))
        |> Seq.distinct
    
 
open System.IO
open ProblemOne
open ProblemTwo

module Main =

    [<EntryPoint>]
    let main argv = 
        match argv with
        | [||] -> 
            printfn "Need a filename."
            1
        | [| "findboxes"; x |] ->
            if File.Exists x then
                let lines = File.ReadAllLines x
                printfn "Common letter %A" (getCommonLetters lines)
                0 // return an integer exit code
            else
                printfn "File not found: %s" x
                1
        | [| "checksum"; x |] ->
            if File.Exists x then
                let lines = File.ReadAllLines x
                printfn "Checksum is %i" (checksum lines)
                0 // return an integer exit code
            else
                printfn "File not found: %s" x
                1
        | _ ->
            printfn "Check your args."
            1
