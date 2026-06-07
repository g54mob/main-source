using ModApi.Settings.Core;
using UnityEngine;

namespace ModApi.Settings
{
	public class PhysicsQualitySettings : SettingsCategory<PhysicsQualitySettings>
	{
		public enum FramerateSpikeReductionQuality
		{
			[EnumOption("Physics simulation will not be slowed down. As a result, you may experience extreme frame-rate dips with larger craft.")]
			Off = 0,
			[EnumOption("During extreme lag spikes, the physics simulation speed will be slowed to allow the frame-rate to recover.")]
			Default = 1,
			[EnumOption("Same as default, except reduction will kick in sooner.  This may result in a smoother frame-rate on faster computers, but may excessively slow down physics simulation on slower computers.")]
			Agressive = 2
		}

		public enum PhysicsUpdateFrequencyQuality
		{
			[EnumOption("Best performance, but some craft may not perform as the designer intended.  Craft may exhibit structural issues, especially load-bearing parts like custom landing gear.")]
			Low = 0,
			[EnumOption("The majority of craft should perform as the designer intended.")]
			Medium = 1,
			[EnumOption("The default update frequency.  All craft should perform as the designer intended.")]
			High = 2,
			[EnumOption("The highest update frequency, but the most CPU intensive.  Larger craft may significantly drop the frame-rate even on fast computers.")]
			Ultra = 3
		}

		public enum RagdollPhysicsQuality
		{
			[EnumOption("The normal rag-doll quality setting.")]
			High = 1,
			[EnumOption("Same as normal except rag-doll animations are updated in sync with physics cycles.  Prevents rag-doll from separating during extreme maneuvers.  Very taxing with multiple rag-dolls, and not recommended.")]
			Ultra = 2
		}

		public enum WaterPhysicsQuality
		{
			[EnumOption("Bare minimum is done to get things to float. Craft may bounce and wobble on the surface more, and we won't calculate precise submerged percentages. Forces are applied per rigid body.")]
			Low = 0,
			[EnumOption("Additional processing is done to give precise submerged percentages.  Forces are applied per-part.")]
			Medium = 1,
			[EnumOption("Further number crunching is performed to make things more stable when resting at the surface.")]
			High = 2
		}

		public BoolSetting EnableDragLift { get; private set; }

		public EnumSetting<FramerateSpikeReductionQuality> FramerateSpikeReduction { get; private set; }

		public NumericSetting<int> PhysicsDistance { get; private set; }

		public EnumSetting<PhysicsUpdateFrequencyQuality> PhysicsUpdateFrequency { get; private set; }

		public EnumSetting<RagdollPhysicsQuality> RagdollPhysics { get; private set; }

		public EnumSetting<WaterPhysicsQuality> WaterPhysics { get; private set; }

		public PhysicsQualitySettings()
			: base("Physics")
		{
			RegisterPresetList(SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Custom);
		}

		public static float GetFixedDeltaTime(PhysicsUpdateFrequencyQuality quality)
		{
			switch (quality)
			{
			case PhysicsUpdateFrequencyQuality.Ultra:
				return 0.01f;
			case PhysicsUpdateFrequencyQuality.High:
				return 1f / 60f;
			case PhysicsUpdateFrequencyQuality.Medium:
				return 1f / 45f;
			case PhysicsUpdateFrequencyQuality.Low:
				return 1f / 30f;
			default:
				Debug.LogError($"Unknown quality setting: {quality}");
				return GetFixedDeltaTime(PhysicsUpdateFrequencyQuality.High);
			}
		}

		public static int GetSolverIterations(PhysicsUpdateFrequencyQuality quality)
		{
			float num = 1f / GetFixedDeltaTime(quality);
			int num2 = (int)(5000f / num);
			switch (quality)
			{
			case PhysicsUpdateFrequencyQuality.Ultra:
				return num2;
			case PhysicsUpdateFrequencyQuality.High:
				return num2;
			case PhysicsUpdateFrequencyQuality.Medium:
				return (int)((float)num2 * 0.8f);
			case PhysicsUpdateFrequencyQuality.Low:
				return (int)((float)num2 * 0.6f);
			default:
				Debug.LogError($"Unknown quality setting: {quality}");
				return GetSolverIterations(PhysicsUpdateFrequencyQuality.High);
			}
		}

		public override SettingsCategoryPreset GetDefaultPreset()
		{
			DeviceFlags flags = CurrentDevice.Flags;
			if (flags.HasFlag(DeviceFlags.LowEndProcessor))
			{
				return SettingsCategoryPreset.Medium;
			}
			return SettingsCategoryPreset.High;
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			if (preset != SettingsCategoryPreset.Custom)
			{
				bool flag = devices.HasFlag(DeviceFlags.Mobile);
				switch (preset)
				{
				case SettingsCategoryPreset.High:
					PhysicsUpdateFrequency.Value = PhysicsUpdateFrequencyQuality.High;
					FramerateSpikeReduction.Value = FramerateSpikeReductionQuality.Default;
					WaterPhysics.Value = WaterPhysicsQuality.High;
					RagdollPhysics.Value = RagdollPhysicsQuality.High;
					PhysicsDistance.Value = (flag ? 3 : 5);
					break;
				case SettingsCategoryPreset.Medium:
					PhysicsUpdateFrequency.Value = PhysicsUpdateFrequencyQuality.Medium;
					FramerateSpikeReduction.Value = FramerateSpikeReductionQuality.Default;
					WaterPhysics.Value = WaterPhysicsQuality.Medium;
					RagdollPhysics.Value = RagdollPhysicsQuality.High;
					PhysicsDistance.Value = 2;
					break;
				default:
					PhysicsUpdateFrequency.Value = PhysicsUpdateFrequencyQuality.Low;
					FramerateSpikeReduction.Value = FramerateSpikeReductionQuality.Default;
					WaterPhysics.Value = WaterPhysicsQuality.Low;
					RagdollPhysics.Value = RagdollPhysicsQuality.High;
					PhysicsDistance.Value = 1;
					break;
				}
				EnableDragLift.Value = true;
			}
		}

		protected override void InitializeSettings()
		{
			PhysicsUpdateFrequency = CreateEnum<PhysicsUpdateFrequencyQuality>("Update Frequency").SetDescription("Sets the frequency of physics updates.The physics simulation gets more accurate at higher settings.Adjusting this setting has large implications to performance and physics accuracy.");
			FramerateSpikeReduction = CreateEnum<FramerateSpikeReductionQuality>("FPS Spike Reduction").SetDescription("This setting allows physics simulation to slow down instead of dropping the frame-rate. When enabled, craft may appear to slow down during intense physics scenarios like during crashes, or may happen frequently if a very large craft is loaded.");
			WaterPhysics = CreateEnum<WaterPhysicsQuality>("Water Physics").SetDescription("Sets the quality of the water physics simulation.");
			RagdollPhysics = CreateEnum<RagdollPhysicsQuality>("Rag-doll Physics").SetDescription("Sets the quality of the rag-doll physics simulation.");
			PhysicsDistance = CreateNumeric("Physics Distance", 1, 10, 1).SetDisplayFormatter((int x) => $"{x} km").SetDescription("The distance in meters at which the physics of other craft become enabled. Note that crafts loaded in far away from the active craft can jitter and become unstable.").SetDefault(2);
			EnableDragLift = CreateBool("Part Lift Forces").SetApplyType(SettingApplyType.RequiresSceneRestart).SetDescription("When enabled, non-wing parts can receive lift forces in addition to drag forces. When disabled, non-wing parts will only receive drag forces.");
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			base.Changed += delegate
			{
				ApplyUnityPhysicsSettings();
			};
			RaiseSettingsChangedEvent();
		}

		private void ApplyUnityPhysicsSettings()
		{
			Physics.defaultSolverIterations = GetSolverIterations(PhysicsUpdateFrequency.Value);
			Time.fixedDeltaTime = GetFixedDeltaTime(PhysicsUpdateFrequency.Value);
			SetFramerateSpikeReduction(FramerateSpikeReduction, GetFixedDeltaTime(PhysicsUpdateFrequency.Value));
		}

		private void SetFramerateSpikeReduction(FramerateSpikeReductionQuality framerateSpikeReduction, float fixedDeltaTime)
		{
			switch (framerateSpikeReduction)
			{
			case FramerateSpikeReductionQuality.Off:
				Time.maximumDeltaTime = 1f / 3f;
				break;
			case FramerateSpikeReductionQuality.Default:
				Time.maximumDeltaTime = 0.1f;
				break;
			case FramerateSpikeReductionQuality.Agressive:
				Time.maximumDeltaTime = 0.05f;
				break;
			default:
				Debug.LogError($"Unknown quality setting: {framerateSpikeReduction}");
				SetFramerateSpikeReduction(FramerateSpikeReductionQuality.Default, fixedDeltaTime);
				break;
			}
		}
	}
}
