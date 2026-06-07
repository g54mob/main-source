using Assets.Scripts.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Flight.Cameras
{
	public class DynamicShadowCascadesScript : MonoBehaviour
	{
		private CameraManagerScript _cameraManager;

		private float _cascadeQualityScale = 1f;

		private float _currentIntersectionDistance = 10f;

		[SerializeField]
		private float _dsdAngleMultMax = 10f;

		[SerializeField]
		private float _dsdAngleMultMin = 1f;

		[SerializeField]
		private float _dsdClampAglPow = 1.25f;

		private float _dsdCurrentDistance = 2000f;

		[SerializeField]
		private float _dsdLerpC3 = 0.1f;

		[SerializeField]
		private float _dsdMaxBoost = 10000f;

		[SerializeField]
		private float _dsdMaxDistance = 15000f;

		[SerializeField]
		private float _dsdMinDistance = 2000f;

		[SerializeField]
		private float _dsdNoHitAslMult = 10f;

		[SerializeField]
		private float _dsdQuicknessDistance = 10f;

		[SerializeField]
		private float _dsdQuicknessIntersection = 100f;

		private bool _initialized;

		[SerializeField]
		private float _intersectionMultC2 = 0.95f;

		[SerializeField]
		private float _maxC1 = 125f;

		[SerializeField]
		private float _maxC2 = 250f;

		[SerializeField]
		private float _minC1 = 1f;

		[SerializeField]
		private float _minC2 = 25f;

		[SerializeField]
		private float _minC3 = 250f;

		[SerializeField]
		private float _multC2 = 2f;

		[SerializeField]
		private float _multC3 = 3f;

		[SerializeField]
		private bool _useDynamicShadowDistance;

		protected virtual void OnDestroy()
		{
			Game.Instance.Settings.Quality.Shadow.ShadowQuality.Changed -= OnShadowsQualityChanged;
		}

		protected virtual void OnEnable()
		{
			if (_initialized)
			{
				ApplyShadowQuality();
			}
		}

		protected virtual void Start()
		{
			_cameraManager = GetComponentInParent<CameraManagerScript>();
			Game.Instance.Settings.Quality.Shadow.ShadowQuality.Changed += OnShadowsQualityChanged;
			_initialized = true;
			ApplyShadowQuality();
		}

		protected virtual void Update()
		{
			UpdateCascades();
		}

		private void ApplyShadowQuality()
		{
			switch (Game.Instance.Settings.Quality.Shadow.ShadowQuality.Value)
			{
			case ShadowQualitySettings.ShadowQualityLevel.VeryHigh:
				base.enabled = true;
				_useDynamicShadowDistance = true;
				_cascadeQualityScale = 1f;
				break;
			case ShadowQualitySettings.ShadowQualityLevel.High:
				base.enabled = true;
				_useDynamicShadowDistance = false;
				_cascadeQualityScale = 1f;
				UniversalRenderPipeline.asset.shadowDistance = 2000f;
				break;
			case ShadowQualitySettings.ShadowQualityLevel.Medium:
				base.enabled = true;
				_useDynamicShadowDistance = false;
				_cascadeQualityScale = 0.75f;
				UniversalRenderPipeline.asset.shadowDistance = 1000f;
				break;
			case ShadowQualitySettings.ShadowQualityLevel.Low:
				base.enabled = true;
				_useDynamicShadowDistance = false;
				_cascadeQualityScale = 0.5f;
				UniversalRenderPipeline.asset.shadowDistance = 500f;
				break;
			default:
				base.enabled = false;
				break;
			}
		}

		private void OnShadowsQualityChanged(object sender, SettingChangedEventArgs<ShadowQualitySettings.ShadowQualityLevel> e)
		{
			ApplyShadowQuality();
		}

		private void SetCascades(float? cascades2, Vector2? cascades3, Vector3? cascades4)
		{
			if (cascades2.HasValue)
			{
				UniversalRenderPipeline.asset.cascade2Split = cascades2.Value;
			}
			if (cascades3.HasValue)
			{
				UniversalRenderPipeline.asset.cascade3Split = cascades3.Value;
			}
			if (cascades4.HasValue)
			{
				UniversalRenderPipeline.asset.cascade4Split = cascades4.Value;
			}
		}

		private void UpdateCascades()
		{
			Vector3 position = base.transform.position;
			float num = Mathf.Max(0f, Utility.GetHeightAboveTerrain(position) ?? (position.y - GameWorld.Instance.FloatingOriginSeaLevel).GetValueOrDefault());
			if (_useDynamicShadowDistance)
			{
				Vector3? terrainOrSeaIntersection = Utility.GetTerrainOrSeaIntersection(new Ray(position, base.transform.forward), GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault(), 20000f);
				float valueOrDefault = (position.y - GameWorld.Instance.FloatingOriginSeaLevel).GetValueOrDefault();
				float a = Mathf.Min((terrainOrSeaIntersection - position)?.magnitude ?? (valueOrDefault * _dsdNoHitAslMult), _dsdMaxDistance);
				a = Mathf.Min(a, Mathf.Pow(num, _dsdClampAglPow));
				_currentIntersectionDistance = Mathf.Lerp(_currentIntersectionDistance, a, Time.unscaledDeltaTime * _dsdQuicknessIntersection);
				float t = Mathf.Abs(base.transform.forward.y);
				float num2 = Mathf.Min(_dsdMaxBoost, valueOrDefault * Mathf.Lerp(_dsdAngleMultMax, _dsdAngleMultMin, t));
				float b = Mathf.Max(_dsdMinDistance, _currentIntersectionDistance + num2);
				_dsdCurrentDistance = Mathf.Lerp(_dsdCurrentDistance, b, Time.unscaledDeltaTime * _dsdQuicknessDistance);
				float num3 = Mathf.Max(_minC1, _cameraManager.Controller.PreferredClosestShadowDistance);
				float num4 = Mathf.Max(_minC2, num3 * _multC2, _currentIntersectionDistance * _intersectionMultC2);
				float num5 = Mathf.Lerp(num4, _dsdCurrentDistance, _dsdLerpC3);
				UniversalRenderPipeline.asset.shadowDistance = _dsdCurrentDistance;
				Vector3 value = new Vector3(Mathf.Clamp01(num3 / _dsdCurrentDistance), Mathf.Clamp01(num4 / _dsdCurrentDistance), Mathf.Clamp01(num5 / _dsdCurrentDistance));
				SetCascades(null, null, value);
			}
			else
			{
				float shadowDistance = UniversalRenderPipeline.asset.shadowDistance;
				float cascadeQualityScale = _cascadeQualityScale;
				float num6 = Mathf.Min(_maxC1 * cascadeQualityScale, Mathf.Max(_minC1, _cameraManager.Controller.PreferredClosestShadowDistance));
				float num7 = Mathf.Min(_maxC2 * cascadeQualityScale, Mathf.Max(Mathf.Max(_minC2 * cascadeQualityScale, num6 * _multC2), num * _intersectionMultC2));
				float num8 = Mathf.Max(num7 * _multC3, _minC3 * cascadeQualityScale);
				Vector3 value2 = new Vector3(Mathf.Clamp01(num6 / shadowDistance), Mathf.Clamp01(num7 / shadowDistance), Mathf.Clamp01(num8 / shadowDistance));
				SetCascades(value2.x, new Vector2(value2.x, value2.y), value2);
			}
		}
	}
}
