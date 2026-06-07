using System;
using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Drones
{
	public abstract class SupplyTankRecipientBehaviour : ResourceHolderBehaviour
	{
		[Header("Supply Tank Recipient")]
		[SerializeField]
		protected bool _needsSupplyTank;

		[SerializeField]
		protected Vector3 _dronePadPosition;

		[SerializeField]
		protected SupplyTankBehaviour _supplyTankBehaviour;

		[SerializeField]
		protected int _operationsPerResource = 1;

		[SerializeField]
		protected ResourceDataSO _neededResourceData;

		private int _currentResourceAmount;

		private bool _hasCapsule;

		private bool _canReceiveCapsule;

		protected OperatorStateBehaviour _operatorStateBehaviour;

		private bool _isShowingNeedsCoolant;

		private SupplyTankDroneBehaviour _droneBehaviour;

		private bool _droneIsFastEnough = true;

		public MainThreadEvent<float> OnCapsuleFillPercChanged = new MainThreadEvent<float>();

		public MainThreadEvent<ResourceDataSO> OnReceiveCapsule = new MainThreadEvent<ResourceDataSO>();

		public MainThreadEvent OnConsumeCapsule = new MainThreadEvent();

		public bool NeedsSupplyTank => _needsSupplyTank;

		public bool HasCapsule => _hasCapsule;

		public int CurrentResourceAmount => _currentResourceAmount;

		public int OperationsPerResource => _operationsPerResource;

		public ResourceDataSO NeededResourceData => _neededResourceData;

		public SupplyTankDroneBehaviour DroneBehaviour => _droneBehaviour;

		public bool DroneIsFastEnough => _droneIsFastEnough;

		public event Action OnCanReceiveNewCapsule = delegate
		{
		};

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_operatorStateBehaviour = factoryObject.GetFactoryObjectBehaviour<OperatorStateBehaviour>();
		}

		public override void UnInit()
		{
			_droneBehaviour = null;
			_currentResourceAmount = 0;
			_hasCapsule = false;
			_droneIsFastEnough = true;
			base.UnInit();
		}

		public sealed override void Update()
		{
			if (!_needsSupplyTank)
			{
				OperatorUpdate();
				return;
			}
			if (!_hasCapsule || _currentResourceAmount <= 0)
			{
				_canReceiveCapsule = true;
				this.OnCanReceiveNewCapsule();
				if (!_hasCapsule)
				{
					_isShowingNeedsCoolant = true;
					_operatorStateBehaviour.SetStateNeedsCoolant();
					_droneIsFastEnough = false;
					EndActivity();
					return;
				}
				if (_droneBehaviour.TotalTimeInProcessTicks < base.UpdateFrequency * _operationsPerResource)
				{
					_droneIsFastEnough = true;
				}
			}
			if (_isShowingNeedsCoolant)
			{
				_operatorStateBehaviour.ResetState();
				_isShowingNeedsCoolant = false;
			}
			OperatorUpdate();
		}

		public virtual void OperatorUpdate()
		{
			if (_needsSupplyTank)
			{
				_currentResourceAmount--;
				float data = (float)_currentResourceAmount / (float)_supplyTankBehaviour.StoragePerCapsule * (float)_operationsPerResource;
				if (_currentResourceAmount <= 0)
				{
					_hasCapsule = false;
					OnConsumeCapsule.Fire();
				}
				OnCapsuleFillPercChanged.Fire(data);
			}
		}

		public bool CanReceiveResources()
		{
			return _canReceiveCapsule;
		}

		public void ReceiveResources(Dictionary<ResourceDataSO, int> resources)
		{
			foreach (KeyValuePair<ResourceDataSO, int> resource in resources)
			{
				_currentResourceAmount = resource.Value * _operationsPerResource;
				_hasCapsule = true;
				_canReceiveCapsule = false;
				OnReceiveCapsule.Fire(resource.Key);
			}
		}

		public Vector3 GetDronePadPosition()
		{
			return base.FactoryObject.DataPosToWorldPos(_dronePadPosition);
		}

		public void SetSaveState(SupplyTankRecipientSaveStateDto saveStateDto)
		{
			_hasCapsule = saveStateDto.HasCapsule;
			_currentResourceAmount = saveStateDto.CurrentResourceAmount;
		}

		public void UpdateDroneBehaviour(SupplyTankDroneBehaviour droneBehaviour)
		{
			_droneBehaviour = droneBehaviour;
		}
	}
}
