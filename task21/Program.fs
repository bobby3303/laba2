open System

let rec input () =
    printfn "Введите количество элементов списка:"
    match Int32.TryParse(Console.ReadLine()) with
    | true, n when n >= 1 -> n
    | _ -> 
        eprintfn "Ошибка: введите целое положительное число!"
        input ()

let rec BuildList cnt =
    if cnt <= 0 then 
        []
    else 
        printf "Введите число (1-9): "
        match Int32.TryParse(Console.ReadLine()) with
        | true, value when value >= 1 && value <= 9 ->
            value :: BuildList (cnt - 1)
        | _ ->
            eprintfn "Ошибка: введите целое число от 1 до 9"
            BuildList cnt

let rec toBinary n =
    if n = 0 then 
        "0"
    elif n = 1 then 
        "1"
    else 
        (toBinary (n / 2)) + (string (n % 2))

[<EntryPoint>]
let main args = 
    let cnt = input()
    let inList = BuildList cnt

    let BinList = inList |> List.map toBinary

    printfn "\nИсходные числа: %A" inList
    printfn "В двоичной системе: %A" BinList

    0