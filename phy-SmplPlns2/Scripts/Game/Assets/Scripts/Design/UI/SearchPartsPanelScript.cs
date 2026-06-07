using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Tutorials;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Jundroo.SocialPlatforms;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design.UI
{
	public class SearchPartsPanelScript : DesignerPanelScript
	{
		private class AircraftItem
		{
			public string AircraftID { get; set; }
		}

		private class SeachPartsListControl : ListControl<PartData>
		{
			public SeachPartsListControl(ScrollViewWidget scrollView)
				: base(scrollView, "list-item")
			{
			}

			protected override void FilterItems(string searchFilter, List<ListItem<PartData>> filteredItems)
			{
				base.FilterItems(searchFilter, filteredItems);
				ListItem<PartData> listItem = null;
				if (int.TryParse(searchFilter, out var partId))
				{
					listItem = base.Items.FirstOrDefault((ListItem<PartData> x) => x.Item.Id == partId);
					if (listItem != null)
					{
						filteredItems.Remove(listItem);
						filteredItems.Insert(0, listItem);
					}
				}
			}
		}

		private bool _ignoreClearConcealedPartCollectionChangedEvent;

		private bool _ignoreSelectedPartChangedEvent;

		private SeachPartsListControl _listControl;

		private bool _refresh;

		private InputWidget _searchInput;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			ScrollViewWidget scrollView = base.Widget.FindWidget<ScrollViewWidget>("scroll-view");
			_listControl = new SeachPartsListControl(scrollView);
			string format = base.Widget.Stylesheet.GetConstant("PartNameFormat") ?? "{PartName}";
			_listControl.CreateListItem = delegate(Widget widget, ListItem<PartData> item)
			{
				widget.FindWidget<TextWidget>("item-name").RichText = format.Replace("{PartName}", StringUtility.ClampString(item.Item.Name, 25)).Replace("{PartNumber}", item.Item.Id.ToString());
				widget.EnableClass("part-hidden", !item.Item.VisibleInDesigner);
			};
			_listControl.DeleteListItem = delegate(ListItem<PartData> x)
			{
				base.Designer.DeleteSelectedParts(singlePart: true);
				base.DesignerUI.ShowMessage("Deleted '" + x.Name + "'");
			};
			_listControl.RenameListItem = delegate(ListItem<PartData> x, string s)
			{
				if (!string.IsNullOrEmpty(s))
				{
					x.Item.Name = s;
					x.Name = x.Item.Name;
				}
				return true;
			};
			_listControl.SelectListItem = delegate(ListItem<PartData> x)
			{
				try
				{
					_ignoreSelectedPartChangedEvent = true;
					base.Designer.SelectedPart = x?.Item.PartScript;
				}
				finally
				{
					_ignoreSelectedPartChangedEvent = false;
				}
			};
			_listControl.DeselectListItem = delegate
			{
				try
				{
					_ignoreSelectedPartChangedEvent = true;
					base.Designer.SelectedPart = null;
				}
				finally
				{
					_ignoreSelectedPartChangedEvent = false;
				}
			};
			_listControl.HoverListItem = delegate(ListItem<PartData> x, bool hovered)
			{
				if (hovered)
				{
					base.Designer.HighlightedPart = x?.Item.PartScript;
				}
				else
				{
					base.Designer.HighlightedPart = null;
				}
			};
			_listControl.ListItemAction = delegate(ListItem<PartData> x, Widget w, string action)
			{
				try
				{
					_ignoreClearConcealedPartCollectionChangedEvent = true;
					if (x.Item.VisibleInDesigner)
					{
						if (base.DesignerUI.DesignerScript.PartConcealment == DesignerScript.PartConcealmentType.None)
						{
							base.DesignerUI.DesignerScript.PartConcealment = DesignerScript.PartConcealmentType.Invisible;
						}
						base.DesignerUI.DesignerScript.AddPartToConcealedCollection(x.Item.PartScript);
					}
					else
					{
						base.DesignerUI.DesignerScript.RemovePartFromConcealedCollection(x.Item.PartScript);
					}
					_listControl.RefreshItem(x);
				}
				finally
				{
					_ignoreClearConcealedPartCollectionChangedEvent = false;
				}
			};
			_listControl.FilterListItem = delegate(ListItem<PartData> listItem, string searchFilter)
			{
				string text = $"{listItem.Item.Name}#{listItem.Item.Id}";
				return string.IsNullOrEmpty(searchFilter) || text.Contains(searchFilter, StringComparison.OrdinalIgnoreCase);
			};
			_searchInput = base.Widget.FindWidget<InputWidget>("search-input");
			_searchInput.Input.onValueChanged.AddListener(delegate(string s)
			{
				OnSearchChanged(s);
			});
			base.Flyout.Opened += OnFlyoutOpened;
			base.Designer.AircraftStructureChangedEvent += OnAircraftStructureChangedEvent;
			base.Designer.SelectedPartChangedEvent += OnSelectedPartChanged;
			base.Designer.DesignerScript.ConcealedPartCollectionChanged += OnConcealedPartCollectionChanged;
		}

		protected virtual void Update()
		{
			if (_refresh)
			{
				_refresh = false;
				Refresh();
			}
			_listControl.Update();
			if (Game.Instance.UserInterface.ActiveDialog == null && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				EventSystem.current.SetSelectedGameObject(null);
				base.DesignerUI.Flyouts.Selected = null;
			}
		}

		private void OnAircraftStructureChangedEvent()
		{
			if (base.Flyout.IsOpen)
			{
				_refresh = true;
			}
		}

		private void OnConcealedPartCollectionChanged()
		{
			if (!_ignoreClearConcealedPartCollectionChangedEvent)
			{
				_refresh = true;
			}
		}

		private void OnConcealModeClicked(Widget widget)
		{
			base.DesignerUI.CycleConcealmentType();
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			_refresh = true;
			if (!SocialExt.IsSteamDeckOrBigPicture)
			{
				_searchInput.Input.Select();
			}
		}

		private void OnInvertClicked(Widget widget)
		{
			base.DesignerUI.InvertConcealedParts();
		}

		private void OnSearchChanged(string searchFilter)
		{
			_listControl.SearchFilter = searchFilter;
		}

		private void OnSelectedPartChanged(PartScript newPart)
		{
			if (base.Flyout.IsOpen && !_ignoreSelectedPartChangedEvent && newPart != null)
			{
				ListItem<PartData> listItem = _listControl.Items.FirstOrDefault((ListItem<PartData> x) => x.Item == newPart.Part);
				if (listItem != null)
				{
					_listControl.SelectedItem = listItem;
					_listControl.ScrollToListItem(listItem);
				}
			}
		}

		private void OnShowAllClicked(Widget widget)
		{
			base.DesignerUI.ClearConcealedPartsList();
		}

		private void Refresh()
		{
			List<PartData> list = base.Designer.Aircraft.Aircraft.Assembly.Parts.OrderBy((PartData x) => x.Name).ToList();
			_listControl.Items.Clear();
			bool tutorialRunning = base.Designer.DesignerScript.TutorialRunning;
			ListItem<PartData> listItem = null;
			foreach (PartData item in list)
			{
				if (!tutorialRunning || !item.PartScript.TryGetComponent<TutorialPartScript>(out var component) || !component.IsHiddenPart)
				{
					ListItem<PartData> listItem2 = new ListItem<PartData>(item.Name, item)
					{
						CanDelete = (item.PartScript != base.Designer.Aircraft.MainCockpit),
						CanRename = true
					};
					_listControl.Items.Add(listItem2);
					if (base.Designer.SelectedPart?.Part == item)
					{
						listItem = listItem2;
					}
				}
			}
			_listControl.Refresh();
			_listControl.SelectedItem = listItem;
			_listControl.ScrollToListItem(listItem);
		}
	}
}
