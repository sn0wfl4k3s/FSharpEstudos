// Learn more about F# at http://fsharp.org

open System
open Validacoes

[<EntryPoint>]
let main argv =
    
    let cpf = "12345678909"

    let SeValido cpf =
        let valido = cpfValido cpf
        match valido with
        | Some n ->
            if n = true then
                printfn "O cpf é válido!"
            else
                printfn "O cpf não é válido!"
        | None ->
            printf "O cpf não está num formato válido!"
    
    SeValido cpf


    0 // return an integer exit code
