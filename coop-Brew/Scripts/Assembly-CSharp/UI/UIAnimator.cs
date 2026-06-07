using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
	public static class UIAnimator
	{
		public static bool AnimationsEnabled;

		public static float SpeedMultiplier;

		public static bool UseUnscaledTime;

		public const float DURATION_INSTANT = 0.05f;

		public const float DURATION_FAST = 0.15f;

		public const float DURATION_NORMAL = 0.25f;

		public const float DURATION_SLOW = 0.4f;

		public const float DURATION_PANEL = 0.3f;

		public const float DURATION_PANEL_FAST = 0.15f;

		public const float DURATION_PANEL_INSTANT = 0.1f;

		public const float SCALE_HOVER = 1.03f;

		public const float SCALE_HOVER_STRONG = 1.05f;

		public const float SCALE_PRESS = 0.95f;

		public const float SCALE_SUCCESS = 1.08f;

		public const float SCALE_ATTENTION = 1.05f;

		public const float SCALE_PANEL_ENTER = 0.9f;

		public const float SCALE_PANEL_EXIT = 0.95f;

		public const float OPACITY_FULL = 1f;

		public const float OPACITY_DISABLED = 0.5f;

		public const float OPACITY_GHOST = 0.3f;

		public const float OPACITY_HIDDEN = 0f;

		public const float SHAKE_INTENSITY = 8f;

		public const float SHAKE_FREQUENCY = 8f;

		public const float SCALE_PULSE_MAX = 1.08f;

		public const float SCALE_PULSE_MIN = 0.95f;

		public const float DURATION_PULSE_CYCLE = 0.6f;

		private static readonly string[] BackdropClassPatterns;

		private static readonly string[] ContentClassPatterns;

		private static readonly string[] ContentNameSuffixes;

		private static readonly Dictionary<VisualElement, List<int>> _activeTweens;

		private static readonly Stack<List<int>> _listPool;

		private static readonly HashSet<VisualElement> _pulsingElements;

		private static GameObject _tweenTarget;

		public static void HoverEnter(VisualElement element, float scale = 1.03f)
		{
		}

		public static void HoverExit(VisualElement element)
		{
		}

		public static void Press(VisualElement element, Action onComplete = null)
		{
		}

		public static void SuccessPulse(VisualElement element, Action onComplete = null)
		{
		}

		public static void ErrorShake(VisualElement element, Action onComplete = null)
		{
		}

		public static void TabSelect(VisualElement tab)
		{
		}

		public static void FadeIn(VisualElement element, bool withScale = true, Action onComplete = null)
		{
		}

		public static void FadeOut(VisualElement element, bool withScale = true, Action onComplete = null)
		{
		}

		public static void PanelOpen(VisualElement container, PanelAnimSpeed speed = PanelAnimSpeed.Fast, Action onComplete = null)
		{
		}

		public static void PanelClose(VisualElement container, PanelAnimSpeed speed = PanelAnimSpeed.Fast, Action onComplete = null)
		{
		}

		public static void PanelOpenWithBackdrop(VisualElement backdrop, VisualElement content, PanelAnimSpeed speed = PanelAnimSpeed.Fast, Action onComplete = null)
		{
		}

		public static void PanelCloseWithBackdrop(VisualElement backdrop, VisualElement content, PanelAnimSpeed speed = PanelAnimSpeed.Fast, Action onComplete = null)
		{
		}

		private static (VisualElement, VisualElement) DetectBackdropContent(VisualElement container)
		{
			return default((VisualElement, VisualElement));
		}

		private static bool HasClassContaining(VisualElement element, string pattern)
		{
			return false;
		}

		public static void SlideIn(VisualElement element, SlideDirection direction = SlideDirection.Bottom, float distance = 50f, float duration = 0.15f, Action onComplete = null)
		{
		}

		public static void SlideOut(VisualElement element, SlideDirection direction = SlideDirection.Bottom, float distance = 50f, float duration = 0.15f, Action onComplete = null)
		{
		}

		private static float GetPanelDuration(PanelAnimSpeed speed)
		{
			return 0f;
		}

		private static (float, float) GetSlideOffset(SlideDirection direction, float distance)
		{
			return default((float, float));
		}

		public static void AttentionPing(VisualElement element)
		{
		}

		public static void ProgressFill(VisualElement fillElement, float targetPercent, float duration = 0.25f)
		{
		}

		public static void SetDisabled(VisualElement element, bool disabled)
		{
		}

		public static void StartPulse(VisualElement element, float minScale = 0.95f, float maxScale = 1.08f)
		{
		}

		public static void StopPulse(VisualElement element)
		{
		}

		public static bool IsPulsing(VisualElement element)
		{
			return false;
		}

		public static void StopAllPulses()
		{
		}

		private static void StartPulseLoop(VisualElement element, float minScale, float maxScale, bool goingUp)
		{
		}

		public static void CancelAnimation(VisualElement element)
		{
		}

		public static void CancelAllAnimations()
		{
		}

		private static List<int> GetOrCreateTweenList(VisualElement element)
		{
			return null;
		}

		private static void TrackTween(VisualElement element, int tweenId)
		{
		}

		private static void AnimateScale(VisualElement element, float target, float duration, LeanTweenType ease, Action onComplete = null)
		{
		}

		private static void AnimateOpacity(VisualElement element, float target, float duration, LeanTweenType ease, Action onComplete = null)
		{
		}

		private static void AnimateTranslateY(VisualElement element, float targetY, float duration, LeanTweenType ease, Action onComplete = null)
		{
		}

		private static void AnimateTranslate(VisualElement element, float targetX, float targetY, float duration, LeanTweenType ease, Action onComplete = null)
		{
		}

		private static void AnimateShake(VisualElement element, float intensity, float duration, Action onComplete = null)
		{
		}

		private static void AnimateWidthPercent(VisualElement element, float targetPercent, float duration, LeanTweenType ease)
		{
		}

		private static void RemoveTweenTracking(VisualElement element, int tweenId)
		{
		}

		private static void ScheduleCallback(float delay, Action callback)
		{
		}

		private static GameObject GetTweenTarget()
		{
			return null;
		}
	}
}
