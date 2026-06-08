using System.Collections.Generic;
using Controllers;

namespace Kitchen
{
	public class InputQueue
	{
		private const int QueueAggregationLimit = 5;

		public InputState State;

		private Queue<InputState> Queue = new Queue<InputState>();

		private bool HasUpdates => Queue.Count > 0;

		private bool QueueOverLimit => Queue.Count > 5;

		public void ApplyUpdates()
		{
			if (HasUpdates)
			{
				if (QueueOverLimit)
				{
					InputState update = InputState.Neutral;
					foreach (InputState item in Queue)
					{
						update = update.ApplyUpdatedState(item, is_aggregation: true);
					}
					State = State.ApplyUpdatedState(update);
					Queue.Clear();
				}
				else
				{
					State = State.ApplyUpdatedState(Queue.Dequeue());
				}
			}
			else
			{
				State = State.ApplyUpdatedState(State);
				Queue.Clear();
			}
		}

		public void Enqueue(InputState update)
		{
			Queue.Enqueue(update);
		}
	}
}
