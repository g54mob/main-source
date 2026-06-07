#define ENABLE_DEBUG_ERRORS
using Data.FactoryFloor.Drones;
using Data.FactoryFloor.Drones.Freighter.SaveStateDtos;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates.Drones;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.Freighter
{
	[CreateAssetMenu(fileName = "FreighterMovementBehaviour", menuName = "Factory/FactoryBehaviour/Freighter/MovementBehaviour")]
	public class FreighterMovementBehaviour : AbstractDroneBehaviour, IFreighterObjectStateBehaviour
	{
		[SerializeField]
		private Vector3 _freighterDockOffset;

		[SerializeField]
		private Vector3 _worldPosOffset;

		[SerializeField]
		private float _occupyFreightHubDistance = 5f;

		[SerializeField]
		private float _queueOffset = 5f;

		[SerializeField]
		private ReferenceObjectDatabase _referenceObjectDatabase;

		public MainThreadEvent<Vector3, Vector3> MoveToTargetEvent = new MainThreadEvent<Vector3, Vector3>();

		private FreighterObject _freighterObject;

		private bool _hasReachedTarget;

		private new FreighterPathBehaviour _path;

		private bool _inFreightHubQueue;

		private bool _reachedQueuePosition;

		private bool _swappedPath;

		private Vector3 _swappedPathEndPos;

		private int _queueIndex = -1;

		public int PathEndReferenceID { get; private set; }

		public void Initialize(FreighterObject freighterObject, FreighterPathBehaviour freighterPathBehaviour)
		{
			_freighterObject = freighterObject;
			_path = freighterPathBehaviour;
			_path.OnFreighterCreatedEvent += FreighterCreated;
		}

		public void Dispose()
		{
			_path.OnFreighterCreatedEvent -= FreighterCreated;
			RemoveFromAllFreightHubQueues();
		}

		public void RemoveFromAllFreightHubQueues()
		{
			for (int i = 0; i < _path.Stops.Count; i++)
			{
				if (_referenceObjectDatabase.TryGetObjectFromReferenceID(_path.Stops[i].freightHubReferenceId, out var referenceObject) && referenceObject.FactoryObject.TryGetFactoryObjectBehaviour<FreightHubBehaviour>(out var behaviour))
				{
					behaviour.StopOccupying(_freighterObject);
					behaviour.RemoveFromQueue(_freighterObject);
				}
			}
		}

		private void FreighterCreated()
		{
			_position = GetDockPositionFromFreightHub(_path.GetFactoryObjectAtStopIndex(0)) + Vector3.up * 10f;
		}

		private Vector3 GetDockPositionFromFreightHub(FactoryObject factoryObject)
		{
			return factoryObject.DataPosToWorldPos(_freighterDockOffset) + _worldPosOffset;
		}

		void IFreighterObjectStateBehaviour.Enter()
		{
			_hasReachedTarget = false;
			_inFreightHubQueue = false;
			_reachedQueuePosition = false;
			if (!_path.HasStops())
			{
				_path.CreateOrDestroyFreighterDependingOnStops();
				return;
			}
			FactoryObject nextFactoryObject = _path.GetNextFactoryObject();
			Vector3 position = _position;
			Vector3 dockPositionFromFreightHub = GetDockPositionFromFreightHub(nextFactoryObject);
			PathEndReferenceID = _path.NextStop.freightHubReferenceId;
			Init(position, dockPositionFromFreightHub, dockPositionFromFreightHub);
			UpdatePath(position, dockPositionFromFreightHub);
			MoveToTargetEvent.Fire(position, dockPositionFromFreightHub);
		}

		void IFreighterObjectStateBehaviour.Exit()
		{
			_hasReachedTarget = true;
		}

		bool IFreighterObjectStateBehaviour.Tick()
		{
			if (_swappedPath)
			{
				SlowDown();
				return false;
			}
			if (!_inFreightHubQueue)
			{
				UpdateFreightHubOccupiedStatus();
			}
			if (_inFreightHubQueue && _reachedQueuePosition)
			{
				return false;
			}
			bool num = MoveDroneOnPath();
			_currentSpeed01 = Mathf.Clamp01(_currentVelocity.magnitude / _droneMaxVelocityData.DefaultValue);
			if (num)
			{
				return !_inFreightHubQueue;
			}
			return false;
		}

		protected override bool MoveDroneOnPath()
		{
			bool flag = base.MoveDroneOnPath();
			if (_inFreightHubQueue && flag)
			{
				_reachedQueuePosition = true;
			}
			return flag;
		}

		private void SlowDown()
		{
			float magnitude = _currentVelocity.magnitude;
			float num = _droneMaxVelocityData.Value / _droneMaxVelocityData.DefaultValue * _deceleration;
			if (magnitude > num)
			{
				_currentVelocity = _currentVelocity.normalized * Mathf.Max(0f, magnitude - num);
				_position -= _currentVelocity;
				return;
			}
			_swappedPath = false;
			Vector3 position = _position;
			Init(position, _swappedPathEndPos, _swappedPathEndPos);
			UpdatePath(position, _swappedPathEndPos);
		}

		public override Vector3 GetNextProcessPosition()
		{
			if (_swappedPath)
			{
				return _position - _currentVelocity;
			}
			return base.GetNextProcessPosition();
		}

		public void RemoveFromQueue()
		{
			SetPathToFreightHub();
			_inFreightHubQueue = false;
			_reachedQueuePosition = false;
		}

		public void MoveDownInQueue()
		{
			_queueIndex--;
			if (_queueIndex < 1)
			{
				RemoveFromQueue();
			}
			else
			{
				SetPathToQueuePosition();
			}
		}

		private void SetPathToFreightHub()
		{
			if (_path.TryGetNextFactoryObject(out var factoryObject))
			{
				Vector3 dockPositionFromFreightHub = GetDockPositionFromFreightHub(factoryObject);
				_swappedPathEndPos = dockPositionFromFreightHub;
				_swappedPath = true;
			}
		}

		private void SetPathToQueuePosition()
		{
			if (_path.TryGetNextFactoryObject(out var factoryObject))
			{
				Vector3 swappedPathEndPos = GetDockPositionFromFreightHub(factoryObject) + Vector3.up * (_queueOffset * (float)_queueIndex);
				_swappedPathEndPos = swappedPathEndPos;
				_swappedPath = true;
				_reachedQueuePosition = false;
			}
		}

		public override void Update()
		{
		}

		private void UpdateFreightHubOccupiedStatus()
		{
			if (_path == null || _freighterObject == null)
			{
				this.LogError($"Path {_path} and FreighterObject {_freighterObject} should never be null", "UpdateFreightHubOccupiedStatus", 197);
			}
			else
			{
				if (!(GetDistanceToEndPos() < _occupyFreightHubDistance))
				{
					return;
				}
				FactoryObject nextFactoryObject = _path.GetNextFactoryObject();
				if (nextFactoryObject == null)
				{
					return;
				}
				FreightHubBehaviour factoryObjectBehaviour = nextFactoryObject.GetFactoryObjectBehaviour<FreightHubBehaviour>();
				if (factoryObjectBehaviour == null)
				{
					return;
				}
				if (!factoryObjectBehaviour.IsOccupied)
				{
					factoryObjectBehaviour.StartOccupying(_freighterObject);
				}
				if (factoryObjectBehaviour.IsOccupied)
				{
					bool inFreightHubQueue = _inFreightHubQueue;
					bool flag = factoryObjectBehaviour.OccupyingFreighterId != _freighterObject.CreatedId;
					if (inFreightHubQueue != flag)
					{
						_inFreightHubQueue = flag;
						_reachedQueuePosition = false;
					}
					if (flag)
					{
						_queueIndex = factoryObjectBehaviour.QueueFreighter(_freighterObject.CreatedId);
						SetPathToQueuePosition();
					}
				}
			}
		}

		private float GetDistanceFromStartPos()
		{
			return Vector3.Distance(_path.GetCurrentFactoryObject().Position, _position);
		}

		private float GetDistanceToEndPos()
		{
			return Vector3.Distance(_path.GetNextFactoryObject().Position, _position);
		}

		public FreighterMovementBehaviourSaveStateDto GetSaveState()
		{
			BaseDroneSaveStateDto baseDroneSaveState = GetBaseDroneSaveState();
			baseDroneSaveState.CurrentTime = ((!_hasReachedTarget) ? baseDroneSaveState.CurrentTime : 0);
			return new FreighterMovementBehaviourSaveStateDto
			{
				Position = _position,
				DroneSaveStateDto = baseDroneSaveState
			};
		}

		public void ApplySaveState(FreighterMovementBehaviourSaveStateDto saveStateDto)
		{
			if (saveStateDto != null)
			{
				_position = saveStateDto.Position;
				if (_path.HasStops())
				{
					FactoryObject nextFactoryObject = _path.GetNextFactoryObject();
					Vector3 position = saveStateDto.Position;
					Vector3 dockPositionFromFreightHub = GetDockPositionFromFreightHub(nextFactoryObject);
					Init(position, dockPositionFromFreightHub, dockPositionFromFreightHub);
					UpdatePath(position, dockPositionFromFreightHub);
					ApplyBaseDroneSaveState(saveStateDto.DroneSaveStateDto);
				}
			}
		}
	}
}
