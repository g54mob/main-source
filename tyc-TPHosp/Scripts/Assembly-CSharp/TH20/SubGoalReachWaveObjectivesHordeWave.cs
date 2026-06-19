using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalReachWaveObjectivesHordeWave : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionReachWaveObjectivesHordeWave _definition;

		private int _currentWaveNum;

		public SubGoalReachWaveObjectivesHordeWave(Objective owner, SubGoalDefinitionReachWaveObjectivesHordeWave definition)
			: base(owner, definition)
		{
			_definition = definition;
			UpdateCurrentWave();
		}

		private void UpdateCurrentWave()
		{
			ChallengeWaveObjectivesHorde objective = Level.LevelScriptManager.GetObjective<ChallengeWaveObjectivesHorde>();
			if (objective != null)
			{
				_currentWaveNum = objective.WaveNum;
			}
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionReachWaveObjectivesHordeWave;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionReachWaveObjectivesHordeWave)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				ChallengeWaveObjectivesHorde.OnWaveChanged = (Action<int, int>)Delegate.Combine(ChallengeWaveObjectivesHorde.OnWaveChanged, new Action<int, int>(OnWaveChanged));
				UpdateCurrentWave();
			}
		}

		protected override void OnStart()
		{
			ChallengeWaveObjectivesHorde.OnWaveChanged = (Action<int, int>)Delegate.Combine(ChallengeWaveObjectivesHorde.OnWaveChanged, new Action<int, int>(OnWaveChanged));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			ChallengeWaveObjectivesHorde.OnWaveChanged = (Action<int, int>)Delegate.Remove(ChallengeWaveObjectivesHorde.OnWaveChanged, new Action<int, int>(OnWaveChanged));
			base.OnEnd();
		}

		private void OnWaveChanged(int waveNum, int waveIndex)
		{
			_currentWaveNum = waveNum;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _currentWaveNum >= _definition.WaveToReach;
		}

		public override float PercentComplete()
		{
			return (float)_currentWaveNum / (float)_definition.WaveToReach;
		}

		public override int Score()
		{
			return _currentWaveNum;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.ReachHordeWave_Progress_CS.Replace("{[WAVE]}", (_currentWaveNum + 1).ToString());
		}
	}
}
