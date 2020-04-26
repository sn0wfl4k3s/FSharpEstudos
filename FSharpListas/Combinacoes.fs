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