
module Data

    open FSharp.Data

    [<Literal>]
    let url = "https://api.github.com/users/microsoft"
    type PerfilGitHub = JsonProvider<url>

    let githubData (url: string) =
        let perfil = PerfilGitHub.Load url
        (perfil.Name, perfil.Following, perfil.Followers)



        