using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class AliensManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			[InspectorMargin(8)]
			[InspectorHeader("Non Alien Visuals")]
			public SharedInstance<PatientDefinition> _alienPatientDefinition;

			public SharedInstance<IllnessDefinition>[] _excludedIllnesses;

			[InspectorMargin(8)]
			[InspectorHeader("Alien Visuals & Audio")]
			public SharedInstance<CharModule.Mask> _alienModularMask;

			public CharacterModifier[] _alienModifiers;

			public GameObject _miscAppearanceEffect;

			public float _miscAppearanceEffectTime;

			[InspectorMargin(8)]
			[InspectorHeader("Alien Advisor")]
			public SharedInstance<Advisor.ConfigCollection> _adviceTriggerCollections;

			[InspectorMargin(8)]
			[InspectorHeader("General")]
			public bool _replaceAliensWithPaparazzi;

			public int _maxAliens = 1;

			public float _chanceOfAlienPatient = 1f;

			public float _chanceOfReceptionByPass = 0.5f;

			public int _alienDurationDaysMin = 10;

			public int _alienDurationDaysMax = 30;

			public int _alienFlashAppearanceDaysInitial = 10;

			public int _alienFlashAppearanceDaysMin = 4;

			public int _alienFlashAppearanceDaysMax = 10;

			public float _alienHeadDownPitchDegrees = 60f;

			public bool AreAliensRequired()
			{
				if (_maxAliens > 0)
				{
					return _chanceOfAlienPatient > 0f;
				}
				return false;
			}
		}

		private class SpawnAlienOnArrival : IArrivedCallback
		{
			private readonly AliensManager _aliensManager;

			private readonly CharacterManager _characterManager;

			private readonly IllnessDefinition _illnessDefinition;

			private readonly IPatientSpawned _onSpawned;

			public SpawnAlienOnArrival(AliensManager aliensManager, CharacterManager characterManager, IllnessDefinition illnessDefinition, IPatientSpawned onSpawned)
			{
				_aliensManager = aliensManager;
				_characterManager = characterManager;
				_illnessDefinition = illnessDefinition;
				_onSpawned = onSpawned;
			}

			public Character OnArrived(Vector3 position)
			{
				Patient patient = _characterManager.CreatePatient(_illnessDefinition, position, _aliensManager.AliensManagerConfig._alienPatientDefinition.Instance);
				_aliensManager.OnArrival(patient);
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

		private Config _config;

		private readonly Level _level;

		private readonly CharacterManager _characterManager;

		private int _numAlienSpawnsPending;

		private int _numAliensDiscovered;

		private bool _bAdviceTriggerCollectionsAdded;

		private List<Patient> _aliens;

		public Action<Patient> OnAlienDiscovered;

		public List<Patient> Aliens => _aliens;

		public int NumAliens => _aliens.Count;

		public int NumAliensDiscovered => _numAliensDiscovered;

		public Config AliensManagerConfig
		{
			get
			{
				return _config;
			}
			set
			{
				_config = value;
			}
		}

		public AliensManager(Config config, Level level, CharacterManager characterManager)
		{
			_config = config;
			_level = level;
			_characterManager = characterManager;
			_aliens = new List<Patient>();
			RegisterEvents();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_aliens == null)
			{
				_aliens = new List<Patient>();
			}
			RegisterEvents();
		}

		public override void Destroy()
		{
			UnRegisterEvents();
			base.Destroy();
		}

		public void ClearAllCharacters()
		{
			_aliens.Clear();
		}

		public void Update()
		{
		}

		public void DebugGUI()
		{
			DrawDebugAlienIndicators();
		}

		public static bool IsAlienPatient(Patient patient)
		{
			if (patient != null)
			{
				return patient.GetComponent<AlienComponent>() != null;
			}
			return false;
		}

		public static bool IsDiscoveredAlienPatient(Patient patient)
		{
			bool result = false;
			if (patient != null)
			{
				AlienComponent component = patient.GetComponent<AlienComponent>();
				if (component != null && component.Discovered)
				{
					result = true;
				}
			}
			return result;
		}

		public void Add(Patient alienPatient)
		{
			_aliens.Add(alienPatient);
			AlienComponent component = alienPatient.GetComponent<AlienComponent>();
			if (component != null)
			{
				component.Setup(_config._alienDurationDaysMin, _config._alienDurationDaysMax);
				CheckAddAdviceTriggerCollections();
			}
		}

		public void Remove(Patient alienPatient)
		{
			_aliens.Remove(alienPatient);
		}

		public void CheckRemove(Patient patient)
		{
			if (IsAlienPatient(patient))
			{
				Remove(patient);
			}
		}

		public IArrivedCallback CheckCreateAlienArrivedCallback(IllnessDefinition illnessDefinition, IPatientSpawned onSpawned)
		{
			IArrivedCallback result = null;
			if (_aliens.Count + _numAlienSpawnsPending < _config._maxAliens && IsIllnessAllowedForAlien(illnessDefinition) && UnityEngine.Random.Range(0f, 1f) < _config._chanceOfAlienPatient)
			{
				result = CreateAlienArrivedCallback(illnessDefinition, onSpawned);
				_numAlienSpawnsPending++;
			}
			return result;
		}

		public bool IsIllnessAllowedForAlien(IllnessDefinition illnessDefinition)
		{
			bool result = true;
			if (_config != null && _config._excludedIllnesses != null && _config._excludedIllnesses.Length != 0)
			{
				SharedInstance<IllnessDefinition>[] excludedIllnesses = _config._excludedIllnesses;
				for (int i = 0; i < excludedIllnesses.Length; i++)
				{
					if (excludedIllnesses[i].Instance == illnessDefinition)
					{
						result = false;
						break;
					}
				}
			}
			return result;
		}

		public IArrivedCallback CreateAlienArrivedCallback(IllnessDefinition illnessDefinition, IPatientSpawned onSpawned)
		{
			return new SpawnAlienOnArrival(this, _characterManager, illnessDefinition, onSpawned);
		}

		public void OnArrival(Patient alienPatient)
		{
			_numAlienSpawnsPending--;
			_numAlienSpawnsPending = Mathf.Max(_numAlienSpawnsPending, 0);
			Add(alienPatient);
		}

		public void NotifyAlienDiscovered(Patient alienPatient)
		{
			_numAliensDiscovered++;
			OnAlienDiscovered.InvokeSafe(alienPatient);
			_level.Metagame.LevelEventsIntermediary.OnAlienExposed.InvokeSafe(alienPatient);
		}

		private void RegisterEvents()
		{
			_level.AddTimelineUpdateListener(OnTimelineUpdated);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnDestroyCharacter = (Action<Character>)Delegate.Combine(characterEvents.OnDestroyCharacter, new Action<Character>(OnDestroyCharacter));
		}

		private void UnRegisterEvents()
		{
			_level.RemoveTimelineUpdateListener(OnTimelineUpdated);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnDestroyCharacter = (Action<Character>)Delegate.Remove(characterEvents.OnDestroyCharacter, new Action<Character>(OnDestroyCharacter));
		}

		private void CheckAddAdviceTriggerCollections()
		{
			if (!_bAdviceTriggerCollectionsAdded && _config._adviceTriggerCollections != null && _config._adviceTriggerCollections.Instance != null)
			{
				_level.Advisor.AddTriggerCollection(_config._adviceTriggerCollections.Instance);
				_bAdviceTriggerCollectionsAdded = true;
			}
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			foreach (Patient alien in _aliens)
			{
				alien.GetComponent<AlienComponent>()?.OnUpdateDaily();
			}
		}

		private void OnDestroyCharacter(Character character)
		{
			_aliens.Remove(character as Patient);
		}

		private void DrawDebugAlienIndicators()
		{
		}
	}
}
