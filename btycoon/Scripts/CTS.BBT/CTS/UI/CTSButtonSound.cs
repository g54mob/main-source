using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public class CTSButtonSound : MonoBehaviour
	{
		private CTSButton _button;

		[SerializeField]
		private AudioAsset _clicSound;

		[SerializeField]
		private AudioAsset _hoverSound;

		private void Awake()
		{
			_button = GetComponent<CTSButton>();
			_button.Pressed += _button_Pressed;
			_button.SelectionStateChanged += Button_SelectionStateChanged;
		}

		private void _button_Pressed()
		{
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_clicSound);
		}

		private void Button_SelectionStateChanged(ESelectionState obj)
		{
			if (obj == ESelectionState.Highlighted)
			{
				MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_hoverSound);
			}
		}

		private void OnDestroy()
		{
			_button.SelectionStateChanged -= Button_SelectionStateChanged;
		}
	}
}
