using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AnimationProperties
	{
		[InspectorRange(0f, 3f)]
		public float Duration;

		public AnimationCurve Curve;

		public bool InterruptOtherAnimations;
	}
}
