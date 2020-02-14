// Learn more about F# at http://fsharp.org

open System

// Record
type Person1 = {
    FirstName: string
    LastName: string
}

// Discriminated Unions
type Person2 =
    | Male of FstNm: string * LstNm: string
    | Female of FstNm2: string * LstNm2: string


// class
type Person3(fstNm: string, lstNm: string) =
    let mutable lstNm : string = lstNm
    member this.FirstNm = fstNm
    member this.FullName : string = fstNm + " " + lstNm
    member this.LastName
        with get () = lstNm
        and set(v) = lstNm <- v

// interface
type IPerson =
    abstract member FullName: string

//class implemented interface
type Person4(fstNm: string, lstNm: string) =
    member this.LastName = lstNm
    interface IPerson with
        member this.FullName : string = fstNm + "-" + lstNm


let getFstNm (x: Person2) : string =
    match x with
    | Male (f, l) -> f
    | Female (f2, l2) -> f2


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#"
    let a: Person1 = {FirstName = "Johnny"; LastName = "Jorster"}

    printfn "firstname = %s" a.FirstName

    printfn "%A" a

    let b = Male("Johseph", "Jorster")

    printfn "fstnm = %s" (getFstNm b)

    printfn "%A" b

    let d = Person3("Josuke", "Kujo")

    printfn "%A" d

    printfn "FirstNm=%s, FullName=%s" d.FirstNm  d.FullName
    
    d.LastName <- "Kujo2"

    printfn "FullName=%s" d.FullName

    let e = Person4("Jorno", "Joberna")

    let f = e :> IPerson

    printfn "f.FullName=%s"f.FullName

    0 // return an integer exit code
