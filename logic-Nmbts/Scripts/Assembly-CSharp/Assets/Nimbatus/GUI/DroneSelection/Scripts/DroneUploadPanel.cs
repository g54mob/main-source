using System;
using System.Collections;
using System.Linq;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts;
using Assets.Nimbatus.GUI.SteamWorkshop.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.Workshop;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DroneUploadPanel : MonoBehaviour
	{
		public UIInput Title;

		public UIInput Description;

		public EnumChooser DroneTypeChooser;

		public DroneUploadButton UploadButton;

		public CancelUpload CancelButton;

		public UITexture DroneImage;

		public GameObject LoadingPanel;

		public UILabel UploadStatusLabel;

		public ShowLocalDrones ShowLocalDronesButton;

		private DroneData _data;

		private DroneSelectionManager _selectionManager;

		private DroneBrowserManager _browserManager;

		private WorkshopItemResult _workshopItem;

		public void Init(DroneSelectionManager manager, DroneData item)
		{
			_selectionManager = manager;
			_data = item;
			UploadButton.Init(this);
			CancelButton.Init(this);
			DroneTypeChooser.Init<EWorkshopTag>(EWorkshopTag.Battle);
			Title.value = item.DroneName;
			Description.value = item.Description;
			DroneImage.mainTexture = item.Image;
			if (DroneImage.mainTexture != null)
			{
				DroneImage.mainTexture.wrapMode = TextureWrapMode.Clamp;
			}
		}

		public void Init(DroneBrowserManager manager, WorkshopItemResult item)
		{
			_browserManager = manager;
			_workshopItem = item;
			UploadButton.Init(this);
			CancelButton.Init(this);
			ShowLocalDronesButton.Init(this);
			EWorkshopTag result;
			if (!Enum.TryParse<EWorkshopTag>(item.Tags.FirstOrDefault(), out result))
			{
				result = EWorkshopTag.Battle;
			}
			DroneTypeChooser.Init<EWorkshopTag>(result);
			Title.value = item.Title;
			Description.value = item.Description;
			DroneImage.mainTexture = item.PreviewImage;
			if (DroneImage.mainTexture != null)
			{
				DroneImage.mainTexture.wrapMode = TextureWrapMode.Clamp;
			}
		}

		public void Update()
		{
			if (ShowLocalDronesButton != null && ShowLocalDronesButton.SelectedDroneData != null)
			{
				DroneImage.mainTexture = ShowLocalDronesButton.SelectedDroneData.Image;
			}
			else if (_workshopItem != null)
			{
				DroneImage.mainTexture = _workshopItem.PreviewImage;
			}
		}

		public void UploadDrone()
		{
			BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.OpenSource);
			CreateWorkshopItemInformation droneInfo = new CreateWorkshopItemInformation
			{
				Id = ((_workshopItem == null) ? PublishedFileId_t.Invalid : _workshopItem.FileId),
				ChangeNote = "",
				Description = Description.value,
				Title = Title.value,
				Language = "en",
				Tag = (EWorkshopTag)(object)DroneTypeChooser.SelectedOption
			};
			StartCoroutine(Upload(droneInfo));
		}

		public void UpdateFromDrone(DroneData item)
		{
			DroneImage.mainTexture = item.Image;
			if (DroneImage.mainTexture != null)
			{
				DroneImage.mainTexture.wrapMode = TextureWrapMode.Clamp;
			}
		}

		public IEnumerator Upload(CreateWorkshopItemInformation droneInfo)
		{
			LoadingPanel.SetActive(true);
			UploadStatusLabel.text = "Uploading...";
			if (ShowLocalDronesButton != null)
			{
				_data = ShowLocalDronesButton.SelectedDroneData;
			}
			yield return StartCoroutine(SerializableMonobehaviour<SteamWorkshopManager, SteamWorkshopSaveData>.Instance.UploadDrone(_data, droneInfo));
			if (SerializableMonobehaviour<SteamWorkshopManager, SteamWorkshopSaveData>.Instance.LastUploadStatus)
			{
				UploadStatusLabel.text = "Upload complete";
				yield return new WaitForSeconds(0.5f);
				LoadingPanel.SetActive(false);
				DroneSelectionManager selectionManager = _selectionManager;
				if ((object)selectionManager != null)
				{
					selectionManager.HideDroneUploadPanel();
				}
				DroneBrowserManager browserManager = _browserManager;
				if ((object)browserManager != null)
				{
					browserManager.HideDroneUploadPanel(true);
				}
			}
			else
			{
				UploadStatusLabel.text = "Upload failed";
				yield return new WaitForSeconds(0.5f);
				LoadingPanel.SetActive(false);
				DroneSelectionManager selectionManager2 = _selectionManager;
				if ((object)selectionManager2 != null)
				{
					selectionManager2.HideDroneUploadPanel();
				}
				DroneBrowserManager browserManager2 = _browserManager;
				if ((object)browserManager2 != null)
				{
					browserManager2.HideDroneUploadPanel(false);
				}
			}
		}

		public void CancelUpload()
		{
			DroneSelectionManager selectionManager = _selectionManager;
			if ((object)selectionManager != null)
			{
				selectionManager.HideDroneUploadPanel();
			}
			DroneBrowserManager browserManager = _browserManager;
			if ((object)browserManager != null)
			{
				browserManager.HideDroneUploadPanel(false);
			}
		}
	}
}
