using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class IslandEditorToolBarButton : MonoBehaviour
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private TMP_Text _label;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _selectedContainer;

		public event Action<IslandEditorToolBarButton> Selected;

		private void Start()
		{
			_button.onClick.AddListener(ButtonPressed);
			SetSelected(isSelected: false);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(ButtonPressed);
		}

		private void ButtonPressed()
		{
			this.Selected?.Invoke(this);
		}

		public void SetSprite(Sprite sprite, Color colour, string name)
		{
			_image.sprite = sprite;
			_image.color = colour;
			_label.SetText(name);
		}

		public void SetSelected(bool isSelected)
		{
			_selectedContainer.SetActive(isSelected);
		}
	}
}
