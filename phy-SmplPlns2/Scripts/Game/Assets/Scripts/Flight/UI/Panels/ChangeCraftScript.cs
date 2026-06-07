using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Achievements;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Craft.CraftFiles.Exceptions;
using Assets.Scripts.Design;
using Assets.Scripts.Settings;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Assets.Scripts.UI.Dialogs;
using Jundroo.Common.DataTypes;
using Jundroo.Common.Pool;
using Jundroo.Common.Settings;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Jundroo.SocialPlatforms;
using Jundroo.SocialPlatforms.Achievements;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class ChangeCraftScript : FlightPanelScript
	{
		private Widget _changeCraftButton;

		private CraftTagsPanelScript.CraftTagsPanel _craftTagsPanel;

		private CraftListControl _listControl;

		private InputWidget _searchInput;

		private SpinnerControl _sortSpinner;

		private bool CanSpawn
		{
			get
			{
				if (!(FlightSceneScript.Instance.LocalPlayer.Aircraft == null))
				{
					AircraftScript aircraft = FlightSceneScript.Instance.LocalPlayer.Aircraft;
					if ((object)aircraft == null)
					{
						return false;
					}
					return aircraft.NetworkAircraft?.IsInitialized == true;
				}
				return true;
			}
		}

		private string CurrentCraftId
		{
			get
			{
				return FlightSceneScript.Instance.LocalPlayer.NetworkPlayer.CraftId;
			}
			set
			{
				FlightSceneScript.Instance.LocalPlayer.NetworkPlayer.CraftId = value;
			}
		}

		public override void InitializeFlightPanel(FlightUIScript flightUI)
		{
			base.InitializeFlightPanel(flightUI);
			_changeCraftButton = base.Widget.FindWidget("change-craft-button");
			_searchInput = base.Widget.FindWidget<InputWidget>("search-input");
			_searchInput.Input.onValueChanged.AddListener(delegate
			{
				OnSearchChanged();
			});
			_listControl = new CraftListControl(base.Widget.FindWidget<ScrollViewWidget>("scroll-view"));
			_listControl.DeleteListItem = delegate(ListItem<CraftFileInfo> x)
			{
				try
				{
					x.Item.Delete();
					base.FlightUI.ShowMessage("Deleted '" + x.Name + "'");
				}
				catch (CraftDatabaseException ex)
				{
					base.FlightUI.ShowMessage(ex.Message);
				}
			};
			_listControl.RenameListItem = delegate(ListItem<CraftFileInfo> x, string s)
			{
				try
				{
					x.Item.Rename(s + ".xml");
					BuildAircraftList();
					return true;
				}
				catch (CraftDatabaseException ex)
				{
					base.FlightUI.ShowMessage(ex.Message);
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
				BuildAircraftList();
			});
			StringValueTypeWrapper value = Game.Instance.Settings.Gameplay.CraftFilters.SortMode.Value;
			_sortSpinner.Value = (_sortSpinner.Values.Contains(value) ? ((string)value) : "Name ▲");
			_craftTagsPanel = CraftTagsPanelScript.InitializeForHostWidget(base.Widget, base.FlightUI.RootWidget, saveCraftDialog: false, BuildAircraftList);
			base.Flyout.Opened += delegate
			{
				_craftTagsPanel.OnHostFlyoutOpened();
				BuildAircraftList();
				if (!SocialExt.IsSteamDeckOrBigPicture)
				{
					_searchInput.Input.Select();
				}
			};
			base.Flyout.Closed += delegate
			{
				_craftTagsPanel.CloseFlyout();
			};
			base.Flyout.HeaderClicked += OnHeaderClicked;
		}

		public void LoadAircraftFromClipboardOrUrl(string url = null)
		{
			AchievementHelper.UnlockAchievement(AchievementKey.WebsiteDownloadPlane);
			string text = url;
			if (string.IsNullOrEmpty(text))
			{
				text = DesignerScript.FindAircraftUrlId(GUIUtility.systemCopyBuffer);
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
			}
			Game.Instance.UserInterface.CreateCraftDownloadDialog().StartDownload(text, delegate(CraftDownloadDialogScript.CraftDownloadResult result)
			{
				if (result.ResultType == CraftDownloadDialogScript.CraftDownloadResultType.Success)
				{
					RestartHereWithCraft(result.CraftXml);
				}
			});
		}

		protected virtual void Update()
		{
			_listControl.Update();
			bool flag = true;
			if (CanSpawn && FlightSceneScript.Instance.FlightUI.LoadCraftCooldown <= 0f)
			{
				flag = false;
			}
			_changeCraftButton.EnableClass("loading", flag);
		}

		private static void RestartHereWithCraft(XElement aircraftXml)
		{
			Game.Instance.CraftDatabase.SaveCraft("__editor__.xml", aircraftXml, backupPreviousFile: false, updateXmlVersion: false);
			FlightSceneScript.Instance.LocalPlayer.NetworkPlayer.CraftId = "__editor__.xml";
			FlightSceneScript.Instance.FlightUI.RestartHere();
		}

		private void BuildAircraftList()
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
				if (Game.Instance.CraftDatabase.TryGetCraft("__editor__.xml", out var craftFileInfo))
				{
					_listControl.Items.Add(new ListItem<CraftFileInfo>(craftFileInfo.Name, craftFileInfo)
					{
						CanDelete = false,
						CanRename = false
					});
				}
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
						CanDelete = flag,
						CanRename = flag
					});
				}
			}
		}

		private void OnChangeCraftClicked(Widget widget)
		{
			if (_listControl.SelectedItem != null && CanSpawn)
			{
				RestartHereWithCraft(_listControl.SelectedItem.Item.LoadXml(showErrorDialogs: true));
				_changeCraftButton.EnableClass("loading", enabled: true);
			}
		}

		private void OnDownloadCraftClicked(Widget widget)
		{
			Game.Instance.UserInterface.OpenDownloadCraftsUrl();
		}

		private void OnHeaderClicked(IFlyout flyout)
		{
			flyout.Close();
			_craftTagsPanel.CloseFlyout();
		}

		private void OnSaveCraftClicked(Widget widget)
		{
			XElement craftXml = FlightSceneScript.Instance.LocalPlayer.Aircraft?.NetworkAircraft?.CraftXml;
			if (craftXml != null)
			{
				InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
				inputDialogScript.Title = "Save Craft";
				inputDialogScript.InputPlaceholderText = "Craft Name";
				inputDialogScript.OkayButtonText = "Save";
				inputDialogScript.CancelButtonText = "Cancel";
				inputDialogScript.ValidationFunction = FileIOUtility.IsValidPath;
				inputDialogScript.InvalidCharacters.AddRange(Path.GetInvalidPathChars());
				inputDialogScript.InputText = craftXml.Attribute("name")?.Value ?? "Unknown Aircraft";
				inputDialogScript.OkayClicked += delegate(InputDialogScript d)
				{
					OnSaveCraftDialogOkayClicked(d, craftXml);
				};
			}
		}

		private void OnSaveCraftDialogOkayClicked(InputDialogScript dialog, XElement craftXml)
		{
			string aircraftId = dialog.InputText;
			Action<string> saveCraft = delegate(string id)
			{
				try
				{
					Game.Instance.CraftDatabase.SaveCraft(id, craftXml, backupPreviousFile: false, updateXmlVersion: false);
					BuildAircraftList();
				}
				catch (CraftDatabaseException ex)
				{
					Game.Instance.UserInterface.CreateMessageDialog(ex.Message, "Craft Save Failed");
				}
				dialog.Close();
			};
			if (string.IsNullOrWhiteSpace(aircraftId))
			{
				return;
			}
			aircraftId += ".xml";
			if (Game.Instance.CraftDatabase.TryGetCraft(aircraftId, out var _))
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = "A craft already exists with that name. Do you wish to overwrite it?";
				messageDialogScript.OkayButtonText = "Overwrite";
				messageDialogScript.UseDangerButtonStyle = true;
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					saveCraft(aircraftId);
					d.Close();
				};
			}
			else
			{
				saveCraft(aircraftId);
			}
		}

		private void OnSearchChanged()
		{
			_listControl.SearchFilter = _searchInput.Text;
		}
	}
}
