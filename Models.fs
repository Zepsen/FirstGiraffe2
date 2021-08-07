namespace FirstGiraffe.Models
open MongoDB.Driver

type Todo = 
    { 
        Id: string
        Text: string
        Done: bool
    }

type TodoFind = unit -> Todo[]
type TodoSave = unit -> Todo