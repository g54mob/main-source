using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Dhs5.Utility.Updates;
using UnityEngine;

namespace Tabletop
{
	public static class JuiceManager
	{
		private static readonly int UnscaledTime = Shader.PropertyToID("_UnscaledTime");

		public static readonly int HighlightShaderKey = Shader.PropertyToID("_HighlightWargame");

		public static readonly int UseWargameStuffShaderKey = Shader.PropertyToID("_UseWargameStuff");

		private static readonly Dictionary<Transform, BounceInstance> _bounceInstances = new Dictionary<Transform, BounceInstance>();

		private static readonly List<Transform> _doneTransforms = new List<Transform>();

		private static bool _updateRegistered;

		public static void AddBounce(EBouncePresets preset, Transform tr)
		{
			AddBounce(tr, ShaderSettings.GetBouncePreset(preset));
		}

		public static void AddBounce(Transform tr, BounceData bounce)
		{
			if (Application.isPlaying)
			{
				ref AnimationCurve customCurve = ref bounce.customCurve;
				if (customCurve == null)
				{
					customCurve = ShaderSettings.BounceAnimationCurve;
				}
				if (_bounceInstances.TryGetValue(tr, out var value))
				{
					value.Bounces.Add(bounce);
				}
				else
				{
					_bounceInstances.Add(tr, new BounceInstance(bounce, tr));
				}
			}
		}

		public static void SetHighlightValue(bool active, Material mat, Tween tween, float duration = 0.3f)
		{
			if (tween.IsActive())
			{
				tween.Kill();
			}
			tween = HighlightTween(duration, mat, active).SetUpdate(isIndependentUpdate: true);
		}

		public static void SetHighlightValue(bool active, Material[] mat, Sequence sequence, int startIndex = 0, int endIndex = -1, float duration = 0.3f)
		{
			if (endIndex == -1)
			{
				endIndex = mat.Length;
			}
			if (sequence.IsActive())
			{
				sequence.Kill();
			}
			sequence = DOTween.Sequence();
			for (int i = startIndex; i < endIndex; i++)
			{
				Material matObj = mat[i];
				sequence.Join(HighlightTween(duration, matObj, active));
			}
			sequence.SetUpdate(isIndependentUpdate: true);
			sequence.Play();
		}

		private static TweenerCore<float, float, FloatOptions> HighlightTween(float duration, Material matObj, bool active)
		{
			float startValue = matObj.GetFloat(HighlightShaderKey);
			float endValue = (active ? 1f : 0f);
			return DOTween.To(() => startValue, delegate(float val)
			{
				startValue = val;
				matObj.SetFloat(HighlightShaderKey, val);
			}, endValue, duration).SetEase(Ease.OutCubic);
		}

		public static void RegisterUpdate(bool register)
		{
			if (_updateRegistered != register)
			{
				_updateRegistered = register;
				Updater.RegisterChannelCallback(register, EUpdateChannel.CLASSIC, OnUpdate);
			}
		}

		private static void OnUpdate(float deltaTime)
		{
			Shader.SetGlobalFloat(UnscaledTime, Time.unscaledTime);
			if (_bounceInstances.Count == 0)
			{
				return;
			}
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			_doneTransforms.Clear();
			foreach (var (transform2, bounceInstance2) in _bounceInstances)
			{
				if (bounceInstance2.Update(unscaledDeltaTime, transform2))
				{
					_doneTransforms.Add(transform2);
				}
			}
			foreach (Transform doneTransform in _doneTransforms)
			{
				_bounceInstances.Remove(doneTransform);
			}
		}
	}
}
