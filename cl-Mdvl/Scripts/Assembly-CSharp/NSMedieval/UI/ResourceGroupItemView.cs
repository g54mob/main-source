using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Resources;
using NSMedieval.Sound;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ResourceGroupItemView : LayoutGroupItemView
	{
		[SerializeField]
		private float indentOffset = 14f;

		[SerializeField]
		private float entryDefaultHeight = 18f;

		private readonly int textIndex;

		private readonly int expandToggleImageIndex = 1;

		private readonly int childGroupIndex = 2;

		private readonly int valueGroupIndex = 3;

		private TMP_Text cachedTextComponent;

		private int groupDepth;

		private bool groupExpanded;

		private readonly List<ResourceGroupItemView> immediateGroupChidlren = new List<ResourceGroupItemView>();

		private bool isGroup;

		private ResourceGroupItemView parent;

		private SoundButton GroupExpandButton => base.GroupItems[childGroupIndex].GetComponent<SoundButton>();

		private Transform GroupExpandToggle => base.GroupItems[expandToggleImageIndex].transform;

		private int CurrentValue { get; set; }

		public void AddChild(ResourceGroupItemView child)
		{
			immediateGroupChidlren.Add(child);
			if (immediateGroupChidlren.Count == 1)
			{
				GroupExpandToggle.parent.gameObject.SetActive(value: true);
				UpdateChildren();
			}
		}

		private void UpdateParentValue()
		{
			CurrentValue = 0;
			foreach (ResourceGroupItemView item in immediateGroupChidlren)
			{
				CurrentValue += item.CurrentValue;
			}
			UpdateValue(CurrentValue);
		}

		public void UpdateValue(int value)
		{
			CurrentValue = value;
			if (cachedTextComponent == null)
			{
				cachedTextComponent = base.GroupItems[valueGroupIndex].GetComponent<TMP_Text>();
			}
			cachedTextComponent.text = CurrentValue.ToString();
			SetActive();
			if (parent != null)
			{
				parent.UpdateParentValue();
			}
		}

		public void UpdateValue(int value, bool backgroundEnabled)
		{
			UpdateValue(value);
		}

		public void SetupGroup(string nameKey, string prefix, int depth, int value = 0, Action callback = null)
		{
			isGroup = prefix == "group";
			parent = base.transform.parent.GetComponent<ResourceGroupItemView>();
			groupDepth = depth;
			RotateToggleSprite();
			TMP_Text component = base.GroupItems[textIndex].GetComponent<TMP_Text>();
			base.GroupItems[textIndex].GetComponent<Localize>().enabled = isGroup;
			if (isGroup)
			{
				SetText(base.Localize.GetText("resource_" + prefix + "_" + nameKey), nameKey);
				component.fontSize = 16f;
			}
			else
			{
				SetText(ResourceUtils.GetTextIcon(nameKey));
				component.fontSize = 18f;
				GroupExpandToggle.parent.gameObject.SetActive(value: false);
				base.GroupItems[childGroupIndex].AddComponent<TooltipViewNew>().SetLines(ResourceUtils.GetTooltipData(nameKey));
			}
			UpdateValue(value);
			GetComponent<RectTransform>().sizeDelta = IndentGroup(GetComponent<RectTransform>());
			base.GroupItems[childGroupIndex].GetComponent<RectTransform>().sizeDelta = IndentGroup(GetComponent<RectTransform>());
			GroupExpandButton.AddCleanListener(delegate
			{
				string soundID = (groupExpanded ? "UI_Collapse" : "UI_Expand");
				MonoSingleton<AudioManager>.Instance.PlaySound(soundID);
				callback?.Invoke();
				StartCoroutine(OnExpansionChange());
			});
		}

		private void UpdateChildren()
		{
			foreach (ResourceGroupItemView item in immediateGroupChidlren)
			{
				item.SetActive();
			}
		}

		private void SetActive()
		{
			if (parent != null)
			{
				base.gameObject.SetActive(parent.groupExpanded && CurrentValue > 0);
			}
			else
			{
				base.gameObject.SetActive(CurrentValue > 0);
			}
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.ResourceGroupItemUpdate();
			}
		}

		private IEnumerator OnExpansionChange()
		{
			groupExpanded = !groupExpanded;
			RotateToggleSprite();
			UpdateChildren();
			yield return new WaitForSecondsRealtime(0.001f);
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.ResourceGroupItemUpdate();
			}
		}

		private void RotateToggleSprite()
		{
			GroupExpandToggle.eulerAngles = new Vector3(0f, 0f, groupExpanded ? (-90f) : 0f);
		}

		private Vector2 IndentGroup(RectTransform rect)
		{
			float x = Mathf.Abs(rect.rect.x + (float)groupDepth * indentOffset);
			if (groupDepth == -1 || !isGroup)
			{
				x = base.GroupItems[childGroupIndex].GetComponent<LayoutElement>().minWidth;
			}
			return new Vector2(x, entryDefaultHeight);
		}
	}
}
