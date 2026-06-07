using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class SliderManager : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public TextMeshProUGUI valueText;

		public TextMeshProUGUI popupValueText;

		public bool usePercent;

		public bool showValue;

		public bool showPopupValue;

		public bool useRoundValue;

		private Slider mainSlider;

		private Animator sliderAnimator;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}
	}
}
