using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	public class DecoratorPrefabView : DataView
	{
		private Dictionary<Decor, GameObject> Prefabs;

		private GameObject Container;

		public override void Initialise(GameData data)
		{
			base.Initialise(data);
			Container = new GameObject("DecoratorPrefabContainer");
			Container.SetActive(value: false);
			Prefabs = new Dictionary<Decor, GameObject>();
			foreach (Decor item in data.Get<Decor>())
			{
				Prefabs[item] = CreateSpecificPrefab(item);
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			if (Container != null)
			{
				Object.DestroyImmediate(Container);
			}
		}

		public GameObject GetPrefab(Decor decor)
		{
			return Prefabs[decor];
		}

		private GameObject CreateSpecificPrefab(Decor decor)
		{
			GameObject gameObject = Object.Instantiate(decor.ApplicatorAppliance.Prefab, Container.transform, worldPositionStays: true);
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			Material material = new Material(decor.Material);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				Material[] sharedMaterials = meshRenderer.sharedMaterials;
				for (int j = 0; j < sharedMaterials.Length; j++)
				{
					if (sharedMaterials[j].name == "DECORATION_REPLACE")
					{
						sharedMaterials[j] = material;
					}
				}
				meshRenderer.sharedMaterials = sharedMaterials;
			}
			return gameObject;
		}
	}
}
