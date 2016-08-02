module ReaderActor

open System
open Akka.Actor
open Akka.FSharp

open WriterActor

type ReaderMessage =
    | ReadMessage

let ReaderActor (mailbox: Actor<ReaderMessage>) = 
               
    let rnd = new Random()

    let rec reader() = 
        actor {
    
            let! msg = mailbox.Receive()
            
            match msg with
            | ReadMessage -> 
                let writer = mailbox.ActorSelection("/user/WriterActor")
                writer <! WriteMessage(rnd.Next().ToString())

            return! reader()                
        }

    reader()

