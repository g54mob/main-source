using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Settings;
using ModApi.Ui.Inspector;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Modifiers.Lights
{
	public class BeaconLightScript : PartModifierScript<BeaconLightData>, IAnalyzePerformance, IDesignerLateUpdate, IGameLoopItem, IFlightUpdate, IFlightStart, IDesignerStart
	{
		private bool? _activationOverrideState;

		[SerializeField]
		private AnimationCurve _animationCurveDebug;

		private IFuelSource _battery;

		private LightPartComponents _components;

		private CraftQualitySettings _craftQualitySettings;

		private float _currentIntensity;

		private List<IRendererMaterialMap> _emissiveRenderers;

		private bool _inFlightScene;

		private IInputController _inputBlinkFrequency;

		private IInputController _inputIntensity;

		private float _powerConsumption;

		private ShadowQualitySettings _shadowSettings;

		private bool _usesInputControllers;

		public bool? ActivationOverrideState
		{
			get
			{
				return _activationOverrideState;
			}
			set
			{
				if (_activationOverrideState != value)
				{
					_activationOverrideState = value;
					RefreshEmissiveRenderers();
					UpdateIntensity();
				}
			}
		}

		public bool HasPower { get; set; }

		public float PowerConsumption => _powerConsumption;

		public bool UsesMachNumber => false;

		void IDesignerLateUpdate.DesignerLateUpdate(in DesignerFrameData frame)
		{
			if (_activationOverrideState.HasValue)
			{
				if (base.Data.BlinkCurve != null)
				{
					base.Data.BlinkCurve.CurrentTime += frame.DeltaTime;
				}
				RefreshEmissiveRenderers();
				UpdateIntensity();
			}
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			UpdateScale();
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_inputIntensity = GetInputController("BeaconLightIntensity");
			_inputBlinkFrequency = GetInputController("BeaconLightBlinkFrequency");
			_usesInputControllers = _inputIntensity != null || _inputBlinkFrequency != null;
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			bool activated = base.PartScript.Data.Activated;
			if (activated && _powerConsumption != 0f)
			{
				_battery.RemoveFuel((double)_powerConsumption * frame.DeltaTimeWorld);
			}
			HasPower = _powerConsumption == 0f || !(_battery?.IsEmpty ?? true);
			if (activated && HasPower)
			{
				base.Data.BlinkCurve.CurrentTime += (float)frame.DeltaTimeWorld;
				if (_usesInputControllers)
				{
					if (_inputIntensity != null)
					{
						base.Data.Intensity = _inputIntensity.Value;
					}
					if (_inputBlinkFrequency != null)
					{
						base.Data.BlinkFrequency = _inputBlinkFrequency.Value;
					}
				}
			}
			UpdateIntensity();
		}

		public void InitializeLight()
		{
			LightPartComponents components = _components;
			if (components != null)
			{
				components.Mount.gameObject.SetActive(!base.Data.HideBase);
				components.LightContainer.localPosition = new Vector3(0f, base.Data.HideBase ? (-0.025f) : components.MountHeightAbovePivot, 0f);
			}
			_powerConsumption = 0.005f * base.Data.PowerConsumptionScale;
			if (_shadowSettings == null || _craftQualitySettings == null)
			{
				IGameQualitySettings qualitySettings = Game.Instance.QualitySettings;
				_shadowSettings = qualitySettings.Shadows;
				_craftQualitySettings = qualitySettings.Crafts;
			}
			UpdateScale();
			_currentIntensity = -1f;
			RefreshEmissiveRenderers();
		}

		public override void OnActivated()
		{
			UpdateIntensity();
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			_battery = base.PartScript.BatteryFuelSource;
		}

		public override void OnDeactivated()
		{
			UpdateIntensity();
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new TextModel("Power Consumption", () => Units.GetPowerString(base.PartScript.Data.Activated ? (_powerConsumption * 1000f) : 0f)));
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(5f * base.Data.PowerConsumptionScale), null, "The power consumption of the beacon."));
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			UpdateScale();
		}

		public void UpdateScale()
		{
			if (!(base.Data.Part.PartType.Id == "BeaconLight1"))
			{
				return;
			}
			Transform transform = base.transform.Find("Scalar");
			if (!(transform != null))
			{
				return;
			}
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 0.4f * base.Data.Scale;
			}
			transform.localScale = Vector3.one * base.Data.Scale;
			transform.localPosition = new Vector3(0f, 0f, 0f);
		}

		public override void ValidatePart(ValidationResult result)
		{
			if (base.Data.PowerConsumptionScale > 0f)
			{
				result.ValidatFuel(this, _battery, 100f * _powerConsumption);
			}
		}

		protected virtual void Awake()
		{
			_components = GetComponent<LightPartComponents>();
			_inFlightScene = Game.InFlightScene;
		}

		protected override void OnInitialized()
		{
			InitializeLight();
		}

		private float CalculateLightIntensity()
		{
			bool? activationOverrideState = _activationOverrideState;
			bool num;
			if (!activationOverrideState.HasValue)
			{
				if (!base.PartScript.Data.Activated)
				{
					goto IL_0060;
				}
				num = HasPower;
			}
			else
			{
				num = activationOverrideState == true;
			}
			if (num)
			{
				float num2 = base.Data.BlinkCurve?.GetValueAtCurrentTime() ?? 1f;
				return base.Data.Intensity * num2;
			}
			goto IL_0060;
			IL_0060:
			return 0f;
		}

		private void RefreshEmissiveRenderers()
		{
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

		private void UpdateIntensity()
		{
			float num = CalculateLightIntensity();
			if (_currentIntensity == num)
			{
				return;
			}
			_currentIntensity = num;
			if (_emissiveRenderers == null)
			{
				return;
			}
			float num2 = num;
			foreach (IRendererMaterialMap emissiveRenderer in _emissiveRenderers)
			{
				emissiveRenderer.EmissiveOverride = num2;
				if (!_inFlightScene)
				{
					emissiveRenderer.ApplyEmissiveOverride();
				}
				Renderer renderer = emissiveRenderer.Renderer;
				if (num2 > 0f)
				{
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
