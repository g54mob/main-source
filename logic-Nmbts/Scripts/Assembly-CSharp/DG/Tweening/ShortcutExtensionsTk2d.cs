using UnityEngine;

namespace DG.Tweening
{
	public static class ShortcutExtensionsTk2d
	{
		public static Tweener DOScale(this tk2dBaseSprite target, Vector3 endValue, float duration)
		{
			return DOTween.To(() => target.scale, delegate(Vector3 x)
			{
				target.scale = x;
			}, endValue, duration).SetTarget(target);
		}

		public static Tweener DOScaleX(this tk2dBaseSprite target, float endValue, float duration)
		{
			return DOTween.To(() => target.scale, delegate(Vector3 x)
			{
				target.scale = x;
			}, new Vector3(endValue, 0f, 0f), duration).SetOptions(AxisConstraint.X).SetTarget(target);
		}

		public static Tweener DOScaleY(this tk2dBaseSprite target, float endValue, float duration)
		{
			return DOTween.To(() => target.scale, delegate(Vector3 x)
			{
				target.scale = x;
			}, new Vector3(0f, endValue, 0f), duration).SetOptions(AxisConstraint.Y).SetTarget(target);
		}

		public static Tweener DOScaleZ(this tk2dBaseSprite target, float endValue, float duration)
		{
			return DOTween.To(() => target.scale, delegate(Vector3 x)
			{
				target.scale = x;
			}, new Vector3(0f, 0f, endValue), duration).SetOptions(AxisConstraint.Z).SetTarget(target);
		}

		public static Tweener DOColor(this tk2dBaseSprite target, Color endValue, float duration)
		{
			return DOTween.To(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		public static Tweener DOFade(this tk2dBaseSprite target, float endValue, float duration)
		{
			return DOTween.ToAlpha(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		public static Sequence DOGradientColor(this tk2dBaseSprite target, Gradient gradient, float duration)
		{
			Sequence sequence = DOTween.Sequence();
			GradientColorKey[] colorKeys = gradient.colorKeys;
			int num = colorKeys.Length;
			for (int i = 0; i < num; i++)
			{
				GradientColorKey gradientColorKey = colorKeys[i];
				if (i == 0 && gradientColorKey.time <= 0f)
				{
					target.color = gradientColorKey.color;
					continue;
				}
				float duration2 = ((i == num - 1) ? (duration - sequence.Duration(false)) : (duration * ((i == 0) ? gradientColorKey.time : (gradientColorKey.time - colorKeys[i - 1].time))));
				sequence.Append(target.DOColor(gradientColorKey.color, duration2).SetEase(Ease.Linear));
			}
			return sequence;
		}

		public static Tweener DOScaleDimensions(this tk2dSlicedSprite target, Vector2 endValue, float duration)
		{
			return DOTween.To(() => target.dimensions, delegate(Vector2 x)
			{
				target.dimensions = x;
			}, endValue, duration).SetTarget(target);
		}

		public static Tweener DOScaleDimensionsX(this tk2dSlicedSprite target, float endValue, float duration)
		{
			return DOTween.To(() => target.dimensions, delegate(Vector2 x)
			{
				target.dimensions = x;
			}, new Vector2(endValue, 0f), duration).SetOptions(AxisConstraint.X).SetTarget(target);
		}

		public static Tweener DOScaleDimensionsY(this tk2dSlicedSprite target, float endValue, float duration)
		{
			return DOTween.To(() => target.dimensions, delegate(Vector2 x)
			{
				target.dimensions = x;
			}, new Vector2(0f, endValue), duration).SetOptions(AxisConstraint.Y).SetTarget(target);
		}

		public static Tweener DOScale(this tk2dTextMesh target, Vector3 endValue, float duration)
		{
			return DOTween.To(() => target.scale, delegate(Vector3 x)
			{
				target.scale = x;
			}, endValue, duration).SetTarget(target);
		}

		public static Tweener DOScaleX(this tk2dTextMesh target, float endValue, float duration)
		{
			return DOTween.To(() => target.scale, delegate(Vector3 x)
			{
				target.scale = x;
			}, new Vector3(endValue, 0f, 0f), duration).SetOptions(AxisConstraint.X).SetTarget(target);
		}

		public static Tweener DOScaleY(this tk2dTextMesh target, float endValue, float duration)
		{
			return DOTween.To(() => target.scale, delegate(Vector3 x)
			{
				target.scale = x;
			}, new Vector3(0f, endValue, 0f), duration).SetOptions(AxisConstraint.Y).SetTarget(target);
		}

		public static Tweener DOScaleZ(this tk2dTextMesh target, float endValue, float duration)
		{
			return DOTween.To(() => target.scale, delegate(Vector3 x)
			{
				target.scale = x;
			}, new Vector3(0f, 0f, endValue), duration).SetOptions(AxisConstraint.Z).SetTarget(target);
		}

		public static Tweener DOColor(this tk2dTextMesh target, Color endValue, float duration)
		{
			return DOTween.To(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		public static Tweener DOFade(this tk2dTextMesh target, float endValue, float duration)
		{
			return DOTween.ToAlpha(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		public static Sequence DOGradientColor(this tk2dTextMesh target, Gradient gradient, float duration)
		{
			Sequence sequence = DOTween.Sequence();
			GradientColorKey[] colorKeys = gradient.colorKeys;
			int num = colorKeys.Length;
			for (int i = 0; i < num; i++)
			{
				GradientColorKey gradientColorKey = colorKeys[i];
				if (i == 0 && gradientColorKey.time <= 0f)
				{
					target.color = gradientColorKey.color;
					continue;
				}
				float duration2 = ((i == num - 1) ? (duration - sequence.Duration(false)) : (duration * ((i == 0) ? gradientColorKey.time : (gradientColorKey.time - colorKeys[i - 1].time))));
				sequence.Append(target.DOColor(gradientColorKey.color, duration2).SetEase(Ease.Linear));
			}
			return sequence;
		}

		public static Tweener DOText(this tk2dTextMesh target, string endValue, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
		{
			return DOTween.To(() => target.text, delegate(string x)
			{
				target.text = x;
			}, endValue, duration).SetOptions(richTextEnabled, scrambleMode, scrambleChars).SetTarget(target);
		}
	}
}
