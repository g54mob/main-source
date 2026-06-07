using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TriLib
{
	public class AssimpMetadataCollection : MonoBehaviour, IDictionary<string, AssimpMetadata>, ICollection<KeyValuePair<string, AssimpMetadata>>, IEnumerable<KeyValuePair<string, AssimpMetadata>>, IEnumerable
	{
		private readonly Dictionary<string, AssimpMetadata> _metadataDictionary = new Dictionary<string, AssimpMetadata>();

		public int Count => _metadataDictionary.Count;

		public bool IsReadOnly => ((ICollection<KeyValuePair<string, AssimpMetadata>>)_metadataDictionary).IsReadOnly;

		public AssimpMetadata this[string key]
		{
			get
			{
				return _metadataDictionary[key];
			}
			set
			{
				_metadataDictionary[key] = value;
			}
		}

		public ICollection<string> Keys => ((IDictionary<string, AssimpMetadata>)_metadataDictionary).Keys;

		public ICollection<AssimpMetadata> Values => ((IDictionary<string, AssimpMetadata>)_metadataDictionary).Values;

		public IEnumerator<KeyValuePair<string, AssimpMetadata>> GetEnumerator()
		{
			return _metadataDictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_metadataDictionary).GetEnumerator();
		}

		public void Add(KeyValuePair<string, AssimpMetadata> item)
		{
			_metadataDictionary.Add(item.Key, item.Value);
		}

		public void Clear()
		{
			_metadataDictionary.Clear();
		}

		public bool Contains(KeyValuePair<string, AssimpMetadata> item)
		{
			return _metadataDictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<string, AssimpMetadata>[] array, int arrayIndex)
		{
			using (IEnumerator<KeyValuePair<string, AssimpMetadata>> enumerator = GetEnumerator())
			{
				int num = 0;
				while (enumerator.MoveNext())
				{
					array[num++] = enumerator.Current;
				}
			}
		}

		public bool Remove(KeyValuePair<string, AssimpMetadata> item)
		{
			return _metadataDictionary.Remove(item.Key);
		}

		public void Add(string key, AssimpMetadata value)
		{
			_metadataDictionary.Add(key, value);
		}

		public bool ContainsKey(string key)
		{
			return _metadataDictionary.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return _metadataDictionary.Remove(key);
		}

		public bool TryGetValue(string key, out AssimpMetadata value)
		{
			return _metadataDictionary.TryGetValue(key, out value);
		}
	}
}
