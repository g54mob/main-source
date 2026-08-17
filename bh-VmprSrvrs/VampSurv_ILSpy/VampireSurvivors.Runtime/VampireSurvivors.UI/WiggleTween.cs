using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace VampireSurvivors.UI;

public class WiggleTween
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public float Value;

		public WiggleTween _003C_003E4__this;

		internal float _003CStart_003Eb__0()
		{
			return Value;
		}

		internal void _003CStart_003Eb__1(float x)
		{
			Value = x;
		}

		internal void _003CStart_003Eb__2()
		{
			WiggleTween wiggleTween = _003C_003E4__this;
			wiggleTween.Current = Value;
		}
	}

	public float Current;

	private Tween _tween;

	public void Start(int index)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.Value = -5f;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((_003C_003Ec__DisplayClass2_0)(object)dOSetter)._003CStart_003Eb__1(x);
		TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 5f, 0.5f);
		float delay = (float)index * 0.05f;
		TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
					TweenCallback tweenCallback = delegate
					{
						WiggleTween wiggleTween = CS_0024_003C_003E8__locals6._003C_003E4__this;
						wiggleTween.Current = CS_0024_003C_003E8__locals6.Value;
					};
					tweenCallback2 = tweenCallback;
					goto IL_017e;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			WiggleTween wiggleTween = CS_0024_003C_003E8__locals6._003C_003E4__this;
			wiggleTween.Current = CS_0024_003C_003E8__locals6.Value;
		};
		bool flag = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag)
		{
			goto IL_017e;
		}
		goto IL_01ad;
		IL_017e:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_01ad;
		IL_01ad:
		_tween = tweenerCore;
	}
}
