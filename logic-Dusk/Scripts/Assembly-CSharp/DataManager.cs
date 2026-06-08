using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class DataManager
{
	private class RootDataObject
	{
		public List<DataObject> childList;

		public string GroupKey { get; private set; }

		public string ObjectName { get; private set; }

		private RootDataObject()
		{
		}

		public RootDataObject(string groupKey, string objectName)
		{
			GroupKey = groupKey;
			ObjectName = objectName.ToLower();
			childList = new List<DataObject>();
		}
	}

	private class DataObject
	{
		public List<KeyValuePair<string, string>> variableList;

		public List<DataObject> childList;

		public string GroupKey { get; private set; }

		public string ParentGroupKey { get; set; }

		public string SourceFile { get; private set; }

		private DataObject()
		{
		}

		public DataObject(string groupKey, string parentGroupKey, List<KeyValuePair<string, string>> variableList, string sourceFile)
		{
			GroupKey = groupKey;
			ParentGroupKey = parentGroupKey;
			this.variableList = variableList;
			SourceFile = sourceFile;
			childList = new List<DataObject>();
		}

		public bool IsValidKeyValue(string key, string value, bool validIfMissing)
		{
			bool flag = false;
			if (variableList != null)
			{
				if (key[0] == '^')
				{
					key = key.Substring(1);
				}
				if (key[0] == '!')
				{
					key = key.Substring(1);
					flag = true;
					if (!validIfMissing)
					{
						validIfMissing = true;
					}
				}
				KeyValuePair<string, string> keyValuePair = default(KeyValuePair<string, string>);
				int count = variableList.Count;
				for (int i = 0; i < count; i++)
				{
					KeyValuePair<string, string> keyValuePair2 = variableList[i];
					if (keyValuePair2.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
					{
						keyValuePair = keyValuePair2;
						break;
					}
				}
				if (keyValuePair.Key != null)
				{
					if (keyValuePair.Value.Equals(value, StringComparison.InvariantCultureIgnoreCase))
					{
						return !flag;
					}
					return flag ? true : false;
				}
			}
			return validIfMissing;
		}
	}

	private static int attemptsToLoad;

	private static Dictionary<string, RootDataObject> cachedGalaxyDict;

	private static Dictionary<string, DataObject> cachedSystemDict;

	private static Dictionary<string, DataObject> cachedDungeonDict;

	private static Dictionary<string, RootDataObject> cachedReferencedRootData;

	private static Dictionary<string, DataObject> cachedReferencedData;

	public static bool IsInMultiStepQueryMode { get; private set; }

	public static bool LoadQueryableRespository()
	{
		attemptsToLoad++;
		if (attemptsToLoad == 1)
		{
			if (cachedGalaxyDict == null)
			{
				cachedGalaxyDict = new Dictionary<string, RootDataObject>();
			}
			else
			{
				cachedGalaxyDict.Clear();
			}
			if (cachedSystemDict == null)
			{
				cachedSystemDict = new Dictionary<string, DataObject>();
			}
			else
			{
				cachedSystemDict.Clear();
			}
			if (cachedDungeonDict == null)
			{
				cachedDungeonDict = new Dictionary<string, DataObject>();
			}
			else
			{
				cachedDungeonDict.Clear();
			}
			DataFile dataFile = new DataFile();
			string currentDataUniverseLocation = GameFileHelper.GetCurrentDataUniverseLocation();
			List<string> allGroups = UniverseSaveFile.GetAllGroups("GX_");
			int count = allGroups.Count;
			for (int i = 0; i < count; i++)
			{
				string text = allGroups[i];
				if (cachedGalaxyDict.ContainsKey(text))
				{
					continue;
				}
				string text2 = UniverseSaveFile.Get(text, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(text2))
				{
					dataFile.InitSettingInstance(currentDataUniverseLocation, string.Format("{0}.txt", text2));
					RootDataObject rootDataObject = new RootDataObject(text, dataFile.GetSetting("DATA", string.Empty));
					cachedGalaxyDict.Add(text, rootDataObject);
					List<string> groupsByName = dataFile.GetGroupsByName("SYS_");
					int count2 = groupsByName.Count;
					for (int j = 0; j < count2; j++)
					{
						string text3 = groupsByName[j];
						DataObject dataObject = new DataObject(text3, text, dataFile.GetGroupData(text3), text2);
						rootDataObject.childList.Add(dataObject);
						if (!cachedSystemDict.ContainsKey(text3))
						{
							cachedSystemDict.Add(text3, dataObject);
						}
						List<string> groups = dataFile.GetGroups("OBJ_", "P", text3);
						int count3 = groups.Count;
						for (int k = 0; k < count3; k++)
						{
							string text4 = groups[k];
							DataObject dataObject2 = new DataObject(text4, text3, dataFile.GetGroupData(text4), text2);
							dataObject.childList.Add(dataObject2);
							if (!cachedDungeonDict.ContainsKey(text4))
							{
								cachedDungeonDict.Add(text4, dataObject2);
								continue;
							}
							DataObject dataObject3 = cachedSystemDict[cachedDungeonDict[text4].ParentGroupKey];
							Debug.LogError(string.Format("There were 2+ OBJ_ in the data with the same ID.  This message is for the dev: GX: {0}, SYS: {1}, OBJ: {2}.  Other objet Info: {3}", text, text3, text4, dataObject3.ParentGroupKey));
						}
					}
				}
				else
				{
					Debug.LogWarning(string.Format("BuildQueryableRespository - any - Didn't find the '{0}' key of a referenced galaxy key: {1}.  Corrupted data and not including that galaxy as part of the repository", "FILE", text));
				}
			}
		}
		return true;
	}

	public static void Unload()
	{
		attemptsToLoad--;
		if (attemptsToLoad == 0)
		{
			if (cachedGalaxyDict != null)
			{
				cachedGalaxyDict.Clear();
				cachedGalaxyDict = null;
			}
			if (cachedSystemDict != null)
			{
				cachedSystemDict.Clear();
				cachedSystemDict = null;
			}
			if (cachedDungeonDict != null)
			{
				cachedDungeonDict.Clear();
				cachedDungeonDict = null;
			}
			if (cachedReferencedData != null)
			{
				cachedReferencedData.Clear();
				cachedReferencedData = null;
			}
			if (cachedReferencedRootData != null)
			{
				cachedReferencedRootData.Clear();
				cachedReferencedRootData = null;
			}
		}
	}

	public static void BeginMultiStepQuery()
	{
		IsInMultiStepQueryMode = true;
	}

	public static void EndMultiStepQuery()
	{
		IsInMultiStepQueryMode = false;
	}

	public static string FindDungeon(DungeonTypeEnum dungeonType, string variableID, string galaxyLocation, string systemLocation, string dungeonLocation, string property, string externalReference, string tag, bool hasDataTagBack, string dataTagBackValue, params string[] filters)
	{
		string text = null;
		bool flag = false;
		RootDataObject rootDataObject = null;
		DataObject dataObject = null;
		DataObject dataObject2 = null;
		List<DataObject> list = new List<DataObject>();
		if (cachedReferencedData == null)
		{
			cachedReferencedData = new Dictionary<string, DataObject>();
		}
		if (cachedReferencedData.Count > 0 && cachedReferencedData.ContainsKey(variableID))
		{
			if (cachedReferencedData[variableID] == null)
			{
				return null;
			}
			list.Add(cachedReferencedData[variableID]);
			flag = true;
		}
		else
		{
			if (cachedReferencedData.Count > 0 && cachedReferencedData.ContainsKey(galaxyLocation))
			{
				if (cachedReferencedData[galaxyLocation] == null)
				{
					return null;
				}
				if (cachedReferencedData[galaxyLocation].GroupKey.Length > 0 && cachedReferencedData[galaxyLocation].GroupKey[0] == 'S' && cachedReferencedData[galaxyLocation].GroupKey.StartsWith("SYS_"))
				{
					dataObject = cachedReferencedData[galaxyLocation];
				}
			}
			else if (cachedReferencedRootData != null && cachedReferencedRootData.Count > 0 && cachedReferencedRootData.ContainsKey(galaxyLocation))
			{
				if (cachedReferencedRootData[galaxyLocation] == null)
				{
					return null;
				}
				rootDataObject = cachedReferencedRootData[galaxyLocation];
			}
			if (dataObject2 == null && dungeonLocation != "any" && cachedDungeonDict.Count > 0 && cachedDungeonDict.ContainsKey(dungeonLocation))
			{
				dataObject2 = cachedDungeonDict[dungeonLocation];
			}
			if (dataObject == null && systemLocation != "any")
			{
				if (cachedSystemDict.Count > 0 && cachedSystemDict.ContainsKey(systemLocation))
				{
					dataObject = cachedSystemDict[systemLocation];
				}
				else if (cachedReferencedData != null && cachedReferencedData.ContainsKey(systemLocation))
				{
					dataObject = cachedReferencedData[systemLocation];
				}
			}
			if (rootDataObject == null && galaxyLocation != "any")
			{
				if (cachedGalaxyDict.Count > 0 && cachedGalaxyDict.ContainsKey(galaxyLocation))
				{
					rootDataObject = cachedGalaxyDict[galaxyLocation];
				}
				if (rootDataObject == null)
				{
					rootDataObject = cachedGalaxyDict.FirstOrDefault((KeyValuePair<string, RootDataObject> x) => x.Value.ObjectName != null && x.Value.ObjectName == galaxyLocation).Value;
				}
			}
			if (dataObject2 != null)
			{
				list.Add(dataObject2);
			}
			else if (rootDataObject != null)
			{
				if (dataObject != null)
				{
					if (dataObject.ParentGroupKey != rootDataObject.GroupKey)
					{
						return null;
					}
					if (dataObject.childList != null)
					{
						int count = dataObject.childList.Count;
						List<DataObject> list2 = null;
						for (int num = 0; num < count; num++)
						{
							DataObject dataObject3 = dataObject.childList[num];
							if (dataObject3 == null || !(dataObject3.ParentGroupKey == dataObject.GroupKey) || dataObject3.variableList == null)
							{
								continue;
							}
							int count2 = dataObject3.variableList.Count;
							for (int num2 = 0; num2 < count2; num2++)
							{
								KeyValuePair<string, string> keyValuePair = dataObject3.variableList[num2];
								if (!(keyValuePair.Key == "DTYPE"))
								{
									continue;
								}
								string value = keyValuePair.Value;
								int num3 = (int)dungeonType;
								if (value == num3.ToString())
								{
									if (list2 == null)
									{
										list2 = new List<DataObject>();
									}
									list2.Add(dataObject3);
									break;
								}
							}
						}
						if (list2 != null)
						{
							list = list2;
						}
						else
						{
							int num4 = 0;
							num4++;
						}
					}
				}
				else
				{
					int count3 = rootDataObject.childList.Count;
					List<DataObject> list3 = null;
					for (int num5 = 0; num5 < count3; num5++)
					{
						DataObject dataObject4 = rootDataObject.childList[num5];
						if (dataObject4 == null || dataObject4.childList == null)
						{
							continue;
						}
						int count4 = dataObject4.childList.Count;
						for (int num6 = 0; num6 < count4; num6++)
						{
							DataObject dataObject5 = dataObject4.childList[num6];
							if (dataObject5 == null || dataObject5.variableList == null)
							{
								continue;
							}
							int count5 = dataObject5.variableList.Count;
							for (int num7 = 0; num7 < count5; num7++)
							{
								KeyValuePair<string, string> keyValuePair2 = dataObject5.variableList[num7];
								if (!(keyValuePair2.Key == "DTYPE"))
								{
									continue;
								}
								string value2 = keyValuePair2.Value;
								int num8 = (int)dungeonType;
								if (value2 == num8.ToString())
								{
									if (list3 == null)
									{
										list3 = new List<DataObject>();
									}
									list3.Add(dataObject5);
									break;
								}
							}
						}
					}
					if (list3 != null)
					{
						List<DataObject> list4 = new List<DataObject>(list3.Count);
						int count6 = list4.Count;
						for (int num9 = 0; num9 < count6; num9++)
						{
							list4.Add(list3[num9]);
						}
						int count7 = list4.Count;
						for (int num10 = 0; num10 < count7; num10++)
						{
							DataObject dataObject6 = list4[num10];
							list3.Clear();
							int count8 = dataObject6.childList.Count;
							for (int num11 = 0; num11 < count8; num11++)
							{
								DataObject dataObject7 = dataObject6.childList[num11];
								if (dataObject7 == null || dataObject7.variableList == null)
								{
									continue;
								}
								int count9 = dataObject7.variableList.Count;
								for (int num12 = 0; num12 < count9; num12++)
								{
									KeyValuePair<string, string> keyValuePair3 = dataObject7.variableList[num12];
									if (keyValuePair3.Key == "DTYPE")
									{
										string value3 = keyValuePair3.Value;
										int num13 = (int)dungeonType;
										if (value3 == num13.ToString())
										{
											list3.Add(dataObject7);
											break;
										}
									}
								}
							}
							if (list3 != null)
							{
								list.AddRange(list3);
								int num14 = 0;
								num14++;
							}
						}
					}
					else
					{
						int num15 = 0;
						num15++;
					}
				}
			}
			else if (dataObject != null)
			{
				if (dataObject.childList != null)
				{
					int count10 = dataObject.childList.Count;
					List<DataObject> list5 = null;
					for (int num16 = 0; num16 < count10; num16++)
					{
						DataObject dataObject8 = dataObject.childList[num16];
						if (dataObject8 == null || dataObject8.variableList == null)
						{
							continue;
						}
						int count11 = dataObject8.variableList.Count;
						for (int num17 = 0; num17 < count11; num17++)
						{
							KeyValuePair<string, string> keyValuePair4 = dataObject8.variableList[num17];
							if (!(keyValuePair4.Key == "DTYPE"))
							{
								continue;
							}
							string value4 = keyValuePair4.Value;
							int num18 = (int)dungeonType;
							if (value4 == num18.ToString())
							{
								if (list5 == null)
								{
									list5 = new List<DataObject>();
								}
								list5.Add(dataObject8);
								break;
							}
						}
					}
					if (list5 != null)
					{
						list = list5.ToList();
					}
				}
			}
			else
			{
				Dictionary<string, DataObject>.Enumerator enumerator = cachedDungeonDict.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Value.variableList.FirstOrDefault(delegate(KeyValuePair<string, string> x)
					{
						int result4;
						if (x.Key == "DTYPE")
						{
							string value7 = x.Value;
							int num23 = (int)dungeonType;
							result4 = ((value7 == num23.ToString()) ? 1 : 0);
						}
						else
						{
							result4 = 0;
						}
						return (byte)result4 != 0;
					}).Key != null)
					{
						list.Add(enumerator.Current.Value);
					}
				}
			}
		}
		if (list.Count > 0)
		{
			if (galaxyLocation == "any" && !flag)
			{
				int count12 = cachedReferencedData.Count;
				for (int num19 = 0; num19 < count12; num19++)
				{
					int count13 = list.Count;
					KeyValuePair<string, DataObject> keyValuePair5 = cachedReferencedData.ElementAt(num19);
					if (!(keyValuePair5.Key != variableID))
					{
						continue;
					}
					for (int num20 = 0; num20 < count13; num20++)
					{
						DataObject dataObject9 = list[num20];
						if (dataObject9 != null && keyValuePair5.Value != null && dataObject9.GroupKey == keyValuePair5.Value.GroupKey)
						{
							list.RemoveAt(num20);
							break;
						}
					}
				}
				if (list.Count == 0)
				{
					if (cachedReferencedData.Count == 0 || !cachedReferencedData.ContainsKey(variableID))
					{
						cachedReferencedData.Add(variableID, null);
					}
					return null;
				}
			}
			list = ApplyFilterToList(list, filters);
			if (list.Count == 0)
			{
				if (cachedReferencedData.Count == 0 || !cachedReferencedData.ContainsKey(variableID))
				{
					cachedReferencedData.Add(variableID, null);
				}
				return null;
			}
			if (!string.IsNullOrEmpty(externalReference))
			{
				if (externalReference.ToUpper() != "SCAVENGER")
				{
					Debug.LogWarning("We currently only support using the SCAVENGER HUNT as an exteral source for objects.  This is stubbed out logic, and will need to be expanded to reference whatever you were tyring to reference.  Note: iof you were TRYING to reference the scavenger hunt, make sure you referenced it with '@SCAVENGER'!");
				}
				else
				{
					DataFile dataFile = new DataFile();
					string dataUniverseLocation = GameFileHelper.GetDataUniverseLocation();
					dataUniverseLocation = Path.Combine(dataUniverseLocation, GameSaveFile.Get("UNIVERSE_ID", string.Empty));
					dataFile.InitSettingInstance(dataUniverseLocation, "~objscvngr.txt");
					int count14 = list.Count;
					for (int num21 = count14 - 1; num21 >= 0; num21--)
					{
						if (string.IsNullOrEmpty(dataFile.GetGroupWithSettings("RO_OBJ_", "KEY", list[num21].GroupKey)))
						{
							list.RemoveAt(num21);
						}
					}
					if (list.Count == 0)
					{
						if (cachedReferencedData.Count == 0 || !cachedReferencedData.ContainsKey(variableID))
						{
							cachedReferencedData.Add(variableID, null);
						}
						return null;
					}
				}
			}
			int index = UnityEngine.Random.Range(0, list.Count);
			if (cachedReferencedData.Count == 0 || !cachedReferencedData.ContainsKey(variableID))
			{
				cachedReferencedData.Add(variableID, list[index]);
			}
			property = property.ToUpper();
			if (string.IsNullOrEmpty(property))
			{
				property = "NAME";
			}
			else
			{
				StarSystemInfo starSystemInfo = null;
				DungeonInfo dungeonInfo = null;
				switch (property)
				{
				default:
					if ((dungeonType != DungeonTypeEnum.AutoTrade || !(property == "NAME")) && string.IsNullOrEmpty(tag))
					{
						break;
					}
					goto case "AGE";
				case "AGE":
				case "TYPE":
				case "INTERNALID":
				{
					string value5 = list[index].variableList.FirstOrDefault((KeyValuePair<string, string> x) => x.Key.ToUpper() == "SEED_D").Value;
					int result = 0;
					if (value5 == null || !int.TryParse(value5, out result))
					{
						break;
					}
					bool result2 = false;
					string value6 = list[index].variableList.FirstOrDefault((KeyValuePair<string, string> x) => x.Key.ToUpper() == "SD").Value;
					if (!string.IsNullOrEmpty(value6))
					{
						bool.TryParse(value6, out result2);
					}
					starSystemInfo = new StarSystemInfo(null);
					if (!result2)
					{
						int result3 = -1;
						string[] array = list[index].GroupKey.Split('_');
						if (array.Length == 2)
						{
							int.TryParse(array[1], out result3);
						}
						dungeonInfo = GalaxyProcessor.BuildNormalDungeon(result, dungeonType, starSystemInfo, 0, result3);
					}
					else
					{
						dungeonInfo = GalaxyProcessor.BuildNurseryDungeon(result, dungeonType, starSystemInfo, 0, GalaxySaveFile.Get(list[index].GroupKey, "EPIDX", 0));
					}
					break;
				}
				}
				switch (property)
				{
				case "AGE":
					if (dungeonInfo != null)
					{
						text = dungeonInfo.Age.ToString();
					}
					break;
				case "TYPE":
					if (dungeonInfo != null)
					{
						text = dungeonInfo.DisplayName;
					}
					break;
				case "INTERNALID":
					if (dungeonInfo != null)
					{
						text = dungeonInfo.InternalId.ToString();
					}
					break;
				case "GROUPKEY":
					text = list[index].GroupKey;
					break;
				case "HIDDEN":
					return string.Empty;
				}
				if (dungeonType == DungeonTypeEnum.AutoTrade && property == "NAME" && dungeonInfo != null)
				{
					text = dungeonInfo.Name.ToString();
				}
				if (!string.IsNullOrEmpty(tag) && dungeonInfo != null)
				{
					DataFile dataFile2 = new DataFile();
					string currentDataUniverseLocation = GameFileHelper.GetCurrentDataUniverseLocation();
					string fileName = Path.Combine(currentDataUniverseLocation, list[index].SourceFile + ".txt");
					dataFile2.InitSettingInstance(currentDataUniverseLocation, fileName);
					dataFile2.SaveValue(dungeonInfo.GroupKey, "TAG", tag);
					if (text == null)
					{
						text = dataFile2.GetValue(dungeonInfo.GroupKey, "NAME", "ERR");
					}
				}
			}
			if (text == null)
			{
				DataObject dataObject10 = list[index];
				int count15 = dataObject10.variableList.Count;
				for (int num22 = 0; num22 < count15; num22++)
				{
					KeyValuePair<string, string> keyValuePair6 = dataObject10.variableList[num22];
					if (keyValuePair6.Key.ToUpper() == property)
					{
						text = keyValuePair6.Value;
						break;
					}
				}
			}
			if (text != null && hasDataTagBack)
			{
				string[] array2 = dataTagBackValue.Split('=');
				if (array2.Length == 2)
				{
					DataFile dataFile3 = new DataFile();
					string currentDataUniverseLocation2 = GameFileHelper.GetCurrentDataUniverseLocation();
					string fileName2 = Path.Combine(currentDataUniverseLocation2, list[index].SourceFile + ".txt");
					dataFile3.InitSettingInstance(currentDataUniverseLocation2, fileName2);
					dataFile3.SaveValue(list[index].GroupKey, array2[0], array2[1]);
				}
			}
		}
		return text;
	}

	public static string FindSystem(string variableID, string galaxyLocation, string systemLocation, string property, string externalReference, params string[] filters)
	{
		string text = null;
		bool flag = false;
		RootDataObject rootDataObject = null;
		DataObject dataObject = null;
		List<DataObject> list = new List<DataObject>();
		if (cachedReferencedData == null)
		{
			cachedReferencedData = new Dictionary<string, DataObject>();
		}
		if (cachedReferencedData.ContainsKey(variableID))
		{
			if (cachedReferencedData[variableID] == null)
			{
				return null;
			}
			list.Add(cachedReferencedData[variableID]);
			flag = true;
		}
		else
		{
			if (cachedReferencedData.ContainsKey(galaxyLocation))
			{
				if (cachedReferencedData[galaxyLocation] == null)
				{
					return null;
				}
				systemLocation = cachedReferencedData[galaxyLocation].ParentGroupKey;
			}
			if (systemLocation != "any" && cachedSystemDict.ContainsKey(systemLocation))
			{
				dataObject = cachedSystemDict[systemLocation];
			}
			if (galaxyLocation != "any")
			{
				if (cachedGalaxyDict.ContainsKey(galaxyLocation))
				{
					rootDataObject = cachedGalaxyDict[galaxyLocation];
				}
				if (cachedReferencedRootData != null && cachedReferencedRootData.ContainsKey(galaxyLocation))
				{
					rootDataObject = cachedReferencedRootData[galaxyLocation];
				}
				if (rootDataObject == null)
				{
					rootDataObject = cachedGalaxyDict.FirstOrDefault((KeyValuePair<string, RootDataObject> x) => x.Value.ObjectName != null && x.Value.ObjectName == galaxyLocation).Value;
				}
			}
			if (rootDataObject != null)
			{
				if (dataObject != null)
				{
					if (dataObject.ParentGroupKey != rootDataObject.GroupKey)
					{
						return null;
					}
					list.Add(dataObject);
				}
				else
				{
					list.AddRange(rootDataObject.childList);
				}
			}
			else if (dataObject != null)
			{
				list.Add(dataObject);
			}
			else
			{
				Dictionary<string, DataObject>.Enumerator enumerator = cachedSystemDict.GetEnumerator();
				while (enumerator.MoveNext())
				{
					list.Add(enumerator.Current.Value);
				}
			}
		}
		if (list.Count > 0)
		{
			if (galaxyLocation == "any" && !flag)
			{
				int count = cachedReferencedData.Count;
				for (int i = 0; i < count; i++)
				{
					if (list.FirstOrDefault((DataObject x) => x != null && cachedReferencedData.ElementAt(i).Key != variableID && cachedReferencedData.ElementAt(i).Key[0] == variableID[0] && cachedReferencedData.ElementAt(i).Value != null && x.GroupKey == cachedReferencedData.ElementAt(i).Value.GroupKey) != null)
					{
						list.Remove(cachedReferencedData.ElementAt(i).Value);
					}
				}
				if (list.Count == 0)
				{
					if (!cachedReferencedData.ContainsKey(variableID))
					{
						cachedReferencedData.Add(variableID, null);
					}
					return null;
				}
			}
			list = ApplyFilterToList(list, filters);
			if (list.Count == 0)
			{
				if (!cachedReferencedData.ContainsKey(variableID))
				{
					cachedReferencedData.Add(variableID, null);
				}
				return null;
			}
			if (!string.IsNullOrEmpty(externalReference))
			{
				if (externalReference.ToUpper() != "SCAVENGER")
				{
					Debug.LogWarning("We currently only support using the SCAVENGER HUNT as an exteral source for objects.  This is stubbed out logic, and will need to be expanded to reference whatever you were tyring to reference.  Note: iof you were TRYING to reference the scavenger hunt, make sure you referenced it with '@SCAVENGER'!");
				}
				else
				{
					DataFile dataFile = new DataFile();
					string dataUniverseLocation = GameFileHelper.GetDataUniverseLocation();
					dataUniverseLocation = Path.Combine(dataUniverseLocation, GameSaveFile.Get("UNIVERSE_ID", string.Empty));
					dataFile.InitSettingInstance(dataUniverseLocation, "~objscvngr.txt");
					int count2 = list.Count;
					for (int num = count2 - 1; num >= 0; num--)
					{
						if (string.IsNullOrEmpty(dataFile.GetGroupWithSettings("RO_OBJ_", "SYS", list[num].GroupKey)))
						{
							list.RemoveAt(num);
						}
					}
					if (list.Count == 0)
					{
						if (!cachedReferencedData.ContainsKey(variableID))
						{
							cachedReferencedData.Add(variableID, null);
						}
						return null;
					}
				}
			}
			int index = UnityEngine.Random.Range(0, list.Count);
			if (!cachedReferencedData.ContainsKey(variableID))
			{
				cachedReferencedData.Add(variableID, list[index]);
			}
			property = property.ToUpper();
			if (string.IsNullOrEmpty(property))
			{
				property = "NAME";
			}
			else
			{
				if (property == "HIDDEN")
				{
					return string.Empty;
				}
				if (property == "INTERNALID")
				{
					Debug.LogWarning("Log Variable Warning: InternalID not supported by Systems - a close (and valid) alternative is GroupKey");
				}
				else if (property == "GROUPKEY")
				{
					return list[index].GroupKey;
				}
			}
			if (text == null)
			{
				text = list[index].variableList.FirstOrDefault((KeyValuePair<string, string> x) => x.Key.ToUpper() == property).Value;
			}
		}
		return text;
	}

	public static string FindGalaxy(string variableID, string galaxyLocation, string property, string externalReference, params string[] filters)
	{
		string text = null;
		bool flag = false;
		RootDataObject rootDataObject = null;
		DataObject dataObject = null;
		List<RootDataObject> filteredGalaxies = new List<RootDataObject>();
		if (cachedReferencedRootData == null)
		{
			cachedReferencedRootData = new Dictionary<string, RootDataObject>();
		}
		if (cachedReferencedRootData.ContainsKey(variableID))
		{
			if (cachedReferencedRootData[variableID] == null)
			{
				return null;
			}
			filteredGalaxies.Add(cachedReferencedRootData[variableID]);
			flag = true;
		}
		else
		{
			bool flag2 = false;
			if (cachedReferencedData != null && cachedReferencedData.ContainsKey(galaxyLocation))
			{
				if (cachedReferencedData[galaxyLocation] == null)
				{
					return null;
				}
				galaxyLocation = cachedReferencedData[galaxyLocation].ParentGroupKey;
				if (galaxyLocation.Length > 0 && galaxyLocation[0] == 'S' && galaxyLocation.StartsWith("SYS_"))
				{
					flag2 = true;
				}
			}
			if (galaxyLocation != "any")
			{
				if (cachedGalaxyDict.ContainsKey(galaxyLocation))
				{
					rootDataObject = cachedGalaxyDict[galaxyLocation];
				}
				if (rootDataObject == null)
				{
					rootDataObject = (flag2 ? cachedGalaxyDict.FirstOrDefault((KeyValuePair<string, RootDataObject> x) => x.Value.childList != null && x.Value.childList.FirstOrDefault((DataObject y) => y.GroupKey == galaxyLocation) != null).Value : cachedGalaxyDict.FirstOrDefault((KeyValuePair<string, RootDataObject> x) => x.Value.ObjectName != null && x.Value.ObjectName == galaxyLocation).Value);
				}
			}
			if (rootDataObject != null)
			{
				filteredGalaxies.Add(rootDataObject);
			}
			else
			{
				Dictionary<string, RootDataObject>.Enumerator enumerator = cachedGalaxyDict.GetEnumerator();
				while (enumerator.MoveNext())
				{
					filteredGalaxies.Add(enumerator.Current.Value);
				}
			}
		}
		if (filteredGalaxies.Count > 0)
		{
			if (galaxyLocation == "any" && !flag)
			{
				int count = cachedReferencedRootData.Count;
				for (int i = 0; i < count; i++)
				{
					if (filteredGalaxies.FirstOrDefault((RootDataObject x) => x != null && cachedReferencedRootData.ElementAt(i).Key != variableID && cachedReferencedRootData.ElementAt(i).Key[0] == variableID[0] && cachedReferencedRootData.ElementAt(i).Value != null && x.GroupKey == cachedReferencedRootData.ElementAt(i).Value.GroupKey) != null)
					{
						filteredGalaxies.Remove(cachedReferencedRootData.ElementAt(i).Value);
					}
				}
				if (filteredGalaxies.Count == 0)
				{
					if (!cachedReferencedRootData.ContainsKey(variableID))
					{
						cachedReferencedRootData.Add(variableID, null);
					}
					return null;
				}
			}
			if (!string.IsNullOrEmpty(externalReference))
			{
				if (externalReference.ToUpper() != "SCAVENGER")
				{
					Debug.LogWarning("We currently only support using the SCAVENGER HUNT as an exteral source for objects.  This is stubbed out logic, and will need to be expanded to reference whatever you were tyring to reference.  Note: iof you were TRYING to reference the scavenger hunt, make sure you referenced it with '@SCAVENGER'!");
				}
				else
				{
					DataFile dataFile = new DataFile();
					string dataUniverseLocation = GameFileHelper.GetDataUniverseLocation();
					dataUniverseLocation = Path.Combine(dataUniverseLocation, GameSaveFile.Get("UNIVERSE_ID", string.Empty));
					dataFile.InitSettingInstance(dataUniverseLocation, "~objscvngr.txt");
					int count2 = filteredGalaxies.Count;
					for (int num = count2 - 1; num >= 0; num--)
					{
						if (string.IsNullOrEmpty(dataFile.GetGroupWithSettings("RO_OBJ_", "GXY", filteredGalaxies[num].GroupKey)))
						{
							filteredGalaxies.RemoveAt(num);
						}
					}
					if (filteredGalaxies.Count == 0)
					{
						if (!cachedReferencedRootData.ContainsKey(variableID))
						{
							cachedReferencedRootData.Add(variableID, null);
						}
						return null;
					}
				}
			}
			int idx = UnityEngine.Random.Range(0, filteredGalaxies.Count);
			if (!cachedReferencedRootData.ContainsKey(variableID))
			{
				cachedReferencedRootData.Add(variableID, filteredGalaxies[idx]);
			}
			property = property.ToUpper();
			if (string.IsNullOrEmpty(property))
			{
				property = "NAME";
			}
			else if (property == "HIDDEN")
			{
				return string.Empty;
			}
			if (text == null)
			{
				List<UniverseNode> placedNodes = UniverseMapManager.Instance.GetPlacedNodes();
				UniverseNode universeNode = placedNodes.FirstOrDefault((UniverseNode x) => x != null && x.GroupKey == filteredGalaxies[idx].GroupKey);
				if (universeNode != null)
				{
					switch (property)
					{
					case "NAME":
						text = universeNode.name;
						break;
					case "INTERNALID":
						text = universeNode.InternalID.ToString();
						break;
					case "GROUPKEY":
						text = universeNode.GroupKey;
						break;
					}
				}
			}
		}
		if (text == null)
		{
			int num2 = 0;
			num2++;
		}
		return text;
	}

	private static List<DataObject> ApplyFilterToList(List<DataObject> sourceList, params string[] filters)
	{
		if (filters != null)
		{
			int num = filters.Length;
			bool flag = false;
			for (int i = 0; i < num; i++)
			{
				if (filters[i].Contains('^'))
				{
					flag = true;
					break;
				}
			}
			int num2 = ((!flag) ? 1 : 2);
			List<DataObject> list = null;
			if (flag)
			{
				list = new List<DataObject>();
				int count = sourceList.Count;
				for (int j = 0; j < count; j++)
				{
					list.Add(sourceList[j]);
				}
			}
			for (int k = 0; k < num2; k++)
			{
				for (int l = 0; l < num; l++)
				{
					string text = filters[l];
					string[] array = text.Split('=');
					if (array.Length != 2 || (k == 1 && array[0][0] == '^'))
					{
						continue;
					}
					bool validIfMissing = false;
					switch (array[0].ToUpper())
					{
					case "VISITED":
						if (array[1].Equals("False", StringComparison.InvariantCultureIgnoreCase))
						{
							validIfMissing = true;
						}
						break;
					}
					List<DataObject> list2 = new List<DataObject>();
					int count2 = sourceList.Count;
					for (int m = 0; m < count2; m++)
					{
						DataObject dataObject = sourceList[m];
						if (dataObject != null && dataObject.IsValidKeyValue(array[0], array[1], validIfMissing))
						{
							list2.Add(dataObject);
						}
					}
					sourceList = list2;
				}
				if (sourceList.Count == 0 && flag && k == 0)
				{
					int count3 = list.Count;
					for (int n = 0; n < count3; n++)
					{
						sourceList.Add(list[n]);
					}
					continue;
				}
				break;
			}
		}
		return sourceList;
	}
}
