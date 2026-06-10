using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class TagListItem : ListItem
	{
		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private Toggle toggle;

		private TagJumpToSelection jumpToComponent;

		public RectTransform rectTransform;

		public string tagName;

		public string tagCategory;

		private void OnEnable()
		{
		}

		public override void SetViewportRestraint(RectTransform content, RectTransform viewport)
		{
		}

		public override void Setup(string tagName, string tagCategory)
		{
		}

		public override void Setup()
		{
		}

		public void Toggled(bool isOn)
		{
		}

		private bool IsTagSelected(string tagName)
		{
			return false;
		}
	}
}
