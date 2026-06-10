using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[RequireComponent(typeof(ScrollRect))]
	public class ScrollRectExtension : MonoBehaviour
	{
		private ScrollRect scrollRect;

		[SerializeField]
		private bool scrollToTopOnEnable;

		private void Awake()
		{
			scrollRect = GetComponent<ScrollRect>();
		}

		private void ScrollToTop()
		{
			scrollRect.normalizedPosition = new Vector2(0f, 1f);
		}

		private void ScrollToBottom()
		{
			scrollRect.normalizedPosition = new Vector2(0f, 0f);
		}

		private void OnEnable()
		{
			if (scrollToTopOnEnable)
			{
				ScrollToTop();
			}
		}
	}
}
