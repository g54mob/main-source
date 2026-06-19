using Unity.Collections;
using Unity.Entities;

namespace PlayerState
{
	public struct ChangePlayerStatePresentationLookups
	{
		[ReadOnly]
		public ComponentLookup<TriggerEffectCD> triggerEffectLookup;
	}
}
