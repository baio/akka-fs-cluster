// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Akka.FSharp
open Akka.FSharp.Spawn
open Akka.Actor

[<EntryPoint>]
let main argv = 
    let system = System.create "globomantics" (Configuration.load())
    system.WhenTerminated.Wait()
    0 // return an integer exit code