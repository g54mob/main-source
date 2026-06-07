using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;
using UnityEngine.UI;

namespace AirFishLab.ScrollingList.Demo
{
	public class NameListBox : ListBox
	{
		[SerializeField]
		private Text _contentText;

		public string Content { get; private set; }

		protected override void UpdateDisplayContent(IListContent listContent)
		{
			Content = ((StringListContent)listContent).Value;
			_contentText.text = Content;
		}
	}
}
