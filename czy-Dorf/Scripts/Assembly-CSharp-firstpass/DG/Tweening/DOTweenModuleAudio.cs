using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	public static class DOTweenModuleAudio
	{
		private sealed class _003C_003Ec__DisplayClass0_0
		{
			public AudioSource target;

			internal float _003CDOFade_003Eb__0()
			{
				return target.volume;
			}

			internal void _003CDOFade_003Eb__1(float x)
			{
				target.volume = x;
			}
		}

		public static TweenerCore<float, float, FloatOptions> DOFade(AudioSource target, float endValue, float duration)
		{
			_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass0_0();
			CS_0024_003C_003E8__locals4.target = target;
			if (endValue < 0f)
			{
				endValue = 0f;
			}
			else if (endValue > 1f)
			{
				endValue = 1f;
			}
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.volume, delegate(float x)
			{
				CS_0024_003C_003E8__locals4.target.volume = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}
	}
}
