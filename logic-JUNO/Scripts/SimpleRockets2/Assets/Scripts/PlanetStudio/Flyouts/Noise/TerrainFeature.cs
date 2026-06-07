using System;
using ModApi.Ui.Inspector;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class TerrainFeature
	{
		public virtual void CreateModel(InspectorModel model, Action rebuildModel)
		{
		}

		protected void RefreshPlanet()
		{
			PlanetStudioScript.Instance.CelestialBodyDesignerScript.StartViewCelestialBodyInteractive();
		}
	}
}
