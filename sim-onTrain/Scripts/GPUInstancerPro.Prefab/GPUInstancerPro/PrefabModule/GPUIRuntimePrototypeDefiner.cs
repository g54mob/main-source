using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro.PrefabModule
{
	[RequireComponent(typeof(GPUIPrefabManager))]
	[DefaultExecutionOrder(-1000)]
	public class GPUIRuntimePrototypeDefiner : MonoBehaviour
	{
		public List<GameObject> prefabs;

		public bool enableTransformUpdates;

		private GPUIPrefabManager _prefabManager;

		private void OnEnable()
		{
			_prefabManager = GetComponent<GPUIPrefabManager>();
			if (prefabs == null)
			{
				return;
			}
			foreach (GameObject prefab in prefabs)
			{
				if (prefab == null)
				{
					continue;
				}
				int num = _prefabManager.GetPrototypeIndex(prefab);
				if (num < 0)
				{
					num = _prefabManager.AddPrototype(prefab);
					if (num < 0)
					{
						Debug.LogError("Add Prototype operation failed for prefab: " + prefab, prefab);
						continue;
					}
				}
				_prefabManager.GetPrototypeData(num).isAutoUpdateTransformData = enableTransformUpdates;
			}
		}
	}
}
