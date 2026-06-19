using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class GuestTrainerDefinition : StaffDefinition
	{
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class Skill
		{
			public SharedInstance<QualificationDefinition> Qualification;

			[SerializeField]
			private int UpfrontCost;

			[SerializeField]
			private int CostPerTrainee;

			public int GetUpfrontCost(Level level)
			{
				return (int)((float)UpfrontCost * level.Config.GuestTrainerUpfrontCostMultiplier);
			}

			public int GetCostPerTrainee(Level level)
			{
				return (int)((float)CostPerTrainee * level.Config.GuestTrainerCostPerTraineeMultiplier);
			}
		}

		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Guest Trainer Data")]
		public CharacterName Name;

		public Character.Sex Sex;

		public int Rank;

		public Skill[] Skills;

		public LocalisedString FlavourTrait;

		public SharedInstance<CharacterTraitDefinition>[] Traits;

		public SharedInstance<ArrivalMethodDefinition> ArrivalMethod;

		public Skill GetSkill(QualificationDefinition qualification)
		{
			Skill[] skills = Skills;
			foreach (Skill skill in skills)
			{
				if (skill.Qualification.Instance == qualification)
				{
					return skill;
				}
			}
			return null;
		}
	}
}
