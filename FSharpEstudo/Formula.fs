module Formula

    
    let distancia ((x1, y1): float * float) ((x2, y2): float * float) =
        (x2-x1) ** (2 |> float) + (y2-y1) ** (2 |> float)
        |> abs
        |> sqrt

    open System
    
    type Pessoa = {
        nome: string
        sobrenome: string
        nascimento: DateTime
    }

    type Categoria =
        | Popular
        | Medio
        | Luxo of string

    type Carro = {
        categoria: Categoria
        valor: double
    }

    [<Measure>] 
    type km

    [<Measure>]
    type h

    [<Measure>]
    type reais

    [<Measure>]
    type dolar

    [<Measure>]
    type real

    let converterParaDolar (valor:float<real>) cambio : float<dolar> = 
        valor / cambio