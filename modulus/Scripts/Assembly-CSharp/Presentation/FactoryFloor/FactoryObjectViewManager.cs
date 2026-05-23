using System;
using System.Collections;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using Data.SaveData.PersistentSOs;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Events.Islands;
using Presentation.FactoryFloor.ParticleSystemPool;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class FactoryObjectViewManager : MonoBehaviour
	{
		[SerializeField]
		private CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private IntListEvent _newFactoryObjectsSelectedEvent;

		[SerializeField]
		private IntListEvent _factoryObjectsDeSelectedEvent;

		[SerializeField]
		private IntEvent _factoryObjectHoverStoppedEvent;

		[SerializeField]
		private IntListEvent _factoryObjectsRemoveViewsEvent;

		[SerializeField]
		private BaseEvent _factoryClearedEvent;

		[SerializeField]
		private BaseEvent _startLoadingSave;

		[SerializeField]
		private BaseEvent _finishedLoadingSave;

		[SerializeField]
		private float _maxDelayPerObjectPlaced = 0.03f;

		[SerializeField]
		private float _minDelayPerObjectPlaced = 0.01f;

		[SerializeField]
		private int _objectsPlacedTillMaxSpeed = 10;

		[SerializeField]
		private ParticleSystemPoolLocator _particleSystemPoolLocator;

		[SerializeField]
		private IslandCullStateChangedEventSO _islandCullStateChangedEvent;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private FactoryObjectBlockedInDemoDatabase _factoryObjectBlockedInDemoDatabase;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSo;

		private readonly Dictionary<int, FactoryObjectView> _createdObjects = new Dictionary<int, FactoryObjectView>();

		private Dictionary<IslandObject, List<int>> _islandToCreatedObjectIndex = new Dictionary<IslandObject, List<int>>();

		private Dictionary<int, IslandObject> _objectIslandLookup = new Dictionary<int, IslandObject>();

		private Dictionary<int, CreateFactoryObjectDto> _virtualizedObjectsAwaitingCreation = new Dictionary<int, CreateFactoryObjectDto>();

		private static FactoryObjectViewManager _instance;

		private bool _isLoadingSave;

		public static FactoryObjectViewManager Instance => _instance;

		public event Action<FactoryObjectView, FactoryObject> OnFactoryObjectViewCreated = delegate
		{
		};

		public event Action<FactoryObjectView, FactoryObject> OnFactoryObjectViewRemoved = delegate
		{
		};

		private void Awake()
		{
			if (_instance != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else
			{
				_instance = this;
			}
		}

		private void Start()
		{
			_createFactoryObjectEvent.Register(CreateFactoryObject);
			_newFactoryObjectsSelectedEvent.Register(ObjectsSelected);
			_factoryObjectHoverStoppedEvent.Register(ObjectsHoverStopped);
			_factoryObjectsDeSelectedEvent.Register(ObjectsDeSelected);
			_factoryObjectsRemoveViewsEvent.Register(DeleteObjects);
			_factoryClearedEvent.Register(DeleteAllObjects);
			_startLoadingSave.Register(StartLoadingSave);
			_finishedLoadingSave.Register(FinishedLoadingSave);
		}

		private void OnDestroy()
		{
			_createFactoryObjectEvent.UnRegister(CreateFactoryObject);
			_newFactoryObjectsSelectedEvent.UnRegister(ObjectsSelected);
			_factoryObjectHoverStoppedEvent.UnRegister(ObjectsHoverStopped);
			_factoryObjectsDeSelectedEvent.UnRegister(ObjectsDeSelected);
			_factoryObjectsRemoveViewsEvent.UnRegister(DeleteObjects);
			_factoryClearedEvent.UnRegister(DeleteAllObjects);
			_startLoadingSave.UnRegister(StartLoadingSave);
			_finishedLoadingSave.UnRegister(FinishedLoadingSave);
		}

		private void StartLoadingSave()
		{
			_isLoadingSave = true;
		}

		private void FinishedLoadingSave()
		{
			_isLoadingSave = false;
		}

		private void CreateFactoryObject(CreateFactoryObjectDto createFactoryObjectDto)
		{
			if (createFactoryObjectDto.FactoryObject.GetIsland() != null)
			{
				if (!_islandToCreatedObjectIndex.ContainsKey(createFactoryObjectDto.FactoryObject.GetIsland()))
				{
					_islandToCreatedObjectIndex.Add(createFactoryObjectDto.FactoryObject.GetIsland(), new List<int>());
				}
				_islandToCreatedObjectIndex[createFactoryObjectDto.FactoryObject.GetIsland()].Add(createFactoryObjectDto.FactoryObject.CreatedId);
				_objectIslandLookup[createFactoryObjectDto.FactoryObject.CreatedId] = createFactoryObjectDto.FactoryObject.GetIsland();
			}
			CreateFactoryObjectView(createFactoryObjectDto);
		}

		public void CreateFactoryObjectView(CreateFactoryObjectDto createFactoryObjectDto)
		{
			if (_factoryObjectBlockedInDemoDatabase.IsFactoryObjectDataBlockedInDemo(createFactoryObjectDto.FactoryObject.FactoryObjectData))
			{
				return;
			}
			IslandObject island = createFactoryObjectDto.FactoryObject.GetIsland();
			if (!island.IslandConfig.IsGNNGateIsland || _unlockedIslandsPersistentSo.IsIslandUnlocked(island))
			{
				FactoryObjectView factoryObjectView = FactoryObjectViewPoolManager.Instance.GetObject(createFactoryObjectDto.FactoryObject.ObjectId);
				factoryObjectView.transform.SetPositionAndRotation(createFactoryObjectDto.Position, Quaternion.Euler(0f, createFactoryObjectDto.Rotation, 0f));
				factoryObjectView.transform.localScale = new Vector3((!createFactoryObjectDto.Mirrored) ? 1 : (-1), 1f, 1f);
				factoryObjectView.SetFactoryObject(createFactoryObjectDto.FactoryObject, createFactoryObjectDto.IsGameLoading);
				_createdObjects.Add(createFactoryObjectDto.FactoryObject.CreatedId, factoryObjectView);
				this.OnFactoryObjectViewCreated?.Invoke(factoryObjectView, createFactoryObjectDto.FactoryObject);
				if (createFactoryObjectDto.BlueprintElementIndex == -1 || _isLoadingSave)
				{
					factoryObjectView.PrepareShow(_isLoadingSave);
					factoryObjectView.Show(_isLoadingSave);
				}
				else
				{
					factoryObjectView.PrepareShow(_isLoadingSave);
					StartCoroutine(IShowViewWithDelay(createFactoryObjectDto, factoryObjectView));
				}
			}
		}

		private IEnumerator IShowViewWithDelay(CreateFactoryObjectDto createFactoryObjectDto, FactoryObjectView view)
		{
			float num = 0f;
			for (int i = 0; i < createFactoryObjectDto.BlueprintElementIndex; i++)
			{
				float t = Mathf.Clamp01((float)i / (float)_objectsPlacedTillMaxSpeed);
				num += Mathf.Lerp(_maxDelayPerObjectPlaced, _minDelayPerObjectPlaced, t);
			}
			yield return new WaitForSeconds(num);
			view.Show(_isLoadingSave);
		}

		public bool TryGetFactoryObjectView(int createdId, out FactoryObjectView view)
		{
			if (_createdObjects.ContainsKey(createdId))
			{
				view = _createdObjects[createdId];
				return true;
			}
			view = null;
			return false;
		}

		private void ObjectsSelected(List<int> createdIds)
		{
			foreach (int createdId in createdIds)
			{
				if (_createdObjects.ContainsKey(createdId))
				{
					_createdObjects[createdId].Select();
				}
			}
		}

		private void ObjectsDeSelected(List<int> createdIds)
		{
			foreach (int createdId in createdIds)
			{
				if (_createdObjects.ContainsKey(createdId))
				{
					_createdObjects[createdId].DeSelect();
				}
			}
		}

		private void ObjectsHoverStopped(int createdID)
		{
			if (_createdObjects.ContainsKey(createdID))
			{
				_createdObjects[createdID].HoverStopped();
			}
		}

		private void DeleteObjects(List<int> createdIds)
		{
			foreach (int createdId in createdIds)
			{
				if (_createdObjects.TryGetValue(createdId, out var value))
				{
					if (_objectIslandLookup.ContainsKey(createdId))
					{
						_islandToCreatedObjectIndex[_objectIslandLookup[createdId]].Remove(createdId);
						_objectIslandLookup.Remove(createdId);
					}
					FactoryObjectViewPoolManager.Instance.ReturnFactoryObject(value.FactoryObject.ObjectId, value);
					value.HoverStopped();
					_createdObjects.Remove(createdId);
				}
			}
		}

		private void DeleteAllObjects()
		{
			foreach (KeyValuePair<int, FactoryObjectView> createdObject in _createdObjects)
			{
				FactoryObjectViewPoolManager.Instance.ReturnFactoryObject(createdObject.Value.FactoryObject.ObjectId, createdObject.Value);
			}
			_islandToCreatedObjectIndex.Clear();
			_objectIslandLookup.Clear();
			_createdObjects.Clear();
		}
	}
}
