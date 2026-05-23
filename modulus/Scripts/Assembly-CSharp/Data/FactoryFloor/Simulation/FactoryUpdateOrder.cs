#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.Maps;
using UnityEngine.Pool;
using Utils;

namespace Data.FactoryFloor.Simulation
{
	public class FactoryUpdateOrder
	{
		private readonly IslandObject _islandObject;

		private readonly FactoryLayer _layer;

		private readonly List<FactoryObject> _updateOrder = new List<FactoryObject>();

		private readonly Stack<FactoryObject> _toResolve = new Stack<FactoryObject>();

		private bool _orderRequiresUpdate;

		public IslandObject IslandObject => _islandObject;

		public List<FactoryObject> UpdateOrder => _updateOrder;

		public FactoryUpdateOrder(FactoryLayer layer, IslandObject islandObject)
		{
			_islandObject = islandObject;
			_layer = layer;
		}

		public void Subscribe()
		{
			_islandObject.OnObjectsOnIslandChanged += ObjectsOnIslandChanged;
		}

		public void Unsubscribe()
		{
			_islandObject.OnObjectsOnIslandChanged -= ObjectsOnIslandChanged;
		}

		private void ObjectsOnIslandChanged(IslandObject islandObject, FactoryLayer factoryLayer)
		{
			_orderRequiresUpdate = true;
		}

		public void UpdateObjects(int step)
		{
			if (_orderRequiresUpdate)
			{
				CalculateUpdateOrder();
			}
			try
			{
				foreach (FactoryObject item in _updateOrder)
				{
					item.Process(step);
				}
			}
			catch (Exception arg)
			{
				this.LogAssertion($"Failed updating factory on step {step} with exception: {arg}", "UpdateObjects", 61);
			}
		}

		public void SetLastUpdateTime(double currentTime, double waitTime)
		{
			_islandObject.SetLastUpdateTime((float)currentTime, (float)waitTime);
		}

		public void CalculateUpdateOrder()
		{
			_updateOrder.Clear();
			CollectionPool<Dictionary<int, FactoryObject>, KeyValuePair<int, FactoryObject>>.Get(out var value);
			CollectionPool<List<FactoryObject>, FactoryObject>.Get(out var value2);
			CollectionPool<Dictionary<int, int>, KeyValuePair<int, int>>.Get(out var value3);
			foreach (FactoryObject allDistinctObject in _islandObject.GetAllDistinctObjects(_layer))
			{
				value.Add(allDistinctObject.CreatedId, allDistinctObject);
			}
			FindEndPoints(value2, value, value3);
			IterateThroughStartPoints(value2, value, value3);
			while (value.Count > 0)
			{
				value2.Clear();
				FindLoopStartPoints(value2, value, value3);
				IterateThroughStartPoints(value2, value, value3);
			}
			CollectionPool<Dictionary<int, FactoryObject>, KeyValuePair<int, FactoryObject>>.Release(value);
			CollectionPool<List<FactoryObject>, FactoryObject>.Release(value2);
			CollectionPool<Dictionary<int, int>, KeyValuePair<int, int>>.Release(value3);
			_orderRequiresUpdate = false;
		}

		private void FindEndPoints(IList<FactoryObject> pathStartPoints, IDictionary<int, FactoryObject> allObjects, IDictionary<int, int> unresolvedCreatedIdOutputs)
		{
			foreach (FactoryObject value in allObjects.Values)
			{
				if (value.GetOutputFactoryObjectsCountHardLinked() == 0)
				{
					pathStartPoints.Add(value);
				}
				else if (value.OutputFactoryObjectsCount >= 2)
				{
					unresolvedCreatedIdOutputs.Add(value.CreatedId, value.OutputFactoryObjectsCount);
				}
			}
		}

		private void FindLoopStartPoints(IList<FactoryObject> startPoints, IDictionary<int, FactoryObject> allObjects, IDictionary<int, int> unresolvedCreatedIdOutputs)
		{
			startPoints.Clear();
			_toResolve.Clear();
			_toResolve.Push(allObjects.First().Value);
			CollectionPool<HashSet<int>, int>.Get(out var value);
			while (_toResolve.Count > 0)
			{
				FactoryObject factoryObject = _toResolve.Pop();
				if (value.Contains(factoryObject.CreatedId))
				{
					startPoints.Add(factoryObject);
					continue;
				}
				value.Add(factoryObject.CreatedId);
				if (unresolvedCreatedIdOutputs.TryGetValue(factoryObject.CreatedId, out var value2) && value2 <= 1)
				{
					startPoints.Add(factoryObject);
					continue;
				}
				foreach (FactoryObject.OutputFactoryObject item in factoryObject.GetOutputFactoryObjectsHardLinked())
				{
					if (item != null)
					{
						_toResolve.Push(item.FactoryObject);
					}
				}
			}
			CollectionPool<HashSet<int>, int>.Release(value);
		}

		private void IterateThroughStartPoints(IList<FactoryObject> pathStartPoints, IDictionary<int, FactoryObject> allObjects, IDictionary<int, int> unresolvedCreatedIdOutputs)
		{
			CollectionPool<List<FactoryObject>, FactoryObject>.Get(out var value);
			for (int i = 0; i < pathStartPoints.Count; i++)
			{
				value.Clear();
				AddToPath(pathStartPoints[i], value, allObjects, unresolvedCreatedIdOutputs);
				_updateOrder.AddRange(value);
			}
			CollectionPool<List<FactoryObject>, FactoryObject>.Release(value);
		}

		private void AddToPath(FactoryObject currObject, IList<FactoryObject> path, IDictionary<int, FactoryObject> allObjects, IDictionary<int, int> unresolvedCreatedIdOutputs)
		{
			_toResolve.Clear();
			_toResolve.Push(currObject);
			while (_toResolve.Count > 0)
			{
				currObject = _toResolve.Pop();
				if (!allObjects.ContainsKey(currObject.CreatedId))
				{
					continue;
				}
				if (unresolvedCreatedIdOutputs.TryGetValue(currObject.CreatedId, out var value))
				{
					if (value > 1)
					{
						unresolvedCreatedIdOutputs[currObject.CreatedId] = value - 1;
						continue;
					}
					unresolvedCreatedIdOutputs.Remove(currObject.ObjectId);
				}
				if (currObject.HasUpdateBehaviours)
				{
					path.Add(currObject);
				}
				allObjects.Remove(currObject.CreatedId);
				foreach (FactoryObject item in currObject.GetInputFactoryObjectsHardLinked())
				{
					if (item != null)
					{
						_toResolve.Push(item);
					}
				}
			}
		}
	}
}
