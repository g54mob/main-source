using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Settings;
using Jundroo.ModTools;
using Jundroo.ModTools.Core;
using ModApi.Core;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class ModsViewModel : ListViewModel
	{
		private static bool _acceptedModWarningThisSession;

		private ContextMenuItemScript _contextMenuDisableAll;

		private ContextMenuItemScript _contextMenuEnableAll;

		private ContextMenuItemScript _contextMenuToggleModSupport;

		private ModsDetails _details;

		private IModManager _modManager;

		public static bool RestartRequired { get; private set; }

		public override IEnumerator LoadItems()
		{
			if (!RestartRequired)
			{
				foreach (ModInfo knownMod in _modManager.KnownMods)
				{
					ListViewItemScript item = base.ListView.CreateItem(knownMod.Name, knownMod.Author, knownMod, null, ListViewScript.SpriteLoadLocation.Resources);
					RefreshItem(item);
				}
			}
			yield return new WaitForEndOfFrame();
		}

		public override void OnDeleteButtonClicked(ListViewItemScript selectedItem)
		{
			ModInfo mod = (ModInfo)selectedItem.ItemModel;
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.OkayButtonText = "DELETE";
			messageDialogScript.MessageText = string.Format("Confirm that you want to delete the mod '" + mod.Name + "'");
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				_modManager.DeleteMod(mod);
				base.ListView.DeleteItem(selectedItem);
				Items.Remove(selectedItem);
				base.ListView.SelectedItem = null;
			};
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			_modManager = Game.Instance.ModManagerScript.ModManager;
			_details = new ModsDetails(listView.ListViewDetails);
			listView.Title = "Mods";
			listView.DisplayType = ListViewScript.ListViewDisplayType.SmallDialog;
			listView.PrimaryButtonText = "ENABLE";
			listView.PrimaryButtonEnabled = !RestartRequired;
			listView.CanDelete = false;
			bool modSupportEnabled = Game.Instance.Settings.ModSupportEnabled;
			if (!RestartRequired)
			{
				if (modSupportEnabled)
				{
					base.ListView.NoSelectionMessageText = "Select a mod on the left to view details about it and to enable or disable it.";
					_contextMenuDisableAll = listView.CreateContextMenuItem("Disable All Mods", OnDisableAllMods, "Disables all mods that are currently enabled.");
					_contextMenuEnableAll = listView.CreateContextMenuItem("Enable All Mods", OnEnableAllMods, "Enables all mods that are not currently enabled or pending disable.");
					_contextMenuToggleModSupport = listView.CreateContextMenuItem("Disable Mod Support", OnToggleModSupport, "Toggles mod support off without affecting the current list of enabled mods. Requires restart.");
					RefreshContextMenu();
				}
				else
				{
					base.ListView.NoSelectionMessageText = "Mod support is currently disabled. It can be re-enabled via the button in the top right of this dialog. A restart will be required in order for the change to take effect.";
					_contextMenuToggleModSupport = listView.CreateContextMenuItem("Enable Mod Support", OnToggleModSupport, "Re-enables mod support.");
				}
			}
			else if (modSupportEnabled)
			{
				base.ListView.NoSelectionMessageText = "Mod support is currently disabled but it will be restored once the game is restarted.";
			}
			else
			{
				base.ListView.NoSelectionMessageText = "Mod support has been disabled but the game needs to be restarted for this to fully take effect.";
			}
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			ModInfo mod = (ModInfo)selectedItem.ItemModel;
			if (mod.PendingDisable)
			{
				return;
			}
			if (mod.Enabled)
			{
				mod.Enabled = false;
				mod.PendingDisable = true;
				SaveChanges();
				return;
			}
			ShowWarningDialog(delegate
			{
				mod.Enabled = true;
				_modManager.LoadMod(mod, allowApiVersionMismatch: true);
				Game.Instance.PartStyleManager.RebuildTextureArraysIfNecessary();
				SaveChanges();
			});
		}

		public override void OnSelectedItemChanged(ListViewItemScript item)
		{
			ModInfo mod = item?.ItemModel as ModInfo;
			RefreshButtons(mod);
		}

		public void RefreshButtons(ModInfo mod)
		{
			if (mod == null)
			{
				base.ListView.PrimaryButtonEnabled = false;
				base.ListView.CanDelete = false;
			}
			else if (mod.PendingDisable)
			{
				base.ListView.PrimaryButtonText = "PENDING\nDISABLE";
				base.ListView.PrimaryButtonEnabled = false;
				base.ListView.CanDelete = false;
			}
			else if (mod.Enabled)
			{
				base.ListView.PrimaryButtonText = "DISABLE";
				base.ListView.PrimaryButtonEnabled = !RestartRequired;
				base.ListView.CanDelete = false;
			}
			else
			{
				base.ListView.PrimaryButtonText = "ENABLE";
				base.ListView.PrimaryButtonEnabled = !RestartRequired;
				base.ListView.CanDelete = true;
			}
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			_details.UpdateDetails((ModInfo)item.ItemModel);
			completeCallback?.Invoke();
		}

		private void OnDisableAllMods(ContextMenuItemScript item)
		{
			foreach (ListViewItemScript item2 in Items)
			{
				ModInfo modInfo = (ModInfo)item2.ItemModel;
				if (modInfo.Enabled && !modInfo.PendingDisable)
				{
					modInfo.Enabled = false;
					modInfo.PendingDisable = true;
					RefreshItem(item2);
				}
			}
			SaveChanges();
		}

		private void OnEnableAllMods(ContextMenuItemScript item)
		{
			ShowWarningDialog(delegate
			{
				foreach (ListViewItemScript item2 in Items)
				{
					ModInfo modInfo = (ModInfo)item2.ItemModel;
					if (!modInfo.Enabled && !modInfo.PendingDisable)
					{
						modInfo.Enabled = true;
						try
						{
							_modManager.LoadMod(modInfo, allowApiVersionMismatch: true);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
						RefreshItem(item2);
					}
				}
				Game.Instance.PartStyleManager.RebuildTextureArraysIfNecessary();
				SaveChanges();
			});
		}

		private void OnToggleModSupport(ContextMenuItemScript item)
		{
			ApplicationSettings settings = Game.Instance.Settings;
			bool flag = (settings.ModSupportEnabled = !settings.ModSupportEnabled);
			settings.Save();
			RestartRequired = true;
			base.ListView.Close();
			Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Mod support has been " + (flag ? "enabled" : "disabled") + ". Restart the game for changes to take effect.";
		}

		private void RefreshContextMenu()
		{
			_contextMenuDisableAll.Visible = _modManager.KnownMods.Any((ModInfo x) => x.Enabled && !x.PendingDisable);
			_contextMenuEnableAll.Visible = _modManager.KnownMods.Any((ModInfo x) => !x.Enabled && !x.PendingDisable);
		}

		private void RefreshItem(ListViewItemScript item)
		{
			ModInfo mod = (ModInfo)item.ItemModel;
			List<ModLoadMessage> list = _modManager.ModLoadErrors.Where((ModLoadMessage x) => x.Mod == mod).ToList();
			List<ModLoadMessage> list2 = _modManager.ModLoadWarnings.Where((ModLoadMessage x) => x.Mod == mod).ToList();
			if (mod.PendingDisable)
			{
				item.StatusIcon = ListViewItemScript.StatusIconType.Checkmark;
				item.StatusIconColor = "ButtonDisabled";
				item.StatusIconTooltip = "This mod is will be disabled when the game is restarted.";
			}
			else if (list.Count > 0)
			{
				item.StatusIcon = ListViewItemScript.StatusIconType.Exclamation;
				item.StatusIconColor = "Danger";
				item.StatusIconTooltip = "This mod is enabled, but some errors occurred when it was loaded.";
			}
			else if (list2.Count > 0)
			{
				item.StatusIcon = ListViewItemScript.StatusIconType.Exclamation;
				item.StatusIconColor = "Warning";
				item.StatusIconTooltip = "This mod is enabled, but some warnings occurred when it was loaded.";
			}
			else if (mod.Enabled)
			{
				item.StatusIcon = ListViewItemScript.StatusIconType.Checkmark;
				item.StatusIconColor = "White";
				item.StatusIconTooltip = "This mod is enabled and loaded.";
			}
			else
			{
				item.StatusIcon = ListViewItemScript.StatusIconType.None;
				item.StatusIconColor = "White";
				item.StatusIconTooltip = string.Empty;
			}
		}

		private void SaveChanges()
		{
			RefreshContextMenu();
			ListViewItemScript selectedItem = base.ListView.SelectedItem;
			if (selectedItem != null)
			{
				ModInfo mod = (ModInfo)selectedItem.ItemModel;
				RefreshItem(selectedItem);
				RefreshButtons(mod);
				_details.UpdateDetails(mod);
			}
			List<ModInfo> list = _modManager.KnownMods.Where((ModInfo x) => x.Enabled && !x.PendingDisable).ToList();
			ApplicationSettings settings = Game.Instance.Settings;
			settings.UpdateEnabledMods(list);
			settings.Save();
		}

		private void ShowWarningDialog(Action acceptedAction)
		{
			if (_acceptedModWarningThisSession)
			{
				acceptedAction?.Invoke();
				return;
			}
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.CancelButtonText = "CANCEL";
			messageDialogScript.OkayButtonText = "I ACCEPT";
			messageDialogScript.MessageText = "WARNING: Mods can execute code. This means that the author of the mod could use it for evil and damage your system. Only run a mod if you trust the author. By clicking 'I Accept' below, you agree that you bear this risk and Jundroo, LLC is not responsible for any damages.";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				_acceptedModWarningThisSession = true;
				acceptedAction?.Invoke();
			};
		}
	}
}
