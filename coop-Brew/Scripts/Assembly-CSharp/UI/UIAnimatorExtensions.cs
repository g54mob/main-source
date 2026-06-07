using System;
using UnityEngine.UIElements;

namespace UI
{
	public static class UIAnimatorExtensions
	{
		public static Button WithButtonAnimations(this Button button, bool playSound = true)
		{
			return null;
		}

		public static T WithHoverAnimation<T>(this T element, float hoverScale = 1.03f) where T : VisualElement
		{
			return null;
		}

		public static T WithPressAnimation<T>(this T element) where T : VisualElement
		{
			return null;
		}

		public static T WithInteractionAnimations<T>(this T element, float hoverScale = 1.03f) where T : VisualElement
		{
			return null;
		}

		public static Button WithPulseAnimation(this Button button)
		{
			return null;
		}

		public static void PlaySuccess(this VisualElement element, Action onComplete = null)
		{
		}

		public static void PlayError(this VisualElement element, Action onComplete = null)
		{
		}

		public static void PlayAttention(this VisualElement element)
		{
		}

		public static void FadeIn(this VisualElement element, bool withScale = true, Action onComplete = null)
		{
		}

		public static void FadeOut(this VisualElement element, bool withScale = true, Action onComplete = null)
		{
		}

		public static void AnimateDisabled(this VisualElement element, bool disabled)
		{
		}

		public static void CancelAnimations(this VisualElement element)
		{
		}

		public static void ResetHoverState(this VisualElement element)
		{
		}

		public static void ResetAllButtonHoverStates(this VisualElement container)
		{
		}
	}
}
