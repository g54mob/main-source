using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Craft.CraftFiles.Exceptions;
using Assets.Scripts.Settings;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.DataTypes;
using Jundroo.Common.Pool;
using Jundroo.Common.Settings;
using Jundroo.Juicy.Widgets;
using Jundroo.SocialPlatforms;

namespace Assets.Scripts.Design.UI
{
	public class LoadCraftPanelScript : DesignerPanelScript
	{
		public const string SortModeDateAscending = "Date ▲";

		public const string SortModeDateDescending = "Date ▼";

		public const string SortModeIdAscending = "Path ▲";

		public const string SortModeIdDescending = "Path ▼";

		public const string SortModeNameAscending = "Name ▲";

		public const string SortModeNameDescending = "Name ▼";

		private CraftTagsPanelScript.CraftTagsPanel _craftTagsPanel;

		private CraftListControl _listControl;

		private InputWidget _searchInput;

		private SpinnerControl _sortSpinner;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			ScrollViewWidget scrollView = base.Widget.FindWidget<ScrollViewWidget>("scroll-view");
			_listControl = new CraftListControl(scrollView);
			_listControl.DeleteListItem = delegate(ListItem<CraftFileInfo> x)
			{
				try
				{
					x.Item.Delete();
					base.DesignerUI.ShowMessage("Deleted '" + x.Name + "'");
				}
				catch (CraftDatabaseException ex)
				{
					base.DesignerUI.ShowMessage(ex.Message);
				}
			};
			_listControl.SelectListItem = delegate(ListItem<CraftFileInfo> x)
			{
				if (x != null)
				{
					XElement xElement = x.Item.LoadXml(showErrorDialogs: true);
					if (xElement == null)
					{
						Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "An error occurred loading the requested aircraft: '" + x.Name + "'");
						Refresh();
					}
					else
					{
						Game.Instance.CraftDatabase.CurrentSubdirectoryPath = x.Item.SubdirectoryPath;
						StartCoroutine(LoadAircraft(xElement, x.Name));
					}
				}
			};
			_listControl.RenameListItem = delegate(ListItem<CraftFileInfo> x, string s)
			{
				try
				{
					x.Item.Rename(s + ".xml");
					Refresh();
					return true;
				}
				catch (CraftDatabaseException ex)
				{
					base.DesignerUI.ShowMessage(ex.Message);
					return false;
				}
			};
			_sortSpinner = new SpinnerControl(base.Widget.FindWidget("sort-mode-spinner"));
			_sortSpinner.Values.Add("Name ▲");
			_sortSpinner.Values.Add("Name ▼");
			_sortSpinner.Values.Add("Date ▲");
			_sortSpinner.Values.Add("Date ▼");
			_sortSpinner.Values.Add("Path ▲");
			_sortSpinner.Values.Add("Path ▼");
			SpinnerControl sortSpinner = _sortSpinner;
			sortSpinner.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(sortSpinner.OnValueChanged, (OnValueChanged<string>)delegate
			{
				StringSetting sortMode = Game.Instance.Settings.Gameplay.CraftFilters.SortMode;
				sortMode.Value = _sortSpinner.Value;
				sortMode.CommitChanges();
				Refresh();
			});
			StringValueTypeWrapper value = Game.Instance.Settings.Gameplay.CraftFilters.SortMode.Value;
			_sortSpinner.Value = (_sortSpinner.Values.Contains(value) ? ((string)value) : "Name ▲");
			_searchInput = base.Widget.FindWidget<InputWidget>("search-input");
			_searchInput.Input.onValueChanged.AddListener(delegate(string s)
			{
				OnSearchChanged(s);
			});
			_craftTagsPanel = CraftTagsPanelScript.InitializeForHostWidget(base.Widget, base.DesignerUI.RootWidget, saveCraftDialog: false, Refresh);
			base.Flyout.Opened += OnFlyoutOpened;
			base.Flyout.Closed += OnFlyoutClosed;
			base.Flyout.HeaderClicked += OnHeaderClicked;
		}

		protected virtual void OnDestroy()
		{
			if (base.Flyout != null)
			{
				base.Flyout.Opened -= OnFlyoutOpened;
				base.Flyout.Closed -= OnFlyoutClosed;
				base.Flyout.HeaderClicked -= OnHeaderClicked;
			}
		}

		protected virtual void Update()
		{
			_listControl.Update();
		}

		private IEnumerator LoadAircraft(XElement aircraftElement, string name)
		{
			base.DesignerUI.ShowMessage("Loading...", 7f, animate: false);
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			base.Designer.LoadXml(aircraftElement, isNewAircraft: true);
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			base.DesignerUI.ShowMessage("Loaded '" + name + "'");
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			_craftTagsPanel.CloseFlyout();
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			_craftTagsPanel.OnHostFlyoutOpened();
			Refresh();
			if (!SocialExt.IsSteamDeckOrBigPicture)
			{
				_searchInput.Input.Select();
			}
		}

		private void OnHeaderClicked(IFlyout flyout)
		{
			flyout.Close();
			_craftTagsPanel.CloseFlyout();
		}

		private void OnSearchChanged(string searchFilter)
		{
			_listControl.SearchFilter = searchFilter;
		}

		private void Refresh()
		{
			List<CraftFileInfo> value;
			using (CollectionPool<List<CraftFileInfo>, CraftFileInfo>.Get(out value))
			{
				CraftSettings crafts = Game.Instance.Settings.Cloud.Crafts;
				foreach (CraftFileInfo craft in Game.Instance.CraftDatabase.GetCrafts(_craftTagsPanel.SelectedTagsAsFilters, _craftTagsPanel.SelectedSubdirectoriesAsFilters))
				{
					if (!craft.IsHidden && !crafts.IsUndiscoveredDiscoverable(craft.Id))
					{
						value.Add(craft);
					}
				}
				switch (_sortSpinner.Value)
				{
				case "Date ▲":
					value = value.OrderBy((CraftFileInfo x) => x.LastModified).ToList();
					break;
				case "Date ▼":
					value = value.OrderByDescending((CraftFileInfo x) => x.LastModified).ToList();
					break;
				case "Name ▲":
					value = value.OrderBy((CraftFileInfo x) => x.Name).ToList();
					break;
				case "Name ▼":
					value = value.OrderByDescending((CraftFileInfo x) => x.Name).ToList();
					break;
				case "Path ▲":
					value = value.OrderBy((CraftFileInfo x) => x.Id).ToList();
					break;
				case "Path ▼":
					value = value.OrderByDescending((CraftFileInfo x) => x.Id).ToList();
					break;
				}
				_listControl.Items.Clear();
				foreach (CraftFileInfo item in value)
				{
					bool flag = true;
					string[] readOnlyDirectories = CraftDatabase.ReadOnlyDirectories;
					for (int num = 0; num < readOnlyDirectories.Length; num++)
					{
						if (readOnlyDirectories[num] == item.SubdirectoryPath)
						{
							flag = false;
							break;
						}
					}
					_listControl.Items.Add(new ListItem<CraftFileInfo>(item.FileNameWithoutExtension, item)
					{
						CanRename = flag,
						CanDelete = flag
					});
				}
			}
		}
	}
}
