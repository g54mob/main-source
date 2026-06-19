using UnityHFSM;

namespace AssembleSystem.FSM.PlacedObject
{
	public class PlacedParentAssembledState : StateBase<StateIdentifier>
	{
		public PlacedParentAssembledState(bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
		}
	}
}
