using System;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.TextBlock
{
	public class TextBlockIconButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _selectedUI;

		[SerializeField]
		private Image _image;

		private int _iconKey;

		private Action<int> _onButtonClicked;

		private void Awake()
		{
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			_onButtonClicked(_iconKey);
		}

		public void Setup(Sprite icon, int iconKey, Action<int> onButtonClicked)
		{
			_image.sprite = icon;
			_iconKey = iconKey;
			_onButtonClicked = onButtonClicked;
		}

		public void SetIsSelected(bool selected)
		{
			_selectedUI.SetActive(selected);
		}
	}
}
