module ReaderActor

open System
open Akka.Actor
open Akka.FSharp

open WriterActor

type ReaderMessage =
    | ReadMessage

let ReaderActor (mailbox: Actor<_>) = 
               
    let rnd = new Random()

    printfn "deployed !!!"

    let rec reader() = 
        actor {
    
            let! msg = mailbox.Receive()

            printf "reader msg %A" msg
            
            //let writer = mailbox.ActorSelection("/user/WriterActor")
            //writer <! rnd.Next()

            return! reader()                
        }

    reader()

