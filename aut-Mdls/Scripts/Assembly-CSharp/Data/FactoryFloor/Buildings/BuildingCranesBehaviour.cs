using System;
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.PlacementValidators;
using Data.FeatureFlags.Validators;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Data.Variables.Cranes;
using SaveData.FactoryFloor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data.FactoryFloor.Buildings
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/BuildingCranesBehaviour", fileName = "BuildingCranesBehaviour", order = 0)]
	public class BuildingCranesBehaviour : FactoryObjectBehaviour
	{
		public struct Crane
		{
			public Vector3Int Position;

			public Vector3Int PickupPosition;

			public Vector3Int Direction;

			public BuildingCraneBehaviour Behaviour;
		}

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private CranesLibrarySO _cranesLibrary;

		[SerializeField]
		private CraneMaxAmountPerBuilding _maxAmountOfCranes;

		[SerializeField]
		private CantBePlacedOnTopOfCranes _cantBePlacedOnTopOfCranesValidator;

		[FormerlySerializedAs("_cantOverrideLowObjectsValidator")]
		[SerializeField]
		private CanOverrideLowObjects _canOverrideLowObjectsValidator;

		[SerializeField]
		private List<FactoryObjectPlacementValidator> _cranePlacementValidators = new List<FactoryObjectPlacementValidator>();

		[Header("Feature Flag Validators")]
		[SerializeField]
		private EnableCraneLimitValidator _enableCraneLimitValidator;

		private BuildingBehaviour _buildingBehaviour;

		private Dictionary<Vector3Int, Vector3Int> _possibleCranePositions = new Dictionary<Vector3Int, Vector3Int>();

		private List<Vector3Int> _possibleCranePickupPositions = new List<Vector3Int>();

		private readonly List<Crane> _cranes = new List<Crane>();

		private BuildingCranesBehaviourConfigurationDto _configurationDto;

		public int MaxAmountOfCranes => _maxAmountOfCranes.Value;

		public bool HasReachedCraneLimit => _cranes.Count >= MaxAmountOfCranes;

		public Dictionary<Vector3Int, Vector3Int> PossibleCranePositions => _possibleCranePositions;

		public List<Crane> Cranes => _cranes;

		public EnableCraneLimitValidator EnableCraneLimitValidator => _enableCraneLimitValidator;

		public event Action<Crane> OnCraneAddedEvent = delegate
		{
		};

		public event Action<Crane> OnCraneRemovedEvent = delegate
		{
		};

		public event Action OnCraneEntrancesChangedEvent = delegate
		{
		};

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			CalculatePossibleCranePositions();
			_buildingBehaviour = _factoryObject.GetFactoryObjectBehaviour<BuildingBehaviour>();
			if (_configurationDto == null)
			{
				_configurationDto = factoryObject.GetBehaviourConfigurationDto<BuildingCranesBehaviourConfigurationDto>();
			}
			if (_configurationDto != null)
			{
				InitCranes(_configurationDto);
			}
		}

		public override void UnInit()
		{
			for (int num = Cranes.Count - 1; num >= 0; num--)
			{
				RemoveCrane(Cranes[num]);
			}
			_possibleCranePositions.Clear();
			_buildingBehaviour = null;
			base.UnInit();
		}

		public void ResetForcedPickupPositions()
		{
			_possibleCranePickupPositions.Clear();
		}

		public void CalculatePossibleCranePositions()
		{
			_possibleCranePositions.Clear();
			foreach (Vector3Int occupiedPosition2 in _factoryObject.OccupiedPositions)
			{
				Vector3Int occupiedPosition = occupiedPosition2;
				int amountOfNeighbors = 0;
				Vector3Int dir = new Vector3Int(0, 0, 0);
				CheckNeighbor(new Vector3Int(1, 0, 0));
				CheckNeighbor(new Vector3Int(-1, 0, 0));
				CheckNeighbor(new Vector3Int(0, 0, 1));
				CheckNeighbor(new Vector3Int(0, 0, -1));
				if (amountOfNeighbors == 3)
				{
					_possibleCranePositions.Add(occupiedPosition, dir);
				}
				void CheckNeighbor(Vector3Int offset)
				{
					if (_factoryLayer.TryGetObjectAt(occupiedPosition + offset, out var factoryObject) && factoryObject == _factoryObject)
					{
						amountOfNeighbors++;
						dir -= offset;
					}
				}
			}
			foreach (Crane crane in _cranes)
			{
				_possibleCranePositions.Remove(crane.Position);
			}
			this.OnCraneEntrancesChangedEvent();
		}

		public void ForcePossibleCranePositions(Dictionary<Vector3Int, Vector3Int> forcedPossibleCranePositions)
		{
			_possibleCranePositions = forcedPossibleCranePositions;
			this.OnCraneEntrancesChangedEvent();
		}

		public void ForcePossibleCranePickupPositions(List<Vector3Int> forcedPossibleCranePositions)
		{
			_possibleCranePickupPositions = forcedPossibleCranePositions;
		}

		public bool AddCrane(Vector3Int entrancePos, Vector3Int pickupPos)
		{
			if (!_possibleCranePositions.ContainsKey(entrancePos) || _cranesLibrary.Cranes.ContainsKey(pickupPos) || !IsValidCranePosition(pickupPos, entrancePos) || (_possibleCranePickupPositions.Count > 0 && !_possibleCranePickupPositions.Contains(pickupPos)))
			{
				return false;
			}
			Crane crane = new Crane
			{
				Position = entrancePos,
				PickupPosition = pickupPos,
				Direction = _possibleCranePositions[entrancePos],
				Behaviour = new BuildingCraneBehaviour(entrancePos, pickupPos, _factoryLayer, _buildingBehaviour, this)
			};
			_cranes.Add(crane);
			_possibleCranePositions.Remove(entrancePos);
			_cranesLibrary.AddCrane(this, crane);
			this.OnCraneAddedEvent(crane);
			return true;
		}

		public bool IsValidCranePosition(Vector3Int cranePickupPos, Vector3Int craneEntrancePos)
		{
			if (_possibleCranePickupPositions.Count > 0 && !_possibleCranePickupPositions.Contains(cranePickupPos))
			{
				return false;
			}
			foreach (FactoryObjectPlacementValidator cranePlacementValidator in _cranePlacementValidators)
			{
				if (!cranePlacementValidator.IsValidPosition(null, craneEntrancePos, cranePickupPos, 0, _factoryLayer, _terrainLayer, 0))
				{
					return false;
				}
			}
			Vector3Int vector3Int = cranePickupPos - craneEntrancePos;
			Vector3 normalized = new Vector3(vector3Int.x, 0f, vector3Int.z).normalized;
			Vector3Int vector3Int2 = new Vector3Int((int)normalized.x, 0, (int)normalized.z);
			int num = (int)vector3Int.magnitude;
			for (int i = 1; i < num; i++)
			{
				Vector3Int position = craneEntrancePos + vector3Int2 * i;
				if (i < num - 1 && !_canOverrideLowObjectsValidator.IsValidPosition(null, Vector3Int.zero, position, 0, _factoryLayer, _terrainLayer, 0))
				{
					return false;
				}
				if (!_cantBePlacedOnTopOfCranesValidator.IsValidPosition(null, Vector3Int.zero, position, 0, _factoryLayer, _terrainLayer, 0))
				{
					return false;
				}
			}
			return true;
		}

		private void InitCranes(BuildingCranesBehaviourConfigurationDto configDto)
		{
			for (int i = 0; i < configDto.CraneDatas.Count; i++)
			{
				BuildingCranesBehaviourConfigurationDto.CraneData craneData = configDto.CraneDatas[i];
				if (i + 1 <= _maxAmountOfCranes.Value)
				{
					AddCrane(_factoryObject.DataPosToWorldPos(craneData.RelativeCraneEntrancePos), _factoryObject.DataPosToWorldPos(craneData.RelativeCranePos));
				}
			}
		}

		public bool RemoveCrane(Vector3Int position)
		{
			for (int i = 0; i < _cranes.Count; i++)
			{
				Crane crane = _cranes[i];
				if (crane.Position == position)
				{
					RemoveCrane(crane);
					return true;
				}
			}
			return false;
		}

		private void RemoveCrane(Crane crane)
		{
			_cranesLibrary.RemoveCraneFromLibrary(crane.PickupPosition);
			_possibleCranePositions.TryAdd(crane.Position, crane.Direction);
			_cranes.Remove(crane);
			this.OnCraneRemovedEvent(crane);
		}

		public override void Process(int step)
		{
			base.Process(step);
			for (int num = _cranes.Count - 1; num >= 0; num--)
			{
				_cranes[num].Behaviour.Process(step);
			}
			for (int num2 = _cranes.Count - 1; num2 >= 0; num2--)
			{
				_cranes[num2].Behaviour.CallCanReceiveOnConveyor();
			}
		}

		public override void Update()
		{
		}

		public bool GetClosestAvailableCranePos(Vector3 hoverPos, out Vector3Int cranePos, out Vector3Int craneDir)
		{
			cranePos = Vector3Int.zero;
			craneDir = Vector3Int.zero;
			if (_possibleCranePositions.Count <= 0)
			{
				return false;
			}
			Vector3Int vector3Int = Vector3Int.zero;
			Vector3Int vector3Int2 = Vector3Int.zero;
			float num = float.MaxValue;
			foreach (KeyValuePair<Vector3Int, Vector3Int> possibleCranePosition in _possibleCranePositions)
			{
				float num2 = Vector3.Distance(hoverPos, possibleCranePosition.Key);
				if (num2 < num)
				{
					vector3Int = possibleCranePosition.Key;
					vector3Int2 = possibleCranePosition.Value;
					num = num2;
				}
			}
			cranePos = vector3Int;
			craneDir = vector3Int2;
			return true;
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			_configurationDto = new BuildingCranesBehaviourConfigurationDto(_cranes, _factoryObject);
			return _configurationDto;
		}
	}
}
