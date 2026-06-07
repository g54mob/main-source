using System;

namespace Coherence.RSL
{
	public interface IReplicationServerLite : IDisposable
	{
		void Tick();
	}
}
