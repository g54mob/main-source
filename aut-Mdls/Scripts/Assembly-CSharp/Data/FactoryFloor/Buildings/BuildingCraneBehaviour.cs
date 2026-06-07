using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Variables;
using Logic.Threading.Events;
using UnityEngine;

namespace Data.FactoryFloor.Buildings
{
	public class BuildingCraneBehaviour : ITrackActivity
	{
		public MainThreadEvent<ConveyorBehaviour> OnConveyorFound = new MainThreadEvent<ConveyorBehaviour>();

		public MainThreadEvent OnConveyorRemoved = new MainThreadEvent();

		public MainThreadEvent<Resource, int> OnTakeResource = new MainThreadEvent<Resource, int>();

		private Vector3Int _position;

		private Vector3Int _pickupPosition;

		private readonly FactoryLayer _factoryLayer;

		private readonly BuildingBehaviour _buildingBehaviour;

		private readonly BuildingCranesBehaviour _buildingCranesBehaviour;

		private bool _hasConveyor;

		private ConveyorBehaviour _conveyorBehaviour;

		private readonly IntVariableSO _updateFrequency;

		private int _ticksWaited;

		private int _downTicksWaited;

		public MainThreadEvent OnActivityStart { get; private set; } = new MainThreadEvent();

		public MainThreadEvent OnActivityEnd { get; private set; } = new MainThreadEvent();

		public BuildingCraneBehaviour(Vector3Int pos, Vector3Int pickupPos, FactoryLayer factoryLayer, BuildingBehaviour buildingBehaviour, BuildingCranesBehaviour buildingCranesBehaviour)
		{
			_position = pos;
			_pickupPosition = pickupPos;
			_factoryLayer = factoryLayer;
			_buildingBehaviour = buildingBehaviour;
			_buildingCranesBehaviour = buildingCranesBehaviour;
			_updateFrequency = _buildingCranesBehaviour.VariableUpdateFrequency;
			_ticksWaited = _updateFrequency.Value;
		}

		public void Process(int step)
		{
			GetConveyorBehaviour();
			UpdateCrane();
		}

		private void GetConveyorBehaviour()
		{
			if (_hasConveyor && _conveyorBehaviour == null)
			{
				_hasConveyor = false;
				OnConveyorRemoved.Fire();
			}
			if ((!_hasConveyor || !(_conveyorBehaviour != null)) && _factoryLayer.TryGetObjectAt(_pickupPosition, out var factoryObject))
			{
				if (factoryObject.HasFactoryObjectBehaviour(out ConveyorBehaviour behaviour))
				{
					_conveyorBehaviour = behaviour;
					_hasConveyor = true;
					_conveyorBehaviour.OnUnInit += RemovedConveyor;
					OnConveyorFound.Fire(behaviour);
				}
				else
				{
					_buildingCranesBehaviour.RemoveCrane(_position);
				}
			}
		}

		private void RemovedConveyor(FactoryObjectBehaviour behaviour)
		{
			if (behaviour == _conveyorBehaviour)
			{
				behaviour.OnUnInit -= RemovedConveyor;
				_conveyorBehaviour = null;
				_hasConveyor = false;
				OnConveyorRemoved.Fire();
			}
		}

		private void UpdateCrane()
		{
			if (_ticksWaited >= _updateFrequency.Value)
			{
				PickUpItemFromConveyor();
			}
			_ticksWaited++;
			_downTicksWaited++;
		}

		private void PickUpItemFromConveyor()
		{
			if (CannotOperate())
			{
				TryEndActivity();
				return;
			}
			int value = _updateFrequency.Value;
			OnTakeResource.Fire(_conveyorBehaviour.Resource, value);
			StartActivity();
			_buildingBehaviour.AddResource(_conveyorBehaviour.Resource);
			_conveyorBehaviour.StopTryingToOutput();
			_conveyorBehaviour.RemoveResourceWithoutCallingClearBuffers(_conveyorBehaviour.Resource, returnResource: false);
			_ticksWaited = 0;
			_downTicksWaited = 0;
		}

		private bool CannotOperate()
		{
			if (_hasConveyor && _conveyorBehaviour.HasResource())
			{
				return !_buildingBehaviour.CanReceiveResource(_conveyorBehaviour.Resource);
			}
			return true;
		}

		private void TryEndActivity()
		{
			if (_downTicksWaited > _updateFrequency.Value)
			{
				_downTicksWaited = 0;
				EndActivity();
			}
		}

		public void CallCanReceiveOnConveyor()
		{
			if (_conveyorBehaviour != null && !_conveyorBehaviour.HasResource())
			{
				_conveyorBehaviour.CallCanReceiveNewResourcesOnUpdate();
			}
		}

		public void StartActivity()
		{
			OnActivityStart.Fire();
		}

		public void EndActivity()
		{
			OnActivityEnd.Fire();
		}
	}
}
