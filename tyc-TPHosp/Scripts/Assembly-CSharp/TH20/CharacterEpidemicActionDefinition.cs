using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterEpidemicActionDefinition : CharacterActionDefinition
	{
		[InspectorHeader("Chance of Infection")]
		[SerializeField]
		private float _lowHygieneChance = 90f;

		[SerializeField]
		private float _highHygieneChance = 60f;

		public override void TriggerReaction(Character character, Character reactingTo)
		{
			bool flag = true;
			List<ChallengeEpidemic> activeChallengesOfType = character.Level.ChallengeManager.GetActiveChallengesOfType<ChallengeEpidemic>();
			if (activeChallengesOfType.Count == 1)
			{
				if (!ChallengeEpidemic.IsInfectableEver(character) || activeChallengesOfType[0].IsVaccinated(character))
				{
					flag = false;
				}
				else
				{
					AttributeFloat attribute = character.GetCharacterAttributes().GetAttribute(CharacterAttributes.Type.Hygiene);
					if (attribute != null)
					{
						float num = Mathf.Lerp(_lowHygieneChance, _highHygieneChance, attribute.Value() / 100f);
						if (RandomUtils.GlobalRandomInstance.NextFloat(0f, 100f) > num)
						{
							flag = false;
						}
					}
				}
			}
			if (flag)
			{
				base.TriggerReaction(character, reactingTo);
			}
			character.Level.StatusIconManager.ShowStatusIcon(reactingTo, StatusIcon.Type.EpidemicTell);
		}
	}
}
