using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class ShowItemDetails : MonoBehaviour
	{
		public TweenPosition ItemConfiguratorTween;

		public UILabel NameLabel;

		public UILabel DetailLabel;

		public GameObject TemplateButton;

		public void Update()
		{
			if (!ItemSelector.HasSelectedItems() || DragAndDropHelper.DraggedItem != null)
			{
				ItemConfiguratorTween.Play(false);
				TemplateButton.SetActive(false);
				return;
			}
			DronePart onlySelection = ItemSelector.GetOnlySelection();
			TemplateButton.gameObject.SetActive(onlySelection != null && !(onlySelection is RootDronePart));
			if (RuntimeGlobals.GameMode == EGameMode.Tutorial)
			{
				TemplateButton.gameObject.SetActive(false);
			}
			ItemConfiguratorTween.Play(true);
			if (onlySelection != null)
			{
				NameLabel.text = LabelHelper.Blue + onlySelection.Name;
				string text = "";
				if (!string.IsNullOrEmpty(onlySelection.CustomToolTip.GetTranslation()))
				{
					text = string.Concat(text, LabelHelper.LightGrey, onlySelection.CustomToolTip, LabelHelper.NewLine);
				}
				DetailLabel.text = text + onlySelection.GetDetailedTooltip();
				return;
			}
			List<string> list = new List<string>();
			NameLabel.text = "";
			foreach (DronePart item in ItemSelector.SelectedItems)
			{
				if (!list.Contains(item.Name.Term))
				{
					int num = ItemSelector.SelectedItems.Count((DronePart i) => i.Name.Term == item.Name.Term);
					string text2 = ((num > 1) ? (" (" + num + ")") : "");
					UILabel nameLabel = NameLabel;
					nameLabel.text = string.Concat(nameLabel.text, LabelHelper.Blue, item.Name, text2, LabelHelper.NewLine);
					list.Add(item.Name.Term);
				}
			}
			DetailLabel.text = "";
		}
	}
}
