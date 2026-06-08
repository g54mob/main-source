using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	public static class DOTweenModuleSprite
	{
		private sealed class _003C_003Ec__DisplayClass0_0
		{
			public SpriteRenderer target;

			internal Color _003CDOColor_003Eb__0()
			{
				return target.color;
			}

			internal void _003CDOColor_003Eb__1(Color x)
			{
				target.color = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass1_0
		{
			public SpriteRenderer target;

			internal Color _003CDOFade_003Eb__0()
			{
				return target.color;
			}

			internal void _003CDOFade_003Eb__1(Color x)
			{
				target.color = x;
			}
		}

		public static TweenerCore<Color, Color, ColorOptions> DOColor(SpriteRenderer target, Color endValue, float duration)
		{
			_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass0_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.color, delegate(Color x)
			{
				CS_0024_003C_003E8__locals4.target.color = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOFade(SpriteRenderer target, float endValue, float duration)
		{
			_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass1_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(() => CS_0024_003C_003E8__locals4.target.color, delegate(Color x)
			{
				CS_0024_003C_003E8__locals4.target.color = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}
	}
}
