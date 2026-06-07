using Coherence.Common;

namespace Coherence.RSL.ReplicationManager.ClientWorld
{
	public interface IOutgoingEntityChangeBuffer
	{
		void ShiftOutgoingPositionComponents(Vector3d floatingOriginShift);
	}
}
