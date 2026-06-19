using System;
using System.Collections.Generic;
using UnityEngine;

namespace PugTilemap.Workshop
{
	[CreateAssetMenu(fileName = "PrefabBank", menuName = "Pug/PugMap/MapWorkshopPrefabBank", order = 1)]
	public class WorkshopPrefabBank : ScriptableObject
	{
		[Serializable]
		public class EdPrefab
		{
			public GameObject prefab;

			public Sprite icon;

			public bool canShareTileWithOtherPrefabs;

			[NonSerialized]
			public ObjectID mainObjectID;

			public string name
			{
				get
				{
					if (!(prefab == null))
					{
						return prefab.name;
					}
					return "missing";
				}
			}

			public GameObject Instantiate()
			{
				return UnityEngine.Object.Instantiate(prefab);
			}
		}

		[NonSerialized]
		private bool inited;

		public List<EdPrefab> prefabs;

		[NonSerialized]
		public Dictionary<string, EdPrefab> prefabsByName;

		public void AddPrefab(EdPrefab prefab)
		{
			prefabs.Insert(0, prefab);
			if (prefabs.Count > 10)
			{
				prefabs.RemoveRange(10, prefabs.Count - 10);
			}
		}

		public void InitVolatile()
		{
			if (inited)
			{
				return;
			}
			prefabsByName = new Dictionary<string, EdPrefab>(prefabs.Count);
			bool flag = false;
			for (int num = prefabs.Count - 1; num >= 0; num--)
			{
				EdPrefab edPrefab = prefabs[num];
				if (edPrefab.prefab == null || edPrefab.prefab.GetComponent(typeof(IEntityMonoBehaviourData)) == null)
				{
					Debug.LogWarning("Removing missing prefab from workshop prefab bank: " + edPrefab.mainObjectID);
					prefabs.RemoveAt(num);
					flag = true;
				}
				else
				{
					IEntityMonoBehaviourData entityMonoBehaviourData = edPrefab.prefab.GetComponents(typeof(IEntityMonoBehaviourData))[0] as IEntityMonoBehaviourData;
					edPrefab.mainObjectID = entityMonoBehaviourData.ObjectInfo.objectID;
					prefabsByName.Add(entityMonoBehaviourData.GameObject.name, edPrefab);
					if (edPrefab.icon == null)
					{
						edPrefab.icon = entityMonoBehaviourData.ObjectInfo.icon;
					}
				}
			}
			inited = true;
		}
	}
}
