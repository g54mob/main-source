using System;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class GalleryImageButtonListItem : ListItem
	{
		[SerializeField]
		private Button button;

		private Color _normalColorDefault;

		protected override void Awake()
		{
			base.Awake();
			_normalColorDefault = button.colors.normalColor;
		}

		public override void Setup(Action clicked)
		{
			base.Setup();
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(delegate
			{
				clicked();
			});
			base.gameObject.SetActive(value: true);
		}

		public override void Select()
		{
			ColorBlock colors = button.colors;
			colors.normalColor = button.colors.selectedColor;
			button.colors = colors;
		}

		public override void DeSelect()
		{
			ColorBlock colors = button.colors;
			colors.normalColor = _normalColorDefault;
			button.colors = colors;
		}
	}
}
