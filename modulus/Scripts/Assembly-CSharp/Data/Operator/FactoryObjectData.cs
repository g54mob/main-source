#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using System.Linq;
using CustomAttributes;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.PlacementValidators;
using Data.FactoryFloor.Resources;
using Logic.Factory.Blueprint;
using NaughtyAttributes;
using Presentation.FactoryFloor;
using UnityEngine;
using Utils;

namespace Data.Operator
{
	[Serializable]
	[CreateAssetMenu(menuName = "Factory/FactoryObjectData", fileName = "FactoryObjectData", order = 0)]
	public class FactoryObjectData : ScriptableObject
	{
		[Serializable]
		public struct InputData
		{
			[CustomAttributes.ReadOnly]
			public int Index;

			public Vector3Int Position;

			public Vector3Int Direction;

			public List<ResourceDataSO> AllowedResourceTypes;
		}

		[Serializable]
		public struct OutputData
		{
			public Vector3Int Position;

			public Vector3Int Direction;
		}

		public bool CanBeMoved = true;

		public bool CanBeDuplicated = true;

		public bool CanBeDeleted = true;

		public bool CanBeMirrored = true;

		public bool CanBeBluePrinted = true;

		public bool ConfigCanBeCopied;

		public bool DrawPlacement;

		[SerializeField]
		private FactoryObjectView _prefab;

		[MinValue(0)]
		[MaxValue(2)]
		public int ObjectSize;

		[field: SerializeField]
		[field: NaughtyAttributes.ReadOnly]
		public int ID { get; private set; } = -1;

		[field: SerializeField]
		public FactoryObjectUIData UIData { get; private set; }

		[field: SerializeField]
		public string AnalyticsName { get; internal set; }

		[field: SerializeField]
		[field: Space]
		public List<Vector3Int> RelativePositions { get; protected set; } = new List<Vector3Int> { Vector3Int.zero };

		[field: SerializeField]
		public List<InputData> InputPositionsData { get; private set; } = new List<InputData>
		{
			new InputData
			{
				Index = 0,
				Position = Vector3Int.zero,
				Direction = Vector3Int.zero,
				AllowedResourceTypes = new List<ResourceDataSO>()
			}
		};

		[field: SerializeField]
		public List<OutputData> OutputPositions { get; private set; } = new List<OutputData>
		{
			new OutputData
			{
				Position = Vector3Int.zero,
				Direction = Vector3Int.zero
			}
		};

		[field: SerializeField]
		[field: Space]
		public List<FactoryObjectBehaviour> Behaviours { get; private set; }

		[field: SerializeField]
		public List<FactoryObjectPlacementValidator> Validators { get; private set; }

		public FactoryObjectView PrefabFactoryObjectView => _prefab;

		public string NameLocKey
		{
			get
			{
				if (!(UIData == null))
				{
					return UIData.NameLocKey;
				}
				return null;
			}
		}

		public string BreadcrumbId => base.name;

		public void SetID(int id)
		{
			if (Application.isPlaying)
			{
				this.DevException("Cannot set id during playmode", "SetID", 96);
			}
			else
			{
				ID = id;
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public virtual void UpdateRelativePositions()
		{
			if (PrefabFactoryObjectView != null)
			{
				RelativePositions = PrefabFactoryObjectView.RelativePositions;
			}
		}

		public void UpdateIndex()
		{
			for (int i = 0; i < InputPositionsData.Count; i++)
			{
				InputData value = InputPositionsData[i];
				value.Index = i;
				InputPositionsData[i] = value;
			}
		}

		protected virtual void OnValidate()
		{
			UpdateIndex();
		}

		protected virtual void Reset()
		{
			AnalyticsName = base.name;
		}

		public Vector3Int GetRelativeBounds()
		{
			Vector3Int vector3Int = new Vector3Int(int.MaxValue, 0, int.MaxValue);
			Vector3Int vector3Int2 = new Vector3Int(int.MinValue, 0, int.MinValue);
			foreach (Vector3Int relativePosition in RelativePositions)
			{
				if (relativePosition.x < vector3Int.x)
				{
					vector3Int.x = relativePosition.x;
				}
				if (relativePosition.z < vector3Int.z)
				{
					vector3Int.z = relativePosition.z;
				}
				if (relativePosition.x > vector3Int2.x)
				{
					vector3Int2.x = relativePosition.x;
				}
				if (relativePosition.z > vector3Int2.z)
				{
					vector3Int2.z = relativePosition.z;
				}
			}
			vector3Int2 += Vector3Int.one;
			return vector3Int2 - vector3Int;
		}

		public Vector3Int DataPosToWorldPos(Vector3Int dataPos, Vector3Int objectPos, int rotation, bool mirrored)
		{
			if (mirrored)
			{
				dataPos.x = -dataPos.x;
			}
			return GridUtils.RotatePoint(dataPos, rotation) + objectPos;
		}

		public bool IsValidPosition(Vector3Int position, int rotation, Vector3Int blueprintPosition, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement blueprintElement = null)
		{
			foreach (FactoryObjectPlacementValidator validator in Validators)
			{
				if (!validator.IsValidPosition(this, blueprintPosition, position, rotation, placementLayer, terrainLayer, createdId, blueprint, isBeingMoved, blueprintElement))
				{
					return false;
				}
			}
			return true;
		}

		public T GetFactoryObjectBehaviour<T>() where T : FactoryObjectBehaviour
		{
			return Behaviours.OfType<T>().FirstOrDefault();
		}

		public bool ContainsFactoryObjectBehaviour<T>() where T : FactoryObjectBehaviour
		{
			return Behaviours.FindIndex((FactoryObjectBehaviour a) => a.GetType().Is<T>()) != -1;
		}

		public static FactoryObjectData Create(FactoryObjectView prefab, List<FactoryObjectBehaviour> behaviourList, List<FactoryObjectPlacementValidator> validatorList)
		{
			FactoryObjectData factoryObjectData = ScriptableObject.CreateInstance<FactoryObjectData>();
			factoryObjectData.Behaviours = new List<FactoryObjectBehaviour>(behaviourList);
			factoryObjectData.Validators = new List<FactoryObjectPlacementValidator>(validatorList);
			return factoryObjectData;
		}

		public void SetPrefab(GameObject go)
		{
			_prefab = go.GetComponent<FactoryObjectView>();
			SetDirty();
		}
	}
}
