using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Logic.Factory;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates.Drones;
using UnityEngine;

namespace Data.FactoryFloor.Drones
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/SupplyTankDroneBehaviour", fileName = "SupplyTankDroneBehaviour", order = 0)]
	public class SupplyTankDroneBehaviour : AbstractDroneBehaviour
	{
		public enum SupplyTankDroneState
		{
			Spawning = 0,
			MovingToRecipient = 1,
			MovingToSupplyTank = 2,
			WaitingForPickUpResources = 3,
			PickUpResources = 4,
			WaitingToDropResources = 5,
			DroppingResources = 6
		}

		public int StepsToSpawn = 24;

		public int StepsToTransferItems = 24;

		private int _droneID;

		private SupplyTankBehaviour _supplyTankBehaviour;

		private SupplyTankRecipientBehaviour _supplyTankRecipientBehaviour;

		private SupplyTankDroneState _state;

		private int _stepsElapsed;

		private bool _isSubscribedToTryDropResources;

		private int _totalTimeInProcessTicks;

		private float _totalTimeInSeconds;

		public MainThreadEvent<SupplyTankDroneState> OnChangeState = new MainThreadEvent<SupplyTankDroneState>();

		public MainThreadEvent<IReadOnlyDictionary<ResourceDataSO, int>> OnResourcesAdded = new MainThreadEvent<IReadOnlyDictionary<ResourceDataSO, int>>();

		public int DroneID => _droneID;

		public float TotalTimeInSeconds => _totalTimeInSeconds;

		public int TotalTimeInProcessTicks => _totalTimeInProcessTicks;

		public void Init(SupplyTankBehaviour supplyTankBehaviour, SupplyTankRecipientBehaviour recipientBehaviour, Vector3 startPos, Vector3 endPos, int droneID)
		{
			Init(startPos, endPos, endPos);
			_supplyTankBehaviour = supplyTankBehaviour;
			_supplyTankRecipientBehaviour = recipientBehaviour;
			_droneID = droneID;
			SetDroneState(SupplyTankDroneState.Spawning);
			_position = startPos;
			CalculateTotalFlyTimeOfDrone();
		}

		protected override void OnMaxVelocityChanged(float _)
		{
			base.OnMaxVelocityChanged(_);
			CalculateTotalFlyTimeOfDrone();
		}

		private void CalculateTotalFlyTimeOfDrone()
		{
			int num = Mathf.CeilToInt(_totalTime);
			_totalTimeInProcessTicks = num + num + StepsToTransferItems + StepsToTransferItems;
			_totalTimeInSeconds = FactoryUpdater.Instance.GetProcessTicksToRealTime(_totalTimeInProcessTicks);
		}

		public void CalculateTotalFlyTimeOfADrone(Vector3 pickUpPos, Vector3 dropOffPos, out int totalTimeInProcessTicks, out float totalTimeInSeconds)
		{
			int num = Mathf.CeilToInt(CalculateTotalFlyTimeBetweenStartAndEnd(pickUpPos, dropOffPos));
			totalTimeInProcessTicks = num + num + StepsToTransferItems + StepsToTransferItems;
			totalTimeInSeconds = FactoryUpdater.Instance.GetProcessTicksToRealTime(totalTimeInProcessTicks);
		}

		public override void DestroyDrone()
		{
			base.DestroyDrone();
			_supplyTankRecipientBehaviour.OnCanReceiveNewCapsule -= TryDropResources;
			_isSubscribedToTryDropResources = false;
		}

		private void SetDroneState(SupplyTankDroneState state)
		{
			_state = state;
			_stepsElapsed = 0;
			OnChangeState.Fire(state);
		}

		public override void Update()
		{
			switch (_state)
			{
			case SupplyTankDroneState.Spawning:
				Spawning();
				break;
			case SupplyTankDroneState.MovingToRecipient:
				MoveToRecipient();
				break;
			case SupplyTankDroneState.MovingToSupplyTank:
				MoveToSupplyTank();
				break;
			case SupplyTankDroneState.WaitingForPickUpResources:
				WaitingForPickUpResources();
				break;
			case SupplyTankDroneState.PickUpResources:
				PickUpResources();
				break;
			case SupplyTankDroneState.WaitingToDropResources:
				WaitingToDropResources();
				break;
			case SupplyTankDroneState.DroppingResources:
				DropResources();
				break;
			}
			_stepsElapsed++;
		}

		private void Spawning()
		{
			if (_stepsElapsed >= StepsToSpawn)
			{
				UpdatePath(_startPos, _endPos);
				SetDroneState(SupplyTankDroneState.WaitingForPickUpResources);
			}
		}

		private void MoveToRecipient()
		{
			if (MoveDroneOnPath())
			{
				SetDroneState(SupplyTankDroneState.WaitingToDropResources);
			}
		}

		private void MoveToSupplyTank()
		{
			if (MoveDroneOnPath())
			{
				SetDroneState(SupplyTankDroneState.WaitingForPickUpResources);
			}
		}

		private void WaitingForPickUpResources()
		{
			if (!_supplyTankBehaviour.HasFilledCapsule(_droneID))
			{
				_stepsElapsed = 0;
			}
			if (_stepsElapsed > StepsToTransferItems / 2)
			{
				var (key, value) = _supplyTankBehaviour.TakeCapsule(_droneID);
				_resources.Add(key, value);
				OnResourcesAdded.Fire(_resources);
				SetDroneState(SupplyTankDroneState.PickUpResources);
			}
		}

		private void PickUpResources()
		{
			if (_stepsElapsed >= StepsToTransferItems / 2)
			{
				UpdatePath(_startPos, _endPos);
				SetDroneState(SupplyTankDroneState.MovingToRecipient);
			}
		}

		private void WaitingToDropResources()
		{
			if (_stepsElapsed >= StepsToTransferItems / 2)
			{
				if (_supplyTankRecipientBehaviour.CanReceiveResources())
				{
					_supplyTankRecipientBehaviour.ReceiveResources(new Dictionary<ResourceDataSO, int>(_resources));
					_resources.Clear();
					SetDroneState(SupplyTankDroneState.DroppingResources);
				}
				else if (!_isSubscribedToTryDropResources)
				{
					_isSubscribedToTryDropResources = true;
					_supplyTankRecipientBehaviour.OnCanReceiveNewCapsule += TryDropResources;
				}
			}
		}

		private void TryDropResources()
		{
			if (_supplyTankRecipientBehaviour.CanReceiveResources())
			{
				_supplyTankRecipientBehaviour.OnCanReceiveNewCapsule -= TryDropResources;
				_isSubscribedToTryDropResources = false;
				_supplyTankRecipientBehaviour.ReceiveResources(new Dictionary<ResourceDataSO, int>(_resources));
				_resources.Clear();
				SetDroneState(SupplyTankDroneState.DroppingResources);
			}
		}

		private void DropResources()
		{
			_supplyTankRecipientBehaviour.OnCanReceiveNewCapsule -= TryDropResources;
			_isSubscribedToTryDropResources = false;
			if (_stepsElapsed >= StepsToTransferItems / 2)
			{
				UpdatePath(_endPos, _startPos);
				SetDroneState(SupplyTankDroneState.MovingToSupplyTank);
			}
		}

		public SupplyTankDroneState GetState()
		{
			return _state;
		}

		public SupplyTankDroneSaveStateDto GetSaveState()
		{
			return new SupplyTankDroneSaveStateDto
			{
				DroneState = _state,
				StepsElapsed = _stepsElapsed,
				BaseDroneSaveStateDto = GetBaseDroneSaveState()
			};
		}

		public void ApplySaveState(SupplyTankDroneSaveStateDto saveStateDto)
		{
			_state = saveStateDto.DroneState;
			_stepsElapsed = saveStateDto.StepsElapsed;
			switch (_state)
			{
			case SupplyTankDroneState.Spawning:
				UpdatePath(_startPos, _startPos);
				break;
			case SupplyTankDroneState.MovingToRecipient:
				UpdatePath(_startPos, _endPos);
				break;
			case SupplyTankDroneState.MovingToSupplyTank:
				UpdatePath(_endPos, _startPos);
				break;
			case SupplyTankDroneState.WaitingForPickUpResources:
				UpdatePath(_startPos, _startPos);
				break;
			case SupplyTankDroneState.PickUpResources:
				UpdatePath(_startPos, _startPos);
				break;
			case SupplyTankDroneState.WaitingToDropResources:
				UpdatePath(_endPos, _endPos);
				break;
			case SupplyTankDroneState.DroppingResources:
				UpdatePath(_endPos, _endPos);
				break;
			}
			ApplyBaseDroneSaveState(saveStateDto.BaseDroneSaveStateDto);
			OnChangeState.Fire(_state);
		}
	}
}
