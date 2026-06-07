using System;

namespace Brewery.Minigames
{
	public class GrindPatternSequence
	{
		private readonly int[] sequence;

		private int inputIndex;

		public int Length => 0;

		public int InputIndex => 0;

		public bool IsComplete => false;

		public GrindPatternSequence(int length, Func<int, int> rng, int buttonCount = 4)
		{
		}

		public int GetStep(int index)
		{
			return 0;
		}

		public bool TryInput(int buttonIndex)
		{
			return false;
		}
	}
}
