using System;
using System.Collections;
using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity
{
	public class ProximityLoadedTerrain : ProximityLoadedObject
	{
		[SerializeField]
		private bool _hasMultipleTiledTerrains;

		[SerializeField]
		private bool _reducePrefabQualityOnMobile;

		[SerializeField]
		private string[] _terrainPrefabPathsLowToHighQuality;

		private EnvironmentQualitySettings.TerrainQualityLevel TerrainQuality => Game.Instance.Settings.Quality.Environment.TerrainQuality.Value;

		public override void OnObjectLoaded(GameObject obj)
		{
			base.OnObjectLoaded(obj);
			if (_hasMultipleTiledTerrains)
			{
				AdjustMultipleTiledTerrains(obj);
			}
			else
			{
				AdjustSingleTerrain(obj);
			}
			obj.transform.localScale = Vector3.one;
			obj.transform.localRotation = Quaternion.identity;
			StartCoroutine(FixDisappearingTerrain(obj));
		}

		protected override void Awake()
		{
			PrefabPath = _terrainPrefabPathsLowToHighQuality[0];
			bool flag = _reducePrefabQualityOnMobile && Game.Instance.Device.IsMobileBuild;
			if (_terrainPrefabPathsLowToHighQuality.Length > 1)
			{
				switch (TerrainQuality)
				{
				case EnvironmentQualitySettings.TerrainQualityLevel.High:
					PrefabPath = (flag ? _terrainPrefabPathsLowToHighQuality[1] : _terrainPrefabPathsLowToHighQuality[2]);
					break;
				case EnvironmentQualitySettings.TerrainQualityLevel.Medium:
					PrefabPath = (flag ? _terrainPrefabPathsLowToHighQuality[0] : _terrainPrefabPathsLowToHighQuality[1]);
					break;
				}
			}
			if (PrefabPath == null)
			{
				Debug.LogErrorFormat("TerrainPrefabPath not found!");
			}
			base.Awake();
		}

		private void AdjustMultipleTiledTerrains(GameObject obj)
		{
			obj.transform.position = base.transform.position;
		}

		private void AdjustSingleTerrain(GameObject obj)
		{
			Terrain component = obj.GetComponent<Terrain>();
			Vector3 localPosition = obj.transform.localPosition;
			localPosition.x -= component.terrainData.size.x / 2f;
			localPosition.z -= component.terrainData.size.z / 2f;
			obj.transform.localPosition = localPosition;
		}

		private IEnumerator FixDisappearingTerrain(GameObject obj)
		{
			yield return new WaitForEndOfFrame();
			if (obj == null)
			{
				yield break;
			}
			Terrain[] componentsInChildren = obj.GetComponentsInChildren<Terrain>();
			foreach (Terrain terrain in componentsInChildren)
			{
				if (!(terrain == null) && !(terrain.gameObject == null))
				{
					try
					{
						terrain.enabled = false;
						terrain.enabled = true;
					}
					catch (Exception arg)
					{
						Debug.LogError($"FixDisappearingTerrain: Exception while toggling terrain '{terrain.name}' on GameObject '{terrain.gameObject.name}': {arg}");
					}
				}
			}
		}
	}
}
