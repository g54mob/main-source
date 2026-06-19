using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierMicroBehaviour : CharacterModifier
	{
		[SerializeField]
		private float MinFrequencyInSeconds;

		[SerializeField]
		private float MaxFrequencyInSeconds;

		public SharedInstance<CharacterActionDefinition> Action;

		public float Frequency()
		{
			return RandomUtils.GlobalRandomInstance.NextFloat(MinFrequencyInSeconds, MaxFrequencyInSeconds);
		}
	}
}
