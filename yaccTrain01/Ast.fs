module Ast

    open System
    open System.Collections.Generic


    type pos = int
    type Symbol = string
   
    type Comment = string

    type BoolCmpOper =
        | BoolCmpOpEq       // =

    type Exp = 
        | IntExp of int
        | VarExp of Var
        | DimExp
        | ExpBool of BoolExp

    and BoolExp =
        | BoolExpCmp of left: Exp * right: Exp * oper: BoolCmpOper

    and Var = 
        | SimpleVar of Symbol

    type Statement = 
        | AssignStmt of objExp1: Var * expr2: Exp * bSet: bool
        | BlankLine
    and StatementBlock = Statement list

    type Prog = Prog of StatementBlock

    let exprToStr expr =
        match expr with
        | IntExp n -> "IntExp: " + n.ToString()
        //| StringExp s -> "StringExp: " + s
        | VarExp vr -> sprintf "VarExp: %A " vr
        | DimExp -> "DimExp"

    let stmtToStr (stmt: Statement) : string =
        match stmt with
        | AssignStmt (objExp1, expr2, bSet) ->
            let sExp1 = sprintf "%A" objExp1
            let sExp2 = exprToStr expr2
            sExp1 + " = " + sExp2
        | BlankLine -> ""

    let progToStr (Prog stmtBlk) = 

        let sStmts = List.map stmtToStr stmtBlk
    
        sprintf "Prog (\n%s\n)\n" (String.Join("\n", sStmts))


