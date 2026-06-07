using FMODUnity;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI.ButtonHelpers
{
	public class ButtonSFX : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private EventReference _overrideAudioEvent;

		[SerializeField]
		private bool _playOnClick = true;

		[SerializeField]
		private bool _playOnHover = true;

		private void Awake()
		{
			if ((_button != null || TryGetComponent<Button>(out _button)) && _playOnClick)
			{
				_button.onClick.AddListener(PlaySFX);
			}
		}

		private void OnDestroy()
		{
			if (_button != null && _playOnClick)
			{
				_button.onClick.RemoveListener(PlaySFX);
			}
		}

		private void PlaySFX()
		{
			if (!(_audioManagerLocator.AudioManager == null))
			{
				if (_overrideAudioEvent.IsNull)
				{
					_audioManagerLocator?.AudioManager.PlayButtonSound();
				}
				else
				{
					_audioManagerLocator?.AudioManager.PlayButtonSound(_overrideAudioEvent);
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!(_audioManagerLocator.AudioManager == null) && _playOnHover)
			{
				_audioManagerLocator?.AudioManager.PlayButtonHoverSound();
			}
		}
	}
}
