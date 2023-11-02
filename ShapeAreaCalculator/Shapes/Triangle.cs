using System;
using System.Security.Cryptography;
using ShapeAreaCalculator.Interfaces;

namespace ShapeAreaCalculator.Shapes
{
    public class Triangle : IShapeCalculeteArea
    {
        //Треугольник является прямоугольным
        public bool IsRightAngle { get; private set; }
        public decimal Hypotenuse { get; private set; }
        public decimal SideA { get; private set; }
        public decimal SideB { get; private set; }

        public Triangle(decimal sideA, decimal sideB, decimal sideC)
        {
            List<decimal> Sides = new List<decimal>() { sideA, sideB, sideC };

            if (Sides.Any(x => x <= 0))
            {
                throw new ArgumentException("Стороны треугольника должны быть положительными числами.");
            }

            Sides.Sort();
            SideA = Sides[0];
            SideB = Sides[1];
            Hypotenuse = Sides[2];


            if ((Hypotenuse - SideA - SideB) > 0)
            {
                throw new ArgumentException("Такого треугольника не существует.");
            }

            IsRightAngle = Math.Pow((double)SideA, 2) + Math.Pow((double)SideB, 2) == Math.Pow((double)Hypotenuse, 2);
        }

        //Подсчет площади фигуры
        public decimal CalculateArea()
        {
            decimal area;

            if (IsRightAngle)
            {
                area = (SideA * SideB) / 2;
            }
            else
            {
                decimal halfPerimeter = GetAllSides().Sum() / 2;

                area = (decimal)Math.Sqrt((double)(
                    halfPerimeter
                    * (halfPerimeter - Hypotenuse)
                    * (halfPerimeter - SideA)
                    * (halfPerimeter - SideB)
                ));
            }

            return Math.Round(area, 3);
        }

        //Получение всех сторон треугольника
        public List<decimal> GetAllSides()
        {
            List<decimal> allSides = new List<decimal> { Hypotenuse, SideA, SideB };

            allSides.Sort();

            return allSides;
        }
    }
}