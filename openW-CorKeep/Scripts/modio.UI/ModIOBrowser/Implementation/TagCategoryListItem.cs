using TMPro;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	internal class TagCategoryListItem : ListItem
	{
		[SerializeField]
		private TMP_Text title;

		public override void Setup(string tagName)
		{
			base.Setup();
			title.text = tagName;
			base.transform.SetAsLastSibling();
			base.gameObject.SetActive(value: true);
		}
	}
}
