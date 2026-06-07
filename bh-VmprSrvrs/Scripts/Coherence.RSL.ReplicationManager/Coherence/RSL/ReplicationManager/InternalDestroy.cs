using Coherence.Entities;

namespace Coherence.RSL.ReplicationManager
{
	public struct InternalDestroy
	{
		public Entity ID;

		public DestroyReason Reason;
	}
}
