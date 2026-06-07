using System;

namespace Coherence.Common
{
	public interface IStopwatch
	{
		long ElapsedMilliseconds { get; }

		TimeSpan Elapsed { get; }

		void Start();

		void Reset();

		void Restart();

		void Stop();
	}
}
