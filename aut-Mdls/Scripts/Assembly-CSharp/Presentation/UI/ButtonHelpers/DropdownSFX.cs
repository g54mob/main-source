using Presentation.Locators;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.UI.ButtonHelpers
{
	public class DropdownSFX : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler
	{
		[SerializeField]
		private TMP_Dropdown _dropdown;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		private void Awake()
		{
			if (_dropdown == null)
			{
				_dropdown = GetComponent<TMP_Dropdown>();
			}
			if (_dropdown != null)
			{
				_dropdown.onValueChanged.AddListener(PlaySFX);
			}
		}

		private void OnDestroy()
		{
			if (_dropdown != null)
			{
				_dropdown.onValueChanged.RemoveListener(PlaySFX);
			}
		}

		private void PlaySFX(int _ = 0)
		{
			if (!(_dropdown == null) && !(_audioManagerLocator == null) && !(_audioManagerLocator.AudioManager == null))
			{
				_audioManagerLocator?.AudioManager.PlayButtonSound();
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			PlaySFX();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!(_dropdown == null) && !(_audioManagerLocator == null) && !(_audioManagerLocator.AudioManager == null))
			{
				_audioManagerLocator?.AudioManager.PlayButtonHoverSound();
			}
		}
	}
}
