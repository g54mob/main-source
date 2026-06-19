using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalD7PatientsCollectedShare : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionD7PatientsCollectedShare _definition;

		private int _collectedByPlayer;

		private int _collectedTotal;

		private float _percentageShare;

		public SubGoalD7PatientsCollectedShare(Objective owner, SubGoalDefinitionD7PatientsCollectedShare definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionD7PatientsCollectedShare;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionD7PatientsCollectedShare)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Combine(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientsCollectedByPlayer));
				CharacterEvents characterEvents2 = Level.CharacterEvents;
				characterEvents2.OnPatientsCollected = (Action<int>)Delegate.Combine(characterEvents2.OnPatientsCollected, new Action<int>(OnPatientsCollected));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Combine(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientsCollectedByPlayer));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientsCollected = (Action<int>)Delegate.Combine(characterEvents2.OnPatientsCollected, new Action<int>(OnPatientsCollected));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Remove(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientsCollectedByPlayer));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientsCollected = (Action<int>)Delegate.Remove(characterEvents2.OnPatientsCollected, new Action<int>(OnPatientsCollected));
			base.OnEnd();
		}

		private void OnPatientsCollectedByPlayer(List<Patient> patients, string ID)
		{
			if (_definition != null && patients.Count != 0)
			{
				_collectedByPlayer += patients.Count;
				_percentageShare = (float)_collectedByPlayer / (float)_collectedTotal * 100f;
				UpdateProgress();
			}
		}

		private void OnPatientsCollected(int collected)
		{
			if (_definition != null && _collectedTotal != 0)
			{
				_collectedTotal += collected;
				_percentageShare = (float)_collectedByPlayer / (float)_collectedTotal * 100f;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return (int)_percentageShare >= _definition.PlayerCollectionShareTarget;
		}

		public override float PercentComplete()
		{
			return _percentageShare / (float)_definition.PlayerCollectionShareTarget;
		}

		public override int Score()
		{
			return (int)_percentageShare;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{Mathf.Floor(_percentageShare)}% / {_definition.PlayerCollectionShareTarget}%";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
