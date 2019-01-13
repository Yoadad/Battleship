namespace Battleship.GameController.Tests.GameControllerTests
{
    using System.Collections.Generic;

    using Battleship.GameController.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The is ship valid tests.
    /// </summary>
    [TestClass]
    public class CheckWinnerTests
    {
        /// <summary>
        /// The ship is not valid.
        /// </summary>
        [TestMethod]
        public void isWinner()
        {
            var ships = GameController.InitializeShips();
            var shots = new List<Position>();

            var counter = 0;
            foreach (var ship in ships)
            {
                var letter = (Letters)counter;
                for (int i = 0; i < ship.Size; i++)
                {
                    var position = new Position(letter, i);

                    ship.Positions.Add(position);
                    shots.Add(position);
                }

                counter++;
            }

            var result = GameController.CheckIsWin(ships, shots);



            Assert.IsTrue(result);
        }

        // <summary>
        /// The ship is not valid.
        /// </summary>
        [TestMethod]
        public void isNotWinner()
        {
            var ships = GameController.InitializeShips();
            var shots = new List<Position>();

            var counter = 0;
            foreach (var ship in ships)
            {
                var letter = (Letters)counter;
                for (int i = 0; i < ship.Size; i++)
                {
                    var position = new Position(letter, i);

                    ship.Positions.Add(position);
                    
                }

                counter++;
            }

            var result = GameController.CheckIsWin(ships, shots);

            Assert.IsFalse(result);
        }


    }
}