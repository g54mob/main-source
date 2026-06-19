#define LOG_LEVEL_VERBOSE
using System;
using UnityEngine;

namespace TH20
{
	public class Ambulance
	{
		public enum State
		{
			Idle = 0,
			GettingReady = 1,
			ReadyToLeave = 2,
			WaitingForClearExitRoute = 3,
			VisuallyLeavingBase = 4,
			MovingToEmergency = 5,
			AtEmergency = 6,
			RescuePatients = 7,
			ReturningToBase = 8,
			WaitingForClearParkingRoute = 9,
			VisuallyReturning = 10,
			AtHospital = 11,
			Parking = 12,
			UnloadingStaff = 13,
			UnloadingPatients = 14,
			ApplyWearAndTear = 15,
			Maintenance = 16,
			ReturnOrIdleDecision = 17
		}

		protected AmbulanceConfig _config;

		protected State _currentState;

		private float _progress;

		private float _currentEmergencyDistance;

		private float _movedPercentage;

		protected float _speedBoost = 1f;

		private string _lastDebugLog = string.Empty;

		protected ChallengeAmbulanceEmergency _ambulanceEmergency;

		protected AmbulanceDepartment _owner;

		protected AmbulanceRoute _currentRoute;

		protected float _rescueTimer;

		protected float _currentEmergencyETA;

		protected Vector2 _currentEmergencyLocation;

		public AmbulanceConfig Config => _config;

		public State CurrentState => _currentState;

		public float CurrentEmergencyDistance => _currentEmergencyDistance;

		public float CurrentEmergencyETA => _currentEmergencyETA;

		public float Progress => _progress;

		public ChallengeAmbulanceEmergency AmbulanceEmergency => _ambulanceEmergency;

		public AmbulanceDepartment Owner => _owner;

		public AmbulanceConfig.Type AmbulanceType => _config.AmbulanceType;

		public AmbulanceRoute CurrentRoute => _currentRoute;

		public bool ShouldHighlight { get; set; }

		public bool IsGettingReady => _currentState == State.GettingReady;

		public bool IsActive
		{
			get
			{
				if (!IsOnWorldMap)
				{
					return _currentState == State.VisuallyReturning;
				}
				return true;
			}
		}

		public bool IsOnWorldMap
		{
			get
			{
				if (!IsAwayFromLevel)
				{
					return _currentState == State.VisuallyLeavingBase;
				}
				return true;
			}
		}

		public bool IsAwayFromLevel
		{
			get
			{
				if (_currentState != State.MovingToEmergency && _currentState != State.AtEmergency && _currentState != State.RescuePatients && _currentState != State.ReturningToBase)
				{
					return _currentState == State.WaitingForClearParkingRoute;
				}
				return true;
			}
		}

		public Ambulance(AmbulanceConfig config, AmbulanceDepartment owner)
		{
			_config = config;
			_currentState = State.Idle;
			_owner = owner;
			if (_config.AmbulanceType == AmbulanceConfig.Type.All)
			{
				Logging.Error(LogChannels.AmbulanceEmergency, "An ambulance cannot have the Type 'All'. This type is used by emergencies to declare that Road or Air ambulances may reach them.");
			}
		}

		public virtual void Update(float timeDelta)
		{
			switch (_currentState)
			{
			case State.MovingToEmergency:
				MakeProgress(timeDelta, toEmergency: true);
				break;
			case State.RescuePatients:
				if (RescuePatients(timeDelta))
				{
					_currentState = State.AtEmergency;
				}
				break;
			case State.ReturningToBase:
				MakeProgress(timeDelta, toEmergency: false);
				break;
			case State.AtEmergency:
				break;
			}
		}

		protected void MakeProgress(float timeDelta, bool toEmergency, bool blockCompletion = false)
		{
			float num = timeDelta * _config.Speed * Time.timeScale * _speedBoost / _currentEmergencyDistance;
			if (toEmergency)
			{
				_movedPercentage += num;
				_progress = _movedPercentage;
				if ((Math.Abs(_progress - 100f) < 0.001f || _progress > 100f) && !blockCompletion)
				{
					_currentState = State.AtEmergency;
				}
			}
			else
			{
				_movedPercentage -= num;
				_progress = _movedPercentage;
				if (_progress <= 0f)
				{
					_currentState = State.WaitingForClearParkingRoute;
				}
			}
			Debug_VisualProgress(toEmergency);
		}

		private bool RescuePatients(float timeDelta)
		{
			_rescueTimer += timeDelta * Time.timeScale;
			if (_rescueTimer >= _currentEmergencyETA * 2f)
			{
				Logging.Info(LogChannels.AmbulanceEmergency, _config.AmbulanceName.Translation + " has finished rescuing one load of patients at the scene.");
				_rescueTimer = 0f;
				return true;
			}
			return false;
		}

		private void Debug_VisualProgress(bool toEmergency)
		{
			string text = string.Empty;
			string text2 = (toEmergency ? ">" : "<");
			string text3 = Config.AmbulanceName.Translation + " Ambulance";
			text3 = ((!(this is RivalAmbulance rivalAmbulance)) ? ("Your " + text3) : ((rivalAmbulance.Owner as RivalAmbulanceDepartment)?.Config.RivalFoundationDefinition.Instance.FoundationName.Translation + "'s " + text3));
			switch ((int)_progress)
			{
			case 0:
				text = "|" + text2 + "..........| - " + text3;
				break;
			case 10:
				text = "|." + text2 + ".........| - " + text3;
				break;
			case 20:
				text = "|.." + text2 + "........| - " + text3;
				break;
			case 30:
				text = "|..." + text2 + ".......| - " + text3;
				break;
			case 40:
				text = "|...." + text2 + "......| - " + text3;
				break;
			case 50:
				text = "|....." + text2 + ".....| - " + text3;
				break;
			case 60:
				text = "|......" + text2 + "....| - " + text3;
				break;
			case 70:
				text = "|......." + text2 + "...| - " + text3;
				break;
			case 80:
				text = "|........" + text2 + "..| - " + text3;
				break;
			case 90:
				text = "|........." + text2 + ".| - " + text3;
				break;
			case 100:
				text = "|.........." + text2 + "| - " + text3;
				break;
			}
			if (!text.IsNullOrEmpty() && _lastDebugLog != text)
			{
				Logging.Info(LogChannels.AmbulanceEmergency, text);
				_lastDebugLog = text;
			}
		}

		public virtual bool CanBeAssignedTo(ChallengeAmbulanceEmergency emergency, bool includeReassign)
		{
			bool flag = emergency.Definition.ValidAmbulanceType == AmbulanceConfig.Type.All || emergency.Definition.ValidAmbulanceType == AmbulanceType;
			bool flag2 = emergency.IsJourneyFutile(this);
			return (CurrentState == State.Idle || (includeReassign && _ambulanceEmergency != null && _ambulanceEmergency != emergency)) && !flag2 && flag;
		}

		public virtual void SetEmergency(ChallengeAmbulanceEmergency emergency, float distance)
		{
			_ambulanceEmergency = emergency;
			_currentEmergencyDistance = distance;
			_currentRoute = _owner.GetRouteToEmergency(emergency, _config.AmbulanceType);
			_currentEmergencyETA = CalculateETA();
			_currentEmergencyLocation = _ambulanceEmergency.Location;
		}

		public void ClearEmergency()
		{
			_ambulanceEmergency = null;
			_currentRoute = null;
			_currentEmergencyDistance = 0f;
			_currentEmergencyETA = 0f;
			_currentEmergencyLocation = Vector2.zero;
		}

		public virtual void LeaveWhenReady()
		{
		}

		public virtual bool BeginGettingReady()
		{
			if (_currentState != State.Idle && _currentState != State.ReturnOrIdleDecision)
			{
				return false;
			}
			Logging.Info(LogChannels.AmbulanceEmergency, $"Ambulance {Config.AmbulanceName} has been assigned! ({CurrentEmergencyDistance} miles out)");
			_currentState = State.GettingReady;
			return true;
		}

		public void ForceDispatch()
		{
			_ambulanceEmergency.OnAmbulanceDepartHospital.InvokeSafe(this);
			_currentState = State.MovingToEmergency;
		}

		public virtual void RestoreFromSave(Level level)
		{
		}

		public virtual float GetHighestSpeedFromStaff()
		{
			return 1f;
		}

		public float CalculateETA(ChallengeAmbulanceEmergency ambulanceEmergency = null)
		{
			if (Owner?.BaseConfig == null)
			{
				return 0f;
			}
			float num = ((ambulanceEmergency != null) ? (ambulanceEmergency.CalculateDistance(Owner.BaseConfig.Location) / (Config.Speed * GetHighestSpeedFromStaff())) : (CalculateDistance(Owner.BaseConfig.Location) / (Config.Speed * GetHighestSpeedFromStaff())));
			num *= 100f;
			return num / ((Time.timeScale == 0f) ? 1f : Time.timeScale);
		}

		private float CalculateDistance(Vector2 startingLocation)
		{
			return Vector2.Distance(startingLocation, _currentEmergencyLocation);
		}
	}
}
