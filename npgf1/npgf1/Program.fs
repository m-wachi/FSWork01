// Learn more about F# at http://fsharp.org

open System
open Npgsql

let subfunc2 x =
    printfn "subfunc2"
    x + 1

[<EntryPoint>]
let main argv =
    let msg = "Hello World from F#!"
    printfn "%s" msg

    let subfunc1 p1 = 
        let m1 = "subfunc1"
        printfn "%s, %s" m1 p1
        0

    let a = subfunc1 msg

    printfn "%d" (subfunc2 3)


    // var connString = "Host=localhost;Username=wrio_user;Password=wrio_user;Database=wrio01";
    let connString = "Host=localhost;Username=wrio_user;Password=wrio_user;Database=wrio01"

    // var conn = new NpgsqlConnection(connString);
    let conn = NpgsqlConnection(connString)

    // conn.Open();
    conn.Open()

    // var sql = "select 'Hello PostgreSql.'";
    let sql = "select 'Hello PostgreSql.'"

    // var cmd = new NpgsqlCommand(sql, conn);
    let cmd = NpgsqlCommand(sql, conn)

    // var rdr = cmd.ExecuteReader();
    let rdr = cmd.ExecuteReader()

    //        rdr.Read();
    rdr.Read()

    // Console.WriteLine(rdr.GetString(0));
    printfn "%s" (rdr.GetString(0))

    // rdr.Close();
    rdr.Close()

    // conn.Close();
    conn.Close()

    0 // return an integer exit code

