namespace gol
module GameOfLife =
    type state = | Dead | Alive
    type cell = int*int*state

    let samePosition ((x1,y1), (x2,y2)) =
        x1 = x2 && y1 = y2
    
    let neighbors_of ((x,y,s),grid: cell list) =   
        let are_neighbors ((x1,y1,s1),(x2,y2,s2)) =
            abs (x1 - x2) <=1 && abs (y1 - y2) <= 1 && not (samePosition ((x1,y1), (x2,y2)))
       
        let rec neighbors_accumul (acell: cell, grid: cell list, accumul: cell list): cell list = 
            match grid with
                | [] -> accumul
                | H::T -> if are_neighbors(acell,H) then neighbors_accumul(acell,T, H::accumul) else neighbors_accumul(acell,T,accumul)

        neighbors_accumul((x,y,s),grid,[])

                           
    let neighbors_alive((x,y,c): cell ,grid: cell list): cell list =
        List.filter (fun (_,_,s) -> s = Alive) (neighbors_of((x,y,c),grid))

    let numOfNeighborsAlive ((x,y,s): cell,d: cell list): int  =
        List.length(neighbors_alive((x,y,s),d))
    
    let next_generation(grid) = 
        let rec next_generation_iter(remaining_cells: cell list, accumul: cell list): cell list =
            match remaining_cells with 
                |(X,y,Alive)::T -> ( match numOfNeighborsAlive((X,y,Alive),grid) with
                                    | (2|3) -> next_generation_iter(T, accumul @ [(X,y,Alive)])
                                    | _ -> next_generation_iter(T, accumul @ [(X,y,Dead)])

                                    )
                |(X,y,Dead)::T -> ( match numOfNeighborsAlive ((X,y,Dead),grid) with
                                    | 3 -> next_generation_iter(T, accumul @ [(X,y,Alive)])
                                    | _ -> next_generation_iter(T, accumul @ [(X,y,Dead)])
                                    )
                | [] -> accumul

        next_generation_iter(grid, [])

  

#if COMPILED

module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
//    do System.Windows.Forms.Application.Run()

#endif







