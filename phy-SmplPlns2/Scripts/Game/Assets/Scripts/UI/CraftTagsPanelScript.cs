using System;
using System.Collections.Generic;
using Assets.Scripts.Settings;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Pool;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using Jundroo.SocialPlatforms;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public class CraftTagsPanelScript : WidgetScript
	{
		private enum ListItemType
		{
			Tag = 0,
			Subdirectory = 1,
			Label = 2
		}

		public class CraftFiltersChangedEventArgs : EventArgs
		{
			public IReadOnlyList<string> SelectedSubdirectories { get; }

			public IReadOnlyList<string> SelectedTags { get; }

			public CraftFiltersChangedEventArgs(IReadOnlyList<string> selectedTags, IReadOnlyList<string> selectedSubdirectories)
			{
				SelectedTags = selectedTags;
				SelectedSubdirectories = selectedSubdirectories;
			}
		}

		public class CraftTagsPanel
		{
			private CraftFilterSettings _filterSettings;

			private Widget _hostWidget;

			private bool _isSaveCraftDialog;

			private Widget _parentWidget;

			private Action _refreshCraftListAction;

			private List<string> _selectedSubdirectories;

			private List<string> _selectedTags;

			private Widget _tagButtonsContainerWidget;

			private List<Widget> _tagButtonWidgets;

			public bool IsSaveCraftDialog => _isSaveCraftDialog;

			public IList<string> SelectedSubdirectoriesAsFilters
			{
				get
				{
					if (_selectedSubdirectories.Count <= 0)
					{
						return null;
					}
					return _selectedSubdirectories;
				}
			}

			public IList<string> SelectedTagsAsFilters
			{
				get
				{
					if (_selectedTags.Count <= 0)
					{
						return null;
					}
					return _selectedTags;
				}
			}

			public CraftTagsPanel(Widget hostWidget, Widget parentWidget, bool saveCraftDialog, Action refreshCraftListAction)
			{
				_hostWidget = hostWidget;
				_parentWidget = parentWidget;
				_isSaveCraftDialog = saveCraftDialog;
				_refreshCraftListAction = refreshCraftListAction;
				_selectedTags = new List<string>();
				_selectedSubdirectories = new List<string>();
				_tagButtonWidgets = new List<Widget>();
				_filterSettings = Game.Instance.Settings.Gameplay.CraftFilters;
				_tagButtonsContainerWidget = hostWidget.FindWidget("tag-buttons");
				hostWidget.FindWidget<ButtonWidget>("tag-button").Clicked += delegate
				{
					CraftTagsPanelScript craftTagsFlyout = GetCraftTagsFlyout(createIfNecessary: true, _parentWidget, this);
					if (craftTagsFlyout.Flyout.IsOpen)
					{
						craftTagsFlyout.Flyout.Close();
					}
					else
					{
						craftTagsFlyout.TagsChanged += OnCraftTagsChanged;
						craftTagsFlyout.Flyout.Closed += OnCraftTagsFlyoutClosed;
						craftTagsFlyout.Flyout.Show(show: true);
					}
				};
			}

			public void ApplyCraftTags(IReadOnlyCollection<string> tags, IReadOnlyCollection<string> subdirectories)
			{
				_selectedTags.Clear();
				_selectedSubdirectories.Clear();
				if (tags != null)
				{
					_selectedTags.AddRange(tags);
				}
				if (subdirectories != null && !_isSaveCraftDialog)
				{
					_selectedSubdirectories.AddRange(subdirectories);
				}
				RebuildTagButtons();
				_refreshCraftListAction?.Invoke();
			}

			public void CloseFlyout()
			{
				CraftTagsPanelScript craftTagsFlyout = GetCraftTagsFlyout(createIfNecessary: false, _parentWidget, this);
				if (craftTagsFlyout != null && craftTagsFlyout.Flyout.IsOpen)
				{
					craftTagsFlyout.Flyout.Close();
				}
			}

			public void GetSelectedTags(List<string> selectedTags)
			{
				selectedTags.AddRange(_selectedTags);
			}

			public void OnHostFlyoutOpened()
			{
				CraftTagsPanelScript craftTagsFlyout = GetCraftTagsFlyout(createIfNecessary: false, _parentWidget, this);
				if (craftTagsFlyout != null)
				{
					craftTagsFlyout.OnHostFlyoutOpened();
				}
				_selectedTags.Clear();
				_selectedSubdirectories.Clear();
				_filterSettings.GetActiveTags(_selectedTags);
				if (!_isSaveCraftDialog)
				{
					_filterSettings.GetActiveSubdirectories(_selectedSubdirectories);
				}
				RebuildTagButtons();
			}

			public void SetSelectedTags(IReadOnlyCollection<string> selectedTags)
			{
				ApplyCraftTags(selectedTags, _selectedSubdirectories);
				CraftTagsPanelScript craftTagsFlyout = GetCraftTagsFlyout(createIfNecessary: false, _parentWidget, this);
				if (craftTagsFlyout != null)
				{
					craftTagsFlyout.OnTagsChanged(_selectedTags, _selectedSubdirectories);
				}
			}

			private Widget CreateTagButton(string value, bool isSubdirectory)
			{
				Widget widget = _hostWidget.Context.CreateWidgetFromTemplate("tag-button", _tagButtonsContainerWidget);
				TextWidget textWidget = widget.FindWidget<TextWidget>("tag-button-text");
				textWidget.Text = ((!isSubdirectory) ? ((value == "None") ? "No Tags" : value) : ((value == "None") ? "No Subdirectory" : value));
				widget.Tooltip = textWidget.Text;
				widget.Clicked += delegate
				{
					if (isSubdirectory)
					{
						_selectedSubdirectories.Remove(value);
						if (!IsSaveCraftDialog)
						{
							_filterSettings.SetActiveSubdirectories(_selectedSubdirectories);
						}
					}
					else
					{
						_selectedTags.Remove(value);
						if (!IsSaveCraftDialog)
						{
							_filterSettings.SetActiveTags(_selectedTags);
						}
					}
					RebuildTagButtons();
					CraftTagsPanelScript craftTagsFlyout = GetCraftTagsFlyout(createIfNecessary: false, _parentWidget, this);
					if (craftTagsFlyout != null)
					{
						craftTagsFlyout.OnTagsChanged(_selectedTags, _selectedSubdirectories);
					}
					_refreshCraftListAction?.Invoke();
				};
				return widget;
			}

			private void OnCraftTagsChanged(object sender, CraftFiltersChangedEventArgs e)
			{
				ApplyCraftTags(e.SelectedTags, e.SelectedSubdirectories);
			}

			private void OnCraftTagsFlyoutClosed(IFlyout flyout)
			{
				flyout.Closed -= OnCraftTagsFlyoutClosed;
				CraftTagsPanelScript componentInChildren = flyout.Widget.GetComponentInChildren<CraftTagsPanelScript>(includeInactive: true);
				if (componentInChildren != null)
				{
					componentInChildren.TagsChanged -= OnCraftTagsChanged;
				}
			}

			private void RebuildTagButtons()
			{
				foreach (Widget tagButtonWidget in _tagButtonWidgets)
				{
					tagButtonWidget.Destroy();
				}
				List<string> selectedTags = _selectedTags;
				bool flag = selectedTags != null && selectedTags.Count > 0;
				List<string> selectedSubdirectories = _selectedSubdirectories;
				bool flag2 = selectedSubdirectories != null && selectedSubdirectories.Count > 0;
				if (flag)
				{
					foreach (string selectedTag in _selectedTags)
					{
						Widget item = CreateTagButton(selectedTag, isSubdirectory: false);
						_tagButtonWidgets.Add(item);
					}
				}
				if (flag2)
				{
					foreach (string selectedSubdirectory in _selectedSubdirectories)
					{
						Widget item2 = CreateTagButton(selectedSubdirectory, isSubdirectory: true);
						_tagButtonWidgets.Add(item2);
					}
				}
				if (!flag && !flag2)
				{
					_tagButtonsContainerWidget.Parent.AddClass("no-filters-selected");
				}
				else
				{
					_tagButtonsContainerWidget.Parent.RemoveClass("no-filters-selected");
				}
			}
		}

		private class ListItemInfo
		{
			public bool Favorite { get; set; }

			public string Name { get; set; }

			public ListItemType Type { get; set; }

			public ListItemInfo(string name, bool favorite, ListItemType type)
			{
				Name = name;
				Favorite = favorite;
				Type = type;
			}
		}

		private List<string> _addedTags;

		private CraftTagsPanel _craftTagsPanel;

		private List<string> _favoriteSubdirectories;

		private List<string> _favoriteTags;

		private CraftFilterSettings _filterSettings;

		private FlyoutScript _flyout;

		private InputWidget _searchInput;

		private List<string> _selectedSubdirectories;

		private List<string> _selectedTags;

		private ListControl<ListItemInfo> _tagListControl;

		public IFlyout Flyout => _flyout ?? GetComponentInParent<FlyoutScript>(includeInactive: true);

		public IReadOnlyList<string> SelectedSubdirectories => _selectedSubdirectories;

		public IReadOnlyList<string> SelectedTags => _selectedTags;

		public event EventHandler<CraftFiltersChangedEventArgs> TagsChanged;

		public static CraftTagsPanelScript GetCraftTagsFlyout(bool createIfNecessary, Widget parent, CraftTagsPanel craftTagsPanel)
		{
			CraftTagsPanelScript craftTagsPanelScript = null;
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}
			Widget widget = parent.FindDirectChildWidget("craft-tags");
			if (widget == null)
			{
				if (!createIfNecessary)
				{
					return null;
				}
				widget = parent.Context.LoadWidgetFromXml("Xml/CraftTags", parent);
				craftTagsPanelScript = widget.GetComponentInChildren<CraftTagsPanelScript>(includeInactive: true);
				craftTagsPanelScript.Initialize(craftTagsPanel);
			}
			if (craftTagsPanelScript == null)
			{
				craftTagsPanelScript = widget.GetComponentInChildren<CraftTagsPanelScript>(includeInactive: true);
			}
			return craftTagsPanelScript;
		}

		public static CraftTagsPanel InitializeForHostWidget(Widget hostWidget, Widget parentWidget, bool saveCraftDialog, Action refreshCraftListAction)
		{
			return new CraftTagsPanel(hostWidget, parentWidget, saveCraftDialog, refreshCraftListAction);
		}

		public void Initialize(CraftTagsPanel craftTagsPanel)
		{
			_craftTagsPanel = craftTagsPanel;
			if (_craftTagsPanel.IsSaveCraftDialog)
			{
				base.Widget.Parent.Position = Vector2.zero;
				Flyout.Title = "Craft Tags";
				base.Widget.AddClass("save-craft-tags");
			}
			Flyout.Opened += OnFlyoutOpened;
			Flyout.Closed += OnFlyoutClosed;
			ReloadFilterSettings();
		}

		public void OnTagsChanged(IReadOnlyCollection<string> tags, IReadOnlyCollection<string> subdirectories)
		{
			_selectedTags.Clear();
			_selectedSubdirectories.Clear();
			_selectedTags.AddRange(tags);
			if (!_craftTagsPanel.IsSaveCraftDialog)
			{
				_selectedSubdirectories.AddRange(subdirectories);
			}
			if (Flyout.IsOpen)
			{
				Refresh();
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_selectedTags = new List<string>();
			_selectedSubdirectories = new List<string>();
			_favoriteTags = new List<string>();
			_favoriteSubdirectories = new List<string>();
			_addedTags = new List<string>();
			_filterSettings = Game.Instance.Settings.Gameplay.CraftFilters;
			ScrollViewWidget scrollView = base.Widget.FindWidget<ScrollViewWidget>("scroll-view");
			_tagListControl = new ListControl<ListItemInfo>(scrollView, "tag-list-item");
			_tagListControl.EnableMultiSelect = true;
			ListControl<ListItemInfo> tagListControl = _tagListControl;
			tagListControl.CreateListItem = (Action<Widget, ListItem<ListItemInfo>>)Delegate.Combine(tagListControl.CreateListItem, (Action<Widget, ListItem<ListItemInfo>>)delegate(Widget widget2, ListItem<ListItemInfo> listItem)
			{
				widget2.FindWidget<TextWidget>("tag-name").Text = listItem.Name;
				if (listItem.Item.Type == ListItemType.Label)
				{
					widget2.AddClass("tag-list-item-label");
				}
				else
				{
					widget2.RemoveClass("tag-list-item-label");
				}
				if (listItem.Item.Favorite)
				{
					widget2.AddClass("is-favorite");
				}
				else
				{
					widget2.RemoveClass("is-favorite");
				}
			});
			ListControl<ListItemInfo> tagListControl2 = _tagListControl;
			tagListControl2.SelectListItem = (Action<ListItem<ListItemInfo>>)Delegate.Combine(tagListControl2.SelectListItem, (Action<ListItem<ListItemInfo>>)delegate(ListItem<ListItemInfo> item)
			{
				if (item != null)
				{
					OnListItemSelectedStateChanged(item, selected: true);
				}
			});
			ListControl<ListItemInfo> tagListControl3 = _tagListControl;
			tagListControl3.DeselectListItem = (Action<ListItem<ListItemInfo>>)Delegate.Combine(tagListControl3.DeselectListItem, (Action<ListItem<ListItemInfo>>)delegate(ListItem<ListItemInfo> item)
			{
				if (item != null)
				{
					OnListItemSelectedStateChanged(item, selected: false);
				}
			});
			ListControl<ListItemInfo> tagListControl4 = _tagListControl;
			tagListControl4.ListItemAction = (Action<ListItem<ListItemInfo>, Widget, string>)Delegate.Combine(tagListControl4.ListItemAction, (Action<ListItem<ListItemInfo>, Widget, string>)delegate(ListItem<ListItemInfo> item, Widget widget2, string action)
			{
				if (item != null && action == "Favorite")
				{
					OnFavoriteButtonClicked(widget2, item);
				}
			});
			_tagListControl.FilterListItem = delegate(ListItem<ListItemInfo> listItem, string searchFilter)
			{
				if (listItem.Item.Type == ListItemType.Label)
				{
					return true;
				}
				return string.IsNullOrEmpty(searchFilter) || listItem.Name.Contains(searchFilter, StringComparison.OrdinalIgnoreCase);
			};
			_tagListControl.FinalizeFilteredListItems = delegate(List<ListItem<ListItemInfo>> listItems, string searchFilter)
			{
				int num = 0;
				for (int num2 = listItems.Count - 1; num2 >= 0; num2--)
				{
					if (listItems[num2].Item.Type == ListItemType.Label)
					{
						if (num == 0)
						{
							listItems.RemoveAt(num2);
						}
						num = 0;
					}
					else
					{
						num++;
					}
				}
			};
			_searchInput = base.Widget.FindWidget<InputWidget>("search-input");
			_searchInput.Input.onValueChanged.AddListener(delegate(string s)
			{
				OnSearchChanged(s);
			});
		}

		protected virtual void Update()
		{
			_tagListControl.Update();
		}

		private static ListItem<ListItemInfo> CreateListItem(string name, bool favorite, ListItemType type, string displayName = null)
		{
			return new ListItem<ListItemInfo>(displayName ?? name, new ListItemInfo(name, favorite, type))
			{
				CanRename = true
			};
		}

		private void OnAddTag(Widget widget)
		{
			string text = (_searchInput.Text ?? string.Empty).Trim();
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			string text2 = null;
			foreach (string addedTag in _addedTags)
			{
				if (string.Equals(addedTag, text, StringComparison.OrdinalIgnoreCase))
				{
					text2 = addedTag;
					break;
				}
			}
			if (text2 == null)
			{
				List<string> value;
				using (CollectionPool<List<string>, string>.Get(out value))
				{
					Game.Instance.CraftDatabase.GetTags(value, sorted: false, allTags: true);
					foreach (string item in value)
					{
						if (string.Equals(item, text, StringComparison.OrdinalIgnoreCase))
						{
							text2 = item;
							break;
						}
					}
				}
			}
			if (text2 == null)
			{
				text2 = text;
			}
			if (!_selectedTags.Contains(text2))
			{
				_selectedTags.Add(text2);
				this.TagsChanged?.Invoke(this, new CraftFiltersChangedEventArgs(_selectedTags, _selectedSubdirectories));
			}
			Refresh();
		}

		private void OnClearFilters(Widget widget)
		{
			OnTagsChanged(Array.Empty<string>(), Array.Empty<string>());
		}

		private void OnFavoriteButtonClicked(Widget widget, ListItem<ListItemInfo> item)
		{
			item.Item.Favorite = !item.Item.Favorite;
			if (item.Item.Favorite)
			{
				widget.AddClass("is-favorite");
			}
			else
			{
				widget.RemoveClass("is-favorite");
			}
			OnListItemFavoriteStateChanged(item, item.Item.Favorite);
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			Refresh();
			if (!SocialExt.IsSteamDeckOrBigPicture)
			{
				_searchInput.Input.Select();
			}
		}

		private void OnHostFlyoutOpened()
		{
			ReloadFilterSettings();
			Refresh();
		}

		private void OnListItemFavoriteStateChanged(ListItem<ListItemInfo> item, bool isFavorite)
		{
			if (item.Item.Type == ListItemType.Tag)
			{
				if (isFavorite)
				{
					if (!_favoriteTags.Contains(item.Item.Name))
					{
						_favoriteTags.Add(item.Item.Name);
					}
				}
				else
				{
					_favoriteTags.Remove(item.Item.Name);
				}
				_filterSettings.SetFavoriteTags(_favoriteTags);
			}
			else
			{
				if (item.Item.Type != ListItemType.Subdirectory)
				{
					return;
				}
				if (isFavorite)
				{
					if (!_favoriteSubdirectories.Contains(item.Item.Name))
					{
						_favoriteSubdirectories.Add(item.Item.Name);
					}
				}
				else
				{
					_favoriteSubdirectories.Remove(item.Item.Name);
				}
				_filterSettings.SetFavoriteSubdirectories(_favoriteSubdirectories);
			}
		}

		private void OnListItemSelectedStateChanged(ListItem<ListItemInfo> item, bool selected)
		{
			if (item.Item.Type == ListItemType.Tag)
			{
				if (selected)
				{
					if (!_selectedTags.Contains(item.Item.Name))
					{
						_selectedTags.Add(item.Item.Name);
					}
				}
				else
				{
					_selectedTags.Remove(item.Item.Name);
				}
				if (!_craftTagsPanel.IsSaveCraftDialog)
				{
					_filterSettings.SetActiveTags(_selectedTags);
				}
				this.TagsChanged?.Invoke(this, new CraftFiltersChangedEventArgs(_selectedTags, _selectedSubdirectories));
			}
			else
			{
				if (item.Item.Type != ListItemType.Subdirectory)
				{
					return;
				}
				if (selected)
				{
					if (!_selectedSubdirectories.Contains(item.Item.Name))
					{
						_selectedSubdirectories.Add(item.Item.Name);
					}
				}
				else
				{
					_selectedSubdirectories.Remove(item.Item.Name);
				}
				if (!_craftTagsPanel.IsSaveCraftDialog)
				{
					_filterSettings.SetActiveSubdirectories(_selectedSubdirectories);
				}
				this.TagsChanged?.Invoke(this, new CraftFiltersChangedEventArgs(_selectedTags, _selectedSubdirectories));
			}
		}

		private void OnSearchChanged(string searchFilter)
		{
			_tagListControl.SearchFilter = searchFilter;
		}

		private void Refresh()
		{
			List<string> value;
			using (CollectionPool<List<string>, string>.Get(out value))
			{
				Game.Instance.CraftDatabase.GetTags(value, sorted: true, _craftTagsPanel.IsSaveCraftDialog);
				List<string> value2;
				using (CollectionPool<List<string>, string>.Get(out value2))
				{
					Game.Instance.CraftDatabase.GetSubdirectories(value2, sorted: true);
					List<ListItem<ListItemInfo>> value3;
					using (CollectionPool<List<ListItem<ListItemInfo>>, ListItem<ListItemInfo>>.Get(out value3))
					{
						List<ListItem<ListItemInfo>> value4;
						using (CollectionPool<List<ListItem<ListItemInfo>>, ListItem<ListItemInfo>>.Get(out value4))
						{
							List<ListItem<ListItemInfo>> value5;
							using (CollectionPool<List<ListItem<ListItemInfo>>, ListItem<ListItemInfo>>.Get(out value5))
							{
								List<ListItem<ListItemInfo>> value6;
								using (CollectionPool<List<ListItem<ListItemInfo>>, ListItem<ListItemInfo>>.Get(out value6))
								{
									List<ListItem<ListItemInfo>> value7;
									using (CollectionPool<List<ListItem<ListItemInfo>>, ListItem<ListItemInfo>>.Get(out value7))
									{
										foreach (string selectedTag in _selectedTags)
										{
											bool flag = false;
											foreach (string item3 in value)
											{
												if (string.Equals(item3, selectedTag, StringComparison.OrdinalIgnoreCase))
												{
													flag = true;
													break;
												}
											}
											if (!flag)
											{
												foreach (string addedTag in _addedTags)
												{
													if (string.Equals(addedTag, selectedTag, StringComparison.OrdinalIgnoreCase))
													{
														flag = true;
														break;
													}
												}
											}
											if (!flag)
											{
												_addedTags.Add(selectedTag);
											}
										}
										if (_addedTags.Count > 0)
										{
											value.AddRange(_addedTags);
											value.Sort(StringComparer.OrdinalIgnoreCase);
										}
										foreach (string item4 in value)
										{
											if (!(item4 == "None") || !_craftTagsPanel.IsSaveCraftDialog)
											{
												bool flag2 = _favoriteTags.Contains(item4);
												bool num = _selectedTags.Contains(item4);
												string displayName = ((item4 == "None") ? "No Tags" : item4);
												ListItem<ListItemInfo> item = CreateListItem(item4, flag2, ListItemType.Tag, displayName);
												if (flag2)
												{
													value6.Add(item);
												}
												else
												{
													value4.Add(item);
												}
												if (num)
												{
													value3.Add(item);
												}
											}
										}
										if (!_craftTagsPanel.IsSaveCraftDialog)
										{
											foreach (string item5 in value2)
											{
												if (!(item5 == "Required Craft"))
												{
													bool flag3 = _favoriteSubdirectories.Contains(item5);
													bool num2 = _selectedSubdirectories.Contains(item5);
													string displayName2 = ((item5 == "None") ? "No Subdirectory" : item5);
													ListItem<ListItemInfo> item2 = CreateListItem(item5, flag3, ListItemType.Subdirectory, displayName2);
													if (flag3)
													{
														value7.Add(item2);
													}
													else
													{
														value5.Add(item2);
													}
													if (num2)
													{
														value3.Add(item2);
													}
												}
											}
										}
										_tagListControl.Items.Clear();
										if (value6.Count > 0)
										{
											_tagListControl.Items.Add(CreateListItem("Favorite Tags", favorite: false, ListItemType.Label));
											foreach (ListItem<ListItemInfo> item6 in value6)
											{
												_tagListControl.Items.Add(item6);
											}
										}
										if (value7.Count > 0)
										{
											_tagListControl.Items.Add(CreateListItem("Favorite Subdirectories", favorite: false, ListItemType.Label));
											foreach (ListItem<ListItemInfo> item7 in value7)
											{
												_tagListControl.Items.Add(item7);
											}
										}
										if (value4.Count > 0)
										{
											_tagListControl.Items.Add(CreateListItem("Tags", favorite: false, ListItemType.Label));
											foreach (ListItem<ListItemInfo> item8 in value4)
											{
												_tagListControl.Items.Add(item8);
											}
										}
										if (value5.Count > 0)
										{
											_tagListControl.Items.Add(CreateListItem("Subdirectories", favorite: false, ListItemType.Label));
											foreach (ListItem<ListItemInfo> item9 in value5)
											{
												_tagListControl.Items.Add(item9);
											}
										}
										_tagListControl.DeselectAllItems();
										foreach (ListItem<ListItemInfo> item10 in value3)
										{
											_tagListControl.SelectItem(item10);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void ReloadFilterSettings()
		{
			_selectedTags.Clear();
			_selectedSubdirectories.Clear();
			_favoriteTags.Clear();
			_favoriteSubdirectories.Clear();
			if (_craftTagsPanel.IsSaveCraftDialog)
			{
				_craftTagsPanel.GetSelectedTags(_selectedTags);
				_filterSettings.GetFavoriteTags(_favoriteTags);
				return;
			}
			_filterSettings.GetActiveTags(_selectedTags);
			_filterSettings.GetFavoriteTags(_favoriteTags);
			_filterSettings.GetActiveSubdirectories(_selectedSubdirectories);
			_filterSettings.GetFavoriteSubdirectories(_favoriteSubdirectories);
		}
	}
}
