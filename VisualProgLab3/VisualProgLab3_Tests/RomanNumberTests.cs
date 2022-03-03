using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisualProgLab3;
using System;

namespace VisualProgLab3.Tests
{
    [TestClass()]
    public class RomanNumberTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            ushort a = 7;
            var Str = new RomanNumber(a);
            string expected = "VII";

            Assert.AreEqual(expected, Str.ToString(), "не работает ToString");
        }

        [TestMethod()]
        public void RomanNumberTest1()
        {
            //arrage
            ushort a = 7;
            string expected = "VII";

            var Constr = new RomanNumber(a);

            Assert.AreEqual(expected, Constr.ToString(), "Конструктор не работает с верным входным значением");
        }

        [TestMethod()]
        public void RomanNumberTest2()
        {
            //arrage          
            ushort b = 0;
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumber(b), "Не обработано исключение ноль");
        }

        [TestMethod()]
        public void RomanNumberTest3()
        {
            //arrage
            ushort c = 4000;

            Assert.ThrowsException<RomanNumberException>(() => new RomanNumber(c), "Не обработано исключение выход за границы");
        }

        [TestMethod()]
        public void AddTest()
        {
            ushort a = 22;
            ushort b = 12;
            string expected = "XXXIV";
            var Add1 = new RomanNumber(a);
            var Add2 = new RomanNumber(b);

            Assert.AreEqual(expected, (Add1 + Add2).ToString(), "Не рабтает сложение");
        }

        [TestMethod()]
        public void SubTest1()
        {
            ushort a = 20;
            ushort b = 5;
            string expected = "XV";
            var Sub1 = new RomanNumber(a);
            var Sub2 = new RomanNumber(b);

            Assert.AreEqual(expected, (Sub1 - Sub2).ToString(), "Не работает вычитание");
        }

        [TestMethod()]
        public void SubTest2()
        {
            ushort a = 3;
            ushort b = 9;
            var Sub1 = new RomanNumber(a);
            var Sub2 = new RomanNumber(b);

            Assert.ThrowsException<RomanNumberException>(() => (Sub1 - Sub2), "Исключение при вычитании из меньшего");
        }

        [TestMethod()]
        public void SubTest3()
        {
            ushort a = 9;
            ushort b = 9;
            var Sub1 = new RomanNumber(a);
            var Sub2 = new RomanNumber(b);

            Assert.ThrowsException<RomanNumberException>(() => (Sub1 - Sub2), "Исключение при вычитании двух равных");
        }

        [TestMethod()]
        public void MulTest()
        {
            ushort a = 7;
            ushort b = 6;
            string expected = "XLII";
            var Mul1 = new RomanNumber(a);
            var Mul2 = new RomanNumber(b);

            Assert.AreEqual(expected, (Mul1 * Mul2).ToString(), "Не рабтает умножение");
        }

        [TestMethod()]
        public void DivTest1()
        {
            ushort a = 21;
            ushort b = 3;
            string expected = "VII";
            var Div1 = new RomanNumber(a);
            var Div2 = new RomanNumber(b);

            Assert.AreEqual(expected, (Div1 / Div2).ToString(), "Не работает деление");
        }

        [TestMethod()]
        public void DivTest2()
        {
            ushort a = 12;
            ushort b = 9;
            var Div1 = new RomanNumber(a);
            var Div2 = new RomanNumber(b);

            Assert.ThrowsException<RomanNumberException>(() => (Div1 / Div2), "Исключение при делении - не делится нацело");
        }

        [TestMethod()]
        public void CloneTest()
        {
            ushort a = 9;
            var Cl1 = new RomanNumber(a);

            var Cl2 = (RomanNumber)Cl1.Clone();//клонируем Cl1 в Cl2

            Assert.AreNotSame(Cl1, Cl2, "Не работает Clone");//проверяем на то, что Cl1 и Cl2 ссылаются на разные объекты
        }

        [TestMethod()]
        public void CompareToTest1()
        {
            ushort a = 9;
            ushort b = 5;
            var Comp1 = new RomanNumber(a);
            RomanNumber? Comp2 = new RomanNumber(b);

            Assert.IsTrue((Comp1.CompareTo(Comp2) > 0), "Не работает CompareTo");//Comp1 > Comp2, поэтому CompareTo вернёт значение > 0

        }

        [TestMethod()]
        public void CompareToTest2()
        {
            ushort a = 9;
            var Comp1 = new RomanNumber(a);
            RomanNumber? Comp2 = null;

            Assert.ThrowsException<RomanNumberException>(() => (Comp1.CompareTo(Comp2)), "Исключение в CompareTo не работает");
        }
    }
}