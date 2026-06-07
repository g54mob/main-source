using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerLightScript : MonoBehaviour
	{
		private static class ShaderPropertyIds
		{
			public static readonly int DirectionalLightAdditiveDirection = Shader.PropertyToID("_directionalLightAdditive_Direction");
		}

		[SerializeField]
		private Light _mainLight;

		[SerializeField]
		private Light _secondaryLight;

		public void UpdateLights()
		{
			Shader.SetGlobalVector(ShaderPropertyIds.DirectionalLightAdditiveDirection, -_secondaryLight.transform.forward);
		}

		protected virtual void LateUpdate()
		{
			UpdateLights();
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.Settings.Quality.Shadows.DesignerShadows.Changed -= OnDesignerShadowsChanged;
		}

		protected virtual void Start()
		{
			Game.Instance.Settings.Quality.Shadows.DesignerShadows.Changed += OnDesignerShadowsChanged;
			UpdateShadows();
		}

		private void OnDesignerShadowsChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			UpdateShadows();
		}

		private void UpdateShadows()
		{
			_mainLight.shadows = (Game.Instance.Settings.Quality.Shadows.DesignerShadows.Value ? LightShadows.Hard : LightShadows.None);
			_secondaryLight.shadows = LightShadows.None;
		}
	}
}
