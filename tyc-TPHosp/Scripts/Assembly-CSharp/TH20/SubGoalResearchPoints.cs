using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalResearchPoints : LevelObjectiveSubGoal
	{
		private float _points;

		[DontSave]
		private SubGoalResearchPointsDefinition _definition;

		public SubGoalResearchPoints(Objective owner, SubGoalResearchPointsDefinition definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalResearchPointsDefinition;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalResearchPointsDefinition)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				ResearchManager researchManager = Level.ResearchManager;
				researchManager.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(researchManager.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			}
		}

		protected override void OnStart()
		{
			ResearchManager researchManager = Level.ResearchManager;
			researchManager.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(researchManager.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			ResearchManager researchManager = Level.ResearchManager;
			researchManager.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Remove(researchManager.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			base.OnEnd();
		}

		private void OnResearchPointsAdded(float points, ResearchProject project)
		{
			_points += points;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _points >= _definition.Points;
		}

		public override float PercentComplete()
		{
			return _points / _definition.Points;
		}

		public override int Score()
		{
			return (int)_points;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{Score()} / {(int)_definition.Points}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
