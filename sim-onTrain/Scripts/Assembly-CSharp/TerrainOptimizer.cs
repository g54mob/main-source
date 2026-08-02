using UnityEngine;
using UnityEngine.Rendering;

public class TerrainOptimizer : MonoBehaviour
{
	private void Start()
	{
		Terrain component = GetComponent<Terrain>();
		component.heightmapPixelError = 8f;
		component.basemapDistance = 1000f;
		component.shadowCastingMode = ShadowCastingMode.On;
	}
}
