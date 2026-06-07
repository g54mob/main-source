using Assets.Scripts.Cameras;
using Assets.Scripts.PlanetStudio;
using ModApi;
using ModApi.Planet;
using ModApi.Planet.Events;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Terrain.Rendering
{
	public class WaterTransparencyCameraScript : MonoBehaviour
	{
		private Camera _camera;

		private CommandBuffer _commandBuffer;

		private bool _commandBufferEnabled;

		private IPlanet _planet;

		private bool _supportsTransparency;

		protected virtual void Awake()
		{
			if (Game.InFlightScene)
			{
				_planet = Game.Instance.FlightScene?.ViewManager.GameView.Planet;
			}
			else if (Game.InPlanetStudioScene)
			{
				_planet = PlanetStudioScript.Instance.CelestialBodyDesignerScript.CelestialBodyViewer.PlanetScript;
			}
			if (_planet == null)
			{
				Debug.LogError("Unable to find the planet reference.");
				base.gameObject.SetActive(value: false);
				return;
			}
			_planet.QuadSphereLoaded += QuadSphereStateChanged;
			_planet.QuadSphereEnabledStateChanged += QuadSphereStateChanged;
			WaterQualitySettings water = Game.Instance.QualitySettings.Water;
			water.Changed += OnWaterQualityChanged;
			ApplyQualitySettings(water);
		}

		protected virtual void OnDestroy()
		{
			DisableCommandBuffer();
			Game.Instance.QualitySettings.Water.Changed -= OnWaterQualityChanged;
			if (_planet != null)
			{
				_planet.QuadSphereLoaded -= QuadSphereStateChanged;
				_planet.QuadSphereEnabledStateChanged -= QuadSphereStateChanged;
				_planet = null;
			}
		}

		private void ApplyQualitySettings(WaterQualitySettings quality)
		{
			_supportsTransparency = quality.Transparency;
			SceneCameraScript.UpdateDepthTextureState();
		}

		private void DisableCommandBuffer()
		{
			if (_camera != null)
			{
				if (_commandBuffer != null)
				{
					_camera.RemoveCommandBuffer(CameraEvent.BeforeForwardAlpha, _commandBuffer);
				}
				_camera = null;
			}
			_commandBuffer = null;
		}

		private void EnableCommandBuffer()
		{
			_camera = GetComponent<Camera>();
			if (_camera == null)
			{
				Debug.LogError("The water refraction script must be attached to a camera game object.");
			}
			CommandBuffer commandBuffer = new CommandBuffer();
			commandBuffer.name = "Water Refraction Grab Pass";
			int num = Shader.PropertyToID("_WaterRefractionTexture");
			commandBuffer.GetTemporaryRT(num, -1, -1, 0, FilterMode.Bilinear, Utilities.Texture.GetDefaultRenderTextureFormat());
			commandBuffer.Blit(BuiltinRenderTextureType.CurrentActive, num);
			commandBuffer.SetGlobalTexture("_WaterRefractionTexture", num);
			_camera.AddCommandBuffer(CameraEvent.BeforeForwardAlpha, commandBuffer);
			_commandBuffer = commandBuffer;
		}

		private void OnWaterQualityChanged(object sender, SettingsChangedEventArgs<WaterQualitySettings> e)
		{
			ApplyQualitySettings(e.Category);
		}

		private void QuadSphereStateChanged(object sender, PlanetQuadSphereEventArgs e)
		{
			if (!_supportsTransparency)
			{
				if (_commandBufferEnabled)
				{
					_commandBufferEnabled = false;
					DisableCommandBuffer();
				}
				return;
			}
			bool quadSphereEnabled = e.Planet.QuadSphereEnabled;
			if (quadSphereEnabled != _commandBufferEnabled)
			{
				_commandBufferEnabled = quadSphereEnabled;
				if (quadSphereEnabled)
				{
					EnableCommandBuffer();
				}
				else
				{
					DisableCommandBuffer();
				}
			}
		}
	}
}
