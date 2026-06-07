using Jundroo.Common.Settings;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerEnvironmentScript : MonoBehaviour
	{
		public const string DefaultPlatformName = "Square";

		public const string DefaultSkyName = "Purple Haze";

		public const string PlatformNameClassic = "Classic";

		public const string SkyNameSolidColor = "Solid Color";

		private Color32 _ambientColor;

		private StringSetting _ambientColorSetting;

		private Camera _camera;

		private Designer _designer;

		private NumericSetting<float> _lightIntensitySetting;

		private NumericSetting<float> _lightRotationXSetting;

		private NumericSetting<float> _lightRotationYSetting;

		[SerializeField]
		private DesignerLightsScript _lights;

		private bool _overrideHidePlatform;

		private Transform _platform;

		private Color32 _platformColor;

		private StringSetting _platformColorSetting;

		private Material _platformMaterial;

		private StringSetting _platformSetting;

		private NumericSetting<float> _reflectionIntensitySetting;

		private Color32 _skyColor;

		private StringSetting _skyColorSetting;

		private StringSetting _skySetting;

		public static Color32 DefaultAmbientColor { get; } = new Color32(128, 128, 128, byte.MaxValue);

		public static Color DefaultPlatformColor { get; } = new Color(0f, 45f, 255f, 255f);

		public static Color32 DefaultSkyColor { get; } = new Color32(38, 38, 38, byte.MaxValue);

		public Color32 AmbientColor
		{
			get
			{
				return _ambientColor;
			}
			set
			{
				_ambientColor = value;
				_ambientColorSetting.Value = ColorsUtility.ToString(value, ColorStringFormat.HexRGB);
				if (!SuppressPersistence)
				{
					_ambientColorSetting.CommitChanges();
				}
				UpdateLights();
			}
		}

		public float LightIntensity
		{
			get
			{
				return _lightIntensitySetting.Value;
			}
			set
			{
				_lightIntensitySetting.Value = value;
				if (!SuppressPersistence)
				{
					_lightIntensitySetting.CommitChanges();
				}
				UpdateLights();
			}
		}

		public float LightRotationY
		{
			get
			{
				return _lightRotationYSetting.Value;
			}
			set
			{
				_lightRotationYSetting.Value = value;
				if (!SuppressPersistence)
				{
					_lightRotationYSetting.CommitChanges();
				}
				UpdateLights();
			}
		}

		public bool OverrideHidePlatform
		{
			get
			{
				return _overrideHidePlatform;
			}
			set
			{
				_overrideHidePlatform = value;
				UpdatePlatformVisibility();
			}
		}

		public Color PlatformColor
		{
			get
			{
				return _platformColor;
			}
			set
			{
				_platformColorSetting.Value = ColorsUtility.ToString(value, ColorStringFormat.HexRGB);
				if (!SuppressPersistence)
				{
					_platformColorSetting.CommitChanges();
				}
				UpdatePlatformColor(value);
			}
		}

		public string PlatformName
		{
			get
			{
				return _platformSetting.Value;
			}
			set
			{
				_platformSetting.Value = value;
				if (!SuppressPersistence)
				{
					_platformSetting.CommitChanges();
				}
				UpdatePlatform();
			}
		}

		public float ReflectionIntensity
		{
			get
			{
				return _reflectionIntensitySetting.Value;
			}
			set
			{
				_reflectionIntensitySetting.Value = value;
				if (!SuppressPersistence)
				{
					_reflectionIntensitySetting.CommitChanges();
				}
				UpdateLights();
			}
		}

		public Color32 SkyColor
		{
			get
			{
				return _skyColor;
			}
			set
			{
				_skyColor = value;
				_skyColorSetting.Value = ColorsUtility.ToString(value, ColorStringFormat.HexRGB);
				if (!SuppressPersistence)
				{
					_skyColorSetting.CommitChanges();
				}
				UpdateSky();
			}
		}

		public string SkyName
		{
			get
			{
				return _skySetting.Value;
			}
			set
			{
				_skySetting.Value = value;
				if (!SuppressPersistence)
				{
					_skySetting.CommitChanges();
				}
				UpdateSky();
			}
		}

		public bool SuppressPersistence { get; set; }

		public void Initialize(Designer designer)
		{
			_designer = designer;
			_camera = _designer.CameraController.Camera;
			_skySetting = Game.Instance.Settings.Gameplay.Designer.Sky;
			_skyColorSetting = Game.Instance.Settings.Gameplay.Designer.SkyColor;
			_platformColorSetting = Game.Instance.Settings.Gameplay.Designer.PlatformColor;
			_ambientColorSetting = Game.Instance.Settings.Gameplay.Designer.AmbientColor;
			_platformSetting = Game.Instance.Settings.Gameplay.Designer.Platform;
			_lightIntensitySetting = Game.Instance.Settings.Gameplay.Designer.LightIntensity;
			_lightRotationXSetting = Game.Instance.Settings.Gameplay.Designer.LightRotationX;
			_lightRotationYSetting = Game.Instance.Settings.Gameplay.Designer.LightRotationY;
			_reflectionIntensitySetting = Game.Instance.Settings.Gameplay.Designer.ReflectionIntensity;
			if (ColorsUtility.TryParseHexRGBA(_skyColorSetting.Value, out var color))
			{
				_skyColor = color;
			}
			else
			{
				_skyColor = DefaultSkyColor;
			}
			if (ColorsUtility.TryParseHexRGBA(_ambientColorSetting.Value, out var color2))
			{
				_ambientColor = color2;
			}
			else
			{
				_ambientColor = DefaultAmbientColor;
			}
			UpdateLights();
			UpdatePlatform();
			UpdateSky();
			if (ColorsUtility.TryParseHexRGBA(_platformColorSetting.Value, out var color3))
			{
				UpdatePlatformColor(color3);
			}
			else
			{
				UpdatePlatformColor(DefaultPlatformColor);
			}
		}

		public void OnEnteredDesignerFromFlight()
		{
			if (_designer != null)
			{
				UpdateLights();
			}
		}

		public void ShowPlatform(bool show)
		{
			if (_platform == null)
			{
				UpdatePlatform();
			}
			_platform.gameObject.SetActive(show && !OverrideHidePlatform);
		}

		public void UpdatePlatformColor(Color color)
		{
			if (_platformMaterial != null)
			{
				_platformColor = color;
				Color color2 = color * new Color(2f, 2f, 2f, 1f);
				_platformMaterial.SetColor("_EmissionColor", color2);
				_lights.SetBottomLightColor(color2);
			}
			else
			{
				_lights.SetBottomLightColor(Color.white);
			}
		}

		public void UpdatePlatformVisibility()
		{
			if (_camera.orthographic)
			{
				ShowPlatform(_camera.transform.forward.y <= 0f);
			}
			else
			{
				ShowPlatform(_camera.transform.position.y > 0f);
			}
		}

		protected virtual void OnEnable()
		{
			if (_skySetting != null && Game.Instance.SceneManager.InFlightScene)
			{
				UpdateSky();
			}
		}

		private void UpdateLights()
		{
			_lights.SetIntensity(LightIntensity);
			_lights.SetRotation(_lightRotationXSetting.Value, _lightRotationYSetting.Value);
			_lights.SetAmbient(AmbientColor);
		}

		private void UpdatePlatform()
		{
			if (_platform != null)
			{
				Object.Destroy(_platform.gameObject);
			}
			_platform = Game.Instance.ResourceLoader.InstantiatePrefab("Designer/Environment/Platforms/" + PlatformName).transform;
			_platform.SetParent(_designer.DesignerScript.transform);
			_platform.localScale = Vector3.one;
			_platform.rotation = Quaternion.identity;
			string platformName = PlatformName;
			Material platformMaterial = ((platformName == "Square") ? _platform.GetComponentInChildren<Renderer>().materials[1] : ((!(platformName == "Circle")) ? null : _platform.GetComponentInChildren<Renderer>().materials[0]));
			_platformMaterial = platformMaterial;
			UpdatePlatformColor(PlatformColor);
		}

		private void UpdateSky()
		{
			if (SkyName != null && SkyName != "Solid Color")
			{
				_camera.clearFlags = CameraClearFlags.Skybox;
				RenderSettings.skybox = Game.Instance.ResourceLoader.InstantiateMaterial("Designer/Environment/Skies/" + SkyName);
				return;
			}
			_camera.clearFlags = CameraClearFlags.Color;
			_camera.backgroundColor = SkyColor;
			Material material = Game.Instance.ResourceLoader.InstantiateMaterial("Designer/Environment/Skies/FlatColor");
			material.SetColor("_Tint", SkyColor);
			RenderSettings.skybox = material;
		}
	}
}
