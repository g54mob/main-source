using System;
using Cysharp.Text;
using LitMotion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class LitMotionExtensions
{
	private const string DefaultFormat = "{0}";

	public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<double, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<double, TOptions>
	{
		return builder.BindToText(text, "{0}");
	}

	public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<double, TOptions, TAdapter> builder, TMP_Text text, string format) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<double, TOptions>
	{
		return builder.Bind(text, format, delegate(double x, TMP_Text tMP_Text, string format2)
		{
			if ((bool)tMP_Text)
			{
				tMP_Text.SetTextFormat(format2, x);
			}
		});
	}

	public static MotionHandle BindToTextDimLeadingZeros<TOptions, TAdapter>(this MotionBuilder<double, TOptions, TAdapter> builder, TMP_Text text, string format, float dimAlpha) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<double, TOptions>
	{
		return builder.Bind(text, format, delegate(double x, TMP_Text tMP_Text, string format2)
		{
			if ((bool)tMP_Text)
			{
				tMP_Text.SetTextFormat(format2, x);
				LeadingZerosDimmer.ApplyDim(tMP_Text, dimAlpha);
			}
		});
	}

	public static MotionHandle BindToSliderNormalized<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Slider slider) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
	{
		return builder.Bind(slider, delegate(float t, Slider slider2)
		{
			if ((bool)slider2)
			{
				slider2.normalizedValue = t;
			}
		});
	}

	public static MotionHandle BindToAudioSourceVolume<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, AudioSource audioSource, float targetVolume) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
	{
		return builder.Bind<float, TOptions, TAdapter, (AudioSource, float)>((audioSource, targetVolume), (Action<float, (AudioSource, float)>)delegate(float t, (AudioSource audioSource, float targetVolume) state)
		{
			if ((bool)state.audioSource)
			{
				state.audioSource.volume = state.targetVolume * t;
			}
		});
	}
}
