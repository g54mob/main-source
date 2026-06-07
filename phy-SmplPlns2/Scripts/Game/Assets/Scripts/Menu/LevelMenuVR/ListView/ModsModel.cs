using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Mods;
using Assets.Scripts.Storage;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class ModsModel : ListViewModel
	{
		public class ModItemModel : ItemModel
		{
			public bool Active
			{
				get
				{
					if (Mod.Enabled)
					{
						return !PendingDisable;
					}
					return false;
				}
			}

			public ModLoadMessage[] LoadErrors => ModManager.Instance.ModLoadErrors.Where((ModLoadMessage x) => x.Mod == Mod).ToArray();

			public ModInfo Mod { get; }

			public bool PendingDisable => ModsPendingDisable.Contains(Mod.Path);

			public ModItemModel(ModInfo mod)
				: base(mod.Name)
			{
				Mod = mod;
			}
		}

		private const string NavItemActive = "Active";

		private const string NavItemAll = "All";

		private const string NavItemInactive = "Inactive";

		private static List<string> _modsPendingDisable = new List<string>();

		private bool _acceptedModWarningThisSession;

		private LevelMenuVRScript _levelMenu;

		private bool _restartSceneOnExit;

		private ModInfo _selectedModAtStartup;

		public static List<string> ModsPendingDisable => _modsPendingDisable;

		public ModsModel(LevelMenuVRScript levelMenu)
		{
			_levelMenu = levelMenu;
		}

		public static void SetModActive(ModInfo mod, bool active)
		{
			mod.Enabled = active;
			if (mod.Enabled)
			{
				ModManager.Instance.LoadMod(mod, allowApiVersionMismatch: true);
			}
			else
			{
				ModsPendingDisable.Add(mod.Path);
			}
			if (Game.Instance.Settings.App.UpdateEnabledMods(ModManager.Instance.KnownMods.Where((ModInfo x) => x.Enabled).ToList()))
			{
				Debug.Log("List of enabled mods changed. Saving settings...");
				Game.Instance.Settings.App.Save();
			}
			ModManager.Instance.SaveModLoadLog(GameData.GetPath("ModLoadLog.txt"));
		}

		public override IEnumerator LoadItems(List<ItemModel> items)
		{
			base.ListView.ShowModsInfoSection(show: false);
			IModManager modManager = Game.Instance.ModManager;
			new List<ModItemModel>();
			string text = base.ListView.SelectedNavItem.UserData as string;
			bool? flag = null;
			if (text == "Active")
			{
				flag = true;
			}
			else if (text == "Inactive")
			{
				flag = false;
			}
			foreach (ModInfo item in modManager.KnownMods.OrderBy((ModInfo x) => x.Name))
			{
				ModItemModel modItem = new ModItemModel(item);
				if (!flag.HasValue || modItem.Active == flag)
				{
					modItem.ThumbnailLocation = ResourceLocation.Web;
					modItem.ThumbnailPath = Uri.EscapeUriString(Game.SimplePlanesWebsiteUrl + "/Client/DownloadModThumbnail?name=" + modItem.Mod.Name);
					items.Add(modItem);
					modItem.CheckmarkStyle = () => modItem.Active ? ((modItem.LoadErrors.Length == 0) ? ItemModel.CheckmarkStyleTypes.Success : ItemModel.CheckmarkStyleTypes.Error) : ItemModel.CheckmarkStyleTypes.Invisible;
				}
			}
			yield return null;
		}

		public override void OnClosing()
		{
			base.OnClosing();
			if (_restartSceneOnExit)
			{
				Game.Instance.SceneManager.ReloadCurrentScene();
			}
		}

		public override void OnItemsFinishedLoading()
		{
			if (_selectedModAtStartup != null)
			{
				ListViewItemScript listViewItemScript = base.ListView.Items.Where((ListViewItemScript x) => ((ModItemModel)x.Model).Mod == _selectedModAtStartup).FirstOrDefault();
				if (listViewItemScript != null)
				{
					base.ListView.SelectedItem = listViewItemScript;
					_selectedModAtStartup = null;
				}
			}
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.SetHeaderText("MODS");
			NavigationGroupScript navGroup = listView.CreateNavGroup("MODS");
			listView.CreateNavItem(navGroup, "All", "All");
			listView.CreateNavItem(navGroup, "Active", "Active");
			listView.CreateNavItem(navGroup, "Inactive", "Inactive");
		}

		public override void OnSelectButtonClicked(ListViewItemScript selectedItem)
		{
			ModItemModel modItem = selectedItem.Model as ModItemModel;
			if (modItem.PendingDisable)
			{
				return;
			}
			Action activateMod = delegate
			{
				SetModActive(modItem.Mod, !modItem.Mod.Enabled);
				_restartSceneOnExit = true;
				foreach (ListViewItemScript item in base.ListView.Items)
				{
					item.UpdateCheckmarkStyle();
				}
				base.ListView.SelectedItem = null;
				base.ListView.SelectedItem = base.ListView.Items.Where((ListViewItemScript x) => x.Model == modItem).FirstOrDefault();
			};
			if (!_acceptedModWarningThisSession && !modItem.Mod.Enabled && !modItem.Mod.IsBundledMod)
			{
				VRDialogScript vRDialogScript = VRDialogScript.CreateDialog();
				vRDialogScript.MessageText = "WARNING: Mods can execute code. This means that the author of the mod could use it for evil and damage your system. Only run a mod if you trust the author. By clicking okay, you agree that you bear this risk and Jundroo, LLC is not responsible for any damages.";
				vRDialogScript.OnOkay += delegate(VRDialogScript d)
				{
					d.Close();
					activateMod();
				};
			}
			else
			{
				activateMod();
			}
		}

		public override void UpdateDetailsPanel(ItemModel model, ListViewDetailsScript details)
		{
			details.StarButton.SetButtonStates(visible: false, selected: false);
			details.UpvoteButton.SetButtonStates(visible: false, selected: false);
			details.CurateApproveButton.SetButtonStates(visible: false, selected: false);
			details.CurateRejectButton.SetButtonStates(visible: false, selected: false);
			details.CurateResetButton.SetButtonStates(visible: false, selected: false);
			details.FavoriteButton.SetButtonStates(visible: false, selected: false);
			ModItemModel modItemModel = model as ModItemModel;
			ModItemModel modItemModel2 = model as ModItemModel;
			string selectButtonText = (modItemModel2.Active ? "DISABLE" : "ENABLE") ?? "";
			if (modItemModel2.PendingDisable)
			{
				selectButtonText = "PENDING DISABLE";
			}
			details.SetSelectButtonText(selectButtonText);
			details.SetHeaderText(modItemModel.Name + "<size=75%><color=#aaa> by " + modItemModel2.Mod.Author);
			string bodyText = modItemModel.Mod.Description + "\n\n" + $"Version: {modItemModel2.Mod.Version} \n" + $"Last Updated: {modItemModel2.Mod.LastUpdated} \n" + "Path: " + modItemModel2.Mod.Path + " \n";
			details.SetBodyText(bodyText);
			details.SetPreviewSprite(null);
		}
	}
}
