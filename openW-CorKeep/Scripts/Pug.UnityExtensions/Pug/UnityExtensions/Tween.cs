using System;
using System.Collections;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public static class Tween
	{
		public static class Easing
		{
			public enum EasingType
			{
				Linear = 0,
				Sin = 1,
				EaseInQuad = 2,
				EaseOutQuad = 3,
				EaseInOutQuad = 4,
				EaseInCubic = 5,
				EaseOutCubic = 6,
				EaseInOutCubic = 7
			}

			public static readonly Func<float, float> Linear = (float t) => t;

			public static readonly Func<float, float> EaseInQuad = (float t) => t * t;

			public static readonly Func<float, float> EaseOutQuad = (float t) => t * (2f - t);

			public static readonly Func<float, float> EaseInOutQuad = (float t) => (!((double)t < 0.5)) ? (-1f + (4f - 2f * t) * t) : (2f * t * t);

			public static readonly Func<float, float> EaseInCubic = (float t) => t * t * t;

			public static readonly Func<float, float> EaseOutCubic = (float t) => (t -= 1f) * t * t + 1f;

			public static readonly Func<float, float> EaseInOutCubic = (float t) => (!(t < 0.5f)) ? ((t - 1f) * (2f * t - 2f) * (2f * t - 2f) + 1f) : (4f * t * t * t);

			public static readonly Func<float, float> Sin = (float t) => (1f + Mathf.Sin(MathF.PI * (t - 0.5f))) * 0.5f;

			public static readonly Func<float, float> Default = Sin;

			public static void Init()
			{
			}

			public static Func<float, float> GetFunctionByEasingType(EasingType easingType)
			{
				return easingType switch
				{
					EasingType.Linear => Linear, 
					EasingType.Sin => Sin, 
					EasingType.EaseInQuad => EaseInQuad, 
					EasingType.EaseOutQuad => EaseOutQuad, 
					EasingType.EaseInOutQuad => EaseInOutQuad, 
					EasingType.EaseInCubic => EaseInCubic, 
					EasingType.EaseOutCubic => EaseOutCubic, 
					EasingType.EaseInOutCubic => EaseInOutCubic, 
					_ => throw new ArgumentOutOfRangeException("easingType", easingType, null), 
				};
			}
		}

		public static class Apply
		{
			public static readonly Action<Transform, float, Vector3, Vector3> TransformPosition = delegate(Transform o, float t, Vector3 a, Vector3 b)
			{
				o.position = Vector3.Lerp(a, b, t);
			};

			public static readonly Action<Transform, float, Vector3, Vector3> TransformLocalPosition = delegate(Transform o, float t, Vector3 a, Vector3 b)
			{
				o.localPosition = Vector3.Lerp(a, b, t);
			};

			public static readonly Action<Transform, float, Vector3, Vector3> TransformLocalScale = delegate(Transform o, float t, Vector3 a, Vector3 b)
			{
				o.localScale = Vector3.Lerp(a, b, t);
			};

			public static void Init()
			{
			}
		}

		public static class Enumerators
		{
			public static IEnumerator GenericTween<T1, T2>(T1 obj, float duration, T2 from, T2 to, Action<T1, float, T2, T2> apply, Func<float, float> ratioProcessor)
			{
				TimerSimple timer = TimerSimple.StartNew(duration);
				while (!timer.isTimerElapsed)
				{
					float arg = ratioProcessor(timer.elapsedRatio);
					apply(obj, arg, from, to);
					yield return Yielders.WaitForFixedUpdate();
				}
				apply(obj, 1f, to, to);
			}

			public static IEnumerator GenericTweenDynamicTarget<T1, T2>(T1 obj, float duration, T2 from, Func<T2> dynamicTo, Action<T1, float, T2, T2> apply, Func<float, float> ratioProcessor)
			{
				TimerSimple timer = TimerSimple.StartNew(duration);
				while (!timer.isTimerElapsed)
				{
					float arg = ratioProcessor(timer.elapsedRatio);
					apply(obj, arg, from, dynamicTo());
					yield return Yielders.WaitForFixedUpdate();
				}
				T2 val = dynamicTo();
				apply(obj, 1f, val, val);
			}

			public static IEnumerator Position(MonoBehaviour mb, float duration, Vector3 to, Func<float, float> easingFunction = null)
			{
				return GenericTween(mb.transform, duration, mb.transform.position, to, Apply.TransformPosition, easingFunction ?? Easing.Default);
			}

			public static IEnumerator PositionDynamicTarget(MonoBehaviour mb, float duration, Func<Vector3> dynamicTo, Func<float, float> easingFunction = null)
			{
				return GenericTweenDynamicTarget(mb.transform, duration, mb.transform.position, dynamicTo, Apply.TransformPosition, easingFunction ?? Easing.Default);
			}

			public static IEnumerator LocalPosition(MonoBehaviour mb, float duration, Vector3 to, Func<float, float> easingFunction = null)
			{
				return GenericTween(mb.transform, duration, mb.transform.localPosition, to, Apply.TransformLocalPosition, easingFunction ?? Easing.Default);
			}

			public static IEnumerator LocalScale(MonoBehaviour mb, float duration, Vector3 to, Func<float, float> easingFunction = null)
			{
				return GenericTween(mb.transform, duration, mb.transform.localScale, to, Apply.TransformLocalScale, easingFunction ?? Easing.Default);
			}
		}

		public static void Init()
		{
			Easing.Init();
			Apply.Init();
		}

		public static Coroutine StartTween<T1, T2>(this T1 obj, float duration, T2 from, T2 to, Action<T1, float, T2, T2> apply) where T1 : MonoBehaviour
		{
			return obj.StartCoroutine(Enumerators.GenericTween(obj, duration, from, to, apply, Easing.Sin));
		}

		public static Coroutine StartTweenPosition(this MonoBehaviour mb, float duration, Vector3 to, Func<float, float> easingFunction = null)
		{
			return mb.StartCoroutine(Enumerators.Position(mb, duration, to, easingFunction));
		}

		public static Coroutine StartTweenLocalPosition(this MonoBehaviour mb, float duration, Vector3 to)
		{
			return mb.StartCoroutine(Enumerators.LocalPosition(mb, duration, to));
		}

		public static Coroutine StartTweenLocalScale(this MonoBehaviour mb, float duration, Vector3 to)
		{
			return mb.StartCoroutine(Enumerators.LocalScale(mb, duration, to));
		}
	}
}
