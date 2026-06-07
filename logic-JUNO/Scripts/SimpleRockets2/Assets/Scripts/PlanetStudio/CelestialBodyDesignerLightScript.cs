using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio
{
	public class CelestialBodyDesignerLightScript : MonoBehaviour
	{
		protected virtual void OnDestroy()
		{
			Game.Instance.Settings.Quality.Shadows.TerrainReceivesShadows.Changed -= OnTerrainReceivesShadowsChanged;
		}

		protected virtual void Start()
		{
			Game.Instance.Settings.Quality.Shadows.TerrainReceivesShadows.Changed += OnTerrainReceivesShadowsChanged;
			UpdateShadows();
		}

		private void OnTerrainReceivesShadowsChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			UpdateShadows();
		}

		private void UpdateShadows()
		{
			GetComponent<Light>().shadows = (Game.Instance.Settings.Quality.Shadows.TerrainReceivesShadows.Value ? LightShadows.Hard : LightShadows.None);
		}
	}
}
