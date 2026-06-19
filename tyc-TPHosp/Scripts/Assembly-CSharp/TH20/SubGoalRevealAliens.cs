using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalRevealAliens : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionRevealAliens _definition;

		private int _numAliensRevealed;

		public SubGoalRevealAliens(Objective owner, SubGoalDefinitionRevealAliens definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionRevealAliens;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionRevealAliens)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				RegisterEvents();
			}
		}

		protected override void OnStart()
		{
			RegisterEvents();
			base.OnStart();
		}

		protected override void OnEnd()
		{
			RegisterEvents(bRegister: false);
			base.OnEnd();
		}

		private void RegisterEvents(bool bRegister = true)
		{
			AliensManager aliensManager = Level.CharacterManager.GetAliensManager();
			if (aliensManager != null)
			{
				if (bRegister)
				{
					aliensManager.OnAlienDiscovered = (Action<Patient>)Delegate.Combine(aliensManager.OnAlienDiscovered, new Action<Patient>(OnAlienDiscovered));
				}
				else
				{
					aliensManager.OnAlienDiscovered = (Action<Patient>)Delegate.Remove(aliensManager.OnAlienDiscovered, new Action<Patient>(OnAlienDiscovered));
				}
			}
		}

		private void OnAlienDiscovered(Patient alienPatient)
		{
			AliensManager aliensManager = Level.CharacterManager.GetAliensManager();
			if (aliensManager != null)
			{
				_numAliensRevealed = aliensManager.NumAliensDiscovered;
			}
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _numAliensRevealed >= _definition.NumAliens;
		}

		public override float PercentComplete()
		{
			return (float)_numAliensRevealed / (float)_definition.NumAliens;
		}

		public override int Score()
		{
			return _numAliensRevealed;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ((_definition.ProgressTextOverride.Term == null) ? ScriptLocalization.Challenges_SubGoals.RevealAliens_Progress_CS : _definition.ProgressTextOverride.Translation).Replace("{[COUNT_REVEALED]}", _numAliensRevealed.ToString()).Replace("{[COUNT_ALIENS]}", _definition.NumAliens.ToString());
		}
	}
}
