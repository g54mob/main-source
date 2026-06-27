using Moq.Language;
using Moq.Language.Flow;

namespace Moq
{
	public class MockSequence
	{
		private int sequenceStep;

		private int sequenceLength;

		public bool Cyclic { get; set; }

		public MockSequence()
		{
			sequenceLength = 0;
			sequenceStep = 0;
		}

		private void NextStep()
		{
			sequenceStep++;
			if (Cyclic)
			{
				sequenceStep %= sequenceLength;
			}
		}

		internal ISetupConditionResult<TMock> For<TMock>(Mock<TMock> mock) where TMock : class
		{
			int expectationPosition = sequenceLength++;
			return new WhenPhrase<TMock>(mock, new Condition(() => expectationPosition == sequenceStep, NextStep));
		}
	}
}
