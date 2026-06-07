using DG.Tweening;
using Doozy.Engine.Settings;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI.Animation
{
	public static class UIAnimator
	{
		public static Vector3 DEFAULT_START_POSITION;

		public static Vector3 DEFAULT_START_ROTATION;

		public static Vector3 DEFAULT_START_SCALE;

		public const float DEFAULT_START_ALPHA = 1f;

		public const bool DefaultAnimationEnabledState = false;

		public const Direction DefaultDirection = Direction.Left;

		public const RotateMode DefaultRotateMode = RotateMode.FastBeyond360;

		public const LoopType DefaultLoopType = LoopType.Yoyo;

		public const EaseType DefaultEaseType = EaseType.Ease;

		public const Ease DefaultEase = Ease.Linear;

		public const float DefaultDuration = 1f;

		public const float DefaultStartDelay = 0f;

		public const int DefaultNumberOfLoops = -1;

		public const float DefaultDurationOnComplete = 0.05f;

		public const float DefaultDurationInitLoop = 0.2f;

		public const float DefaultDurationResetTarget = 0.1f;

		public const int DefaultVibrato = 10;

		public const float DefaultElasticity = 1f;

		private static DoozySettings Settings => null;

		public static Tween MoveTween(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue)
		{
			return null;
		}

		public static Vector3 MoveLoopPositionA(UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static Vector3 MoveLoopPositionB(UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static Tween MoveLoopTween(RectTransform target, UIAnimation animation, Vector3 startValue)
		{
			return null;
		}

		public static Tween MovePunchTween(RectTransform target, UIAnimation animation)
		{
			return null;
		}

		public static Tween MoveStateTween(RectTransform target, UIAnimation animation, Vector3 startValue)
		{
			return null;
		}

		public static Tween RotateTween(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue)
		{
			return null;
		}

		public static Vector3 RotateLoopRotationA(UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static Vector3 RotateLoopRotationB(UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static Tween RotateLoopTween(RectTransform target, UIAnimation animation, Vector3 startValue)
		{
			return null;
		}

		public static Tween RotatePunchTween(RectTransform target, UIAnimation animation)
		{
			return null;
		}

		public static Tween RotateStateTween(RectTransform target, UIAnimation animation, Vector3 startValue)
		{
			return null;
		}

		public static Tween ScaleTween(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue)
		{
			return null;
		}

		public static Tween ScaleLoopTween(RectTransform target, UIAnimation animation)
		{
			return null;
		}

		public static Tween ScalePunchTween(RectTransform target, UIAnimation animation)
		{
			return null;
		}

		public static Tween ScaleStateTween(RectTransform target, UIAnimation animation, Vector3 startValue)
		{
			return null;
		}

		public static Tween FadeTween(RectTransform target, UIAnimation animation, float startValue, float endValue)
		{
			return null;
		}

		public static Tween FadeLoopTween(RectTransform target, UIAnimation animation)
		{
			return null;
		}

		public static Tween FadeStateTween(RectTransform target, UIAnimation animation, float startValue)
		{
			return null;
		}

		public static void Move(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void Rotate(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void Scale(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void Fade(RectTransform target, UIAnimation animation, float startValue, float endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void MoveLoop(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void RotateLoop(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void ScaleLoop(RectTransform target, UIAnimation animation, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void FadeLoop(RectTransform target, UIAnimation animation, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void MovePunch(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void RotatePunch(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void ScalePunch(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void MoveState(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void RotateState(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void ScaleState(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static void FadeState(RectTransform target, UIAnimation animation, float startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public static Vector3 GetAnimationMoveFrom(RectTransform target, UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static Vector3 GetAnimationMoveTo(RectTransform target, UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static Vector3 GetAnimationRotateFrom(UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static Vector3 GetAnimationRotateTo(UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static Vector3 GetAnimationScaleFrom(UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static Vector3 GetAnimationScaleTo(UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static float GetAnimationFadeFrom(UIAnimation animation, float startValue)
		{
			return 0f;
		}

		public static float GetAnimationFadeTo(UIAnimation animation, float startValue)
		{
			return 0f;
		}

		public static Direction ReverseDirection(Direction direction)
		{
			return default(Direction);
		}

		public static Vector3 GetToPositionByDirection(RectTransform target, UIAnimation animation, Vector3 startValue)
		{
			return default(Vector3);
		}

		public static string GetTweenId(RectTransform target, AnimationType animationType, AnimationAction animationAction)
		{
			return null;
		}

		public static void ResetCanvasGroup(RectTransform target, bool interactable = true, bool blocksRaycasts = true)
		{
		}

		public static void StopAnimations(RectTransform target, AnimationType animationType, bool complete = true)
		{
		}

		private static void SetEase(this Tween tween, Move move)
		{
		}

		private static void SetEase(this Tween tween, Rotate rotate)
		{
		}

		private static void SetEase(this Tween tween, Scale scale)
		{
		}

		private static void SetEase(this Tween tween, Fade fade)
		{
		}
	}
}
