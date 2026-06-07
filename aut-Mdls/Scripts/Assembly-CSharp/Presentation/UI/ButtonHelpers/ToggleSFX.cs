using Presentation.Locators;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI.ButtonHelpers
{
	public class ToggleSFX : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
	{
		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		private void Awake()
		{
			if (_toggle == null)
			{
				_toggle = GetComponent<Toggle>();
			}
			if (_toggle != null)
			{
				_toggle.onValueChanged.AddListener(PlaySFX);
			}
		}

		private void OnDestroy()
		{
			if (_toggle != null)
			{
				_toggle.onValueChanged.RemoveListener(PlaySFX);
			}
		}

		private void PlaySFX(bool _ = false)
		{
			if (!(_toggle == null) && !(_audioManagerLocator == null) && !(_audioManagerLocator.AudioManager == null))
			{
				_audioManagerLocator?.AudioManager.PlayButtonSound();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!(_toggle == null) && !(_audioManagerLocator == null) && !(_audioManagerLocator.AudioManager == null))
			{
				_audioManagerLocator?.AudioManager.PlayButtonHoverSound();
			}
		}
	}
}
