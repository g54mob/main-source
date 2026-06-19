using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace PlayerState
{
	public struct StatePresentationUpdateLookups
	{
		[ReadOnly]
		public ComponentLookup<GhostOwnerIsLocal> ghostOwnerIsLocalLookup;

		[ReadOnly]
		public ComponentLookup<PredictedGhost> predictedGhostLookup;

		[ReadOnly]
		public ComponentLookup<VehicleCD> vehicleLookup;

		[ReadOnly]
		public ComponentLookup<TriggerEffectCD> triggerEffectLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsLookup;
	}
}
