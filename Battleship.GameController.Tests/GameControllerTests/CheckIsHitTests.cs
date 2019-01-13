namespace Battleship.GameController.Tests.GameControllerTests
{
    using System;
    using System.Collections.Generic;
    using Battleship.GameController.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The game controller tests.
    /// </summary>
    [TestClass]
    public class GameControllerTests
    {

        /// <summary>
        /// The should win the game.
        /// </summary>
        [TestMethod]
        public void ShouldWinTheGame()
        {
            var ships = GameController.InitializeShips();
            var positions = new List<Position>();
            var counter = 0;
            foreach (var ship in ships)
            {
                var letter = (Letters)counter;
                for (int i = 0; i < ship.Size; i++)
                {
                    var position = new Position(letter, i);
                    ship.Positions.Add(position);
                    positions.Add(position);
                }
                counter++;
            }
            var result = GameController.CheckIsWin(ships, positions);
            Assert.IsTrue(result);
        }
        /// <summary>
        /// The should hit the ship.
        /// </summary>
        [TestMethod]
        public void ShouldHitTheShip()
        {
            var ships = GameController.InitializeShips();

            var counter = 0;
            foreach (var ship in ships)
            {
                var letter = (Letters)counter;
                for (int i = 0; i < ship.Size; i++)
                {
                    ship.Positions.Add(new Position(letter, i));
                }

                counter++;
            }

            var result = GameController.CheckIsHit(ships, new Position(Letters.A, 1));
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The should not hit the ship.
        /// </summary>
        [TestMethod]
        public void ShouldNotHitTheShip()
        {
            var ships = GameController.InitializeShips();

            var counter = 0;
            foreach (var ship in ships)
            {
                var letter = (Letters)counter;
                for (int i = 0; i < ship.Size; i++)
                {
                    ship.Positions.Add(new Position(letter, i));
                }

                counter++;
            }

            var result = GameController.CheckIsHit(ships, new Position(Letters.H, 1));
            Assert.IsFalse(result);
        }

        /// <summary>
        /// The throw exception if positstion is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionIfPositstionIsNull()
        {
            GameController.CheckIsHit(GameController.InitializeShips(), null);
        }

        /// <summary>
        /// The throw exception if ship is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionIfShipIsNull()
        {
            GameController.CheckIsHit(null, new Position(Letters.H, 1));
        }
    }
}