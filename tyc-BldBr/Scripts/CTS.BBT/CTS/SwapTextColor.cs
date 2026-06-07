using CTS.UI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class SwapTextColor : MonoBehaviour
	{
		private CTSButton _button;

		[SerializeField]
		private TextMeshProUGUI _textChangeColor;

		[SerializeField]
		private Color _baseColor;

		[SerializeField]
		private Color _selectColor;

		private void Awake()
		{
			_textChangeColor.color = _baseColor;
			_button = GetComponent<CTSButton>();
			_button.SelectionStateChanged += Button_SelectionStateChanged;
		}

		private void Button_SelectionStateChanged(ESelectionState obj)
		{
			if (obj == ESelectionState.Selected)
			{
				_textChangeColor.color = _selectColor;
			}
			else
			{
				_textChangeColor.color = _baseColor;
			}
		}

		private void OnDestroy()
		{
			_button.SelectionStateChanged -= Button_SelectionStateChanged;
		}
	}
}
