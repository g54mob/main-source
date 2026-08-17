using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using VampireSurvivors.Data.Characters;

namespace VampireSurvivors.Objects;

public class SineBonus : IDisposable
{
	private float _sine;

	private Tween _sineTween;

	private SineBonusData _sineBonusData;

	public float Value
	{
		get
		{
			//IL_0015: Invalid comparison between F4 and I4
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_0154: Expected O, but got I4
			//IL_0041: Invalid comparison between I4 and F4
			//IL_00fa: Invalid comparison between O and F4
			//IL_00b8: Expected F4, but got I4
			SineBonusData sineBonusData = _sineBonusData;
			if (_sine > 0f)
			{
				float num = _sine;
				if (!(0f > _sine))
				{
					if (num > 1f)
					{
						float num2 = sineBonusData._003Cmax_003Ek__BackingField - 1f;
						float num3 = num2 * 1f;
						return num3 + 1f;
					}
				}
				else
				{
					num = 0f;
				}
				float num4 = sineBonusData._003Cmax_003Ek__BackingField - 1f;
				float num5 = num4 * num;
				return num5 + 1f;
			}
			float sine = _sine;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = sine ^ 0;
			if (0 <= (nint)obj)
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
				{
					float num6 = sineBonusData._003Cmin_003Ek__BackingField - 1f;
					float num7 = num6 * 1f;
					return num7 + 1f;
				}
			}
			else
			{
				obj = 0;
			}
			float num8 = sineBonusData._003Cmin_003Ek__BackingField - 1f;
			float num9 = num8 * (float)obj;
			return num9 + 1f;
		}
	}

	public void Start(SineBonusData data)
	{
		_sineBonusData = data;
		_sine = -1f;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((SineBonus)(object)dOSetter)._003CStart_003Eb__5_1(x);
		SineBonusData sineBonusData = _sineBonusData;
		float duration = sineBonusData._003Cduration_003Ek__BackingField * 0.001f;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_sineTween = tweenerCore;
	}

	public void Dispose()
	{
		if (_sineTween != null)
		{
			TweenExtensions.Kill(_sineTween);
		}
	}

	private float _003CStart_003Eb__5_0()
	{
		return _sine;
	}

	private void _003CStart_003Eb__5_1(float x)
	{
		_sine = x;
	}
}
