module Domain

    type Pessoa = {
        nome: string
        idade: int
    }

    type Request = { 
        Name: string
        Email: string
    }

    type Shape =
        | Rectangle of width : float * length : float
        | Circle of radius : float
        | Prism of width : float * float * height : float