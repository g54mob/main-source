using System.Collections.Generic;
using System.Linq;
using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.Progression
{
	public class ProgressionMonumentsManager : MonoBehaviour
	{
		public enum MonumentState
		{
			None = 0,
			Placed = 1,
			Built = 2
		}

		public class Monument
		{
			public BuildingObjectData BuildingObjectData;

			public MonumentState State;
		}

		[SerializeField]
		private ProgressionManagerLocator _progressionManagerLocator;

		[SerializeField]
		private ProgressionPersistentSO _progressionPersistentSO;

		[SerializeField]
		private BuildingObjectDatabase _buildingObjectDatabase;

		[Header("Events")]
		[SerializeField]
		private CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private FactoryObjectDeletedEvent _factoryObjectDeletedEvent;

		[SerializeField]
		private MonumentBuiltEvent _monumentBuiltEvent;

		[SerializeField]
		private ProgressionMonumentEvent _progressionMonumentStateChangedEvent;

		private readonly List<Monument> _monumentInfos = new List<Monument>();

		public IReadOnlyList<Monument> MonumentInfos => _monumentInfos;

		public int BuiltMonumentCount => _monumentInfos.Count((Monument m) => m.State == MonumentState.Built);

		private void Awake()
		{
			_progressionManagerLocator.ProgressionMonuments = this;
			_createFactoryObjectEvent.Register(OnFactoryObjectCreated);
			_factoryObjectDeletedEvent.Register(OnFactoryObjectDeleted);
			_monumentBuiltEvent.Register(OnMonumentBuiltEvent);
		}

		private void OnDestroy()
		{
			_createFactoryObjectEvent.UnRegister(OnFactoryObjectCreated);
			_factoryObjectDeletedEvent.UnRegister(OnFactoryObjectDeleted);
			_monumentBuiltEvent.UnRegister(OnMonumentBuiltEvent);
		}

		private void Start()
		{
			Reset();
			if (_progressionPersistentSO.TryGetSaveData(out var progressionSaveData))
			{
				ApplySaveData(progressionSaveData);
			}
		}

		private void OnFactoryObjectCreated(CreateFactoryObjectDto dto)
		{
			if (!dto.IsGameLoading && dto.FactoryObject.FactoryObjectData is BuildingObjectData buildingObjectData && buildingObjectData.ContainsFactoryObjectBehaviour<MonumentBehaviour>() && GetMonumentState(buildingObjectData) == MonumentState.None)
			{
				SetMonumentState(buildingObjectData, MonumentState.Placed);
			}
		}

		private void OnFactoryObjectDeleted((FactoryObject factoryObject, FactoryLayer factoryLayer) dto)
		{
			if (dto.factoryObject.FactoryObjectData is BuildingObjectData buildingObjectData && buildingObjectData.ContainsFactoryObjectBehaviour<MonumentBehaviour>())
			{
				SetMonumentState(buildingObjectData, MonumentState.None);
			}
		}

		private void OnMonumentBuiltEvent(FactoryObject factoryObject)
		{
			if (factoryObject.FactoryObjectData is BuildingObjectData monumentData)
			{
				SetMonumentState(monumentData, MonumentState.Built);
			}
		}

		public MonumentState GetMonumentState(BuildingObjectData monumentData)
		{
			foreach (Monument monumentInfo in _monumentInfos)
			{
				if (monumentInfo.BuildingObjectData.ID == monumentData.ID)
				{
					return monumentInfo.State;
				}
			}
			return MonumentState.None;
		}

		private void SetMonumentState(BuildingObjectData monumentData, MonumentState state)
		{
			Monument orCreateMonumentInfo = GetOrCreateMonumentInfo(monumentData);
			if (orCreateMonumentInfo.State != state)
			{
				orCreateMonumentInfo.State = state;
				_progressionMonumentStateChangedEvent.Fire(orCreateMonumentInfo);
			}
		}

		private Monument GetOrCreateMonumentInfo(BuildingObjectData monumentData)
		{
			foreach (Monument monumentInfo in _monumentInfos)
			{
				if (monumentInfo.BuildingObjectData.ID == monumentData.ID)
				{
					return monumentInfo;
				}
			}
			Monument monument = new Monument
			{
				BuildingObjectData = monumentData,
				State = MonumentState.None
			};
			_monumentInfos.Add(monument);
			return monument;
		}

		internal void ApplySaveData(ProgressionSaveData saveData)
		{
			_monumentInfos.Capacity = saveData.MonumentIds.Length;
			for (int i = 0; i < saveData.MonumentIds.Length; i++)
			{
				Monument item = new Monument
				{
					BuildingObjectData = _buildingObjectDatabase.GetBuildingDataWithId(saveData.MonumentIds[i]),
					State = (MonumentState)saveData.MonumentStates[i]
				};
				_monumentInfos.Add(item);
			}
		}

		internal void Reset()
		{
			_monumentInfos.Clear();
		}
	}
}
