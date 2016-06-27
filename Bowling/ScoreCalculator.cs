using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class ScoreCalculator : IScoreCalculator
    {
        public int Calc(IList<IFrame> frames, int framesPerGame)
        {
            var score = 0;
            for (var i = 0; i < framesPerGame - 1; i++)
            {
                score += frames[i].Rolls.Sum();

                var nextFrame = frames[i + 1];

                if (frames[i].IsSpare)
                {
                    score += nextFrame.Rolls.First();
                }
                if (frames[i].IsStrike)
                {
                    score += nextFrame.IsStrike && !(nextFrame is LastFrame)
                        ? nextFrame.Rolls.First() + frames[i + 2].Rolls.First()
                        : nextFrame.Rolls[0] + nextFrame.Rolls[1];
                }
            }
            score += frames[framesPerGame - 1].Rolls.Sum();
            return score;
        }
    }
}