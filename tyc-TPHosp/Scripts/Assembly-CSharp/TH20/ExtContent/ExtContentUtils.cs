using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using FullInspector;
using FullSerializerSave;
using UnityEngine;

namespace TH20.ExtContent
{
	public static class ExtContentUtils
	{
		public const uint cMaxItemTagKeyAndValueLen = 64u;

		public const uint cMaxFolderSpecLen = 1024u;

		public const string cFolderDelimiter = "/";

		public const string cTagKey_ContentType = "ContentType";

		public const string cTagKey_Version = "AssetVersion";

		public const long cInfoFileMinLength = 8L;

		public const long cInfoFileMaxLength = 131072L;

		public const float cApproxValue = 0.0001f;

		private static ExtContentManager _extContentManager;

		public static string cRefDateTimeString = "01/01/2018 00:00:00";

		public static DateTime cRefDateTime = DateTime.Parse(cRefDateTimeString);

		public static ExtContentManager ExtContentManager
		{
			get
			{
				return _extContentManager;
			}
			set
			{
				_extContentManager = value;
			}
		}

		public static ExtContentTextureUtils.ExtContentTexturesConfig TexturesConfig => _extContentManager.Config.ExtContentTexturesConfig.Instance;

		public static bool IsTagsContentTypeValid(Dictionary<string, string> tags)
		{
			return ExtContentType.IsValid(GetContentTypeTagValue(tags));
		}

		public static string GetContentTypeTagValueString(Dictionary<string, string> tags)
		{
			return GetTagValue(tags, "ContentType");
		}

		public static EContentType GetContentTypeTagValue(Dictionary<string, string> tags)
		{
			return ExtContentType.StringToContentType(GetContentTypeTagValueString(tags));
		}

		public static string GetTagValue(Dictionary<string, string> tags, string key)
		{
			string result = string.Empty;
			string value = string.Empty;
			if (tags.TryGetValue(key, out value))
			{
				result = value;
			}
			return result;
		}

		public static string HiliteParams(string paramString, bool bForce = false)
		{
			string text = paramString;
			if (bForce)
			{
				int num = 0;
				while (true)
				{
					string text2 = "{" + num + "}";
					if (!text.Contains(text2))
					{
						break;
					}
					string newValue = Hilite(text2, bForce);
					text = text.Replace(text2, newValue);
					num++;
				}
			}
			return text;
		}

		public static string HiliteParamsF(string paramString)
		{
			return HiliteParams(paramString, bForce: true);
		}

		public static string Hilite(int value, bool bForce = false)
		{
			return Hilite(value.ToString(), bForce);
		}

		public static string Hilite(string value, bool bForce = false)
		{
			if (bForce)
			{
				return "<b><color=#FFFFFF>" + value + "</color></b>";
			}
			return value;
		}

		public static bool WriteJSONFile(string folderPathSpec, string jsonFileName, Dictionary<string, string> values)
		{
			bool flag = false;
			bool flag2 = false;
			if (!folderPathSpec.IsNullOrEmpty())
			{
				if (values.Count > 0)
				{
					new fsSerializer().TrySerialize(values, out var data);
					string text = fsJsonPrinter.PrettyJson(data);
					if (!text.IsNullOrEmpty())
					{
						string pathSpec = GetPathSpec(folderPathSpec, jsonFileName);
						try
						{
							File.WriteAllText(pathSpec, text);
							flag = true;
							ExtContentMessages.LogDebug(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyWroteJSONFile), pathSpec, values.Count));
						}
						catch (Exception ex)
						{
							ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.JSONFileWriteErrorWriteException), pathSpec, ex.ToString()));
						}
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.JSONFileWriteErrorGeneratedEmptyJSON)));
					}
				}
				else
				{
					flag2 = true;
				}
			}
			else
			{
				flag2 = true;
			}
			if (!flag && flag2)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.JSONFileWriteErrorGeneral), folderPathSpec, jsonFileName, values.Count));
			}
			return flag;
		}

		public static bool ReadJSONFile(string folderPathSpec, string jsonFileName, ref Dictionary<string, string> values)
		{
			bool result = false;
			if (!folderPathSpec.IsNullOrEmpty() && !jsonFileName.IsNullOrEmpty())
			{
				string pathSpec = GetPathSpec(folderPathSpec, jsonFileName);
				if (File.Exists(pathSpec))
				{
					long length = new FileInfo(pathSpec).Length;
					if (length >= 8 && length <= 131072)
					{
						try
						{
							string text = File.ReadAllText(pathSpec);
							if (!text.IsNullOrEmpty())
							{
								if (values == null)
								{
									values = new Dictionary<string, string>();
								}
								fsData data = fsJsonParser.Parse(text);
								new fsSerializer().TryDeserialize(data, ref values);
								result = true;
							}
							else
							{
								ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopMetaDataFileReadErrorReadingJSON), pathSpec));
							}
						}
						catch (Exception ex)
						{
							ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.JSONFileReadErrorReadException), pathSpec, ex.ToString()));
						}
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopMetaDataFileReadErrorInvalidFileSize), pathSpec, length, 8L, 131072L));
					}
				}
				else
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.JSONFileDoesNotExist), pathSpec));
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.JSONFileReadErrorInvalidFolder)));
			}
			return result;
		}

		public static bool DeleteInvalidFiles(string folderSpec, List<string> validRelFileSpecs, List<string> validFileExtensions)
		{
			bool result = true;
			string[] files = Directory.GetFiles(folderSpec, "*", SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++)
			{
				string text = NormalisePathSpec(files[i]).ToLower();
				bool flag = false;
				string pathExtensionWithoutDot = GetPathExtensionWithoutDot(text);
				foreach (string validFileExtension in validFileExtensions)
				{
					if (pathExtensionWithoutDot == validFileExtension.ToLower())
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				bool flag2 = false;
				foreach (string validRelFileSpec in validRelFileSpecs)
				{
					string value = "/" + NormalisePathSpec(validRelFileSpec).ToLower();
					if (text.EndsWith(value))
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2 && !DeleteFile(text))
				{
					result = false;
				}
			}
			return result;
		}

		public static bool DeleteFile(string fileSpec)
		{
			bool result = false;
			if (File.Exists(fileSpec))
			{
				try
				{
					File.Delete(fileSpec);
					result = true;
					ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyDeletedFile), fileSpec));
				}
				catch (Exception ex)
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorDeletingFile), fileSpec, ex.ToString()));
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.FileToDeleteDoesNotExist), fileSpec));
			}
			return result;
		}

		public static bool DeleteFolder(string folderPathSpec)
		{
			bool result = false;
			if (Directory.Exists(folderPathSpec))
			{
				try
				{
					Directory.Delete(folderPathSpec, recursive: true);
					result = true;
					ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyDeletedFolder), folderPathSpec));
				}
				catch (Exception ex)
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorDeletingFolder), folderPathSpec, ex.ToString()));
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.FolderToDeleteDoesNotExist), folderPathSpec));
			}
			return result;
		}

		public static bool GetDictionaryValue(Dictionary<string, string> dictionary, string key, ref string retValue, bool bAllowEmptyValues = true)
		{
			bool result = false;
			retValue = string.Empty;
			string value = string.Empty;
			if (dictionary.TryGetValue(key, out value) && (bAllowEmptyValues || !value.IsNullOrEmpty()))
			{
				result = true;
				retValue = value;
			}
			return result;
		}

		public static bool GetDictionaryValue(Dictionary<string, string> dictionary, string key, ref int retValue)
		{
			bool result = false;
			string retValue2 = string.Empty;
			if (GetDictionaryValue(dictionary, key, ref retValue2))
			{
				result = true;
				retValue = Convert.ToInt32(retValue2);
			}
			return result;
		}

		public static bool GetDictionaryValue(Dictionary<string, string> dictionary, string key, ref long retValue)
		{
			bool result = false;
			string retValue2 = string.Empty;
			if (GetDictionaryValue(dictionary, key, ref retValue2))
			{
				result = true;
				retValue = Convert.ToInt64(retValue2);
			}
			return result;
		}

		public static bool SetDictionaryValue(Dictionary<string, string> dictionary, string key, string value)
		{
			bool result = false;
			if (dictionary.ContainsKey(key))
			{
				if (dictionary[key] != value)
				{
					result = true;
					dictionary[key] = value;
				}
			}
			else
			{
				result = true;
				dictionary.Add(key, value);
			}
			return result;
		}

		public static bool ReadWriteDictionaryValue(bool bWrite, Dictionary<string, string> dictiionary, string key, ref int value)
		{
			string value2 = value.ToString();
			bool result = ReadWriteDictionaryValue(bWrite, dictiionary, key, ref value2);
			if (!bWrite && !value2.IsNullOrEmpty())
			{
				value = Convert.ToInt32(value2);
			}
			return result;
		}

		public static bool ReadWriteDictionaryValue(bool bWrite, Dictionary<string, string> dictionary, string key, ref string value)
		{
			bool result = false;
			if (bWrite)
			{
				if (SetDictionaryValue(dictionary, key, value))
				{
					result = true;
				}
			}
			else
			{
				GetDictionaryValue(dictionary, key, ref value);
			}
			return result;
		}

		public static bool CreateFolder(string folderSpec)
		{
			bool result = false;
			try
			{
				Directory.CreateDirectory(folderSpec);
				result = true;
				ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyCreatedFolder), folderSpec));
			}
			catch (Exception ex)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorCreatingFolder), folderSpec, ex.ToString()));
			}
			return result;
		}

		public static bool IsValidForFileOrFolderName(char inChar)
		{
			bool result = false;
			if (char.IsLetterOrDigit(inChar) || inChar == ' ' || inChar == '-' || inChar == '+' || inChar == '=' || inChar == '_' || inChar == '(' || inChar == ')' || inChar == '[' || inChar == ']' || inChar == '{' || inChar == '}')
			{
				result = true;
			}
			return result;
		}

		public static bool IsValidForFileOrFolderName(string inString)
		{
			bool result = true;
			if (!inString.IsNullOrEmpty())
			{
				int i = 0;
				for (int length = inString.Length; i < length; i++)
				{
					if (!IsValidForFileOrFolderName(inString[i]))
					{
						result = false;
						break;
					}
				}
			}
			return result;
		}

		public static string SanitizeFileOrFolderName(string inName)
		{
			string text = inName;
			text = text.Replace(",", "");
			text = text.Replace("/", "");
			text = text.Replace("\\", "");
			bool flag = false;
			char[] array = text.ToCharArray();
			int i = 0;
			for (int length = text.Length; i < length; i++)
			{
				if (!IsValidForFileOrFolderName(array[i]))
				{
					array[i] = '*';
					flag = true;
				}
			}
			if (flag)
			{
				text = new string(array);
				text = text.Replace('*'.ToString(), "");
			}
			return text;
		}

		public static string GetPathSpec(string pathSpec, string fileName)
		{
			string result = string.Empty;
			if (!pathSpec.IsNullOrEmpty() && !fileName.IsNullOrEmpty())
			{
				result = Path.Combine(pathSpec, fileName);
				result = NormalisePathSpec(result);
			}
			return result;
		}

		public static string GetPathExtensionWithoutDot(string pathSpec)
		{
			return Path.GetExtension(pathSpec).Replace(".", "");
		}

		public static string NormalisePathSpec(string pathSpec)
		{
			return pathSpec.Replace("\\", "/").Replace("\\\\", "/").Replace("//", "/");
		}

		public static string MakePathSpecRelativeTo(string pathSpec, string relativeToPathSpec)
		{
			string text = pathSpec;
			if (pathSpec.StartsWith(relativeToPathSpec))
			{
				text = text.Replace(relativeToPathSpec, "");
			}
			return text;
		}

		public static string GetPathSpecToNamedFolder(string pathSpec, string namedFolder)
		{
			string result = string.Empty;
			int num = pathSpec.IndexOf(namedFolder);
			if (num >= 0)
			{
				num += namedFolder.Length + 1;
				result = pathSpec.Substring(0, num);
			}
			return result;
		}

		public static string ExtractCommonRootPathFromSpecs(ref List<string> logInstallPathSpecs, string commonPathSearchFolder)
		{
			string text = string.Empty;
			if (logInstallPathSpecs.Count > 0)
			{
				int i = 0;
				for (int count = logInstallPathSpecs.Count; i < count; i++)
				{
					logInstallPathSpecs[i] = NormalisePathSpec(logInstallPathSpecs[i]);
				}
				text = GetPathSpecToNamedFolder(logInstallPathSpecs[0], commonPathSearchFolder);
				if (!text.IsNullOrEmpty())
				{
					int j = 0;
					for (int count2 = logInstallPathSpecs.Count; j < count2; j++)
					{
						logInstallPathSpecs[j] = MakePathSpecRelativeTo(logInstallPathSpecs[j], text);
					}
				}
			}
			return text;
		}

		public static bool ScanFoldersForFileSpecs(string folderSpec, string fileName, ref List<string> targetFileSpecs)
		{
			return ScanFoldersForFiles(folderSpec, fileName, ref targetFileSpecs);
		}

		public static bool ScanFoldersForFileSpecFolders(string folderSpec, string fileName, ref List<string> targetFolderSpecs)
		{
			return ScanFoldersForFiles(folderSpec, fileName, ref targetFolderSpecs, bIncludeFileName: false);
		}

		public static bool ScanFoldersForFiles(string folderSpec, string fileName, ref List<string> targetSpecs, bool bIncludeFileName = true)
		{
			bool flag = false;
			ExtContentMessages.LogDebug(string.Format(HiliteParams("Scanning for '{0}' files within folder '{1}' ..."), fileName, folderSpec));
			if (targetSpecs == null)
			{
				targetSpecs = new List<string>();
			}
			flag = ScanFoldersForFilesRecurse(folderSpec, fileName, ref targetSpecs, bIncludeFileName);
			ExtContentMessages.LogDebug(string.Format(HiliteParams("Scanning found {0} '{1}' files within folder '{2}'. Errors encountered: {3}"), targetSpecs.Count, folderSpec, fileName, flag ? "N" : "Y"));
			return flag;
		}

		private static bool ScanFoldersForFilesRecurse(string folderSpec, string fileName, ref List<string> targetSpecs, bool bIncludeFileName = true)
		{
			bool result = false;
			if (Directory.Exists(folderSpec))
			{
				string pathSpec = GetPathSpec(folderSpec, fileName);
				if (!File.Exists(pathSpec))
				{
					result = true;
					string[] directories = Directory.GetDirectories(folderSpec);
					if (directories.Length != 0)
					{
						int i = 0;
						for (int num = directories.Length; i < num; i++)
						{
							if (!ScanFoldersForFilesRecurse(GetPathSpec(folderSpec, directories[i]), fileName, ref targetSpecs, bIncludeFileName))
							{
								result = false;
							}
						}
					}
				}
				else
				{
					result = true;
					if (bIncludeFileName)
					{
						targetSpecs.Add(pathSpec);
					}
					else
					{
						targetSpecs.Add(folderSpec);
					}
				}
			}
			return result;
		}

		public static string GetRootFolderNameFromPathSpec(string pathSpec)
		{
			string result = string.Empty;
			pathSpec = pathSpec.TrimStart('/');
			pathSpec = pathSpec.TrimStart('\\');
			int num = pathSpec.IndexOf("/");
			if (num < 0)
			{
				num = pathSpec.IndexOf("\\");
			}
			if (num >= 0)
			{
				result = pathSpec.Substring(0, num);
			}
			return result;
		}

		public static string GetRootAssetNameForAssetBundle(string assetBundleFileSpec)
		{
			string result = string.Empty;
			bool flag = true;
			if (!assetBundleFileSpec.IsNullOrEmpty())
			{
				string text = assetBundleFileSpec + ".manifest";
				try
				{
					string[] array = File.ReadAllLines(text);
					string text2 = string.Empty;
					int i = 0;
					for (int num = array.Length - 1; i < num; i++)
					{
						if (array[i].StartsWith("Assets:"))
						{
							text2 = array[i + 1];
							if (text2.StartsWith("- "))
							{
								text2 = text2.Substring(2);
							}
							break;
						}
					}
					if (!text2.IsNullOrEmpty())
					{
						flag = false;
						result = text2;
					}
				}
				catch (Exception ex)
				{
					ExtContentMessages.LogDebug(string.Format(HiliteParams("Error reading asset bundle manifest file '{0}'. Exception: '{1}'"), text, ex.ToString()));
				}
			}
			if (flag)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorObtainingAssetBundleRootAssetName), assetBundleFileSpec));
			}
			return result;
		}

		public static long GetCurrentTimeStamp()
		{
			return (DateTime.UtcNow.Ticks - cRefDateTime.Ticks) / 10000;
		}

		public static string GetTimeStampDisplayString(long timestamp, bool bYearFirst = true)
		{
			long num = timestamp * 10000;
			DateTime dateTime = new DateTime(cRefDateTime.Ticks + num);
			string empty = string.Empty;
			if (bYearFirst)
			{
				return $"{dateTime.Year:0000}/{dateTime.Month:00}/{dateTime.Day:00}@{dateTime.Hour:00}:{dateTime.Minute:00}:{dateTime.Second:00}";
			}
			return $"{dateTime.Day:00}/{dateTime.Month:00}/{dateTime.Year:0000}@{dateTime.Hour:00}:{dateTime.Minute:00}:{dateTime.Second:00}";
		}

		public static string FileModTimeToString(DateTime dt)
		{
			return $"{dt.Year:0000}:{dt.Month:00}:{dt.Day:00}:{dt.Hour:00}:{dt.Minute:00}:{dt.Second:00}:{dt.Millisecond:000}";
		}

		public static DateTime FileModTimeFromString(string dtStr)
		{
			DateTime result = cRefDateTime;
			if (!dtStr.IsNullOrEmpty())
			{
				string[] array = dtStr.Split(':');
				if (array.Length == 7)
				{
					result = new DateTime(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), Convert.ToInt32(array[2]), Convert.ToInt32(array[3]), Convert.ToInt32(array[4]), Convert.ToInt32(array[5]), Convert.ToInt32(array[6]));
				}
			}
			return result;
		}

		public static bool IsFileModTimeMoreRecentThan(DateTime dt1, DateTime dt2)
		{
			bool result = false;
			if (dt1.Year > dt2.Year || dt1.Month > dt2.Month || dt1.Day > dt2.Day || dt1.Hour > dt2.Hour || dt1.Minute > dt2.Minute || dt1.Second > dt2.Second || dt1.Millisecond > dt2.Millisecond)
			{
				result = true;
			}
			return result;
		}

		public static string SecsToMinsAndSecsString(float totalsSecs)
		{
			int num = Mathf.CeilToInt(totalsSecs);
			int num2 = num / 60;
			int num3 = num % 60;
			return $"{num2:00}:{num3:00}";
		}

		public static uint GetPathSpecHash(string pathSpec)
		{
			pathSpec = NormalisePathSpec(pathSpec);
			pathSpec = pathSpec.Replace("/", "");
			pathSpec = pathSpec.Replace("\\", "");
			return (uint)pathSpec.GetHashCode();
		}

		public static uint GetPathSpecHash2(string pathSpec)
		{
			pathSpec = NormalisePathSpec(pathSpec);
			return (uint)pathSpec.GetHashCode();
		}

		public static string GetGameItemInGameName(GameItemBase gameItem)
		{
			string result = string.Empty;
			if (gameItem != null)
			{
				result = gameItem.Title;
			}
			return result;
		}

		public static string GetGameItemInGameDescription(GameItemBase gameItem)
		{
			string result = string.Empty;
			if (gameItem != null)
			{
				result = gameItem.Description;
			}
			return result;
		}

		public static Sprite GetPictureBaseGameItemInGameIconSprite(GameItemBase gameItem)
		{
			Sprite result = null;
			if (gameItem != null)
			{
				GameItemDataBase gameItemDataBase = gameItem.GetGameItemDataBase();
				if (gameItemDataBase != null)
				{
					Texture2D texture2D = null;
					if (gameItemDataBase is GameItemDataRoomItemPictureBase gameItemDataRoomItemPictureBase)
					{
						texture2D = gameItemDataRoomItemPictureBase.IconTexture2D;
					}
					else if (gameItemDataBase is GameItemDataFloorAndWall gameItemDataFloorAndWall)
					{
						texture2D = gameItemDataFloorAndWall.IconTexture2D;
					}
					if (texture2D != null)
					{
						result = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
					}
				}
			}
			return result;
		}

		public static bool IsGeneralDevModifierOn()
		{
			if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
			{
				return Input.GetKey(KeyCode.CapsLock);
			}
			return false;
		}

		public static bool IsShowGameItemDevInfoPanelModifierOn()
		{
			return IsGeneralDevModifierOn();
		}

		public static bool CheckShowGameItemDevInfoPanelInput(GameItemBase gameItem = null, bool bCheckNoUGCUIScreensOpen = true)
		{
			bool result = false;
			if (Input.GetMouseButtonDown(0) && (!bCheckNoUGCUIScreensOpen || !ExtContentUIUtils.AreAnyugcUIScreensShown()))
			{
				result = CheckShowGameItemDevInfoPanel(gameItem);
			}
			return result;
		}

		public static bool CheckShowGameItemDevInfoPanel(GameItemBase gameItem = null)
		{
			bool result = false;
			if (IsShowGameItemDevInfoPanelModifierOn())
			{
				result = true;
				ShowGameItemDevInfoPanel(gameItem);
			}
			return result;
		}

		public static void ShowGameItemDevInfoPanel(GameItemBase gameItem = null)
		{
			List<string> list = new List<string>();
			ExtContentSourceLocalMods contentSourceLocalMods = ExtContentManager.ContentSourceLocalMods;
			ExtContentSourceWorkshop contentSourceWorkshop = ExtContentManager.ContentSourceWorkshop;
			List<GameItemBase> allGameItems = contentSourceLocalMods.GetAllGameItems();
			List<GameItemBase> allGameItems2 = contentSourceWorkshop.GetAllGameItems();
			List<WorkshopInstalledItem> installedItems = contentSourceWorkshop.InstalledItems;
			list.Add($"Local Items: <$S>{allGameItems.Count}<$E>, Workshop Packages: <$S>{installedItems.Count}<$E>, Workshop Items: <$S>{allGameItems2.Count}<$E>");
			list.Add("");
			list.Add($"Local Mods Location:");
			list.Add($"<$S>{contentSourceLocalMods.GetLocalModsFolderSpec()}<$E>");
			list.Add("");
			bool flag = true;
			string button2Text = "Open Workshop";
			if (gameItem != null)
			{
				ExtContentSourceBase extContentSourceBase = null;
				switch (gameItem.ContentSource)
				{
				case EContentSourceType.LocalMods:
					flag = false;
					extContentSourceBase = contentSourceLocalMods;
					button2Text = "Open Local / Workshop";
					break;
				case EContentSourceType.Workshop:
					flag = true;
					extContentSourceBase = contentSourceWorkshop;
					button2Text = "Open Workshop";
					break;
				}
				list.Add($"Game Item Title: <$S>{gameItem.Title}<$E>");
				list.Add($"Display Name: <$S>{gameItem.DisplayName}<$E>");
				list.Add($"Source: <$S>{ExtContentSourceType.ContentSourceTypeToString(gameItem.ContentSource)}<$E>");
				list.Add($"Content Type: <$S>{ExtContentType.ContentTypeToString(gameItem.ContentType)}<$E>");
				if (gameItem is GameItemPictureBase gameItemPictureBase)
				{
					list.Add($"Content Sub Type: <$S>{gameItemPictureBase.ItemSubTypeID}<$E>");
				}
				list.Add($"Last Updated: <$S>{GetTimeStampDisplayString(gameItem.LastUpdatedTimeStamp, bYearFirst: false)}<$E>");
				string pathSpecToNamedFolder = GetPathSpecToNamedFolder(gameItem.InstalledFolderPathSpec, extContentSourceBase.GetCommonPathSearchFolder());
				string arg = MakePathSpecRelativeTo(gameItem.InstalledFolderPathSpec, pathSpecToNamedFolder);
				list.Add($"Location (Rel): <$S>{arg}<$E>");
				list.Add("");
				list.Add($"ContentID: <$S>{gameItem.ContentID}<$E>");
				list.Add("");
				WorkshopItemMetaData publishedWorkshopMetaData = gameItem.PublishedWorkshopMetaData;
				if (publishedWorkshopMetaData != null)
				{
					list.Add(string.Format("Workshop Published File ID: : <$S>{0}<$E>, Version On Disk: <$S>{1}<$E>", publishedWorkshopMetaData.PublishedFileId, "v" + $"{publishedWorkshopMetaData.VersionNumberOnDisk}"));
				}
				else
				{
					list.Add(string.Format("Workshop Published Info: : <$S>{0}<$E>", "Not published"));
				}
			}
			else
			{
				list.Add(string.Format(HiliteParamsF("Game Item: <$S>{0}<$E>"), "None"));
			}
			string text = string.Empty;
			foreach (string item in list)
			{
				string text2 = "<color=#BBBBBB>" + item + "</color>";
				text2 = text2.Replace("<$S>", "</color><color=#FFFFFF>");
				text2 = text2.Replace("<$E>", "</color><color=#BBBBBB>");
				text = text + text2 + "\n";
			}
			string button1Text = (true ? "Dump All To Log & Open" : "Dump All To Log");
			ExtContentMessages.ShowTwoOptionMessageBox("UGC Local Mod & Workshop Info", text, button1Text, button2Text, "OK", delegate
			{
				LogAllItems(gameItem);
				OpenLatestLogFileIntextEditor();
			}, delegate
			{
				CheckOpenGameItemUI(gameItem);
			}, null, option1ButtonsAutoHide: false, !flag);
		}

		private static void LogAllItems(GameItemBase gameItem)
		{
			ExtContentMessages.LogDebug("");
			ExtContentMessages.LogDebug("#############################################################");
			ExtContentMessages.LogDebug("UGC LOCAL MOD & WORKSHOP INFO");
			ExtContentMessages.LogDebug("#############################################################");
			if (gameItem != null)
			{
				ExtContentMessages.LogDebug(gameItem.GetLogInfoStringWithPath());
				ExtContentMessages.LogDebug("#############################################################");
			}
			ExtContentManager.ContentSourceLocalMods.LogGameItems();
			ExtContentMessages.LogDebug("#############################################################");
			ExtContentManager.ContentSourceWorkshop.LogInstalledItems();
			ExtContentMessages.LogDebug("#############################################################");
			ExtContentManager.ContentSourceWorkshop.LogGameItems();
			ExtContentMessages.LogDebug("#############################################################");
		}

		private static void CheckOpenGameItemUI(GameItemBase gameItem)
		{
			bool flag = true;
			if (gameItem != null && gameItem.ContentSource == EContentSourceType.LocalMods && !IsShowGameItemDevInfoPanelModifierOn())
			{
				flag = false;
				if (!ExtContentUIUtils.IsGameItemUIScreenShown())
				{
					ExtContentUIUtils.OpenGameItemUIScreen(gameItem);
				}
			}
			if (flag)
			{
				ExtContentUIUtils.OpenGameItemWorkshopPage(gameItem);
			}
		}

		public static void OpenLatestLogFileIntextEditor()
		{
			string logFileSpec = Logging.Logger.GetLogHandler<FileLogHandler>().LogFileSpec;
			if (!logFileSpec.IsNullOrEmpty())
			{
				OpenTextEditor(logFileSpec);
			}
		}

		private static void OpenTextEditor(string fileSpec)
		{
			string arguments = $"\"{fileSpec}\"";
			Process.Start(new ProcessStartInfo("notepad.exe", arguments));
		}

		private static void AddContentSubTypeItem(GameItemBase.GameItemBaseConfig configItem, ref List<string> retItems, ref List<string> retItemDisplayNamesLoc)
		{
			if (configItem == null)
			{
				return;
			}
			if (retItems != null)
			{
				retItems.Add(configItem._itemConfigTag);
			}
			if (retItemDisplayNamesLoc != null)
			{
				string text = string.Empty;
				if (!configItem._itemDisplayName.Term.IsNullOrEmpty())
				{
					text = configItem._itemDisplayName.Translation;
				}
				if (text.IsNullOrEmpty())
				{
					text = configItem._itemConfigTag;
				}
				retItemDisplayNamesLoc.Add(text);
			}
		}

		public static bool GetContentSubTypesForContentType(EContentType contentType, ref List<string> retItems, ref List<string> retItemDisplayNamesLoc)
		{
			switch (contentType)
			{
			case EContentType.Picture:
			{
				SharedInstance<GameItemPicture.GameItemPictureConfig>[] configPictures = ExtContentManager.Config.ExtContentConfig.Instance._configPictures;
				for (int i = 0; i < configPictures.Length; i++)
				{
					AddContentSubTypeItem(configPictures[i].Instance, ref retItems, ref retItemDisplayNamesLoc);
				}
				break;
			}
			case EContentType.Rug:
			{
				SharedInstance<GameItemRug.GameItemRugConfig>[] configWalls = ExtContentManager.Config.ExtContentConfig.Instance._configRugs;
				for (int i = 0; i < configWalls.Length; i++)
				{
					AddContentSubTypeItem(configWalls[i].Instance, ref retItems, ref retItemDisplayNamesLoc);
				}
				break;
			}
			case EContentType.Floor:
			{
				SharedInstance<GameItemRug.GameItemRugConfig>[] configWalls = ExtContentManager.Config.ExtContentConfig.Instance._configFloors;
				for (int i = 0; i < configWalls.Length; i++)
				{
					AddContentSubTypeItem(configWalls[i].Instance, ref retItems, ref retItemDisplayNamesLoc);
				}
				break;
			}
			case EContentType.Wall:
			{
				SharedInstance<GameItemRug.GameItemRugConfig>[] configWalls = ExtContentManager.Config.ExtContentConfig.Instance._configWalls;
				for (int i = 0; i < configWalls.Length; i++)
				{
					AddContentSubTypeItem(configWalls[i].Instance, ref retItems, ref retItemDisplayNamesLoc);
				}
				break;
			}
			}
			return true;
		}

		public static GameItemPictureBase.GameItemPictureBaseConfig GetPictureBaseConfigForContentType(EContentType contentType, string subTypeID)
		{
			GameItemPictureBase.GameItemPictureBaseConfig result = null;
			List<string> retItems = new List<string>();
			List<string> retItemDisplayNamesLoc = null;
			if (GetContentSubTypesForContentType(contentType, ref retItems, ref retItemDisplayNamesLoc))
			{
				result = GetPictureBaseConfigForContentType(contentType, retItems.IndexOf(subTypeID));
			}
			return result;
		}

		public static GameItemPictureBase.GameItemPictureBaseConfig GetPictureBaseConfigForContentTypeAndTag(EContentType contentType, string itemConfigTag)
		{
			GameItemPictureBase.GameItemPictureBaseConfig result = null;
			if (!itemConfigTag.IsNullOrEmpty())
			{
				int num = -1;
				switch (contentType)
				{
				case EContentType.Picture:
					num = Array.FindIndex(ExtContentManager.Config.ExtContentConfig.Instance._configPictures, (SharedInstance<GameItemPicture.GameItemPictureConfig> item) => item.Instance._itemConfigTag == itemConfigTag);
					if (num >= 0)
					{
						result = ExtContentManager.Config.ExtContentConfig.Instance._configPictures[num].Instance;
					}
					break;
				case EContentType.Rug:
					num = Array.FindIndex(ExtContentManager.Config.ExtContentConfig.Instance._configRugs, (SharedInstance<GameItemRug.GameItemRugConfig> item) => item.Instance._itemConfigTag == itemConfigTag);
					if (num >= 0)
					{
						result = ExtContentManager.Config.ExtContentConfig.Instance._configRugs[num].Instance;
					}
					break;
				case EContentType.Floor:
					num = Array.FindIndex(ExtContentManager.Config.ExtContentConfig.Instance._configFloors, (SharedInstance<GameItemRug.GameItemRugConfig> item) => item.Instance._itemConfigTag == itemConfigTag);
					if (num >= 0)
					{
						result = ExtContentManager.Config.ExtContentConfig.Instance._configFloors[num].Instance;
					}
					break;
				case EContentType.Wall:
					num = Array.FindIndex(ExtContentManager.Config.ExtContentConfig.Instance._configWalls, (SharedInstance<GameItemRug.GameItemRugConfig> item) => item.Instance._itemConfigTag == itemConfigTag);
					if (num >= 0)
					{
						result = ExtContentManager.Config.ExtContentConfig.Instance._configWalls[num].Instance;
					}
					break;
				}
			}
			return result;
		}

		public static GameItemPictureBase.GameItemPictureBaseConfig GetPictureBaseConfigForContentType(EContentType contentType, int subTypeIndex = 0)
		{
			GameItemPictureBase.GameItemPictureBaseConfig result = null;
			if (subTypeIndex >= 0)
			{
				switch (contentType)
				{
				case EContentType.Picture:
					if (subTypeIndex < ExtContentManager.Config.ExtContentConfig.Instance._configPictures.Length)
					{
						result = ExtContentManager.Config.ExtContentConfig.Instance._configPictures[subTypeIndex].Instance;
					}
					break;
				case EContentType.Rug:
					if (subTypeIndex < ExtContentManager.Config.ExtContentConfig.Instance._configRugs.Length)
					{
						result = ExtContentManager.Config.ExtContentConfig.Instance._configRugs[subTypeIndex].Instance;
					}
					break;
				case EContentType.Floor:
					if (subTypeIndex < ExtContentManager.Config.ExtContentConfig.Instance._configFloors.Length)
					{
						result = ExtContentManager.Config.ExtContentConfig.Instance._configFloors[subTypeIndex].Instance;
					}
					break;
				case EContentType.Wall:
					if (subTypeIndex < ExtContentManager.Config.ExtContentConfig.Instance._configWalls.Length)
					{
						result = ExtContentManager.Config.ExtContentConfig.Instance._configWalls[subTypeIndex].Instance;
					}
					break;
				}
			}
			return result;
		}
	}
}
