using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerLightsScript : MonoBehaviour
	{
		private BoolSetting _designerShadowsSetting;

		private float _intensityBottom;

		private float _intensityTop;

		[SerializeField]
		private Light _lightBottom;

		[SerializeField]
		private Light _lightTop;

		[SerializeField]
		private Transform _rotationRoot;

		public void SetAmbient(Color color)
		{
			RenderSettings.ambientLight = color;
		}

		public void SetBottomLightColor(Color color)
		{
			_lightBottom.color = color;
		}

		public void SetIntensity(float intensity)
		{
			_lightTop.intensity = _intensityTop * intensity;
			_lightBottom.intensity = _intensityBottom * intensity;
		}

		public void SetRotation(float x, float y)
		{
			_rotationRoot.localEulerAngles = new Vector3(x, y, 0f);
		}

		protected virtual void Awake()
		{
			_intensityBottom = _lightBottom.intensity;
			_intensityTop = _lightTop.intensity;
			SetIntensity(1f);
			SetAmbient(new Color(0.5f, 0.5f, 0.5f, 1f));
			_designerShadowsSetting = Game.Instance.Settings.Quality.Shadow.DesignerShadows;
			_designerShadowsSetting.Changed += OnDesignerShadowsChanged;
			ApplyShadowSettings();
		}

		protected virtual void OnDestroy()
		{
			_designerShadowsSetting.Changed -= OnDesignerShadowsChanged;
		}

		private void ApplyShadowSettings()
		{
			bool value = _designerShadowsSetting.Value;
			_lightTop.shadows = (value ? LightShadows.Soft : LightShadows.None);
			_lightBottom.shadows = LightShadows.None;
		}

		private void OnDesignerShadowsChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			ApplyShadowSettings();
		}
	}
}
