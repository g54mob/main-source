using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBox
{
	public static class TransformShakeExtension
	{
		private static Dictionary<Transform, Tuple<Coroutine, Vector3>> _activeShakingTransforms;

		public static void StartShake(this Transform transform, float time = 0.1f, float shakeBounds = 0.1f, bool useUnscaledTime = true, bool fadeBounds = false)
		{
			if (_activeShakingTransforms == null)
			{
				_activeShakingTransforms = new Dictionary<Transform, Tuple<Coroutine, Vector3>>();
			}
			BreakShakeIfAny(transform);
			Coroutine item = TransformShakeCoroutine(transform, time, shakeBounds, useUnscaledTime, fadeBounds).StartCoroutine();
			_activeShakingTransforms.Add(transform, new Tuple<Coroutine, Vector3>(item, transform.position));
		}

		public static void StopShake(this Transform transform)
		{
			BreakShakeIfAny(transform);
		}

		private static IEnumerator TransformShakeCoroutine(Transform transform, float shakeTime, float bounds, bool useUnscaledTime, bool fadeBounds)
		{
			Vector3 initialPosition = transform.position;
			float initialBounds = bounds;
			float elapsed = 0f;
			while (shakeTime < 0f || elapsed < shakeTime)
			{
				yield return null;
				elapsed += (useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
				float num = 1f - elapsed / shakeTime;
				float num2 = UnityEngine.Random.value * bounds * 2f - bounds;
				float num3 = UnityEngine.Random.value * bounds * 2f - bounds;
				Vector3 position = transform.position;
				position.x += num2;
				position.y += num3;
				bounds = (fadeBounds ? (initialBounds * num) : initialBounds);
				position.x = Mathf.Clamp(position.x, initialPosition.x - bounds, initialPosition.x + bounds);
				position.y = Mathf.Clamp(position.y, initialPosition.y - bounds, initialPosition.y + bounds);
				transform.position = position;
			}
			transform.position = initialPosition;
			_activeShakingTransforms.Remove(transform);
		}

		private static void BreakShakeIfAny(Transform transform)
		{
			if (_activeShakingTransforms != null && _activeShakingTransforms.ContainsKey(transform))
			{
				Tuple<Coroutine, Vector3> tuple = _activeShakingTransforms[transform];
				MyCoroutines.StopCoroutine(tuple.Item1);
				transform.position = tuple.Item2;
				_activeShakingTransforms.Remove(transform);
			}
		}
	}
}
