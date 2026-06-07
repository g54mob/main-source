using System;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class GeneratorScript : PartModifierScript<GeneratorData>, IAnalyzePerformance, IDesignerStart, IGameLoopItem, IFlightStart, IFlightUpdate
	{
		private LoopingAudioScript _audio;

		private IFuelSource _battery;

		private double _fuelRemoved;

		private IFuelSource _fuelSource;

		private FuelTankScript _fuelTank;

		private IInputController _inputThrottle;

		private double _powerGenerated;

		private float _powerScale = 1f;

		public bool UsesMachNumber => false;

		private FuelTankScript FuelTank
		{
			get
			{
				return _fuelTank;
			}
			set
			{
				if (_fuelTank != value)
				{
					if (Game.InFlightScene && _fuelTank != null)
					{
						_fuelTank.CraftFuelSourceChanged -= OnCraftFuelSourceChanged;
					}
					_fuelTank = value;
					if (Game.InFlightScene && _fuelTank != null)
					{
						_fuelTank.CraftFuelSourceChanged += OnCraftFuelSourceChanged;
					}
				}
			}
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			UpdateBase();
			UpdateScale();
			UpdateStretch();
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			UpdateBase();
			UpdateScale();
			UpdateStretch();
			_powerScale = base.Data.FuelConsumptionScale;
			_inputThrottle = GetInputController("Throttle");
			if (base.Data.SoundVolume > 0f)
			{
				_audio = base.PartScript.Transform.GetComponentInChildren<LoopingAudioScript>(includeInactive: true);
				ConfigureAudio();
			}
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (frame.DeltaTimeWorld == 0.0)
			{
				return;
			}
			if (_inputThrottle != null)
			{
				_powerScale = Mathf.Clamp01(_inputThrottle.Value);
			}
			if (base.PartScript.Data.Activated || !base.PartScript.Data.Config.SupportsActivation)
			{
				double num = 1.0 / frame.DeltaTimeWorld;
				double num2 = (double)(_powerScale * base.Data.FuelFlow) * frame.DeltaTimeWorld;
				if (base.Data.FuelType != null)
				{
					num2 = _fuelSource.RemoveFuel(num2);
					_fuelRemoved = num2 * num;
				}
				double num3 = base.Data.MaxPowerGenerated((float)num2);
				_powerGenerated = num3 * num;
				_battery.AddFuel(num3 * 0.001);
				if (_audio != null && base.Data.SoundVolume > 0f)
				{
					float num4 = Mathf.Lerp(0.25f, 1f, _powerScale);
					_audio.UpdateLoopAudio(num4, num4, 2.1f);
				}
			}
			else
			{
				_fuelRemoved = 0.0;
				_powerGenerated = 0.0;
				if (_audio != null && base.Data.SoundVolume > 0f)
				{
					float targetPitch = Mathf.Lerp(0.25f, 1f, _powerScale);
					_audio.UpdateLoopAudio(0f, targetPitch);
				}
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			_battery = base.PartScript.BatteryFuelSource;
			FuelTank = EngineUtilities.GetFuelTank(base.PartScript, base.Data.FuelSourceAttachPoint, base.Data.FuelType)?.Script;
			RefreshFuelSource();
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			GroupModel groupModel = new GroupModel("Performance");
			model.AddGroup(groupModel);
			CreateInspectorModel(groupModel, flight: true);
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			CreateInspectorModel(groupModel, flight: false);
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			UpdateBase();
			UpdateScale();
			UpdateStretch();
		}

		public void UpdateBase()
		{
			if (!(base.Data.Part.PartType.Id == "Generator2"))
			{
				return;
			}
			Transform transform = base.transform.Find("Scalar");
			if (transform != null)
			{
				Transform transform2 = transform.Find("Base");
				Transform transform3 = transform.Find("Mesh");
				if (transform2 != null && transform3 != null)
				{
					transform2.gameObject.SetActive(!base.Data.HideBase);
					transform3.localPosition = new Vector3(0f, base.Data.HideBase ? 0f : 0.108f, 0f);
				}
			}
		}

		public void UpdateScale()
		{
			Transform transform = base.transform.Find("Scalar");
			if (!(transform != null))
			{
				return;
			}
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 0.8f * base.Data.Scale;
			}
			transform.localScale = Vector3.one * base.Data.Scale;
		}

		public void UpdateStretch()
		{
			if (base.Data.Part.PartType.Id == "Generator2")
			{
				Transform transform = base.transform.Find("Scalar").Find("Mesh");
				if (transform != null)
				{
					transform.localScale = new Vector3(0.12f, 0.12f + 0.06f * base.Data.Stretch, 0.12f);
				}
			}
		}

		public override void ValidatePart(ValidationResult result)
		{
			if (base.Data.FuelFlow > 0f && _fuelSource != null)
			{
				result.ValidatFuel(this, _fuelSource);
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			UpdateBase();
			UpdateScale();
			UpdateStretch();
		}

		private void ConfigureAudio()
		{
			float t = 0.25f * base.Data.Scale;
			float basePitch = Mathf.Lerp(2f, 1f, t);
			float baseVolume = Mathf.Lerp(0.5f, 2f, t) * base.Data.SoundVolume;
			float distanceScale = Mathf.Lerp(0.1f, 0.5f, t);
			_audio.Configure(basePitch, baseVolume, distanceScale);
		}

		private void CreateInspectorModel(GroupModel model, bool flight)
		{
			model.Add(new TextModel("Power", () => Units.GetPowerString(flight ? ((float)_powerGenerated) : base.Data.MaxPowerGenerated(base.Data.FuelFlow)), null, "The power being generated per second."));
			if (base.Data.FuelType == null)
			{
				return;
			}
			model.Add(new TextModel("Fuel Flow", () => Units.GetMassFlowRateString((flight ? ((float)_fuelRemoved) : base.Data.FuelFlow) * base.Data.FuelType.Density), null, "The kilograms of fuel being burnt per second."));
			model.Add(new TextModel("Fuel Type", () => base.Data.FuelType.Name, null, "The name of the fuel being burnt."));
			if (flight)
			{
				model.Add(new SliderModel("Power Scale", () => _powerScale, delegate(float x)
				{
					_powerScale = Mathf.Clamp01(x);
				}));
			}
		}

		private void OnCraftFuelSourceChanged(object sender, EventArgs e)
		{
			RefreshFuelSource();
		}

		private void RefreshFuelSource()
		{
			if (base.Data.FuelType == FuelTank?.CraftFuelSource?.FuelType)
			{
				_fuelSource = FuelTank?.CraftFuelSource;
			}
			else if (base.Data.FuelType != null)
			{
				_fuelSource = EmptyFuelSource.GetOrCreate(base.Data.FuelType);
			}
		}
	}
}
