namespace Moq.Behaviors
{
	internal sealed class VerifyInvocationCount : Behavior
	{
		private int count;

		private readonly Times times;

		private readonly MethodCall setup;

		public VerifyInvocationCount(MethodCall setup, Times times)
		{
			this.setup = setup;
			this.times = times;
			count = 0;
		}

		public void Reset()
		{
			count = 0;
		}

		public override void Execute(Invocation invocation)
		{
			count++;
			VerifyUpperBound();
		}

		public void Verify()
		{
			if (!times.Validate(count))
			{
				throw MockException.IncorrectNumberOfCalls(setup, times, count);
			}
		}

		public void VerifyUpperBound()
		{
			Times times = this.times;
			var (_, num3) = (Times)(ref times);
			if (count > num3)
			{
				throw MockException.IncorrectNumberOfCalls(setup, this.times, count);
			}
		}
	}
}
