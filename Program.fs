let hiObject = { new obj() with member x.ToString() = "Hi!" }

printfn "%A" hiObject

type IDeepThought =
    abstract member TheAnswer: int with get
    abstract member AnswerString: unit -> string

type DeepThought()=
    interface IDeepThought with
        member x.TheAnswer = 42
        member x.AnswerString() = sprintf "The Answer is %d" (x :> IDeepThought).TheAnswer

let htmlDeepThought =
    let deepThought = DeepThought() :> IDeepThought
    { new IDeepThought with
        member x.TheAnswer = deepThought.TheAnswer
        member x.AnswerString() = sprintf "<b>%s</b>" (deepThought.AnswerString()) }

printfn "%A" (htmlDeepThought.AnswerString())

let confusedDeepThought answer =
    { new IDeepThought with
        member x.TheAnswer = answer
        member x.AnswerString() = "Duh...." }

let cdt = confusedDeepThought 35

printfn "%A" cdt.TheAnswer
printfn "%A" (cdt.AnswerString()) 