using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;
using UnityEngine.UI;

namespace AirFishLab.ScrollingList.Demo
{
	public class ImageListBox : ListBox
	{
		[SerializeField]
		private Image _image;

		public Sprite Content { get; private set; }

		protected override void UpdateDisplayContent(IListContent listContent)
		{
			Content = ((SpriteListContent)listContent).Value;
			_image.sprite = Content;
		}
	}
}
