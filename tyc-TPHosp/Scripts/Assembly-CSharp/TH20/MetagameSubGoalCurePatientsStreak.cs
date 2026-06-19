using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalCurePatientsStreak : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionCurePatientsStreak _definition;

		[SerializeField]
		private int _currentCureStreak;

		public MetagameSubGoalCurePatientsStreak(Objective owner, MetagameSubGoalDefinitionCurePatientsStreak definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(levelEventsIntermediary.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
				LevelEventsIntermediary levelEventsIntermediary2 = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnPatientDied = (Action<Patient>)Delegate.Combine(levelEventsIntermediary2.OnPatientDied, new Action<Patient>(OnPatientDied));
				LevelEventsIntermediary levelEventsIntermediary3 = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary3.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(levelEventsIntermediary3.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
				LevelEventsIntermediary levelEventsIntermediary4 = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary4.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(levelEventsIntermediary4.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
				LevelEventsIntermediary levelEventsIntermediary5 = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary5.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(levelEventsIntermediary5.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
				LevelEventsIntermediary levelEventsIntermediary6 = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary6.OnPatientSentHome = (Action<Patient>)Delegate.Combine(levelEventsIntermediary6.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(levelEventsIntermediary.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
				LevelEventsIntermediary levelEventsIntermediary2 = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnPatientDied = (Action<Patient>)Delegate.Remove(levelEventsIntermediary2.OnPatientDied, new Action<Patient>(OnPatientDied));
				LevelEventsIntermediary levelEventsIntermediary3 = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary3.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(levelEventsIntermediary3.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
				LevelEventsIntermediary levelEventsIntermediary4 = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary4.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(levelEventsIntermediary4.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
				LevelEventsIntermediary levelEventsIntermediary5 = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary5.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(levelEventsIntermediary5.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
				LevelEventsIntermediary levelEventsIntermediary6 = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary6.OnPatientSentHome = (Action<Patient>)Delegate.Remove(levelEventsIntermediary6.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary7 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary7.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(levelEventsIntermediary7.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
				LevelEventsIntermediary levelEventsIntermediary8 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary8.OnPatientDied = (Action<Patient>)Delegate.Combine(levelEventsIntermediary8.OnPatientDied, new Action<Patient>(OnPatientDied));
				LevelEventsIntermediary levelEventsIntermediary9 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary9.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(levelEventsIntermediary9.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
				LevelEventsIntermediary levelEventsIntermediary10 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary10.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(levelEventsIntermediary10.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
				LevelEventsIntermediary levelEventsIntermediary11 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary11.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(levelEventsIntermediary11.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
				LevelEventsIntermediary levelEventsIntermediary12 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary12.OnPatientSentHome = (Action<Patient>)Delegate.Combine(levelEventsIntermediary12.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(levelEventsIntermediary.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
				LevelEventsIntermediary levelEventsIntermediary2 = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnPatientDied = (Action<Patient>)Delegate.Remove(levelEventsIntermediary2.OnPatientDied, new Action<Patient>(OnPatientDied));
				LevelEventsIntermediary levelEventsIntermediary3 = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary3.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(levelEventsIntermediary3.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
				LevelEventsIntermediary levelEventsIntermediary4 = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary4.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(levelEventsIntermediary4.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
				LevelEventsIntermediary levelEventsIntermediary5 = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary5.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(levelEventsIntermediary5.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
				LevelEventsIntermediary levelEventsIntermediary6 = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary6.OnPatientSentHome = (Action<Patient>)Delegate.Remove(levelEventsIntermediary6.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}
			base.Destroy();
		}

		private void OnPatientCured(Patient patient, List<Staff> staffInvolved)
		{
			bool num = _definition.ValidRoom(patient.RoomUsing);
			bool flag = _definition.ValidIllness(patient.Illness);
			if (num && flag)
			{
				_currentCureStreak++;
				UpdateProgress();
			}
		}

		private void OnPatientDied(Patient patient)
		{
			bool num = _definition.ValidRoom(patient.RoomUsing);
			bool flag = _definition.ValidIllness(patient.Illness);
			bool flag2 = patient.TreatmentOutcome != Treatment.Outcome.Unknown;
			if (num && flag && !flag2)
			{
				_currentCureStreak = 0;
				UpdateProgress();
			}
		}

		private void OnIneffectiveTreatment(Patient patient, List<Staff> involvedStaff)
		{
			bool num = _definition.ValidRoom(patient.RoomUsing);
			bool flag = _definition.ValidIllness(patient.Illness);
			if (num && flag)
			{
				_currentCureStreak = 0;
				UpdateProgress();
			}
		}

		private void OnFatalTreatment(Patient patient, List<Staff> involvedStaff)
		{
			bool num = _definition.ValidRoom(patient.RoomUsing);
			bool flag = _definition.ValidIllness(patient.Illness);
			if (num && flag)
			{
				_currentCureStreak = 0;
				UpdateProgress();
			}
		}

		private void OnPatientRageQuit(Patient patient)
		{
			bool num = _definition.ValidRoom(patient.RoomUsing);
			bool flag = _definition.ValidIllness(patient.Illness);
			if (num && flag)
			{
				_currentCureStreak = 0;
				UpdateProgress();
			}
		}

		private void OnPatientSentHome(Patient patient)
		{
			bool num = _definition.ValidRoom(patient.RoomUsing);
			bool flag = _definition.ValidIllness(patient.Illness);
			if (num && flag)
			{
				_currentCureStreak = 0;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _currentCureStreak >= _definition.TargetCureStreak;
		}

		public override float PercentComplete()
		{
			return (float)_currentCureStreak / (float)_definition.TargetCureStreak;
		}

		public override int Score()
		{
			return _currentCureStreak;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_currentCureStreak} / {_definition.TargetCureStreak}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
