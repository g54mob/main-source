using Unity.Entities;
using Unity.NetCode;

namespace PlayerState
{
	public struct CastingStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public TickTimer castTimer;

		[GhostField]
		public int previousHealth;

		[GhostField]
		public int previousMaxHealth;

		[GhostField]
		public bool itemIsInProcessOfBeingUsed;

		[GhostField]
		public ObjectDataCD objectData;

		[GhostField]
		public int inventoryIndexOnCast;

		[GhostField]
		public TickTimer exitStateDelayTimer;

		[GhostField]
		public EffectID castCompleteEffect;
	}
}
