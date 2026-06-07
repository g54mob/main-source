#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.Operator;
using Events;
using Unity.Mathematics;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor
{
	public class FactoryObjectViewPoolManager : MonoBehaviour
	{
		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[Space]
		[SerializeField]
		private int _defaultSupposedPoolSize = 20;

		[SerializeField]
		private List<FactoryObjectData> _excludedFromPooling;

		[SerializeField]
		private List<FactoryObjectData> _exludedFromAutoExpansion;

		[SerializeField]
		private SerializedDictionary<FactoryObjectData, int> _prefillAmountsPerObjectData;

		private static FactoryObjectViewPoolManager _instance;

		private readonly Dictionary<int, ComponentPool<FactoryObjectView>> _pools = new Dictionary<int, ComponentPool<FactoryObjectView>>();

		private readonly List<Transform> _parents = new List<Transform>();

		private double _nextUpdateTime;

		public static FactoryObjectViewPoolManager Instance => _instance;

		private void Awake()
		{
			if (_instance != null)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			_instance = this;
			CreatePools();
		}

		private void OnDestroy()
		{
			_finishedLoadingSaveEvent.UnRegister(OnFinishedLoadingSave);
			foreach (Transform parent in _parents)
			{
				if (parent != null)
				{
					Object.Destroy(parent.gameObject);
				}
			}
		}

		private void OnFinishedLoadingSave()
		{
			foreach (ComponentPool<FactoryObjectView> value in _pools.Values)
			{
				while (value.TryAutoBalance())
				{
				}
			}
		}

		private void Update()
		{
			if (Time.timeAsDouble < _nextUpdateTime)
			{
				return;
			}
			_nextUpdateTime = Time.timeAsDouble;
			using Dictionary<int, ComponentPool<FactoryObjectView>>.ValueCollection.Enumerator enumerator = _pools.Values.GetEnumerator();
			while (enumerator.MoveNext() && !enumerator.Current.TryAutoBalance())
			{
			}
		}

		private void CreatePools()
		{
			foreach (FactoryObjectData allFactoryObjectsDatum in _factoryObjectDatabase.AllFactoryObjectsData)
			{
				CreatePool(allFactoryObjectsDatum);
			}
		}

		private void CreatePool(FactoryObjectData objectData)
		{
			if (!_excludedFromPooling.Contains(objectData))
			{
				bool flag = _exludedFromAutoExpansion.Contains(objectData);
				int supposedAmount = (_prefillAmountsPerObjectData.ContainsKey(objectData) ? _prefillAmountsPerObjectData[objectData] : ((!flag) ? _defaultSupposedPoolSize : 0));
				Transform transform = new GameObject().transform;
				transform.name = "Pool_" + objectData.name + (flag ? "" : "_autoEx");
				_parents.Add(transform);
				_pools.Add(objectData.ID, new ComponentPool<FactoryObjectView>(supposedAmount, objectData.PrefabFactoryObjectView, transform, quaternion.identity, !flag));
			}
		}

		public FactoryObjectView GetObject(int id)
		{
			if (!_pools.TryGetValue(id, out var value))
			{
				return null;
			}
			return value.GetComponent();
		}

		public void ReturnFactoryObject(int objectId, FactoryObjectView factoryObjectView, bool wasPreview = false)
		{
			if (!_pools.TryGetValue(objectId, out var value))
			{
				this.LogError("Couldn't return factory object" + factoryObjectView.name, "ReturnFactoryObject", 113);
				return;
			}
			factoryObjectView.Reset(wasPreview);
			value.ReturnMono(factoryObjectView);
		}
	}
}
