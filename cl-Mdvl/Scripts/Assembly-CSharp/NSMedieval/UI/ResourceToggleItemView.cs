using System.Collections;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Resources;
using NSMedieval.Sound;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ResourceToggleItemView : LayoutGroupItemView
	{
		public delegate void GroupUpdated();

		[SerializeField]
		private float indentOffset = 10f;

		[SerializeField]
		private float entryDefaultHeight = 24f;

		private readonly int textIndex;

		private readonly int expandImageIndex = 1;

		private readonly int toggleIndex = 2;

		private readonly int checkImageIndex = 3;

		private readonly int partialCheckIndex = 4;

		private readonly int childGroupIndex = 5;

		private readonly int expandButtonIndex = 6;

		private int groupDepth;

		private bool groupExpanded;

		private readonly List<ResourceToggleItemView> immediateGroupChildren = new List<ResourceToggleItemView>();

		private string labelText;

		private List<string> tooltipLines = new List<string>();

		public CustomToggle GroupSelectToggle => base.GroupItems[toggleIndex].GetComponent<CustomToggle>();

		public bool PartiallySelected => base.GroupItems[partialCheckIndex].activeSelf;

		public void SetExpanded(bool groupExpanded)
		{
			this.groupExpanded = groupExpanded;
		}

		public void SetupGroup(string nameKey, string prefix, int depth)
		{
			groupDepth = depth;
			labelText = string.Empty;
			tooltipLines.Clear();
			RotateToggleSprite();
			if (prefix.Equals("group"))
			{
				labelText = base.Localize.GetText("resource_" + prefix + "_" + nameKey);
			}
			else
			{
				if (nameKey.Equals("worker"))
				{
					nameKey = "human_carcass";
				}
				if (nameKey.Equals("enemy"))
				{
					nameKey = "enemy_carcass";
				}
				labelText = ResourceUtils.GetTextIcon(nameKey) + " " + ResourceUtils.GetLocalizedProtoName(nameKey);
				tooltipLines.AddRange(ResourceUtils.GetTooltipData(nameKey));
				SetExpandButtonActive(active: false);
			}
			UpdateLabel();
			GetComponent<RectTransform>().sizeDelta = IndentGroup(GetComponent<RectTransform>(), depth);
			base.GroupItems[childGroupIndex].GetComponent<RectTransform>().sizeDelta = IndentGroup(GetComponent<RectTransform>(), depth);
			base.GroupItems[expandButtonIndex].GetComponent<SoundButton>().onClick.AddListener(delegate
			{
				string soundID = (groupExpanded ? "UI_Collapse" : "UI_Expand");
				MonoSingleton<AudioManager>.Instance.PlaySound(soundID);
				StartCoroutine(OnExpansionChange());
			});
			SetActive(depth == 0);
		}

		public void AddChild(ResourceToggleItemView child)
		{
			immediateGroupChildren.Add(child);
			if (immediateGroupChildren.Count == 1)
			{
				SetExpandButtonActive(active: true);
				UpdateChildren();
			}
		}

		public void SetSelectedPartial()
		{
			base.GroupItems[partialCheckIndex].SetActive(value: true);
			base.GroupItems[checkImageIndex].SetActive(value: false);
			GroupSelectToggle.targetGraphic = base.GroupItems[partialCheckIndex].GetComponent<Image>();
			GroupSelectToggle.SetIsOnWithoutNotify(value: true);
		}

		public void SetSelectedFull()
		{
			base.GroupItems[partialCheckIndex].SetActive(value: false);
			base.GroupItems[checkImageIndex].SetActive(value: true);
			GroupSelectToggle.targetGraphic = base.GroupItems[checkImageIndex].GetComponent<Image>();
			GroupSelectToggle.SetIsOnWithoutNotify(value: true);
		}

		public void SetSelected(bool selected)
		{
			GroupSelectToggle.SetIsOnWithoutNotify(selected);
			base.GroupItems[checkImageIndex].SetActive(selected);
			base.GroupItems[partialCheckIndex].SetActive(value: false);
		}

		private Vector2 IndentGroup(RectTransform rect, int depth)
		{
			return new Vector2(Mathf.Abs(rect.rect.x + (float)depth * indentOffset), entryDefaultHeight);
		}

		private void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
			if (active)
			{
				UpdateLabel();
			}
		}

		private void UpdateLabel()
		{
			SetText(labelText);
			SetTooltipLines(tooltipLines);
		}

		public void RotateToggleSprite()
		{
			base.GroupItems[expandImageIndex].transform.eulerAngles = new Vector3(0f, 0f, groupExpanded ? (-90f) : 0f);
		}

		private IEnumerator OnExpansionChange()
		{
			groupExpanded = !groupExpanded;
			RotateToggleSprite();
			foreach (ResourceToggleItemView immediateGroupChild in immediateGroupChildren)
			{
				immediateGroupChild.SetActive(groupExpanded);
				yield return new WaitForSecondsRealtime(1E-07f);
			}
			yield return new WaitForSecondsRealtime(1E-06f);
			MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdated();
		}

		public void UpdateChildren()
		{
			foreach (ResourceToggleItemView immediateGroupChild in immediateGroupChildren)
			{
				immediateGroupChild.SetActive(groupExpanded);
			}
		}

		private void SetExpandButtonActive(bool active)
		{
			base.GroupItems[expandButtonIndex].GetComponent<SoundButton>().enabled = active;
			base.GroupItems[expandImageIndex].GetComponentInChildren<Image>().enabled = active;
		}
	}
}
