using Xunit;
using CalcLB;
using System;
using FluentAssertions;

namespace testCalc
{
    public class UnitTest1
    {
        [Fact]
        public void Two_and_three()
        {
            var calc = new Calc();
            string numbers;
            numbers = "2,3";
            int exp = 5;
            int act = calc.Add(numbers);
            Assert.Equal(exp, act);
        }

        [Fact]
        public void Two_and_eight()
        {
            var calc = new Calc();
            string numbers;
            numbers = "2, 8";
            int exp = 10;
            int act = calc.Add(numbers);

            Assert.Equal(exp, act);
        }

        [Fact]
        public void Nothing()
        {
            var calc = new Calc();
            string numbers;
            numbers = "";
            int exp = 0;
            int act = calc.Add(numbers);

            Assert.Equal(exp, act);
        }

        [Fact]
        public void Nothing_with_a_space()
        {
            var calc = new Calc();
            string numbers;
            numbers = " ";
            int exp = 0;
            int act = calc.Add(numbers);

            Assert.Equal(exp, act);
        }

        [Fact]
        public void Nothing_with_a_Null()
        {
            var calc = new Calc();
            string numbers;
            numbers = null;
            int exp = 0;
            int act = calc.Add(numbers);

            Assert.Equal(exp, act);
        }

        [Fact]
        public void Two_and_minusOne()
        {
            var calc = new Calc();
            string numbers;
            numbers = "2,-1";
            int exp = 1;
            int act = calc.Add(numbers);

            Assert.Equal(exp, act);
        }

        [Fact]
        public void Two_and_character()
        {
            var calc = new Calc();
            string numbers;
            numbers = "2,a";
            //int exp = -1;
            //int act = calc.Add(numbers);
            Action action = () => calc.Add(numbers);
            action.Should().Throw<ArgumentException>().WithMessage("Ошибка сложения строки!");

            //Assert.Equal(exp, act);
        }

        [Fact]
        public void Two_and_transferSix()
        {
            var calc = new Calc();
            string numbers;
            numbers = "2\n 6";
            int exp = 8;
            int act = calc.Add(numbers);
            Assert.Equal(exp, act);
        }

        [Fact]
        public void TestSeparator()
        {
            var calc = new Calc();
            string numbers;
            numbers = "2\n 6a 3";
            string[] sep = { ",", "\n", "a" };
            int exp = 11;
            int act = calc.Add(numbers, sep);
            Assert.Equal(exp, act);
        }

        [Fact]
        public void TestSeparatorNull()
        {
            var calc = new Calc();
            string numbers;
            numbers = "1\n2 3";
            string[] sep = { };
            int exp = 6;
            int act = calc.Add(numbers, sep);
            Assert.Equal(exp, act);
        }



        [Fact]
        public void TestSeparatorNo()
        {
            var calc = new Calc();
            string numbers;
            numbers = "1 2 3";
            int exp = 6;
            int act = calc.Add(numbers);
            Assert.Equal(exp, act);
        }

        [Fact]
        public void Two_and_transfer()
        {
            var calc = new Calc();
            string numbers;
            numbers = "2\n"; 
            Action action = () => calc.Add(numbers);
            action.Should().Throw<ArgumentException>().WithMessage("Ошибка сложения строки!");
        }

        [Fact]
        public void TestNumberNoMore20()
        {
            var calc = new Calc();
            string numbers;
            numbers = "21\n 3, 6";
            int exp = 9;
            int act = calc.Add(numbers);

            Assert.Equal(exp, act);
        }

        [Fact]
        public void NoMore5Arguments()
        {
            var calc = new Calc();
            string numbers;
            numbers = "1\n 2, 3, 4, 5\n 6, 7, 8";
            int exp = 15;
            int act = calc.Add(numbers);

            Assert.Equal(exp, act);
        }


    }
}