using System;
using System.Collections.Generic;
using Assets.Scripts.Ui;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Math;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class CraftPartsPanelScript : DesignerFlyoutPanelScript
	{
		private enum PartSortingMethods
		{
			Name = 0,
			Mass = 1,
			Price = 2
		}

		private class ListItem
		{
			public XmlElement Element { get; set; }

			public XmlElement HideButton { get; set; }

			public PartDesignerInteractionMode InteractionMode { get; internal set; }

			public int PartId { get; set; }

			public string PartName { get; set; }

			public bool RemoveFlag { get; set; }

			public TextMeshProUGUI Text { get; internal set; }
		}

		private const int DefaultNumPartsToShow = 50;

		private const string HiddenClass = "hide-button-toggled";

		private XmlElement _content;

		private ListItem _highlightedPart;

		private Dictionary<int, ListItem> _items = new Dictionary<int, ListItem>();

		private GameObject _listItemPrefab;

		private int _numPartsToShow = 50;

		private TextMeshProUGUI _partCountText;

		private ScrollRect _scrollRect;

		private string _searchFilter = string.Empty;

		private ListItem _selectedItem;

		private List<ListItem> _sortedItems = new List<ListItem>();

		private PartSortingMethods _sortingMethod;

		private TextMeshProUGUI _toggleAllButtonText;

		private Assembly CraftAssembly => base.DesignerUi.Designer.CraftScript.Data.Assembly;

		private ListItem HighlightedPart
		{
			get
			{
				return _highlightedPart;
			}
			set
			{
				if (_highlightedPart == value)
				{
					return;
				}
				if (_highlightedPart != null)
				{
					PartData part = GetPart(_highlightedPart.Element);
					if (part != null)
					{
						part.PartScript.PartMaterialScript.IsHighlighted = false;
					}
				}
				_highlightedPart = value;
				if (_highlightedPart != null)
				{
					PartData part2 = GetPart(_highlightedPart.Element);
					if (part2 != null)
					{
						part2.PartScript.PartMaterialScript.IsHighlighted = true;
					}
				}
			}
		}

		private ListItem SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				if (_selectedItem != null)
				{
					_selectedItem.Element.RemoveClass("list-item-selected");
				}
				_selectedItem = value;
				if (_selectedItem != null)
				{
					_selectedItem.Element.AddClass("list-item-selected");
					if (!_selectedItem.Element.Visible)
					{
						_selectedItem.Element.Show();
					}
					UiUtilities.ScrollToTarget(_selectedItem.Element.GetComponent<RectTransform>(), _scrollRect, -20f);
				}
			}
		}

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			base.Flyout.Opening += OnFlyoutOpening;
			base.Flyout.Closing += OnFlyoutClosing;
			designerUi.Designer.SelectedPartChanged += OnSelectedPartChanged;
			designerUi.Designer.CraftLoaded += OnCraftLoaded;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_scrollRect = base.xmlLayout.GetElementById<ScrollRect>("scrollview");
			_content = base.xmlLayout.GetElementById("content");
			_listItemPrefab = base.xmlLayout.GetElementById("template").gameObject;
			_partCountText = base.xmlLayout.GetElementById<TextMeshProUGUI>("part-count");
			_toggleAllButtonText = base.xmlLayout.GetElementById<TextMeshProUGUI>("toggle-all-button-text");
			if (base.DesignerUi != null)
			{
				_items.Clear();
				_sortedItems.Clear();
				if (base.Flyout != null && base.Flyout.IsOpen)
				{
					RefreshList();
				}
			}
		}

		private void CreateListItem(PartData partData, XmlElement parent)
		{
			XmlElement component = UnityEngine.Object.Instantiate(_listItemPrefab).GetComponent<XmlElement>();
			component.SetAttribute("active", "true");
			component.SetAttribute("part-id", DataIO.ToString(partData.Id));
			parent.AddChildElement(component);
			XmlElement elementByInternalId = component.GetElementByInternalId("hide-button");
			TextMeshProUGUI elementByInternalId2 = component.GetElementByInternalId<TextMeshProUGUI>("name");
			elementByInternalId2.text = partData.Name;
			component.ApplyAttributes();
			ListItem listItem = new ListItem
			{
				PartId = partData.Id,
				PartName = partData.Name,
				Element = component,
				HideButton = elementByInternalId,
				Text = elementByInternalId2
			};
			_items[partData.Id] = listItem;
			_sortedItems.Add(listItem);
		}

		private void FilterItems(string searchFilter)
		{
			int result = -1;
			if (searchFilter == null)
			{
				searchFilter = string.Empty;
			}
			else
			{
				int.TryParse(searchFilter, out result);
			}
			_searchFilter = searchFilter;
			int num = 0;
			foreach (ListItem value in _items.Values)
			{
				string partName = value.PartName;
				if (num < _numPartsToShow && (result == value.PartId || partName.IndexOf(searchFilter, StringComparison.OrdinalIgnoreCase) >= 0))
				{
					num++;
					value.Element.gameObject.SetActive(value: true);
				}
				else if (SelectedItem?.Element == value.Element)
				{
					value.Element.gameObject.SetActive(value: true);
				}
				else
				{
					value.Element.gameObject.SetActive(value: false);
				}
			}
			UpdateHeader();
		}

		private ListItem GetItem(XmlElement element)
		{
			int key = DataIO.ParseInt(element.GetAttribute("part-id"));
			return _items[key];
		}

		private PartData GetPart(XmlElement element)
		{
			PartData result = null;
			int value = 0;
			if (DataIO.TryParseInt(element.GetAttribute("part-id"), out value))
			{
				result = CraftAssembly.GetPartById(value);
			}
			return result;
		}

		private void OnCraftLoaded()
		{
			if (base.Flyout.IsOpen)
			{
				RefreshList();
			}
			SelectedItem = null;
		}

		private void OnFlyoutClosing(IFlyout flyout)
		{
			HighlightedPart = null;
		}

		private void OnFlyoutOpening(IFlyout flyout)
		{
			RefreshList();
		}

		private void OnHideButtonClicked(XmlElement element)
		{
			XmlElement parentElementWithClass = element.GetParentElementWithClass("list-item");
			PartData part = GetPart(parentElementWithClass);
			if (part.PartScript.DesignerInteractionMode == PartDesignerInteractionMode.Normal)
			{
				part.PartScript.DesignerInteractionMode = PartDesignerInteractionMode.Disabled;
			}
			else
			{
				part.PartScript.DesignerInteractionMode = PartDesignerInteractionMode.Normal;
			}
			ListItem item = GetItem(parentElementWithClass);
			UpdateListItem(item, part);
			if (part.PartScript.PartMaterialScript.IsDisabled)
			{
				HighlightedPart = null;
			}
			UpdateHeader();
		}

		private void OnListItemClicked(XmlElement element)
		{
			IPartScript partScript = GetPart(element)?.PartScript;
			if (base.DesignerUi.Designer.SelectedPart != partScript)
			{
				base.DesignerUi.Designer.SelectPart(partScript, null, justAdded: false);
			}
			else
			{
				base.DesignerUi.Designer.DeselectPart();
			}
		}

		private void OnMouseEnterListItem(XmlElement element)
		{
			HighlightedPart = GetItem(element);
		}

		private void OnMouseExitListItem(XmlElement element)
		{
			HighlightedPart = null;
		}

		private void OnSelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (base.Flyout.IsOpen)
			{
				RefreshList();
			}
		}

		private void OnSortingMethodMass()
		{
			_sortingMethod = PartSortingMethods.Mass;
			RefreshList();
		}

		private void OnSortingMethodName()
		{
			_sortingMethod = PartSortingMethods.Name;
			RefreshList();
		}

		private void OnSortingMethodPrice()
		{
			_sortingMethod = PartSortingMethods.Price;
			RefreshList();
		}

		private void OnToggleAllVisibilityClicked()
		{
			bool flag = false;
			if (_toggleAllButtonText.text.Contains("Show"))
			{
				flag = true;
			}
			foreach (ListItem sortedItem in _sortedItems)
			{
				if (sortedItem.Element.Visible)
				{
					PartData part = GetPart(sortedItem.Element);
					if (flag && part.PartScript.DesignerInteractionMode != PartDesignerInteractionMode.Normal)
					{
						part.PartScript.DesignerInteractionMode = PartDesignerInteractionMode.Normal;
					}
					else if (!flag && part.PartScript.DesignerInteractionMode != PartDesignerInteractionMode.Disabled)
					{
						part.PartScript.DesignerInteractionMode = PartDesignerInteractionMode.Disabled;
					}
				}
			}
			RefreshList();
		}

		private void OnToggleListAllPartsClicked()
		{
			if (_numPartsToShow == 50)
			{
				base.DesignerUi.ShowMessage("Listing all parts can result in performance degredation depending on part count");
				_numPartsToShow = int.MaxValue;
			}
			else
			{
				_numPartsToShow = 50;
			}
			RefreshList();
		}

		private void RefreshList()
		{
			foreach (ListItem value in _items.Values)
			{
				value.RemoveFlag = true;
			}
			foreach (PartData part in CraftAssembly.Parts)
			{
				if (!_items.ContainsKey(part.Id))
				{
					CreateListItem(part, _content);
					continue;
				}
				ListItem listItem = _items[part.Id];
				listItem.RemoveFlag = false;
				UpdateListItem(listItem, part);
			}
			List<ListItem> list = new List<ListItem>();
			foreach (ListItem value2 in _items.Values)
			{
				if (value2.RemoveFlag)
				{
					list.Add(value2);
				}
			}
			foreach (ListItem item in list)
			{
				_items.Remove(item.PartId);
				_sortedItems.Remove(item);
				UnityEngine.Object.Destroy(item.Element.gameObject);
			}
			_sortedItems.Sort(delegate(ListItem x, ListItem y)
			{
				int num2 = 0;
				switch (_sortingMethod)
				{
				case PartSortingMethods.Name:
					num2 = string.Compare(x.PartName, y.PartName, ignoreCase: true);
					break;
				case PartSortingMethods.Mass:
				{
					float mass = CraftAssembly.GetPartById(x.PartId).Mass;
					float mass2 = CraftAssembly.GetPartById(y.PartId).Mass;
					num2 = ((mass < mass2) ? 1 : ((mass != mass2) ? (-1) : 0));
					break;
				}
				case PartSortingMethods.Price:
				{
					float num3 = CraftAssembly.GetPartById(x.PartId).Price;
					float num4 = CraftAssembly.GetPartById(y.PartId).Price;
					num2 = ((num3 < num4) ? 1 : ((num3 != num4) ? (-1) : 0));
					break;
				}
				}
				return (num2 != 0) ? num2 : (x.PartId - y.PartId);
			});
			for (int num = 0; num < _sortedItems.Count; num++)
			{
				_sortedItems[num].Element.transform.SetSiblingIndex(num + 1);
			}
			ListItem selectedItem = null;
			if (base.DesignerUi.Designer.SelectedPart != null && _items.ContainsKey(base.DesignerUi.Designer.SelectedPart.Data.Id))
			{
				selectedItem = _items[base.DesignerUi.Designer.SelectedPart.Data.Id];
			}
			SelectedItem = selectedItem;
			FilterItems(_searchFilter);
		}

		private void UpdateHeader()
		{
			int num = 0;
			bool flag = true;
			foreach (ListItem sortedItem in _sortedItems)
			{
				if (sortedItem.Element.gameObject.activeSelf)
				{
					num++;
					if (sortedItem.InteractionMode != PartDesignerInteractionMode.Normal)
					{
						flag = false;
					}
				}
			}
			_partCountText.text = $"{num} parts";
			if (flag)
			{
				_toggleAllButtonText.text = "Hide All";
			}
			else
			{
				_toggleAllButtonText.text = "Show All";
			}
		}

		private void UpdateListItem(ListItem item, PartData part)
		{
			item.PartName = part.Name;
			switch (_sortingMethod)
			{
			case PartSortingMethods.Mass:
				item.Text.text = part.Name + " - " + Units.GetMassString(part.Mass);
				break;
			case PartSortingMethods.Price:
				item.Text.text = part.Name + " - " + Units.GetMoneyString(part.Price);
				break;
			default:
				item.Text.text = part.Name;
				break;
			}
			if (item.InteractionMode != part.PartScript.DesignerInteractionMode)
			{
				item.InteractionMode = part.PartScript.DesignerInteractionMode;
				if (item.InteractionMode == PartDesignerInteractionMode.Disabled && !item.HideButton.HasClass("hide-button-toggled"))
				{
					item.HideButton.AddClass("hide-button-toggled");
				}
				else if (item.InteractionMode == PartDesignerInteractionMode.Normal && item.HideButton.HasClass("hide-button-toggled"))
				{
					item.HideButton.RemoveClass("hide-button-toggled");
				}
			}
		}
	}
}
