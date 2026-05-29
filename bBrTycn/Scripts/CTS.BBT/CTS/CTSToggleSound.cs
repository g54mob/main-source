using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class CTSToggleSound : MonoBehaviour
	{
		private CTSToggle _toggle;

		[SerializeField]
		private AudioAsset _clicSound;

		[SerializeField]
		private AudioAsset _hoverSound;

		[SerializeField]
		private bool _needHoverSound;

		private void Awake()
		{
			_toggle = GetComponent<CTSToggle>();
			_toggle.Pressed += _toggle_Pressed;
			if (_needHoverSound)
			{
				_toggle.SelectionStateChanged += Button_SelectionStateChanged;
			}
		}

		private void _toggle_Pressed()
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
			_toggle.SelectionStateChanged -= Button_SelectionStateChanged;
			_toggle.Pressed -= _toggle_Pressed;
		}
	}
}
