using System;
using System.Collections.Generic;
using NSMedieval.Model;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class EventResourceEntry : LayoutGroupItemView
	{
		[SerializeField]
		private Image icon;

		[SerializeField]
		private TMP_Text nameLabel;

		[SerializeField]
		private Toggle selectToggle;

		[SerializeField]
		private TooltipViewNew iconTooltip;

		[SerializeField]
		private GameObject background;

		private Color iconDefaultColor = Color.white;

		public void SetData(Resource resource, string groupId, bool selected, ToggleGroup toggleGroup, Action<KeyValuePair<string, Resource>, bool> addRemoveCallback)
		{
			nameLabel.SetText(ResourceUtils.GetLocalizedResourceName(resource));
			icon.color = iconDefaultColor;
			icon.sprite = AssetUtils.GetSprite(resource.IconPath);
			iconTooltip.ClearLines();
			iconTooltip.SetLines(ResourceUtils.GetTooltipData(resource));
			selectToggle.group = toggleGroup;
			selectToggle.interactable = true;
			selectToggle.SetIsOnWithoutNotify(selected);
			selectToggle.onValueChanged.RemoveAllListeners();
			selectToggle.onValueChanged.AddListener(delegate(bool value)
			{
				addRemoveCallback(new KeyValuePair<string, Resource>(groupId, resource), value);
			});
		}

		public void SetBackground(bool selected)
		{
			background.SetActive(selected);
		}
	}
}
