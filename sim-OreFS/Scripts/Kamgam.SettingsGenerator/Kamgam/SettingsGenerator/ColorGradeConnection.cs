using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class ColorGradeConnection : Connection<float>
	{
		public enum ColorGradeEffect
		{
			[InspectorName("[na] Brigthness")]
			Brightness = 1,
			[InspectorName("Gain   (-1 to 1)")]
			Gain = 3,
			[InspectorName("Gamma   (-1 to 1)")]
			Gamma = 4,
			[InspectorName("Lift   (-1 to 1)")]
			Lift = 5,
			[InspectorName("PostExposure   (-10 to 10)")]
			PostExposure = 17,
			[InspectorName("Saturation   (-100 to 100)")]
			Saturation = 18,
			[InspectorName("[na] ColorFilter")]
			ColorFilter = 27,
			[InspectorName("Contrast   (-100 to 100 or more)")]
			Contrast = 2,
			[InspectorName("HueShift   (-175 to 175)")]
			HueShift = 6,
			[InspectorName("[na] LdrLutContribution")]
			LdrLutContribution = 7,
			[InspectorName("MixerBlueOutBlueIn   (-200 to 200)")]
			MixerBlueOutBlueIn = 8,
			MixerBlueOutGreenIn = 9,
			MixerBlueOutRedIn = 10,
			MixerGreenOutBlueIn = 11,
			MixerGreenOutGreenIn = 12,
			MixerGreenOutRedIn = 13,
			MixerRedOutBlueIn = 14,
			MixerRedOutGreenIn = 15,
			MixerRedOutRedIn = 16,
			[InspectorName("Temperature   (-100 to 100)")]
			Temperature = 19,
			[InspectorName("Tint   (-100 to 100)")]
			Tint = 20,
			[InspectorName("[na] ToneCurveGamma")]
			ToneCurveGamma = 21,
			[InspectorName("[na] ToneCurveShoulderAngle")]
			ToneCurveShoulderAngle = 22,
			[InspectorName("[na] ToneCurveShoulderLength")]
			ToneCurveShoulderLength = 23,
			[InspectorName("[na] ToneCurveShoulderStrength")]
			ToneCurveShoulderStrength = 24,
			[InspectorName("[na] ToneCurveToeLength")]
			ToneCurveToeLength = 25,
			[InspectorName("[na] ToneCurveToeStrength")]
			ToneCurveToeStrength = 26,
			[InspectorName("SMH Shadows   (-1 to 1)")]
			SMHShadows = 28,
			[InspectorName("SMH Midtones   (-1 to 1)")]
			SMHMidtones = 29,
			[InspectorName("SMH Highlights   (-1 to 1)")]
			SMHHighlights = 30
		}

		protected ColorGradeEffect _effect;

		protected LiftGammaGain _liftGammaGain;

		protected ColorAdjustments _colorAdjustment;

		protected ChannelMixer _channelMixer;

		protected WhiteBalance _whiteBalance;

		protected ShadowsMidtonesHighlights _shadowsMidtonesHighlights;

		public float _defaultValue;

		public ColorGradeEffect Effect => _effect;

		public static bool IsLiftGammaGain(ColorGradeEffect effect)
		{
			if (effect != ColorGradeEffect.Lift && effect != ColorGradeEffect.Gamma)
			{
				return effect == ColorGradeEffect.Gain;
			}
			return true;
		}

		public static bool IsColorAdjustment(ColorGradeEffect effect)
		{
			if (effect != ColorGradeEffect.PostExposure && effect != ColorGradeEffect.Saturation && effect != ColorGradeEffect.Contrast)
			{
				return effect == ColorGradeEffect.HueShift;
			}
			return true;
		}

		public static bool IsChannelMixer(ColorGradeEffect effect)
		{
			if (effect != ColorGradeEffect.MixerBlueOutBlueIn && effect != ColorGradeEffect.MixerBlueOutGreenIn && effect != ColorGradeEffect.MixerBlueOutRedIn && effect != ColorGradeEffect.MixerGreenOutBlueIn && effect != ColorGradeEffect.MixerGreenOutGreenIn && effect != ColorGradeEffect.MixerGreenOutRedIn && effect != ColorGradeEffect.MixerRedOutBlueIn && effect != ColorGradeEffect.MixerRedOutGreenIn)
			{
				return effect == ColorGradeEffect.MixerRedOutRedIn;
			}
			return true;
		}

		public static bool IsWhiteBalance(ColorGradeEffect effect)
		{
			if (effect != ColorGradeEffect.Temperature)
			{
				return effect == ColorGradeEffect.Tint;
			}
			return true;
		}

		public static bool IsShadowsMidtonesHighlights(ColorGradeEffect effect)
		{
			if (effect != ColorGradeEffect.SMHShadows && effect != ColorGradeEffect.SMHMidtones)
			{
				return effect == ColorGradeEffect.SMHHighlights;
			}
			return true;
		}

		public ColorGradeConnection(ColorGradeEffect effect = ColorGradeEffect.Gamma)
		{
			if (!(SettingsVolume.Instance == null))
			{
				_effect = effect;
				if (IsLiftGammaGain(_effect))
				{
					_liftGammaGain = SettingsVolume.Instance.GetOrAddComponent<LiftGammaGain>();
					_liftGammaGain.Override(_liftGammaGain, 1f);
					_liftGammaGain.active = false;
				}
				else if (IsColorAdjustment(_effect))
				{
					_colorAdjustment = SettingsVolume.Instance.GetOrAddComponent<ColorAdjustments>();
					_colorAdjustment.Override(_colorAdjustment, 1f);
					_colorAdjustment.active = false;
				}
				else if (IsChannelMixer(_effect))
				{
					_channelMixer = SettingsVolume.Instance.GetOrAddComponent<ChannelMixer>();
					_channelMixer.blueOutBlueIn.value = 100f;
					_channelMixer.redOutRedIn.value = 100f;
					_channelMixer.greenOutGreenIn.value = 100f;
					_channelMixer.Override(_channelMixer, 1f);
					_channelMixer.active = false;
				}
				else if (IsWhiteBalance(_effect))
				{
					_whiteBalance = SettingsVolume.Instance.GetOrAddComponent<WhiteBalance>();
					_whiteBalance.Override(_whiteBalance, 1f);
					_whiteBalance.active = false;
				}
				else if (IsShadowsMidtonesHighlights(_effect))
				{
					_shadowsMidtonesHighlights = SettingsVolume.Instance.GetOrAddComponent<ShadowsMidtonesHighlights>();
					_shadowsMidtonesHighlights.Override(_shadowsMidtonesHighlights, 1f);
					_shadowsMidtonesHighlights.active = false;
				}
				else
				{
					Logger.LogWarning("The '" + _effect.ToString() + "' color grading effect is not supported in the universal render pipeline.");
				}
				UpdateDefaultValue();
			}
		}

		public void UpdateDefaultValue()
		{
			if (IsLiftGammaGain(_effect))
			{
				LiftGammaGain liftGammaGain = SettingsVolume.Instance.FindDefaultVolumeComponent<LiftGammaGain>();
				if (liftGammaGain == null || !liftGammaGain.active)
				{
					_defaultValue = 0f;
				}
				else if (_effect == ColorGradeEffect.Lift)
				{
					_defaultValue = liftGammaGain.lift.value.w;
				}
				else if (_effect == ColorGradeEffect.Gamma)
				{
					_defaultValue = liftGammaGain.gamma.value.w;
				}
				else if (_effect == ColorGradeEffect.Gain)
				{
					_defaultValue = liftGammaGain.gain.value.w;
				}
			}
			else if (IsColorAdjustment(_effect))
			{
				ColorAdjustments colorAdjustments = SettingsVolume.Instance.FindDefaultVolumeComponent<ColorAdjustments>();
				if (colorAdjustments == null || !colorAdjustments.active)
				{
					_defaultValue = 0f;
				}
				else if (_effect == ColorGradeEffect.PostExposure && colorAdjustments.postExposure.overrideState)
				{
					_defaultValue = colorAdjustments.postExposure.value;
				}
				else if (_effect == ColorGradeEffect.Saturation && colorAdjustments.saturation.overrideState)
				{
					_defaultValue = colorAdjustments.saturation.value;
				}
				else if (_effect == ColorGradeEffect.Contrast && colorAdjustments.contrast.overrideState)
				{
					_defaultValue = colorAdjustments.contrast.value;
				}
				else if (_effect == ColorGradeEffect.HueShift && colorAdjustments.hueShift.overrideState)
				{
					_defaultValue = colorAdjustments.hueShift.value;
				}
			}
			else if (IsChannelMixer(_effect))
			{
				ChannelMixer channelMixer = SettingsVolume.Instance.FindDefaultVolumeComponent<ChannelMixer>();
				if (channelMixer == null || !channelMixer.active)
				{
					if (_effect == ColorGradeEffect.MixerBlueOutBlueIn || _effect == ColorGradeEffect.MixerGreenOutGreenIn || _effect == ColorGradeEffect.MixerRedOutRedIn)
					{
						_defaultValue = 100f;
					}
					else
					{
						_defaultValue = 0f;
					}
				}
				else if (_effect == ColorGradeEffect.MixerBlueOutBlueIn && channelMixer.blueOutBlueIn.overrideState)
				{
					_defaultValue = channelMixer.blueOutBlueIn.value;
				}
				else if (_effect == ColorGradeEffect.MixerBlueOutGreenIn && channelMixer.blueOutGreenIn.overrideState)
				{
					_defaultValue = channelMixer.blueOutGreenIn.value;
				}
				else if (_effect == ColorGradeEffect.MixerBlueOutRedIn && channelMixer.blueOutRedIn.overrideState)
				{
					_defaultValue = channelMixer.blueOutRedIn.value;
				}
				else if (_effect == ColorGradeEffect.MixerGreenOutBlueIn && channelMixer.greenOutBlueIn.overrideState)
				{
					_defaultValue = channelMixer.greenOutBlueIn.value;
				}
				else if (_effect == ColorGradeEffect.MixerGreenOutGreenIn && channelMixer.greenOutGreenIn.overrideState)
				{
					_defaultValue = channelMixer.greenOutGreenIn.value;
				}
				else if (_effect == ColorGradeEffect.MixerGreenOutRedIn && channelMixer.greenOutRedIn.overrideState)
				{
					_defaultValue = channelMixer.greenOutRedIn.value;
				}
				else if (_effect == ColorGradeEffect.MixerRedOutBlueIn && channelMixer.redOutBlueIn.overrideState)
				{
					_defaultValue = channelMixer.redOutBlueIn.value;
				}
				else if (_effect == ColorGradeEffect.MixerRedOutGreenIn && channelMixer.redOutGreenIn.overrideState)
				{
					_defaultValue = channelMixer.redOutGreenIn.value;
				}
				else if (_effect == ColorGradeEffect.MixerRedOutRedIn && channelMixer.redOutRedIn.overrideState)
				{
					_defaultValue = channelMixer.redOutRedIn.value;
				}
			}
			else if (IsWhiteBalance(_effect))
			{
				WhiteBalance whiteBalance = SettingsVolume.Instance.FindDefaultVolumeComponent<WhiteBalance>();
				if (whiteBalance == null || !whiteBalance.active)
				{
					_defaultValue = 0f;
				}
				else if (_effect == ColorGradeEffect.Temperature && whiteBalance.temperature.overrideState)
				{
					_defaultValue = whiteBalance.temperature.value;
				}
				else if (_effect == ColorGradeEffect.Tint && whiteBalance.tint.overrideState)
				{
					_defaultValue = whiteBalance.tint.value;
				}
			}
			else if (IsShadowsMidtonesHighlights(_effect))
			{
				ShadowsMidtonesHighlights shadowsMidtonesHighlights = SettingsVolume.Instance.FindDefaultVolumeComponent<ShadowsMidtonesHighlights>();
				if (shadowsMidtonesHighlights == null || !shadowsMidtonesHighlights.active)
				{
					_defaultValue = 0f;
				}
				else if (_effect == ColorGradeEffect.SMHShadows && shadowsMidtonesHighlights.shadows.overrideState)
				{
					_defaultValue = shadowsMidtonesHighlights.shadows.value.w;
				}
				else if (_effect == ColorGradeEffect.SMHMidtones && shadowsMidtonesHighlights.midtones.overrideState)
				{
					_defaultValue = shadowsMidtonesHighlights.midtones.value.w;
				}
				else if (_effect == ColorGradeEffect.SMHHighlights && shadowsMidtonesHighlights.highlights.overrideState)
				{
					_defaultValue = shadowsMidtonesHighlights.highlights.value.w;
				}
			}
		}

		public override float Get()
		{
			if (IsLiftGammaGain(_effect))
			{
				if (_liftGammaGain == null || !_liftGammaGain.active)
				{
					return _defaultValue;
				}
				if (_effect == ColorGradeEffect.Lift && _liftGammaGain.lift.overrideState)
				{
					return _liftGammaGain.lift.value.w;
				}
				if (_effect == ColorGradeEffect.Gamma && _liftGammaGain.gamma.overrideState)
				{
					return _liftGammaGain.gamma.value.w;
				}
				if (_effect == ColorGradeEffect.Gain && _liftGammaGain.gain.overrideState)
				{
					return _liftGammaGain.gain.value.w;
				}
			}
			else if (IsColorAdjustment(_effect))
			{
				if (_colorAdjustment == null || !_colorAdjustment.active)
				{
					return _defaultValue;
				}
				if (_effect == ColorGradeEffect.PostExposure && _colorAdjustment.postExposure.overrideState)
				{
					return _colorAdjustment.postExposure.value;
				}
				if (_effect == ColorGradeEffect.Saturation && _colorAdjustment.saturation.overrideState)
				{
					return _colorAdjustment.saturation.value;
				}
				if (_effect == ColorGradeEffect.Contrast && _colorAdjustment.contrast.overrideState)
				{
					return _colorAdjustment.contrast.value;
				}
				if (_effect == ColorGradeEffect.HueShift && _colorAdjustment.hueShift.overrideState)
				{
					return _colorAdjustment.hueShift.value;
				}
			}
			else if (IsChannelMixer(_effect))
			{
				if (_channelMixer == null || !_channelMixer.active)
				{
					return _defaultValue;
				}
				if (_effect == ColorGradeEffect.MixerBlueOutBlueIn && _channelMixer.blueOutBlueIn.overrideState)
				{
					return _channelMixer.blueOutBlueIn.value;
				}
				if (_effect == ColorGradeEffect.MixerBlueOutGreenIn && _channelMixer.blueOutGreenIn.overrideState)
				{
					return _channelMixer.blueOutGreenIn.value;
				}
				if (_effect == ColorGradeEffect.MixerBlueOutRedIn && _channelMixer.blueOutRedIn.overrideState)
				{
					return _channelMixer.blueOutRedIn.value;
				}
				if (_effect == ColorGradeEffect.MixerGreenOutBlueIn && _channelMixer.greenOutBlueIn.overrideState)
				{
					return _channelMixer.greenOutBlueIn.value;
				}
				if (_effect == ColorGradeEffect.MixerGreenOutGreenIn && _channelMixer.greenOutGreenIn.overrideState)
				{
					return _channelMixer.greenOutGreenIn.value;
				}
				if (_effect == ColorGradeEffect.MixerGreenOutRedIn && _channelMixer.greenOutRedIn.overrideState)
				{
					return _channelMixer.greenOutRedIn.value;
				}
				if (_effect == ColorGradeEffect.MixerRedOutBlueIn && _channelMixer.redOutBlueIn.overrideState)
				{
					return _channelMixer.redOutBlueIn.value;
				}
				if (_effect == ColorGradeEffect.MixerRedOutGreenIn && _channelMixer.redOutGreenIn.overrideState)
				{
					return _channelMixer.redOutGreenIn.value;
				}
				if (_effect == ColorGradeEffect.MixerRedOutRedIn && _channelMixer.redOutRedIn.overrideState)
				{
					return _channelMixer.redOutRedIn.value;
				}
			}
			else if (IsWhiteBalance(_effect))
			{
				if (_whiteBalance == null || !_whiteBalance.active)
				{
					return _defaultValue;
				}
				if (_effect == ColorGradeEffect.Temperature && _whiteBalance.temperature.overrideState)
				{
					return _whiteBalance.temperature.value;
				}
				if (_effect == ColorGradeEffect.Tint && _whiteBalance.tint.overrideState)
				{
					return _whiteBalance.tint.value;
				}
			}
			else if (IsShadowsMidtonesHighlights(_effect))
			{
				if (_shadowsMidtonesHighlights == null || !_shadowsMidtonesHighlights.active)
				{
					return _defaultValue;
				}
				if (_effect == ColorGradeEffect.SMHShadows && _shadowsMidtonesHighlights.shadows.overrideState)
				{
					return _shadowsMidtonesHighlights.shadows.value.w;
				}
				if (_effect == ColorGradeEffect.SMHMidtones && _shadowsMidtonesHighlights.midtones.overrideState)
				{
					return _shadowsMidtonesHighlights.midtones.value.w;
				}
				if (_effect == ColorGradeEffect.SMHHighlights && _shadowsMidtonesHighlights.highlights.overrideState)
				{
					return _shadowsMidtonesHighlights.highlights.value.w;
				}
			}
			return _defaultValue;
		}

		public override void Set(float value)
		{
			if (IsLiftGammaGain(_effect))
			{
				if (_liftGammaGain == null)
				{
					return;
				}
				_liftGammaGain.active = true;
				Vector4 x = new Vector4(1f, 1f, 1f, _defaultValue);
				x.w = value;
				if (_effect == ColorGradeEffect.Lift)
				{
					_liftGammaGain.lift.Override(x);
				}
				else if (_effect == ColorGradeEffect.Gamma)
				{
					_liftGammaGain.gamma.Override(x);
				}
				else if (_effect == ColorGradeEffect.Gain)
				{
					_liftGammaGain.gain.Override(x);
				}
			}
			else if (IsColorAdjustment(_effect))
			{
				if (_colorAdjustment == null)
				{
					return;
				}
				_colorAdjustment.active = true;
				if (_effect == ColorGradeEffect.PostExposure)
				{
					_colorAdjustment.postExposure.Override(value);
				}
				else if (_effect == ColorGradeEffect.Saturation)
				{
					_colorAdjustment.saturation.Override(value);
				}
				else if (_effect == ColorGradeEffect.Contrast)
				{
					_colorAdjustment.contrast.Override(value);
				}
				else if (_effect == ColorGradeEffect.HueShift)
				{
					_colorAdjustment.hueShift.Override(value);
				}
			}
			else if (IsChannelMixer(_effect))
			{
				if (_channelMixer == null)
				{
					return;
				}
				_channelMixer.active = true;
				if (_effect == ColorGradeEffect.MixerBlueOutBlueIn)
				{
					_channelMixer.blueOutBlueIn.Override(value);
				}
				else if (_effect == ColorGradeEffect.MixerBlueOutGreenIn)
				{
					_channelMixer.blueOutGreenIn.Override(value);
				}
				else if (_effect == ColorGradeEffect.MixerBlueOutRedIn)
				{
					_channelMixer.blueOutRedIn.Override(value);
				}
				else if (_effect == ColorGradeEffect.MixerGreenOutBlueIn)
				{
					_channelMixer.greenOutBlueIn.Override(value);
				}
				else if (_effect == ColorGradeEffect.MixerGreenOutGreenIn)
				{
					_channelMixer.greenOutGreenIn.Override(value);
				}
				else if (_effect == ColorGradeEffect.MixerGreenOutRedIn)
				{
					_channelMixer.greenOutRedIn.Override(value);
				}
				else if (_effect == ColorGradeEffect.MixerRedOutBlueIn)
				{
					_channelMixer.redOutBlueIn.Override(value);
				}
				else if (_effect == ColorGradeEffect.MixerRedOutGreenIn)
				{
					_channelMixer.redOutGreenIn.Override(value);
				}
				else if (_effect == ColorGradeEffect.MixerRedOutRedIn)
				{
					_channelMixer.redOutRedIn.Override(value);
				}
			}
			else if (IsWhiteBalance(_effect))
			{
				if (_whiteBalance == null)
				{
					return;
				}
				_whiteBalance.active = true;
				if (_effect == ColorGradeEffect.Temperature)
				{
					_whiteBalance.temperature.Override(value);
				}
				else if (_effect == ColorGradeEffect.Tint)
				{
					_whiteBalance.tint.Override(value);
				}
			}
			else if (IsShadowsMidtonesHighlights(_effect))
			{
				if (_shadowsMidtonesHighlights == null)
				{
					return;
				}
				_shadowsMidtonesHighlights.active = true;
				Vector4 x2 = new Vector4(1f, 1f, 1f, _defaultValue);
				x2.w = value;
				if (_effect == ColorGradeEffect.SMHShadows)
				{
					_shadowsMidtonesHighlights.shadows.Override(x2);
				}
				else if (_effect == ColorGradeEffect.SMHMidtones)
				{
					_shadowsMidtonesHighlights.midtones.Override(x2);
				}
				else if (_effect == ColorGradeEffect.SMHHighlights)
				{
					_shadowsMidtonesHighlights.highlights.Override(x2);
				}
			}
			NotifyListenersIfChanged(value);
		}
	}
}
