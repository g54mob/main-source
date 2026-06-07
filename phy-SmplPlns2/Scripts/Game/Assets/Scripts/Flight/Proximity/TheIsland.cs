using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity
{
	public class TheIsland : ProximityLoadedObject
	{
		protected virtual string TerrainPrefabPath
		{
			get
			{
				string text = null;
				return Game.Instance.Settings.Quality.Environment.TerrainQuality.Value switch
				{
					EnvironmentQualitySettings.TerrainQualityLevel.High => "Terrain/Terrain-High", 
					EnvironmentQualitySettings.TerrainQualityLevel.Medium => "Terrain/Terrain-Medium", 
					_ => "Terrain/Terrain-Low", 
				};
			}
		}

		public override void OnObjectLoaded(GameObject obj)
		{
			base.OnObjectLoaded(obj);
			EnvironmentQualitySettings.TerrainQualityLevel value = Game.Instance.Settings.Quality.Environment.TerrainQuality.Value;
			Terrain component = obj.GetComponent<Terrain>();
			Vector3 localPosition = obj.transform.localPosition;
			localPosition.x -= component.terrainData.size.x / 2f;
			localPosition.z -= component.terrainData.size.z / 2f;
			obj.transform.localPosition = localPosition;
			obj.transform.localScale = Vector3.one;
			obj.transform.localRotation = Quaternion.identity;
			switch (value)
			{
			case EnvironmentQualitySettings.TerrainQualityLevel.Low:
				component.heightmapPixelError = 200f;
				component.basemapDistance = 500f;
				break;
			case EnvironmentQualitySettings.TerrainQualityLevel.Medium:
				component.heightmapPixelError = 70f;
				component.basemapDistance = 2000f;
				break;
			case EnvironmentQualitySettings.TerrainQualityLevel.High:
				component.heightmapPixelError = 10f;
				component.basemapDistance = 20000f;
				break;
			}
		}

		protected override void Awake()
		{
			PrefabPath = TerrainPrefabPath;
			base.Awake();
		}
	}
}
