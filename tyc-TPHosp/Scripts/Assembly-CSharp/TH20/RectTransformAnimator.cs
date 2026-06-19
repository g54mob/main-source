#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class RectTransformAnimator : MonoBehaviour
	{
		public class TweenAnimationStatus
		{
			public float Progress;

			public bool Finished;
		}

		public enum AnimationSpace
		{
			Local = 0,
			Anchored = 1,
			Global = 2
		}

		public Action<RectTransform> OnAnimationFinished;

		protected WaitForEndOfFrame _frameWait;

		private List<RectTransform> _affectedTransforms;

		private List<RectTransform> _dirtyTransforms;

		protected virtual void Awake()
		{
			_affectedTransforms = new List<RectTransform>();
			_dirtyTransforms = new List<RectTransform>();
			_frameWait = new WaitForEndOfFrame();
		}

		protected virtual void OnDisable()
		{
			StopAllAnimations();
		}

		public void StopAllAnimations()
		{
			StopAllCoroutines();
			_affectedTransforms.Clear();
			_dirtyTransforms.Clear();
		}

		public TweenAnimationStatus Animate(EasingsUtils.Functions method, RectTransform target, Vector3 endPoint, Quaternion endRotation, float duration, bool replaceExisting = false, AnimationSpace space = AnimationSpace.Local)
		{
			if (!base.isActiveAndEnabled)
			{
				return null;
			}
			TweenAnimationStatus tweenAnimationStatus = new TweenAnimationStatus();
			StartCoroutine(AnimateInternal(tweenAnimationStatus, method, target, endPoint, endRotation, duration, replaceExisting, space));
			return tweenAnimationStatus;
		}

		public TweenAnimationStatus Animate(AnimationCurve curve, RectTransform target, Vector3 endPoint, Quaternion endRotation, float duration, bool replaceExisting = false)
		{
			if (!base.isActiveAndEnabled)
			{
				return null;
			}
			TweenAnimationStatus tweenAnimationStatus = new TweenAnimationStatus();
			StartCoroutine(AnimateInternal(tweenAnimationStatus, curve, target, endPoint, endRotation, duration, replaceExisting));
			return tweenAnimationStatus;
		}

		private IEnumerator AnimateInternal(TweenAnimationStatus status, EasingsUtils.Functions method, RectTransform target, Vector3 endPoint, Quaternion endRotation, float duration, bool replaceExisting, AnimationSpace space)
		{
			if (!replaceExisting)
			{
				while (_affectedTransforms.Contains(target) || _dirtyTransforms.Contains(target))
				{
					yield return _frameWait;
				}
			}
			else
			{
				if (_affectedTransforms.Contains(target))
				{
					_affectedTransforms.Remove(target);
					_dirtyTransforms.Add(target);
				}
				while (_dirtyTransforms.Contains(target))
				{
					yield return _frameWait;
				}
			}
			_affectedTransforms.Add(target);
			Vector3 startPoint;
			Quaternion startRotation;
			switch (space)
			{
			case AnimationSpace.Local:
				startPoint = target.localPosition;
				startRotation = target.localRotation;
				break;
			case AnimationSpace.Anchored:
				startPoint = new Vector3(target.anchoredPosition.x, target.anchoredPosition.y, 0f);
				startRotation = target.localRotation;
				break;
			case AnimationSpace.Global:
				startPoint = target.position;
				startRotation = target.rotation;
				break;
			default:
				Logging.Warning(LogChannels.GUI, "Tried to use unimplemented AnimationSpace {0} in RectTransformAnimator", space);
				startPoint = target.localPosition;
				startRotation = target.localRotation;
				break;
			}
			float timeElapsed = 0f;
			do
			{
				if (_dirtyTransforms.Contains(target))
				{
					_dirtyTransforms.Remove(target);
					status.Progress = -1f;
					status.Finished = true;
					OnAnimationFinished.InvokeSafe(target);
					yield break;
				}
				if (status.Finished)
				{
					if (_affectedTransforms.Contains(target))
					{
						_affectedTransforms.Remove(target);
					}
					OnAnimationFinished.InvokeSafe(target);
					yield break;
				}
				timeElapsed += Time.unscaledDeltaTime / duration;
				if (timeElapsed > 1f)
				{
					timeElapsed = 1f;
				}
				float t = EasingsUtils.Interpolate(timeElapsed, method);
				switch (space)
				{
				case AnimationSpace.Local:
					target.localPosition = Vector3.LerpUnclamped(startPoint, endPoint, t);
					target.localRotation = Quaternion.LerpUnclamped(startRotation, endRotation, t);
					break;
				case AnimationSpace.Anchored:
					target.anchoredPosition = Vector3.LerpUnclamped(startPoint, endPoint, t);
					target.localRotation = Quaternion.LerpUnclamped(startRotation, endRotation, t);
					break;
				case AnimationSpace.Global:
					target.position = Vector3.LerpUnclamped(startPoint, endPoint, t);
					target.rotation = Quaternion.LerpUnclamped(startRotation, endRotation, t);
					break;
				default:
					target.localPosition = Vector3.LerpUnclamped(startPoint, endPoint, t);
					target.localRotation = Quaternion.LerpUnclamped(startRotation, endRotation, t);
					break;
				}
				status.Progress = timeElapsed;
				yield return _frameWait;
			}
			while (timeElapsed < 1f);
			status.Progress = 1f;
			status.Finished = true;
			if (_affectedTransforms.Contains(target))
			{
				_affectedTransforms.Remove(target);
			}
			OnAnimationFinished.InvokeSafe(target);
		}

		private IEnumerator AnimateInternal(TweenAnimationStatus status, AnimationCurve curve, RectTransform target, Vector3 endPoint, Quaternion endRotation, float duration, bool replaceExisting)
		{
			if (!replaceExisting)
			{
				while (_affectedTransforms.Contains(target) || _dirtyTransforms.Contains(target))
				{
					yield return _frameWait;
				}
			}
			else
			{
				if (_affectedTransforms.Contains(target))
				{
					_affectedTransforms.Remove(target);
					_dirtyTransforms.Add(target);
				}
				while (_dirtyTransforms.Contains(target))
				{
					yield return _frameWait;
				}
			}
			_affectedTransforms.Add(target);
			Vector3 startPoint = target.localPosition;
			Quaternion startRotation = target.localRotation;
			float timeElapsed = 0f;
			do
			{
				if (_dirtyTransforms.Contains(target))
				{
					_dirtyTransforms.Remove(target);
					status.Progress = -1f;
					status.Finished = true;
					OnAnimationFinished.InvokeSafe(target);
					yield break;
				}
				if (status.Finished)
				{
					if (_affectedTransforms.Contains(target))
					{
						_affectedTransforms.Remove(target);
					}
					OnAnimationFinished.InvokeSafe(target);
					yield break;
				}
				timeElapsed += GameTime.unscaledDeltaTime / duration;
				if (timeElapsed > 1f)
				{
					timeElapsed = 1f;
				}
				float t = curve.Evaluate(timeElapsed);
				target.localPosition = Vector3.LerpUnclamped(startPoint, endPoint, t);
				target.localRotation = Quaternion.LerpUnclamped(startRotation, endRotation, t);
				status.Progress = timeElapsed;
				yield return _frameWait;
			}
			while (timeElapsed < 1f);
			status.Progress = 1f;
			status.Finished = true;
			if (_affectedTransforms.Contains(target))
			{
				_affectedTransforms.Remove(target);
			}
			OnAnimationFinished.InvokeSafe(target);
		}
	}
}
