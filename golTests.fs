namespace tests 
 module HisTests =
   
   open gol.GameOfLife 
   open System
   open NUnit.Framework
   

    [<Test>]
        let neithbors_of_one_cell() =
            Assert.IsTrue(numOfNeighboursAlive (1,1,Alive) [(0,1,Alive)] = 1)

    [<Test>]
        let exclude_the_cell_itself_from_neighbors() =
            Assert.IsTrue(numOfNeighboursAlive (1,1,Alive) [(0,1,Alive) ; (1,1,Alive)] = 1)

    [<Test>]
        let exclude_the_cell_itself_from_neighbors2() =
            Assert.IsTrue(numOfNeighboursAlive (1,1,Alive) [(0,1,Alive) ; (1,1,Alive); (0,0,Alive)] = 2)


    [<Test>]
        let num_of_neighbors_alive_test2() =
            let celllist: cell list = [(0,1,Alive) ; (1,1,Alive); (0,0,Dead)]
            Assert.IsTrue ( numOfNeighboursAlive (0,1,Alive) [(0,1,Alive) ; (1,1,Alive); (0,0,Dead)] = 1)           


    [<Test>]
        let test_blinker2() =
            let blinkerStart  = [(0,0,Dead);(0,1,Alive);(0,2,Dead);
                                (1,0,Dead);(1,1,Alive);(1,2,Dead);
                                (2,0,Dead);(2,1,Alive);(2,2,Dead)]
            let blinkerEnd   = [(0,0,Dead); (0,1,Dead); (0,2,Dead);
                                (1,0,Alive);(1,1,Alive);(1,2,Alive);
                                (2,0,Dead); (2,1,Dead); (2,2,Dead)]

            Assert.IsTrue (nextGeneration blinkerStart = blinkerEnd)


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

            Assert.IsTrue(nextGeneration tick0 = tick1)


