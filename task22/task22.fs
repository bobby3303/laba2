open System

let rec input () =
    printfn "Введите количество элементов списка:"
    match Int32.TryParse(Console.ReadLine()) with
    | true, n when n >= 1 -> n
    | _ -> 
        eprintfn "Ошибка: введите целое положительное число!"
        input ()

let rec buildList cnt =
    if cnt <= 0 then 
        []
    else 
        printf "Введите число (0-9): "
        match Int32.TryParse(Console.ReadLine()) with
        | true, value when value >= 0 && value <= 9 ->
            value :: buildList (cnt - 1)
        | _ ->
            eprintfn "Ошибка: введите целое число от 0 до 9"
            buildList cnt

let digitToWord n =
    match n with
    | 0 -> "ноль"
    | 1 -> "один"
    | 2 -> "два"
    | 3 -> "три"
    | 4 -> "четыре"
    | 5 -> "пять"
    | 6 -> "шесть"
    | 7 -> "семь"
    | 8 -> "восемь"
    | 9 -> "девять"
    | _ -> "неизвестно"

let folder acc n =
    let word = digitToWord n
    if acc = "" then 
        word
    else 
        acc + "; " + word

[<EntryPoint>]
let main args = 
    let cnt = input()
    let inList = buildList cnt

    let result = List.fold folder "" inList

    printfn "\nИсходные числа: %A" inList
    printfn "Результат: «%s»" result

    0
