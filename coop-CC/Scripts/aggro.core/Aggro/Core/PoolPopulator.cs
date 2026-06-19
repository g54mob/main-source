using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Aggro.Core
{
	public class PoolPopulator
	{
		private struct Request
		{
			public GameObject prefab;

			public int generation;

			public int count;
		}

		private List<Request> _requests = new List<Request>();

		internal PoolPopulator()
		{
		}

		public void Populate(GameObject prefab, int count)
		{
			Populate(prefab, 0, count);
		}

		public void Populate(GameObject prefab, int generation, int count)
		{
			Request item = new Request
			{
				prefab = prefab,
				generation = generation,
				count = count
			};
			_requests.Add(item);
		}

		internal void Process()
		{
			Dictionary<GameObject, Dictionary<int, int>> dictionary = new Dictionary<GameObject, Dictionary<int, int>>();
			for (int i = 0; i < _requests.Count; i++)
			{
				Request request = _requests[i];
				if (!dictionary.TryGetValue(request.prefab, out var value))
				{
					value = new Dictionary<int, int>();
					dictionary[request.prefab] = value;
				}
				value.TryGetValue(request.generation, out var value2);
				value2 += request.count;
				value[request.generation] = value2;
			}
			foreach (KeyValuePair<GameObject, Dictionary<int, int>> item in dictionary)
			{
				int num = 0;
				foreach (KeyValuePair<int, int> item2 in item.Value)
				{
					num = math.max(num, item2.Value);
				}
				item.Key.PopulateForPrefabPool(num);
			}
			_requests.Clear();
		}
	}
}
