using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace Bowling.Tests
{
    [TestFixture]
    public class When_playing_a_gutter_game
    {
        readonly BowlingGame _game = new BowlingGame();

        [SetUp]
        public void Setup()
        {
            for (var i = 0; i < 20; i++)
            {
                _game.Roll(0);
            }
        }

        [Test]
        public void it_should_score_zero()
        {
              _game.Score().ShouldBe(0);
        }
    }

    [TestFixture]
    public class When_hitting_one_pin_per_roll
    {
        readonly BowlingGame _game = new BowlingGame();

        [SetUp]
        public void Setup()
        {
            for (var i = 0; i < 20; i++)
            {
                _game.Roll(1);
            }
        }

        [Test]
        public void it_should_score_twenty()
        {
            _game.Score().ShouldBe(20);
        }
    }

    [TestFixture]
    public class When_roll_a_spare
    {
        readonly BowlingGame _game = new BowlingGame();

        [SetUp]
        public void Setup()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(3);
            for (var i = 0; i < 17; i++)
            {
                _game.Roll(0);
            }
        }

        [Test]
        public void it_should_double_up_the_roll_after_the_spare()
        {
            _game.Score().ShouldBe(16);
        }
    }

    [TestFixture]
    public class When_roll_a_strike
    {
        readonly BowlingGame _game = new BowlingGame();

        [SetUp]
        public void Setup()
        {
            _game.Roll(10);
            _game.Roll(5);
            _game.Roll(3);
            for (var i = 0; i < 16; i++)
            {
                _game.Roll(0);
            }
        }
        [Test]
        public void it_should_double_up_the_next_two_rolls()
        {
            _game.Score().ShouldBe(26);
        }
    }

    [TestFixture]
    public class When_a_perfect_game
    {
        readonly BowlingGame _game = new BowlingGame();

        [SetUp]
        public void Setup()
        {
            for (var i = 0; i < 12; i++)
            {
                _game.Roll(10);
            }
        }

        [Test]
        public void it_should_scoore_three_hundred()
        {
            _game.Score().ShouldBe(300);
        }
    }

    [TestFixture]
    public class When_strike_in_the_last_frame
    {
        readonly BowlingGame _game = new BowlingGame();

        [SetUp]
        public void Setup()
        {
            for (var i = 0; i < 18; i++)
            {
                _game.Roll(0);
            }
            _game.Roll(10);
            _game.Roll(10);
            _game.Roll(10);
        }
        [Test]
        public void it_should_scoore_three_hundred()
        {
            _game.Score().ShouldBe(30);
        }
    }
}
