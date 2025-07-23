using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestProject1.StepDefinitions.Api
{
    [Binding]
    public class CalculatorSteps
    {
        private Calculator _calculator = new Calculator();
        private int _result;

        [Given(@"Я ввел (\d+) в калькулятор")]
        public void GivenIHaveEnteredNumberIntoCalculator(int number)
        {
            _calculator.Enter(number);
        }

        [When(@"Я нажимаю кнопку сложения")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }

        [When(@"Я нажимаю кнопку умножения")]
        public void WhenIPressMultiply()
        {
            _result = _calculator.Multiply();
        }

        [Then(@"Результат должен быть (\d+)")]
        public void ThenResultShouldBe(int expected)
        {
            Assert.AreEqual(expected, _result);
        }
    }
}
