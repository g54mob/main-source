using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Almanac;
using UnityEngine;

namespace NSMedieval.UI
{
	public class AlmanacSearchGroupItemView : LayoutGroupItemView
	{
		private int expandButtonIndex = 1;

		private int expandArrow = 2;

		private bool groupExpanded;

		private List<AlmanacSearchSubgroupItemView> groupChidlren = new List<AlmanacSearchSubgroupItemView>();

		public LayoutGroupView SubgroupParent => GetComponent<LayoutGroupView>();

		public List<AlmanacSearchSubgroupItemView> GroupChildren => groupChidlren;

		private SoundButton GroupExpandButton => base.GroupItems[expandButtonIndex].GetComponent<SoundButton>();

		public void Hide(bool hide)
		{
			groupExpanded = false;
			UpdateChildren();
			base.gameObject.SetActive(hide);
		}

		public void Refresh()
		{
			bool active = (from child in GroupChildren
				where child.gameObject.activeSelf
				select child.gameObject.activeSelf).FirstOrDefault();
			base.gameObject.SetActive(active);
			groupExpanded = active;
			RotateToggleSprite();
		}

		public void SetupGroup(string text, string textKey)
		{
			SetText(text, textKey);
			GroupExpandButton.AddCleanListener(OnExpansionChange);
			GroupExpandButton.ButtonClickSound = "UI_AlmanacClick";
			GroupExpandButton.ButtonHoverSound = "UI_AlmanacHover";
		}

		public void AddChild(AlmanacSearchSubgroupItemView child)
		{
			groupChidlren.Add(child);
			if (groupChidlren.Count == 1)
			{
				GroupExpandButton.transform.parent.gameObject.SetActive(value: true);
				UpdateChildren();
			}
		}

		private void OnExpansionChange()
		{
			groupExpanded = !groupExpanded;
			UpdateChildren();
		}

		private void UpdateChildren()
		{
			foreach (AlmanacSearchSubgroupItemView item in groupChidlren)
			{
				item.gameObject.SetActive(groupExpanded);
			}
			RotateToggleSprite();
			MonoSingleton<AlmanacController>.Instance.OnSearchGroupExpansion();
		}

		private void RotateToggleSprite()
		{
			base.GroupItems[expandArrow].transform.eulerAngles = new Vector3(0f, 0f, groupExpanded ? (-90f) : 0f);
		}
	}
}
