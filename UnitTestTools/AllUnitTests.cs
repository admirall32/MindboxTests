using ShapeAreaCalculator.Shapes;

namespace UnitTestTools
{
    [TestClass]
    public class AllUnitTests
    {
        [TestMethod]
        public void UsualShapes()
        {
            Triangle triangle = new Triangle(3, 3, 5);

            decimal expectedArea = 4.146M;
            decimal actualArea = triangle.CalculateArea();

            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod]
        public void DoubleShapes()
        {
            Triangle triangle = new Triangle(3.1M, 3.22M, 5.555555M);

            decimal expectedArea = 4.184M;
            decimal actualArea = triangle.CalculateArea();

            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod]
        public void StraightAngleShapes()
        {
            Triangle triangle = new Triangle(3, 4, 5);

            bool expected = true;
            bool response = triangle.IsRightAngle;

            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public void NotStraightAngleShapes()
        {
            Triangle triangle = new Triangle(3, 4, 6);

            bool expected = false;
            bool response = triangle.IsRightAngle;

            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public void MinusAngleShapes()
        {
            try
            {
                Triangle triangle = new Triangle(-3, 4, 6);

                Assert.AreEqual(false, true);
            }
            catch (ArgumentException)
            {
                Assert.AreEqual(true, true);
            }
            catch (Exception)
            {
                Assert.AreEqual(false, true);
            }
        }

        [TestMethod]
        public void UnrealTriangle()
        {
            try
            {
                Triangle triangle = new Triangle(1, 2, 10);

                Assert.AreEqual(false, true);
            }
            catch (ArgumentException)
            {
                Assert.AreEqual(true, true);
            }
            catch (Exception)
            {
                Assert.AreEqual(false, true);
            }
        }

        [TestMethod]
        public void UnrealAngleTriangle()
        {
            Triangle triangle = new Triangle(1, 2, 3);


            decimal expected = 0;
            decimal response = triangle.CalculateArea();

            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public void AllSidesTriangle()
        {
            Triangle triangle = new Triangle(2, 3, 4);

            List<decimal> expected = new List<decimal>() { 2, 3, 4 };
            List<decimal> response = triangle.GetAllSides();

            CollectionAssert.AreEqual(expected, response);
        }
    }
}