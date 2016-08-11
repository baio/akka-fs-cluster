module WriterActor

open System
open Akka.Actor
open Akka.FSharp

type WriterMessage =
    | WriteMessage of string

let WriterActor (mailbox: Actor<int>) = 
               
    let rec reader() = 
        actor {
    
            let! msg = mailbox.Receive()
            
            printfn "writer msg %i" msg
            (*
            match msg with
            | WriteMessage s -> printfn "%s" s
            *)

            return! reader()                
        }

    reader()

