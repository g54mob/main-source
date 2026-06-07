#define ENABLE_DEBUG_WARNINGS
#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Maps;
using Data.FactoryFloor.Resources;
using Data.Operator;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor
{
	public class FactoryObject
	{
		public class OutputFactoryObject
		{
			public FactoryObject FactoryObject;

			public FactoryObjectData.InputData InputData;

			public FactoryObjectData.OutputData OutputData;
		}

		private List<FactoryObject> _softLinkedObjects = new List<FactoryObject>();

		private List<FactoryObject> _hardLinkedObjects = new List<FactoryObject>();

		private readonly FactoryLayer _factoryLayer;

		private readonly List<FactoryObjectBehaviour> _behaviours;

		private readonly List<FactoryObjectBehaviour> _updateBehaviours;

		private readonly List<FactoryObjectData.InputData> _dataInputPositions;

		private readonly List<FactoryObjectData.OutputData> _dataOutputPositions;

		private BehaviourSaveStateDto[] _behaviourSaveStateDto;

		private BehaviourConfigurationDto[] _behaviourConfigurationDto;

		private readonly bool _canBeMoved;

		private readonly bool _canBeDuplicated;

		private readonly bool _canBeDeleted;

		private readonly bool _canBeMirrored;

		private readonly FactoryObjectData _factoryObjectData;

		private readonly bool _apartOfMap;

		private IslandObject _islandObject;

		public List<Vector3Int> OccupiedPositions { get; private set; }

		public int ObjectId { get; private set; }

		public int CreatedId { get; private set; }

		public int Rotation { get; private set; }

		public bool Mirrored { get; private set; }

		public bool IsLinked
		{
			get
			{
				if (!IsSoftLinked)
				{
					return IsHardLinked;
				}
				return true;
			}
		}

		public bool IsSoftLinked
		{
			get
			{
				if (_softLinkedObjects != null)
				{
					return _softLinkedObjects.Count != 0;
				}
				return false;
			}
		}

		public bool IsHardLinked
		{
			get
			{
				if (_hardLinkedObjects != null)
				{
					return _hardLinkedObjects.Count != 0;
				}
				return false;
			}
		}

		public Vector3Int[] NeighboringPositions { get; private set; }

		public Vector3Int Position => OccupiedPositions[0];

		public IslandObject IslandObject => _islandObject;

		public FactoryLayer FactoryLayer => _factoryLayer;

		public List<FactoryObject> SoftLinkedObjects => _softLinkedObjects;

		public List<FactoryObject> HardLinkedObjects => _hardLinkedObjects;

		public List<FactoryObjectData.InputData> DataInputPositions => _dataInputPositions;

		public List<FactoryObjectData.OutputData> DataOutputPositions => _dataOutputPositions;

		public int OutputFactoryObjectsCount { get; private set; }

		public List<FactoryObject> InputFactoryObjects { get; private set; } = new List<FactoryObject>();

		public OutputFactoryObject[] OutputFactoryObjects { get; private set; } = Array.Empty<OutputFactoryObject>();

		public FactoryObjectData FactoryObjectData => _factoryObjectData;

		public bool CanBeMirrored => _canBeMirrored;

		public bool CanBeMoved => _canBeMoved;

		public bool CanBeDuplicated => _canBeDuplicated;

		public bool CanBeDeleted => _canBeDeleted;

		public bool NonChangable { get; set; }

		public bool ApartOfMap => _apartOfMap;

		public bool HasUpdateBehaviours => _updateBehaviours.Count > 0;

		public event Action<int> OnRemovingOutput = delegate
		{
		};

		public event Action<FactoryObject> OnObjectLinked = delegate
		{
		};

		public event Action<FactoryObject, FactoryObject> OnObjectUnLinked = delegate
		{
		};

		public event Action OnOutputsUpdated = delegate
		{
		};

		public event Action OnInputsUpdated = delegate
		{
		};

		public List<Vector3Int> GetSoftLinkedObjectsPos()
		{
			List<Vector3Int> list = new List<Vector3Int>();
			if (!IsSoftLinked)
			{
				return list;
			}
			foreach (FactoryObject softLinkedObject in _softLinkedObjects)
			{
				list.Add(softLinkedObject.Position);
			}
			return list;
		}

		public List<Vector3Int> GetHardLinkedObjectsPos()
		{
			List<Vector3Int> list = new List<Vector3Int>();
			if (!IsHardLinked)
			{
				return list;
			}
			foreach (FactoryObject hardLinkedObject in _hardLinkedObjects)
			{
				if (hardLinkedObject == null)
				{
					this.LogError($"Null hardlinked Object in FO on: {Position}", "GetHardLinkedObjectsPos", 70);
				}
				else
				{
					list.Add(hardLinkedObject.Position);
				}
			}
			return list;
		}

		public FactoryObject(List<Vector3Int> occupiedPositions, FactoryObjectData factoryObjectData, int createdId, int rotation, bool mirrored, bool nonChangable, FactoryLayer factoryLayer, BehaviourConfigurationDto[] behaviourConfigurationDto = null, BehaviourSaveStateDto[] behaviourSaveStateDto = null, bool isApartOfMap = false)
		{
			OccupiedPositions = occupiedPositions;
			ObjectId = factoryObjectData.ID;
			_behaviours = CreateBehaviours(factoryObjectData.Behaviours);
			_updateBehaviours = new List<FactoryObjectBehaviour>();
			foreach (FactoryObjectBehaviour behaviour in _behaviours)
			{
				if (behaviour.IsUpdateBehaviour)
				{
					_updateBehaviours.Add(behaviour);
				}
			}
			CreatedId = createdId;
			Rotation = rotation % 360;
			Mirrored = mirrored;
			NonChangable = nonChangable;
			_factoryLayer = factoryLayer;
			_behaviourConfigurationDto = behaviourConfigurationDto;
			_behaviourSaveStateDto = behaviourSaveStateDto;
			_dataInputPositions = factoryObjectData.InputPositionsData;
			_dataOutputPositions = factoryObjectData.OutputPositions;
			NeighboringPositions = GridUtils.GetNeighboringPositions(OccupiedPositions, Position);
			_canBeMoved = factoryObjectData.CanBeMoved;
			_canBeDuplicated = factoryObjectData.CanBeDuplicated;
			_canBeDeleted = factoryObjectData.CanBeDeleted;
			_canBeMirrored = factoryObjectData.CanBeMirrored;
			_factoryObjectData = factoryObjectData;
			_apartOfMap = isApartOfMap;
		}

		public void Move(List<Vector3Int> newPositions, int newRotation, bool isMirrored)
		{
			OccupiedPositions = newPositions;
			Rotation = newRotation % 360;
			Mirrored = isMirrored;
		}

		public void HardLink(FactoryObject factoryObject)
		{
			if (factoryObject == null)
			{
				this.LogWarning("Trying to hardlink a null object to: " + FactoryObjectData.name, "HardLink", 172);
			}
			else if (_hardLinkedObjects == null)
			{
				_hardLinkedObjects = new List<FactoryObject> { factoryObject };
				this.OnObjectLinked(factoryObject);
			}
			else if (!_hardLinkedObjects.Contains(factoryObject))
			{
				_hardLinkedObjects.Add(factoryObject);
				this.OnObjectLinked(factoryObject);
			}
		}

		public void SoftLink(FactoryObject factoryObject)
		{
			if (factoryObject == null)
			{
				this.LogWarning("Trying to softlink a null object", "SoftLink", 192);
			}
			else if (_softLinkedObjects == null)
			{
				_softLinkedObjects = new List<FactoryObject> { factoryObject };
				this.OnObjectLinked(factoryObject);
			}
			else if (!_softLinkedObjects.Contains(factoryObject))
			{
				_softLinkedObjects.Add(factoryObject);
				this.OnObjectLinked(factoryObject);
			}
		}

		public void UnlinkHard(FactoryObject factoryObject)
		{
			this.OnObjectUnLinked(this, factoryObject);
			_hardLinkedObjects.Remove(factoryObject);
		}

		public void UnlinkSoft(FactoryObject factoryObject)
		{
			this.OnObjectUnLinked(this, factoryObject);
			_softLinkedObjects.Remove(factoryObject);
		}

		private void UnlinkAllSoft()
		{
			if (_softLinkedObjects == null)
			{
				return;
			}
			for (int num = _softLinkedObjects.Count - 1; num >= 0; num--)
			{
				if (_softLinkedObjects[num].SoftLinkedObjects.Contains(this))
				{
					_softLinkedObjects[num].UnlinkSoft(this);
				}
				if (num < _softLinkedObjects.Count)
				{
					UnlinkSoft(_softLinkedObjects[num]);
				}
			}
			this.OnObjectUnLinked = delegate
			{
			};
		}

		private List<FactoryObjectBehaviour> CreateBehaviours(List<FactoryObjectBehaviour> dataBehaviours)
		{
			List<FactoryObjectBehaviour> list = new List<FactoryObjectBehaviour>(dataBehaviours.Count);
			foreach (FactoryObjectBehaviour dataBehaviour in dataBehaviours)
			{
				list.Add(UnityEngine.Object.Instantiate(dataBehaviour));
			}
			return list;
		}

		public void Initialize()
		{
			InitInputObjectsList();
			InitOutputObjectsList();
			foreach (FactoryObjectBehaviour behaviour in _behaviours)
			{
				behaviour.Init(this);
			}
		}

		public void UnInitialize()
		{
			UnlinkAllSoft();
			foreach (FactoryObjectBehaviour behaviour in _behaviours)
			{
				behaviour.UnInit();
			}
			foreach (FactoryObject inputFactoryObject in InputFactoryObjects)
			{
				if (inputFactoryObject != null)
				{
					inputFactoryObject.RemoveOutputObject(this);
					inputFactoryObject.UpdateBehaviourOutputs();
				}
			}
			OutputFactoryObject[] outputFactoryObjects = OutputFactoryObjects;
			for (int i = 0; i < outputFactoryObjects.Length; i++)
			{
				outputFactoryObjects[i]?.FactoryObject.RemoveInputObject(this);
			}
			UpdateBehaviourOutputs();
		}

		public void Process(int step)
		{
			foreach (FactoryObjectBehaviour updateBehaviour in _updateBehaviours)
			{
				updateBehaviour.Process(step);
			}
		}

		public bool TryGetFactoryObjectBehaviour<T>(out T behaviour) where T : FactoryObjectBehaviour
		{
			foreach (FactoryObjectBehaviour behaviour2 in _behaviours)
			{
				if (behaviour2 is T val)
				{
					behaviour = val;
					return true;
				}
			}
			behaviour = null;
			return false;
		}

		public T GetFactoryObjectBehaviour<T>() where T : FactoryObjectBehaviour
		{
			return _behaviours.OfType<T>().FirstOrDefault();
		}

		public bool HasFactoryObjectBehaviour<T>(out T behaviour) where T : FactoryObjectBehaviour
		{
			behaviour = _behaviours.OfType<T>().FirstOrDefault();
			return behaviour;
		}

		public bool HasFactoryObjectBehaviour<T>() where T : FactoryObjectBehaviour
		{
			return _behaviours.OfType<T>().FirstOrDefault() != null;
		}

		public List<FactoryObjectBehaviour> GetFactoryObjectBehaviours()
		{
			return _behaviours;
		}

		public bool HasFactoryObjectBehaviour(Type type)
		{
			foreach (FactoryObjectBehaviour behaviour in _behaviours)
			{
				if (behaviour.GetType() == type)
				{
					return true;
				}
			}
			return false;
		}

		public IResourceHolder GetResourceHolderBehaviour()
		{
			return _behaviours.OfType<IResourceHolder>().FirstOrDefault();
		}

		public bool TryGetResourceHolderBehaviour(out IResourceHolder resourceHolder)
		{
			foreach (FactoryObjectBehaviour behaviour in _behaviours)
			{
				if (behaviour is IResourceHolder resourceHolder2)
				{
					resourceHolder = resourceHolder2;
					return true;
				}
			}
			resourceHolder = null;
			return false;
		}

		public Vector3Int DataPosToWorldPos(Vector3Int dataPosition)
		{
			if (Mirrored)
			{
				dataPosition.x = -dataPosition.x;
			}
			return GridUtils.RotatePoint(dataPosition, Rotation) + Position;
		}

		public Vector3 DataPosToWorldPos(Vector3 dataPosition)
		{
			if (Mirrored)
			{
				dataPosition.x = 0f - dataPosition.x;
			}
			return GridUtils.RotatePoint(dataPosition, Rotation) + Position;
		}

		public Vector3Int WorldPosToDataPos(Vector3Int worldPosition)
		{
			Vector3Int point = worldPosition - Position;
			point = GridUtils.RotatePoint(point, -Rotation);
			if (Mirrored)
			{
				point.x = -point.x;
			}
			return point;
		}

		public Vector3Int DataDirToWorldDir(Vector3Int dataDir)
		{
			if (Mirrored)
			{
				dataDir.x = -dataDir.x;
			}
			return GridUtils.RotatePoint(dataDir, Rotation);
		}

		public Vector3Int WorldDirToDataDir(Vector3Int worldDir)
		{
			Vector3Int result = GridUtils.RotatePoint(worldDir, -Rotation);
			if (Mirrored)
			{
				worldDir.x = -worldDir.x;
			}
			return result;
		}

		private void InitInputObjectsList()
		{
			InputFactoryObjects.Clear();
			for (int i = 0; i < _dataInputPositions.Count; i++)
			{
				FactoryObjectData.InputData inputData = _dataInputPositions[i];
				Vector3Int vector3Int = DataPosToWorldPos(inputData.Position);
				Vector3Int[] neighboringPositions = GridUtils.GetNeighboringPositions(vector3Int);
				foreach (Vector3Int position in neighboringPositions)
				{
					FactoryObject objectAt = _factoryLayer.GetObjectAt(position);
					if (objectAt == null)
					{
						continue;
					}
					for (int k = 0; k < objectAt._dataOutputPositions.Count; k++)
					{
						FactoryObjectData.OutputData outputData = objectAt._dataOutputPositions[k];
						Vector3Int vector3Int2 = objectAt.DataPosToWorldPos(outputData.Position);
						if (!(vector3Int != vector3Int2) && (inputData.Direction == Vector3Int.zero || DataDirToWorldDir(inputData.Direction) == objectAt.DataDirToWorldDir(outputData.Direction)))
						{
							AddInputObject(objectAt);
							objectAt.SetOutputObject(k, this, inputData, outputData);
							objectAt.UpdateBehaviourOutputs();
							break;
						}
					}
				}
			}
		}

		private void InitOutputObjectsList()
		{
			OutputFactoryObjectsCount = 0;
			OutputFactoryObjects = new OutputFactoryObject[_dataOutputPositions.Count];
			for (int i = 0; i < _dataOutputPositions.Count; i++)
			{
				FactoryObjectData.OutputData outputData = _dataOutputPositions[i];
				Vector3Int vector3Int = DataPosToWorldPos(outputData.Position);
				FactoryObject objectAt = _factoryLayer.GetObjectAt(vector3Int);
				if (objectAt == null)
				{
					continue;
				}
				for (int j = 0; j < objectAt._dataInputPositions.Count; j++)
				{
					FactoryObjectData.InputData inputData = objectAt._dataInputPositions[j];
					if (vector3Int == objectAt.DataPosToWorldPos(inputData.Position) && (inputData.Direction == Vector3Int.zero || objectAt.DataDirToWorldDir(inputData.Direction) == DataDirToWorldDir(outputData.Direction)))
					{
						SetOutputObject(i, objectAt, inputData, outputData);
						objectAt.AddInputObject(this);
					}
				}
			}
		}

		private void SetOutputObject(int index, FactoryObject factoryObject, FactoryObjectData.InputData inputData, FactoryObjectData.OutputData outputData)
		{
			if (OutputFactoryObjects[index] == null)
			{
				OutputFactoryObjectsCount++;
			}
			OutputFactoryObjects[index] = new OutputFactoryObject
			{
				FactoryObject = factoryObject,
				InputData = inputData,
				OutputData = outputData
			};
			this.OnOutputsUpdated();
		}

		private void AddInputObject(FactoryObject factoryObject)
		{
			InputFactoryObjects.Add(factoryObject);
			this.OnInputsUpdated();
		}

		private void RemoveOutputObject(FactoryObject factoryObject)
		{
			for (int i = 0; i < OutputFactoryObjects.Length; i++)
			{
				if (OutputFactoryObjects[i] != null && OutputFactoryObjects[i].FactoryObject == factoryObject)
				{
					this.OnRemovingOutput(i);
					OutputFactoryObjectsCount--;
					OutputFactoryObjects[i] = null;
					this.OnOutputsUpdated();
					break;
				}
			}
		}

		private void RemoveInputObject(FactoryObject factoryObject)
		{
			InputFactoryObjects.Remove(factoryObject);
			this.OnInputsUpdated();
		}

		private int IndexOfOutputPosition(Vector3Int pos)
		{
			for (int i = 0; i < _dataOutputPositions.Count; i++)
			{
				if (pos == DataPosToWorldPos(_dataOutputPositions[i].Position))
				{
					return i;
				}
			}
			return 0;
		}

		public void UpdateBehaviourOutputs()
		{
			foreach (FactoryObjectBehaviour behaviour in _behaviours)
			{
				if (behaviour is IResourceHolder resourceHolder)
				{
					resourceHolder.UpdateOutput();
				}
			}
		}

		public void DestroyBehaviours()
		{
			foreach (FactoryObjectBehaviour behaviour in _behaviours)
			{
				behaviour.UnInit();
				UnityEngine.Object.Destroy(behaviour);
			}
		}

		public T GetBehaviourConfigurationDto<T>() where T : BehaviourConfigurationDto
		{
			if (_behaviourConfigurationDto == null)
			{
				return null;
			}
			return _behaviourConfigurationDto.OfType<T>().FirstOrDefault();
		}

		public T GetBehaviourSaveStateDto<T>() where T : BehaviourSaveStateDto
		{
			if (_behaviourSaveStateDto == null)
			{
				return null;
			}
			return _behaviourSaveStateDto.OfType<T>().FirstOrDefault();
		}

		public void UpdateSaveState()
		{
			_behaviourSaveStateDto = GetSaveStates().ToArray();
		}

		public void UpdateConfigurations()
		{
			_behaviourConfigurationDto = GetConfigurations().ToArray();
		}

		public List<BehaviourSaveStateDto> GetSaveStates()
		{
			List<BehaviourSaveStateDto> list = new List<BehaviourSaveStateDto>();
			foreach (FactoryObjectBehaviour behaviour in _behaviours)
			{
				BehaviourSaveStateDto saveState = behaviour.GetSaveState();
				if (saveState != null)
				{
					list.Add(saveState);
				}
			}
			return list;
		}

		public List<BehaviourConfigurationDto> GetConfigurations()
		{
			List<BehaviourConfigurationDto> list = new List<BehaviourConfigurationDto>();
			foreach (FactoryObjectBehaviour behaviour in _behaviours)
			{
				BehaviourConfigurationDto configuration = behaviour.GetConfiguration();
				if (configuration != null)
				{
					list.Add(configuration);
				}
			}
			return list;
		}

		public void SetConfigurations(BehaviourConfigurationDto[] behaviourConfigurationDtos)
		{
			_behaviourConfigurationDto = behaviourConfigurationDtos;
		}

		public void SetSaveStates(BehaviourSaveStateDto[] behaviourSaveStateDtosDtos)
		{
			_behaviourSaveStateDto = behaviourSaveStateDtosDtos;
		}

		public void ReSize(List<Vector3Int> newOccupiedPositions)
		{
			OccupiedPositions = newOccupiedPositions;
		}

		public static List<Vector3Int> GetOccupiedPositions(Vector3Int newPosition, List<Vector3Int> occupiedPositions)
		{
			List<Vector3Int> list = new List<Vector3Int>(occupiedPositions.Count);
			foreach (Vector3Int occupiedPosition in occupiedPositions)
			{
				list.Add(occupiedPosition + newPosition);
			}
			return list;
		}

		public void AssignIsland(IslandObject islandObject)
		{
			_islandObject = islandObject;
		}

		public int GetOutputFactoryObjectsCountHardLinked()
		{
			if (!IsHardLinked)
			{
				return OutputFactoryObjectsCount;
			}
			int num = OutputFactoryObjectsCount;
			foreach (FactoryObject hardLinkedObject in _hardLinkedObjects)
			{
				if (hardLinkedObject.IslandObject == IslandObject)
				{
					num++;
				}
			}
			return num;
		}

		public IEnumerable<FactoryObject> GetInputFactoryObjectsHardLinked()
		{
			foreach (FactoryObject inputFactoryObject in InputFactoryObjects)
			{
				yield return inputFactoryObject;
			}
			if (!IsHardLinked)
			{
				yield break;
			}
			foreach (FactoryObject hardLinkedObject in _hardLinkedObjects)
			{
				if (hardLinkedObject.IslandObject != IslandObject)
				{
					continue;
				}
				foreach (FactoryObject inputFactoryObject2 in hardLinkedObject.InputFactoryObjects)
				{
					yield return inputFactoryObject2;
				}
				yield return hardLinkedObject;
			}
		}

		public IEnumerable<OutputFactoryObject> GetOutputFactoryObjectsHardLinked()
		{
			OutputFactoryObject[] outputFactoryObjects = OutputFactoryObjects;
			for (int i = 0; i < outputFactoryObjects.Length; i++)
			{
				yield return outputFactoryObjects[i];
			}
			if (!IsHardLinked)
			{
				yield break;
			}
			foreach (FactoryObject hardLinkedObject in _hardLinkedObjects)
			{
				if (hardLinkedObject.IslandObject == IslandObject)
				{
					outputFactoryObjects = hardLinkedObject.OutputFactoryObjects;
					for (int i = 0; i < outputFactoryObjects.Length; i++)
					{
						yield return outputFactoryObjects[i];
					}
					yield return new OutputFactoryObject
					{
						FactoryObject = hardLinkedObject
					};
				}
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Position: (");
			stringBuilder.Append(Position.x);
			stringBuilder.Append(", ");
			stringBuilder.Append(Position.z);
			stringBuilder.Append(") Rotation: ");
			stringBuilder.Append(Rotation);
			stringBuilder.Append(" Mirror: ");
			stringBuilder.Append(Mirrored);
			stringBuilder.Append("\nOccupiedPositions: [");
			for (int i = 0; i < OccupiedPositions.Count; i++)
			{
				stringBuilder.Append(OccupiedPositions[i]);
				if (i < OccupiedPositions.Count - 2)
				{
					stringBuilder.Append(", ");
				}
			}
			stringBuilder.Append("]\nCreatedId: ");
			stringBuilder.Append(CreatedId);
			stringBuilder.Append(" ObjectId: ");
			stringBuilder.Append(ObjectId);
			stringBuilder.Append(" IslandId: ");
			stringBuilder.Append((_islandObject == null) ? "null" : ((object)_islandObject.CreatedId));
			stringBuilder.Append(" ApartOfMap: ");
			stringBuilder.Append(_apartOfMap);
			stringBuilder.Append("\nHard: ");
			stringBuilder.Append((HardLinkedObjects != null) ? ((object)HardLinkedObjects.Count) : string.Empty);
			stringBuilder.Append(" Soft: ");
			stringBuilder.Append((SoftLinkedObjects != null) ? ((object)SoftLinkedObjects.Count) : string.Empty);
			stringBuilder.Append("\nInputs: ");
			stringBuilder.Append(InputFactoryObjects.Count);
			for (int j = 0; j < InputFactoryObjects.Count; j++)
			{
				stringBuilder.Append("\n" + InputFactoryObjects[j].Position.ToString());
			}
			stringBuilder.Append("\nOutputs: ");
			stringBuilder.Append(OutputFactoryObjectsCount);
			for (int k = 0; k < OutputFactoryObjects.Length; k++)
			{
				if (OutputFactoryObjects[k] != null)
				{
					stringBuilder.Append("\n" + OutputFactoryObjects[k].FactoryObject.Position.ToString());
				}
			}
			stringBuilder.Append("\nMoveable: ");
			stringBuilder.Append(CanBeMoved ? 'y' : 'n');
			stringBuilder.Append(" Duplicateable: ");
			stringBuilder.Append(CanBeDuplicated ? 'y' : 'n');
			stringBuilder.Append(" Deleteable: ");
			stringBuilder.Append(CanBeDeleted ? 'y' : 'n');
			stringBuilder.Append(" Changeable: ");
			stringBuilder.Append(NonChangable ? 'n' : 'y');
			stringBuilder.Append("\nLayer: " + _factoryLayer.name);
			stringBuilder.Append("\n");
			foreach (FactoryObjectBehaviour behaviour in _behaviours)
			{
				stringBuilder.Append(behaviour.ToString());
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}

		public IslandObject GetIsland()
		{
			return _islandObject;
		}
	}
}
