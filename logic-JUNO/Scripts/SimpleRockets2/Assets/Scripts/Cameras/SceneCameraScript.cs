using System;
using Assets.Scripts.PlanetStudio;
using ModApi.Cameras;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace Assets.Scripts.Cameras
{
	public class SceneCameraScript : MonoBehaviour, ISceneCamera
	{
		private enum CraftMaskMode
		{
			Disabled = 0,
			NearCam = 1,
			FarCam = 2
		}

		private Camera _cam;

		[SerializeField]
		private CraftMaskMode _craftMaskMode;

		private RenderBuffer[] _dualBufferArray;

		private SceneMasterCameraScript _masterCam;

		[SerializeField]
		private bool _useConfigurableFOV;

		public Camera Camera => _cam;

		public ISceneMasterCamera MasterCamera => _masterCam;

		public bool UseConfigurableFOV => _useConfigurableFOV;

		public event EventHandler<EventArgs> PostRender;

		public event EventHandler<EventArgs> PreRender;

		public static void UpdateDepthTextureState()
		{
			Camera camera = null;
			if (Game.InFlightScene)
			{
				camera = Game.Instance.FlightScene?.ViewManager.GameView.GameCamera.NearCamera;
			}
			else if (Game.InDesignerScene)
			{
				camera = Game.Instance.Designer.DesignerCamera.Camera;
			}
			else if (Game.InPlanetStudioScene)
			{
				camera = PlanetStudioScript.Instance?.CelestialBodyDesignerScript.CelestialBodyViewer.NearCamera;
			}
			if (!(camera == null))
			{
				DepthOfField component = camera.GetComponent<DepthOfField>();
				IGameQualitySettings qualitySettings = Game.Instance.QualitySettings;
				if (QualitySettings.softParticles || component.enabled || (Game.InFlightScene && (qualitySettings.ImageEffects.Enabled.Value || qualitySettings.Water.Transparency.Value)))
				{
					camera.depthTextureMode = DepthTextureMode.Depth;
				}
				else
				{
					camera.depthTextureMode = DepthTextureMode.None;
				}
			}
		}

		protected virtual void Awake()
		{
			_masterCam = UnityEngine.Object.FindObjectOfType<SceneMasterCameraScript>();
			if (_masterCam == null)
			{
				Debug.LogError("Camera '" + base.gameObject.name + "' cannot find master scene camera.", this);
			}
			_cam = GetComponent<Camera>();
			if (_cam == null)
			{
				Debug.LogError("Camera '" + base.gameObject.name + "' cannot find the camera component.", this);
			}
			_dualBufferArray = new RenderBuffer[2];
			if (_useConfigurableFOV)
			{
				NumericSetting<float> fieldOfView = Game.Instance.Settings.Game.General.FieldOfView;
				fieldOfView.Changed += OnFieldOfViewChanged;
				_cam.fieldOfView = fieldOfView;
			}
			_cam.allowHDR = Game.Instance.Settings.Quality.ImageEffects.HdrEnabled.Value;
		}

		protected virtual void OnDestroy()
		{
			if (_useConfigurableFOV)
			{
				Game.Instance.Settings.Game.General.FieldOfView.Changed -= OnFieldOfViewChanged;
			}
		}

		private void OnFieldOfViewChanged(object sender, SettingChangedEventArgs<float> e)
		{
			_cam.fieldOfView = e.Setting;
		}

		private void OnPostRender()
		{
			_cam.targetTexture = _masterCam.RenderTextureScene;
			this.PostRender?.Invoke(this, EventArgs.Empty);
		}

		private void OnPreRender()
		{
			bool num = _craftMaskMode == CraftMaskMode.NearCam;
			bool flag = _craftMaskMode == CraftMaskMode.FarCam;
			if (num)
			{
				Shader.EnableKeyword("NEAR_CAMERA");
				Shader.DisableKeyword("FAR_CAMERA");
			}
			else if (flag)
			{
				Shader.DisableKeyword("NEAR_CAMERA");
				Shader.EnableKeyword("FAR_CAMERA");
			}
			else
			{
				Shader.DisableKeyword("NEAR_CAMERA");
				Shader.DisableKeyword("FAR_CAMERA");
			}
			RenderTexture renderTextureScene = _masterCam.RenderTextureScene;
			RenderTexture renderTextureCraftMask = _masterCam.RenderTextureCraftMask;
			if ((num || flag) && renderTextureCraftMask != null)
			{
				if (flag)
				{
					RenderTexture active = RenderTexture.active;
					RenderTexture.active = renderTextureCraftMask;
					GL.Clear(clearDepth: false, clearColor: true, Color.black);
					RenderTexture.active = active;
				}
				_dualBufferArray[0] = renderTextureScene.colorBuffer;
				_dualBufferArray[1] = renderTextureCraftMask.colorBuffer;
				_cam.SetTargetBuffers(_dualBufferArray, renderTextureScene.depthBuffer);
			}
			else
			{
				_cam.targetTexture = _masterCam.RenderTextureScene;
			}
			this.PreRender?.Invoke(this, EventArgs.Empty);
		}
	}
}
