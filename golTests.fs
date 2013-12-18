namespace tests 
 module HisTests =
   
   open gol.GameOfLife 
   open System
   open NUnit.Framework
   
    [<Test>]
    let sillyTest() = 
        let firstCell = (1,1,Alive)
        Assert.AreEqual((1,1,Alive),firstCell)

    [<Test>]
        let testSamePosition() =
        Assert.IsTrue(samePosition (1,1) (1,1))

    [<Test>]
        let empty_grid_contains_neighbors_of_noone() =
            Assert.IsTrue(neighborsOf(1,1 ,Alive) [] = [])

    [<Test>]
        let neithbors_of_one_cell() =
            Assert.IsTrue(neighborsOf (1,1,Alive) [(0,1,Alive)] = [(0,1,Alive)])

    [<Test>]
        let neithbors_of_one_cell2() =
            Assert.IsTrue(neighborsOf (1,1,Alive) [(0,1,Alive)] = [(0,1,Alive)])

    [<Test>]
        let exclude_the_cell_itself_from_neighbors() =
            Assert.IsTrue(neighborsOf (1,1,Alive) [(0,1,Alive) ; (1,1,Alive)] = [(0,1,Alive)])


    [<Test>]
        let exclude_the_cell_itself_from_neighbors2() =
            Assert.IsTrue(neighborsOf (1,1,Alive) [(0,1,Alive) ; (1,1,Alive); (0,0,Alive)] = [(0,0,Alive);(0,1,Alive)])

    [<Test>]
        let num_of_neighbors_alive() =
            Assert.IsTrue(neighbors_alive(1,1,Alive) [(0,1,Alive) ; (1,1,Alive); (0,0,Dead)] = [(0,1,Alive)])

    [<Test>]
        let num_of_neighbors_alivedfdfdf() =
            let celllist: cell list = [(0,1,Alive) ; (1,1,Alive); (0,0,Dead)]
            Assert.IsTrue ( numOfNeighborsAlive (0,1,Alive) [(0,1,Alive) ; (1,1,Alive); (0,0,Dead)] = 1)           

    [<Test>]
        let num_of_neighbors_alivedfdf() =
            Assert.IsTrue ( List.length(neighbors_alive (1,1,Alive) [(0,1,Alive) ; (1,1,Alive); (0,0,Dead)]) = 1)


    [<Test>]
        let test_blinker2() =
            let blinkerStart  = [(0,0,Dead);(0,1,Alive);(0,2,Dead);
                                (1,0,Dead);(1,1,Alive);(1,2,Dead);
                                (2,0,Dead);(2,1,Alive);(2,2,Dead)]
            let blinkerEnd   = [(0,0,Dead); (0,1,Dead); (0,2,Dead);
                                (1,0,Alive);(1,1,Alive);(1,2,Alive);
                                (2,0,Dead); (2,1,Dead); (2,2,Dead)]

            Assert.IsTrue (nextGeneration blinkerStart = blinkerEnd)
