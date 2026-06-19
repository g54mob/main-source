using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardFlavourText : IReward
	{
		[SerializeField]
		private LocalisedString _text;

		public void Apply(Objective objective, Level level)
		{
		}

		public string Description(Objective objective)
		{
			if (_text.Term == null)
			{
				return null;
			}
			return _text.Translation;
		}
	}
}
