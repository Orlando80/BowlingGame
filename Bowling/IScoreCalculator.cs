using System.Collections.Generic;

namespace Bowling
{
    public interface IScoreCalculator
    {
        int Calc(IList<IFrame> frames, int framesPerGame);
    }
}