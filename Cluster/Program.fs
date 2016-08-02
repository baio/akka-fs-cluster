// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Akka.FSharp
open Akka.FSharp.Spawn
open Akka.Actor
open FSharp.Configuration

open WriterActor
//open ReaderRouter
open ReaderActor

[<EntryPoint>]
let main argv = 

    let system = System.create "globomantics" (Configuration.load())

    
    let writer = spawn system "WriterActor" (WriterActor)    

    //let routerOpt = SpawnOption.Router ( Akka.Routing.FromConfig.Instance )
    //let supervisionOpt = SpawnOption.SupervisorStrategy (Strategy.OneForOne(fun _ -> Directive.Stop))

    let reader = spawn system "ReaderActor" (ReaderActor)
    //let readerRouter = spawn system "ReaderRouter" (ReaderRouter writer)    
    
    reader <! ReadMessage
    //readerRouter <! ReaderRouterStart
    
    system.WhenTerminated.Wait()


    0 // return an integer exit code
