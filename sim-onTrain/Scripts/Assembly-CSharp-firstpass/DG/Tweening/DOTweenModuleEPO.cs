using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using EPOOutline;
using UnityEngine;

namespace DG.Tweening
{
	public static class DOTweenModuleEPO
	{
		public static int DOKill(this SerializedPass target, bool complete)
		{
			return DOTween.Kill(target, complete);
		}

		public static TweenerCore<float, float, FloatOptions> DOFloat(this SerializedPass target, string propertyName, float endValue, float duration)
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => target.GetFloat(propertyName), delegate(float x)
			{
				target.SetFloat(propertyName, x);
			}, endValue, duration);
			tweenerCore.SetOptions(snapping: true).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOFade(this SerializedPass target, string propertyName, float endValue, float duration)
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(() => target.GetColor(propertyName), delegate(Color x)
			{
				target.SetColor(propertyName, x);
			}, endValue, duration);
			tweenerCore.SetOptions(alphaOnly: true).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOColor(this SerializedPass target, string propertyName, Color endValue, float duration)
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(() => target.GetColor(propertyName), delegate(Color x)
			{
				target.SetColor(propertyName, x);
			}, endValue, duration);
			tweenerCore.SetOptions(alphaOnly: false).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<Vector4, Vector4, VectorOptions> DOVector(this SerializedPass target, string propertyName, Vector4 endValue, float duration)
		{
			TweenerCore<Vector4, Vector4, VectorOptions> tweenerCore = DOTween.To(() => target.GetVector(propertyName), delegate(Vector4 x)
			{
				target.SetVector(propertyName, x);
			}, endValue, duration);
			tweenerCore.SetOptions(snapping: false).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<float, float, FloatOptions> DOFloat(this SerializedPass target, int propertyId, float endValue, float duration)
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => target.GetFloat(propertyId), delegate(float x)
			{
				target.SetFloat(propertyId, x);
			}, endValue, duration);
			tweenerCore.SetOptions(snapping: true).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOFade(this SerializedPass target, int propertyId, float endValue, float duration)
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(() => target.GetColor(propertyId), delegate(Color x)
			{
				target.SetColor(propertyId, x);
			}, endValue, duration);
			tweenerCore.SetOptions(alphaOnly: true).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOColor(this SerializedPass target, int propertyId, Color endValue, float duration)
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(() => target.GetColor(propertyId), delegate(Color x)
			{
				target.SetColor(propertyId, x);
			}, endValue, duration);
			tweenerCore.SetOptions(alphaOnly: false).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<Vector4, Vector4, VectorOptions> DOVector(this SerializedPass target, int propertyId, Vector4 endValue, float duration)
		{
			TweenerCore<Vector4, Vector4, VectorOptions> tweenerCore = DOTween.To(() => target.GetVector(propertyId), delegate(Vector4 x)
			{
				target.SetVector(propertyId, x);
			}, endValue, duration);
			tweenerCore.SetOptions(snapping: false).SetTarget(target);
			return tweenerCore;
		}

		public static int DOKill(this Outlinable.OutlineProperties target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		public static int DOKill(this Outliner target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		public static TweenerCore<Color, Color, ColorOptions> DOFade(this Outlinable.OutlineProperties target, float endValue, float duration)
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(() => target.Color, delegate(Color x)
			{
				target.Color = x;
			}, endValue, duration);
			tweenerCore.SetOptions(alphaOnly: true).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Outlinable.OutlineProperties target, Color endValue, float duration)
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(() => target.Color, delegate(Color x)
			{
				target.Color = x;
			}, endValue, duration);
			tweenerCore.SetOptions(alphaOnly: false).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<float, float, FloatOptions> DODilateShift(this Outlinable.OutlineProperties target, float endValue, float duration, bool snapping = false)
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => target.DilateShift, delegate(float x)
			{
				target.DilateShift = x;
			}, endValue, duration);
			tweenerCore.SetOptions(snapping).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<float, float, FloatOptions> DOBlurShift(this Outlinable.OutlineProperties target, float endValue, float duration, bool snapping = false)
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => target.BlurShift, delegate(float x)
			{
				target.BlurShift = x;
			}, endValue, duration);
			tweenerCore.SetOptions(snapping).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<float, float, FloatOptions> DOBlurShift(this Outliner target, float endValue, float duration, bool snapping = false)
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => target.BlurShift, delegate(float x)
			{
				target.BlurShift = x;
			}, endValue, duration);
			tweenerCore.SetOptions(snapping).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<float, float, FloatOptions> DODilateShift(this Outliner target, float endValue, float duration, bool snapping = false)
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => target.DilateShift, delegate(float x)
			{
				target.DilateShift = x;
			}, endValue, duration);
			tweenerCore.SetOptions(snapping).SetTarget(target);
			return tweenerCore;
		}

		public static TweenerCore<float, float, FloatOptions> DOPrimaryRendererScale(this Outliner target, float endValue, float duration, bool snapping = false)
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => target.PrimaryRendererScale, delegate(float x)
			{
				target.PrimaryRendererScale = x;
			}, endValue, duration);
			tweenerCore.SetOptions(snapping).SetTarget(target);
			return tweenerCore;
		}
	}
}
