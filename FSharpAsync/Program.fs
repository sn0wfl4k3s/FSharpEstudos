// Learn more about F# at http://fsharp.org

open System
open System.Net
open System.IO

let fetchUrl url =
    let request = WebRequest.Create (Uri url)
    use response = request.GetResponse()
    use stream = response.GetResponseStream()
    use reader = new StreamReader( stream)
    let html = reader.ReadToEnd()
    printfn "finished reading %s" url
    html

let asyncFetchUrl url = 
    async{
        let request = WebRequest.Create (Uri url)
        use response = request.GetResponse()
        use stream = response.GetResponseStream()
        use reader = new StreamReader( stream)
        let html = reader.ReadToEnd()
        printfn "finished reading %s" url
        return html
    }

[<EntryPoint>]
let main argv =

    let sites = [
        "https://www.github.com/"
        "https://www.google.com/"
        "https://www.amazon.com/"
        "https://gabrielschade.github.io/"
    ]

    let stopWatch1 = new Diagnostics.Stopwatch()
    let stopWatch2 = new Diagnostics.Stopwatch()

    stopWatch1.Start()
    sites 
    |> List.map fetchUrl
    |> ignore
    stopWatch1.Stop()
    printfn "Tempo sem async: %A ms" stopWatch1.ElapsedMilliseconds

    stopWatch2.Start()
    sites
    |> List.map asyncFetchUrl
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
    stopWatch2.Stop()
    printfn "Tempo sem async: %A ms" stopWatch2.ElapsedMilliseconds

    let diferenca = stopWatch1.ElapsedMilliseconds - stopWatch2.ElapsedMilliseconds |> abs

    printf "Diferença de tempo: %A ms" diferenca
    

    0 // return an integer exit code
