using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalShootMonoBeasts : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionShootMonoBeasts _definition;

		private int _numShot;

		public SubGoalShootMonoBeasts(Objective owner, SubGoalDefinitionShootMonoBeasts definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionShootMonoBeasts;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionShootMonoBeasts)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				MonoBeastManager monoBeastManager = Level.MonoBeastManager;
				monoBeastManager.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Combine(monoBeastManager.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShot));
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			MonoBeastManager monoBeastManager = Level.MonoBeastManager;
			monoBeastManager.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Combine(monoBeastManager.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShot));
		}

		protected override void OnEnd()
		{
			MonoBeastManager monoBeastManager = Level.MonoBeastManager;
			monoBeastManager.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Remove(monoBeastManager.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShot));
			base.OnEnd();
		}

		private void OnMonoBeastShot(MonoBeast monoBeast, int killStreak)
		{
			_numShot++;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _numShot >= _definition.NumToShoot;
		}

		public override float PercentComplete()
		{
			return (float)_numShot / (float)_definition.NumToShoot;
		}

		public override int Score()
		{
			return _numShot;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numShot} / {_definition.NumToShoot}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
