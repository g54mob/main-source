using System.Collections;
using System.Collections.Generic;

namespace Coherence.Toolkit
{
	public class SimulationStateStore<TState> : IEnumerable<TState>, IEnumerable
	{
		private long ackFrame;

		private readonly List<TState> store;

		public int Count => 0;

		public long NewestFrame { get; private set; }

		public long OldestFrame { get; private set; }

		public void Clear()
		{
		}

		public bool TryRollback(long mispredictionFrame, out TState validState)
		{
			validState = default(TState);
			return false;
		}

		public void Add(in TState state, long simulationFrame)
		{
		}

		public void Acknowledge(long frame)
		{
		}

		public IEnumerator<TState> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
