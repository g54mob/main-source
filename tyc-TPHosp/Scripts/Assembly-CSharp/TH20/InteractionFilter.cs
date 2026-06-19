using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InteractionFilter
	{
		[SerializeField]
		protected bool _enabled;

		public virtual bool IsValid(ObjectInteraction interaction, Character character)
		{
			return true;
		}
	}
}
