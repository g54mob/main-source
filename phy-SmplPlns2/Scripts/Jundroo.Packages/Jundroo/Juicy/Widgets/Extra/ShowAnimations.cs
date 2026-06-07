using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Jundroo.Juicy.Widgets.Extra
{
	public static class ShowAnimations
	{
		public static IWidgetAnimation CreateShowAnimation(Widget widget, AnimationData animationData, Vector3 shownPosition)
		{
			ShowAnimationType animationType = Enum.Parse<ShowAnimationType>(animationData.Target);
			if (IsSlideAnimation(animationType))
			{
				return CreateSlideAnimation(widget, animationData, animationType, shownPosition);
			}
			if (IsScaleAnimation(animationType))
			{
				return CreateScaleAnimation(widget, animationData, animationType);
			}
			return CreateFadeAnimation(widget, animationData, animationType);
		}

		public static bool IsScaleAnimation(ShowAnimationType animationType)
		{
			if (animationType != ShowAnimationType.GrowHorizontal && animationType != ShowAnimationType.GrowVertical && animationType != ShowAnimationType.GrowBoth && animationType != ShowAnimationType.ShrinkHorizontal && animationType != ShowAnimationType.ShrinkVertical)
			{
				return animationType == ShowAnimationType.ShrinkBoth;
			}
			return true;
		}

		public static bool IsSlideAnimation(ShowAnimationType animationType)
		{
			if (animationType != ShowAnimationType.SlideInLeft && animationType != ShowAnimationType.SlideInRight && animationType != ShowAnimationType.SlideInTop && animationType != ShowAnimationType.SlideInBottom && animationType != ShowAnimationType.SlideOutLeft && animationType != ShowAnimationType.SlideOutRight && animationType != ShowAnimationType.SlideOutTop)
			{
				return animationType == ShowAnimationType.SlideOutBottom;
			}
			return true;
		}

		private static IWidgetAnimation CreateFadeAnimation(Widget widget, AnimationData animationData, ShowAnimationType animationType)
		{
			float opacity = ((animationType == ShowAnimationType.FadeIn) ? 0f : 1f);
			float endValue = ((animationType == ShowAnimationType.FadeOut) ? 0f : 1f);
			widget.Opacity = opacity;
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => widget.Opacity, delegate(float x)
			{
				widget.Opacity = x;
			}, endValue, animationData.Duration).SetUpdate(isIndependentUpdate: true).Pause();
			animationData.ApplyEase(tweenerCore);
			tweenerCore.OnStart(delegate
			{
				widget.Visible = true;
			});
			if (animationData.Delay > 0f)
			{
				tweenerCore.SetDelay(animationData.Delay);
			}
			return new WidgetTweenAnimation(tweenerCore);
		}

		private static IWidgetAnimation CreateScaleAnimation(Widget widget, AnimationData animationData, ShowAnimationType animationType)
		{
			Vector3 localScale = Vector3.one;
			Vector3 endValue = Vector3.one;
			switch (animationType)
			{
			case ShowAnimationType.GrowHorizontal:
				localScale = new Vector3(0f, 1f, 1f);
				break;
			case ShowAnimationType.GrowVertical:
				localScale = new Vector3(1f, 0f, 1f);
				break;
			case ShowAnimationType.GrowBoth:
				localScale = new Vector3(0f, 0f, 1f);
				break;
			case ShowAnimationType.ShrinkHorizontal:
				endValue = new Vector3(0f, 1f, 1f);
				break;
			case ShowAnimationType.ShrinkVertical:
				endValue = new Vector3(1f, 0f, 1f);
				break;
			case ShowAnimationType.ShrinkBoth:
				endValue = new Vector3(0f, 0f, 1f);
				break;
			}
			widget.Rect.localScale = localScale;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(() => widget.Rect.localScale, delegate(Vector3 x)
			{
				widget.Rect.localScale = x;
			}, endValue, animationData.Duration).SetUpdate(isIndependentUpdate: true).Pause();
			animationData.ApplyEase(tweenerCore);
			tweenerCore.OnStart(delegate
			{
				widget.Visible = true;
			});
			if (animationData.Delay > 0f)
			{
				tweenerCore.SetDelay(animationData.Delay);
			}
			return new WidgetTweenAnimation(tweenerCore);
		}

		private static IWidgetAnimation CreateSlideAnimation(Widget widget, AnimationData animationData, ShowAnimationType animationType, Vector3 shownPosition)
		{
			RectTransform rectTransform = (RectTransform)widget.Rect.parent;
			widget.Rect.anchoredPosition = shownPosition;
			Vector3[] array = new Vector3[4];
			Vector3[] array2 = new Vector3[4];
			widget.Rect.GetWorldCorners(array);
			rectTransform.GetWorldCorners(array2);
			Vector3[] array3 = new Vector3[4];
			Vector3[] array4 = new Vector3[4];
			for (int i = 0; i < 4; i++)
			{
				array3[i] = rectTransform.InverseTransformPoint(array[i]);
				array4[i] = rectTransform.InverseTransformPoint(array2[i]);
			}
			Vector2 anchoredPosition = shownPosition;
			Vector2 endValue = shownPosition;
			switch (animationType)
			{
			case ShowAnimationType.SlideInLeft:
				anchoredPosition.x = shownPosition.x + (array4[1].x - array3[2].x);
				break;
			case ShowAnimationType.SlideInRight:
				anchoredPosition.x = shownPosition.x + (array4[2].x - array3[1].x);
				break;
			case ShowAnimationType.SlideInTop:
				anchoredPosition.y = shownPosition.y + (array4[1].y - array3[0].y);
				break;
			case ShowAnimationType.SlideInBottom:
				anchoredPosition.y = shownPosition.y + (array4[0].y - array3[1].y);
				break;
			case ShowAnimationType.SlideOutLeft:
				endValue.x = shownPosition.x + (array4[1].x - array3[2].x);
				break;
			case ShowAnimationType.SlideOutRight:
				endValue.x = shownPosition.x + (array4[2].x - array3[1].x);
				break;
			case ShowAnimationType.SlideOutTop:
				endValue.y = shownPosition.y + (array4[1].y - array3[0].y);
				break;
			case ShowAnimationType.SlideOutBottom:
				endValue.y = shownPosition.y + (array4[0].y - array3[1].y);
				break;
			}
			widget.Rect.anchoredPosition = anchoredPosition;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(() => widget.Rect.anchoredPosition, delegate(Vector2 x)
			{
				widget.Rect.anchoredPosition = x;
			}, endValue, animationData.Duration).SetUpdate(isIndependentUpdate: true).Pause();
			animationData.ApplyEase(tweenerCore);
			tweenerCore.OnStart(delegate
			{
				widget.Visible = true;
			});
			if (animationData.Delay > 0f)
			{
				tweenerCore.SetDelay(animationData.Delay);
			}
			return new WidgetTweenAnimation(tweenerCore);
		}
	}
}
