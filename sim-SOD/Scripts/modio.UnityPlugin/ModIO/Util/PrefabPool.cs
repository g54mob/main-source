using System.Collections.Generic;
using UnityEngine;

namespace ModIO.Util
{
	internal class PrefabPool : SelfInstancingMonoSingleton<PrefabPool>
	{
		public Dictionary<string, List<MonoBehaviour>> pool;

		public List<GameObject> pooledItems;

		public T Load<T>(string name) where T : MonoBehaviour
		{
			return null;
		}

		public T Get<T>(string name) where T : MonoBehaviour
		{
			return null;
		}

		public void Return<T>(string name, T item) where T : MonoBehaviour
		{
		}
	}
}
