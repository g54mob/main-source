using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class AnimatedIconHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public enum PlayType
		{
			CLICK = 0,
			ON_POINTER_ENTER = 1
		}

		public PlayType playType;

		private Animator iconAnimator;

		private Button eventButton;

		private bool isClicked;

		private void Start()
		{
			iconAnimator = base.gameObject.GetComponent<Animator>();
			if (playType == PlayType.CLICK)
			{
				eventButton = base.gameObject.GetComponent<Button>();
				eventButton.onClick.AddListener(ClickEvent);
			}
		}

		public void ClickEvent()
		{
			if (isClicked)
			{
				iconAnimator.Play("Out");
				isClicked = false;
			}
			else
			{
				iconAnimator.Play("In");
				isClicked = true;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (playType == PlayType.ON_POINTER_ENTER)
			{
				iconAnimator.Play("In");
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (playType == PlayType.ON_POINTER_ENTER)
			{
				iconAnimator.Play("Out");
			}
		}
	}
}
