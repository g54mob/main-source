using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.UI.ModernUIPack
{
	public class TooltipContent : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public string description;

		public GameObject tooltipRect;

		public TextMeshProUGUI descriptionText;

		private TooltipManager tpManager;

		public Animator tooltipAnimator;

		private void Start()
		{
			if (tooltipRect == null || descriptionText == null)
			{
				try
				{
					tooltipRect = GameObject.Find("Tooltip Rect");
					descriptionText = tooltipRect.transform.GetComponentInChildren<TextMeshProUGUI>();
				}
				catch
				{
					Debug.LogError("No Tooltip object assigned.", this);
				}
			}
			if (tooltipRect != null)
			{
				tpManager = tooltipRect.GetComponentInParent<TooltipManager>();
				tooltipAnimator = tooltipRect.GetComponentInParent<Animator>();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (tooltipRect != null)
			{
				descriptionText.text = description;
				tpManager.allowUpdating = true;
				tooltipAnimator.gameObject.SetActive(value: false);
				tooltipAnimator.gameObject.SetActive(value: true);
				tooltipAnimator.Play("In");
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (tooltipRect != null)
			{
				tooltipAnimator.Play("Out");
				tpManager.allowUpdating = false;
			}
		}
	}
}
