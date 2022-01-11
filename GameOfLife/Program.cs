
using GameOfLife.Engine;
using GameOfLife.Printers;

Console.WriteLine("Welcome in Game of Life");
Console.WriteLine("Enter the startup grid parametera");

var gameEngine = new GameEngine();

var gridPrinter = new GridPrinter();


gridPrinter.PrintGrid(gameEngine.GameGrid);

