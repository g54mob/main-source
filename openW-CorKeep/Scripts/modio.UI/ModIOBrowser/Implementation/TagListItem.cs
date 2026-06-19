using ModIO.Util;
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

		[SerializeField]
		private string tagName;

		[SerializeField]
		private string tagCategory;

		private void OnEnable()
		{
			rectTransform = base.transform as RectTransform;
		}

		public override void SetViewportRestraint(RectTransform content, RectTransform viewport)
		{
			base.SetViewportRestraint(content, viewport);
			viewportRestraint.PercentPaddingVertical = 0.15f;
		}

		public override void Setup(string tagName, string tagCategory)
		{
			base.Setup();
			this.tagName = tagName;
			this.tagCategory = tagCategory;
			title.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get(tagName);
			base.transform.SetAsLastSibling();
			base.gameObject.SetActive(value: true);
			toggle.onValueChanged.RemoveAllListeners();
			toggle.isOn = IsTagSelected(tagName);
			toggle.onValueChanged.AddListener(Toggled);
			if (jumpToComponent != null)
			{
				Object.Destroy(jumpToComponent);
			}
		}

		public override void Setup()
		{
			jumpToComponent = base.gameObject.AddComponent<TagJumpToSelection>();
			jumpToComponent.selection = selectable;
			jumpToComponent.Setup();
		}

		public void Toggled(bool isOn)
		{
			Tag item = new Tag(tagCategory, tagName);
			if (isOn)
			{
				if (!SearchPanel.searchFilterTags.Contains(item))
				{
					SearchPanel.searchFilterTags.Add(item);
				}
			}
			else if (SearchPanel.searchFilterTags.Contains(item))
			{
				SearchPanel.searchFilterTags.Remove(item);
			}
		}

		private bool IsTagSelected(string tagName)
		{
			foreach (Tag searchFilterTag in SearchPanel.searchFilterTags)
			{
				if (searchFilterTag.name == tagName)
				{
					return true;
				}
			}
			return false;
		}
	}
}
