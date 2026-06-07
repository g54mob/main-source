using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;

namespace ModApi.Settings
{
	public class ExplosionsQualitySettings : SettingsCategory<ExplosionsQualitySettings>
	{
		public enum CollidersQuality
		{
			[EnumOption("Colliders will be disabled for explosion debris.  It will just fall right through stuff, but will be faster.")]
			Off = 0,
			[EnumOption("Explosions debris will contain a physics collider.  It won't fall through objects.")]
			On = 1
		}

		public enum DebrisRetentionQuality
		{
			[EnumOption("Debris are aggressively discarded, including medium and some larger pieces.")]
			Low = 0,
			[EnumOption("Fewer large debris are discarded, but some medium pieces still are.")]
			Medium = 1,
			[EnumOption("Only the smaller debris will be discarded.")]
			High = 2,
			[EnumOption("Similar to high setting except some parts which would never have debris will have it now.")]
			Ultra = 3
		}

		public enum PartFracturingSizeQuality
		{
			[EnumOption("Exploded parts will not fracture into smaller pieces.")]
			Off = 0,
			[EnumOption("Parts will fracture into fewer, large parts.")]
			Large = 1,
			[EnumOption("Parts will fracture into more, smaller parts.")]
			Medium = 2,
			[EnumOption("Parts will fracture into many, even smaller parts.")]
			Small = 3
		}

		public enum ParticleEffectQuality
		{
			[EnumOption("A less taxing particle effect shader")]
			Medium = 0,
			[EnumOption("Higher quality shader that responds to light conditions and have volumetric effects.")]
			High = 1
		}

		public EnumSetting<CollidersQuality> Colliders { get; private set; }

		public NumericSetting<int> DebrisLifeTime { get; private set; }

		public EnumSetting<DebrisRetentionQuality> DebrisRetention { get; private set; }

		public BoolSetting EnableExplosionEffects { get; private set; }

		public EnumSetting<PartFracturingSizeQuality> PartFracturing { get; private set; }

		public EnumSetting<ParticleEffectQuality> ParticleEffect { get; private set; }

		public NumericSetting<float> ParticleEffectFrequency { get; private set; }

		public NumericSetting<float> ParticleEffectLightFrequency { get; private set; }

		public ExplosionsQualitySettings()
			: base("Explosions")
		{
			RegisterPresetList(SettingsCategoryPreset.Off, SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Custom);
		}

		public override SettingsCategoryPreset GetDefaultPreset()
		{
			DeviceFlags flags = CurrentDevice.Flags;
			if (flags.HasFlag(DeviceFlags.LowEnd))
			{
				return SettingsCategoryPreset.Medium;
			}
			return SettingsCategoryPreset.High;
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			if (preset != SettingsCategoryPreset.Custom)
			{
				EnableExplosionEffects.Value = true;
				switch (preset)
				{
				case SettingsCategoryPreset.High:
					Colliders.Value = CollidersQuality.On;
					DebrisLifeTime.Value = 30;
					DebrisRetention.Value = DebrisRetentionQuality.High;
					PartFracturing.Value = PartFracturingSizeQuality.Small;
					ParticleEffect.Value = ParticleEffectQuality.High;
					ParticleEffectFrequency.Value = 0.1f;
					ParticleEffectLightFrequency.Value = 0f;
					break;
				case SettingsCategoryPreset.Medium:
					Colliders.Value = CollidersQuality.On;
					DebrisLifeTime.Value = 20;
					DebrisRetention.Value = DebrisRetentionQuality.Medium;
					PartFracturing.Value = PartFracturingSizeQuality.Medium;
					ParticleEffect.Value = ParticleEffectQuality.Medium;
					ParticleEffectFrequency.Value = 0.04f;
					ParticleEffectLightFrequency.Value = 0f;
					break;
				case SettingsCategoryPreset.Off:
					EnableExplosionEffects.Value = false;
					break;
				default:
					Colliders.Value = CollidersQuality.On;
					DebrisLifeTime.Value = 10;
					DebrisRetention.Value = DebrisRetentionQuality.Low;
					PartFracturing.Value = PartFracturingSizeQuality.Large;
					ParticleEffect.Value = ParticleEffectQuality.Medium;
					ParticleEffectFrequency.Value = 0f;
					ParticleEffectLightFrequency.Value = 0f;
					break;
				}
			}
		}

		protected override void InitializeSettings()
		{
			EnableExplosionEffects = CreateBool("Enable Explosion Effects").SetDescription("If disabled, enhanced explosion effects will be completely disabled.").SetState(SettingState.Hidden);
			DebrisLifeTime = CreateNumeric("Debris Lifetime", 5, 60, 1).SetDescription("The lifetime (in seconds) of explosion debris.");
			Colliders = CreateEnum<CollidersQuality>("Debris Colliders").SetDescription("Sets the quality of physics colliders for debris pieces.");
			DebrisRetention = CreateEnum<DebrisRetentionQuality>("Debris Retention").SetDescription("We will discard pieces that are smaller than a certain size (which is determined by this setting).");
			PartFracturing = CreateEnum<PartFracturingSizeQuality>("Part Fracturing").SetDescription("Controls the size and number of pieces parts will explode into. Larger pieces means there are fewer of them and therefore increases performance.");
			ParticleEffect = CreateEnum<ParticleEffectQuality>("Particle Effect Quality").SetDescription("Sets the quality of the particle effects for explosion debris.");
			ParticleEffectFrequency = CreateNumeric("Particle Effect Frequency", 0f, 1f, 0.01f).SetDescription("Sets the frequency at which particle effects are added to explosion debris. WARNING: Increasing this can severely impact performance. ").AddWarning((float x) => base.Preset == SettingsCategoryPreset.Custom, "Increasing the number of particle effects should be done in small increments to see how your system will handle it.  It has a large impact on performance and could make the game become unresponsive.");
			ParticleEffectLightFrequency = CreateNumeric("Light Frequency", 0f, 1f, 0.01f).SetDescription("Sets the frequency at which lights are added to particles effects.  This value can severely impact performance and may require reducing the particle effect frequency. WARNING: Increasing this can severely impact performance. ").AddWarning((float x) => base.Preset == SettingsCategoryPreset.Custom, "Increasing the number of lights should be done in small increments to see how your system will handle it.  It has a large impact on performance and could make the game become unresponsive.");
			ParticleEffectFrequency.Changed += OnParticleEffectFrequencyChanged;
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
		}

		private void OnParticleEffectFrequencyChanged(object sender, SettingChangedEventArgs<float> e)
		{
			if (e.Setting.Value == 0f)
			{
				SetParticleEffectSettingsEnabled(enabled: false);
			}
			else
			{
				SetParticleEffectSettingsEnabled(enabled: true);
			}
		}

		private void SetParticleEffectSettingsEnabled(bool enabled)
		{
		}
	}
}
