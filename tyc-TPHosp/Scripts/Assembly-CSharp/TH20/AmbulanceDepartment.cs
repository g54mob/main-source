#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class AmbulanceDepartment
	{
		[DontSave]
		protected AmbulanceDepartmentDefinition _departmentDefinitionBase;

		protected string _foundationName;

		protected Sprite _foundationIcon;

		protected FoundationStyleDefinition _foundationStyle;

		protected AmbulanceDepartmentStats _stats;

		protected List<Ambulance> _ambulances;

		protected Dictionary<string, EmergencyStatTracker> _emergencyStatTrackers = new Dictionary<string, EmergencyStatTracker>();

		protected Level _level;

		public string FoundationName => _foundationName;

		public Sprite FoundationIcon => _foundationIcon;

		public FoundationStyleDefinition FoundationStyle => _foundationStyle;

		public AmbulanceDepartmentStats Stats => _stats;

		public Level Level => _level;

		[HideInInspector]
		public List<Ambulance> Ambulances => _ambulances;

		public AmbulanceDepartmentDefinition BaseConfig => _departmentDefinitionBase;

		public virtual void Destroy()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientDiedAtScene = (Action<bool, string>)Delegate.Remove(characterEvents.OnPatientDiedAtScene, new Action<bool, string>(OnPatientDiedAtScene));
		}

		public void RestoreFromSave(Level level)
		{
			_level = level;
			_stats.RestoreFromSave();
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientDiedAtScene = (Action<bool, string>)Delegate.Combine(characterEvents.OnPatientDiedAtScene, new Action<bool, string>(OnPatientDiedAtScene));
		}

		public AmbulanceRoute GetRouteToEmergency(ChallengeAmbulanceEmergency emergency, AmbulanceConfig.Type ambulanceType)
		{
			if (emergency == null || BaseConfig.RoutesFromDepartment == null)
			{
				Logging.Error(LogChannels.AmbulanceEmergency, "Emergency or RoutesFromDepartment are null.");
				return null;
			}
			if (ambulanceType == AmbulanceConfig.Type.All)
			{
				Logging.Error(LogChannels.AmbulanceEmergency, "An ambulance cannot have the Type 'All'. This type is used by emergencies to declare that Road or Air ambulances may reach them.");
				return null;
			}
			AmbulanceRoute ambulanceRoute = null;
			if (BaseConfig.RoutesFromDepartment != null && BaseConfig.RoutesFromDepartment.Length != 0)
			{
				for (int i = 0; i < BaseConfig.RoutesFromDepartment.Length; i++)
				{
					if (ambulanceType == BaseConfig.RoutesFromDepartment[i]?.Instance?.RouteType)
					{
						Vector2 emergencyLocation = emergency.Definition.Location.Instance.EmergencyLocation;
						Vector2 emergencyLocation2 = BaseConfig.RoutesFromDepartment[i].Instance.Destination.Instance.EmergencyLocation;
						if (emergencyLocation == emergencyLocation2)
						{
							ambulanceRoute = BaseConfig.RoutesFromDepartment[i].Instance;
							break;
						}
					}
				}
			}
			if (ambulanceRoute == null)
			{
				Logging.Error(LogChannels.AmbulanceEmergency, "An Ambulance has just been set a null route, this is not intended. Emergency: " + emergency.EmergencyID);
			}
			return ambulanceRoute;
		}

		protected void OnPatientDiedAtScene(bool playerResponded, string emergencyID)
		{
			_emergencyStatTrackers[emergencyID].SceneDeaths++;
		}

		public int CalculateChallengeScore(EmergencyStatTracker statTracker)
		{
			float num = statTracker.StatsContainer.PatientsCured;
			float num2 = statTracker.StatsContainer.PatientsCollected;
			float num3 = statTracker.StatsContainer.PatientsDied;
			float num4 = statTracker.SceneDeaths;
			if (!statTracker.DidRespond)
			{
				return Mathf.RoundToInt((1f - num4 / (float)statTracker.InitialPatientCount) * _level.ChallengeManager.IgnoredSceneDeathPenaltyMultiplier * 100f);
			}
			if (statTracker.IsRescue)
			{
				float num5 = num4 / (float)statTracker.InitialPatientCount * _level.ChallengeManager.RescueDeathPenaltyMultiplier;
				num5 = 1f - num5;
				return Mathf.Clamp(Mathf.RoundToInt(num5 * 100f), 0, 100);
			}
			float num6 = num2 / (float)statTracker.InitialPatientCount;
			float num7 = ((num2 > 0f) ? (num / num2) : 0f);
			float num8 = ((num2 > 0f) ? (1f - num3 / num2) : 0f);
			float num9 = 1f - num4 / (float)statTracker.InitialPatientCount;
			return Mathf.RoundToInt((num6 + num7 + num8 + num9) / 4f * 100f);
		}
	}
}
