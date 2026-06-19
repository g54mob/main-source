using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalReachHordeWave : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionReachHordeWave _definition;

		private int _currentWave;

		public SubGoalReachHordeWave(Objective owner, SubGoalDefinitionReachHordeWave definition)
			: base(owner, definition)
		{
			_definition = definition;
			UpdateCurrentWave();
		}

		private void UpdateCurrentWave()
		{
			ChallengeHorde objective = Level.LevelScriptManager.GetObjective<ChallengeHorde>();
			if (objective != null)
			{
				_currentWave = objective.WaveIndex;
			}
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionReachHordeWave;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionReachHordeWave)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				ChallengeHorde.OnWaveChanged = (Action<int>)Delegate.Combine(ChallengeHorde.OnWaveChanged, new Action<int>(OnWaveChanged));
				UpdateCurrentWave();
			}
		}

		protected override void OnStart()
		{
			ChallengeHorde.OnWaveChanged = (Action<int>)Delegate.Combine(ChallengeHorde.OnWaveChanged, new Action<int>(OnWaveChanged));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			ChallengeHorde.OnWaveChanged = (Action<int>)Delegate.Remove(ChallengeHorde.OnWaveChanged, new Action<int>(OnWaveChanged));
			base.OnEnd();
		}

		private void OnWaveChanged(int wave)
		{
			_currentWave = wave;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _currentWave >= _definition.Wave;
		}

		public override float PercentComplete()
		{
			return (float)_currentWave / (float)_definition.Wave;
		}

		public override int Score()
		{
			return _currentWave;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.ReachHordeWave_Progress_CS.Replace("{[WAVE]}", (_currentWave + 1).ToString());
		}
	}
}
