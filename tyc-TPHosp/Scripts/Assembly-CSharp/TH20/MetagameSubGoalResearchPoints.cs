using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MetagameSubGoalResearchPoints : MetagameObjectiveSubGoal
	{
		private float _points;

		private MetagameSubGoalResearchPointsDefinition _definition;

		public MetagameSubGoalResearchPoints(Objective owner, MetagameSubGoalResearchPointsDefinition definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is MetagameSubGoalResearchPointsDefinition;
		}

		public override void RestoreFromSave()
		{
			_definition = (MetagameSubGoalResearchPointsDefinition)base.Definition;
			base.RestoreFromSave();
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(levelEventsIntermediary.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Remove(levelEventsIntermediary.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(levelEventsIntermediary2.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Remove(levelEventsIntermediary.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			}
			base.Destroy();
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
