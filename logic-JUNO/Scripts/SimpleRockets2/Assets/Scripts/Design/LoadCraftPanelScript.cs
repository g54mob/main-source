using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class LoadCraftPanelScript : DesignerFlyoutPanelScript
	{
		private XmlElement _content;

		private CraftDesigns _craftDesigns;

		private GameObject _listItemPrefab;

		private bool _showStock;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			_craftDesigns = designerUi.Designer.CraftDesigns;
			base.Flyout.Opening += OnFlyoutOpening;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_content = base.xmlLayout.GetElementById("content");
			_listItemPrefab = base.xmlLayout.GetElementById("template").gameObject;
			if (base.DesignerUi != null)
			{
				RefreshList();
			}
		}

		private void CreateListItem(string craftId, XmlElement parent)
		{
			GameObject obj = UnityEngine.Object.Instantiate(_listItemPrefab);
			obj.SetActive(value: true);
			XmlElement component = obj.GetComponent<XmlElement>();
			component.SetAttribute("data-craft-id", craftId);
			parent.AddChildElement(component);
			component.GetElementByInternalId<TextMeshProUGUI>("name").text = craftId;
		}

		private void FilterItems(string searchFilter)
		{
			if (string.IsNullOrEmpty(searchFilter))
			{
				return;
			}
			int num = 0;
			foreach (XmlElement item in base.xmlLayout.GetElementsByClass("list-item"))
			{
				string attribute = item.GetAttribute("data-craft-id");
				if (attribute != null)
				{
					if (string.IsNullOrEmpty(searchFilter) || attribute.IndexOf(searchFilter, StringComparison.OrdinalIgnoreCase) >= 0)
					{
						num++;
						item.gameObject.SetActive(value: true);
					}
					else
					{
						item.gameObject.SetActive(value: false);
					}
				}
			}
			DisplayCount(num);
		}

		private void OnDeleteItemClicked(XmlElement deleteButtonElement)
		{
			MessageDialogScript dialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			XmlElement item = deleteButtonElement.GetParentElementWithClass("list-item");
			string craftId = item.GetAttribute("data-craft-id");
			dialog.MessageText = $"Please confirm that you wish to delete this craft:\n'{craftId}'";
			dialog.UseDangerButtonStyle = true;
			dialog.OkayClicked += delegate
			{
				UnityEngine.Object.Destroy(item.gameObject);
				_craftDesigns.DeleteCraftFile(craftId);
				base.DesignerUi.Designer.ShowMessage($"Deleted Craft '{craftId}'");
				dialog.Close();
			};
		}

		private void OnFlyoutOpening(IFlyout flyout)
		{
			RefreshList();
		}

		private void OnListItemClicked(XmlElement element)
		{
			string attribute = element.GetAttribute("data-craft-id");
			try
			{
				XElement craftDesign = _craftDesigns.GetCraftDesign(attribute);
				base.DesignerUi.Designer.ShowMessage("Loading...");
				base.DesignerUi.Designer.CraftLoader.LoadCraftInteractive(craftDesign, createUndoStep: true, centerCamera: false, "Loaded craft '" + attribute + "'", null, null);
			}
			catch (Exception exception)
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "The craft failed to load.";
				Debug.LogException(exception);
			}
		}

		private void OnToggleShowStockCraftsClicked()
		{
			_showStock = !_showStock;
			XmlElement elementById = base.xmlLayout.GetElementById("toggle-stock-button");
			if (_showStock)
			{
				elementById.AddClass("btn-primary");
			}
			else
			{
				elementById.RemoveClass("btn-primary");
			}
			RefreshList();
		}

		private void RefreshList()
		{
			foreach (Transform item in _content.transform)
			{
				if (item.gameObject != _listItemPrefab)
				{
					item.gameObject.SetActive(value: false);
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			List<string> craftDesignIds = _craftDesigns.GetCraftDesignIds(excludeReservedIds: true);
			int num = 0;
			foreach (string item2 in craftDesignIds)
			{
				if (CraftDesigns.IsStock(item2) == _showStock)
				{
					CreateListItem(item2, _content);
					num++;
				}
			}
			DisplayCount(num);
			base.xmlLayout.GetElementById<TMP_InputField>("search-input").text = string.Empty;
		}

		private void DisplayCount(int count)
		{
			base.xmlLayout.GetElementById<TextMeshProUGUI>("item-count").text = string.Format("{0} craft design{1}", count, (count != 1) ? "s" : string.Empty);
		}
	}
}
