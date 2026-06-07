using Assets.Scripts.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Rendering
{
	public class StaticShadowCascadesScript : MonoBehaviour
	{
		[SerializeField]
		private float _cascade1 = 10f;

		[SerializeField]
		private float _cascade2 = 50f;

		[SerializeField]
		private float _cascade3 = 100f;

		[SerializeField]
		private float _cascadeBorder = 250f;

		private bool _initialized;

		[SerializeField]
		private float _shadowDistance = 250f;

		protected virtual void OnDestroy()
		{
			Game.Instance.Settings.Quality.Shadow.ShadowQuality.Changed -= OnShadowsQualityChanged;
		}

		protected virtual void OnEnable()
		{
			if (_initialized)
			{
				ApplySettings();
			}
		}

		protected virtual void Start()
		{
			Game.Instance.Settings.Quality.Shadow.ShadowQuality.Changed += OnShadowsQualityChanged;
			_initialized = true;
			ApplySettings();
		}

		private void ApplySettings()
		{
			float num = Game.Instance.Settings.Quality.Shadow.ShadowQuality.Value switch
			{
				ShadowQualitySettings.ShadowQualityLevel.Low => 0.5f, 
				ShadowQualitySettings.ShadowQualityLevel.Medium => 0.75f, 
				_ => 1f, 
			};
			float num2 = _shadowDistance * num;
			float cascadeBorder = _cascadeBorder * num / num2;
			Vector3 cascades = new Vector3(_cascade1, _cascade2, _cascade3) / num2;
			SetCascades(cascades.x, new Vector2(cascades.x, cascades.y), cascades, cascadeBorder, num2);
		}

		private void OnShadowsQualityChanged(object sender, SettingChangedEventArgs<ShadowQualitySettings.ShadowQualityLevel> e)
		{
			ApplySettings();
		}

		private void SetCascades(float cascades2, Vector2 cascades3, Vector3 cascades4, float cascadeBorder, float shadowDistance)
		{
			UniversalRenderPipeline.asset.cascade2Split = cascades2;
			UniversalRenderPipeline.asset.cascade3Split = cascades3;
			UniversalRenderPipeline.asset.cascade4Split = cascades4;
			UniversalRenderPipeline.asset.cascadeBorder = cascadeBorder;
			UniversalRenderPipeline.asset.shadowDistance = shadowDistance;
		}
	}
}
