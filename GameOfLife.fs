namespace gol
module GameOfLife =
    type state = | Dead | Alive
    type cell = int*int*state
                                           
    let numOfNeighboursAlive (x,y,s) grid  =
        let samePosition (x1,y1) (x2,y2) =
            x1 = x2 && y1 = y2

        let areNeighbours (x1,y1,_) (x2,y2,_) =
            abs (x1 - x2) <=1 && abs (y1 - y2) <= 1 && not (samePosition (x1,y1) (x2,y2)) 
                               
        let neighbours cell  grid =   
            grid |> List.filter(fun c -> areNeighbours cell c)

        let neighborsAlive (x,y,s) grid  =
           neighbours (x,y,s) grid |> List.filter(fun (_,_,s) -> s = Alive)

        List.length(neighborsAlive (x,y,s) grid)
 
                            
    let nextGeneration grid = 
        let rec nextGenerationIter (remainingCells, accumul) =
            match remainingCells with 
                |(x,y,Alive)::T -> ( match numOfNeighboursAlive(x,y,Alive) grid with
                                    | (2|3) -> nextGenerationIter(T, accumul @ [(x,y,Alive)])
                                    | _ -> nextGenerationIter(T, accumul @ [(x,y,Dead)])
                                    )
                |(x,y,Dead)::T -> ( match numOfNeighboursAlive (x,y,Dead) grid with
                                    | 3 -> nextGenerationIter(T, accumul @ [(x,y,Alive)])
                                    | _ -> nextGenerationIter(T, accumul @ [(x,y,Dead)])
                                    )
                | [] -> accumul

        nextGenerationIter (grid, [])









