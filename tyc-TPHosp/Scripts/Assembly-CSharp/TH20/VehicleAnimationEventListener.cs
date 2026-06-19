using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class VehicleAnimationEventListener : MonoBehaviour
	{
		public ArrivalMethodVehicle Method { private get; set; }

		public void ArrivedEvent(AnimationEvent animationEvent)
		{
			Transform transform = base.transform.FindChildRecursively(animationEvent.stringParameter);
			Method.TriggerArrival(transform.position, transform.rotation);
		}

		public void DestroyEvent(AnimationEvent animationEvent)
		{
			Method.TriggerDestroy();
		}
	}
}
