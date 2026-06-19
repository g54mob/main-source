using System.Threading;

namespace Loxodon.Framework.Execution
{
	public class CountDownEvent
	{
		private int max = 1;

		private int count;

		private AutoResetEvent reset = new AutoResetEvent(initialState: false);

		public CountDownEvent(int max)
		{
			this.max = max;
			count = 0;
		}

		public bool Set()
		{
			Interlocked.Decrement(ref count);
			return reset.Set();
		}

		public bool Wait()
		{
			if (Interlocked.Increment(ref count) >= max)
			{
				return reset.WaitOne();
			}
			return false;
		}
	}
}
