using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierInfected : CharacterModifier
	{
		public override void Add(Character character)
		{
			List<ChallengeEpidemic> activeChallengesOfType = character.Level.ChallengeManager.GetActiveChallengesOfType<ChallengeEpidemic>();
			if (activeChallengesOfType.Count == 1)
			{
				activeChallengesOfType[0].AddInfection(character);
			}
			base.Add(character);
		}

		public override void Remove(Character character)
		{
			List<ChallengeEpidemic> activeChallengesOfType = character.Level.ChallengeManager.GetActiveChallengesOfType<ChallengeEpidemic>();
			if (activeChallengesOfType.Count == 1)
			{
				activeChallengesOfType[0].RemoveInfection();
			}
			base.Remove(character);
		}
	}
}
