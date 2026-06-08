using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

namespace DG.Tweening
{
	public static class ShortcutExtensionsTMPText
	{
		private sealed class _003C_003Ec__DisplayClass0_0
		{
			public TMP_Text target;

			internal Color _003CDOColor_003Eb__0()
			{
				return target.color;
			}

			internal void _003CDOColor_003Eb__1(Color x)
			{
				target.color = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass4_0
		{
			public TMP_Text target;

			internal Color _003CDOFade_003Eb__0()
			{
				return target.color;
			}

			internal void _003CDOFade_003Eb__1(Color x)
			{
				target.color = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass10_0
		{
			public TMP_Text target;

			internal string _003CDOText_003Eb__0()
			{
				return target.text;
			}

			internal void _003CDOText_003Eb__1(string x)
			{
				target.text = x;
			}
		}

		public static TweenerCore<Color, Color, ColorOptions> DOColor(TMP_Text target, Color endValue, float duration)
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

		public static TweenerCore<Color, Color, ColorOptions> DOFade(TMP_Text target, float endValue, float duration)
		{
			_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass4_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(() => CS_0024_003C_003E8__locals4.target.color, delegate(Color x)
			{
				CS_0024_003C_003E8__locals4.target.color = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<string, string, StringOptions> DOText(TMP_Text target, string endValue, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
		{
			_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass10_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<string, string, StringOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.text, delegate(string x)
			{
				CS_0024_003C_003E8__locals4.target.text = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(TweenSettingsExtensions.SetOptions(tweenerCore, richTextEnabled, scrambleMode, scrambleChars), CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}
	}
}
