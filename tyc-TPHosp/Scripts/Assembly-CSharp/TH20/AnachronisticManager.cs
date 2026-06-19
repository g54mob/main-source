using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class AnachronisticManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class IllnessEraDefinition
		{
			public IllnessEraType _eraType;

			public float _switchTime;

			[InspectorHeader("Non Patient Visuals")]
			public SharedInstance<PatientDefinition> _anachronisticPatientDefinition;

			[InspectorHeader("Illness era groups")]
			public SharedInstance<IllnessDefinition>[] _illnesses;

			[InspectorHeader("Era patient name overrides")]
			public CharacterNameGenerator _characterNameGenerator;
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class EraConfig
		{
			[InspectorMargin(8)]
			public IllnessEraType _eraType;

			public bool _hasTimeTunnel = true;

			public IllnessEraDefinition[] _illnessEraDefinitions;

			public bool ArePatientsRequired()
			{
				int num = _illnessEraDefinitions.Length;
				for (int i = 0; i < num; i++)
				{
					if (_illnessEraDefinitions[i]._illnesses.Length != 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		private class SpawnPatientOnArrival : IArrivedCallback
		{
			private readonly AnachronisticManager _anachronisticManager;

			private readonly CharacterManager _characterManager;

			private readonly IllnessDefinition _illnessDefinition;

			private readonly IPatientSpawned _onSpawned;

			public SpawnPatientOnArrival(AnachronisticManager anachronisticManager, CharacterManager characterManager, IllnessDefinition illnessDefinition, IPatientSpawned onSpawned)
			{
				_anachronisticManager = anachronisticManager;
				_characterManager = characterManager;
				_illnessDefinition = illnessDefinition;
				_onSpawned = onSpawned;
			}

			public Character OnArrived(Vector3 position)
			{
				IllnessEraDefinition illnessEraDefinition = null;
				IllnessEraDefinition[] illnessEraDefinitions = _anachronisticManager.Config._illnessEraDefinitions;
				foreach (IllnessEraDefinition illnessEraDefinition2 in illnessEraDefinitions)
				{
					if (Array.Exists(illnessEraDefinition2._illnesses, (SharedInstance<IllnessDefinition> illness) => illness.Instance == _illnessDefinition))
					{
						illnessEraDefinition = illnessEraDefinition2;
						break;
					}
				}
				PatientDefinition instance = illnessEraDefinition._anachronisticPatientDefinition.Instance;
				Patient patient = _characterManager.CreatePatient(_illnessDefinition, position, instance);
				_anachronisticManager.OnArrival(patient);
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

		private EraConfig _config;

		private readonly Level _level;

		private readonly CharacterManager _characterManager;

		private List<Patient> _patients;

		public EraConfig Config
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

		public List<Patient> Patients => _patients;

		public int NumPatients => _patients.Count;

		public AnachronisticManager(EraConfig config, Level level, CharacterManager characterManager)
		{
			_config = config;
			_level = level;
			_characterManager = characterManager;
			_patients = new List<Patient>();
			RegisterEvents();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_patients == null)
			{
				_patients = new List<Patient>();
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
			_patients.Clear();
		}

		public void Update()
		{
		}

		public void DebugGUI()
		{
		}

		public static bool IsAnachronisticPatient(Patient patient)
		{
			if (patient != null)
			{
				return patient.GetComponent<AnachronisticTreatmentComponent>() != null;
			}
			return false;
		}

		private bool Add(Patient patient)
		{
			IllnessEraDefinition[] illnessEraDefinitions = _config._illnessEraDefinitions;
			foreach (IllnessEraDefinition illnessEraDefinition in illnessEraDefinitions)
			{
				if (Array.Exists(illnessEraDefinition._illnesses, (SharedInstance<IllnessDefinition> illness) => illness.Instance == patient.Illness))
				{
					_patients.Add(patient);
					patient.GetComponent<AnachronisticTreatmentComponent>()?.Setup(illnessEraDefinition._eraType);
					return true;
				}
			}
			return false;
		}

		private void Remove(Patient patient)
		{
			if (IsAnachronisticPatient(patient))
			{
				if (patient.RoomUsing != null && patient.RoomUsing.Definition._type == RoomDefinition.Type.TimeTunnel)
				{
					patient.RoomUsing.OnUnitProcessed();
				}
				_patients.Remove(patient);
			}
		}

		public void CheckRemove(Patient patient)
		{
			if (IsAnachronisticPatient(patient))
			{
				Remove(patient);
			}
		}

		public IArrivedCallback CheckCreatePatientArrivedCallback(IllnessDefinition illnessDefinition, IPatientSpawned onSpawned)
		{
			IArrivedCallback result = null;
			if (IsIllnessAllowedForPatient(illnessDefinition))
			{
				result = CreatePatientArrivedCallback(illnessDefinition, onSpawned);
			}
			return result;
		}

		public bool IsIllnessAllowedForPatient(IllnessDefinition illnessDefinition)
		{
			if (_config != null && _config._illnessEraDefinitions != null)
			{
				IllnessEraDefinition[] illnessEraDefinitions = _config._illnessEraDefinitions;
				foreach (IllnessEraDefinition illnessEraDefinition in illnessEraDefinitions)
				{
					if (illnessEraDefinition._eraType == _config._eraType)
					{
						continue;
					}
					SharedInstance<IllnessDefinition>[] illnesses = illnessEraDefinition._illnesses;
					for (int j = 0; j < illnesses.Length; j++)
					{
						if (illnesses[j].Instance == illnessDefinition)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public CharacterName GeneratePatientName(IllnessDefinition illnessDefinition, Character.Sex sex)
		{
			if (_config != null && _config._illnessEraDefinitions != null)
			{
				IllnessEraDefinition[] illnessEraDefinitions = _config._illnessEraDefinitions;
				foreach (IllnessEraDefinition illnessEraDefinition in illnessEraDefinitions)
				{
					if (illnessEraDefinition._eraType != _config._eraType)
					{
						continue;
					}
					SharedInstance<IllnessDefinition>[] illnesses = illnessEraDefinition._illnesses;
					for (int j = 0; j < illnesses.Length; j++)
					{
						if (illnesses[j].Instance == illnessDefinition)
						{
							CharacterNameGenerator characterNameGenerator = illnessEraDefinition._characterNameGenerator;
							if (characterNameGenerator != null)
							{
								return characterNameGenerator.Generate(sex);
							}
						}
					}
				}
			}
			return CharacterName.Empty;
		}

		public float GetEraSwitchTime(IllnessEraType eraType)
		{
			if (_config != null && _config._illnessEraDefinitions != null)
			{
				IllnessEraDefinition[] illnessEraDefinitions = _config._illnessEraDefinitions;
				foreach (IllnessEraDefinition illnessEraDefinition in illnessEraDefinitions)
				{
					if (illnessEraDefinition._eraType == eraType)
					{
						return illnessEraDefinition._switchTime;
					}
				}
			}
			return 0f;
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnDestroyCharacter = (Action<Character>)Delegate.Combine(characterEvents.OnDestroyCharacter, new Action<Character>(OnDestroyCharacter));
		}

		private void UnRegisterEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnDestroyCharacter = (Action<Character>)Delegate.Remove(characterEvents.OnDestroyCharacter, new Action<Character>(OnDestroyCharacter));
		}

		private void OnDestroyCharacter(Character character)
		{
			Remove(character as Patient);
		}

		public IArrivedCallback CreatePatientArrivedCallback(IllnessDefinition illnessDefinition, IPatientSpawned onSpawned)
		{
			return new SpawnPatientOnArrival(this, _characterManager, illnessDefinition, onSpawned);
		}

		public void OnArrival(Patient patient)
		{
			Add(patient);
		}

		public bool ArePatientsRequired()
		{
			return _config.ArePatientsRequired();
		}
	}
}
