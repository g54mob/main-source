using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using SteamIntegrations;
using TMPro;
using UnityEngine;
using Utility;

namespace UIScripts.UIReferences
{
	public class SaveItemReference : PoolableItem<SaveItemReference>
	{
		[NonSerialized]
		public FileInfo info;

		[SerializeField]
		private TextMeshProUGUI saveName;

		[SerializeField]
		private TextMeshProUGUI saveDate;

		[SerializeField]
		private GameObject workshopIcon;

		[SerializeField]
		private TooltipTrigger workshopTooltip;

		private IUsingSaveItem user;

		private JObject scene;

		private bool isWorkshopItem;

		public WorkshopItem item;

		public DateTime lastWriteTime;

		public override void WakeUp()
		{
			base.WakeUp();
			base.transform.SetAsLastSibling();
		}

		public override void Retire()
		{
			base.Retire();
			item = null;
			isWorkshopItem = false;
		}

		public bool InitSaveItemAsExternal(FileInfo file, IUsingSaveItem userOfSaveItem, WorkshopItem relatedItem)
		{
			isWorkshopItem = true;
			item = relatedItem;
			return InitSaveItem(file, userOfSaveItem);
		}

		public bool InitSaveItem(FileInfo file, IUsingSaveItem userOfSaveItem)
		{
			info = file;
			user = userOfSaveItem;
			saveName.text = Path.GetFileNameWithoutExtension(info.Name);
			bool result;
			try
			{
				using ZipArchive zip = ZipFile.Open(file.FullName, ZipArchiveMode.Read);
				scene = SaveSystem.GetSceneOfSave(zip);
				result = scene?["version"] != null;
			}
			catch (Exception ex)
			{
				result = false;
				Console.WriteLine(ex);
				PopupManager.DisplayError("Corrupted Save", "A corrupted save was found and couldn't ne displayed:\n" + file.FullName + "\nDelete the file to stop this problem, or even better: Share it with the dev team\n\n" + string.Join("\n", ex.ToString().Split("\n").Take(1)));
			}
			saveDate.text = info.LastWriteTime.ToString("dd/MM/yyyy HH:mm");
			workshopIcon.SetActive(isWorkshopItem);
			if (isWorkshopItem)
			{
				workshopTooltip.UpdateText(null, "This save comes from one of the workshop items you subscribe to:\n" + item.title + " by " + item.creatorName);
			}
			return result;
		}

		public void SelectSave()
		{
			user.SelectSaveItem(this);
		}
	}
}
