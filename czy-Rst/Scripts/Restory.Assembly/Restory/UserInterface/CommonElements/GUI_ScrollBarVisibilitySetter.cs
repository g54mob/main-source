using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_ScrollBarVisibilitySetter : MonoBehaviour
	{
		[SerializeField]
		private Scrollbar scrollbar;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private float notActiveAlpha = 0.5f;

		private float previousSize;

		private float resetPositionElapsed;

		private const float RESET_POSITION_DELAY = 1f;

		public float CurrentValue => scrollbar.value;

		public bool Min
		{
			get
			{
				if (IsScrollbarActive())
				{
					return scrollbar.value <= 0.001f;
				}
				return true;
			}
		}

		public bool Max
		{
			get
			{
				if (IsScrollbarActive())
				{
					return scrollbar.size <= scrollbar.value;
				}
				return true;
			}
		}

		private void Reset()
		{
			base.gameObject.TryGetComponent<Scrollbar>(out scrollbar);
		}

		public void ResetPosition()
		{
			ScrollToTop();
			resetPositionElapsed = Time.realtimeSinceStartup;
		}

		private void LateUpdate()
		{
			if (!Mathf.Approximately(previousSize, scrollbar.size))
			{
				if (resetPositionElapsed + 1f - Time.realtimeSinceStartup > 0f)
				{
					ScrollToTop();
				}
				previousSize = scrollbar.size;
				bool flag = IsScrollbarActive();
				scrollbar.interactable = flag;
				float alpha = (flag ? 1f : notActiveAlpha);
				canvasGroup.alpha = alpha;
			}
		}

		public bool IsScrollbarActive()
		{
			if (!Mathf.Approximately(scrollbar.size, 1f))
			{
				return !Mathf.Approximately(scrollbar.size, 0f);
			}
			return false;
		}

		private void ScrollToTop()
		{
			scrollbar.value = 1f;
		}
	}
}
