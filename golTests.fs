namespace tests 
module HisTests =
   
   open gol.GameOfLife 
   open System
   open NUnit.Framework
   

    [<Test>]
        let a_cell_has_no_neighbours_alive_in_an_empty_board() =
            Assert.AreEqual(0, numOfNeighboursAlive (1,1,Alive) [])

    [<Test>]
        let a_cell_has_no_neighbours_alive_in_one_neightbour_but_dead_cell_board() =
            Assert.AreEqual(0,numOfNeighboursAlive (1,1,Alive) [(0,1,Dead)])

    [<Test>]
        let a_cell_has_no_neighbours_alive_in_one_non_neighbor_cell_board() =
            Assert.AreEqual(0,numOfNeighboursAlive (1,1,Alive) [(999,999,Dead)])

    [<Test>]
        let ``a cell has with one neighbours alive (from a one neighbours alive board)``() =
            Assert.AreEqual(1,numOfNeighboursAlive (1,1,Alive) [(0,1,Alive)])

    [<Test>]
        let ``a cell has no neighbours in a borad that contains an alive cell in the same position of the cell``() =
            Assert.AreEqual(0,numOfNeighboursAlive (1,1,Alive) [(1,1,Alive)])

    [<Test>]
        let ``a cell has one neighbors alive in a cell that contains the cell itself and another alive neighbours``() =
            Assert.AreEqual(1,numOfNeighboursAlive (1,1,Alive) [(0,1,Alive) ; (1,1,Alive)])

    [<Test>]
        let ``exclude the cell from the count of the neighbours``() =
            let theCell = (1,1,Alive)
            let aliveNeighbourOfTheCell1 = (0,1,Alive)
            let aliveNeighbourOfTheCell2 = (0,0,Alive)
            Assert.AreEqual(2,numOfNeighboursAlive theCell [theCell ; aliveNeighbourOfTheCell1; aliveNeighbourOfTheCell2])


    [<Test>]
        let num_of_neighbors_alive_test2() =
            let celllist: cell list = [(0,1,Alive) ; (1,1,Alive); (0,0,Dead)]
            Assert.AreEqual(1,numOfNeighboursAlive (0,1,Alive) [(0,1,Alive) ; (1,1,Alive); (0,0,Dead)])


    [<Test>]
        let test_blinker() =
            let blinkerStart  = [(0,0,Dead);(0,1,Alive);(0,2,Dead);
                                (1,0,Dead);(1,1,Alive);(1,2,Dead);
                                (2,0,Dead);(2,1,Alive);(2,2,Dead)]
            let blinkerEnd   = [(0,0,Dead); (0,1,Dead); (0,2,Dead);
                                (1,0,Alive);(1,1,Alive);(1,2,Alive);
                                (2,0,Dead); (2,1,Dead); (2,2,Dead)]

            Assert.AreEqual (blinkerEnd, nextGeneration blinkerStart)


    [<Test>]
        let more_complex_test_next_generation() =
            let tick0 =  
               [(0,0,Dead);  (0,1,Dead);  (0,2,Dead);  (0,3,Dead);  (0,4,Dead);
                (1,0,Dead) ; (1,1,Alive); (1,2,Alive); (1,3,Alive); (1,4,Dead);
                (2,0,Dead) ; (2,1,Dead);  (2,2,Alive); (2,3,Alive); (2,4,Dead);
                (3,0,Dead) ; (3,1,Alive); (3,3,Dead);  (3,3,Alive); (3,4,Dead);
                (4,0,Dead) ; (4,1,Dead);  (4,2,Dead);  (4,3,Dead);  (4,4,Dead)];
            
            let tick1 =
                 [(0,0,Dead); (0,1,Dead);    (0,2,Alive); (0,3,Dead);  (0,4,Dead);
                  (1,0,Dead) ; (1,1,Alive);  (1,2,Dead);  (1,3,Alive); (1,4,Dead);
                  (2,0,Dead) ; (2,1,Dead);   (2,2,Dead);  (2,3,Dead);  (2,4,Alive);
                  (3,0,Dead) ; (3,1,Dead);   (3,3,Dead);  (3,3,Alive); (3,4,Dead);
                  (4,0,Dead) ; (4,1,Dead);   (4,2,Dead);  (4,3,Dead);  (4,4,Dead)];

            Assert.AreEqual(tick1, nextGeneration tick0)


