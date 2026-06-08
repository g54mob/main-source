using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
	public static class DOTweenModuleUI
	{
		public static class Utils
		{
			public static Vector2 SwitchToRectTransform(RectTransform from, RectTransform to)
			{
				Vector2 vector = new Vector2(from.rect.width * 0.5f + from.rect.xMin, from.rect.height * 0.5f + from.rect.yMin);
				Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(null, from.position);
				screenPoint += vector;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(to, screenPoint, null, out var localPoint);
				Vector2 vector2 = new Vector2(to.rect.width * 0.5f + to.rect.xMin, to.rect.height * 0.5f + to.rect.yMin);
				return to.anchoredPosition + localPoint - vector2;
			}
		}

		private sealed class _003C_003Ec__DisplayClass0_0
		{
			public CanvasGroup target;

			internal float _003CDOFade_003Eb__0()
			{
				return target.alpha;
			}

			internal void _003CDOFade_003Eb__1(float x)
			{
				target.alpha = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass1_0
		{
			public Graphic target;

			internal Color _003CDOColor_003Eb__0()
			{
				return target.color;
			}

			internal void _003CDOColor_003Eb__1(Color x)
			{
				target.color = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass2_0
		{
			public Graphic target;

			internal Color _003CDOFade_003Eb__0()
			{
				return target.color;
			}

			internal void _003CDOFade_003Eb__1(Color x)
			{
				target.color = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass3_0
		{
			public Image target;

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
			public Image target;

			internal Color _003CDOFade_003Eb__0()
			{
				return target.color;
			}

			internal void _003CDOFade_003Eb__1(Color x)
			{
				target.color = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass5_0
		{
			public Image target;

			internal float _003CDOFillAmount_003Eb__0()
			{
				return target.fillAmount;
			}

			internal void _003CDOFillAmount_003Eb__1(float x)
			{
				target.fillAmount = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass13_0
		{
			public RectTransform target;

			internal Vector2 _003CDOAnchorPos_003Eb__0()
			{
				return target.anchoredPosition;
			}

			internal void _003CDOAnchorPos_003Eb__1(Vector2 x)
			{
				target.anchoredPosition = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass16_0
		{
			public RectTransform target;

			internal Vector3 _003CDOAnchorPos3D_003Eb__0()
			{
				return target.anchoredPosition3D;
			}

			internal void _003CDOAnchorPos3D_003Eb__1(Vector3 x)
			{
				target.anchoredPosition3D = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass25_0
		{
			public RectTransform target;

			internal Vector2 _003CDOSizeDelta_003Eb__0()
			{
				return target.sizeDelta;
			}

			internal void _003CDOSizeDelta_003Eb__1(Vector2 x)
			{
				target.sizeDelta = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass26_0
		{
			public RectTransform target;

			internal Vector3 _003CDOPunchAnchorPos_003Eb__0()
			{
				return target.anchoredPosition;
			}

			internal void _003CDOPunchAnchorPos_003Eb__1(Vector3 x)
			{
				target.anchoredPosition = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass28_0
		{
			public RectTransform target;

			internal Vector3 _003CDOShakeAnchorPos_003Eb__0()
			{
				return target.anchoredPosition;
			}

			internal void _003CDOShakeAnchorPos_003Eb__1(Vector3 x)
			{
				target.anchoredPosition = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass34_0
		{
			public Text target;

			internal Color _003CDOColor_003Eb__0()
			{
				return target.color;
			}

			internal void _003CDOColor_003Eb__1(Color x)
			{
				target.color = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass36_0
		{
			public Text target;

			internal Color _003CDOFade_003Eb__0()
			{
				return target.color;
			}

			internal void _003CDOFade_003Eb__1(Color x)
			{
				target.color = x;
			}
		}

		private sealed class _003C_003Ec__DisplayClass37_0
		{
			public Text target;

			internal string _003CDOText_003Eb__0()
			{
				return target.text;
			}

			internal void _003CDOText_003Eb__1(string x)
			{
				target.text = x;
			}
		}

		public static TweenerCore<float, float, FloatOptions> DOFade(CanvasGroup target, float endValue, float duration)
		{
			_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass0_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.alpha, delegate(float x)
			{
				CS_0024_003C_003E8__locals4.target.alpha = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOColor(Graphic target, Color endValue, float duration)
		{
			_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass1_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.color, delegate(Color x)
			{
				CS_0024_003C_003E8__locals4.target.color = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOFade(Graphic target, float endValue, float duration)
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass2_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(() => CS_0024_003C_003E8__locals4.target.color, delegate(Color x)
			{
				CS_0024_003C_003E8__locals4.target.color = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOColor(Image target, Color endValue, float duration)
		{
			_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass3_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.color, delegate(Color x)
			{
				CS_0024_003C_003E8__locals4.target.color = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOFade(Image target, float endValue, float duration)
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

		public static TweenerCore<float, float, FloatOptions> DOFillAmount(Image target, float endValue, float duration)
		{
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass5_0();
			CS_0024_003C_003E8__locals4.target = target;
			if (endValue > 1f)
			{
				endValue = 1f;
			}
			else if (endValue < 0f)
			{
				endValue = 0f;
			}
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.fillAmount, delegate(float x)
			{
				CS_0024_003C_003E8__locals4.target.fillAmount = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorPos(RectTransform target, Vector2 endValue, float duration, bool snapping = false)
		{
			_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass13_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.anchoredPosition, delegate(Vector2 x)
			{
				CS_0024_003C_003E8__locals4.target.anchoredPosition = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(TweenSettingsExtensions.SetOptions(tweenerCore, snapping), CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<Vector3, Vector3, VectorOptions> DOAnchorPos3D(RectTransform target, Vector3 endValue, float duration, bool snapping = false)
		{
			_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass16_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.anchoredPosition3D, delegate(Vector3 x)
			{
				CS_0024_003C_003E8__locals4.target.anchoredPosition3D = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(TweenSettingsExtensions.SetOptions(tweenerCore, snapping), CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<Vector2, Vector2, VectorOptions> DOSizeDelta(RectTransform target, Vector2 endValue, float duration, bool snapping = false)
		{
			_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass25_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.sizeDelta, delegate(Vector2 x)
			{
				CS_0024_003C_003E8__locals4.target.sizeDelta = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(TweenSettingsExtensions.SetOptions(tweenerCore, snapping), CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static Tweener DOPunchAnchorPos(RectTransform target, Vector2 punch, float duration, int vibrato = 10, float elasticity = 1f, bool snapping = false)
		{
			_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass26_0();
			CS_0024_003C_003E8__locals4.target = target;
			return TweenSettingsExtensions.SetOptions(TweenSettingsExtensions.SetTarget(DOTween.Punch(() => CS_0024_003C_003E8__locals4.target.anchoredPosition, delegate(Vector3 x)
			{
				CS_0024_003C_003E8__locals4.target.anchoredPosition = x;
			}, punch, duration, vibrato, elasticity), CS_0024_003C_003E8__locals4.target), snapping);
		}

		public static Tweener DOShakeAnchorPos(RectTransform target, float duration, Vector2 strength, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true)
		{
			_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass28_0();
			CS_0024_003C_003E8__locals4.target = target;
			return TweenSettingsExtensions.SetOptions(Extensions.SetSpecialStartupMode(TweenSettingsExtensions.SetTarget(DOTween.Shake(() => CS_0024_003C_003E8__locals4.target.anchoredPosition, delegate(Vector3 x)
			{
				CS_0024_003C_003E8__locals4.target.anchoredPosition = x;
			}, duration, strength, vibrato, randomness, fadeOut), CS_0024_003C_003E8__locals4.target), SpecialStartupMode.SetShake), snapping);
		}

		public static TweenerCore<Color, Color, ColorOptions> DOColor(Text target, Color endValue, float duration)
		{
			_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass34_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.color, delegate(Color x)
			{
				CS_0024_003C_003E8__locals4.target.color = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOFade(Text target, float endValue, float duration)
		{
			_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass36_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(() => CS_0024_003C_003E8__locals4.target.color, delegate(Color x)
			{
				CS_0024_003C_003E8__locals4.target.color = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<string, string, StringOptions> DOText(Text target, string endValue, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
		{
			_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass37_0();
			CS_0024_003C_003E8__locals4.target = target;
			if (endValue == null)
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogWarning("You can't pass a NULL string to DOText: an empty string will be used instead to avoid errors");
				}
				endValue = "";
			}
			TweenerCore<string, string, StringOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.text, delegate(string x)
			{
				CS_0024_003C_003E8__locals4.target.text = x;
			}, endValue, duration);
			TweenSettingsExtensions.SetTarget(TweenSettingsExtensions.SetOptions(tweenerCore, richTextEnabled, scrambleMode, scrambleChars), CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}
	}
}
