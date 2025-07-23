using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1;

public class Calculator
{
    private List<int> _numbers = new List<int>();

    public void Enter(int number)
    {
        _numbers.Add(number);
    }

    public int Add()
    {
        return _numbers.Sum();
    }

    public int Multiply()
    {
        return _numbers.Aggregate(1, (a, b) => a * b);
    }
}
