


Console.WriteLine("Welcome in Game of Life");
Console.WriteLine("Enter the startup grid parametera");

var gameEngine = new GameEngine();

var gridPrinter = new GridPrinter();
Console.WriteLine("Cell grid state :");
gridPrinter.PrintGrid(gameEngine.GameGrid);


Console.WriteLine("Press enter to start simulation");
Console.ReadLine();

await Task.Run(() =>
{
    var generationNumber = 1;
    while (generationNumber < 100)
    {
        Console.Clear();
        Console.WriteLine($"Generation number = {generationNumber}");
        Console.WriteLine($"Alive symbol = {CellStateEnum.Alive.GetStringValue()}");
        Console.WriteLine($"Dead symbol = {CellStateEnum.Dead.GetStringValue()}");
        Console.WriteLine();

        gameEngine.CalculateNextGeneration(gameEngine.GameGrid);
        gridPrinter.PrintGrid(gameEngine.GameGrid);
        generationNumber++;
        Console.WriteLine("Press enter to show next generation");
        //Console.ReadLine(); //manual mode
        Thread.Sleep(1000); //AutoMode 1sec delay
    }
});

