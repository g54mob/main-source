using ModApi.CelestialData;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio
{
	public class PlanetarySystemViewerScript : MonoBehaviour
	{
		public SolarSystemDataScript PlanetarySystemData { get; private set; }

		public void ResetView()
		{
		}

		public void UnloadPlanetarySystem()
		{
			if (PlanetarySystemData != null)
			{
				Object.DestroyImmediate(PlanetarySystemData.gameObject);
				PlanetarySystemData = null;
			}
		}

		public void ViewPlanetarySystem(CelestialFile planetarySystemFile, bool resetView)
		{
			UnloadPlanetarySystem();
			PlanetarySystemData = SolarSystemDataScript.CreateFromFile(planetarySystemFile, createTerrainData: false, applyScaleAndOverrides: true);
			PlanetarySystemData.transform.SetParent(base.transform);
			PlanetarySystemData.ApplyCustomSkybox();
			if (resetView)
			{
				ResetView();
			}
		}
	}
}
