using System.Collections;
using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMTween : MonoBehaviour
	{
		public enum MMTweenCurve
		{
			LinearTween = 0,
			EaseInQuadratic = 1,
			EaseOutQuadratic = 2,
			EaseInOutQuadratic = 3,
			EaseInCubic = 4,
			EaseOutCubic = 5,
			EaseInOutCubic = 6,
			EaseInQuartic = 7,
			EaseOutQuartic = 8,
			EaseInOutQuartic = 9,
			EaseInQuintic = 10,
			EaseOutQuintic = 11,
			EaseInOutQuintic = 12,
			EaseInSinusoidal = 13,
			EaseOutSinusoidal = 14,
			EaseInOutSinusoidal = 15,
			EaseInBounce = 16,
			EaseOutBounce = 17,
			EaseInOutBounce = 18,
			EaseInOverhead = 19,
			EaseOutOverhead = 20,
			EaseInOutOverhead = 21,
			EaseInExponential = 22,
			EaseOutExponential = 23,
			EaseInOutExponential = 24,
			EaseInElastic = 25,
			EaseOutElastic = 26,
			EaseInOutElastic = 27,
			EaseInCircular = 28,
			EaseOutCircular = 29,
			EaseInOutCircular = 30,
			AntiLinearTween = 31,
			AlmostIdentity = 32
		}

		public delegate float TweenDelegate(float currentTime);

		public static TweenDelegate[] TweenDelegateArray = new TweenDelegate[33]
		{
			LinearTween, EaseInQuadratic, EaseOutQuadratic, EaseInOutQuadratic, EaseInCubic, EaseOutCubic, EaseInOutCubic, EaseInQuartic, EaseOutQuartic, EaseInOutQuartic,
			EaseInQuintic, EaseOutQuintic, EaseInOutQuintic, EaseInSinusoidal, EaseOutSinusoidal, EaseInOutSinusoidal, EaseInBounce, EaseOutBounce, EaseInOutBounce, EaseInOverhead,
			EaseOutOverhead, EaseInOutOverhead, EaseInExponential, EaseOutExponential, EaseInOutExponential, EaseInElastic, EaseOutElastic, EaseInOutElastic, EaseInCircular, EaseOutCircular,
			EaseInOutCircular, AntiLinearTween, AlmostIdentity
		};

		public static float Tween(float currentTime, float initialTime, float endTime, float startValue, float endValue, MMTweenCurve curve)
		{
			currentTime = MMMaths.Remap(currentTime, initialTime, endTime, 0f, 1f);
			currentTime = TweenDelegateArray[(int)curve](currentTime);
			return startValue + currentTime * (endValue - startValue);
		}

		public static long Tween(float currentTime, float initialTime, float endTime, long startValue, long endValue, MMTweenCurve curve)
		{
			currentTime = MMMaths.Remap(currentTime, initialTime, endTime, 0f, 1f);
			currentTime = TweenDelegateArray[(int)curve](currentTime);
			return startValue + (long)(currentTime * (float)(endValue - startValue));
		}

		public static float Evaluate(float t, MMTweenCurve curve)
		{
			return TweenDelegateArray[(int)curve](t);
		}

		public static float Evaluate(float t, MMTweenType tweenType)
		{
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.MMTween)
			{
				return Evaluate(t, tweenType.MMTweenCurve);
			}
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.AnimationCurve)
			{
				return tweenType.Curve.Evaluate(t);
			}
			return 0f;
		}

		public static float LinearTween(float currentTime)
		{
			return MMTweenDefinitions.Linear_Tween(currentTime);
		}

		public static float AntiLinearTween(float currentTime)
		{
			return MMTweenDefinitions.LinearAnti_Tween(currentTime);
		}

		public static float EaseInQuadratic(float currentTime)
		{
			return MMTweenDefinitions.EaseIn_Quadratic(currentTime);
		}

		public static float EaseOutQuadratic(float currentTime)
		{
			return MMTweenDefinitions.EaseOut_Quadratic(currentTime);
		}

		public static float EaseInOutQuadratic(float currentTime)
		{
			return MMTweenDefinitions.EaseInOut_Quadratic(currentTime);
		}

		public static float EaseInCubic(float currentTime)
		{
			return MMTweenDefinitions.EaseIn_Cubic(currentTime);
		}

		public static float EaseOutCubic(float currentTime)
		{
			return MMTweenDefinitions.EaseOut_Cubic(currentTime);
		}

		public static float EaseInOutCubic(float currentTime)
		{
			return MMTweenDefinitions.EaseInOut_Cubic(currentTime);
		}

		public static float EaseInQuartic(float currentTime)
		{
			return MMTweenDefinitions.EaseIn_Quartic(currentTime);
		}

		public static float EaseOutQuartic(float currentTime)
		{
			return MMTweenDefinitions.EaseOut_Quartic(currentTime);
		}

		public static float EaseInOutQuartic(float currentTime)
		{
			return MMTweenDefinitions.EaseInOut_Quartic(currentTime);
		}

		public static float EaseInQuintic(float currentTime)
		{
			return MMTweenDefinitions.EaseIn_Quintic(currentTime);
		}

		public static float EaseOutQuintic(float currentTime)
		{
			return MMTweenDefinitions.EaseOut_Quintic(currentTime);
		}

		public static float EaseInOutQuintic(float currentTime)
		{
			return MMTweenDefinitions.EaseInOut_Quintic(currentTime);
		}

		public static float EaseInSinusoidal(float currentTime)
		{
			return MMTweenDefinitions.EaseIn_Sinusoidal(currentTime);
		}

		public static float EaseOutSinusoidal(float currentTime)
		{
			return MMTweenDefinitions.EaseOut_Sinusoidal(currentTime);
		}

		public static float EaseInOutSinusoidal(float currentTime)
		{
			return MMTweenDefinitions.EaseInOut_Sinusoidal(currentTime);
		}

		public static float EaseInBounce(float currentTime)
		{
			return MMTweenDefinitions.EaseIn_Bounce(currentTime);
		}

		public static float EaseOutBounce(float currentTime)
		{
			return MMTweenDefinitions.EaseOut_Bounce(currentTime);
		}

		public static float EaseInOutBounce(float currentTime)
		{
			return MMTweenDefinitions.EaseInOut_Bounce(currentTime);
		}

		public static float EaseInOverhead(float currentTime)
		{
			return MMTweenDefinitions.EaseIn_Overhead(currentTime);
		}

		public static float EaseOutOverhead(float currentTime)
		{
			return MMTweenDefinitions.EaseOut_Overhead(currentTime);
		}

		public static float EaseInOutOverhead(float currentTime)
		{
			return MMTweenDefinitions.EaseInOut_Overhead(currentTime);
		}

		public static float EaseInExponential(float currentTime)
		{
			return MMTweenDefinitions.EaseIn_Exponential(currentTime);
		}

		public static float EaseOutExponential(float currentTime)
		{
			return MMTweenDefinitions.EaseOut_Exponential(currentTime);
		}

		public static float EaseInOutExponential(float currentTime)
		{
			return MMTweenDefinitions.EaseInOut_Exponential(currentTime);
		}

		public static float EaseInElastic(float currentTime)
		{
			return MMTweenDefinitions.EaseIn_Elastic(currentTime);
		}

		public static float EaseOutElastic(float currentTime)
		{
			return MMTweenDefinitions.EaseOut_Elastic(currentTime);
		}

		public static float EaseInOutElastic(float currentTime)
		{
			return MMTweenDefinitions.EaseInOut_Elastic(currentTime);
		}

		public static float EaseInCircular(float currentTime)
		{
			return MMTweenDefinitions.EaseIn_Circular(currentTime);
		}

		public static float EaseOutCircular(float currentTime)
		{
			return MMTweenDefinitions.EaseOut_Circular(currentTime);
		}

		public static float EaseInOutCircular(float currentTime)
		{
			return MMTweenDefinitions.EaseInOut_Circular(currentTime);
		}

		public static float AlmostIdentity(float currentTime)
		{
			return MMTweenDefinitions.AlmostIdentity(currentTime);
		}

		public static TweenDelegate GetTweenMethod(MMTweenCurve tween)
		{
			return tween switch
			{
				MMTweenCurve.LinearTween => LinearTween, 
				MMTweenCurve.AntiLinearTween => AntiLinearTween, 
				MMTweenCurve.EaseInQuadratic => EaseInQuadratic, 
				MMTweenCurve.EaseOutQuadratic => EaseOutQuadratic, 
				MMTweenCurve.EaseInOutQuadratic => EaseInOutQuadratic, 
				MMTweenCurve.EaseInCubic => EaseInCubic, 
				MMTweenCurve.EaseOutCubic => EaseOutCubic, 
				MMTweenCurve.EaseInOutCubic => EaseInOutCubic, 
				MMTweenCurve.EaseInQuartic => EaseInQuartic, 
				MMTweenCurve.EaseOutQuartic => EaseOutQuartic, 
				MMTweenCurve.EaseInOutQuartic => EaseInOutQuartic, 
				MMTweenCurve.EaseInQuintic => EaseInQuintic, 
				MMTweenCurve.EaseOutQuintic => EaseOutQuintic, 
				MMTweenCurve.EaseInOutQuintic => EaseInOutQuintic, 
				MMTweenCurve.EaseInSinusoidal => EaseInSinusoidal, 
				MMTweenCurve.EaseOutSinusoidal => EaseOutSinusoidal, 
				MMTweenCurve.EaseInOutSinusoidal => EaseInOutSinusoidal, 
				MMTweenCurve.EaseInBounce => EaseInBounce, 
				MMTweenCurve.EaseOutBounce => EaseOutBounce, 
				MMTweenCurve.EaseInOutBounce => EaseInOutBounce, 
				MMTweenCurve.EaseInOverhead => EaseInOverhead, 
				MMTweenCurve.EaseOutOverhead => EaseOutOverhead, 
				MMTweenCurve.EaseInOutOverhead => EaseInOutOverhead, 
				MMTweenCurve.EaseInExponential => EaseInExponential, 
				MMTweenCurve.EaseOutExponential => EaseOutExponential, 
				MMTweenCurve.EaseInOutExponential => EaseInOutExponential, 
				MMTweenCurve.EaseInElastic => EaseInElastic, 
				MMTweenCurve.EaseOutElastic => EaseOutElastic, 
				MMTweenCurve.EaseInOutElastic => EaseInOutElastic, 
				MMTweenCurve.EaseInCircular => EaseInCircular, 
				MMTweenCurve.EaseOutCircular => EaseOutCircular, 
				MMTweenCurve.EaseInOutCircular => EaseInOutCircular, 
				MMTweenCurve.AlmostIdentity => AlmostIdentity, 
				_ => LinearTween, 
			};
		}

		public static Vector2 Tween(float currentTime, float initialTime, float endTime, Vector2 startValue, Vector2 endValue, MMTweenCurve curve)
		{
			startValue.x = Tween(currentTime, initialTime, endTime, startValue.x, endValue.x, curve);
			startValue.y = Tween(currentTime, initialTime, endTime, startValue.y, endValue.y, curve);
			return startValue;
		}

		public static Vector3 Tween(float currentTime, float initialTime, float endTime, Vector3 startValue, Vector3 endValue, MMTweenCurve curve)
		{
			startValue.x = Tween(currentTime, initialTime, endTime, startValue.x, endValue.x, curve);
			startValue.y = Tween(currentTime, initialTime, endTime, startValue.y, endValue.y, curve);
			startValue.z = Tween(currentTime, initialTime, endTime, startValue.z, endValue.z, curve);
			return startValue;
		}

		public static Vector4 Tween(float currentTime, float initialTime, float endTime, Vector4 startValue, Vector4 endValue, MMTweenCurve curve)
		{
			startValue.x = Tween(currentTime, initialTime, endTime, startValue.x, endValue.x, curve);
			startValue.y = Tween(currentTime, initialTime, endTime, startValue.y, endValue.y, curve);
			startValue.z = Tween(currentTime, initialTime, endTime, startValue.z, endValue.z, curve);
			startValue.w = Tween(currentTime, initialTime, endTime, startValue.w, endValue.w, curve);
			return startValue;
		}

		public static Quaternion Tween(float currentTime, float initialTime, float endTime, Quaternion startValue, Quaternion endValue, MMTweenCurve curve)
		{
			float t = Tween(currentTime, initialTime, endTime, 0f, 1f, curve);
			startValue = Quaternion.Slerp(startValue, endValue, t);
			return startValue;
		}

		public static float Tween(float currentTime, float initialTime, float endTime, float startValue, float endValue, AnimationCurve curve)
		{
			currentTime = MMMaths.Remap(currentTime, initialTime, endTime, 0f, 1f);
			currentTime = curve.Evaluate(currentTime);
			return startValue + currentTime * (endValue - startValue);
		}

		public static long Tween(float currentTime, float initialTime, float endTime, long startValue, long endValue, AnimationCurve curve)
		{
			currentTime = MMMaths.Remap(currentTime, initialTime, endTime, 0f, 1f);
			currentTime = curve.Evaluate(currentTime);
			return startValue + (long)currentTime * (endValue - startValue);
		}

		public static Vector2 Tween(float currentTime, float initialTime, float endTime, Vector2 startValue, Vector2 endValue, AnimationCurve curve)
		{
			startValue.x = Tween(currentTime, initialTime, endTime, startValue.x, endValue.x, curve);
			startValue.y = Tween(currentTime, initialTime, endTime, startValue.y, endValue.y, curve);
			return startValue;
		}

		public static Vector3 Tween(float currentTime, float initialTime, float endTime, Vector3 startValue, Vector3 endValue, AnimationCurve curve)
		{
			startValue.x = Tween(currentTime, initialTime, endTime, startValue.x, endValue.x, curve);
			startValue.y = Tween(currentTime, initialTime, endTime, startValue.y, endValue.y, curve);
			startValue.z = Tween(currentTime, initialTime, endTime, startValue.z, endValue.z, curve);
			return startValue;
		}

		public static Vector4 Tween(float currentTime, float initialTime, float endTime, Vector4 startValue, Vector4 endValue, AnimationCurve curve)
		{
			startValue.x = Tween(currentTime, initialTime, endTime, startValue.x, endValue.x, curve);
			startValue.y = Tween(currentTime, initialTime, endTime, startValue.y, endValue.y, curve);
			startValue.z = Tween(currentTime, initialTime, endTime, startValue.z, endValue.z, curve);
			startValue.w = Tween(currentTime, initialTime, endTime, startValue.w, endValue.w, curve);
			return startValue;
		}

		public static Quaternion Tween(float currentTime, float initialTime, float endTime, Quaternion startValue, Quaternion endValue, AnimationCurve curve)
		{
			float t = Tween(currentTime, initialTime, endTime, 0f, 1f, curve);
			startValue = Quaternion.Slerp(startValue, endValue, t);
			return startValue;
		}

		public static float Tween(float currentTime, float initialTime, float endTime, float startValue, float endValue, MMTweenType tweenType)
		{
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.MMTween)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.MMTweenCurve);
			}
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.AnimationCurve)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.Curve);
			}
			return 0f;
		}

		public static long Tween(float currentTime, float initialTime, float endTime, long startValue, long endValue, MMTweenType tweenType)
		{
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.MMTween)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.MMTweenCurve);
			}
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.AnimationCurve)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.Curve);
			}
			return 0L;
		}

		public static Vector2 Tween(float currentTime, float initialTime, float endTime, Vector2 startValue, Vector2 endValue, MMTweenType tweenType)
		{
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.MMTween)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.MMTweenCurve);
			}
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.AnimationCurve)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.Curve);
			}
			return Vector2.zero;
		}

		public static Vector3 Tween(float currentTime, float initialTime, float endTime, Vector3 startValue, Vector3 endValue, MMTweenType tweenType)
		{
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.MMTween)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.MMTweenCurve);
			}
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.AnimationCurve)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.Curve);
			}
			return Vector3.zero;
		}

		public static Vector4 Tween(float currentTime, float initialTime, float endTime, Vector4 startValue, Vector4 endValue, MMTweenType tweenType)
		{
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.MMTween)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.MMTweenCurve);
			}
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.AnimationCurve)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.Curve);
			}
			return Vector3.zero;
		}

		public static Quaternion Tween(float currentTime, float initialTime, float endTime, Quaternion startValue, Quaternion endValue, MMTweenType tweenType)
		{
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.MMTween)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.MMTweenCurve);
			}
			if (tweenType.MMTweenDefinitionType == MMTweenDefinitionTypes.AnimationCurve)
			{
				return Tween(currentTime, initialTime, endTime, startValue, endValue, tweenType.Curve);
			}
			return Quaternion.identity;
		}

		public static Coroutine MoveTransform(MonoBehaviour mono, Transform targetTransform, Vector3 origin, Vector3 destination, WaitForSeconds delay, float delayDuration, float duration, MMTweenCurve curve, bool ignoreTimescale = false)
		{
			return mono.StartCoroutine(MoveTransformCo(targetTransform, origin, destination, delay, delayDuration, duration, curve, ignoreTimescale));
		}

		public static Coroutine MoveRectTransform(MonoBehaviour mono, RectTransform targetTransform, Vector3 origin, Vector3 destination, WaitForSeconds delay, float delayDuration, float duration, MMTweenCurve curve, bool ignoreTimescale = false)
		{
			return mono.StartCoroutine(MoveRectTransformCo(targetTransform, origin, destination, delay, delayDuration, duration, curve, ignoreTimescale));
		}

		public static Coroutine MoveTransform(MonoBehaviour mono, Transform targetTransform, Transform origin, Transform destination, WaitForSeconds delay, float delayDuration, float duration, MMTweenCurve curve, bool updatePosition = true, bool updateRotation = true, bool ignoreTimescale = false)
		{
			return mono.StartCoroutine(MoveTransformCo(targetTransform, origin, destination, delay, delayDuration, duration, curve, updatePosition, updateRotation, ignoreTimescale));
		}

		public static Coroutine RotateTransformAround(MonoBehaviour mono, Transform targetTransform, Transform center, Transform destination, float angle, WaitForSeconds delay, float delayDuration, float duration, MMTweenCurve curve, bool ignoreTimescale = false)
		{
			return mono.StartCoroutine(RotateTransformAroundCo(targetTransform, center, destination, angle, delay, delayDuration, duration, curve, ignoreTimescale));
		}

		protected static IEnumerator MoveRectTransformCo(RectTransform targetTransform, Vector3 origin, Vector3 destination, WaitForSeconds delay, float delayDuration, float duration, MMTweenCurve curve, bool ignoreTimescale = false)
		{
			if (delayDuration > 0f)
			{
				yield return delay;
			}
			float timeLeft = duration;
			while (timeLeft > 0f)
			{
				targetTransform.localPosition = Tween(duration - timeLeft, 0f, duration, origin, destination, curve);
				timeLeft -= (ignoreTimescale ? Time.unscaledDeltaTime : Time.deltaTime);
				yield return null;
			}
			targetTransform.localPosition = destination;
		}

		protected static IEnumerator MoveTransformCo(Transform targetTransform, Vector3 origin, Vector3 destination, WaitForSeconds delay, float delayDuration, float duration, MMTweenCurve curve, bool ignoreTimescale = false)
		{
			if (delayDuration > 0f)
			{
				yield return delay;
			}
			float timeLeft = duration;
			while (timeLeft > 0f)
			{
				targetTransform.transform.position = Tween(duration - timeLeft, 0f, duration, origin, destination, curve);
				timeLeft -= (ignoreTimescale ? Time.unscaledDeltaTime : Time.deltaTime);
				yield return null;
			}
			targetTransform.transform.position = destination;
		}

		protected static IEnumerator MoveTransformCo(Transform targetTransform, Transform origin, Transform destination, WaitForSeconds delay, float delayDuration, float duration, MMTweenCurve curve, bool updatePosition = true, bool updateRotation = true, bool ignoreTimescale = false)
		{
			if (delayDuration > 0f)
			{
				yield return delay;
			}
			float timeLeft = duration;
			while (timeLeft > 0f)
			{
				if (updatePosition)
				{
					targetTransform.transform.position = Tween(duration - timeLeft, 0f, duration, origin.position, destination.position, curve);
				}
				if (updateRotation)
				{
					targetTransform.transform.rotation = Tween(duration - timeLeft, 0f, duration, origin.rotation, destination.rotation, curve);
				}
				timeLeft -= (ignoreTimescale ? Time.unscaledDeltaTime : Time.deltaTime);
				yield return null;
			}
			if (updatePosition)
			{
				targetTransform.transform.position = destination.position;
			}
			if (updateRotation)
			{
				targetTransform.transform.localEulerAngles = destination.localEulerAngles;
			}
		}

		protected static IEnumerator RotateTransformAroundCo(Transform targetTransform, Transform center, Transform destination, float angle, WaitForSeconds delay, float delayDuration, float duration, MMTweenCurve curve, bool ignoreTimescale = false)
		{
			if (delayDuration > 0f)
			{
				yield return delay;
			}
			Vector3 initialRotationPosition = targetTransform.transform.position;
			_ = targetTransform.transform.rotation;
			_ = 1f / duration;
			float timeSpent = 0f;
			while (timeSpent < duration)
			{
				float angle2 = Tween(timeSpent, 0f, duration, 0f, angle, curve);
				targetTransform.transform.position = initialRotationPosition;
				Quaternion rotation = targetTransform.transform.rotation;
				targetTransform.RotateAround(center.transform.position, center.transform.up, angle2);
				targetTransform.transform.rotation = rotation;
				timeSpent += (ignoreTimescale ? Time.unscaledDeltaTime : Time.deltaTime);
				yield return null;
			}
			targetTransform.transform.position = destination.position;
		}
	}
}
