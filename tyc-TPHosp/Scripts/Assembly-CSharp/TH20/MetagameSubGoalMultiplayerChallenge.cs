using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalMultiplayerChallenge : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionMultiplayerChallenge _definition;

		[SerializeField]
		private int _currentCount;

		public MetagameSubGoalMultiplayerChallenge(Objective owner, MetagameSubGoalDefinitionMultiplayerChallenge definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				ObjectiveEvents objectiveEvents = Metagame.ObjectiveEvents;
				objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				ObjectiveEvents objectiveEvents = oldMetagame.ObjectiveEvents;
				objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			}
			if (newMetagame != null)
			{
				ObjectiveEvents objectiveEvents2 = newMetagame.ObjectiveEvents;
				objectiveEvents2.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents2.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				ObjectiveEvents objectiveEvents = Metagame.ObjectiveEvents;
				objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			}
			base.Destroy();
		}

		private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
		{
			if (objective is OnlineChallengeObjective)
			{
				_currentCount++;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _currentCount >= _definition.Count;
		}

		public override float PercentComplete()
		{
			return (float)_currentCount / (float)_definition.Count;
		}

		public override int Score()
		{
			return _currentCount;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_currentCount} / {_definition.Count}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
