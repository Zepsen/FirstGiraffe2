namespace FirstGiraffe

module FirstService =
    open FirstGiraffe.Models
    open MongoDB.Driver
    open Microsoft.Extensions.DependencyInjection

    let find (collection: IMongoCollection<Todo>) (id: string) : Todo [] =
        collection
            .Find(Builders.Filter.Empty)
            .ToEnumerable()
        |> Seq.toArray


    let save (collection: IMongoCollection<Todo>) (todo: Todo) : Todo =
        collection.InsertOne todo
        todo

    type IServiceCollection with
        member this.AddMongoRepo(collection: IMongoCollection<Todo>) =
            this.AddSingleton<TodoFind>(find collection)
            |> ignore

            this.AddSingleton<TodoSave>(save collection)
            |> ignore
