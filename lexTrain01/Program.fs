open System.IO
open FSharp.Text.Lexing


let parseFile (fileName: string) =
    use textReader = new System.IO.StreamReader(fileName)
    let lexbuf = LexBuffer<char>.FromTextReader textReader

    Parser.prog Lexer.sts_initial lexbuf
    
let test01 (fileName: string) =
    use textReader = new System.IO.StreamReader(fileName)
    let lexbuf = LexBuffer<char>.FromTextReader textReader

    let lexeme = LexBuffer<_>.LexemeString

    let a = lexeme lexbuf
    printfn "a=%A" a

    0
    //Parser.prog Lexer.sts_initial lexbuf



[<EntryPoint>]
let main argv =

    let testFile = Path.Combine(__SOURCE_DIRECTORY__, argv.[0])
    let prsRes = parseFile testFile

    printfn "%s" (Ast.progToStr prsRes)


    test01 testFile |> ignore

    0 // return an integer exit code
