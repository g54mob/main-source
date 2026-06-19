using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalMethodTimePortalDefinition : ArrivalMethodDefinition
	{
		public RuntimeAnimatorController CharacterNaturalAnimGraph;

		public RuntimeAnimatorController CharacterArtificialAnimGraph;

		public override ArrivalMethod Create(Level level, IArrivedCallback callback)
		{
			return new ArrivalMethodTimePortal(this, level, callback);
		}
	}
}
