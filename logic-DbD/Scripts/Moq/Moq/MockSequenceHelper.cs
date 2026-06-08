using System.ComponentModel;
using Moq.Language;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class MockSequenceHelper
	{
		public static ISetupConditionResult<TMock> InSequence<TMock>(this Mock<TMock> mock, MockSequence sequence) where TMock : class
		{
			Guard.NotNull(sequence, "sequence");
			return sequence.For(mock);
		}
	}
}
