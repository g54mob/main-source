using System.Collections;
using ModIO.Util;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModIOBrowser.Implementation
{
	public class ViewportRestraint : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		public float PercentPaddingHorizontal = 0.05f;

		public float PercentPaddingVertical = 0.25f;

		public bool adjustHorizontally;

		public bool adjustVertically = true;

		private static float transitionTime = 0.25f;

		public RectTransform Viewport;

		public RectTransform DefaultViewportContainer;

		public RectTransform HorizontalViewportContainer;

		private static IEnumerator HorizontalTransitionCoroutine;

		public void OnSelect(BaseEventData eventData)
		{
			if (!SelfInstancingMonoSingleton<InputNavigation>.Instance.mouseNavigation)
			{
				if (adjustVertically)
				{
					CheckSelectionVerticalVisibility();
				}
				else if (adjustHorizontally)
				{
					CheckSelectionHorizontalVisibility();
				}
			}
		}

		private void BeginTransition(IEnumerator coroutineHandle, IEnumerator coroutine, Vector2 containersNewTargetPosition)
		{
			if (coroutineHandle != null)
			{
				StopCoroutine(coroutineHandle);
			}
			coroutineHandle = coroutine;
			StartCoroutine(coroutineHandle);
		}

		public void CheckSelectionHorizontalVisibility()
		{
			RectTransformOverlap rectTransformOverlap = new RectTransformOverlap(base.transform as RectTransform);
			RectTransformOverlap b = new RectTransformOverlap(Viewport ?? (SelfInstancingMonoSingleton<Home>.Instance.BrowserPanel.transform as RectTransform));
			if (rectTransformOverlap.IsOutsideOfRectX(b, PercentPaddingHorizontal))
			{
				float num = RectTransformOverlap.DistanceFromEdgeX(rectTransformOverlap, b, PercentPaddingHorizontal);
				Vector2 vector = ((HorizontalViewportContainer == null) ? DefaultViewportContainer.position : HorizontalViewportContainer.position);
				Vector2 vector2 = new Vector2(vector.x + num, vector.y);
				BeginTransition(HorizontalTransitionCoroutine, TransitionHorizontally(vector2, HorizontalViewportContainer ?? DefaultViewportContainer), vector2);
			}
		}

		public void CheckSelectionVerticalVisibility()
		{
			RectTransformOverlap rectTransformOverlap = new RectTransformOverlap(base.transform as RectTransform);
			RectTransformOverlap b = new RectTransformOverlap(Viewport ?? (SelfInstancingMonoSingleton<Home>.Instance.BrowserPanel.transform as RectTransform));
			if (rectTransformOverlap.IsOutsideOfRectY(b, PercentPaddingVertical))
			{
				float num = RectTransformOverlap.DistanceFromEdgeY(rectTransformOverlap, b, PercentPaddingVertical);
				Vector2 vector = new Vector2(DefaultViewportContainer.position.x, DefaultViewportContainer.position.y + num);
				BeginTransition(HorizontalTransitionCoroutine, TransitionVertically(vector, DefaultViewportContainer), vector);
			}
		}

		private static IEnumerator Transition(Vector2 end, Transform parent, bool lockX, bool lockY)
		{
			Vector2 start = parent.position;
			Vector2 distance = end - start;
			float timePassed = 0f;
			while (timePassed <= transitionTime)
			{
				timePassed += Time.fixedDeltaTime;
				float num = timePassed / transitionTime;
				Vector2 vector = start + distance * num;
				if (lockX)
				{
					vector.x = parent.position.x;
				}
				if (lockY)
				{
					vector.y = parent.position.y;
				}
				parent.position = vector;
				yield return new WaitForSecondsRealtime(0.01f);
			}
		}

		private static IEnumerator TransitionHorizontally(Vector2 end, Transform parent)
		{
			yield return Transition(end, parent, lockX: false, lockY: true);
		}

		private static IEnumerator TransitionVertically(Vector2 end, Transform parent)
		{
			yield return Transition(end, parent, lockX: true, lockY: false);
		}
	}
}
