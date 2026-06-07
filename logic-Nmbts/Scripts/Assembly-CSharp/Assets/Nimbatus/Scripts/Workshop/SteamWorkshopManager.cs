using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.Nimbatus.Scripts.Leaderboards;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Workshop
{
	public class SteamWorkshopManager : SerializableMonobehaviour<SteamWorkshopManager, SteamWorkshopSaveData>
	{
		public bool LastUploadStatus;

		private bool _initialized;

		internal override string Filename
		{
			get
			{
				return "WorkshopSettings.xml";
			}
		}

		protected override void LoadFromFile(SteamWorkshopSaveData data)
		{
		}

		protected override SteamWorkshopSaveData SaveToFile()
		{
			return new SteamWorkshopSaveData();
		}

		public IEnumerator UploadDrone(DroneData drone, CreateWorkshopItemInformation information)
		{
			LastUploadStatus = false;
			if (!SteamManager.Initialized)
			{
				yield break;
			}
			if (information.Id != PublishedFileId_t.Invalid)
			{
				yield return StartCoroutine(UploadFile(information.Id, drone, information));
				yield break;
			}
			SteamCallbackCoroutine<CreateItemResult_t> createItemCall = new SteamCallbackCoroutine<CreateItemResult_t>();
			SteamAPICall_t handle = SteamUGC.CreateItem(SteamManager.MainAppId, EWorkshopFileType.k_EWorkshopFileTypeFirst);
			yield return StartCoroutine(createItemCall.Start(handle, 15f));
			if (createItemCall.HasResult)
			{
				if (createItemCall.Result.m_eResult != EResult.k_EResultOK)
				{
					Debug.Log(createItemCall.Result.m_eResult);
				}
				PublishedFileId_t nPublishedFileId = createItemCall.Result.m_nPublishedFileId;
				if (createItemCall.Result.m_bUserNeedsToAcceptWorkshopLegalAgreement)
				{
					SteamFriends.ActivateGameOverlayToWebPage("steam://url/CommunityFilePage/" + nPublishedFileId);
				}
				yield return StartCoroutine(UploadFile(nPublishedFileId, drone, information));
			}
		}

		private IEnumerator UploadFile(PublishedFileId_t fileId, DroneData drone, CreateWorkshopItemInformation information)
		{
			string folderPath = Path.Combine(GetWorkshopFolderPath(), fileId.ToString());
			if (Directory.Exists(folderPath))
			{
				Directory.Delete(folderPath, true);
			}
			Directory.CreateDirectory(folderPath);
			UGCUpdateHandle_t uGCUpdateHandle_t = SteamUGC.StartItemUpdate(SteamManager.MainAppId, fileId);
			SteamUGC.SetItemTitle(uGCUpdateHandle_t, information.Title);
			SteamUGC.SetItemDescription(uGCUpdateHandle_t, information.Description);
			SteamUGC.SetItemUpdateLanguage(uGCUpdateHandle_t, information.Language);
			SteamUGC.SetItemVisibility(uGCUpdateHandle_t, ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic);
			SteamUGC.SetItemTags(uGCUpdateHandle_t, new List<string>
			{
				"Drone",
				information.Tag.ToString()
			});
			if (drone != null)
			{
				drone.DroneName = information.Title;
				drone.Description = information.Description;
				string fileName = Path.Combine(folderPath, "Drone.drn");
				drone.Save(fileName);
				string text = Path.Combine(folderPath, "Image.png");
				drone.SaveImage(text);
				SteamUGC.SetItemMetadata(uGCUpdateHandle_t, drone.Version);
				SteamUGC.SetItemContent(uGCUpdateHandle_t, folderPath);
				SteamUGC.SetItemPreview(uGCUpdateHandle_t, text);
			}
			SteamCallbackCoroutine<SubmitItemUpdateResult_t> submitItemCall = new SteamCallbackCoroutine<SubmitItemUpdateResult_t>();
			SteamAPICall_t handle = SteamUGC.SubmitItemUpdate(uGCUpdateHandle_t, information.ChangeNote);
			yield return StartCoroutine(submitItemCall.Start(handle, 30f));
			if (submitItemCall.HasResult)
			{
				if (submitItemCall.Result.m_eResult != EResult.k_EResultOK)
				{
					Debug.Log(submitItemCall.Result.m_eResult);
				}
				LastUploadStatus = true;
			}
			Directory.Delete(folderPath, true);
		}

		public static string GetWorkshopFolderPath()
		{
			return Application.persistentDataPath + "/Workshop";
		}
	}
}
