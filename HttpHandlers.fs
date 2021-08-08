namespace FirstGiraffe

module HttpHandlers =

    open Microsoft.AspNetCore.Http
    open FSharp.Control.Tasks
    open Giraffe
    open FirstGiraffe.Models

    let handleTodo: HttpFunc -> HttpContext -> HttpFuncResult =
        choose [ POST
                 >=> route "/todos"
                 >=> fun next context ->
                         let service = context.GetService<TodoSave>()
                         let todo = service "1"
                         json todo next context

                 GET
                 >=> routef
                         "/todos/%s"
                         (fun id ->
                             fun next context ->
                                 let service = context.GetService<TodoFind>()
                                 let todos = service id
                                 json todos next context) ]
