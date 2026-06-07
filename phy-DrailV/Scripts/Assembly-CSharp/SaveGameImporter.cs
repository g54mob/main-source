using System;
using System.Collections.Generic;
using System.Text;
using DV.Common;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Storage;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SaveGameImporter
{
	public static int CheckForImports(User user)
	{
		int num = 0;
		string text = user.UserBasePath + "/ImportSave";
		List<string> createdFiles;
		if (user.Storage.DirectoryExists(text))
		{
			List<string> list = user.Storage.ListFiles(text);
			createdFiles = new List<string>();
			foreach (string item in list)
			{
				GameSession gameSession = null;
				bool flag = false;
				createdFiles.Clear();
				if (item.EndsWith(".save"))
				{
					try
					{
						Paky paky = new Paky(user.Storage.ReadFileToBytes(text + "/" + item), "SAVE", 1);
						byte[] data = paky.ReadFirst(1);
						byte[] bytes = user.Storage.DecryptData(data, SingletonBehaviour<UserManager>.Instance.KeyProvider?.GetKeyFor(user.UID, user.Name, user.Signature));
						JObject jObject = JObject.Parse(Encoding.UTF8.GetString(bytes));
						string text2 = jObject["Game_mode"].Value<string>();
						string world = jObject["World"].Value<string>();
						if (!user.CanCreateNewSessions(text2))
						{
							throw new Exception("Limit hit while importing saves, can't create any more sessions of " + text2);
						}
						gameSession = user.StartSession(text2, world, "Imported " + text2);
						bool? flag2 = jObject.GetBool("Tutorial_01_completed");
						bool? flag3 = jObject.GetBool("Tutorial_02_completed");
						if (flag2.HasValue && flag2.Value && (!flag3.HasValue || !flag3.Value))
						{
							gameSession.GameData["Difficulty_picked"] = false;
						}
						gameSession.Save();
						user.Storage.CreateDirectory(gameSession.BasePath + "/Saves");
						string text3 = gameSession.BasePath + "/Saves/" + item;
						CopyFile(text + "/" + item, text3);
						int num2 = paky.FindChunkIndex(2);
						byte[] bytes2 = paky.ReadChunk(paky.Chunks[num2]);
						JObject jObject2 = JObject.Parse(Encoding.UTF8.GetString(bytes2));
						if (jObject2["Type"].Type == JTokenType.Integer)
						{
							SaveType saveType = (SaveType)jObject2["Type"].Value<int>();
							if (saveType != SaveType.Manual)
							{
								jObject2["Type"] = 0;
								Paky.InputData[] array = paky.ExportAsInputData();
								array[num2] = new Paky.InputData(2, Encoding.UTF8.GetBytes(jObject2.ToString()));
								user.Storage.WriteFile(text3, Paky.PackToBytes(array, "SAVE", 1));
								Debug.Log("Modified imported save " + text3 + " to be Manual (was " + saveType.ToString() + ".");
							}
						}
						gameSession.ForceRefreshSaves();
						gameSession.Save();
						num++;
						user.Storage.DeleteFile(text + "/" + item);
					}
					catch (Exception ex)
					{
						flag = true;
						Debug.LogError("Error importing save '" + item + "': " + ex.Message);
						Debug.LogException(ex);
					}
				}
				else if (item.EndsWith(".sav"))
				{
					try
					{
						string text4 = item.Substring(0, item.Length - ".sav".Length);
						bool num3 = user.Storage.FileExists(text + "/" + text4 + ".json");
						bool flag4 = user.Storage.FileExists(text + "/" + text4 + ".jpg");
						if (!num3)
						{
							throw new Exception("Save '" + text4 + "' is incomplete, missing .json meta file");
						}
						byte[] data2 = user.Storage.ReadFileToBytes(text + "/" + item);
						byte[] bytes3 = user.Storage.DecryptData(data2, SingletonBehaviour<UserManager>.Instance.KeyProvider?.GetKeyFor(user.UID, user.Name, user.Signature));
						JObject jObject3 = JObject.Parse(Encoding.UTF8.GetString(bytes3));
						string text5 = jObject3["Game_mode"].Value<string>();
						string world2 = jObject3["World"].Value<string>();
						if (!user.CanCreateNewSessions(text5))
						{
							throw new Exception("Limit hit while importing saves, can't create any more sessions of " + text5);
						}
						gameSession = user.StartSession(text5, world2, "Imported " + text5);
						gameSession.Save();
						user.Storage.CreateDirectory(gameSession.BasePath + "/Saves");
						CopyFile(text + "/" + item, gameSession.BasePath + "/Saves/" + item);
						CopyFile(text + "/" + text4 + ".json", gameSession.BasePath + "/Saves/" + text4 + ".json");
						if (flag4)
						{
							CopyFile(text + "/" + text4 + ".jpg", gameSession.BasePath + "/Saves/" + text4 + ".jpg");
						}
						gameSession.ForceRefreshSaves();
						gameSession.Save();
						num++;
						user.Storage.DeleteFile(text + "/" + item);
						user.Storage.DeleteFile(text + "/" + text4 + ".json");
						if (flag4)
						{
							user.Storage.DeleteFile(text + "/" + text4 + ".jpg");
						}
					}
					catch (Exception ex2)
					{
						flag = true;
						Debug.LogError("Error importing save '" + item + "': " + ex2.Message);
						Debug.LogException(ex2);
					}
				}
				else if (item.IndexOf('.') < 0 || item.EndsWith(".bak"))
				{
					try
					{
						byte[] array2 = null;
						if (SingletonBehaviour<UserManager>.Instance.KeyProvider != null)
						{
							array2 = SingletonBehaviour<UserManager>.Instance.KeyProvider.GetKeyFor(user.UID, user.Name, user.Signature);
						}
						string path = text + "/" + item;
						DateTime lastWriteTime = user.Storage.GetLastWriteTime(path);
						string text6 = DataProtection.DecryptString(user.Storage.ReadFileToString(path), Encoding.UTF8.GetString(array2));
						if (JObject.Parse(text6)["Player_position"] == null)
						{
							throw new Exception("Not valid DV save data");
						}
						string text7 = "00000_" + user.Storage.SanitizeName(lastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
						JObject jObject4 = new JObject();
						jObject4.Add("Timestamp", lastWriteTime);
						jObject4.Add("Type", 0);
						jObject4.Add("Name", lastWriteTime.ToString());
						jObject4.Add("World", "World1");
						jObject4.Add("GameMode", "Career");
						if (!user.CanCreateNewSessions("Career"))
						{
							throw new Exception("Limit hit while importing saves, can't create any more sessions of Career");
						}
						gameSession = user.StartSession("Career", "World1", "Imported Career");
						gameSession.Save();
						user.Storage.WriteFile(gameSession.BasePath + "/Saves/" + text7 + ".json", jObject4.ToString());
						user.Storage.WriteFile(gameSession.BasePath + "/Saves/" + text7 + ".sav", text6, array2);
						num++;
						user.Storage.DeleteFile(text + "/" + item);
						gameSession.ForceRefreshSaves();
						gameSession.Save();
					}
					catch (Exception ex3)
					{
						flag = true;
						Debug.LogError("Error importing save '" + item + "': " + ex3.Message);
						Debug.LogException(ex3);
					}
				}
				else if (!item.EndsWith(".jpg") && !item.EndsWith(".json") && !item.EndsWith(".error"))
				{
					Debug.LogWarning("Unrecognized file in save import directory: " + item);
				}
				if (!flag)
				{
					continue;
				}
				try
				{
					if (gameSession != null)
					{
						user.DeleteSession(gameSession);
					}
					foreach (string item2 in createdFiles)
					{
						user.Storage.DeleteFile(item2);
					}
					user.Storage.CopyFile(text + "/" + item, text + "/" + item + ".error");
					user.Storage.DeleteFile(text + "/" + item);
				}
				catch (Exception ex4)
				{
					Debug.LogError("Error cleaning up failed import (" + item + "): " + ex4.Message);
					Debug.LogException(ex4);
				}
			}
		}
		else
		{
			user.Storage.CreateDirectory(text);
		}
		return num;
		void CopyFile(string sourcePath, string destinationPath)
		{
			user.Storage.CopyFile(sourcePath, destinationPath);
			createdFiles.Add(destinationPath);
		}
	}
}
