using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.External.MapMagicInterface
{
	public class MapMagicInfiniteTerrain : MonoBehaviour
	{
		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnGenerateCompleted(Terrain terrain)
		{
			UnityTerrain unityTerrain = terrain.gameObject.GetComponent<UnityTerrain>();
			if (!unityTerrain)
			{
				unityTerrain = terrain.gameObject.AddComponent<UnityTerrain>();
			}
			unityTerrain.TerrainPosition = terrain.transform.position;
			unityTerrain.AutoAddToVegegetationSystem = true;
			unityTerrain.AddTerrainToVegetationSystem();
		}
	}
}
