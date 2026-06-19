using System.Collections.Generic;
using Pug.Properties;
using Unity.Entities;
using UnityEngine;

namespace PugMod
{
	public class ModAPIAuthoring : IAuthoring
	{
		private class HashComparer : IComparer<MonoBehaviour>
		{
			private Dictionary<MonoBehaviour, long> _hash;

			public HashComparer(Dictionary<MonoBehaviour, long> hash)
			{
				_hash = hash;
			}

			public int Compare(MonoBehaviour x, MonoBehaviour y)
			{
				return _hash[x].CompareTo(_hash[y]);
			}
		}

		public readonly Dictionary<string, ObjectID> ObjectIDLookup = new Dictionary<string, ObjectID>();

		private readonly Dictionary<MonoBehaviour, long> _authoringHashes = new Dictionary<MonoBehaviour, long>();

		private readonly HashComparer _comparer;

		public List<MonoBehaviour> ExtraAuthoring { get; } = new List<MonoBehaviour>();

		public PropertyLookup.Enum<ObjectID> ObjectProperties { get; set; }

		public event IAuthoring.ObjectTypeAdded OnObjectTypeAdded;

		public ModAPIAuthoring()
		{
			_comparer = new HashComparer(_authoringHashes);
		}

		public ObjectID GetObjectID(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return ObjectID.None;
			}
			if (ObjectIDLookup.TryGetValue(name, out var value))
			{
				return value;
			}
			return ObjectID.None;
		}

		public void RegisterAuthoringGameObject(GameObject authoringGameObject)
		{
			Component component = authoringGameObject.GetComponent(typeof(IEntityMonoBehaviourData));
			if (component == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = component as MonoBehaviour;
			if (!(monoBehaviour == null) && !ExtraAuthoring.Contains(monoBehaviour))
			{
				if (!_authoringHashes.TryGetValue(monoBehaviour, out var value))
				{
					value = ComputeHash(monoBehaviour);
					_authoringHashes.Add(monoBehaviour, value);
				}
				int num = ExtraAuthoring.BinarySearch(monoBehaviour, _comparer);
				if (num < 0)
				{
					num = ~num;
				}
				ExtraAuthoring.Insert(num, monoBehaviour);
			}
		}

		public void DeregisterAuthoringGameObject(GameObject authoringGameObject)
		{
			Component component = authoringGameObject.GetComponent(typeof(IEntityMonoBehaviourData));
			if (!(component == null))
			{
				MonoBehaviour monoBehaviour = component as MonoBehaviour;
				ExtraAuthoring.Remove(monoBehaviour);
				_authoringHashes.Remove(monoBehaviour);
			}
		}

		public void ObjectTypeAdded(Entity entity, GameObject authoringData, EntityManager entityManager)
		{
			this.OnObjectTypeAdded?.Invoke(entity, authoringData, entityManager);
		}

		private static long ComputeHash(MonoBehaviour monoBehaviour)
		{
			return monoBehaviour.name.GetHashCode();
		}
	}
}
