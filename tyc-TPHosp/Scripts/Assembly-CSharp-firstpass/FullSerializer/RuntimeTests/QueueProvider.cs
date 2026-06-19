using System.Collections.Generic;
using System.Linq;

namespace FullSerializer.RuntimeTests
{
	public class QueueProvider : TestProvider<Queue<int>>
	{
		public override bool Compare(Queue<int> before, Queue<int> after)
		{
			if (before.Except(after).Count() == 0)
			{
				return after.Except(before).Count() == 0;
			}
			return false;
		}

		public override IEnumerable<Queue<int>> GetValues()
		{
			yield return new Queue<int>();
			Queue<int> queue = new Queue<int>();
			queue.Enqueue(1);
			yield return queue;
			queue = new Queue<int>();
			queue.Enqueue(1);
			queue.Enqueue(5);
			queue.Enqueue(3);
			yield return queue;
		}
	}
}
