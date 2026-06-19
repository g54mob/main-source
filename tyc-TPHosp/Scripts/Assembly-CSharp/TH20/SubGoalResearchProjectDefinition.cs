using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalResearchProjectDefinition : SubGoalDefinition
	{
		[SerializeField]
		private SharedInstance<ResearchProjectDefinition> _researchProject;

		public ResearchProjectDefinition ResearchProject
		{
			get
			{
				if (!(_researchProject != null) || _researchProject.Instance == null)
				{
					return null;
				}
				return _researchProject.Instance;
			}
		}

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalResearchProject(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			if (ResearchProject == null)
			{
				return ScriptLocalization.Challenges_SubGoals.CompleteAnyResearchProject_Goal_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.CompleteResearchProject_Goal_CS.Replace("{[PROJECT]}", ResearchProject.NameLocalised.Translation);
		}

		public override bool HasBeenAchieved(Level level)
		{
			if (ResearchProject != null && !level.Metagame.HasCompletedResearchProject(ResearchProject))
			{
				return ResearchProject.IsExcluded(level);
			}
			return true;
		}
	}
}
