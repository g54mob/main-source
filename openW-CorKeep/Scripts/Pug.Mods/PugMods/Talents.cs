using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PugMods
{
	public static class Talents
	{
		[Serializable]
		private class TalentModFile
		{
			public SkillID skill;

			public List<Talent> talents;
		}

		[Serializable]
		private struct Talent
		{
			public string name;

			public ConditionID givesCondition;

			public int conditionValuePerPoint;
		}

		public static void Init(SkillTalentsTable talentsTable)
		{
			List<TalentModFile> talentList = GetTalentList(talentsTable);
			foreach (string confFolder in Config.ConfFolders)
			{
				UpdateFromFiles(confFolder, talentList);
			}
			foreach (TalentModFile item in talentList)
			{
				int i;
				for (i = 0; i < talentsTable.skillTalentTrees.Count && talentsTable.skillTalentTrees[i].skillID != item.skill; i++)
				{
				}
				if (i == talentsTable.skillTalentTrees.Count)
				{
					talentsTable.skillTalentTrees.Add(new SkillTalentsTable.SkillTalentTree
					{
						skillID = item.skill,
						skillTalents = new List<SkillTalentsTable.SkillTalentInfo>()
					});
				}
				SkillTalentsTable.SkillTalentTree value = talentsTable.skillTalentTrees[i];
				for (int j = 0; j < item.talents.Count; j++)
				{
					SkillTalentsTable.SkillTalentInfo skillTalentInfo;
					if (j >= value.skillTalents.Count)
					{
						skillTalentInfo = default(SkillTalentsTable.SkillTalentInfo);
						value.skillTalents.Add(skillTalentInfo);
					}
					else
					{
						skillTalentInfo = value.skillTalents[j];
					}
					Talent talent = item.talents[j];
					skillTalentInfo.name = talent.name;
					skillTalentInfo.givesCondition = talent.givesCondition;
					skillTalentInfo.conditionValuePerPoint = talent.conditionValuePerPoint;
					value.skillTalents[j] = skillTalentInfo;
				}
				talentsTable.skillTalentTrees[i] = value;
			}
		}

		private static void UpdateFromFiles(string directoryPath, List<TalentModFile> talentModList)
		{
			string path = directoryPath + "/Talents";
			if (!Directory.Exists(path))
			{
				return;
			}
			foreach (string item in Directory.EnumerateFiles(path, "*.json"))
			{
				try
				{
					string json = File.ReadAllText(item);
					TalentModFile talentModFile = new TalentModFile();
					JsonUtility.FromJsonOverwrite(json, talentModFile);
					if (talentModFile.talents.Count == 0)
					{
						Debug.Log("Skipping empty talent mod " + item);
						continue;
					}
					int i;
					for (i = 0; i < talentModList.Count; i++)
					{
						if (talentModFile.skill == talentModList[i].skill)
						{
							if (Config.ExtraLog)
							{
								Debug.Log($"Updating {talentModFile.skill} talents with values from {item}");
							}
							talentModList[i] = talentModFile;
							break;
						}
					}
					if (i == talentModList.Count)
					{
						if (Config.ExtraLog)
						{
							Debug.Log($"Adding {talentModFile.skill} talents from {item}");
						}
						talentModList.Add(talentModFile);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private static List<TalentModFile> GetTalentList(SkillTalentsTable talentsTable)
		{
			List<TalentModFile> list = new List<TalentModFile>();
			foreach (SkillTalentsTable.SkillTalentTree skillTalentTree in talentsTable.skillTalentTrees)
			{
				TalentModFile talentModFile = new TalentModFile
				{
					skill = skillTalentTree.skillID,
					talents = new List<Talent>()
				};
				foreach (SkillTalentsTable.SkillTalentInfo skillTalent in skillTalentTree.skillTalents)
				{
					talentModFile.talents.Add(new Talent
					{
						name = skillTalent.name,
						givesCondition = skillTalent.givesCondition,
						conditionValuePerPoint = skillTalent.conditionValuePerPoint
					});
				}
				list.Add(talentModFile);
			}
			return list;
		}
	}
}
