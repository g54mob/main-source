using UnityEngine;

public class TerrainTreeToggle : MonoBehaviour
{
	private void OnEnable()
	{
		Terrain[] array = Object.FindObjectsByType<Terrain>(FindObjectsInactive.Include, FindObjectsSortMode.None);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].drawTreesAndFoliage = false;
		}
		RenderSettings.fogDensity = 0.0001f;
	}

	private void OnDisable()
	{
		Terrain[] array = Object.FindObjectsByType<Terrain>(FindObjectsInactive.Include, FindObjectsSortMode.None);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].drawTreesAndFoliage = true;
		}
		RenderSettings.fogDensity = 0.0005f;
	}
}
