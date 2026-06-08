using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public static class SystemFileManager
{
	public static bool MapDataVerified { get; set; }

	public static bool SyncMapDataChanges()
	{
		bool newDataFound = false;
		bool oldDataDeleted = false;
		bool existingDataModified = false;
		return SyncMapDataChanges(false, out newDataFound, out oldDataDeleted, out existingDataModified);
	}

	public static bool SyncMapDataChanges(bool testOnly, out bool newDataFound, out bool oldDataDeleted, out bool existingDataModified)
	{
		bool result = true;
		newDataFound = false;
		oldDataDeleted = false;
		existingDataModified = false;
		string text = Path.Combine(Application.dataPath, "DataStore");
		Debug.Log(string.Format("Galaxy Source Path: {0}", text));
		GameFileHelper.EnsureGameFileDirectoriesExist();
		string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
		StreamWriter streamWriter = File.AppendText(Path.Combine(dataGalaxyLocation, "log.txt"));
		if (Directory.Exists(text))
		{
			DataFile.InitSetting(dataGalaxyLocation, "~inf.txt");
			string[] directories = Directory.GetDirectories(text, "*.*", SearchOption.TopDirectoryOnly);
			List<string> allGroups = DataFile.GetAllGroups("FOLDER_");
			foreach (string item in allGroups)
			{
				string text2 = DataFile.Get(item, "FLDR", string.Empty);
				if (string.IsNullOrEmpty(text2) || text2.Equals("Objectives", StringComparison.InvariantCultureIgnoreCase))
				{
					continue;
				}
				bool flag = false;
				text2 = text2.ToLower();
				string[] array = directories;
				foreach (string path in array)
				{
					string fileName = Path.GetFileName(path);
					if (fileName.ToLower() == text2)
					{
						string[] files = Directory.GetFiles(path, "_mDM.png", SearchOption.TopDirectoryOnly);
						if (files.Length > 0)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					continue;
				}
				if (!testOnly)
				{
					string text3 = Path.Combine(dataGalaxyLocation, text2);
					try
					{
						if (Directory.Exists(text3))
						{
							Directory.Delete(text3, true);
							streamWriter.WriteLine(string.Format("{0}: SYNC - DELETE: Folder removed: {1}", DateTime.Now.ToString(), text3));
						}
					}
					catch (Exception ex)
					{
						string text4 = string.Format("Failed to delete directory: {0}.\r\nError: {1}", text3, ex.Message);
						Debug.LogError(text4);
						streamWriter.WriteLine(string.Format("{0}:{1}", DateTime.Now.ToString(), text4));
					}
					string text5 = GameSaveFile.Get("GALAXY_ID", string.Empty);
					if (!string.IsNullOrEmpty(text5))
					{
						string text6 = Path.GetFileName(text3).ToLower();
						if (text5.ToLower() == text6)
						{
							GameSaveFile.Clear("GALAXY_ID");
						}
					}
					DataFile.ClearGroupAndChildren(item);
				}
				else
				{
					oldDataDeleted = true;
					result = false;
				}
			}
			string[] array2 = directories;
			foreach (string text7 in array2)
			{
				bool flag2 = text7.ToLower().EndsWith("objectives");
				string[] files2 = Directory.GetFiles(text7, "_mDM.png", SearchOption.TopDirectoryOnly);
				if (!flag2 && files2.Length <= 0)
				{
					continue;
				}
				string fileName2 = Path.GetFileName(text7);
				string text8 = Path.Combine(dataGalaxyLocation, fileName2);
				try
				{
					if (!Directory.Exists(text8))
					{
						if (!testOnly)
						{
							Directory.CreateDirectory(text8);
							streamWriter.WriteLine(string.Format("{0}:SYNC - NEW: \\{1}\\", DateTime.Now.ToString(), fileName2));
						}
						else
						{
							newDataFound = true;
							result = false;
						}
					}
				}
				catch (Exception ex2)
				{
					string text9 = string.Format("Failed to create a directory: {0}.\r\nError: {1}", text8, ex2.Message);
					Debug.LogError(text9);
					streamWriter.WriteLine(string.Format("{0}:{1}", DateTime.Now.ToString(), text9));
					continue;
				}
				string text10 = DataFile.FindGroup("FOLDER_", "FLDR", fileName2);
				if (string.IsNullOrEmpty(text10))
				{
					int num = 0;
					do
					{
						num = UnityEngine.Random.Range(1, int.MaxValue);
					}
					while (DataFile.Exists(string.Format("FOLDER_{0}", num)));
					text10 = string.Format("FOLDER_{0}", num);
					if (!testOnly)
					{
						DataFile.Save(text10, "FLDR", fileName2);
					}
					else
					{
						newDataFound = true;
						result = false;
					}
				}
				string[] array3 = null;
				array3 = (flag2 ? Directory.GetFiles(text7, "~*.txt", SearchOption.TopDirectoryOnly) : Directory.GetFiles(text7, "*.png", SearchOption.TopDirectoryOnly));
				List<string> allGroups2 = DataFile.GetAllGroups("FILE_", "P", text10);
				foreach (string item2 in allGroups2)
				{
					string text11 = DataFile.Get(item2, "FILE", string.Empty);
					if (string.IsNullOrEmpty(text11))
					{
						continue;
					}
					bool flag3 = false;
					text11 = text11.ToLower();
					string[] array4 = text11.Split('-');
					if (array4.Length == 2)
					{
						text11 = array4[1];
					}
					string[] array5 = array3;
					foreach (string path2 in array5)
					{
						string fileName3 = Path.GetFileName(path2);
						if (fileName3.ToLower() == text11)
						{
							flag3 = true;
							break;
						}
					}
					if (flag3)
					{
						continue;
					}
					if (!testOnly)
					{
						string text12 = Path.Combine(text8, text11);
						try
						{
							if (File.Exists(text12))
							{
								File.Delete(text12);
								streamWriter.WriteLine(string.Format("{0}: SYNC - DELETE: File removed: {1}", DateTime.Now.ToString(), text12));
							}
						}
						catch (Exception ex3)
						{
							string text13 = string.Format("Failed to delete file: {0}.\r\nError: {1}", text12, ex3.Message);
							Debug.LogError(text13);
							streamWriter.WriteLine(string.Format("{0}:{1}", DateTime.Now.ToString(), text13));
						}
						DataFile.ClearGroup(item2);
					}
					else
					{
						oldDataDeleted = true;
						result = false;
					}
				}
				int num2 = 0;
				string[] array6 = array3;
				foreach (string text14 in array6)
				{
					try
					{
						bool flag4 = true;
						bool flag5 = false;
						string fileName4 = Path.GetFileName(text14);
						string text15 = Path.Combine(text8, fileName4);
						string text16 = DataFile.FindGroup("FILE_", "FILE", string.Format("{0}-{1}", fileName2, fileName4));
						if (string.IsNullOrEmpty(text16))
						{
							int num3 = 0;
							do
							{
								num3 = UnityEngine.Random.Range(1, int.MaxValue);
							}
							while (DataFile.Exists(string.Format("FILE_{0}", num3)));
							text16 = string.Format("FILE_{0}", num3);
							if (!testOnly)
							{
								DataFile.Save(text16, "P", text10);
								DataFile.Save(text16, "FILE", string.Format("{0}-{1}", fileName2, fileName4));
							}
							else
							{
								newDataFound = true;
								result = false;
							}
						}
						if (File.Exists(text15))
						{
							string text17 = DataFile.Get(text16, "DMODIFIED", string.Empty);
							if (!string.IsNullOrEmpty(text17))
							{
								text17 = text17.Replace(';', ':');
								string[] array7 = text17.Split('.');
								CultureInfo provider = CultureInfo.CreateSpecificCulture("en-US");
								DateTime dateTime = DateTime.Parse(array7[0], provider);
								double result2 = 0.0;
								double.TryParse(array7[1], out result2);
								result2 /= 10000.0;
								dateTime = dateTime.AddMilliseconds(result2);
								if (File.GetLastWriteTime(text14).CompareTo(dateTime) <= 0)
								{
									flag4 = false;
								}
								else
								{
									flag5 = true;
								}
							}
						}
						if (flag4)
						{
							if (!testOnly)
							{
								File.Copy(text14, text15, true);
								string value = File.GetLastWriteTime(text15).ToString("MM/dd/yyyy hh;mm;ss tt.fffffff");
								DataFile.Save(text16, "DMODIFIED", value);
								if (!flag5)
								{
									streamWriter.WriteLine(string.Format("{0}:SYNC - NEW: \\{1}\\{2}", DateTime.Now.ToString(), fileName2, fileName4));
								}
								else
								{
									streamWriter.WriteLine(string.Format("{0}:SYNC - UPDATE: \\{1}\\{2}", DateTime.Now.ToString(), fileName2, fileName4));
								}
							}
							else
							{
								if (!flag5)
								{
									newDataFound = true;
								}
								else
								{
									existingDataModified = true;
								}
								result = false;
							}
						}
						num2++;
					}
					catch (Exception ex4)
					{
						string text18 = string.Format("Failed to move a file from INSTALLDATA: {0} to {1}.\r\nException: {2}", text14, dataGalaxyLocation, ex4.Message);
						Debug.LogError(text18);
						streamWriter.WriteLine(string.Format("{0}:{1}", DateTime.Now.ToString(), text18));
					}
				}
			}
			if (!testOnly)
			{
				GameSaveFile.Clear("WS_STALE");
				MapDataVerified = true;
			}
		}
		else
		{
			streamWriter.WriteLine(string.Format("{0}:Source Galaxy Path Not Found! {1}", DateTime.Now.ToString(), text));
		}
		DataFile.Detach();
		streamWriter.Close();
		return result;
	}

	public static void ClearStarMapDataImages()
	{
		ClearStarMapDataImages(false);
	}

	public static void ClearStarMapDataImages(bool removeMetaDataFile)
	{
		GameFileHelper.EnsureGameFileDirectoriesExist();
		string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
		StreamWriter streamWriter = File.AppendText(Path.Combine(dataGalaxyLocation, "log.txt"));
		if (Directory.Exists(dataGalaxyLocation))
		{
			string[] directories = Directory.GetDirectories(dataGalaxyLocation, "*.*", SearchOption.TopDirectoryOnly);
			string text = "~map";
			if (GameSaveFile.Get("UNIVERSE_ID", "DEFAULT") != "DEFAULT")
			{
				text += "_ch";
			}
			text += ".txt";
			string[] array = directories;
			foreach (string path in array)
			{
				string[] files = Directory.GetFiles(path, "_mDM.png", SearchOption.TopDirectoryOnly);
				if (files.Length <= 0)
				{
					continue;
				}
				string[] files2 = Directory.GetFiles(path, "_d*.png", SearchOption.TopDirectoryOnly);
				string[] array2 = files2;
				foreach (string text2 in array2)
				{
					try
					{
						File.Delete(text2);
					}
					catch (Exception ex)
					{
						string arg = string.Format("Failed to delete a data file: {0}.\r\nException: {1}", text2, ex.Message);
						streamWriter.WriteLine(string.Format("{0}:{1}", DateTime.Now.ToString(), arg));
					}
				}
				if (!removeMetaDataFile)
				{
					continue;
				}
				files2 = Directory.GetFiles(path, text, SearchOption.TopDirectoryOnly);
				if (files2.Length == 1)
				{
					try
					{
						File.Delete(files2[0]);
					}
					catch (Exception ex2)
					{
						string arg2 = string.Format("Failed to delete a data file: {0}.\r\nException: {1}", files2[0], ex2.Message);
						streamWriter.WriteLine(string.Format("{0}:{1}", DateTime.Now.ToString(), arg2));
					}
				}
			}
		}
		else
		{
			streamWriter.WriteLine(string.Format("{0}:Galaxy Data Path Not Found! {1}", DateTime.Now.ToString(), dataGalaxyLocation));
		}
		streamWriter.Close();
	}
}
