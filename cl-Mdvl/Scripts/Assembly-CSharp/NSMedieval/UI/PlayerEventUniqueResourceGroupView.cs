using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.UI
{
	public class PlayerEventUniqueResourceGroupView : PlayerEventLimitedItemGroup
	{
		private PlayerEventUniqueResourceEntryView uniqueResourceEntryView;

		private string nonInteractableMessage;

		public void SetData(KeyValuePair<string, Resource> groupResourcePair, bool hasResources, Action<string> addNewCallback, Action<KeyValuePair<string, Resource>, bool> addRemoveCallback)
		{
			nonInteractableMessage = MonoSingleton<LocalizationController>.Instance.GetText("no_" + groupResourcePair.Key.ToString().ToLower() + "_message");
			addNewButton.GetComponent<LocalizedTextTooltipView>().SetTooltipKey(MonoSingleton<LocalizationController>.Instance.GetText("general_add_unique_resource") ?? "");
			if (!uniqueResourceEntryView)
			{
				uniqueResourceEntryView = UnityEngine.Object.Instantiate(itemGroupView.Prefab.gameObject, itemGroupView.transform).GetComponent<PlayerEventUniqueResourceEntryView>();
			}
			if (groupResourcePair.Value != null)
			{
				uniqueResourceEntryView.gameObject.SetActive(value: true);
				uniqueResourceEntryView.SetData(groupResourcePair, addRemoveCallback);
			}
			else
			{
				uniqueResourceEntryView.gameObject.SetActive(value: false);
			}
			addNewButton.interactable = hasResources;
			addNewButton.AddCleanListener(delegate
			{
				addNewCallback(groupResourcePair.Key);
			});
			addNewButton.transform.SetSiblingIndex(itemGroupView.transform.childCount - 1);
		}

		private void Start()
		{
			addNewButton.onNonInteractableClick.AddListener(delegate
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(nonInteractableMessage);
			});
		}
	}
}
