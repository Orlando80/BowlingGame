using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Bowling
{
    public class BowlingGame
    {
        private const int FramesPerGame = 10;
        private readonly IList<IFrame> _frames = new List<IFrame>();
        private readonly IScoreCalculator _calculator;

        public BowlingGame()
        {
            _calculator = new ScoreCalculator();
            for (int i = 0; i < FramesPerGame - 1; i++)
            {
                _frames.Add(new Frame());
            }
            _frames.Add(new LastFrame());
        }

        private int _framePosition;
        public void Roll(int pins)
        {
            if (_frames[_framePosition].IsCompleted)
            {
                _framePosition++;
            }
            _frames[_framePosition].AddRoll(pins);
        }

        public int Score()
        {
            return _calculator.Calc(_frames, FramesPerGame);
        }
    }
}