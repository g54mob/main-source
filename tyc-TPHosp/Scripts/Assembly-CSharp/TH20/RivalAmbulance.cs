#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class RivalAmbulance : Ambulance
	{
		private float _elapsedSecondsIdle;

		private float _secondsBeforeNextDispatch;

		private readonly float _minSecondsAmbulanceLeftIdle;

		private readonly float _maxSecondsAmbulanceLeftIdle;

		private int _numberOfPatientsOnboard;

		private readonly RivalAmbulanceDepartment _myOwner;

		public int NumPatientsOnboard => _numberOfPatientsOnboard;

		public RivalAmbulance(AmbulanceConfig config, RivalAmbulanceDepartment owningRival, int minSecondsAmbulanceLeftIdle, int maxSecondsAmbulanceLeftIdle)
			: base(config, owningRival)
		{
			_minSecondsAmbulanceLeftIdle = minSecondsAmbulanceLeftIdle;
			_maxSecondsAmbulanceLeftIdle = maxSecondsAmbulanceLeftIdle;
			_secondsBeforeNextDispatch = Random.Range(_minSecondsAmbulanceLeftIdle, _maxSecondsAmbulanceLeftIdle);
			_myOwner = owningRival;
		}

		public override void Update(float timeDelta)
		{
			base.Update(timeDelta);
			switch (_currentState)
			{
			case State.Idle:
				_elapsedSecondsIdle = 0f;
				_secondsBeforeNextDispatch = Random.Range(_minSecondsAmbulanceLeftIdle, _maxSecondsAmbulanceLeftIdle);
				_currentState = State.GettingReady;
				break;
			case State.GettingReady:
				CheckIfReadyForAIDispatch(timeDelta);
				break;
			case State.AtEmergency:
				AssessSituation();
				break;
			case State.WaitingForClearParkingRoute:
				_currentState = State.AtHospital;
				break;
			case State.AtHospital:
				Logging.Info(LogChannels.AmbulanceEmergency, $"{_owner.FoundationName}'s {_config.AmbulanceName} Ambulance has returned!");
				_ambulanceEmergency.RivalAmbulanceArrivesAtHospital(this);
				SimulatePatientTreatments();
				_ambulanceEmergency.UnAssignAmbulance(this);
				_currentState = State.Idle;
				break;
			}
		}

		public void CheckIfReadyForAIDispatch(float timeDelta)
		{
			_elapsedSecondsIdle += timeDelta;
			if (_elapsedSecondsIdle > _secondsBeforeNextDispatch)
			{
				_currentState = State.ReadyToLeave;
			}
		}

		private void AssessSituation()
		{
			Logging.Info(LogChannels.AmbulanceEmergency, $"{_owner.FoundationName}'s {_config.AmbulanceName} Ambulance has arrived at emergency!");
			_numberOfPatientsOnboard = _ambulanceEmergency.RivalCollectsPatients(this);
			if (_numberOfPatientsOnboard > 0 && _ambulanceEmergency.IsRescue)
			{
				_currentState = State.RescuePatients;
				AmbulanceDepartmentStatsContainer ambulanceDepartmentStatsContainer = new AmbulanceDepartmentStatsContainer(_numberOfPatientsOnboard, 0, 0, 0, null);
				_owner.Stats.IncrementStats(ambulanceDepartmentStatsContainer);
				_myOwner.IncrementStatsForEmergency(_ambulanceEmergency, ambulanceDepartmentStatsContainer);
			}
			else
			{
				_currentState = State.ReturningToBase;
			}
		}

		public void SimulatePatientTreatments()
		{
			if (_ambulanceEmergency.IsRescue)
			{
				return;
			}
			RivalAmbulanceDepartment rivalAmbulanceDepartment = _owner as RivalAmbulanceDepartment;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			foreach (KeyValuePair<IllnessDefinition, WeightedIllness> weightedIllness in _ambulanceEmergency.WeightedIllnesses)
			{
				float num4 = (float)Random.Range(weightedIllness.Value.MinWeight, weightedIllness.Value.MaxWeight) / 100f;
				IllnessDefinition.TreatmentType bestTreatmentType = weightedIllness.Key.GetBestTreatmentType(null, null);
				float num5 = Random.Range(bestTreatmentType._effectiveness, bestTreatmentType._effectivenessMax) / 100f;
				num += num4 * num5;
				num2 += num4 * (weightedIllness.Key._treatmentChanceOfDeathOnFailure / 100f);
				num3 += num4;
			}
			num /= num3;
			num = Mathf.Clamp01(num + rivalAmbulanceDepartment.Config.CureRateBonusPercentage);
			num2 /= num3;
			float num6 = 1f - num;
			float num7 = Mathf.Clamp01(num6 * num2);
			int num8 = Mathf.RoundToInt((float)_numberOfPatientsOnboard * num);
			int num9 = Mathf.RoundToInt((float)_numberOfPatientsOnboard * num7);
			int patientsCureFailed = Mathf.RoundToInt((float)_numberOfPatientsOnboard * num6);
			Logging.Info(LogChannels.AmbulanceEmergency, $"{_owner.FoundationName}'s {_config.AmbulanceName} *CURED* {num8}/{_numberOfPatientsOnboard} patients. (Deaths: {num9})");
			AmbulanceDepartmentStatsContainer statsUpdate = new AmbulanceDepartmentStatsContainer(_numberOfPatientsOnboard, num8, num9, patientsCureFailed, null);
			rivalAmbulanceDepartment.IncrementStatsForEmergency(_ambulanceEmergency, statsUpdate);
		}

		public override void RestoreFromSave(Level level)
		{
			if (_currentRoute == null && _ambulanceEmergency != null)
			{
				_currentRoute = _owner.GetRouteToEmergency(_ambulanceEmergency, base.AmbulanceType);
				if (_currentRoute == null && _ambulanceEmergency != null)
				{
					_currentState = State.AtHospital;
				}
			}
			base.RestoreFromSave(level);
		}
	}
}
