using System;
using Events.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.MapEditor
{
	public class IslandMapEditorButton : MonoBehaviour
	{
		[SerializeField]
		private GUIDEvent _islandButtonPressed;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private Button _button;

		private Guid _id;

		public void SetIsland(Sprite sprite, string name, Guid id)
		{
			_image.sprite = sprite;
			_text.SetText(name);
			_id = id;
		}

		private void Start()
		{
			_button.onClick.AddListener(IslandPressed);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(IslandPressed);
		}

		private void IslandPressed()
		{
			_islandButtonPressed.Fire(_id);
		}
	}
}
