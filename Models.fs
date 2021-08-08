namespace FirstGiraffe.Models

type Todo =
    { Id: string
      Text: string
      Done: bool }

type TodoFind = string -> Todo []
type TodoSave = string -> Todo
