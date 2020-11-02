module Combinacoes

    let rec combinacoesDe2 lista =
        match lista with
        | [] -> []
        | head::tail ->
            let headMoreRest = List.map (fun elemento -> [head; elemento]) tail
            headMoreRest @ (combinacoesDe2 tail)

    let rec combinacoesDe3 lista = 
        match lista with
        | [] -> []
        | head::tail ->
            let headMoreRest = combinacoesDe2 tail |> List.map (fun comb2 -> [head] @ comb2)
            headMoreRest @ (combinacoesDe3 tail)

    let rec combinacoesDe4 lista =
        match lista with
        | [] -> []
        | head::tail -> 
            let headMoreRest = combinacoesDe3 tail |> List.map (fun comb3 -> [head] @ comb3)
            headMoreRest @ (combinacoesDe4 tail)

    let rec combinacoesDe (quantidade:int) (l:array<'T>) =
        let lista = l |> Array.toList
        match lista with
        | _lista when (List.length _lista) >= quantidade  -> 
            match quantidade with
            | 2 ->
                match lista with
                | [] -> []
                | head::tail ->
                    let headAndMore = tail |> List.map (fun e -> [head; e])
                    headAndMore @ (tail |> List.toArray |> CombinacoesDe 2)
            | _ -> 
                match lista with
                | [] -> []
                | head::tail ->
                    let headAndMore = CombinacoesDe (quantidade - 1) (List.toArray tail) |> List.map(fun c -> [head] @ c)
                    headAndMore @ (tail |> List.toArray |> CombinacoesDe quantidade)
        | _ -> []