// Learn more about F# at http://fsharp.org

open System


type Maybe<'a> =
    | Just of v : 'a
    | Nothing
    static member Bind (m, f) =
        match m with
        | Just x -> f x
        | Nothing -> Nothing
    static member (>>=) (m, f) = Maybe<'a>.Bind(m, f)

let maybeRet x = Just x     

//let maybeBind = Maybe.(>>=)


(*
let (>>=) m f = 
    match m with
    | Just x -> f x
    | Nothing -> Nothing
*)

let f1 (x: int) : Maybe<int> =
    if x >= 0 
    then Just (x + 3)
    else Nothing

type MaybeBuilder() =
    member x.Bind ( m, f)= Maybe<_>.Bind( m, f)
    member x.ReturnFrom(v) = maybeRet v
    member x.Zero() = Nothing
let maybe = MaybeBuilder()


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    let b = maybeRet 3

    printfn "%A" b

    let c = ((maybeRet 5) >>= f1)
    printfn "%A" c

    let d = ((maybeRet -5) >>= f1)
    printfn "%A" d

    let g = maybe {
        let! e = f1 4

        printfn "%A" e
        return! e
    }

    printfn "%A" g

    0 // returns an integer exit code
