using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalCurePatients : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionCurePatients _definition;

		[SerializeField]
		private int _numCured;

		public MetagameSubGoalCurePatients(Objective owner, MetagameSubGoalDefinitionCurePatients definition)
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
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(levelEventsIntermediary.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(levelEventsIntermediary2.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(levelEventsIntermediary.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			}
			base.Destroy();
		}

		private void OnPatientCured(Patient patient, List<Staff> involvedStaff)
		{
			bool num = _definition.ValidRoom(patient.RoomUsing);
			bool flag = _definition.ValidIllness(patient.Illness);
			if (num && flag)
			{
				_numCured++;
				if (Metagame?.App != null)
				{
					PlatformStatsAndAchievements.SetStatValue(Stat.PatientsCured, _numCured);
				}
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numCured >= _definition.CureCount;
		}

		public override float PercentComplete()
		{
			return (float)_numCured / (float)_definition.CureCount;
		}

		public override int Score()
		{
			return _numCured;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{StringUtils.FormatNumber(_numCured)} / {StringUtils.FormatNumber(_definition.CureCount)}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
