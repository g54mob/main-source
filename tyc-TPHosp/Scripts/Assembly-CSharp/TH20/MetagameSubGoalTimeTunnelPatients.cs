using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalTimeTunnelPatients : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionTimeTunnelPatients _definition;

		[SerializeField]
		private int _numCured;

		public MetagameSubGoalTimeTunnelPatients(Objective owner, MetagameSubGoalDefinitionTimeTunnelPatients definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(levelEventsIntermediary.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(levelEventsIntermediary.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(levelEventsIntermediary2.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(levelEventsIntermediary.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			}
			base.Destroy();
		}

		private void OnPatientTimeTunnel(Patient patient)
		{
			bool num = _definition.ValidRoom(patient.RoomUsing);
			bool flag = _definition.ValidIllness(patient.Illness);
			bool flag2 = _definition.ValidPatient(patient);
			if (num && flag && flag2 && patient.ReasonForLeaving == Character.ReasonForLeavingHospital.Cured)
			{
				_numCured++;
				if (Metagame?.App != null)
				{
					PlatformStatsAndAchievements.SetStatValue(Stat.TimeTunnelPatientsCured, _numCured);
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
