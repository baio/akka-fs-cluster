// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Akka.FSharp
open Akka.FSharp.Spawn
open Akka.Actor
open FSharp.Configuration

open WriterActor
open ReaderRouter

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let system = System.create "mySystem" (Configuration.load())
    let writer = spawn system "WriterActor" (WriterActor)    
    let readerRouter = spawn system "ReaderRouter" (ReaderRouter writer)    
    
    readerRouter <! ReaderRouterStart

    system.WhenTerminated.Wait()

    System.Console.ReadLine() |> ignore

    0 // return an integer exit code
