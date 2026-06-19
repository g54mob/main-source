using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalMethodSubwayDefinition : ArrivalMethodDefinition
	{
		public RuntimeAnimatorController CharacterAnimGraph;

		public override ArrivalMethod Create(Level level, IArrivedCallback callback)
		{
			return new ArrivalMethodSubway(this, level, callback);
		}
	}
}
