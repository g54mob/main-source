using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.GameView.Effects;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Modifiers.Lights
{
	public class LightScript : PartModifierScript<LightData>, IDesignerStart, IGameLoopItem, IDesignerLateUpdate, IFlightStart, IFlightUpdate
	{
		private CraftQualitySettings _craftQualitySettings;

		private List<IRendererMaterialMap> _emissiveRenderers;

		private bool _inFlightScene;

		private IInputController _inputAngle;

		private IInputController _inputIntensity;

		private IInputController _inputRange;

		private bool _isDirty;

		private Light _light;

		private List<MeshRenderer> _renderersDisabledWithActivation;

		private List<MeshRenderer> _renderersEnabledWithActivation;

		private ShadowQualitySettings _shadowSettings;

		private bool _usesInputControllers;

		public bool Active { get; private set; }

		public bool HasPower { get; set; }

		public Light Light => _light;

		public List<MeshRenderer> RenderersDisabledWithActivation => _renderersDisabledWithActivation ?? (_renderersDisabledWithActivation = new List<MeshRenderer>(1));

		public List<MeshRenderer> RenderersEnabledWithActivation => _renderersEnabledWithActivation ?? (_renderersEnabledWithActivation = new List<MeshRenderer>(1));

		public event EventHandler<EventArgs> LightAngleChanged;

		public event EventHandler<EventArgs> LightIntensityChanged;

		public event EventHandler<EventArgs> LightRangeChanged;

		void IDesignerLateUpdate.DesignerLateUpdate(in DesignerFrameData frame)
		{
			if (Active)
			{
				if (_isDirty)
				{
					InitializeLight();
					return;
				}
				RefreshEmissiveRenderers(force: false);
				UpdateRenderersAndEmission(force: false);
			}
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			HasPower = true;
			InitializeLight();
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			HasPower = true;
			InitializeLight();
			_inputRange = GetInputController("LightRange");
			_inputAngle = GetInputController("LightAngle");
			_inputIntensity = GetInputController("LightIntensity");
			_usesInputControllers = _inputRange != null || _inputAngle != null || _inputIntensity != null;
			RefreshEmissiveRenderers(force: false);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			OnUpdate();
		}

		public void InitializeLight()
		{
			_isDirty = false;
			if (_light == null)
			{
				_light = GetComponentInChildren<Light>(includeInactive: true);
				if (_light == null)
				{
					_light = new GameObject("Light").AddComponent<Light>();
					_light.transform.SetParent(base.transform);
				}
				Active = false;
				_light.enabled = false;
			}
			if (_shadowSettings == null || _craftQualitySettings == null)
			{
				_shadowSettings = Game.Instance.QualitySettings.Shadows;
				_shadowSettings.Changed += OnShadowSettingsChanged;
				_craftQualitySettings = Game.Instance.QualitySettings.Crafts;
			}
			RefreshEmissiveRenderers(force: false);
			UpdateRenderersAndEmission(force: false);
			_light.transform.SetLocalPositionAndRotation(base.Data.Offset, Quaternion.Euler(base.Data.Rotation));
			_light.type = ((base.Data.LightType == LightData.LightModifierType.Point) ? LightType.Point : LightType.Spot);
			_light.spotAngle = base.Data.SpotLightAngle;
			_light.range = base.Data.Range;
			_light.intensity = base.Data.Intensity;
			_light.color = base.Data.Color;
			_light.renderMode = LightRenderMode.ForcePixel;
			_shadowSettings.ConfigureLight(_light, ShadowQualitySettings.LightType.CraftPartLight, base.Data.CastShadows);
			if (string.IsNullOrWhiteSpace(base.Data.Mask))
			{
				_light.cookie = null;
				return;
			}
			string text = base.Data.Mask;
			if (!text.Contains('/'))
			{
				text = "Craft/Parts/Textures/LightCookies/" + base.Data.Mask;
			}
			Texture2D cookie = Game.Instance.ResourceLoader.LoadTexture(text);
			_light.cookie = cookie;
		}

		public override void OnActivated()
		{
			OnUpdate();
		}

		public override void OnDeactivated()
		{
			OnUpdate();
		}

		public void OnPartGlowChanged()
		{
			if (!base.Data.PartGlow)
			{
				RefreshEmissiveRenderers(force: true);
				UpdateRenderersAndEmission(force: true);
			}
		}

		public void ReplaceLightSource(Light light)
		{
			_light = light;
			SetDirty();
		}

		public void SetDesignerPreviewState(bool preview)
		{
			if (_inFlightScene)
			{
				Debug.LogError("SetDesignerPreviewState not supported in the flight scene.");
				return;
			}
			Active = preview;
			if (Light == null)
			{
				InitializeLight();
			}
			else
			{
				RefreshEmissiveRenderers(force: false);
				UpdateRenderersAndEmission(force: false);
			}
			Light.enabled = preview;
		}

		public void SetDirty()
		{
			_isDirty = true;
		}

		protected virtual void Awake()
		{
			_inFlightScene = Game.InFlightScene;
		}

		protected virtual void OnDestroy()
		{
			if (_shadowSettings != null)
			{
				_shadowSettings.Changed -= OnShadowSettingsChanged;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if ((object)_light != null && Active)
			{
				LightManager.UnregisterActiveLight(_light);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if ((object)_light != null && Active)
			{
				LightManager.RegisterActiveLight(_light);
			}
		}

		private void OnShadowSettingsChanged(object sender, SettingsChangedEventArgs<ShadowQualitySettings> e)
		{
			if (_light != null)
			{
				_shadowSettings.ConfigureLight(_light, ShadowQualitySettings.LightType.CraftPartLight, base.Data.CastShadows);
			}
		}

		private void OnUpdate()
		{
			bool flag = base.PartScript.Data.Activated && HasPower;
			if (_isDirty && flag)
			{
				InitializeLight();
			}
			SetLightEnabled(flag);
			if (!flag || !_usesInputControllers)
			{
				return;
			}
			bool isDirty = _isDirty;
			if (_inputRange != null)
			{
				float value = _inputRange.Value;
				if (value != _light.range)
				{
					Light light = _light;
					float range = (base.Data.Range = value);
					light.range = range;
					this.LightRangeChanged?.Invoke(this, EventArgs.Empty);
				}
			}
			if (_inputAngle != null)
			{
				float value2 = _inputAngle.Value;
				if (value2 != _light.spotAngle)
				{
					Light light2 = _light;
					float range = (base.Data.SpotLightAngle = value2);
					light2.spotAngle = range;
					this.LightAngleChanged?.Invoke(this, EventArgs.Empty);
				}
			}
			if (_inputIntensity != null)
			{
				float value3 = _inputIntensity.Value;
				if (value3 != _light.intensity)
				{
					Light light3 = _light;
					float range = (base.Data.Intensity = value3);
					light3.intensity = range;
					UpdateRenderersAndEmission(force: false);
					this.LightIntensityChanged?.Invoke(this, EventArgs.Empty);
				}
			}
			_isDirty = isDirty;
		}

		private void RefreshEmissiveRenderers(bool force)
		{
			if (!(base.Data.PartGlow || force))
			{
				return;
			}
			List<IRendererMaterialMap> rendererMaps = base.PartScript.PartMaterialScript.RendererMaps;
			_emissiveRenderers = rendererMaps.Where((IRendererMaterialMap x) => x.UsesEmissiveOverride).ToList();
			if (_emissiveRenderers.Count != 0)
			{
				return;
			}
			_emissiveRenderers.AddRange(rendererMaps);
			foreach (IRendererMaterialMap emissiveRenderer in _emissiveRenderers)
			{
				emissiveRenderer.ExcludeFromMeshCombine = true;
			}
		}

		private void SetLightEnabled(bool enabled)
		{
			if (enabled != Active)
			{
				Active = enabled;
				if (enabled)
				{
					LightManager.RegisterActiveLight(_light);
				}
				else
				{
					LightManager.UnregisterActiveLight(_light);
				}
				UpdateRenderersAndEmission(force: false);
			}
		}

		private void UpdateRenderersAndEmission(bool force)
		{
			bool flag = Active && base.Data.Intensity > 0f;
			List<MeshRenderer> renderersDisabledWithActivation = _renderersDisabledWithActivation;
			if (renderersDisabledWithActivation != null && renderersDisabledWithActivation.Count > 0)
			{
				foreach (MeshRenderer item in _renderersDisabledWithActivation)
				{
					item.enabled = !flag;
				}
			}
			List<MeshRenderer> renderersEnabledWithActivation = _renderersEnabledWithActivation;
			if (renderersEnabledWithActivation != null && renderersEnabledWithActivation.Count > 0)
			{
				foreach (MeshRenderer item2 in _renderersEnabledWithActivation)
				{
					item2.enabled = flag;
				}
			}
			bool partGlow = base.Data.PartGlow;
			if (!(partGlow || force) || _emissiveRenderers == null)
			{
				return;
			}
			float num = ((flag && partGlow) ? (Mathf.Clamp(base.Data.Intensity, 0f, 10f) * 3f) : 0f);
			foreach (IRendererMaterialMap emissiveRenderer in _emissiveRenderers)
			{
				emissiveRenderer.EmissiveOverride = num;
				if (!_inFlightScene)
				{
					emissiveRenderer.ApplyEmissiveOverride();
				}
				Renderer renderer = emissiveRenderer.Renderer;
				if (num > 0f)
				{
					if (!base.Data.PartGlowSelfShadowCasting)
					{
						renderer.shadowCastingMode = ShadowCastingMode.Off;
					}
					renderer.receiveShadows = false;
					renderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
				}
				else
				{
					_shadowSettings.ConfigurePartRenderer(renderer);
					_craftQualitySettings.ConfigurePartRenderer(renderer);
				}
			}
		}
	}
}
