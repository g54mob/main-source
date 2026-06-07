using System.Collections.Generic;
using Jundroo.Common.Pool;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects
{
	public class FlightSceneResettableObjectManager
	{
		private static class Profile
		{
			public static readonly ProfilerMarker ResetObject = new ProfilerMarker("FlightSceneResettableObjectManager.ResetObject");

			public static readonly ProfilerMarker Update = new ProfilerMarker("FlightSceneResettableObjectManager.Update");
		}

		private readonly Dictionary<int, IFlightSceneResettableObject> _objects;

		public FlightSceneResettableObjectManager()
		{
			_objects = new Dictionary<int, IFlightSceneResettableObject>();
		}

		public IFlightSceneResettableObject GetObjectById(int uniqueId)
		{
			if (!_objects.TryGetValue(uniqueId, out var value))
			{
				return null;
			}
			return value;
		}

		public bool IsRegistered(IFlightSceneResettableObject obj)
		{
			return _objects.ContainsKey(obj.UniqueId);
		}

		public bool IsRegistered(int uniqueId)
		{
			return _objects.ContainsKey(uniqueId);
		}

		public void Register(IFlightSceneResettableObject obj)
		{
			if (_objects.TryGetValue(obj.UniqueId, out var value))
			{
				if (value.ResetTimer > obj.ResetTimer)
				{
					_objects[obj.UniqueId] = obj;
				}
			}
			else
			{
				_objects.Add(obj.UniqueId, obj);
			}
		}

		public void ResetAllObjects()
		{
			List<IFlightSceneResettableObject> value;
			using (CollectionPool<List<IFlightSceneResettableObject>, IFlightSceneResettableObject>.Get(out value))
			{
				value.AddRange(_objects.Values);
				foreach (IFlightSceneResettableObject item in value)
				{
					ResetObject(item);
				}
			}
		}

		public void ResetObject(IFlightSceneResettableObject obj)
		{
			using (Profile.ResetObject.Auto())
			{
				Debug.Log("Resetting object: " + obj.DisplayName);
				Unregister(obj);
				obj.ResetObject();
			}
		}

		public void Unregister(IFlightSceneResettableObject obj)
		{
			_objects.Remove(obj.UniqueId);
		}

		public void Unregister(int uniqueId)
		{
			_objects.Remove(uniqueId);
		}

		public void Update(float deltaTime)
		{
			using (Profile.Update.Auto())
			{
				List<IFlightSceneResettableObject> list = null;
				foreach (IFlightSceneResettableObject value in _objects.Values)
				{
					value.ResetTimer -= deltaTime;
					if (value.ResetTimer <= 0f)
					{
						if (list == null)
						{
							list = CollectionPool<List<IFlightSceneResettableObject>, IFlightSceneResettableObject>.Get();
						}
						list.Add(value);
					}
				}
				if (list == null)
				{
					return;
				}
				foreach (IFlightSceneResettableObject item in list)
				{
					ResetObject(item);
				}
				CollectionPool<List<IFlightSceneResettableObject>, IFlightSceneResettableObject>.Release(list);
			}
		}
	}
}
