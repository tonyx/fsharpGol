namespace gol
module GameOfLife =
    type state = | Dead | Alive
    type cell = int*int*state

    let samePosition (x1,y1) (x2,y2) =
        x1 = x2 && y1 = y2
    
    let neighborsOf  (x,y,s) grid =   
        let areNeighbors (x1,y1,_) (x2,y2,_) =
            abs (x1 - x2) <=1 && abs (y1 - y2) <= 1 && not (samePosition (x1,y1) (x2,y2))
       
        let rec neighborsAccumul (acell, grid, accumul) = 
            match grid with
                | [] -> accumul
                | H::T -> if areNeighbors acell H then neighborsAccumul(acell,T, H::accumul) else neighborsAccumul(acell,T,accumul)

        neighborsAccumul((x,y,s),grid,[])
                           
    let neighbors_alive (x,y,s) grid  =
        List.filter (fun (_,_,s) -> s = Alive) (neighborsOf (x,y,s) grid)

    let numOfNeighborsAlive (x,y,s) grid  =
        List.length(neighbors_alive (x,y,s) grid)
    
    let nextGeneration grid = 
        let rec nextGenerationIter (remainingCells, accumul) =
            match remainingCells with 
                |(x,y,Alive)::T -> ( match numOfNeighborsAlive(x,y,Alive) grid with
                                    | (2|3) -> nextGenerationIter(T, accumul @ [(x,y,Alive)])
                                    | _ -> nextGenerationIter(T, accumul @ [(x,y,Dead)])
                                    )
                |(x,y,Dead)::T -> ( match numOfNeighborsAlive (x,y,Dead) grid with
                                    | 3 -> nextGenerationIter(T, accumul @ [(x,y,Alive)])
                                    | _ -> nextGenerationIter(T, accumul @ [(x,y,Dead)])
                                    )
                | [] -> accumul

        nextGenerationIter (grid, [])

#if COMPILED


 module MainWindow =
    
        open System
        open Gtk

        type MyWindow() as this =
            inherit Window("MainWindow")
            
            do this.SetDefaultSize(400,300)
            do this.DeleteEvent.AddHandler(fun o e -> this.OnDeleteEvent(o,e))
            do this.ShowAll()
            
            member this.OnDeleteEvent(o,e:DeleteEventArgs) = 
                Application.Quit ()
                e.RetVal <- true




module start = 
        open System
        open Gtk

        [<EntryPoint>]
        let Main(args) = 
            Application.Init()

            let label = new Label()
            label.Text <- "oila'"
            let win: MyWindow = new MyWindow()
            win.Add(label)
//            win.Show()
            win.ShowAll()
            Application.Run()
            0




//module BoilerPlateForForm =
//    [<System.STAThread>]
//    do ()
////    do System.Windows.Forms.Application.Run()

#endif







