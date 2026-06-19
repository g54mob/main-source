using System;
using System.Collections.Generic;
using System.IO;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugMods
{
	public static class Factions
	{
		[Serializable]
		private class FactionModFile
		{
			public FactionID faction;

			public List<FactionID> attacksFactions;
		}

		public static void Init(BooleanMatrix factionsLookup)
		{
			List<FactionModFile> factionList = GetFactionList(factionsLookup);
			foreach (string confFolder in Config.ConfFolders)
			{
				UpdateFromFiles(confFolder, factionList);
			}
			factionsLookup.Resize(factionList.Count, valueDefault: false, valueKeep: false);
			for (int i = 0; i < factionsLookup.Length; i++)
			{
				foreach (FactionID attacksFaction in factionList[i].attacksFactions)
				{
					for (int j = 0; j < factionsLookup.Length; j++)
					{
						if (attacksFaction == factionList[j].faction)
						{
							factionsLookup[j, i] = true;
							break;
						}
					}
				}
			}
		}

		private static void UpdateFromFiles(string directoryPath, List<FactionModFile> factionModList)
		{
			string path = directoryPath + "/Factions";
			if (!Directory.Exists(path))
			{
				return;
			}
			foreach (string item in Directory.EnumerateFiles(path, "*.json"))
			{
				try
				{
					string json = File.ReadAllText(item);
					FactionModFile factionModFile = new FactionModFile();
					JsonUtility.FromJsonOverwrite(json, factionModFile);
					if (factionModFile.faction == FactionID.None)
					{
						Debug.Log("Skipping faction mod " + item + " with faction None (0)");
						continue;
					}
					int i;
					for (i = 0; i < factionModList.Count; i++)
					{
						if (factionModFile.faction == factionModList[i].faction)
						{
							if (Config.ExtraLog)
							{
								Debug.Log($"Updating faction {factionModFile.faction} with values from {item}");
							}
							factionModList[i].attacksFactions.Clear();
							factionModList[i].attacksFactions.AddRange(factionModFile.attacksFactions);
							break;
						}
					}
					if (i == factionModList.Count)
					{
						if (Config.ExtraLog)
						{
							Debug.Log($"Adding faction {factionModFile.faction} from {item}");
						}
						factionModList.Add(factionModFile);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private static List<FactionModFile> GetFactionList(BooleanMatrix factionsLookup)
		{
			List<FactionModFile> list = new List<FactionModFile>();
			for (int i = 0; i < factionsLookup.Length; i++)
			{
				FactionModFile item = new FactionModFile
				{
					faction = (FactionID)i,
					attacksFactions = new List<FactionID>()
				};
				list.Add(item);
			}
			for (int j = 0; j < list.Count; j++)
			{
				FactionModFile factionModFile = list[j];
				for (int k = 0; k < list.Count; k++)
				{
					if (factionsLookup[k, j])
					{
						factionModFile.attacksFactions.Add(list[k].faction);
					}
				}
			}
			return list;
		}
	}
}
