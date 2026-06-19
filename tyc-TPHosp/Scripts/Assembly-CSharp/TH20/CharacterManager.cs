#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class CharacterManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public SharedInstance<PatientDefinition> _patientDefinition;

			public SharedInstance<GhostDefinition> _ghostDefinition;

			public SharedInstance<AliensManager.Config> _aliensManagerConfig;

			public SharedInstance<AnachronisticManager.EraConfig> _anachronisticManagerConfig;

			public int _maxStaff = 512;

			public int _maxPatients = 250;

			public float _patientSpawnRate;

			public float _reputationArrivalRateMultiplierMin = 1f;

			public float _reputationArrivalRateMultiplierMax = 2f;

			public float _arrivalRandomFactor = 5f;

			public ExternalBehavior _patientBehaviour;

			public WeightedIllness[] _weightedIllnesses;

			public bool _usePatientSelector = true;

			public float _patientSelectionRandomJitter = 0.35f;

			public float _patientTimePortalSpawnRate = 1f;

			public float _patientTimePortalSpawnReductionPerInstance = 0.1f;

			public WeightedIllness[] _weightedIllnessesTimePortal;

			public int ChanceOfLowHygieneEffect = 50;

			public float LowHygieneChanceCheckInterval = 4f;

			public SharedInstance<CharacterStatusEffectDefinition>[] LowHygieneStatusEffects;

			public SharedInstance<ArrivalMethodDefinition> DefaultArrivalMethod;

			public WeightedArrivalMethod[] RandomArrivalMethods;

			public Dictionary<SharedInstance<IllnessDefinition>, SharedInstance<ArrivalMethodDefinition>> OverrideArrivalMethod;

			public EntityComponent[] LevelEffectComponents;

			public bool NeverSpawnPatients;
		}

		private class TimePortalPatientSpawned : IPatientSpawned
		{
			private IPatientSpawned _onSpawned;

			public TimePortalPatientSpawned(IPatientSpawned onSpawned = null)
			{
				_onSpawned = onSpawned;
			}

			public void OnPatientSpawned(Patient patient)
			{
				patient.AddComponent<PatientTimePortalComponent>();
				if (_onSpawned != null)
				{
					_onSpawned.OnPatientSpawned(patient);
					_onSpawned = null;
				}
			}

			public void OnFailedToSpawn()
			{
				if (_onSpawned != null)
				{
					_onSpawned.OnFailedToSpawn();
					_onSpawned = null;
				}
			}

			public bool IsValid()
			{
				return true;
			}

			public int GetArrivalPriority()
			{
				return 0;
			}
		}

		private class SpawnPatientOnArrival : IArrivedCallback
		{
			private readonly CharacterManager _characterManager;

			private readonly IllnessDefinition _illnessDefinition;

			private readonly IPatientSpawned _onSpawned;

			public SpawnPatientOnArrival(CharacterManager characterManager, IllnessDefinition illnessDefinition, IPatientSpawned onSpawned)
			{
				_characterManager = characterManager;
				_illnessDefinition = illnessDefinition;
				_onSpawned = onSpawned;
			}

			public Character OnArrived(Vector3 position)
			{
				Patient patient = _characterManager.CreatePatient(_illnessDefinition, position);
				if (_onSpawned != null)
				{
					_onSpawned.OnPatientSpawned(patient);
				}
				return patient;
			}

			public void OnFailed()
			{
				if (_onSpawned != null)
				{
					_onSpawned.OnFailedToSpawn();
				}
			}

			public bool HasPatientSpawnedCallback(IPatientSpawned patientSpawned)
			{
				return _onSpawned == patientSpawned;
			}

			public bool IsValid()
			{
				if (_onSpawned != null)
				{
					return _onSpawned.IsValid();
				}
				return true;
			}

			public int GetArrivalPriority()
			{
				if (_onSpawned != null)
				{
					return _onSpawned.GetArrivalPriority();
				}
				return 0;
			}
		}

		private class SpawnVisitorOnArrival : IArrivedCallback
		{
			private readonly CharacterManager _characterManager;

			private readonly VisitorDefinition _visitorDefinition;

			private readonly IVisitorSpawned _onSpawned;

			public SpawnVisitorOnArrival(CharacterManager characterManager, VisitorDefinition patientDefinition, IVisitorSpawned onSpawned)
			{
				_characterManager = characterManager;
				_visitorDefinition = patientDefinition;
				_onSpawned = onSpawned;
			}

			public Character OnArrived(Vector3 position)
			{
				Visitor visitor = new Visitor(_visitorDefinition, _characterManager._level, _characterManager._visualManager, _characterManager.TakeNextCharacterID(), position);
				_characterManager._visitors.Add(visitor);
				_characterManager._allCharacters.Add(visitor);
				_characterManager._level.CharacterEvents.OnVisitorSpawned.InvokeSafe(visitor);
				if (_onSpawned != null)
				{
					_onSpawned.OnVisitorSpawned(visitor);
				}
				_characterManager.ApplyLevelComponents(visitor);
				return visitor;
			}

			public void OnFailed()
			{
				if (_onSpawned != null)
				{
					_onSpawned.OnFailedToSpawn();
				}
			}

			public bool HasPatientSpawnedCallback(IPatientSpawned patientSpawned)
			{
				return false;
			}

			public bool IsValid()
			{
				if (_onSpawned != null)
				{
					return _onSpawned.IsValid();
				}
				return true;
			}

			public int GetArrivalPriority()
			{
				return GameAlgorithms.Config.ArrivalPriorityVisitor;
			}
		}

		private class SetRandomDiagnosisOrTreatmentProgress : IPatientSpawned
		{
			private readonly ResearchManager _researchManager;

			public SetRandomDiagnosisOrTreatmentProgress(ResearchManager researchManager)
			{
				_researchManager = researchManager;
			}

			public void OnPatientSpawned(Patient patient)
			{
				float num = RandomUtils.GlobalRandomInstance.NextFloat();
				if (num > 0.85f)
				{
					patient.ModifyDiagnosisCertainty(RandomUtils.GlobalRandomInstance.NextFloat(70f, 100f));
					if (patient.ReasonUsingRoom != ReasonUseRoom.Treatment)
					{
						patient.SendToTreatmentRoom(patient.Illness.GetTreatmentRoom(patient, _researchManager), immediately: true);
					}
				}
				else if (num > 0.15f)
				{
					patient.ModifyDiagnosisCertainty(RandomUtils.GlobalRandomInstance.NextFloat(0f, 80f));
				}
			}

			public void OnFailedToSpawn()
			{
			}

			public bool IsValid()
			{
				return true;
			}

			public int GetArrivalPriority()
			{
				return 0;
			}
		}

		private static readonly LogChannel LogChannel = new LogChannel("CharacterManager");

		private readonly Config _config;

		private readonly Level _level;

		private readonly CharacterNameGenerator _nameGenerator;

		private readonly VisualManager _visualManager;

		private readonly PrestigeTracker _prestigeTracker;

		private readonly ReputationTracker _reputationTracker;

		private readonly ArrivalsManager _arrivalsManager;

		private readonly DeparturesManager _departuresManager;

		private readonly List<Staff> _staff;

		private readonly List<Patient> _patients;

		private readonly List<Visitor> _visitors;

		private readonly List<Character> _allCharacters;

		private CustomisationOption _defaultDoctorCustomisationOption;

		private CustomisationOption _defaultNurseCustomisationOption;

		private CustomisationOption _defaultAssistantCustomisationOption;

		private CustomisationOption _defaultJanitorCustomisationOption;

		private readonly List<Character> _destroyedCharacters;

		private readonly Dictionary<IllnessDefinition, WeightedIllness> _illnesses;

		private Dictionary<IllnessDefinition, WeightedIllness> _illnessesTimePortal;

		private Dictionary<IllnessDefinition, WeightedIllness> _illnessesAmbulance = new Dictionary<IllnessDefinition, WeightedIllness>();

		private readonly NextPatientSelector _nextPatientSelector;

		private AliensManager _aliensManager;

		private AnachronisticManager _anachronisticManager;

		private Dictionary<IllnessDefinition, int> _totalIllnessSpawnCount;

		private readonly List<MarketingCampaignComponent> _marketingCampaigns;

		private readonly List<CharacterStatusEffectDefinition> _lowHygieneStatusEffects;

		private bool _stopPatientSpawning;

		private float _timeToSpawnPatient;

		private float _timeToPortalSpawnPatient;

		private static readonly Vector3 _ambulancePatientSpawnLocation = new Vector3(0f, -100f, 0f);

		private readonly WeightedList<ArrivalMethodDefinition> _arrivalMethods;

		private int _nextCharacterID;

		private readonly ArrivalMethodRandomHospitalLocationDefinition _arrivalMethodRandom = new ArrivalMethodRandomHospitalLocationDefinition();

		[DontSave]
		private GUIStyle _debugGUIStyle;

		public float PatientArrivalRateMultiplier { private get; set; }

		public static Vector3 AmbulancePatientSpawnLocation => _ambulancePatientSpawnLocation;

		public List<Patient> Patients => _patients;

		public List<Staff> StaffMembers => _staff;

		public List<Visitor> Visitors => _visitors;

		public List<Character> AllCharacters => _allCharacters;

		public List<CharacterStatusEffectDefinition> LowHygieneStatusEffects => _lowHygieneStatusEffects;

		public int ChanceOfLowHygieneEffect => _config.ChanceOfLowHygieneEffect;

		public float LowHygieneChanceCheckInterval => _config.LowHygieneChanceCheckInterval;

		public DeparturesManager DeparturesManager => _departuresManager;

		public ArrivalsManager ArrivalsManager => _arrivalsManager;

		public float StaffEnergy => GetEnergyOfStaffType(StaffDefinition.Type.None);

		public float StaffRank => GetRankOfStaffType(StaffDefinition.Type.None);

		public float StaffMorale => GetMoraleOfStaffType(StaffDefinition.Type.None);

		public float PatientHappiness
		{
			get
			{
				if (Patients.Count != 0)
				{
					return Patients.Sum((Patient patient) => (patient.Happiness == null) ? 0f : patient.Happiness.Value()) / (float)Patients.Count / 100f;
				}
				return 0f;
			}
		}

		public float PatientHealth
		{
			get
			{
				if (Patients.Count != 0)
				{
					return Patients.Sum((Patient patient) => patient.Health.Value()) / (float)Patients.Count / 100f;
				}
				return 0f;
			}
		}

		public int SpawnedPatients { get; private set; }

		public bool CanSpawnMoreStaff { get; private set; }

		public bool NeverSpawnPatients
		{
			get
			{
				if (_config.NeverSpawnPatients)
				{
					if (_level != null)
					{
						return !_level.IsSandbox();
					}
					return true;
				}
				return false;
			}
		}

		public CustomisationOption DefaultDoctorCustomisationOption
		{
			get
			{
				return _defaultDoctorCustomisationOption;
			}
			set
			{
				_defaultDoctorCustomisationOption = value;
			}
		}

		public CustomisationOption DefaultNurseCustomisationOption
		{
			get
			{
				return _defaultNurseCustomisationOption;
			}
			set
			{
				_defaultNurseCustomisationOption = value;
			}
		}

		public CustomisationOption DefaultAssistantCustomisationOption
		{
			get
			{
				return _defaultAssistantCustomisationOption;
			}
			set
			{
				_defaultAssistantCustomisationOption = value;
			}
		}

		public CustomisationOption DefaultJanitorCustomisationOption
		{
			get
			{
				return _defaultJanitorCustomisationOption;
			}
			set
			{
				_defaultJanitorCustomisationOption = value;
			}
		}

		public bool StopPatientSpawning
		{
			set
			{
				_stopPatientSpawning = value;
			}
		}

		public static LogChannel GetLogChannel()
		{
			return LogChannel;
		}

		public AliensManager GetAliensManager()
		{
			return _aliensManager;
		}

		public AnachronisticManager GetAnachronisticManager()
		{
			return _anachronisticManager;
		}

		public Config GetConfig()
		{
			return _config;
		}

		public int TakeNextCharacterID()
		{
			return ++_nextCharacterID;
		}

		public CharacterManager(Config config, Level level, PrestigeTracker prestigeTracker, ReputationTracker reputationTracker, CharacterNameGenerator nameGenerator, VisualManager visualManager)
		{
			_config = config;
			_level = level;
			_nameGenerator = nameGenerator;
			_visualManager = visualManager;
			_prestigeTracker = prestigeTracker;
			_reputationTracker = reputationTracker;
			_arrivalsManager = new ArrivalsManager(_level);
			_departuresManager = new DeparturesManager(_level);
			_staff = new List<Staff>();
			_patients = new List<Patient>();
			_visitors = new List<Visitor>();
			_allCharacters = new List<Character>();
			_destroyedCharacters = new List<Character>();
			_totalIllnessSpawnCount = new Dictionary<IllnessDefinition, int>();
			CanSpawnMoreStaff = true;
			_illnesses = new Dictionary<IllnessDefinition, WeightedIllness>();
			WeightedIllness[] weightedIllnesses = _config._weightedIllnesses;
			foreach (WeightedIllness weightedIllness in weightedIllnesses)
			{
				if (!weightedIllness.Deprecated && weightedIllness.Unlocked)
				{
					AddIllness(weightedIllness.Definition.Instance);
				}
			}
			_illnessesTimePortal = new Dictionary<IllnessDefinition, WeightedIllness>();
			if (_config._weightedIllnessesTimePortal != null)
			{
				weightedIllnesses = _config._weightedIllnessesTimePortal;
				foreach (WeightedIllness weightedIllness2 in weightedIllnesses)
				{
					if (!weightedIllness2.Deprecated && weightedIllness2.Unlocked)
					{
						AddIllnessTimePortal(weightedIllness2.Definition.Instance);
					}
				}
			}
			_arrivalMethods = new WeightedList<ArrivalMethodDefinition>();
			if (_config.DefaultArrivalMethod.NotNull())
			{
				_arrivalMethods.Add(_config.DefaultArrivalMethod.Instance, 100);
			}
			if (_config.RandomArrivalMethods != null)
			{
				WeightedArrivalMethod[] randomArrivalMethods = _config.RandomArrivalMethods;
				foreach (WeightedArrivalMethod weightedArrivalMethod in randomArrivalMethods)
				{
					_arrivalMethods.Add(weightedArrivalMethod.Definition.Instance, weightedArrivalMethod.Weight);
				}
			}
			_marketingCampaigns = new List<MarketingCampaignComponent>();
			_nextPatientSelector = new NextPatientSelector(_level, _reputationTracker, _marketingCampaigns, _config);
			if (AliensRequired())
			{
				_aliensManager = new AliensManager(_config._aliensManagerConfig.Instance, _level, this);
			}
			AnachronisticManager.EraConfig eraConfig = ((_config._anachronisticManagerConfig != null) ? _config._anachronisticManagerConfig.Instance : null);
			if (eraConfig != null && eraConfig.ArePatientsRequired())
			{
				_anachronisticManager = new AnachronisticManager(eraConfig, _level, this);
			}
			_lowHygieneStatusEffects = new List<CharacterStatusEffectDefinition>();
			if (_config.LowHygieneStatusEffects != null)
			{
				SharedInstance<CharacterStatusEffectDefinition>[] lowHygieneStatusEffects = _config.LowHygieneStatusEffects;
				foreach (SharedInstance<CharacterStatusEffectDefinition> sharedInstance in lowHygieneStatusEffects)
				{
					_lowHygieneStatusEffects.Add(sharedInstance.Instance);
				}
			}
			Level level2 = _level;
			level2.PostConstruct = (Action)Delegate.Combine(level2.PostConstruct, new Action(RegisterGameEvents));
			_timeToSpawnPatient = CalculateSpawnTime();
			_timeToPortalSpawnPatient = CalculatePortalSpawnTime();
			RegsiterDebugCommands();
		}

		private void RegisterGameEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnAddIllness = (Action<IllnessDefinition>)Delegate.Combine(characterEvents.OnAddIllness, new Action<IllnessDefinition>(AddIllness));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnRemoveIllness = (Action<IllnessDefinition>)Delegate.Combine(characterEvents2.OnRemoveIllness, new Action<IllnessDefinition>(RemoveIllness));
			HospitalEvents hospitalEvents = _level.HospitalEvents;
			hospitalEvents.OnHospitalOpened = (Action)Delegate.Combine(hospitalEvents.OnHospitalOpened, new Action(OnHospitalOpened));
			HospitalEvents hospitalEvents2 = _level.HospitalEvents;
			hospitalEvents2.OnHospitalClosed = (Action)Delegate.Combine(hospitalEvents2.OnHospitalClosed, new Action(OnHospitalClosed));
			MarketingManager marketingManager = _level.MarketingManager;
			marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Combine(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			MarketingManager marketingManager2 = _level.MarketingManager;
			marketingManager2.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Combine(marketingManager2.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
		}

		public void PreRestoreFromSave()
		{
			ArrivalTimePortalComponent._isRestoringFromSave = true;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_totalIllnessSpawnCount == null)
			{
				_totalIllnessSpawnCount = new Dictionary<IllnessDefinition, int>();
			}
			if (_illnessesTimePortal == null)
			{
				_illnessesTimePortal = new Dictionary<IllnessDefinition, WeightedIllness>();
			}
			if (AliensRequired())
			{
				if (_aliensManager == null)
				{
					_aliensManager = new AliensManager(_config._aliensManagerConfig.Instance, _level, this);
				}
				_aliensManager.RestoreFromSave();
			}
			AnachronisticManager.EraConfig eraConfig = ((_config._anachronisticManagerConfig != null) ? _config._anachronisticManagerConfig.Instance : null);
			if (eraConfig != null && eraConfig.ArePatientsRequired())
			{
				if (_anachronisticManager == null)
				{
					_anachronisticManager = new AnachronisticManager(eraConfig, _level, this);
				}
				_anachronisticManager.RestoreFromSave();
			}
			_nextPatientSelector.RestoreFromSave();
			_arrivalsManager.RestoreFromSave();
			_departuresManager.RestoreFromSave(_level);
			_allCharacters.RemoveDuplicates();
			foreach (Character allCharacter in _allCharacters)
			{
				allCharacter.RestoreFromSave();
			}
			foreach (Character allCharacter2 in _allCharacters)
			{
				allCharacter2.PostRestoreFromSaveCallback.InvokeSafe();
				allCharacter2.PostRestoreFromSaveCallback = null;
			}
			RegisterGameEvents();
			RegsiterDebugCommands();
			CanSpawnMoreStaff = _staff.Count < _config._maxStaff;
			foreach (Room allRoom in _level.WorldState.AllRooms)
			{
				if (allRoom.Definition.IsHospitalOrBay)
				{
					continue;
				}
				foreach (Character item in new List<Character>(allRoom.CharactersUsing))
				{
					if (item.RoomUsing != allRoom && allRoom.CharacterEntering != item && (item.Interaction == null || !item.Interaction.IsRoomDoorInteraction()))
					{
						allRoom.ExitRoom(item);
						Logging.Warning(LogChannel, "Removed {0} from {1} as they're no longer in that room", item, allRoom);
					}
				}
			}
			foreach (Character allCharacter3 in _allCharacters)
			{
				if (_level.WorldState.GetRoomAtWorldCoord(allCharacter3.Position, includeHospital: true, includeClosedPlots: false) != allCharacter3.RoomUsing)
				{
					FixRoomCharacterIn(allCharacter3.RoomUsing, allCharacter3);
				}
			}
			if (_illnessesAmbulance == null)
			{
				_illnessesAmbulance = new Dictionary<IllnessDefinition, WeightedIllness>();
			}
		}

		public void PostRestoreFromSave()
		{
			ArrivalTimePortalComponent._isRestoringFromSave = false;
		}

		private void FixRoomCharacterIn(Room room, Character character)
		{
			if (room == null || room.FloorPlan == null || room.Definition.IsHospitalOrBay)
			{
				return;
			}
			RoomItem door = room.FloorPlan.Door;
			if (door != null)
			{
				Logging.Warning(LogChannel, "{0} isn't in {1} ...fixing that!", character, room);
				Vector3 worldPosition = door.WorldPosition;
				if (character.RoomUsing != null)
				{
					character.RoomUsing.ExitRoom(character);
				}
				character.Position = worldPosition;
				character.NavPath.Warp(worldPosition);
				character.ForceUpdateRoomUsing(room);
				room.EnterRoom(character, character.ReasonUsingRoom);
				Level level = _level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, new Action(character.FixupMissingBehaviour));
			}
		}

		public CustomisationOption GetDefaultSaffCustomisationOption(StaffDefinition.Type staffType)
		{
			CustomisationOption result = null;
			switch (staffType)
			{
			case StaffDefinition.Type.Doctor:
				result = _defaultDoctorCustomisationOption;
				break;
			case StaffDefinition.Type.Nurse:
				result = _defaultNurseCustomisationOption;
				break;
			case StaffDefinition.Type.Assistant:
				result = _defaultAssistantCustomisationOption;
				break;
			case StaffDefinition.Type.Janitor:
				result = _defaultJanitorCustomisationOption;
				break;
			}
			return result;
		}

		public float GetEnergyOfStaffType(StaffDefinition.Type staffType)
		{
			int num = 0;
			float num2 = 0f;
			foreach (Staff staffMember in StaffMembers)
			{
				if (staffType == StaffDefinition.Type.None || staffMember.Definition._type == staffType)
				{
					num++;
					num2 += staffMember.Energy.Value() / 100f;
				}
			}
			if (num != 0)
			{
				return num2 / (float)num;
			}
			return 0f;
		}

		public float GetRankOfStaffType(StaffDefinition.Type staffType)
		{
			int num = 0;
			float num2 = 0f;
			foreach (Staff staffMember in StaffMembers)
			{
				if (staffType == StaffDefinition.Type.None || staffMember.Definition._type == staffType)
				{
					num++;
					num2 += (float)(staffMember.Rank + 1);
				}
			}
			if (num != 0)
			{
				return num2 / (float)num;
			}
			return 0f;
		}

		public float GetMoraleOfStaffType(StaffDefinition.Type staffType)
		{
			int num = 0;
			float num2 = 0f;
			foreach (Staff staffMember in StaffMembers)
			{
				if ((staffType == StaffDefinition.Type.None || staffMember.Definition._type == staffType) && !staffMember.Definition._excludeFromStaffMoraleCalculations)
				{
					num++;
					num2 += ((staffMember.Happiness != null) ? (staffMember.Happiness.Value() / 100f) : 0f);
				}
			}
			if (num != 0)
			{
				return num2 / (float)num;
			}
			return 0f;
		}

		public int GetNumberOfStaffReadyForTraining()
		{
			int num = 0;
			foreach (Staff staffMember in StaffMembers)
			{
				if (staffMember.HasFreeTrainingSlots)
				{
					num++;
				}
			}
			return num;
		}

		public override void Destroy()
		{
			_nextPatientSelector.Destroy();
			_aliensManager?.Destroy();
			_anachronisticManager?.Destroy();
			_arrivalsManager.Destroy();
			_departuresManager.Destroy();
			DestroyAllCharacters();
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnAddIllness = (Action<IllnessDefinition>)Delegate.Remove(characterEvents.OnAddIllness, new Action<IllnessDefinition>(AddIllness));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnRemoveIllness = (Action<IllnessDefinition>)Delegate.Remove(characterEvents2.OnRemoveIllness, new Action<IllnessDefinition>(RemoveIllness));
			HospitalEvents hospitalEvents = _level.HospitalEvents;
			hospitalEvents.OnHospitalOpened = (Action)Delegate.Remove(hospitalEvents.OnHospitalOpened, new Action(OnHospitalOpened));
			HospitalEvents hospitalEvents2 = _level.HospitalEvents;
			hospitalEvents2.OnHospitalClosed = (Action)Delegate.Remove(hospitalEvents2.OnHospitalClosed, new Action(OnHospitalClosed));
			MarketingManager marketingManager = _level.MarketingManager;
			marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Remove(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			MarketingManager marketingManager2 = _level.MarketingManager;
			marketingManager2.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Remove(marketingManager2.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			UnregisterDebugCommands();
			base.Destroy();
		}

		private void DestroyAllCharacters()
		{
			_staff.Clear();
			_patients.Clear();
			_visitors.Clear();
			_allCharacters.ClearAndCallDestroy();
			_aliensManager?.ClearAllCharacters();
			_anachronisticManager?.ClearAllCharacters();
		}

		public void Update(float deltaTime)
		{
			SpawnNewPatients(deltaTime);
			_arrivalsManager.Update();
			DeparturesManager.Update();
			_aliensManager?.Update();
			_anachronisticManager?.Update();
			ProcessCharacters(deltaTime);
		}

		private void ProcessCharacters(float deltaTime)
		{
			foreach (Character allCharacter in _allCharacters)
			{
				allCharacter.Update(deltaTime);
			}
			if (_destroyedCharacters.Count != 0)
			{
				for (int i = 0; i < _destroyedCharacters.Count; i++)
				{
					DestroyCharacterDeferred(_destroyedCharacters[i]);
				}
				_destroyedCharacters.Clear();
			}
		}

		private float CalculateSpawnTime()
		{
			float num = Mathf.Lerp(_config._reputationArrivalRateMultiplierMin, _config._reputationArrivalRateMultiplierMax, _reputationTracker.OverallReputation);
			float patientArrivalRate = _prestigeTracker.Data.PatientArrivalRate;
			float num2 = ((PatientArrivalRateMultiplier > 0f) ? PatientArrivalRateMultiplier : 1f);
			float num3 = _config._patientSpawnRate / num2 / num / patientArrivalRate;
			float num4 = RandomUtils.GlobalRandomInstance.NextFloat(0f - _config._arrivalRandomFactor, _config._arrivalRandomFactor);
			num4 = num3 * (num4 / 100f);
			return num3 + num4;
		}

		private float CalculatePortalSpawnTime()
		{
			int num = Mathf.Max(ArrivalTimePortalComponent.Count(), 1) - 1;
			float num2 = Mathf.Max(_config._patientTimePortalSpawnRate - (float)num * _config._patientTimePortalSpawnReductionPerInstance, _config._patientTimePortalSpawnReductionPerInstance);
			float num3 = RandomUtils.GlobalRandomInstance.NextFloat(0f - _config._arrivalRandomFactor, _config._arrivalRandomFactor);
			num3 = num2 * (num3 / 100f);
			return num2 + num3;
		}

		public List<Patient> CreateAmbulancePatients(Dictionary<IllnessDefinition, WeightedIllness> weightedIllnesses, int patientCount, int ambulanceID, string emergencyID)
		{
			List<Patient> list = new List<Patient>(patientCount);
			for (int i = 0; i < patientCount; i++)
			{
				IllnessDefinition illnessDefinition = RandomIllness(weightedIllnesses);
				AddAmbulanceIllness(illnessDefinition, weightedIllnesses[illnessDefinition]);
				Patient patient = CreateAEPatient(illnessDefinition, _ambulancePatientSpawnLocation, navDisabled: true, delayedVisualCreation: true, ambulanceID, emergencyID);
				list.Add(patient);
				patient.AddComponent<DisableSelectionComponent>().InitializeComponent();
				patient.AddComponent<DisableHighlightComponent>().InitializeComponent();
				patient.AddComponent<DisableStatusIconComponent>();
				patient.EnableBehaviour(enabled: false);
			}
			return list;
		}

		private void SpawnNewPatients(float deltaTime)
		{
			if (NeverSpawnPatients || _stopPatientSpawning || HospitalAtMaxCapacity())
			{
				return;
			}
			_timeToSpawnPatient -= deltaTime;
			if (_timeToSpawnPatient <= 0f)
			{
				SpawnRandomPatient(_illnesses, null);
				_timeToSpawnPatient += CalculateSpawnTime();
			}
			if (_anachronisticManager == null)
			{
				return;
			}
			ArrivalTimePortalComponent.Update(deltaTime);
			IllnessDefinition illnessDefinition = null;
			ArrivalMethodDefinition arrivalMethod = null;
			IPatientSpawned onSpawned = null;
			while (ArrivalTimePortalComponent.CanSpawnQueuedTransform(ref illnessDefinition, ref arrivalMethod, ref onSpawned))
			{
				onSpawned = new TimePortalPatientSpawned(onSpawned);
				if (illnessDefinition != null)
				{
					if (arrivalMethod == null)
					{
						arrivalMethod = GetDefaultArrivalDefinition(illnessDefinition);
					}
					SpawnPatient(illnessDefinition, arrivalMethod, onSpawned, bAllowPatientTypeOverrides: true);
				}
				else
				{
					SpawnRandomPatient(_illnessesTimePortal, onSpawned);
				}
			}
			if (ArrivalTimePortalComponent.Count() > 0)
			{
				_timeToPortalSpawnPatient -= deltaTime;
				if (_timeToPortalSpawnPatient <= 0f && ArrivalTimePortalComponent.ValidToSpawn())
				{
					SpawnRandomPatient(_illnessesTimePortal, new TimePortalPatientSpawned());
					_timeToPortalSpawnPatient += CalculatePortalSpawnTime();
				}
			}
		}

		private bool HospitalAtMaxCapacity()
		{
			return Patients.Count >= _config._maxPatients;
		}

		public IllnessDefinition RandomIllness()
		{
			return RandomIllness(_illnesses);
		}

		private IllnessDefinition RandomIllness(Dictionary<IllnessDefinition, WeightedIllness> illnesses)
		{
			if (_config._usePatientSelector)
			{
				return _nextPatientSelector.NextIllness(illnesses);
			}
			if (illnesses.Count != 0)
			{
				int num = 0;
				int num2 = 0;
				int[] array = new int[illnesses.Count];
				foreach (KeyValuePair<IllnessDefinition, WeightedIllness> illness in illnesses)
				{
					IllnessDefinition key = illness.Key;
					if (!key.IsPlatformValid(OSManager.GetPlatform()))
					{
						continue;
					}
					float illnessReputation = _reputationTracker.GetIllnessReputation(key);
					int num3 = (int)Mathf.Lerp(illness.Value.MinWeight, illness.Value.MaxWeight, illnessReputation);
					float num4 = 1f;
					foreach (MarketingCampaignComponent marketingCampaign in _marketingCampaigns)
					{
						num4 += marketingCampaign.CalculateIllnessMultiplier(key);
					}
					num += (array[num2] = (int)((float)num3 * num4));
					num2++;
				}
				int num5 = 0;
				int num6 = RandomUtils.GlobalRandomInstance.Next(0, num + 1);
				num2 = 0;
				foreach (KeyValuePair<IllnessDefinition, WeightedIllness> illness2 in illnesses)
				{
					num5 += array[num2];
					if (num5 >= num6)
					{
						return illness2.Key;
					}
					num2++;
				}
			}
			return null;
		}

		private void ApplyLevelComponents(Character character)
		{
			if (_config.LevelEffectComponents != null)
			{
				EntityComponent[] levelEffectComponents = _config.LevelEffectComponents;
				foreach (EntityComponent obj in levelEffectComponents)
				{
					character.AddComponent(MustCallDestroyOnInstance.CreateInstance(obj));
				}
			}
		}

		public void AddSpecialCharacter(Character character)
		{
			if (!character.HasBeenDestroyed())
			{
				_allCharacters.AddUnique(character);
			}
		}

		public Patient CreateAEPatient(IllnessDefinition illnessDefinition, Vector3 position, bool navDisabled = false, bool delayedVisualCreation = false, int ambulanceID = -1, string emergencyID = "")
		{
			return CreatePatient(illnessDefinition, position, _config._patientDefinition.Instance, navDisabled, delayedVisualCreation, ambulanceID, emergencyID);
		}

		public Patient CreatePatient(IllnessDefinition illnessDefinition, Vector3 position)
		{
			return CreatePatient(illnessDefinition, position, _config._patientDefinition.Instance);
		}

		public Patient CreatePatient(IllnessDefinition illnessDefinition, Vector3 position, PatientDefinition patientDefinition, bool navDisabled = false, bool delayedVisualCreation = false, int ambulanceID = -1, string emergencyID = "")
		{
			Character.Sex sex = ((UnityEngine.Random.Range(0, 2) != 0) ? Character.Sex.Female : Character.Sex.Male);
			CharacterName characterName = CharacterName.Empty;
			if (_anachronisticManager != null && AnachronisticPatientsRequired())
			{
				characterName = _anachronisticManager.GeneratePatientName(illnessDefinition, sex);
			}
			if (characterName == CharacterName.Empty)
			{
				characterName = _nameGenerator.Generate(sex);
			}
			int numSpawned = (_totalIllnessSpawnCount.ContainsKey(illnessDefinition) ? _totalIllnessSpawnCount[illnessDefinition] : 0);
			Patient patient = new Patient(patientDefinition, illnessDefinition.ChooseDefinition(numSpawned), _level, _visualManager, sex, characterName, TakeNextCharacterID(), position, navDisabled, delayedVisualCreation, ambulanceID, emergencyID);
			patient.SetBehaviour(_config._patientBehaviour);
			_patients.Add(patient);
			_allCharacters.Add(patient);
			if (_totalIllnessSpawnCount.ContainsKey(illnessDefinition))
			{
				_totalIllnessSpawnCount[illnessDefinition]++;
			}
			else
			{
				_totalIllnessSpawnCount.Add(illnessDefinition, 1);
			}
			SpawnedPatients++;
			_level.CharacterEvents.OnPatientSpawned.InvokeSafe(patient);
			ApplyLevelComponents(patient);
			return patient;
		}

		private void SpawnRandomPatient(Dictionary<IllnessDefinition, WeightedIllness> illnesses, IPatientSpawned onSpawned)
		{
			IllnessDefinition illnessDefinition = RandomIllness(illnesses);
			SpawnPatient(illnessDefinition, GetDefaultArrivalDefinition(illnessDefinition), onSpawned, bAllowPatientTypeOverrides: true);
		}

		public void SpawnPatient(IllnessDefinition illnessDefinition, ArrivalMethodDefinition arrivalMethod, IPatientSpawned onSpawned, bool bAllowPatientTypeOverrides = false)
		{
			ArrivalMethodDefinition methodDefinition = ((arrivalMethod != null) ? arrivalMethod : GetDefaultArrivalDefinition(illnessDefinition));
			_arrivalsManager.Add(methodDefinition, CreatePatientArrivedCallback(illnessDefinition, onSpawned, bAllowPatientTypeOverrides));
		}

		public void SpawnAlien(IllnessDefinition illnessDefinition, ArrivalMethodDefinition arrivalMethod, IPatientSpawned onSpawned)
		{
			if (_aliensManager != null && AliensRequired() && _aliensManager.IsIllnessAllowedForAlien(illnessDefinition))
			{
				ArrivalMethodDefinition methodDefinition = ((arrivalMethod != null) ? arrivalMethod : GetDefaultArrivalDefinition(illnessDefinition));
				_arrivalsManager.Add(methodDefinition, _aliensManager.CreateAlienArrivedCallback(illnessDefinition, onSpawned));
			}
		}

		public void SpawnAnachronisticPatient(IllnessDefinition illnessDefinition, ArrivalMethodDefinition arrivalMethod, IPatientSpawned onSpawned)
		{
			if (_anachronisticManager != null && AnachronisticPatientsRequired() && _anachronisticManager.IsIllnessAllowedForPatient(illnessDefinition))
			{
				ArrivalMethodDefinition methodDefinition = ((arrivalMethod != null) ? arrivalMethod : GetDefaultArrivalDefinition(illnessDefinition));
				_arrivalsManager.Add(methodDefinition, _anachronisticManager.CreatePatientArrivedCallback(illnessDefinition, onSpawned));
			}
		}

		public Staff SpawnStaff(JobApplicant applicant, Vector3 position, bool navDisabled)
		{
			Staff staff = new Staff(applicant, _level, _visualManager, TakeNextCharacterID(), position, navDisabled);
			CustomisationOption defaultSaffCustomisationOption = GetDefaultSaffCustomisationOption(staff.Definition._type);
			staff.Visual.SetCustomisationOption(defaultSaffCustomisationOption, staff);
			_staff.Add(staff);
			_allCharacters.Add(staff);
			_level.CharacterEvents.OnStaffSpawned.InvokeSafe(staff);
			CanSpawnMoreStaff = _staff.Count < _config._maxStaff;
			ApplyLevelComponents(staff);
			return staff;
		}

		private IArrivedCallback CreatePatientArrivedCallback(IllnessDefinition illnessDefinition, IPatientSpawned onSpawned, bool bAllowPatientTypeOverrides)
		{
			IArrivedCallback arrivedCallback = null;
			if (bAllowPatientTypeOverrides)
			{
				if (AliensRequired())
				{
					arrivedCallback = _aliensManager.CheckCreateAlienArrivedCallback(illnessDefinition, onSpawned);
				}
				if (AnachronisticPatientsRequired())
				{
					arrivedCallback = _anachronisticManager.CheckCreatePatientArrivedCallback(illnessDefinition, onSpawned);
				}
			}
			if (arrivedCallback == null)
			{
				arrivedCallback = new SpawnPatientOnArrival(this, illnessDefinition, onSpawned);
			}
			return arrivedCallback;
		}

		public void SpawnVisitor(VisitorDefinition visitorDefinition, ArrivalMethodDefinition arrivalMethod, IVisitorSpawned onSpawned)
		{
			_arrivalsManager.Add(arrivalMethod, new SpawnVisitorOnArrival(this, visitorDefinition, onSpawned));
		}

		public void SpawnGhostFromCharacter(Character owner)
		{
			SpawnGhost(owner.Gender, owner.CharacterName, owner.Position, owner.Rotation).GetOrAddComponent<DeathRecordComponent>().Initialise(owner);
		}

		public void SpawnRandomGhost(Vector3 position, float rotation, GhostDefinition definition = null)
		{
			Character.Sex sex = Character.Sex.Male;
			CharacterName name = _nameGenerator.Generate(sex);
			SpawnGhost(sex, name, position, Quaternion.Euler(0f, rotation, 0f), definition);
		}

		private void SpawnOwnerlessGhost(Vector3 position)
		{
			SpawnRandomGhost(position, 0f);
		}

		private Character SpawnGhost(Character.Sex gender, CharacterName name, Vector3 position, Quaternion rotation, GhostDefinition definition = null)
		{
			Character character = new Character((definition != null) ? definition : _config._ghostDefinition.Instance, _level, _visualManager, gender, name, TakeNextCharacterID(), position, navDisabled: false)
			{
				Rotation = rotation
			};
			character.ForceUpdateRoomUsing(_level.WorldState.GetRoomAtWorldCoord(position, includeHospital: true, includeClosedPlots: true));
			_allCharacters.Add(character);
			_level.CharacterEvents.OnGhostSpawned.InvokeSafe(character);
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.GhostSpawned);
			return character;
		}

		public bool IsPendingDestroy(Character character)
		{
			return _destroyedCharacters.Contains(character);
		}

		public void DestroyCharacter(Character character)
		{
			if (_allCharacters.Contains(character))
			{
				_destroyedCharacters.AddUnique(character);
			}
		}

		public void DestroyOrphan(Character character)
		{
			DestroyCharacterDeferred(character);
		}

		private void DestroyCharacterDeferred(Character character)
		{
			if (character == null)
			{
				return;
			}
			Patient patient = character as Patient;
			Visitor visitor = character as Visitor;
			if (patient != null)
			{
				_patients.Remove(patient);
				if (AliensRequired())
				{
					_aliensManager.CheckRemove(patient);
				}
				if (AnachronisticPatientsRequired())
				{
					_anachronisticManager.CheckRemove(patient);
				}
				_level.CharacterEvents.OnPatientDestroyed.InvokeSafe(patient);
			}
			else if (visitor != null)
			{
				_visitors.Remove(visitor);
				_level.CharacterEvents.OnVisitorDestroyed.InvokeSafe(visitor);
			}
			else if (character is Staff staff)
			{
				_staff.Remove(staff);
				CanSpawnMoreStaff = _staff.Count < _config._maxStaff;
				_level.CharacterEvents.OnStaffDestroyed.InvokeSafe(staff);
			}
			_level.CharacterEvents.OnCharacterDestroyed.InvokeSafe(character);
			_allCharacters.Remove(character);
			if (!character.HasBeenDestroyed())
			{
				character.Destroy();
				return;
			}
			Logging.Warning(LogChannel, "Character {0} has already been destroyed", character);
		}

		private void AddIllness(IllnessDefinition illness)
		{
			if (_illnesses.ContainsKey(illness) || !illness.DLCIsValid())
			{
				return;
			}
			WeightedIllness[] weightedIllnesses = _config._weightedIllnesses;
			foreach (WeightedIllness weightedIllness in weightedIllnesses)
			{
				if (!weightedIllness.Deprecated && weightedIllness.Definition.Instance == illness)
				{
					_illnesses.Add(illness, weightedIllness);
					if (!_totalIllnessSpawnCount.ContainsKey(illness))
					{
						_totalIllnessSpawnCount.Add(illness, 0);
					}
					RegisterSpawnPatientConsoleCommand(illness);
					return;
				}
			}
			Logging.Error(LogChannel, "Illness {0} isn't available on this level", illness.Name);
		}

		private void AddAmbulanceIllness(IllnessDefinition illness, WeightedIllness weightedIllness)
		{
			if (!_illnessesAmbulance.ContainsKey(illness) && illness.DLCIsValid())
			{
				_illnessesAmbulance.Add(illness, weightedIllness);
				if (!_totalIllnessSpawnCount.ContainsKey(illness))
				{
					_totalIllnessSpawnCount.Add(illness, 0);
				}
				RegisterSpawnPatientConsoleCommand(illness);
			}
		}

		private void AddIllnessTimePortal(IllnessDefinition illness)
		{
			if (_illnessesTimePortal.ContainsKey(illness) || !illness.DLCIsValid())
			{
				return;
			}
			WeightedIllness[] weightedIllnessesTimePortal = _config._weightedIllnessesTimePortal;
			foreach (WeightedIllness weightedIllness in weightedIllnessesTimePortal)
			{
				if (!weightedIllness.Deprecated && weightedIllness.Definition.Instance == illness)
				{
					_illnessesTimePortal.Add(illness, weightedIllness);
					if (!_totalIllnessSpawnCount.ContainsKey(illness))
					{
						_totalIllnessSpawnCount.Add(illness, 0);
					}
					RegisterSpawnPatientConsoleCommand(illness);
					return;
				}
			}
			Logging.Error(LogChannel, "Illness {0} isn't available on this level", illness.Name);
		}

		private void RemoveIllness(IllnessDefinition definition)
		{
			if (_illnesses.Remove(definition))
			{
				ConsoleCommandsDatabase.UnRegisterCommand($"SpawnPatient {definition.Name}");
				return;
			}
			Logging.Error(LogChannel, "Trying to remove illness {0} that hasn't been added", definition.Name);
		}

		public ArrivalMethodDefinition GetDefaultArrivalMethod()
		{
			ArrivalMethodDefinition arrivalMethodDefinition = _arrivalMethods.Choose(null, RandomUtils.GlobalRandomInstance);
			while (!arrivalMethodDefinition.IsAvailable())
			{
				Logging.Warning(LogChannel, "Removing invalid arrival method {0}", arrivalMethodDefinition);
				_arrivalMethods.Remove(arrivalMethodDefinition);
				arrivalMethodDefinition = _arrivalMethods.Choose(null, RandomUtils.GlobalRandomInstance);
			}
			return arrivalMethodDefinition;
		}

		private ArrivalMethodDefinition GetDefaultArrivalDefinition(IllnessDefinition illnessDef)
		{
			if (_config.OverrideArrivalMethod != null)
			{
				foreach (KeyValuePair<SharedInstance<IllnessDefinition>, SharedInstance<ArrivalMethodDefinition>> item in _config.OverrideArrivalMethod)
				{
					if (item.Key.Instance == illnessDef)
					{
						return item.Value.Instance;
					}
				}
			}
			return GetDefaultArrivalMethod();
		}

		private void OnHospitalOpened()
		{
			_stopPatientSpawning = false;
			_timeToSpawnPatient = 0f;
		}

		private void OnHospitalClosed()
		{
			_stopPatientSpawning = true;
		}

		public int GetStaffOfTypeCount(StaffDefinition.Type type)
		{
			int num = 0;
			for (int i = 0; i < StaffMembers.Count; i++)
			{
				if (StaffMembers[i].Definition._type == type)
				{
					num++;
				}
			}
			return num;
		}

		public List<Staff> GetStaffOfType(StaffDefinition definition)
		{
			List<Staff> list = new List<Staff>();
			for (int i = 0; i < StaffMembers.Count; i++)
			{
				Staff staff = StaffMembers[i];
				if (definition == null || staff.Definition == definition)
				{
					list.Add(staff);
				}
			}
			return list;
		}

		public bool IsIllnessUnlocked(IllnessDefinition illness)
		{
			if (!_illnesses.ContainsKey(illness))
			{
				return _illnessesAmbulance.ContainsKey(illness);
			}
			return true;
		}

		public bool IsIllnessAvailable(IllnessDefinition illness)
		{
			if (!_nextPatientSelector.IsIllnessAvailable(illness, _illnesses) && !_nextPatientSelector.IsIllnessAvailable(illness, _illnessesTimePortal))
			{
				return _nextPatientSelector.IsIllnessAvailable(illness, _illnessesAmbulance);
			}
			return true;
		}

		public void GetCharactersWithinDistance(Vector3 position, float radius, Room room, List<Character> charactersOut)
		{
			float num = radius * radius;
			foreach (Character allCharacter in _allCharacters)
			{
				if ((room == null || allCharacter.RoomUsing == room) && position.SquareDistance2D(allCharacter.Position) < num)
				{
					charactersOut.Add(allCharacter);
				}
			}
		}

		private void OnCampaignStarted(MarketingCampaignComponent component)
		{
			if (component.ActiveCampaign is IllnessMarketingCampaignDefinition)
			{
				_marketingCampaigns.Add(component);
			}
		}

		private void OnCampaignEnded(MarketingCampaignComponent component, bool cancelled)
		{
			if (component.ActiveCampaign is IllnessMarketingCampaignDefinition)
			{
				_marketingCampaigns.Remove(component);
			}
		}

		private bool AliensRequired()
		{
			if (_config._aliensManagerConfig != null && _config._aliensManagerConfig.Instance != null)
			{
				return _config._aliensManagerConfig.Instance.AreAliensRequired();
			}
			return false;
		}

		private bool AnachronisticPatientsRequired()
		{
			if (_anachronisticManager != null)
			{
				return _anachronisticManager.ArePatientsRequired();
			}
			return false;
		}

		public bool IllnessWithTreatmentRoomExists(RoomDefinition room)
		{
			foreach (IllnessDefinition key in _illnesses.Keys)
			{
				if (key._treatmentTypes == null)
				{
					continue;
				}
				IllnessDefinition.TreatmentType[] treatmentTypes = key._treatmentTypes;
				foreach (IllnessDefinition.TreatmentType treatmentType in treatmentTypes)
				{
					if (treatmentType._room != null && treatmentType._room.Instance == room)
					{
						return true;
					}
				}
			}
			foreach (IllnessDefinition key2 in _illnessesAmbulance.Keys)
			{
				if (key2._treatmentTypes == null)
				{
					continue;
				}
				IllnessDefinition.TreatmentType[] treatmentTypes = key2._treatmentTypes;
				foreach (IllnessDefinition.TreatmentType treatmentType2 in treatmentTypes)
				{
					if (treatmentType2._room != null && treatmentType2._room.Instance == room)
					{
						return true;
					}
				}
			}
			return false;
		}

		public float GetAverageStaffNeedsValue()
		{
			float num = 0f;
			int num2 = 0;
			CharacterAttributes.Needs results = new CharacterAttributes.Needs();
			foreach (Staff item in _staff)
			{
				item.GetCharacterAttributes().GetNeeds(0f, ref results);
				foreach (KeyValuePair<CharacterAttributes.Type, AttributeFloat> item2 in results)
				{
					num2++;
					num += item2.Value.Value();
				}
			}
			if (num2 == 0)
			{
				return 0f;
			}
			return num / (float)num2;
		}

		public float CalculateEnvironmentRating(CharacterAttributes.Type type)
		{
			int num = 0;
			float num2 = 0f;
			foreach (Character allCharacter in AllCharacters)
			{
				AttributeFloat attribute = allCharacter.GetAttributes().GetAttribute((int)type);
				if (attribute != null)
				{
					num++;
					num2 += attribute.Value();
				}
			}
			if (num == 0)
			{
				return num2;
			}
			return num2 / (float)num;
		}

		public void OverrideIllnesses(WeightedIllnessList illnessList)
		{
			_illnesses.Clear();
			foreach (WeightedIllness illness in illnessList.Illnesses)
			{
				IllnessDefinition instance = illness.Definition.Instance;
				if (instance.DLCIsValid())
				{
					_illnesses.Add(instance, illness);
					if (!_totalIllnessSpawnCount.ContainsKey(instance))
					{
						_totalIllnessSpawnCount.Add(instance, 0);
					}
				}
			}
		}

		public void OverrideAnachronisticManager(AnachronisticManager.EraConfig eraConfig)
		{
			if (eraConfig != null)
			{
				if (_anachronisticManager == null)
				{
					_anachronisticManager = new AnachronisticManager(eraConfig, _level, this);
				}
				else
				{
					_anachronisticManager.Config = eraConfig;
				}
			}
		}

		public void ModifiySpawnedPatientCount(int numPatients)
		{
			_nextPatientSelector.ModifiySpawnedPatientCount(numPatients);
		}

		private void RegsiterDebugCommands()
		{
			ConsoleCommandsDatabase.RegisterCommand("TogglePatientSpawning", "Toggles patient spawning on/off", "TogglePatientSpawning", Debug_TogglePatientSpawning);
			ConsoleCommandsDatabase.RegisterCommand("SpawnPatient", "Spawns a patient next frame", "SpawnPatient", Debug_SpawnPatient);
			ConsoleCommandsDatabase.RegisterCommand("SpawnSomePatients", "Spawns some (default 16) patients", "SpawnSomePatients [number]", Debug_SpawnSomePatients);
			ConsoleCommandsDatabase.RegisterCommand("SpawnOnePatientWithEachIllness", "Spawns one patient with each illness", "SpawnOnePatientWithEachIllness", Debug_SpawnOnePatientWithEachIllness);
			ConsoleCommandsDatabase.RegisterCommand("SpawnGhost", "Spawns a ghost", "SpawnGhost", Debug_SpawnGhost);
			ConsoleCommandsDatabase.RegisterCommand("SpawnGhostAtCursor", "Spawns a ghost at the cursor", "SpawnGhostAtCursor", Debug_SpawnGhostAtCursor);
			ConsoleCommandsDatabase.RegisterCommand("Die", "Make all characters dead", "Die", Debug_MakeAllCharactersDie);
			ConsoleCommandsDatabase.RegisterCommand("Poop", "Make all characters have an accident", "Poop", Debug_MakeAllCharactersPoop);
			ConsoleCommandsDatabase.RegisterCommand("Sick", "Make all characters throw up", "Sick", Debug_MakeAllCharactersSick);
			ConsoleCommandsDatabase.RegisterCommand("Thirsty", "Make all characters suddenly super thirsty", "Hungry", Debug_MakeAllCharactersThirsty);
			ConsoleCommandsDatabase.RegisterCommand("Hungry", "Make all characters suddenly super hungry", "Hungry", Debug_MakeAllCharactersHungry);
			ConsoleCommandsDatabase.RegisterCommand("Rage", "Make all patients rage quit", "Rage", Debug_MakeAllCharactersRageQuit);
			ConsoleCommandsDatabase.RegisterAlias("UnHungry", "Make all characters suddenly not at all hungry", "SetAttributeOnAllCharacters", "Hunger", "-100");
			ConsoleCommandsDatabase.RegisterCommand("Unhappy", "Make all characters suddenly unhappy", "Unhappy", Debug_MakeAllCharactersUnhappy);
			ConsoleCommandsDatabase.RegisterSimpleCommand("Happy", "Make all characters suddenly happy", delegate
			{
				Debug_AllCharactersAttribute(CharacterAttributes.Type.Happiness, 100f);
			});
			ConsoleCommandsDatabase.RegisterCommand("SetAttributeOnAllCharacters", "Sets an attribute on all characters to some amount", "SetAttributeOnAllCharacters [attribute name] [value]", Debug_SetAttributeOnAllCharacters);
			ConsoleCommandsDatabase.RegisterCommand("OpenHospital", "Open hospital", "OpenHospital", Debug_OpenHospital);
			ConsoleCommandsDatabase.RegisterCommand("CloseHospital", "Close hospital", "CloseHospital", Debug_CloseHospital);
			ConsoleCommandsDatabase.RegisterCommand("UnlockLevelIllnesses", "Unlocks all illnesses that are defined for this level", "UnlockLevelIllnesses", Debug_UnlockLevelIllnesses);
			ConsoleCommandsDatabase.RegisterCommand("UnlockAllIllnesses", "Unlocks all illnesses", "UnlockAllIllnesses", Debug_UnlockAllIllnesses);
			ConsoleCommandsDatabase.RegisterCommand("RunPatientSpawnSimulation", "Runs a spawn simulation X times to help balance weights", "RunPatientSpawnSimulation [simulations] [patients]", Debug_RunSpawnSimulation);
			foreach (IllnessDefinition key in _illnesses.Keys)
			{
				RegisterSpawnPatientConsoleCommand(key);
			}
			if (_illnessesTimePortal == null)
			{
				return;
			}
			foreach (IllnessDefinition key2 in _illnessesTimePortal.Keys)
			{
				RegisterSpawnPatientConsoleCommand(key2);
			}
		}

		private void UnregisterDebugCommands()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("TogglePatientSpawning");
			ConsoleCommandsDatabase.UnRegisterCommand("SpawnPatient");
			ConsoleCommandsDatabase.UnRegisterCommand("SpawnSomePatients");
			ConsoleCommandsDatabase.UnRegisterCommand("SpawnOnePatientWithEachIllness");
			ConsoleCommandsDatabase.UnRegisterCommand("Die");
			ConsoleCommandsDatabase.UnRegisterCommand("Poop");
			ConsoleCommandsDatabase.UnRegisterCommand("Sick");
			ConsoleCommandsDatabase.UnRegisterCommand("Thirsty");
			ConsoleCommandsDatabase.UnRegisterCommand("Hungry");
			ConsoleCommandsDatabase.UnRegisterCommand("UnHungry");
			ConsoleCommandsDatabase.UnRegisterCommand("Unhappy");
			ConsoleCommandsDatabase.UnRegisterCommand("Happy");
			ConsoleCommandsDatabase.UnRegisterCommand("SetAttributeOnAllCharacters");
			ConsoleCommandsDatabase.UnRegisterCommand("OpenHospital");
			ConsoleCommandsDatabase.UnRegisterCommand("CloseHospital");
			ConsoleCommandsDatabase.UnRegisterCommand("UnlockLevelIllnesses");
			ConsoleCommandsDatabase.UnRegisterCommand("RunPatientSpawnSimulation");
		}

		public void DebugGUI()
		{
			foreach (Character allCharacter in _allCharacters)
			{
				allCharacter.DebugGUI();
			}
			_aliensManager?.DebugGUI();
			_anachronisticManager?.DebugGUI();
			if (!DebugVars.ShowPatientArrivalInfo.Value)
			{
				return;
			}
			string empty = string.Empty;
			if (_debugGUIStyle == null)
			{
				_debugGUIStyle = new GUIStyle(GUI.skin.box)
				{
					alignment = TextAnchor.UpperLeft,
					font = Font.CreateDynamicFontFromOSFont("Consolas", 12),
					fontStyle = FontStyle.Bold
				};
			}
			empty += "PATIENT ARRIVALS\n";
			empty += $"\n     Patients In Hospital: {Patients.Count}";
			empty += $"\n     Total Spawned Patients: {SpawnedPatients}";
			empty += $"\n     Next patient in: {_timeToSpawnPatient:0.00} seconds";
			empty += "\n\nACTIVE VEHICLE ARRIVALS";
			empty += string.Format("\n{0,40}: {1,10}", "Name", "Passengers");
			foreach (ArrivalMethod arrival in _arrivalsManager.Arrivals)
			{
				if (arrival is ArrivalMethodVehicle arrivalMethodVehicle && arrivalMethodVehicle.Passengers.Count != 0)
				{
					empty += $"\n{arrivalMethodVehicle.Definition,40}: {arrivalMethodVehicle.Passengers.Count,10}";
				}
			}
			Dictionary<ArrivalMethodVehicleDefinition, int> dictionary = new Dictionary<ArrivalMethodVehicleDefinition, int>();
			foreach (ArrivalsManager.PendingArrival pendingArrival in _arrivalsManager.PendingArrivals)
			{
				if (pendingArrival.Definition is ArrivalMethodVehicleDefinition key)
				{
					if (!dictionary.ContainsKey(key))
					{
						dictionary.Add(key, 0);
					}
					dictionary[key]++;
				}
			}
			empty += "\n\nPENDING VEHICLE ARRIVALS";
			empty += string.Format("\n{0,40}: {1,8} {2,8} {3,8}", "Name", "Waiting", "Free", "Total");
			foreach (KeyValuePair<ArrivalMethodVehicleDefinition, int> item in dictionary)
			{
				ArrivalMethodVehicleDefinition key2 = item.Key;
				int value = item.Value;
				empty += $"\n{key2,40}: {value,8} {key2.TotalFreeSpawnPoints(),8} {key2.TotalSpawnPoints(),8}";
			}
			float patientSpawnRate = _config._patientSpawnRate;
			float num = Mathf.Lerp(_config._reputationArrivalRateMultiplierMin, _config._reputationArrivalRateMultiplierMax, _reputationTracker.OverallReputation);
			float patientArrivalRate = _prestigeTracker.Data.PatientArrivalRate;
			float num2 = patientSpawnRate / num / patientArrivalRate;
			float arrivalRandomFactor = _config._arrivalRandomFactor;
			empty += "\n";
			empty += $"\n   Current Frequency: {num2:0.00}";
			empty += $"\n                Base: {patientSpawnRate:0.00}";
			empty += $"\n          Reputation: {num:0.00}";
			empty += $"\n            Prestige: {patientArrivalRate:0.00}";
			empty += $"\n              Random: +/-{arrivalRandomFactor:0.00}%";
			empty += "\n";
			empty += string.Format("\n{0,20}: {1,8}  {2,8}  {3,8} {4,8} {5,8} {6,8} {7,8}", "Name", "Score", "Min", "Max", "MinWeig", "MaxWeig", "Reputation", "Marketing");
			foreach (NextPatientSelector.IllnessDebugInfo item2 in _nextPatientSelector.GetIllnessDebugInfo(_illnesses))
			{
				empty += $"\n{item2.Name,20}: {item2.CurrentScore,8:0}  {item2.MinScoreAdd,8:+0}  {item2.MaxScoreAdd,8:+0} {item2.MinWeight,8:0} {item2.MaxWeight,8:0}   {item2.Reputation,8:0.00}  {item2.Marketing,8:0.00}";
			}
			Vector2 vector = _debugGUIStyle.CalcSize(new GUIContent(empty));
			GUI.Box(new Rect(0f, 0f, vector.x, vector.y), empty, _debugGUIStyle);
		}

		public void DebugDraw()
		{
			foreach (Character allCharacter in _allCharacters)
			{
				allCharacter.DebugDraw();
			}
		}

		private ConsoleCommandResult Debug_MakeAllCharactersDie(params string[] args)
		{
			Debug_AllCharactersAttribute(CharacterAttributes.Type.Health, -100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_MakeAllCharactersSick(string[] args)
		{
			Debug_AllCharactersAttribute(CharacterAttributes.Type.Nausea, 100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_MakeAllCharactersPoop(params string[] args)
		{
			Debug_AllCharactersAttribute(CharacterAttributes.Type.Toilet, 100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_MakeAllCharactersHungry(params string[] args)
		{
			Debug_AllCharactersAttribute(CharacterAttributes.Type.Hunger, 100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_MakeAllCharactersThirsty(params string[] args)
		{
			Debug_AllCharactersAttribute(CharacterAttributes.Type.Thirst, 100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_MakeAllCharactersUnhappy(params string[] args)
		{
			Debug_AllCharactersAttribute(CharacterAttributes.Type.Happiness, -100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_SetAttributeOnAllCharacters(params string[] args)
		{
			if (args.Length < 2)
			{
				return ConsoleCommandResult.Failed("Usage: SetAttributeOnAllCharacters [attribute name] [value]");
			}
			CharacterAttributes.Type attributeType;
			try
			{
				attributeType = EnumHelper<CharacterAttributes.Type>.ToEnum(args[0]);
			}
			catch (Exception)
			{
				return ConsoleCommandResult.Failed("Couldn't match argument \"" + args[0] + "\" to an attribute type. First argument must be an attribute name.");
			}
			if (!int.TryParse(args[1], out var result))
			{
				return ConsoleCommandResult.Failed("Couldn't parse argument \"" + args[1] + "\" as a number. SetAttributeOnAllCharacters needs a number for the second argument.");
			}
			Debug_AllCharactersAttribute(attributeType, result);
			return ConsoleCommandResult.Succeeded();
		}

		private void Debug_AllCharactersAttribute(CharacterAttributes.Type attributeType, float value)
		{
			foreach (Character allCharacter in _allCharacters)
			{
				allCharacter.GetCharacterAttributes().GetAttribute(attributeType)?.Modify(value, 1f);
			}
		}

		private ConsoleCommandResult Debug_MakeAllCharactersRageQuit(params string[] args)
		{
			foreach (Patient patient in _patients)
			{
				patient.RageQuit();
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_TogglePatientSpawning(params string[] args)
		{
			_stopPatientSpawning = !_stopPatientSpawning;
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_OpenHospital(params string[] args)
		{
			_level.HospitalEvents.OnHospitalOpened.InvokeSafe();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_CloseHospital(params string[] args)
		{
			_level.HospitalEvents.OnHospitalClosed.InvokeSafe();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_SpawnGhost(params string[] args)
		{
			if (_level != null)
			{
				List<HospitalMap> hospitalMaps = _level.WorldState.HospitalMaps;
				if (hospitalMaps != null)
				{
					FloorPlan corridorFloorPlan = hospitalMaps.RandomItem().CorridorFloorPlan;
					if (corridorFloorPlan != null)
					{
						Vector3 randomSpawnPositionForCharacter = RoomAlgorithms.GetRandomSpawnPositionForCharacter(corridorFloorPlan);
						SpawnOwnerlessGhost(randomSpawnPositionForCharacter);
						return ConsoleCommandResult.Succeeded();
					}
				}
			}
			return ConsoleCommandResult.Failed();
		}

		private ConsoleCommandResult Debug_SpawnGhostAtCursor(params string[] args)
		{
			if (_level != null)
			{
				SpawnOwnerlessGhost(_level.CursorManager.WorldPosition);
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed();
		}

		private ConsoleCommandResult Debug_SpawnPatient(params string[] args)
		{
			IllnessDefinition illnessDefinition = null;
			List<string> list = new List<string>();
			bool flag = false;
			bool flag2 = false;
			for (int i = 1; i < args.Length; i++)
			{
				if (args[i].ToLower() == "alien")
				{
					flag = true;
					break;
				}
				if (args[i].ToLower() == "anachronistic")
				{
					flag2 = true;
					break;
				}
			}
			if (args.Length >= 1)
			{
				string text = args[0];
				for (int j = 1; j < args.Length; j++)
				{
					text = text + " " + args[j];
				}
				foreach (IllnessDefinition key in _illnesses.Keys)
				{
					if (string.Equals(key.Name.ToString(), text, StringComparison.OrdinalIgnoreCase))
					{
						illnessDefinition = key;
						break;
					}
				}
				if (illnessDefinition == null)
				{
					list.Add("Couldn't find illness with name " + text);
				}
			}
			if (flag)
			{
				SpawnAlien((illnessDefinition != null) ? illnessDefinition : RandomIllness(), null, null);
			}
			else if (flag2)
			{
				SpawnAnachronisticPatient((illnessDefinition != null) ? illnessDefinition : RandomIllness(), null, null);
			}
			else
			{
				SpawnPatient((illnessDefinition != null) ? illnessDefinition : RandomIllness(), null, null);
			}
			return ConsoleCommandResult.Succeeded(string.Join("\n", list.ToArray()));
		}

		private void RegisterSpawnPatientConsoleCommand(IllnessDefinition definition)
		{
			string text = $"SpawnPatient {definition.Name}";
			LocalisedString name = definition.Name;
			ConsoleCommandsDatabase.RegisterCommand(text, "Spawns a patient with " + name.ToString(), text, Debug_SpawnPatient);
		}

		public ConsoleCommandResult Debug_SpawnOnePatientWithEachIllness(params string[] args)
		{
			foreach (KeyValuePair<IllnessDefinition, WeightedIllness> illness in _illnesses)
			{
				SpawnPatient(illness.Value.Definition.Instance, _arrivalMethodRandom, null);
			}
			return ConsoleCommandResult.Succeeded();
		}

		public ConsoleCommandResult Debug_SpawnSomePatients(params string[] args)
		{
			int num = 16;
			if (args.Length != 0)
			{
				if (!int.TryParse(args[0], out var result))
				{
					return ConsoleCommandResult.Failed("Couldn't parse " + args[0] + " as a number");
				}
				num = result;
			}
			for (int i = 0; i < num; i++)
			{
				SpawnPatient(RandomIllness(), _arrivalMethodRandom, new SetRandomDiagnosisOrTreatmentProgress(_level.ResearchManager), bAllowPatientTypeOverrides: true);
				_arrivalsManager.Update();
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UnlockLevelIllnesses(params string[] args)
		{
			WeightedIllness[] weightedIllnesses = _config._weightedIllnesses;
			foreach (WeightedIllness weightedIllness in weightedIllnesses)
			{
				if (!weightedIllness.Deprecated && !_illnesses.ContainsKey(weightedIllness.Definition.Instance))
				{
					AddIllness(weightedIllness.Definition.Instance);
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UnlockAllIllnesses(params string[] args)
		{
			if (_level != null)
			{
				List<HospitalMap> hospitalMaps = _level.WorldState.HospitalMaps;
				if (hospitalMaps != null)
				{
					FloorPlan corridorFloorPlan = hospitalMaps.RandomItem().CorridorFloorPlan;
					if (corridorFloorPlan != null)
					{
						foreach (IllnessDefinition key in _illnesses.Keys)
						{
							Vector3 randomSpawnPositionForCharacter = RoomAlgorithms.GetRandomSpawnPositionForCharacter(corridorFloorPlan);
							Patient patient = _level.CharacterManager.CreatePatient(key, randomSpawnPositionForCharacter);
							if (patient != null)
							{
								_level.CharacterEvents.OnIllnessDiagnosed.InvokeSafe(patient, key);
							}
						}
					}
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_RunSpawnSimulation(params string[] args)
		{
			int numSimulations = 100;
			int numPatients = 500;
			if (args.Length != 0)
			{
				if (!int.TryParse(args[0], out var result))
				{
					return ConsoleCommandResult.Failed("Couldn't parse " + args[0] + " as a number");
				}
				numSimulations = result;
				if (args.Length > 1)
				{
					if (!int.TryParse(args[1], out var result2))
					{
						return ConsoleCommandResult.Failed("Couldn't parse " + args[1] + " as a number");
					}
					numPatients = result2;
				}
			}
			_nextPatientSelector.RunSimulation(numSimulations, numPatients, _illnesses, out var csvTable, out var csvIllnessList);
			File.WriteAllText("User\\NextPatientResults.csv", csvTable);
			File.WriteAllText("User\\NextPatientList.csv", csvIllnessList);
			return ConsoleCommandResult.Succeeded();
		}
	}
}
