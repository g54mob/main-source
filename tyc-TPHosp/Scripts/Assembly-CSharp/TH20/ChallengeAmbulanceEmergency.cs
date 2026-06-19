#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TH20.UI;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class ChallengeAmbulanceEmergency : Challenge
	{
		private class PatientsPerAmbulance
		{
			public int _journeyID;

			public int _patientCount;

			public int _patientsCured;
		}

		private string _emergencyID;

		private int _patientsInitialSpawn;

		private int _patientsRemaining;

		private bool _isRescue;

		private bool _isTutorial;

		private int _patientsPlayerCollected;

		private int _patientsRivalsCollected;

		private int _cured;

		private int _failed;

		private int _deathsAtHospital;

		private int _deathsAtScene;

		private Vector2 _location;

		private bool _finished;

		private bool _playerHasDispatched;

		private List<Patient> _patients;

		private List<Ambulance> _ambulancesInUse;

		private List<AmbulanceDepartment> _departmentsResponded;

		private Dictionary<IllnessDefinition, WeightedIllness> _weightedIllnesses;

		private ChallengeAmbulanceEmergencyConfig _config;

		private Level _level;

		private CharacterManager _characterManager;

		private bool _patientsAllProcessed;

		private bool _deathFreePeriodEnded;

		private int _ticksBeforeFirstDeath;

		private int _wouldBeDeadPatients;

		private float _deathClockDuration;

		private float _deathClockElapsed;

		private float _deathClockElapsedTotal;

		private bool _menuNeedsInit;

		public Action<Ambulance> OnAmbulanceDepartHospital;

		public Action<Ambulance> OnAmbulanceArriveEmergency;

		public Action<Ambulance> OnAmbulanceArriveHospital;

		public Action<Ambulance> OnAmbulanceAssigned;

		public Action<ChallengeAmbulanceEmergency> OnAllPatientsCollected;

		public Action<ChallengeAmbulanceEmergency> OnAllAmbulancesReturned;

		public Action OnDeathClockTick;

		public Action<Ambulance> OnAmbulanceUnassigned;

		public string EmergencyID => _emergencyID;

		public ReadOnlyCollection<Ambulance> AmbulancesInUse => _ambulancesInUse.AsReadOnly();

		public Vector2 Location => _location;

		public bool PlayerAmbulancesInUse => _ambulancesInUse.Count((Ambulance a) => a is PlayerAmbulance) > 0;

		public int TotalPatients => _patientsInitialSpawn;

		public int PatientsRemaining => _patientsRemaining;

		public int WouldBeDeadPatients => _wouldBeDeadPatients;

		public int PatientsDiedAtScene => _deathsAtScene;

		public int PatientsCollected => _patientsPlayerCollected + _patientsRivalsCollected;

		public bool PatientsCollectedAndAmbulancesReturned
		{
			get
			{
				if (_patientsRemaining == 0)
				{
					return _ambulancesInUse.Count == 0;
				}
				return false;
			}
		}

		public Dictionary<IllnessDefinition, WeightedIllness> WeightedIllnesses => _weightedIllnesses;

		public float DeathClockDaysRemaining => Mathf.Clamp(Mathf.RoundToInt((_deathClockDuration - _deathClockElapsedTotal) / GameAlgorithms.Config.SecondsPerDay), 0f, float.PositiveInfinity);

		public float DeathClockRemaining => _deathClockElapsedTotal / _deathClockDuration;

		public float DeathClockRemainingAsSeconds => _deathClockDuration - _deathClockElapsedTotal;

		public int DeathClockTicksBeforeFirstDeath => _ticksBeforeFirstDeath;

		public int OriginalDeathClockTicksBeforeFirstDeath => _config.SeverityTicksBeforeFirstDeath;

		public new ChallengeAmbulanceEmergencyConfig Definition => _definition as ChallengeAmbulanceEmergencyConfig;

		public bool IsRescue => _isRescue;

		public bool IsTutorial => _isTutorial;

		public bool PlayerHasDispatched => _playerHasDispatched;

		public ChallengeAmbulanceEmergency(ChallengeAmbulanceEmergencyConfig definition, Level level)
			: base(definition, level)
		{
			_config = definition;
			_level = level;
			_characterManager = level.CharacterManager;
			_patientsInitialSpawn = UnityEngine.Random.Range(definition.MinPatients, definition.MaxPatients);
			_isRescue = _config.IsRescue;
			_isTutorial = _config.IsTutorial;
			_patientsRemaining = _patientsInitialSpawn;
			_wouldBeDeadPatients = _patientsInitialSpawn;
			_ticksBeforeFirstDeath = _config.SeverityTicksBeforeFirstDeath;
			_ambulancesInUse = new List<Ambulance>();
			_departmentsResponded = new List<AmbulanceDepartment>();
			_patients = new List<Patient>(_patientsInitialSpawn);
			_location = _config.Location.Instance.EmergencyLocation;
			string[] array = new string[5];
			LocalisedString nameLocalised = _definition.NameLocalised;
			array[0] = nameLocalised.ToString();
			array[1] = "_";
			array[2] = _location.ToString();
			array[3] = "_";
			array[4] = _level.ChallengeManager.AddUniqueSuffix().ToString();
			_emergencyID = string.Concat(array);
			_deathClockElapsed = 0f;
			_deathClockElapsedTotal = 0f;
			_deathClockDuration = (float)(_patientsInitialSpawn + _ticksBeforeFirstDeath) * _config.SeveritySecondsPerDeath;
			Logging.Info(LogChannels.AmbulanceEmergency, $"Created {_patientsRemaining} potential patients at emergency, {Vector2.Distance(Vector2.zero, _config.Location.Instance.EmergencyLocation)} miles away.");
			SetupRequiredIllnessDictionary();
			_level.ChallengeManager.NotifyDepartments(this);
			InitMenu();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterDebugCommands();
			InitMenu();
		}

		protected override void InitMenu()
		{
			GeneralNotificationMenu generalNotificationMenu = _level.HUD.FindMenu<GeneralNotificationMenu>();
			if (generalNotificationMenu != null)
			{
				EmergencyChallengeMenu emergencyChallengeMenu = generalNotificationMenu.EmergencyChallengeMenu;
				if ((bool)emergencyChallengeMenu)
				{
					GameObjectUtils.SetActive(emergencyChallengeMenu.gameObject, isActive: true);
					emergencyChallengeMenu.Setup(_level);
				}
				_menuNeedsInit = false;
			}
			else
			{
				_menuNeedsInit = true;
			}
		}

		protected override void UpdateChallenge(float timeDelta)
		{
			if (_menuNeedsInit)
			{
				InitMenu();
			}
			UpdateDeathClock(timeDelta);
			if (EmergencyIsComplete())
			{
				FinishChallenge();
			}
		}

		private void UpdateDeathClock(float timeDelta)
		{
			_deathClockElapsed += timeDelta * Time.timeScale;
			_deathClockElapsedTotal += timeDelta * Time.timeScale;
			if (!(_deathClockElapsed >= _config.SeveritySecondsPerDeath) || _patientsRemaining <= 0)
			{
				return;
			}
			_deathClockElapsed = 0f;
			Logging.Info(LogChannels.AmbulanceEmergency, $"DEATH-CLOCK {DeathClockRemaining}%");
			if (!_deathFreePeriodEnded)
			{
				_ticksBeforeFirstDeath--;
				_deathFreePeriodEnded = _ticksBeforeFirstDeath <= 0;
				OnDeathClockTick.InvokeSafe();
				return;
			}
			_wouldBeDeadPatients--;
			if (_wouldBeDeadPatients < _patientsRemaining)
			{
				_deathFreePeriodEnded = true;
				_deathsAtScene++;
				_patientsRemaining--;
				if (_patientsRemaining <= 0)
				{
					OnAllPatientsCollected.InvokeSafe(this);
				}
				_level.CharacterEvents.OnPatientDiedAtScene.InvokeSafe(_playerHasDispatched, _emergencyID);
				Logging.Info(LogChannels.AmbulanceEmergency, "A patient has died at the scene!");
			}
			OnDeathClockTick.InvokeSafe();
			Logging.Info(LogChannels.AmbulanceEmergency, $"Died/Would-Have ({_deathsAtScene}/{_patientsInitialSpawn - _wouldBeDeadPatients}) - " + $"Collected/All ({_patientsPlayerCollected + _patientsRivalsCollected}/{_patientsInitialSpawn})");
		}

		public bool IsJourneyFutile(Ambulance ambulance)
		{
			if (_patientsRemaining == 0)
			{
				return true;
			}
			float num = ambulance.CalculateETA(this);
			float num2 = _config.SeveritySecondsPerDeath / ((Time.timeScale == 0f) ? 1f : Time.timeScale);
			int num3 = Mathf.FloorToInt(num / num2);
			if (!_deathFreePeriodEnded)
			{
				num3 -= _ticksBeforeFirstDeath;
			}
			if (num3 >= _patientsRemaining || num > DeathClockRemainingAsSeconds)
			{
				return true;
			}
			return false;
		}

		public int PlayerAmbulanceArrivesAtEmergency(PlayerAmbulance ambulance)
		{
			Logging.Info(LogChannels.AmbulanceEmergency, $"Ambulance {ambulance.Config.AmbulanceName} has arrived at emergency!");
			int num = 0;
			int patientsRemaining = _patientsRemaining;
			int patientCapacity = ambulance.Config.PatientCapacity;
			if (_patientsRemaining - patientCapacity > 0)
			{
				_patientsRemaining -= patientCapacity;
				num = patientCapacity;
			}
			else
			{
				num = _patientsRemaining;
				_patientsRemaining = 0;
				OnAllPatientsCollected.InvokeSafe(this);
			}
			Logging.Info(LogChannels.AmbulanceEmergency, $"Your {ambulance.Config.AmbulanceName} Ambulance  takes {num}/{patientsRemaining} patients - ({_patientsRemaining} remaining)");
			List<Patient> list = new List<Patient>();
			if (!_isRescue)
			{
				list = _characterManager.CreateAmbulancePatients(_weightedIllnesses, num, ambulance.ID, _emergencyID);
				_patients.AddRange(list);
				ambulance.OnboardPatients(list);
			}
			_patientsPlayerCollected += num;
			_level.CharacterEvents.OnPatientsCollectedByPlayer.InvokeSafe(list, _emergencyID);
			_level.CharacterEvents.OnPatientsCollected.InvokeSafe(num);
			OnAmbulanceArriveEmergency.InvokeSafe(ambulance);
			return num;
		}

		public void PlayerAmbulanceArrivesAtHospital(PlayerAmbulance ambulance)
		{
			Logging.Info(LogChannels.AmbulanceEmergency, $"Ambulance {ambulance.Config.AmbulanceName} has returned!");
			OnAmbulanceArriveHospital.InvokeSafe(ambulance);
		}

		public void RivalAmbulanceArrivesAtHospital(RivalAmbulance ambulance)
		{
			Logging.Info(LogChannels.AmbulanceEmergency, $"Ambulance {ambulance.Config.AmbulanceName} has returned!");
			OnAmbulanceArriveHospital.InvokeSafe(ambulance);
		}

		public int RivalCollectsPatients(RivalAmbulance ambulance)
		{
			int num = 0;
			int patientsRemaining = _patientsRemaining;
			int patientCapacity = ambulance.Config.PatientCapacity;
			if (_patientsRemaining - patientCapacity > 0)
			{
				num = patientCapacity;
				_patientsRemaining -= patientCapacity;
			}
			else
			{
				num = _patientsRemaining;
				_patientsRemaining = 0;
				OnAllPatientsCollected.InvokeSafe(this);
			}
			Logging.Info(LogChannels.AmbulanceEmergency, $"{ambulance.Owner.FoundationName}'s {ambulance.Config.AmbulanceName} " + $"Ambulance takes {num}/{patientsRemaining} patients - ({_patientsRemaining} remaining)");
			_patientsRivalsCollected += num;
			_level.CharacterEvents.OnPatientsCollected.InvokeSafe(num);
			return num;
		}

		private void SetupRequiredIllnessDictionary()
		{
			_weightedIllnesses = new Dictionary<IllnessDefinition, WeightedIllness>();
			WeightedIllness[] weightedIllnesses = _config.WeightedIllnesses;
			foreach (WeightedIllness weightedIllness in weightedIllnesses)
			{
				IllnessDefinition instance = weightedIllness.Definition.Instance;
				if (!_weightedIllnesses.ContainsKey(instance) && instance.DLCIsValid())
				{
					_weightedIllnesses.Add(instance, weightedIllness);
				}
			}
		}

		public void AssignAmbulance(Ambulance ambulance)
		{
			if (_ambulancesInUse.Contains(ambulance))
			{
				Logging.Info(LogChannels.AmbulanceEmergency, "Tried to assign " + ambulance.Config.AmbulanceName.Translation + " but that Ambulance is already assigned to this Emergency");
				return;
			}
			if (ambulance is PlayerAmbulance)
			{
				_playerHasDispatched = true;
			}
			_departmentsResponded.Add(ambulance.Owner);
			_ambulancesInUse.Add(ambulance);
			ambulance.SetEmergency(this, CalculateDistance(ambulance.Owner.BaseConfig.Location));
			OnAmbulanceAssigned.InvokeSafe(ambulance);
		}

		public float CalculateDistance(Vector2 startingLocation)
		{
			return Vector2.Distance(startingLocation, _location);
		}

		public void UnAssignAmbulance(Ambulance ambulance)
		{
			_ambulancesInUse.Remove(ambulance);
			ambulance.ClearEmergency();
			OnAmbulanceUnassigned.InvokeSafe(ambulance);
			if (PatientsCollectedAndAmbulancesReturned)
			{
				OnAllAmbulancesReturned.InvokeSafe(this);
			}
		}

		protected override void OnChallengeStarted()
		{
			base.OnChallengeStarted();
			RegisterDebugCommands();
			Logging.Info(LogChannels.AmbulanceEmergency, "Ambulance Emergency Challenge Started!");
		}

		protected override void OnChallengeFinished()
		{
			Logging.Info(LogChannels.AmbulanceEmergency, $"Ambulance Emergency Challenge Complete! Cured: {_cured} Deaths: {_deathsAtHospital} Fails: {_failed} ");
			UnregisterDebugCommands();
			base.OnChallengeFinished();
		}

		protected override int CalculateChallengeScore()
		{
			return (int)((float)_cured / (float)_patientsPlayerCollected) * 100;
		}

		private void RegisterDebugCommands()
		{
			ConsoleCommandsDatabase.RegisterCommand("FreezeRivals", "Stop all rival ambulance departments from doing anything", "CreateAllAmbulanceTypes", Debug_FreezeRivals);
			ConsoleCommandsDatabase.RegisterCommand("UnfreezeRivals", "Allow rival ambulance departments to continue", "CreateSlowAmbulance", Debug_UnfreezeRivals);
		}

		private void UnregisterDebugCommands()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("FreezeRivals");
			ConsoleCommandsDatabase.UnRegisterCommand("UnfreezeRivals");
		}

		private bool EmergencyIsComplete()
		{
			if (_patientsRemaining > 0)
			{
				return false;
			}
			foreach (Ambulance item in _ambulancesInUse)
			{
				if (item.CurrentState != Ambulance.State.Idle && item.CurrentState != Ambulance.State.Maintenance)
				{
					return false;
				}
			}
			_level.ChallengeManager.PlayerAmbulanceDepartment.EmergencyOver(this);
			foreach (RivalAmbulanceDepartment rivalAmbulanceDepartment in _level.ChallengeManager.RivalAmbulanceDepartments)
			{
				rivalAmbulanceDepartment.EmergencyOver(this);
			}
			UnAssignAllAmbulances();
			return true;
		}

		private void UnAssignAllAmbulances()
		{
			if (_ambulancesInUse != null)
			{
				foreach (Ambulance item in _ambulancesInUse)
				{
					item.ClearEmergency();
					OnAmbulanceUnassigned.InvokeSafe(item);
				}
				_ambulancesInUse.Clear();
			}
			if (PatientsCollectedAndAmbulancesReturned)
			{
				OnAllAmbulancesReturned.InvokeSafe(this);
			}
		}

		public override void Destroy()
		{
			UnregisterDebugCommands();
			base.Destroy();
		}

		private ConsoleCommandResult Debug_FreezeRivals(string[] args)
		{
			foreach (RivalAmbulanceDepartment rivalAmbulanceDepartment in _level.ChallengeManager.RivalAmbulanceDepartments)
			{
				rivalAmbulanceDepartment.Debug_Freeze();
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UnfreezeRivals(string[] args)
		{
			foreach (RivalAmbulanceDepartment rivalAmbulanceDepartment in _level.ChallengeManager.RivalAmbulanceDepartments)
			{
				rivalAmbulanceDepartment.Debug_Unfreeze();
			}
			return ConsoleCommandResult.Succeeded();
		}
	}
}
