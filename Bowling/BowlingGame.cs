using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Bowling
{
    public class BowlingGame
    {
        private const int FramesPerGame = 10;
        private readonly IList<IFrame> _frames = new List<IFrame>();

        public BowlingGame()
        {
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
            var score = 0;
            for (var i = 0; i < FramesPerGame - 1; i++)
            {
                score += _frames[i].Rolls.Sum();
                if (_frames[i].IsSpare)
                {
                    score += _frames[i + 1].Rolls.First();
                }
                if (_frames[i].IsStrike)
                {
                    score += _frames[i + 1].IsStrike && !(_frames[i + 1] is LastFrame)
                        ? _frames[i + 1].Rolls.First() + _frames[i + 2].Rolls.First()
                        : _frames[i + 1].Rolls[0] + _frames[i + 1].Rolls[1];
                }
            }
            score += _frames[FramesPerGame - 1].Rolls.Sum();
            return score;
        }
    }
}