// Learn more about F# at http://fsharp.org


open System
open Formula
open Data

[<EntryPoint>]
let main argv =

    let retornarSePar  numero =
        match numero with
        | n when n % 2 = 0 -> Some n
        | _ -> None
    let valor = retornarSePar 10
    let numero = 
        match valor with
        | Some n -> n
        | None -> 0

    let rec imprimir lista =
        match lista with
        | [] -> printf "empty"
        | head::tail -> 
            printf "elemento=%A, " head
            imprimir tail
    imprimir [0..2..10]

    let listaGerada = [
        for numero in [2..3] do
            yield numero
            yield numero * numero
            yield numero * numero * numero
    ]

    printfn ""
    printf "%A" listaGerada


    let somarComUm numero = numero + 1
    let operacoes = 
        somarComUm 10
        |> somarComUm

    printf "%A" operacoes
    
    let impar numero =
        numero % 2 = 0
        |> not

    let resultado = impar 21

    printfn "%A" resultado

    let somar x y = x + y
    let somaCom3 = somar 3

    let treze = somaCom3 10
    printfn "%A" treze


    let disstancia = 100<km>
    let real = 1<reais>
    let tempo = 1<h>
    let velocidade = 50<km/h>

    printfn "velocidade: %A" velocidade

    let convercao =
        converterParaDolar 250.5<real> 3.88<real/dolar>
        |> Console.WriteLine
    
    let gitdata = Data.githubData("https://api.github.com/users/sn0wfl4k3s")
    printfn "%A" gitdata


    let square x = x * x
    let squared = List.map square [1;2;3]
    printfn "%A" squared


    0