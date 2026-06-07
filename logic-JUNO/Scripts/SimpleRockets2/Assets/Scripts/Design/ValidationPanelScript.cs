using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Ui;
using ModApi.Craft.Parts;
using ModApi.Scripts.State.Validation;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class ValidationPanelScript : DesignerSubPanelScript
	{
		private class ListItem
		{
			public XmlElement Element { get; set; }

			public ValidationMessage Message { get; set; }

			public TextMeshProUGUI Text { get; internal set; }
		}

		private XmlElement _autoFix;

		private XmlElement _content;

		private ListItem _highlightedPart;

		private List<ListItem> _items = new List<ListItem>();

		private GameObject _listItemPrefab;

		private bool _refresh;

		private ScrollRect _scrollRect;

		private ListItem _selectedItem;

		private TextMeshProUGUI _statusText;

		private CraftScript Craft => base.DesignerUi.Designer.CraftScript as CraftScript;

		private ListItem HighlightedItem
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
					PartData part = GetPart(_highlightedPart);
					if (part != null)
					{
						part.PartScript.PartMaterialScript.IsHighlighted = false;
					}
				}
				_highlightedPart = value;
				if (_highlightedPart != null)
				{
					PartData part2 = GetPart(_highlightedPart);
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
			designerUi.Designer.CraftStructureChanged += OnCraftStructureChanged;
			designerUi.Designer.CraftLoaded += OnCraftLoaded;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_scrollRect = base.xmlLayout.GetElementById<ScrollRect>("scrollview");
			_content = base.xmlLayout.GetElementById("content");
			_autoFix = base.xmlLayout.GetElementById("autofix");
			_listItemPrefab = base.xmlLayout.GetElementById("template").gameObject;
			_statusText = base.xmlLayout.GetElementById<TextMeshProUGUI>("status");
			if (base.DesignerUi != null)
			{
				_items.Clear();
				if (base.IsOpen)
				{
					_refresh = true;
				}
			}
		}

		public override void OnClosed()
		{
			base.OnClosed();
			HighlightedItem = null;
		}

		public override void OnOpened()
		{
			base.OnOpened();
			_refresh = true;
		}

		protected virtual void Update()
		{
			if (_refresh)
			{
				_refresh = false;
				RefreshList();
			}
		}

		private void CreateListItem(ValidationMessage message, XmlElement parent)
		{
			XmlElement component = UnityEngine.Object.Instantiate(_listItemPrefab).GetComponent<XmlElement>();
			component.SetAttribute("active", "true");
			component.SetAttribute("index", _items.Count.ToString());
			component.SetAttribute("part-id", message.PartID.ToString());
			if (message.Message.Length > 100)
			{
				component.AddClass("tall");
			}
			parent.AddChildElement(component);
			TextMeshProUGUI elementByInternalId = component.GetElementByInternalId<TextMeshProUGUI>("name");
			elementByInternalId.text = message.Message;
			component.ApplyAttributes();
			ListItem item = new ListItem
			{
				Message = message,
				Element = component,
				Text = elementByInternalId
			};
			_items.Add(item);
		}

		private ListItem GetItem(XmlElement element)
		{
			int index = DataIO.ParseInt(element.GetAttribute("index"));
			return _items[index];
		}

		private PartData GetPart(ListItem item)
		{
			return Craft.Data.Assembly.GetPartById(item.Message.PartID);
		}

		private void OnCraftLoaded()
		{
			_refresh = true;
			SelectedItem = null;
		}

		private void OnCraftStructureChanged()
		{
			_refresh = true;
		}

		private void OnFixClicked()
		{
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "Auto-fix will likely alter the behaviour of the craft, are you sure you want to do it?";
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				RefreshList(fix: true);
			};
		}

		private void OnListItemClicked(XmlElement element)
		{
			ListItem listItem = _items.Where((ListItem x) => element == x.Element).FirstOrDefault();
			if (listItem == null)
			{
				return;
			}
			if (listItem.Message.ClickAction == ClickAction.SelectPart)
			{
				IPartScript partScript = GetPart(listItem)?.PartScript;
				if (base.DesignerUi.Designer.SelectedPart != partScript)
				{
					base.DesignerUi.Designer.SelectPart(partScript, null, justAdded: false);
				}
				else
				{
					base.DesignerUi.Designer.DeselectPart();
				}
			}
			else if (listItem.Message.ClickAction == ClickAction.OpenResumeCrafts)
			{
				ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = "Click Okay to be redirected to the Resume Flight view. From there you can select a craft and remove it from flight.";
				messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
				{
					d.Close();
					base.DesignerUi.Designer.ShowActiveCrafts();
				};
			}
		}

		private void OnMouseEnterListItem(XmlElement element)
		{
			HighlightedItem = GetItem(element);
		}

		private void OnMouseExitListItem(XmlElement element)
		{
			HighlightedItem = null;
		}

		private void RefreshList(bool fix = false)
		{
			Craft.CalculateStartingBounds();
			HighlightedItem = null;
			SelectedItem = null;
			foreach (ListItem item in _items)
			{
				UnityEngine.Object.Destroy(item.Element.gameObject);
			}
			_autoFix.Hide();
			_items.Clear();
			ValidationResult validationResult = Game.Instance.GameState.Validator.ValidateCraft(Craft, Game.Instance.GameState.SelectedLaunchLocation, fix);
			List<ValidationMessage> list = (from x in validationResult.Messages
				orderby x.MessageType, x.Priority descending, x.Message
				select x).Skip(0).Take(50).ToList();
			int errorCount = validationResult.ErrorCount;
			int warningCount = validationResult.WarningCount;
			if (errorCount > 0 || warningCount > 0)
			{
				_autoFix.Show();
				_statusText.text = $"{errorCount} error(s) and {warningCount} warning(s).";
				if (validationResult.Messages.Count > 50)
				{
					_statusText.text += $" Showing first {50}.";
				}
			}
			else
			{
				_statusText.text = "Craft is looking great and is ready for launch!";
			}
			foreach (ValidationMessage item2 in list)
			{
				CreateListItem(item2, _content);
			}
		}
	}
}
