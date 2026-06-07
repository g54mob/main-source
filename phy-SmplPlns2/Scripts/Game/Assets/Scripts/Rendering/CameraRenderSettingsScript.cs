using UnityEngine;

namespace Assets.Scripts.Rendering
{
	public class CameraRenderSettingsScript : MonoBehaviour
	{
		public Color AmbientColor = Color.clear;

		public float AmbientIntensity = -1f;

		private Color _ambientColorBackup;

		private float _ambientIntensityBackup;

		protected virtual void OnPostRender()
		{
			if (IsAmbientColorEnabled())
			{
				RenderSettings.ambientLight = _ambientColorBackup;
			}
			if (IsAmbientIntensityEnabled())
			{
				RenderSettings.ambientIntensity = _ambientIntensityBackup;
			}
		}

		protected virtual void OnPreRender()
		{
			if (IsAmbientColorEnabled())
			{
				_ambientColorBackup = RenderSettings.ambientLight;
				RenderSettings.ambientLight = AmbientColor;
			}
			if (IsAmbientIntensityEnabled())
			{
				_ambientIntensityBackup = RenderSettings.ambientIntensity;
				RenderSettings.ambientIntensity = AmbientIntensity;
			}
		}

		private bool IsAmbientColorEnabled()
		{
			return AmbientColor != Color.clear;
		}

		private bool IsAmbientIntensityEnabled()
		{
			return AmbientIntensity > 0f;
		}
	}
}
