using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace NSMedieval.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class TutorialHighlightSquare : MonoBehaviour
	{
		[SerializeField]
		private Animator animator;

		private CanvasGroup canvasGroup;

		private RectTransform highlightSquareRect;

		private void Awake()
		{
			highlightSquareRect = GetComponent<RectTransform>();
			canvasGroup = GetComponent<CanvasGroup>();
			canvasGroup.alpha = 0f;
		}

		public void Show(RectTransform target)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\TutorialHighlightSquare.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Show at ");
				messageBuilder.AppendFormatted(target.position);
			}
			Log.Trace(messageBuilder);
			if (!target.gameObject.activeInHierarchy)
			{
				Hide();
				return;
			}
			canvasGroup.alpha = 1f;
			Vector3[] array = new Vector3[4];
			target.GetWorldCorners(array);
			Vector2 vector = RectTransformUtility.WorldToScreenPoint(null, array[0]);
			Vector2 vector2 = RectTransformUtility.WorldToScreenPoint(null, array[2]);
			float scaleFactor = highlightSquareRect.GetParentCanvas().scaleFactor;
			Vector2 vector3 = (vector2 - vector) / scaleFactor;
			Vector2 screenPoint = vector + (vector2 - vector) * 0.5f;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(highlightSquareRect.parent.GetComponent<RectTransform>(), screenPoint, null, out var localPoint);
			highlightSquareRect.anchoredPosition = localPoint;
			highlightSquareRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, vector3.x);
			highlightSquareRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, vector3.y);
			PlayAnimation();
		}

		private void PlayAnimation()
		{
			StopAnimation();
			animator.enabled = true;
			animator.Play("TutorialSelection", 0, 0f);
		}

		public void Hide()
		{
			Log.Trace("Hide", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\TutorialHighlightSquare.cs");
			canvasGroup.alpha = 0f;
			StopAnimation();
		}

		private void StopAnimation()
		{
			animator.enabled = false;
			animator.Rebind();
			animator.Update(0f);
		}
	}
}
