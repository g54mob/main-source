using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengeDefinition : ObjectiveDefinition
	{
		public float ChallengeWeight = 1f;

		public float CoolDownTimeSeconds = 20f;

		public int DifficultyRating;

		[FullInspector.InspectorName("Intro Message Text")]
		public LocalisedString IntroMessageTextLocalised;

		[FullInspector.InspectorName("Outro Message Success Text")]
		public LocalisedString OutroMessageSuccessTextLocalised;

		[FullInspector.InspectorName("Outro Message Failed Text")]
		public LocalisedString OutroMessageFailedTextLoaclised;

		[SerializeField]
		private StaffChallengePrerequisite[] Prerequisites;

		public override string ToString()
		{
			return DescriptionLocalised.Translation;
		}

		public bool IsSuitable(Level level, Staff staff)
		{
			if (Prerequisites != null)
			{
				StaffChallengePrerequisite[] prerequisites = Prerequisites;
				for (int i = 0; i < prerequisites.Length; i++)
				{
					if (!prerequisites[i].IsValid(level, staff))
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
