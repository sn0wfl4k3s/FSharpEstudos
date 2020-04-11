module Validacoes

    let cpfValido (cpf: string) =
        match cpf with
        | _cpf when _cpf.Length = 11 || _cpf.Length = 14 ->
            let cpfFiltrado = cpf.Replace("-", "").Replace(".", "")
            let cpfNumerico = 
                Seq.toList cpfFiltrado
                |> List.map (fun c -> c |> string |> System.Int32.Parse)
            let tuplaOitoDigitosInverso = 
                Seq.toList cpfNumerico.[..8]
                |> List.rev
                |> List.mapi (fun i c -> (i, c ))
            let s1 = List.sumBy (fun (i, cpf) ->  cpf * (9 - (i % 10))) tuplaOitoDigitosInverso
            let s2 = List.sumBy (fun (i, cpf) ->  cpf * (9 - ((i + 1) % 10))) tuplaOitoDigitosInverso
            let d1 = (s1 % 11) % 10;
            let d2 = ((s2 + d1 * 9) % 11) % 10
            Some([d1; d2] = cpfNumerico.[9..])
        | _ -> None