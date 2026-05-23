using Presentation.Locators;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI.ButtonHelpers
{
	public class SliderSFX : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler
	{
		[SerializeField]
		private Slider _slider;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		private void Awake()
		{
			if (_slider == null)
			{
				_slider = GetComponent<Slider>();
			}
		}

		private void PlaySFX(float _ = 0f)
		{
			if (!(_slider == null) && !(_audioManagerLocator == null) && !(_audioManagerLocator.AudioManager == null))
			{
				_audioManagerLocator?.AudioManager.PlayButtonSound();
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			PlaySFX();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			PlaySFX();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!(_slider == null) && !(_audioManagerLocator == null) && !(_audioManagerLocator.AudioManager == null))
			{
				_audioManagerLocator?.AudioManager.PlayButtonHoverSound();
			}
		}
	}
}
