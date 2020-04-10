// Learn more about F# at http://fsharp.org


open System
open Domain

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"


    let listOfSquares = [ for i in 1..10 -> i * i ]
    //printfn "%A" listOfSquares

    let listaAnexada = 1 :: [2..10]
    //printfn "%A" listaAnexada

    let listaConcatenada = [1..5] @ [6..10]
    //printfn "%A" listaConcatenada

    printfn "head: %A" listaConcatenada.Head
    printfn "primeiro: %A" (listaConcatenada.Item(1))
    printfn "último: %A" (listaConcatenada.Item(listaConcatenada.Length - 1))
    
    let quadradosÍmpares = List.filter (fun (n:int) -> n % 2 = 0 |> not) listOfSquares
    printfn "apenasÍmpares: %A" quadradosÍmpares

    let listaDesordenada = [5;2;1;3;4;9;7;6;8]

    let rec quicksort (lista: int list) : int list = 
        match lista with
        | [] -> []
        | head::tail ->
            let smaller = List.filter (fun (item:int) -> item < head) tail
            let larger = List.filter (fun (item:int) -> item > head) tail
            quicksort smaller @ [head] @ quicksort larger

    let rec quicksort2 (lista: int list) = 
        match lista with
        | [] -> []
        | x::xs -> 
            let menores, maiores = List.partition (fun n -> n < x) xs
            quicksort2 menores @ [x] @ quicksort2 maiores

    let listaOrdenada = quicksort2 listaDesordenada
    
    printfn "%A" listaDesordenada
    printfn "%A" listaOrdenada


    let animals = ["cat";"bird";"zebra";"leopard";"shark"]

    let animalsSorted =
        Seq.ofList animals
        |> Seq.where (fun a -> a.Contains("e"))
        |> Seq.sort
        |> Seq.toList

    printfn "%A" animalsSorted

    let conjunto = [-2; 1; 4; 5; 8]

    let organizado = List.sortBy (fun x -> abs x) conjunto
    printfn "%A" organizado




    let listaPessoas : Pessoa list = [
        {nome = "teste"; idade = 52}
        {nome = "teste"; idade = 12}
        {nome = "teste"; idade = 88}
        {nome = "teste"; idade = 67}
    ]

    let compararPessoa (p1:Pessoa) (p2:Pessoa) =
        if p1.idade > p2.idade then 1 else 
        if p1.idade < p2.idade then -1 else 
        0

    let pessoasFiltradas = List.sortWith compararPessoa listaPessoas
    printfn "%A" pessoasFiltradas


    let divisivelPor number1 element1 = element1 % number1 = 0
    let divisiveisPor5 = List.where (divisivelPor 5) [1..50]
    let primeiroDivisivelPor5 = List.find(divisivelPor 5) [1..50]
    printfn "%A" divisiveisPor5
    printfn "%A" primeiroDivisivelPor5



    let valuesList = [("a", 1); ("b", 2); ("c", 3)]
    let pickFunction = fun elem -> 
        match elem with
        | (value, 2) -> Some value
        | _ -> None
    let resultPick = List.pick pickFunction valuesList
    printfn "%A" resultPick



    let somatorio = List.sum [-3..10]
    printfn "%A" somatorio

    let media = List.average [2.2; 2.2; 2.3; 2.2]
    printfn "%A" media

    let mapeado = List.map (fun x -> x + 1) listaDesordenada
    printfn "%A" mapeado


    let sequencia = seq { 0 .. 10 .. 100 }
    printfn "%A" sequencia

    let array = [|1..10|] :> seq<int>




    let fullList = [1..100]
    let smallSlice = fullList.[65..]
    printfn "%A" smallSlice




    let validateName req =
        match req.Name with
        | null -> Error "No name found."
        | "" -> Error "Name is empty."
        | "bananas" -> Error "Bananas is not a name."
        | _ -> Ok req
    let validateEmail req =
        match req.Email with
        | null -> Error "No email found."
        | "" -> Error "Email is empty."
        | s when s.EndsWith("bananas.com") -> Error "No email from bananas.com is allowed."
        | _ -> Ok req
    
    let validateRequest reqResult =
        reqResult
        |> Result.bind validateName
        |> Result.bind validateEmail
    
    let test() =
        let req1 = { Name = "Phillip"; Email = "phillip@contoso.biz" }
        let res1 = validateRequest (Ok req1)
        match res1 with
        | Ok req -> printfn "My request was valid! Name: %s Email %s" req.Name req.Email
        | Error e -> printfn "Error: %s" e

    test()




    let retangulo = Rectangle(10.0, 20.0)

    let getShapeWidth shape =
        match shape with
        | Rectangle(width = w) -> w
        | Circle(radius = r) -> 2. * r
        | Prism(width = w) -> w

    printfn "%A" (getShapeWidth retangulo)

    let pi = 3.141592654
    
    let area myShape =
        match myShape with
        | Circle radius -> pi * radius * radius
        | Rectangle (h, w) -> h * w
    
    let radius = 15.0
    let myCircle = Circle(radius)
    printfn "Area of circle that has radius %f: %f" radius (area myCircle)

    let height, width = 5.0, 10.0
    let myRectangle = Rectangle(height, width)
    printfn "Area of rectangle that has height %f and width %f is %f" height width (area myRectangle)

    0 // return an integer exit code

