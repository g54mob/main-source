using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class DisplayResources : MonoBehaviour
	{
		public ResourceItem ItemPrefab;

		public UIGrid Grid;

		public void Start()
		{
			Grid.transform.DestroyAllChildren();
			foreach (KeyValuePair<ETerrainMaterial, ResourceSetting> resourceSetting in SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.ResourceSettings)
			{
				if (!resourceSetting.Value.HideInUserInterface)
				{
					ResourceItem resourceItem = Object.Instantiate(ItemPrefab);
					resourceItem.transform.position = Grid.transform.position;
					resourceItem.transform.parent = Grid.transform;
					resourceItem.transform.localScale = ItemPrefab.transform.localScale;
					resourceItem.Init(resourceSetting.Key, resourceSetting.Value);
				}
			}
			Grid.Reposition();
			Grid.repositionNow = true;
		}
	}
}
