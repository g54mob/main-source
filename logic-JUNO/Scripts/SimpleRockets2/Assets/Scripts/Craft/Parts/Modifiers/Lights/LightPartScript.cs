using System;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Craft.Parts.Styles;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Lights
{
	public class LightPartScript : PartModifierScript<LightPartData>, IAnalyzePerformance, IFlightUpdate, IGameLoopItem, IFlightStart, IDesignerStart
	{
		private IFuelSource _battery;

		private LightPartComponents _components;

		private IInputController _inputExtension;

		private IInputController _inputRotation;

		private LightScript _light;

		private float _powerConsumption;

		private Transform _prefabTransform;

		private bool _recalculatePowerConsumption;

		private IPartStyle _style;

		public LightScript Light => _light;

		public float PowerConsumption => _powerConsumption;

		public bool UsesMachNumber => false;

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			InitializeLight(calculateMinimumExtension: true);
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			InitializeLight(calculateMinimumExtension: true);
			if ((object)_light != null)
			{
				_light.LightAngleChanged += PowerConsumptionParametersChanged;
				_light.LightRangeChanged += PowerConsumptionParametersChanged;
				_light.LightIntensityChanged += PowerConsumptionParametersChanged;
				CalculatePowerConsumption();
			}
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (base.PartScript.Data.Activated)
			{
				if (_recalculatePowerConsumption)
				{
					CalculatePowerConsumption();
				}
				float num = (float)((double)_powerConsumption * frame.DeltaTimeWorld);
				if (_battery != null && Light != null && num > 0f)
				{
					Light.HasPower = _battery.RemoveFuel(num) > 0.0;
				}
			}
			if (_inputRotation != null)
			{
				SetRotation(_inputRotation.Value, forceIfUnchanged: false);
			}
			if (_inputExtension != null)
			{
				SetExtension(_inputExtension.Value, forceIfUnchanged: false);
			}
		}

		public void InitializeLight(bool calculateMinimumExtension)
		{
			LightPartComponents components = _components;
			IPartStyle style = base.PartScript.Data.Styles[0].Style;
			if (_style != style)
			{
				_style = style;
				Transform prefabTransform = _prefabTransform;
				string path = "Craft/Parts/Prefabs/Lights/" + _style.Id;
				_prefabTransform = Game.Instance.ResourceLoader.InstantiatePrefab<Transform>(path);
				_prefabTransform.SetParent(components.LightContainer, worldPositionStays: false);
				Light componentInChildren = _prefabTransform.GetComponentInChildren<Light>();
				if (_light != null)
				{
					componentInChildren.enabled = !(_light.Light == null) && _light.Light.enabled;
					_light.ReplaceLightSource(componentInChildren);
				}
				else
				{
					componentInChildren.enabled = false;
				}
				if (prefabTransform != null)
				{
					prefabTransform.gameObject.SetActive(value: false);
					UnityEngine.Object.Destroy(prefabTransform.gameObject);
				}
			}
			LightMeshData component = _prefabTransform.GetComponent<LightMeshData>();
			float num = 0f;
			if (calculateMinimumExtension)
			{
				Quaternion quaternion = Quaternion.AngleAxis(Mathf.Abs(base.Data.Rotation), Vector3.right);
				Vector3[] samplePoints = component.SamplePoints;
				foreach (Vector3 vector in samplePoints)
				{
					num = Mathf.Min(num, (quaternion * vector).y);
				}
			}
			float num2 = Mathf.Max(base.Data.Extension, Mathf.Abs(num));
			float num3 = (base.Data.HideBase ? 0f : components.MountHeightAbovePivot) + num2;
			float num4 = num3 + components.ArmExtensionBeyondLightPivot;
			float y = num4 + components.MountHeightBelowPivot;
			components.Mount.gameObject.SetActive(!base.Data.HideBase);
			components.Arm1.localPosition = new Vector3(component.Width / 2f, num4, 0f);
			components.Arm1.localScale = new Vector3(components.Arm1.localScale.x, y, components.Arm1.localScale.z);
			components.Arm2.localPosition = new Vector3((0f - component.Width) / 2f, num4, 0f);
			components.Arm2.localScale = new Vector3(components.Arm2.localScale.x, y, components.Arm2.localScale.z);
			components.Mount.localScale = new Vector3(component.MountSize.x, components.Mount.localScale.y, component.MountSize.y);
			components.LightContainer.localPosition = new Vector3(0f, num3, 0f);
			SetRotation(base.Data.Rotation, forceIfUnchanged: true);
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

		public void InitializeLightModifier()
		{
			if (_light == null)
			{
				_light = base.PartScript.GetModifier<LightScript>();
				if (_light == null)
				{
					Debug.LogWarning($"Unable to find 'Light' modifier for part '{base.PartScript.Data.Id}'");
					return;
				}
			}
			_light.Data.Color = base.Data.Part.GetMaterial(PartMeshMaterialLevel.Primary).Color;
			_light.Data.Rotation = GetComponentInChildren<Light>().transform.localRotation.eulerAngles;
			_light.Data.Mask = base.Data.Part.Styles[0].Style.Data["LightTexture"];
			_light.Data.Range = base.Data.Range;
			_light.Data.SpotLightAngle = base.Data.SpotLightAngle;
			_light.Data.PartGlow = true;
			_light.Data.PartGlowSelfShadowCasting = true;
			_light.RenderersEnabledWithActivation.Clear();
			MeshRenderer meshRenderer = _prefabTransform.Find("SpotlightEmissive")?.GetComponent<MeshRenderer>();
			if (meshRenderer != null)
			{
				_light.RenderersEnabledWithActivation.Add(meshRenderer);
			}
			_light.RenderersDisabledWithActivation.Clear();
			MeshRenderer meshRenderer2 = _prefabTransform.Find("SpotlightEmissiveOff")?.GetComponent<MeshRenderer>();
			if (meshRenderer2 != null)
			{
				_light.RenderersDisabledWithActivation.Add(meshRenderer2);
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			_battery = base.PartScript.BatteryFuelSource;
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new TextModel("Power Consumption", () => Units.GetPowerString(base.PartScript.Data.Activated ? (_powerConsumption * 1000f) : 0f)));
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(base.Data.PowerConsumption * 1000f), null, "The power consumption of the light."));
		}

		public override void OnModifiersCreated()
		{
			InitializeLightModifier();
			if (Game.InFlightScene)
			{
				_inputRotation = GetInputController("LightRotation");
				_inputExtension = GetInputController("LightExtension");
				if (_inputExtension != null)
				{
					InitializeLight(calculateMinimumExtension: true);
				}
			}
			ConfigureRenderers();
		}

		public void OnPartStyleChanged()
		{
			InitializeLight(calculateMinimumExtension: true);
			InitializeLightModifier();
			ConfigureRenderers();
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			InitializeLight(calculateMinimumExtension: true);
		}

		public override void ValidatePart(ValidationResult result)
		{
			if (base.Data.PowerConsumption > 0f)
			{
				result.ValidatFuel(this, _battery, 100f * _powerConsumption);
			}
		}

		protected virtual void Awake()
		{
			_components = GetComponent<LightPartComponents>();
		}

		protected virtual void OnDestroy()
		{
			if ((object)_light != null)
			{
				_light.LightAngleChanged -= PowerConsumptionParametersChanged;
				_light.LightRangeChanged -= PowerConsumptionParametersChanged;
				_light.LightIntensityChanged -= PowerConsumptionParametersChanged;
			}
		}

		protected override void OnInitialized()
		{
			InitializeLight(calculateMinimumExtension: true);
		}

		private void CalculatePowerConsumption()
		{
			_recalculatePowerConsumption = false;
			if (_light?.Data == null)
			{
				_powerConsumption = 0f;
			}
			else
			{
				_powerConsumption = base.Data.PowerConsumption;
			}
		}

		private void ConfigureRenderers()
		{
			if (_inputRotation != null || _inputExtension != null)
			{
				MeshRenderer[] componentsInChildren = _components.LightContainer.GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer meshRenderer in componentsInChildren)
				{
					PartMeshScript component = meshRenderer.GetComponent<PartMeshScript>();
					component = ((component != null) ? component : meshRenderer.gameObject.AddComponent<PartMeshScript>());
					component.ExcludeFromMeshCombine = true;
				}
				if (_inputExtension != null)
				{
					_ = _components.Arm1;
					Transform[] array = new Transform[2] { _components.Arm1, _components.Arm2 };
					foreach (Transform transform in array)
					{
						PartMeshScript component2 = transform.GetComponent<PartMeshScript>();
						component2 = ((component2 != null) ? component2 : transform.gameObject.AddComponent<PartMeshScript>());
						component2.ExcludeFromMeshCombine = true;
					}
				}
			}
			base.PartScript.PartMaterialScript.UpdateRenderers();
		}

		private void PowerConsumptionParametersChanged(object sender, EventArgs e)
		{
			_recalculatePowerConsumption = true;
		}

		private void SetExtension(float extension, bool forceIfUnchanged)
		{
			if (forceIfUnchanged || extension != base.Data.Extension)
			{
				base.Data.Extension = extension;
				InitializeLight(calculateMinimumExtension: false);
			}
		}

		private void SetRotation(float rotation, bool forceIfUnchanged)
		{
			if (forceIfUnchanged || rotation != base.Data.Rotation)
			{
				base.Data.Rotation = rotation;
				_components.LightContainer.localRotation = Quaternion.Euler(rotation, 0f, 0f);
			}
		}
	}
}
