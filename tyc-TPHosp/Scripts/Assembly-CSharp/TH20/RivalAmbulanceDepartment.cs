#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class RivalAmbulanceDepartment : AmbulanceDepartment
	{
		private enum Preference
		{
			FavourLower = 0,
			NoPreference = 1,
			FavourHigher = 2
		}

		[DontSave]
		private RivalAmbulanceDepartmentDefinition _departmentConfig;

		private List<ChallengeAmbulanceEmergency> _ambulanceEmergencies = new List<ChallengeAmbulanceEmergency>();

		private bool _emergencyListNeedsSort;

		private bool _debugFreeze;

		private const int BASE_SCORE = 100;

		public RivalAmbulanceDepartmentDefinition Config => _departmentConfig;

		public RivalAmbulanceDepartment(RivalAmbulanceDepartmentDefinition config, Level level)
		{
			_level = level;
			_departmentConfig = config;
			_departmentDefinitionBase = Config;
			_foundationName = Config.RivalFoundationDefinition.Instance.FoundationName.Translation;
			_foundationIcon = Config.RivalFoundationDefinition.Instance.Icon;
			_foundationStyle = Config.RivalFoundationDefinition.Instance.FoundationStyle.Instance;
			_ambulances = new List<Ambulance>();
			for (int i = 0; i < Config.AmbulanceConfigs.Length; i++)
			{
				_ambulances.Add(new RivalAmbulance(Config.AmbulanceConfigs[i].Instance, this, Config.MinSecondsAmbulanceLeftIdle, Config.MaxSecondsAmbulanceLeftIdle));
			}
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientDiedAtScene = (Action<bool, string>)Delegate.Combine(characterEvents.OnPatientDiedAtScene, new Action<bool, string>(base.OnPatientDiedAtScene));
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			_stats = new AmbulanceDepartmentStats(level.TimelineManager);
		}

		public void RestoreFromSave(RivalAmbulanceDepartmentDefinition config, Level level)
		{
			_level = level;
			_departmentConfig = config;
			_departmentDefinitionBase = Config;
			_foundationName = Config.RivalFoundationDefinition.Instance.FoundationName.Translation;
			foreach (Ambulance ambulance in _ambulances)
			{
				ambulance.RestoreFromSave(level);
			}
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			RestoreFromSave(level);
		}

		public void Update(float timeDelta)
		{
			if (_ambulanceEmergencies.Count == 0 || _debugFreeze)
			{
				return;
			}
			int num = 0;
			bool flag = false;
			for (int i = 0; i < _ambulances.Count; i++)
			{
				_ambulances[i].Update(timeDelta);
				if (_ambulances[i].CurrentState == Ambulance.State.ReadyToLeave)
				{
					flag = true;
				}
				else if (_ambulances[i].CurrentState != Ambulance.State.Idle && _ambulances[i].CurrentState != Ambulance.State.GettingReady)
				{
					num++;
				}
			}
			if (num < Config.MaxSimultaneousDispatches && flag)
			{
				ChooseEmergencyAndDispatch();
			}
		}

		public Ambulance FirstAvailableValidAmbulance(ChallengeAmbulanceEmergency emergency)
		{
			if (emergency.PatientsRemaining <= 0)
			{
				return null;
			}
			for (int i = 0; i < _ambulances.Count; i++)
			{
				bool flag = _ambulances[i].Config.AmbulanceType == emergency.Definition.ValidAmbulanceType || emergency.Definition.ValidAmbulanceType == AmbulanceConfig.Type.All;
				flag &= !emergency.IsJourneyFutile(_ambulances[i]);
				if (_ambulances[i].CurrentState == Ambulance.State.ReadyToLeave && flag)
				{
					return _ambulances[i];
				}
			}
			return null;
		}

		public void AddChallenge(ChallengeAmbulanceEmergency challengeAmbulanceEmergency)
		{
			if (!challengeAmbulanceEmergency.IsTutorial)
			{
				_ambulanceEmergencies.Add(challengeAmbulanceEmergency);
				_emergencyStatTrackers.Add(challengeAmbulanceEmergency.EmergencyID, new EmergencyStatTracker(challengeAmbulanceEmergency.TotalPatients, challengeAmbulanceEmergency.IsRescue));
				_emergencyListNeedsSort = true;
			}
		}

		public void EmergencyOver(ChallengeAmbulanceEmergency challengeAmbulanceEmergency)
		{
			if (_emergencyStatTrackers.ContainsKey(challengeAmbulanceEmergency.EmergencyID) && _ambulanceEmergencies.Contains(challengeAmbulanceEmergency))
			{
				int item = CalculateChallengeScore(_emergencyStatTrackers[challengeAmbulanceEmergency.EmergencyID]);
				_emergencyStatTrackers[challengeAmbulanceEmergency.EmergencyID].StatsContainer.DepartmentReputation.Add(item);
				base.Stats.IncrementStats(_emergencyStatTrackers[challengeAmbulanceEmergency.EmergencyID].StatsContainer);
				_ambulanceEmergencies.Remove(challengeAmbulanceEmergency);
				_emergencyStatTrackers.Remove(challengeAmbulanceEmergency.EmergencyID);
				_emergencyListNeedsSort = true;
			}
		}

		private void ChooseEmergencyAndDispatch()
		{
			if (_ambulanceEmergencies.Count == 0)
			{
				return;
			}
			Ambulance ambulance = null;
			ChallengeAmbulanceEmergency challengeAmbulanceEmergency = null;
			if (_emergencyListNeedsSort)
			{
				SortEmergenciesByPriority();
			}
			for (int i = 0; i < _ambulanceEmergencies.Count; i++)
			{
				ambulance = FirstAvailableValidAmbulance(_ambulanceEmergencies[i]);
				if (ambulance != null)
				{
					challengeAmbulanceEmergency = _ambulanceEmergencies[i];
					break;
				}
			}
			if (ambulance != null)
			{
				challengeAmbulanceEmergency.AssignAmbulance(ambulance);
				_emergencyStatTrackers[challengeAmbulanceEmergency.EmergencyID].DidRespond = true;
				if (ambulance.CurrentRoute == null)
				{
					Logging.Error(LogChannels.AmbulanceEmergency, $"{base.FoundationName}'s {ambulance.Config.AmbulanceName} Ambulance has been forced to abort due to null route!");
					challengeAmbulanceEmergency.UnAssignAmbulance(ambulance);
				}
				else
				{
					ambulance.ForceDispatch();
					Logging.Info(LogChannels.AmbulanceEmergency, $"{base.FoundationName}'s {ambulance.Config.AmbulanceName} Ambulance has been dispatched! " + $"({ambulance.CurrentEmergencyDistance} miles out)");
					_emergencyListNeedsSort = true;
				}
			}
		}

		private bool OurAmbulanceOnTask(ChallengeAmbulanceEmergency challengeAmbulanceEmergency)
		{
			for (int i = 0; i < _ambulances.Count; i++)
			{
				if (_ambulances[i].AmbulanceEmergency == challengeAmbulanceEmergency)
				{
					return true;
				}
			}
			return false;
		}

		private void SortEmergenciesByPriority()
		{
			_ambulanceEmergencies.Sort(delegate(ChallengeAmbulanceEmergency x, ChallengeAmbulanceEmergency y)
			{
				int num = CalculateScore(x.Definition.SeverityDisplayValue, y.Definition.SeverityDisplayValue, (Preference)Config.Severity);
				float sqrMagnitude = (x.Definition.Location.Instance.EmergencyLocation - Config.Location).sqrMagnitude;
				float sqrMagnitude2 = (y.Definition.Location.Instance.EmergencyLocation - Config.Location).sqrMagnitude;
				int num2 = CalculateScore(sqrMagnitude, sqrMagnitude2, (Preference)Config.Distance);
				float firstValue = Mathf.Round((float)(x.Definition.MinPatients + x.Definition.MaxPatients) / 2f);
				float secondValue = Mathf.Round((float)(y.Definition.MinPatients + y.Definition.MaxPatients) / 2f);
				int num3 = CalculateScore(firstValue, secondValue, (Preference)Config.PatientCount);
				int num4 = CalculateBoost(x.PlayerAmbulancesInUse, y.PlayerAmbulancesInUse, (Preference)Config.Aggression);
				int num5 = CalculateBoost(OurAmbulanceOnTask(x), OurAmbulanceOnTask(y), (Preference)Config.Focus);
				return num + num2 + num3 + num4 + num5;
			});
			_emergencyListNeedsSort = false;
		}

		private int CalculateScore(float firstValue, float secondValue, Preference preference)
		{
			float num = firstValue / secondValue;
			float num2 = 1f;
			switch (preference)
			{
			case Preference.FavourHigher:
				num2 = num;
				break;
			case Preference.FavourLower:
				num2 = 1f / num;
				break;
			}
			return (int)(100f * num2);
		}

		private int CalculateBoost(bool firstValue, bool secondValue, Preference preference)
		{
			int num = (firstValue ? 1 : 0);
			int num2 = (secondValue ? 1 : 0);
			float num3 = num - num2;
			float num4 = ((preference == Preference.FavourHigher) ? num3 : (-1f * num3));
			return (int)(100f * num4);
		}

		public void IncrementStatsForEmergency(ChallengeAmbulanceEmergency emergency, AmbulanceDepartmentStatsContainer statsUpdate)
		{
			if (!_emergencyStatTrackers.ContainsKey(emergency.EmergencyID))
			{
				Logging.Info(LogChannels.AmbulanceEmergency, "Rival tried to increment its stats for an emergency that was not being tracked.");
			}
			else
			{
				_emergencyStatTrackers[emergency.EmergencyID].StatsContainer.IncrementStats(statsUpdate);
			}
		}

		public void Debug_Freeze()
		{
			_debugFreeze = true;
		}

		public void Debug_Unfreeze()
		{
			_debugFreeze = false;
		}

		private void OnLocalize()
		{
			_foundationName = Config.RivalFoundationDefinition.Instance.FoundationName.Translation;
		}

		public override void Destroy()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			base.Destroy();
		}
	}
}
