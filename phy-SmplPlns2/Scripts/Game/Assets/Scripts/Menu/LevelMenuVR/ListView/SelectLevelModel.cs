using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Levels;
using Assets.Scripts.Mods;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class SelectLevelModel : ListViewModel
	{
		public class LevelItemModel : ItemModel
		{
			public string Body { get; set; }

			public string DisplayName { get; set; }

			public string Header { get; set; }

			public string Id { get; private set; }

			public LevelInfo LevelInfo { get; }

			public string Mode { get; set; }

			public bool RequiresOpponent { get; set; }

			public StartLocationData StartingLocation { get; }

			public LevelItemModel(string id, LevelInfo levelInfo, StartLocationData location = null)
				: base(levelInfo.Name)
			{
				Id = id;
				LevelInfo = levelInfo;
				StartingLocation = location;
			}
		}

		private const string NavGroupNameLevelMods = "Level Mods";

		private const string NavGroupNameMapMods = "Map Mods";

		private const string SandboxModeId = "Sandbox";

		private const string SandboxModeName = "Sandbox";

		private string _autoSelectName;

		private VRDialogScript _dialog;

		private string _initiallySelectedId;

		private LevelMenuVRScript _levelMenu;

		private int _lockedLocationAttemptCount;

		public static LevelItemModel DefaultLevelItem { get; private set; }

		public static List<LevelItemModel> LevelItems { get; private set; }

		public event Action<LevelItemModel> LevelSelected;

		public SelectLevelModel(LevelMenuVRScript levelMenu, string selectedId)
		{
			_levelMenu = levelMenu;
			_initiallySelectedId = selectedId;
		}

		public static void LoadLevelItems()
		{
			throw new NotImplementedException();
		}

		public override IEnumerator LoadItems(List<ItemModel> items)
		{
			IEnumerable<LevelItemModel> enumerable = null;
			object userData = base.ListView.SelectedNavItem.UserData;
			ModInfo mod = userData as ModInfo;
			if (mod != null)
			{
				string name = base.ListView.SelectedNavItem.NavGroup.Name;
				if (name == "Map Mods")
				{
					enumerable = (from x in LevelItems
						where x.LevelInfo.ModName == mod.Name && x.LevelInfo.IsSandbox
						orderby x.LevelInfo.Name
						select x).ToList();
				}
				else if (name == "Level Mods")
				{
					enumerable = (from x in LevelItems
						where x.LevelInfo.ModName == mod.Name && !x.LevelInfo.IsSandbox
						orderby x.LevelInfo.Name
						select x).ToList();
				}
			}
			else
			{
				string mode = userData as string;
				enumerable = LevelItems.Where((LevelItemModel x) => x.Mode == mode).ToList();
			}
			if (enumerable != null)
			{
				items.AddRange(enumerable);
			}
			yield return null;
		}

		public override void OnItemsFinishedLoading()
		{
			if (!string.IsNullOrWhiteSpace(_autoSelectName))
			{
				ListViewItemScript selectedItem = base.ListView.Items.Where((ListViewItemScript x) => x.Name == _autoSelectName).FirstOrDefault();
				base.ListView.SelectedItem = selectedItem;
				_autoSelectName = null;
			}
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.SetHeaderText("SELECT SCENARIO");
			NavigationGroupScript navigationGroupScript = listView.CreateNavGroup("SCENARIO");
			listView.CreateNavItem(navigationGroupScript, "Sandbox", "Sandbox");
			listView.CreateNavItem(navigationGroupScript, "Combat", "Combat");
			listView.CreateNavItem(navigationGroupScript, "Races", "Races");
			listView.CreateNavItem(navigationGroupScript, "Challenges", "Challenges");
			IModManager modManager = Game.Instance.ModManager;
			NavigationGroupScript navigationGroupScript2 = null;
			List<ModInfo> list = modManager.SandboxMaps.Select((MapInfo x) => x.Mod).Distinct().ToList();
			if (list.Count > 0)
			{
				navigationGroupScript2 = listView.CreateNavGroup("Map Mods");
				foreach (ModInfo item in list.OrderBy((ModInfo x) => x.Name))
				{
					listView.CreateNavItem(navigationGroupScript2, item.Name, item);
				}
			}
			NavigationGroupScript navigationGroupScript3 = null;
			List<ModInfo> list2 = modManager.Levels.Select((ModLevelInfo x) => x.Mod).Distinct().ToList();
			if (list2.Count > 0)
			{
				navigationGroupScript3 = listView.CreateNavGroup("Level Mods");
				foreach (ModInfo item2 in list2.OrderBy((ModInfo x) => x.Name))
				{
					listView.CreateNavItem(navigationGroupScript3, item2.Name, item2);
				}
			}
			LevelItemModel selectedItem = LevelItems.Where((LevelItemModel x) => x.Id == _initiallySelectedId).FirstOrDefault();
			if (selectedItem != null)
			{
				NavigationItemScript navigationItemScript = null;
				navigationItemScript = ((selectedItem.LevelInfo.ModName == null) ? navigationGroupScript.NavigationItems.Where((NavigationItemScript x) => x.UserData as string == selectedItem.Mode).FirstOrDefault() : (selectedItem.LevelInfo.IsSandbox ? navigationGroupScript2 : navigationGroupScript3).NavigationItems.Where((NavigationItemScript x) => (x.UserData as ModInfo)?.Name == selectedItem.LevelInfo.ModName).FirstOrDefault());
				if (navigationItemScript != null)
				{
					_autoSelectName = selectedItem.Name;
					listView.SelectedNavItem = navigationItemScript;
				}
			}
		}

		public override void OnSelectButtonClicked(ListViewItemScript selectedItem)
		{
			if (!selectedItem.Model.IsLocked)
			{
				this.LevelSelected?.Invoke(selectedItem.Model as LevelItemModel);
				base.ListView.Close();
				return;
			}
			Vector3 localPosition = new Vector3(0f, 0f, -100f);
			if (_dialog != null)
			{
				_dialog.Close();
			}
			if (++_lockedLocationAttemptCount >= 20)
			{
				Game.Instance.Settings.Cloud.Locations.UnlockAllDiscoverableLocations();
				_dialog = VRDialogScript.CreateDialog(showOkay: true, showCancel: false);
				_dialog.MessageText = "You win! All locations are now unlocked...";
				_dialog.transform.localPosition = localPosition;
				base.ListView.Close();
				_dialog.OnOkay += delegate
				{
					Game.Instance.SceneManager.LoadMenu();
					_dialog.Close();
					_dialog = null;
				};
			}
			else
			{
				_dialog = VRDialogScript.CreateDialog(showOkay: true, showCancel: false);
				_dialog.MessageText = "This location hasn't been discovered...yet!\n\nSimplePlanes has a large, seamless world to explore with no loading screens in between.  Start from one of the available locations and fly around to discover the other islands.\n\nWhen you spot one of the other large islands, make sure to fly there and unlock all the locations each island has to offer!";
				_dialog.transform.localPosition = localPosition;
				_dialog.OnOkay += delegate
				{
					_dialog.Close();
					_dialog = null;
				};
			}
		}

		public override void UpdateDetailsPanel(ItemModel model, ListViewDetailsScript details)
		{
			throw new NotImplementedException();
		}
	}
}
