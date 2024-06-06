// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "Parser.fsy"

open Ast    
(*
let parse_error a =
    printfn "parse_error called."
*)


//This works. but I don't know why...
let parse_error_rich =
    let f (ectx : FSharp.Text.Parsing.ParseErrorContext<_>) = 
        let currTok = ectx.CurrentToken
        match currTok with
        | Some t -> printfn "parse_error. CurrentToken = %A" t
        | None -> printfn   "parse_error."
        printfn "            ParseState = %A" ectx.ParseState
        printfn "            StateStack = %A" ectx.StateStack
        printfn "            ReduceTokens = %A" ectx.ReduceTokens
        printfn "            ShiftTokens = %A" ectx.ShiftTokens
        printfn "----"
        ()
    Some f

let getInt (expInt: Ast.Exp) : int =
    match expInt with
    | Ast.IntExp v -> v
    | _ -> 0


# 36 "Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | DIM
  | ID of (string)
  | INT of (System.Int32)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_DIM
    | TOKEN_ID
    | TOKEN_INT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startprog
    | NONTERM_prog
    | NONTERM_exps
    | NONTERM_exp
    | NONTERM_end

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | DIM  -> 1 
  | ID _ -> 2 
  | INT _ -> 3 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_DIM 
  | 2 -> TOKEN_ID 
  | 3 -> TOKEN_INT 
  | 6 -> TOKEN_end_of_input
  | 4 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startprog 
    | 1 -> NONTERM_prog 
    | 2 -> NONTERM_prog 
    | 3 -> NONTERM_exps 
    | 4 -> NONTERM_exps 
    | 5 -> NONTERM_exp 
    | 6 -> NONTERM_exp 
    | 7 -> NONTERM_exp 
    | 8 -> NONTERM_end 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 6 
let _fsyacc_tagOfErrorTerminal = 4

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | DIM  -> "DIM" 
  | ID _ -> "ID" 
  | INT _ -> "INT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | DIM  -> (null : System.Object) 
  | ID _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 2us; 65535us; 0us; 2us; 5us; 6us; 2us; 65535us; 0us; 5us; 5us; 5us; 2us; 65535us; 0us; 4us; 2us; 3us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 6us; 9us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 1us; 1us; 1us; 2us; 2us; 3us; 4us; 1us; 4us; 1us; 5us; 1us; 6us; 1us; 7us; 1us; 8us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 8us; 10us; 13us; 15us; 17us; 19us; 21us; |]
let _fsyacc_action_rows = 11
let _fsyacc_actionTableElements = [|4us; 32768us; 0us; 10us; 1us; 9us; 2us; 8us; 3us; 7us; 0us; 49152us; 1us; 32768us; 0us; 10us; 0us; 16385us; 0us; 16386us; 3us; 16387us; 1us; 9us; 2us; 8us; 3us; 7us; 0us; 16388us; 0us; 16389us; 0us; 16390us; 0us; 16391us; 0us; 16392us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 5us; 6us; 8us; 9us; 10us; 14us; 15us; 16us; 17us; 18us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 2us; 1us; 1us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 1us; 2us; 2us; 3us; 3us; 3us; 4us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 16386us; 65535us; 16388us; 16389us; 16390us; 16391us; 16392us; |]
let _fsyacc_reductions ()  =    [| 
# 121 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?>  Ast.Prog  in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startprog));
# 130 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_exps in
            let _2 = parseState.GetInput(2) :?> 'gentype_end in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "Parser.fsy"
                                      Prog _1 
                   )
# 50 "Parser.fsy"
                 :  Ast.Prog ));
# 142 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_end in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "Parser.fsy"
                                        _1 
                   )
# 51 "Parser.fsy"
                 :  Ast.Prog ));
# 153 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_exp in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "Parser.fsy"
                                                      [_1] 
                   )
# 54 "Parser.fsy"
                 : 'gentype_exps));
# 164 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_exp in
            let _2 = parseState.GetInput(2) :?> 'gentype_exps in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "Parser.fsy"
                                                      _1 :: _2 
                   )
# 55 "Parser.fsy"
                 : 'gentype_exps));
# 176 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> System.Int32 in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "Parser.fsy"
                                                      Ast.IntExp _1 
                   )
# 58 "Parser.fsy"
                 : 'gentype_exp));
# 187 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "Parser.fsy"
                                                      Ast.VarExp _1 
                   )
# 59 "Parser.fsy"
                 : 'gentype_exp));
# 198 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "Parser.fsy"
                                                      Ast.DimExp 
                   )
# 60 "Parser.fsy"
                 : 'gentype_exp));
# 208 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "Parser.fsy"
                                Prog [] 
                   )
# 63 "Parser.fsy"
                 : 'gentype_end));
|]
# 219 "Parser.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 7;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let prog lexer lexbuf :  Ast.Prog  =
    engine lexer lexbuf 0 :?> _
