using Presentation.Locators;
using UnityEngine;

namespace Data.Lighting
{
	[CreateAssetMenu(menuName = "DayNightCycle/DayNightCycleMomentSO", fileName = "DayNightCycleMoment", order = 0)]
	public class DayNightCycleMomentSO : ScriptableObject
	{
		[SerializeField]
		private float _durationInSec;

		[Header("Main Light")]
		[SerializeField]
		private Color _mainLightColor;

		[SerializeField]
		private Vector3 _mainLightDirection;

		[SerializeField]
		private float _mainLightIntensity;

		[SerializeField]
		private float _mainLightTemperature;

		[SerializeField]
		private float _shadowsIntensity;

		[Header("Ambient")]
		[SerializeField]
		private Color _ambientColor;

		[Header("Bloom")]
		[SerializeField]
		private float _bloomThreshold;

		[SerializeField]
		private float _bloomIntensity;

		[Header("ColorLookup")]
		[SerializeField]
		private Texture2D _lookUpTexture;

		[Header("Color Adjustment")]
		[SerializeField]
		private float _postExposure;

		[SerializeField]
		private float _contrast;

		[SerializeField]
		private float _saturation;

		[Header("Clouds")]
		[SerializeField]
		private Color _cloudsColorHigh;

		[SerializeField]
		private Color _cloudsColorLow;

		[Header("Shader Globals")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _night;

		[Header("Audio")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _daytimeSFXParameter;

		[Header("References")]
		[SerializeField]
		private DirectionalLightManagerLocator _directionalLightManagerLocator;

		[SerializeField]
		private GlobalVolumeManagerLocator _globalVolumeManagerLocator;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private DayNightCycleManagerLocator _dayNightCycleManagerLocator;

		public float DurationInSec => _durationInSec;

		public Color MainLightColor => _mainLightColor;

		public Vector3 MainLightDirection => _mainLightDirection;

		public float MainLightIntensity => _mainLightIntensity;

		public float MainLightTemperature => _mainLightTemperature;

		public float ShadowsIntensity => _shadowsIntensity;

		public Color AmbientColor => _ambientColor;

		public float BloomThreshold => _bloomThreshold;

		public float BloomIntensity => _bloomIntensity;

		public Texture2D LookUpTexture => _lookUpTexture;

		public float PostExposure => _postExposure;

		public float Contrast => _contrast;

		public float Saturation => _saturation;

		public Color CloudsColorHigh => _cloudsColorHigh;

		public Color CloudsColorLow => _cloudsColorLow;

		public float Night => _night;

		public float DaytimeSFXParameter => _daytimeSFXParameter;
	}
}
