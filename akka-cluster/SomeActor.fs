module ReaderActor

open System
open Akka.Actor
open Akka.FSharp

type ReaderMessage =
    | ReaderMessage of string

let ReaderActor (mailbox: Actor<ReaderMessage>) = 
               
    let rec reader() = 
        actor {
    
            let! msg = mailbox.Receive()
            
            match msg with
            | ReaderMessage s -> printfn "%s" s

            return! reader()                
        }

    reader()

