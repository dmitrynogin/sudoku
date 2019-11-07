using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Tests
{
    [TestClass]
    public class Board_Should
    {
        [TestMethod]
        public void Be_Valid()
        {
            var data = new int?[,]
            {
                { 5, 3, null },
                { 6, null, null },
                { null, 9, 8 }
            };

            var board = new Board(data);
            Assert.IsTrue(board.Valid);
        }

        [TestMethod]
        public void Be_Invalid()
        {
            var data = new int?[,]
            {
                { 5, 3, 8 },
                { 6, null, null },
                { null, 9, 8 }
            };

            var board = new Board(data);
            Assert.IsFalse(board.Valid);
        }
    }
}
