using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ManagementScripts;
using ScriptHelpers;
using StandaloneFileBrowser;
using Steamworks;
using TMPro;
using UIScripts;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace SteamIntegrations
{
	public class WorkshopItemsPanel : UIPanel
	{
		public static WorkshopItemsPanel instance;

		private SteamWorkshopManager manager;

		[Header("GameObject References")]
		[SerializeField]
		private GameObject workshopItemPrefab;

		[SerializeField]
		private Transform subscribedHolder;

		[SerializeField]
		private Transform sharedHolder;

		[SerializeField]
		private GameObject noSubscribedDisclaimer;

		[SerializeField]
		private GameObject noSharedDisclaimer;

		[SerializeField]
		private EditSharedItemPanel editSharedPanel;

		[Header("Preview Ref")]
		[SerializeField]
		private RawImage preview;

		[SerializeField]
		private Texture defaultPreview;

		[SerializeField]
		private GameObject noPreviewDisclaimer;

		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private TextMeshProUGUI description;

		[SerializeField]
		private TextMeshProUGUI visibility;

		[SerializeField]
		private TextMeshProUGUI type;

		[SerializeField]
		private Image typeIcon;

		[SerializeField]
		private TextMeshProUGUI version;

		[SerializeField]
		private TextMeshProUGUI creatorName;

		[SerializeField]
		private TextMeshProUGUI lastUpdateButton;

		[SerializeField]
		private TooltipTrigger lastUpdateTooltip;

		[SerializeField]
		private GameObject selectedPanel;

		[SerializeField]
		private GameObject selectedPlaceHolder;

		[SerializeField]
		private GameObject updateItemButton;

		[SerializeField]
		private List<GameObject> showOnShared = new List<GameObject>();

		[SerializeField]
		private List<GameObject> showOnSubscribed = new List<GameObject>();

		private Texture2D tex;

		private ItemDictPool<WorkshopItem, WorkshopItemReference> subscribedItems;

		private ItemDictPool<WorkshopItem, WorkshopItemReference> sharedItems;

		private readonly Dictionary<WorkshopItem, WorkshopItemReference> allItems = new Dictionary<WorkshopItem, WorkshopItemReference>();

		private WorkshopItemReference selectedItem;

		public override void InitPanel()
		{
			base.InitPanel();
			manager = SteamWorkshopManager.instance;
			manager.onWorkshopItemCreated.AddListener(OnNewItemCreated);
			manager.onWorkshopItemSubmitResult.AddListener(OnItemUpdateSubmitResult);
			manager.onWorkshopItemDestroyed.AddListener(OnNewItemDestroyed);
			manager.onWorkshopItemUnSubscribed.AddListener(UnsubscribedFromItemSuccessful);
			manager.onWorkshopItemUpdated.AddListener(OnSelectedItemDownloaded);
			instance = this;
			tex = new Texture2D(400, 400);
			subscribedItems = new ItemDictPool<WorkshopItem, WorkshopItemReference>(workshopItemPrefab, subscribedHolder);
			sharedItems = new ItemDictPool<WorkshopItem, WorkshopItemReference>(workshopItemPrefab, sharedHolder);
		}

		public void OpenPanelWithItemSelected(WorkshopItem toSelect)
		{
			if (!SteamManager.Initialized)
			{
				ClosePanel();
				return;
			}
			OpenPanel();
			Select(allItems[toSelect]);
		}

		public override void OpenPanel()
		{
			if (!SteamManager.Initialized)
			{
				ClosePanel();
				return;
			}
			base.OpenPanel();
			editSharedPanel.ClosePanel();
			Select(null);
			allItems.Clear();
			foreach (WorkshopItem subscribedItem in manager.subscribedItems)
			{
				allItems.Add(subscribedItem, subscribedItems[subscribedItem]);
			}
			noSubscribedDisclaimer.SetActive(manager.subscribedItems.Count < 1);
			foreach (WorkshopItem sharedItem in manager.sharedItems)
			{
				allItems.Add(sharedItem, sharedItems[sharedItem]);
			}
			noSharedDisclaimer.SetActive(manager.sharedItems.Count < 1);
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			if (selectedItem != null)
			{
				selectedItem.Select(select: false);
				selectedItem = null;
			}
		}

		public void Select(WorkshopItemReference toSelect)
		{
			if (selectedItem != null)
			{
				selectedItem.Select(select: false);
			}
			selectedItem = toSelect;
			selectedPanel.SetActive(selectedItem != null);
			selectedPlaceHolder.SetActive(selectedItem == null);
			if (!(selectedItem == null))
			{
				selectedItem.Select(select: true);
				bool flag = toSelect.item.LoadPreviewToTex(tex);
				if (flag)
				{
					preview.FitTexture(tex, FitType.Fill);
				}
				else
				{
					preview.texture = defaultPreview;
				}
				noPreviewDisclaimer.SetActive(!flag);
				WorkshopItem item = toSelect.item;
				title.text = item.title;
				description.text = item.desc;
				version.text = item.version;
				type.text = item.type.ToString();
				typeIcon.sprite = selectedItem.typeIcon.sprite;
				creatorName.text = item.creatorName;
				visibility.text = item.visibility.valLabel;
				lastUpdateButton.text = item.lastUpdated.ToString("yyyy-MM dd HH:mm:ss");
				lastUpdateTooltip.UpdateText(lastUpdateButton.text, item.lastChangelog);
				bool shared = item.canBeModified;
				showOnShared.ForEach(delegate(GameObject g)
				{
					g.SetActive(shared);
				});
				showOnSubscribed.ForEach(delegate(GameObject g)
				{
					g.SetActive(!shared);
				});
				if (shared)
				{
					updateItemButton.SetActive(value: false);
					return;
				}
				creatorName.text = item.creatorName;
				updateItemButton.SetActive(item.needUpdate);
			}
		}

		public void ShareNewItem()
		{
			ExtensionFilter[] extensions = new ExtensionFilter[1]
			{
				new ExtensionFilter("shareable files", "bb8", "bb8template", "zip")
			};
			global::StandaloneFileBrowser.StandaloneFileBrowser.OpenFilePanelAsync("Select file to share", Application.persistentDataPath, extensions, multiselect: false, OnNewShareSubmit);
		}

		public void ShareNewItemFromPath(string path)
		{
			path = path.Replace('/', Path.DirectorySeparatorChar);
			if (path.StartsWith(Application.persistentDataPath.Replace('/', Path.DirectorySeparatorChar), StringComparison.InvariantCulture))
			{
				manager.RequestCreateItem(path);
			}
		}

		private void OnNewShareSubmit(string[] files)
		{
			if (files == null || files.Length < 1)
			{
				return;
			}
			string text = files[0];
			if (!text.StartsWith(Application.persistentDataPath.Replace('/', Path.DirectorySeparatorChar), StringComparison.InvariantCulture))
			{
				PopupManager.DisplayError("Invalid File", "Shared Files Have to be selected from the persistent data path folder and its subfolders: \n" + Application.persistentDataPath + "\n\nAnd you can only share files that have been generated by the game (bibites, saves, scenario, or challenges)");
				return;
			}
			string value = text.Replace(Application.persistentDataPath.Replace('/', Path.DirectorySeparatorChar), "").Remove(0, 1);
			if (manager.sourceFiles.ContainsValue(value))
			{
				PopupManager.DisplayError("File is already shared through another item", "The same file can only be shared through one item");
			}
			else
			{
				manager.RequestCreateItem(files[0]);
			}
		}

		private void OnNewItemCreated(WorkshopItem item)
		{
			if (!base.gameObject.activeSelf)
			{
				OpenPanel();
			}
			editSharedPanel.OpenForItem(item, isNewItem: true);
		}

		private void OnItemUpdateSubmitResult(EResult res, WorkshopItem item)
		{
			if (res == EResult.k_EResultOK && item != null)
			{
				bool num = sharedItems.HasItemWithKey(item);
				WorkshopItemReference itemWithKey = sharedItems.GetItemWithKey(item);
				if (num)
				{
					itemWithKey.AssignKey(item);
				}
				Select(itemWithKey);
				noSharedDisclaimer.SetActive(value: false);
			}
		}

		private void OnNewItemDestroyed(PublishedFileId_t removedID)
		{
			WorkshopItem workshopItem = sharedItems.activeKeys.FirstOrDefault((WorkshopItem i) => i.id == removedID);
			if (workshopItem != null)
			{
				sharedItems.RetireItemWithKey(workshopItem);
				workshopItem.Delete();
			}
			noSharedDisclaimer.SetActive(sharedItems.activeCount < 1);
			Select(null);
		}

		public void EditSelectedSharedItem()
		{
			editSharedPanel.OpenForItem(selectedItem.item, isNewItem: false);
		}

		public void UnSubscribeFromSelectedItem()
		{
			if (!(selectedItem == null))
			{
				manager.RequestUnsubscribe(selectedItem.item);
			}
		}

		protected void UnsubscribedFromItemSuccessful(WorkshopItem item)
		{
			subscribedItems.RetireItemWithKey(item);
			allItems.Remove(item);
			Select(null);
		}

		public void RequestDownloadForSelectedItem()
		{
			if (!(selectedItem == null))
			{
				manager.RequestDownloadItem(selectedItem.item.id);
				updateItemButton.SetActive(value: false);
			}
		}

		protected void OnSelectedItemDownloaded(WorkshopItem item)
		{
			if (selectedItem != null && selectedItem.item == item)
			{
				Select(selectedItem);
			}
		}

		public void OpenSteamWorkshop()
		{
			Application.OpenURL("https://steamcommunity.com/app/2736860/workshop/");
		}

		public void OpenWorkshopPageOfSelectedItem()
		{
			if (!(selectedItem == null))
			{
				Application.OpenURL($"https://steamcommunity.com/sharedfiles/filedetails/?id={selectedItem.item.id}");
			}
		}

		private void OnDestroy()
		{
			manager.onWorkshopItemCreated.RemoveListener(OnNewItemCreated);
			manager.onWorkshopItemSubmitResult.RemoveListener(OnItemUpdateSubmitResult);
			manager.onWorkshopItemDestroyed.RemoveListener(OnNewItemDestroyed);
			manager.onWorkshopItemUnSubscribed.RemoveListener(UnsubscribedFromItemSuccessful);
			manager.onWorkshopItemUpdated.RemoveListener(OnSelectedItemDownloaded);
			UnityEngine.Object.Destroy(tex);
		}
	}
}
