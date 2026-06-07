using System;
using Data.FactoryFloor;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Variables;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.Buildings
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/MonumentBuildingBehaviour", fileName = "MonumentBuildingBehaviour", order = 0)]
	public class MonumentBuildingBehaviour : BuildingBehaviour
	{
		[SerializeField]
		private IntVariableSO _craneUpdateFrequency;

		[SerializeField]
		private int _updateFrequencyForReducingDatashards = 24;

		[SerializeField]
		private int _maxStorageAmount = 60;

		[SerializeField]
		private int _stepsForChargeToBegin;

		[SerializeField]
		private int _endStepsBuffer = 48;

		[SerializeField]
		private int _startStepsBuffer = 12;

		[SerializeField]
		private NonShapeResourceDataSO _dataShardToCharge;

		[SerializeField]
		private BoolVariableSO _monumentCanBeChargedSO;

		[SerializeField]
		private MainThreadBoolVariableSO _monumentIsChargedBoolSO;

		[SerializeField]
		[LocaKey]
		private string _chargeTextLocaKey;

		[SerializeField]
		private Sprite _chargeIcon;

		[SerializeField]
		private Color _color;

		[SerializeField]
		private MonumentBuiltEvent _monumentBuiltEvent;

		private int _currentStepsWithDatashards;

		private int _currentDataShardAmount;

		private int _stepsToRemoveAt0Datashards = 4;

		private bool _monumentActivated;

		private bool _isBuildingStartBuffer;

		private int _startBufferCount;

		public int UpdateFrequencyForReducingDatashards => _updateFrequencyForReducingDatashards;

		public NonShapeResourceDataSO DataShardToCharge => _dataShardToCharge;

		public int MaxStorageAmount => _maxStorageAmount;

		public int CurrentStepsWithDataShards => _currentStepsWithDatashards;

		public int StepsForChargeToBegin => _stepsForChargeToBegin;

		public int CurrentDataShardAmount => _currentDataShardAmount;

		public string ChargeTextLocaKey => _chargeTextLocaKey;

		public bool IsCharged => _monumentIsChargedBoolSO.Value;

		public Sprite ChargeIcon => _chargeIcon;

		public Color ChargeColor => _color;

		public bool CanMonumentBeCharged => _monumentCanBeChargedSO.Value;

		public MainThreadBoolVariableSO ChargeVariable => _monumentIsChargedBoolSO;

		public event Action OnAllShapesReceived = delegate
		{
		};

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_stepsToRemoveAt0Datashards = Mathf.RoundToInt(96f / (float)_updateFrequencyForReducingDatashards);
			MonumentSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<MonumentSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				_monumentActivated = behaviourSaveStateDto.IsActivated;
			}
			MonumentBuildingBehaviourSaveStateDto behaviourSaveStateDto2 = factoryObject.GetBehaviourSaveStateDto<MonumentBuildingBehaviourSaveStateDto>();
			if (behaviourSaveStateDto2 != null)
			{
				SetMonumentSaveState(behaviourSaveStateDto2);
				if (!_monumentActivated)
				{
					CheckIfAllRequirementsMet();
				}
			}
			_monumentBuiltEvent.Register(OnMonumentActivated);
		}

		private void OnMonumentActivated(FactoryObject activatedMonument)
		{
			if (!_monumentActivated && _factoryObject == activatedMonument)
			{
				_monumentActivated = true;
				Upgrade();
			}
		}

		public override void UnInit()
		{
			base.UnInit();
			_monumentIsChargedBoolSO.SetValue(value: false);
			_monumentBuiltEvent.UnRegister(OnMonumentActivated);
		}

		public override void Process(int step)
		{
			base.Process(step);
			if (_buildingCompleted)
			{
				UpdateMonumentCharge();
				RemoveDatashards(step);
			}
		}

		private void RemoveDatashards(int step)
		{
			if (_isBuildingStartBuffer)
			{
				_startBufferCount++;
				if (_startBufferCount < _startStepsBuffer)
				{
					return;
				}
				_isBuildingStartBuffer = false;
			}
			if (step % _updateFrequencyForReducingDatashards == 0 && _currentDataShardAmount > 0)
			{
				_currentDataShardAmount--;
			}
		}

		private void UpdateMonumentCharge()
		{
			if (_currentDataShardAmount > 0)
			{
				_currentStepsWithDatashards++;
			}
			else
			{
				_currentStepsWithDatashards -= _stepsToRemoveAt0Datashards;
			}
			_currentStepsWithDatashards = Mathf.Clamp(_currentStepsWithDatashards, 0, _stepsForChargeToBegin + _endStepsBuffer);
			if (_currentStepsWithDatashards == 0)
			{
				_monumentIsChargedBoolSO.SetValue(value: false);
			}
			if (_currentStepsWithDatashards >= _stepsForChargeToBegin && !_monumentIsChargedBoolSO.Value)
			{
				_monumentIsChargedBoolSO.SetValue(value: true);
			}
		}

		protected override void ReceivedAllModules()
		{
			if (_monumentActivated)
			{
				CreateResources();
			}
			else
			{
				this.OnAllShapesReceived();
			}
		}

		protected override void BuildingCompletedAddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			if (_currentDataShardAmount == 0 && _currentStepsWithDatashards == 0)
			{
				_isBuildingStartBuffer = true;
				_startBufferCount = 0;
			}
			_currentDataShardAmount++;
		}

		protected override bool BuildingCompletedCanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (!_isBuildingActive || !CanMonumentBeCharged)
			{
				return false;
			}
			bool num = resource.Data.ID == _dataShardToCharge.ID;
			bool flag = _currentDataShardAmount < _maxStorageAmount;
			return num && flag;
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new MonumentBuildingBehaviourSaveStateDto
			{
				CurrentDataShardAmount = _currentDataShardAmount,
				CurrentStepsUntilChargeRunsOut = _currentStepsWithDatashards,
				BuildingBehaviourSaveStateDto = (base.GetSaveState() as BuildingBehaviourSaveStateDto)
			};
		}

		private void SetMonumentSaveState(MonumentBuildingBehaviourSaveStateDto saveStateDto)
		{
			_currentDataShardAmount = saveStateDto.CurrentDataShardAmount;
			_currentStepsWithDatashards = saveStateDto.CurrentStepsUntilChargeRunsOut;
			SetSaveState(saveStateDto.BuildingBehaviourSaveStateDto);
		}
	}
}
