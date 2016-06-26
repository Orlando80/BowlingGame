using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public interface IFrame
    {
        bool IsStrike { get; }
        bool IsSpare { get; }
        bool IsCompleted { get; }
        IList<int> Rolls { get; }
        void AddRoll(int pins);
    }

    public class Frame : IFrame
    {
        private const int Rollsperframe = 2;
        private readonly IList<int> _rolls = new List<int>();
        public bool IsStrike => _rolls.Count == 1 && _rolls[0] == 10;
        public bool IsSpare => _rolls.Count == 2 && _rolls.Sum() == 10;
        public bool IsCompleted => _rolls.Count == Rollsperframe || IsStrike;

        public IList<int> Rolls => _rolls;

        public void AddRoll(int pins)
        {
         _rolls.Add(pins);   
        }
    }

    public class LastFrame : IFrame
    {
        private const int Rollsperframe = 3;
        private readonly IList<int> _rolls = new List<int>();
        public bool IsStrike => _rolls.Count == 1 && _rolls[0] == 10;
        public bool IsSpare => _rolls.Count == 2 && _rolls.Sum() == 10;
        public bool IsCompleted => _rolls.Count == Rollsperframe;

        public IList<int> Rolls => _rolls;

        public void AddRoll(int pins)
        {
            _rolls.Add(pins);
        }
    }

}
