using System;
using System.Collections;
using Assets.Scripts.Design;
using Assets.Scripts.Environment;
using Assets.Scripts.Settings;
using Enviro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Rendering
{
	public class GlobalReflectionProbeScript : MonoBehaviour
	{
		private DesignerSettings _designerSettings;

		private bool _inDesigner;

		private int? _pendingRenderId;

		private bool _probeBakePending;

		private ReflectionProbe _reflectionProbe;

		private RenderTexture _renderTexture;

		public ReflectionProbe ReflectionProbe => _reflectionProbe;

		protected virtual void Awake()
		{
			_reflectionProbe = GetComponent<ReflectionProbe>();
			_inDesigner = GetComponentInParent<DesignerScript>() != null;
			if (_inDesigner)
			{
				_designerSettings = Game.Instance.Settings.Gameplay.Designer;
				_designerSettings.Platform.Changed += OnDesignerEnvironmentChanged;
				_designerSettings.Sky.Changed += OnDesignerEnvironmentChanged;
				_designerSettings.SkyColor.Changed += OnDesignerEnvironmentChanged;
				_designerSettings.ReflectionIntensity.Changed += OnDesignerReflectionIntensityChanged;
				OnDesignerReflectionIntensityChanged(this, EventArgs.Empty);
			}
		}

		protected virtual void LateUpdate()
		{
			if (_probeBakePending)
			{
				_probeBakePending = false;
				BakeCurrentEnvironment();
			}
			else if (_pendingRenderId.HasValue && _reflectionProbe.IsFinishedRendering(_pendingRenderId.Value))
			{
				_pendingRenderId = null;
				Graphics.CopyTexture(_reflectionProbe.texture, _renderTexture);
				_reflectionProbe.mode = ReflectionProbeMode.Custom;
				_reflectionProbe.customBakedTexture = _renderTexture;
			}
			if (!_inDesigner)
			{
				EnviroManager instance = EnviroManager.instance;
				if (instance != null)
				{
					Light directionalLight = instance.Objects.directionalLight;
					float t = Mathf.InverseLerp(0.1f, 0.6f, directionalLight.intensity);
					_reflectionProbe.intensity = Mathf.Lerp(0.4f, 1f, t);
				}
			}
		}

		protected virtual void OnDestroy()
		{
			if (_renderTexture != null)
			{
				UnityEngine.Object.Destroy(_renderTexture);
				_renderTexture = null;
			}
			if (_inDesigner)
			{
				_designerSettings.Platform.Changed -= OnDesignerEnvironmentChanged;
				_designerSettings.Sky.Changed -= OnDesignerEnvironmentChanged;
				_designerSettings.SkyColor.Changed -= OnDesignerEnvironmentChanged;
				_designerSettings.ReflectionIntensity.Changed -= OnDesignerReflectionIntensityChanged;
			}
		}

		protected virtual IEnumerator Start()
		{
			if (!_inDesigner)
			{
				yield return null;
				yield return null;
			}
			_probeBakePending = true;
		}

		private void BakeCurrentEnvironment()
		{
			if (_renderTexture == null)
			{
				CreateRenderTexture();
			}
			_reflectionProbe.mode = ReflectionProbeMode.Realtime;
			_reflectionProbe.timeSlicingMode = ReflectionProbeTimeSlicingMode.NoTimeSlicing;
			_reflectionProbe.refreshMode = ReflectionProbeRefreshMode.ViaScripting;
			_reflectionProbe.renderDynamicObjects = true;
			_reflectionProbe.hdr = true;
			string text = (_inDesigner ? "Designer" : Game.Instance.SceneManager.CurrentScene);
			ReflectionProbe reflectionProbe = _reflectionProbe;
			int cullingMask = ((text == "MainMenu") ? 8388625 : ((text == "Designer") ? 1048577 : 0));
			reflectionProbe.cullingMask = cullingMask;
			if (_inDesigner && EnviroManager.instance != null)
			{
				VolumetricEnvironment.UnsetEnviroInstance();
			}
			_pendingRenderId = _reflectionProbe.RenderProbe();
		}

		private void CreateRenderTexture()
		{
			RenderTexture renderTexture = new RenderTexture(_reflectionProbe.resolution, _reflectionProbe.resolution, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
			renderTexture.isPowerOfTwo = true;
			renderTexture.dimension = TextureDimension.Cube;
			renderTexture.useMipMap = true;
			renderTexture.autoGenerateMips = true;
			if (!renderTexture.Create())
			{
				Debug.LogError("Failed to create global reflection probe render texture.");
			}
			_renderTexture = renderTexture;
		}

		private void OnDesignerEnvironmentChanged(object sender, EventArgs e)
		{
			_probeBakePending = true;
		}

		private void OnDesignerReflectionIntensityChanged(object sender, EventArgs e)
		{
			_reflectionProbe.intensity = Mathf.Clamp(_designerSettings.ReflectionIntensity.Value, 0f, 2f);
		}
	}
}
