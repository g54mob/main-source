using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using OneUseScripts;
using ScriptHelpers;
using SettingScripts;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace SteamIntegrations
{
	public class WorkshopItem
	{
		public string title;

		public string desc;

		public WorkshopItemType type;

		public string version;

		public string lastChangelog;

		public long lastUpdatedUTC;

		public long lastFilePullUTC;

		public DateTime lastFilePull;

		public DateTime lastUpdated;

		public UnityEvent onInfoUpdate = new UnityEvent();

		public static SettingChoices<ERemoteStoragePublishedFileVisibility> visibilityChoices = new SettingChoices<ERemoteStoragePublishedFileVisibility>
		{
			choices = new List<SettingChoice<ERemoteStoragePublishedFileVisibility>>
			{
				new SettingChoice<ERemoteStoragePublishedFileVisibility>(ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate, "Private", "Not available to anyone else"),
				new SettingChoice<ERemoteStoragePublishedFileVisibility>(ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityUnlisted, "Unlisted", "Anyone with the link will be able to see and subscribe to this item"),
				new SettingChoice<ERemoteStoragePublishedFileVisibility>(ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityFriendsOnly, "Friends Only", "Only available to your steam friends"),
				new SettingChoice<ERemoteStoragePublishedFileVisibility>(ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic, "Public", "Item will be shown on the workshop and available to everyone")
			}
		};

		public ChoiceSetting<ERemoteStoragePublishedFileVisibility> visibility = new ChoiceSetting<ERemoteStoragePublishedFileVisibility>
		{
			choices = visibilityChoices
		};

		private string path;

		private string mainItem;

		private string sourceSharedItem;

		public readonly List<string> files = new List<string>();

		private SteamUGCDetails_t details;

		public PublishedFileId_t id;

		private UGCUpdateHandle_t updateHandle;

		public bool needUpdate;

		private bool userIsAuthor;

		private CSteamID creatorID;

		public bool isValid;

		public const string dateFormat = "yyyy-MM dd HH:mm:ss";

		public string contentPath => Path.Combine(path, "Content");

		public string itemPath => Path.Combine(contentPath, mainItem);

		public string infoPath => Path.Combine(path, "item.info");

		public string previewPath => Path.Combine(path, "preview.png");

		public UGCUpdateHandle_t itemUpdateHandle => updateHandle;

		public bool canBeModified => userIsAuthor;

		public string creatorName => SteamFriends.GetFriendPersonaName(creatorID);

		public WorkshopItem(string folderPath)
		{
			path = folderPath;
			ReadInfoFromFile();
		}

		public void ReadInfoFromFile()
		{
			try
			{
				JObject jObject = JObject.Parse(File.ReadAllText(infoPath));
				if (jObject["id"] != null)
				{
					id = new PublishedFileId_t(jObject["id"].ToObject<ulong>());
				}
				version = jObject["version"].ToString();
				title = jObject["title"].ToString();
				if (jObject["item"] != null)
				{
					mainItem = jObject["item"].ToString();
				}
				else
				{
					mainItem = Directory.EnumerateFiles(contentPath).ToList()[0];
				}
				desc = jObject["desc"].ToString();
				type = jObject["type"].ToObject<WorkshopItemType>();
				visibility.SetValue(jObject["visibility"].ToObject<ERemoteStoragePublishedFileVisibility>());
				if (jObject["lastChangelog"] != null)
				{
					lastChangelog = jObject["lastChangelog"].ToString();
				}
				if (jObject["lastUpdatedUTC"] != null)
				{
					lastUpdatedUTC = jObject["lastUpdatedUTC"].ToObject<long>();
					lastUpdated = DateTimeOffset.FromUnixTimeSeconds(lastUpdatedUTC).LocalDateTime;
				}
				else
				{
					DateTime.TryParseExact(jObject["lastUpdated"].ToString(), "yyyy-MM dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastUpdated);
					lastUpdatedUTC = ((DateTimeOffset)lastUpdated).ToUnixTimeSeconds();
				}
				if (jObject["lastFilePullUTC"] != null)
				{
					lastFilePullUTC = jObject["lastFilePullUTC"].ToObject<long>();
					lastFilePull = DateTimeOffset.FromUnixTimeSeconds(lastFilePullUTC).LocalDateTime;
				}
				else
				{
					DateTime.TryParseExact(jObject["lastFilePull"].ToString(), "yyyy-MM dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastFilePull);
					lastFilePullUTC = ((DateTimeOffset)lastFilePull).ToUnixTimeSeconds();
				}
				isValid = true;
				onInfoUpdate.Invoke();
			}
			catch (Exception)
			{
				isValid = false;
			}
		}

		public void ReUpdateAfterDownload(string folderPath)
		{
			needUpdate = false;
			path = folderPath;
			ReadInfoFromFile();
		}

		public WorkshopItem(PublishedFileId_t itemID, SteamUGCDetails_t itemDetails, WorkshopItemType itemType, string folderPath)
		{
			id = itemID;
			path = folderPath;
			title = itemDetails.m_rgchTitle;
			desc = itemDetails.m_rgchDescription;
			type = itemType;
			ReadInfoFromFile();
			SetItemDetails(itemDetails);
		}

		public WorkshopItem(PublishedFileId_t itemID, string originalPath)
		{
			id = itemID;
			sourceSharedItem = originalPath;
			userIsAuthor = true;
			path = Path.Combine(SteamWorkshopManager.workshopSharingPath, $"{id}");
			Directory.CreateDirectory(path);
			Directory.CreateDirectory(contentPath);
			StartItemUpdate();
			SetSharedFile(originalPath);
		}

		public void StartItemUpdate()
		{
			updateHandle = SteamUGC.StartItemUpdate(SteamManager.AppID, id);
			bool flag = SteamUGC.SetItemUpdateLanguage(updateHandle, "english");
			UGCUpdateHandle_t uGCUpdateHandle_t = updateHandle;
			Debug.Log("SteamUGC.SetItemUpdateLanguage(" + uGCUpdateHandle_t.ToString() + ", \"english\") : " + flag);
		}

		public void SetItemDetails(SteamUGCDetails_t ugcDetails)
		{
			details = ugcDetails;
			creatorID = new CSteamID(details.m_ulSteamIDOwner);
			userIsAuthor = details.m_ulSteamIDOwner == SteamManager.userID.m_SteamID;
			needUpdate = lastUpdatedUTC + 60 < details.m_rtimeUpdated;
		}

		public void SetSharedFile(string originalPath)
		{
			FileInfo fileInfo = new FileInfo(originalPath);
			mainItem = fileInfo.Name;
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.Name);
			try
			{
				UGCUpdateHandle_t uGCUpdateHandle_t;
				if (fileInfo.Extension == ".bb8" || fileInfo.Extension == ".bb8template")
				{
					type = WorkshopItemType.Bibite;
					BibiteTemplate bibiteTemplate = new BibiteTemplate(originalPath);
					SetTitle(bibiteTemplate.speciesName);
					SetDescription(bibiteTemplate.description);
					if (File.Exists(SteamWorkshopManager.tempImgPath))
					{
						File.Move(SteamWorkshopManager.tempImgPath, previewPath);
						bool flag = SteamUGC.SetItemPreview(updateHandle, previewPath);
						string[] obj = new string[6] { "SteamUGC.SetItemPreview(", null, null, null, null, null };
						uGCUpdateHandle_t = updateHandle;
						obj[1] = uGCUpdateHandle_t.ToString();
						obj[2] = ", ";
						obj[3] = previewPath;
						obj[4] = ") : ";
						obj[5] = flag.ToString();
						Debug.Log(string.Concat(obj));
					}
					version = bibiteTemplate.version;
				}
				else
				{
					if (!(fileInfo.Extension == ".zip"))
					{
						Debug.Log("Invalid File Type");
						return;
					}
					using ZipArchive zipArchive = ZipFile.Open(originalPath, ZipArchiveMode.Read);
					JObject infoOfScenario = SaveSystem.GetInfoOfScenario(zipArchive);
					if (infoOfScenario != null)
					{
						if (infoOfScenario["name"] != null)
						{
							SetTitle(infoOfScenario["name"].ToString());
						}
						if (infoOfScenario["desc"] != null)
						{
							desc = infoOfScenario["desc"].ToString();
						}
						if (infoOfScenario["version"] != null && Utility.Version.CanParse(infoOfScenario["version"].ToString()))
						{
							version = infoOfScenario["version"].ToString();
						}
						if (infoOfScenario["isChallenge"] != null || infoOfScenario["star1"] != null || infoOfScenario["star2"] != null)
						{
							type = WorkshopItemType.Challenge;
							if (infoOfScenario["star1"] != null)
							{
								desc = desc + "\n\n1 Star: " + infoOfScenario["star1"];
							}
							if (infoOfScenario["star2"] != null)
							{
								desc = desc + "\n2 Stars: " + infoOfScenario["star2"];
							}
							if (infoOfScenario["star3"] != null)
							{
								desc = desc + "\n3 Stars: " + infoOfScenario["star3"];
							}
						}
						else
						{
							type = WorkshopItemType.Scenario;
						}
					}
					else
					{
						JObject sceneOfSave = SaveSystem.GetSceneOfSave(zipArchive);
						if (sceneOfSave == null)
						{
							isValid = false;
							PopupManager.DisplayError("Creating Workshop Item", "The file was of an unknown type\n\nOnly Bibites, Scenarios, Challenges, and Save files can be shared for now");
							return;
						}
						try
						{
							SetTitle(fileNameWithoutExtension);
							int[] array = TimeKeeper.ParseTime(sceneOfSave["simulatedTime"].ToObject<double>());
							desc = $"Simulation Time: {array[0]:00} hours";
							desc += string.Format("\nNumber of Bibites: {0}", sceneOfSave["nBibites"].ToObject<int>());
							desc += string.Format("\nNumber of Pellets: {0}", sceneOfSave["nPellets"].ToObject<int>());
							desc += "\n\nDetails:\n";
							if (sceneOfSave["version"] != null && Utility.Version.CanParse(sceneOfSave["version"].ToString()))
							{
								version = sceneOfSave["version"].ToString();
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex);
							Debug.LogError(ex.Message);
							isValid = false;
							PopupManager.DisplayError("Creating Workshop Item", "An unexpected error occured when trying to read " + originalPath);
						}
						type = WorkshopItemType.Save;
					}
					ZipArchiveEntry zipArchiveEntry = zipArchive.Entries.FirstOrDefault((ZipArchiveEntry e) => e.FullName.EndsWith(".png", StringComparison.OrdinalIgnoreCase));
					if (zipArchiveEntry != null && (double)zipArchiveEntry.Length < 1000000.0)
					{
						byte[] array2 = SaveSystem.ReadFileFromArchive(zipArchiveEntry);
						if ((double)zipArchiveEntry.Length > 1000000.0)
						{
							int num = Mathf.CeilToInt((float)zipArchiveEntry.Length / 1000000f);
							Texture2D texture2D = new Texture2D(2, 2);
							texture2D.LoadImage(array2);
							texture2D.Reinitialize(Mathf.FloorToInt((float)texture2D.width / (float)num), Mathf.FloorToInt((float)texture2D.height / (float)num), TextureFormat.ARGB32, hasMipMap: false);
							texture2D.Apply();
							array2 = texture2D.EncodeToPNG();
						}
						if (File.Exists(previewPath))
						{
							File.Delete(previewPath);
						}
						File.WriteAllBytes(previewPath, array2);
						bool flag2 = SteamUGC.SetItemPreview(updateHandle, previewPath);
						string[] obj2 = new string[6] { "SteamUGC.SetItemPreview(", null, null, null, null, null };
						uGCUpdateHandle_t = updateHandle;
						obj2[1] = uGCUpdateHandle_t.ToString();
						obj2[2] = ", ";
						obj2[3] = previewPath;
						obj2[4] = ") : ";
						obj2[5] = flag2.ToString();
						Debug.Log(string.Concat(obj2));
					}
					else if (File.Exists(SteamWorkshopManager.tempImgPath))
					{
						File.Move(SteamWorkshopManager.tempImgPath, previewPath);
						bool flag3 = SteamUGC.SetItemPreview(updateHandle, previewPath);
						string[] obj3 = new string[6] { "SteamUGC.SetItemPreview(", null, null, null, null, null };
						uGCUpdateHandle_t = updateHandle;
						obj3[1] = uGCUpdateHandle_t.ToString();
						obj3[2] = ", ";
						obj3[3] = previewPath;
						obj3[4] = ") : ";
						obj3[5] = flag3.ToString();
						Debug.Log(string.Concat(obj3));
					}
					SetDescription(desc);
				}
				foreach (string item in Directory.EnumerateFiles(contentPath))
				{
					File.Delete(item);
				}
				string text = Path.Combine(contentPath, fileInfo.Name);
				File.Copy(originalPath, text);
				WorkshopItemType workshopItemType = type;
				if (workshopItemType == WorkshopItemType.Challenge || workshopItemType == WorkshopItemType.Save || workshopItemType == WorkshopItemType.Scenario)
				{
					using ZipArchive zip = ZipFile.Open(text, ZipArchiveMode.Update);
					SaveSystem.MoveTemplatesOfArchive(zip, contentPath);
				}
				lastFilePullUTC = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
				lastFilePull = DateTimeOffset.FromUnixTimeSeconds(lastFilePullUTC).LocalDateTime;
				bool flag4 = SteamUGC.SetItemContent(updateHandle, path);
				string[] obj4 = new string[6] { "SteamUGC.SetItemContent(", null, null, null, null, null };
				uGCUpdateHandle_t = updateHandle;
				obj4[1] = uGCUpdateHandle_t.ToString();
				obj4[2] = ", ";
				obj4[3] = path;
				obj4[4] = ") : ";
				obj4[5] = flag4.ToString();
				Debug.Log(string.Concat(obj4));
				flag4 = SteamUGC.SetItemTags(updateHandle, new List<string> { $"{type}" });
				string[] obj5 = new string[6] { "SteamUGC.SetItemTags(", null, null, null, null, null };
				uGCUpdateHandle_t = updateHandle;
				obj5[1] = uGCUpdateHandle_t.ToString();
				obj5[2] = ", new List<string>(){";
				obj5[3] = $"{type}";
				obj5[4] = "}) : ";
				obj5[5] = flag4.ToString();
				Debug.Log(string.Concat(obj5));
				SteamUGC.RemoveAllItemKeyValueTags(updateHandle);
				Debug.Log("SteamUGC.RemoveAllItemKeyValueTags(itemUpdateHandle) : " + flag4);
				flag4 = SteamUGC.AddItemKeyValueTag(updateHandle, "type", $"{type}");
				string[] obj6 = new string[6] { "SteamUGC.AddItemKeyValueTag(", null, null, null, null, null };
				uGCUpdateHandle_t = updateHandle;
				obj6[1] = uGCUpdateHandle_t.ToString();
				obj6[2] = ", \"type\"";
				obj6[3] = $", \"{type}\"";
				obj6[4] = ") : ";
				obj6[5] = flag4.ToString();
				Debug.Log(string.Concat(obj6));
				flag4 = SteamUGC.AddItemKeyValueTag(updateHandle, "version", version ?? "");
				string[] obj7 = new string[6] { "SteamUGC.AddItemKeyValueTag(", null, null, null, null, null };
				uGCUpdateHandle_t = updateHandle;
				obj7[1] = uGCUpdateHandle_t.ToString();
				obj7[2] = ", \"version\", \"";
				obj7[3] = version;
				obj7[4] = "\") : ";
				obj7[5] = flag4.ToString();
				Debug.Log(string.Concat(obj7));
				isValid = true;
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2);
				Debug.LogError(ex2.Message);
				isValid = false;
				PopupManager.DisplayError("Creating Workshop Item", "An unexpected error occured when trying to read " + originalPath);
			}
		}

		public void UpdateSharedFile(string originalPath, DateTime pullTime, string fileVersion)
		{
			FileInfo fileInfo = new FileInfo(originalPath);
			mainItem = fileInfo.Name;
			try
			{
				if (fileInfo.Extension == ".bb8" || fileInfo.Extension == ".bb8template")
				{
					if (type != WorkshopItemType.Bibite)
					{
						throw new EvaluateException(originalPath + "\n\nFile wasn't of the right type (" + type.ToString() + ")");
					}
					if (!new BibiteTemplate(originalPath).IsValid)
					{
						throw new EvaluateException(originalPath + "\n\nFile couldn't be loaded or was corrupt");
					}
				}
				else
				{
					if (!(fileInfo.Extension == ".zip"))
					{
						throw new EvaluateException(originalPath + "\n\nFile wasn't of the right type (" + type.ToString() + ")");
					}
					using ZipArchive zip = ZipFile.Open(originalPath, ZipArchiveMode.Read);
					JObject infoOfScenario = SaveSystem.GetInfoOfScenario(zip);
					if (infoOfScenario != null)
					{
						if (infoOfScenario["version"] == null || fileVersion != infoOfScenario["version"].ToString())
						{
							throw new EvaluateException(originalPath + "\n\nFile couldn't be loaded or was corrupt");
						}
						if (infoOfScenario["isChallenge"] != null)
						{
							if (type != WorkshopItemType.Challenge)
							{
								throw new EvaluateException(originalPath + "\n\nFile wasn't of the right type (" + type.ToString() + ")");
							}
						}
						else if (type != WorkshopItemType.Scenario)
						{
							throw new EvaluateException(originalPath + "\n\nFile wasn't of the right type (" + type.ToString() + ")");
						}
					}
					else
					{
						JObject sceneOfSave = SaveSystem.GetSceneOfSave(zip);
						if (sceneOfSave == null || type != WorkshopItemType.Save)
						{
							throw new EvaluateException(originalPath + "\n\nFile wasn't of the right type (" + type.ToString() + ")");
						}
						if (sceneOfSave["version"] == null || fileVersion != sceneOfSave["version"].ToString())
						{
							throw new EvaluateException(originalPath + "\n\nFile couldn't be loaded or was corrupt");
						}
					}
				}
				isValid = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				Debug.LogError(ex.Message);
				isValid = false;
				PopupManager.DisplayError("Updating Workshop Item File", "An unexpected error occured when trying to read " + originalPath);
			}
			foreach (string item in Directory.EnumerateFiles(contentPath))
			{
				File.Delete(item);
			}
			string text = Path.Combine(contentPath, fileInfo.Name);
			File.Copy(originalPath, text);
			WorkshopItemType workshopItemType = type;
			if (workshopItemType == WorkshopItemType.Challenge || workshopItemType == WorkshopItemType.Save || workshopItemType == WorkshopItemType.Scenario)
			{
				using ZipArchive zip2 = ZipFile.Open(text, ZipArchiveMode.Update);
				SaveSystem.MoveTemplatesOfArchive(zip2, contentPath);
			}
			bool flag = SteamUGC.SetItemTags(updateHandle, new List<string> { $"{type}" });
			string[] obj = new string[6] { "SteamUGC.SetItemTags(", null, null, null, null, null };
			UGCUpdateHandle_t uGCUpdateHandle_t = updateHandle;
			obj[1] = uGCUpdateHandle_t.ToString();
			obj[2] = ", new List<string>(){";
			obj[3] = $"{type}";
			obj[4] = "}) : ";
			obj[5] = flag.ToString();
			Debug.Log(string.Concat(obj));
			SteamUGC.RemoveAllItemKeyValueTags(updateHandle);
			Debug.Log("SteamUGC.RemoveAllItemKeyValueTags(itemUpdateHandle) : " + flag);
			flag = SteamUGC.AddItemKeyValueTag(updateHandle, "type", $"{type}");
			string[] obj2 = new string[6] { "SteamUGC.AddItemKeyValueTag(", null, null, null, null, null };
			uGCUpdateHandle_t = updateHandle;
			obj2[1] = uGCUpdateHandle_t.ToString();
			obj2[2] = ", \"type\"";
			obj2[3] = $", \"{type}\"";
			obj2[4] = ") : ";
			obj2[5] = flag.ToString();
			Debug.Log(string.Concat(obj2));
			flag = SteamUGC.AddItemKeyValueTag(updateHandle, "version", version ?? "");
			string[] obj3 = new string[6] { "SteamUGC.AddItemKeyValueTag(", null, null, null, null, null };
			uGCUpdateHandle_t = updateHandle;
			obj3[1] = uGCUpdateHandle_t.ToString();
			obj3[2] = ", \"version\", \"";
			obj3[3] = version;
			obj3[4] = "\") : ";
			obj3[5] = flag.ToString();
			Debug.Log(string.Concat(obj3));
			version = fileVersion;
			lastFilePullUTC = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
			lastFilePull = DateTimeOffset.FromUnixTimeSeconds(lastFilePullUTC).LocalDateTime;
		}

		public void SetPreview(string originalPath)
		{
			FileInfo fileInfo = new FileInfo(originalPath);
			if (fileInfo.Extension != ".png")
			{
				PopupManager.DisplayError("Image Upload", "Only .png files are supported.");
				return;
			}
			if ((double)fileInfo.Length > 1000000.0)
			{
				PopupManager.DisplayError("Image Upload", "The maximum preview image size is 1MB");
				return;
			}
			if (File.Exists(previewPath))
			{
				File.Delete(previewPath);
			}
			File.Copy(originalPath, previewPath);
			bool flag = SteamUGC.SetItemPreview(updateHandle, previewPath);
			string[] obj = new string[6] { "SteamUGC.SetItemPreview(", null, null, null, null, null };
			UGCUpdateHandle_t uGCUpdateHandle_t = updateHandle;
			obj[1] = uGCUpdateHandle_t.ToString();
			obj[2] = ", ";
			obj[3] = previewPath;
			obj[4] = ") : ";
			obj[5] = flag.ToString();
			Debug.Log(string.Concat(obj));
		}

		public void SetVisibility(ERemoteStoragePublishedFileVisibility itemVisibility)
		{
			visibility.SetValue(itemVisibility);
			bool flag = SteamUGC.SetItemVisibility(updateHandle, itemVisibility);
			string[] obj = new string[6] { "SteamUGC.SetItemVisibility(", null, null, null, null, null };
			UGCUpdateHandle_t uGCUpdateHandle_t = updateHandle;
			obj[1] = uGCUpdateHandle_t.ToString();
			obj[2] = ", ";
			obj[3] = $"{itemVisibility}";
			obj[4] = ") : ";
			obj[5] = flag.ToString();
			Debug.Log(string.Concat(obj));
		}

		public void SetTitle(string itemTitle)
		{
			title = itemTitle;
			SteamUGC.SetItemTitle(updateHandle, itemTitle);
		}

		public void SetDescription(string itemDesc)
		{
			desc = itemDesc;
			SteamUGC.SetItemDescription(updateHandle, itemDesc);
		}

		public bool SubmitItemUpdate(string changelog = "")
		{
			lastChangelog = changelog;
			lastUpdatedUTC = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			lastUpdated = DateTimeOffset.FromUnixTimeSeconds(lastUpdatedUTC).LocalDateTime;
			SaveInfoToFile();
			bool result = SteamUGC.SetItemContent(updateHandle, path);
			string[] obj = new string[6] { "SteamUGC.SetItemContent(", null, null, null, null, null };
			UGCUpdateHandle_t uGCUpdateHandle_t = updateHandle;
			obj[1] = uGCUpdateHandle_t.ToString();
			obj[2] = ", ";
			obj[3] = path;
			obj[4] = ") : ";
			obj[5] = result.ToString();
			Debug.Log(string.Concat(obj));
			SteamWorkshopManager.instance.SubmitItemUpdate(this, changelog);
			return result;
		}

		public float GetUpdateProgress()
		{
			ulong punBytesProcessed;
			ulong punBytesTotal;
			return SteamUGC.GetItemUpdateProgress(updateHandle, out punBytesProcessed, out punBytesTotal) switch
			{
				EItemUpdateStatus.k_EItemUpdateStatusPreparingConfig => 0.1f, 
				EItemUpdateStatus.k_EItemUpdateStatusPreparingContent => 0.2f, 
				EItemUpdateStatus.k_EItemUpdateStatusCommittingChanges => 0.95f, 
				EItemUpdateStatus.k_EItemUpdateStatusInvalid => 1f, 
				_ => 0.2f + 0.7f * ((punBytesTotal == 0L) ? 1f : ((float)punBytesProcessed / (float)punBytesTotal)), 
			};
		}

		public bool LoadPreviewToTex(Texture2D tex)
		{
			return tex.LoadImageIntoTexture(previewPath);
		}

		public void SaveInfoToFile()
		{
			JObject jObject = new JObject();
			jObject["item"] = mainItem;
			jObject["title"] = title;
			jObject["desc"] = desc;
			jObject["version"] = version;
			jObject["id"] = id.ToString();
			jObject["type"] = type.ToString();
			jObject["visibility"] = visibility.val.ToString();
			jObject["lastUpdatedUTC"] = lastUpdatedUTC;
			jObject["lastFilePullUTC"] = lastFilePullUTC;
			if (!string.IsNullOrEmpty(lastChangelog))
			{
				jObject["lastChangelog"] = lastChangelog;
			}
			File.WriteAllText(infoPath, jObject.ToString());
		}

		public void Delete()
		{
			if (Directory.Exists(path))
			{
				new DirectoryInfo(path).Delete(recursive: true);
			}
		}
	}
}
