using System.Collections.Generic;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class PrefabRepository : AddressableRepository<PrefabRepository, KeyGameObjectPair, GameObject>
	{
		public override List<string> AddressableLabels()
		{
			return new List<string> { "Prefab" };
		}

		public override void AddNewObject(string key, Object obj, bool overwrite = false)
		{
			if (!(obj == null) && !string.IsNullOrEmpty(key) && !dictionary.ContainsKey(key))
			{
				Add(new KeyGameObjectPair(key, obj as GameObject));
			}
		}
	}
}
