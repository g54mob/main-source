using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TriLib
{
	public class AssimpMetadataCollection : MonoBehaviour, IDictionary<string, AssimpMetadata>, ICollection<KeyValuePair<string, AssimpMetadata>>, IEnumerable<KeyValuePair<string, AssimpMetadata>>, IEnumerable
	{
		private readonly Dictionary<string, AssimpMetadata> _metadataDictionary;

		public int Count => 0;

		public bool IsReadOnly => false;

		public AssimpMetadata Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ICollection<string> Keys => null;

		public ICollection<AssimpMetadata> Values => null;

		public IEnumerator<KeyValuePair<string, AssimpMetadata>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void Add(KeyValuePair<string, AssimpMetadata> item)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(KeyValuePair<string, AssimpMetadata> item)
		{
			return false;
		}

		public void CopyTo(KeyValuePair<string, AssimpMetadata>[] array, int arrayIndex)
		{
		}

		public bool Remove(KeyValuePair<string, AssimpMetadata> item)
		{
			return false;
		}

		public void Add(string key, AssimpMetadata value)
		{
		}

		public bool ContainsKey(string key)
		{
			return false;
		}

		public bool Remove(string key)
		{
			return false;
		}

		public bool TryGetValue(string key, out AssimpMetadata value)
		{
			value = null;
			return false;
		}
	}
}
