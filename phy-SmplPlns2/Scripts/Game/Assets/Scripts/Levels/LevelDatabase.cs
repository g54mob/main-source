using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.SocialPlatforms.Achievements;
using UnityEngine;

namespace Assets.Scripts.Levels
{
	public class LevelDatabase
	{
		private bool _desktop;

		private string _path;

		private bool _quest1;

		private bool _vr;

		public List<LevelInfo> Levels { get; private set; } = new List<LevelInfo>();

		public List<LevelInfo> ModLevels { get; private set; } = new List<LevelInfo>();

		public LevelDatabase(string path, bool isDesktop, bool quest1)
		{
			_path = path;
			_desktop = isDesktop;
			_quest1 = quest1;
			Rebuild(false);
		}

		public LevelInfo GetLevel(string levelId)
		{
			foreach (LevelInfo level in Levels)
			{
				if (level.Id == levelId)
				{
					return level;
				}
			}
			return null;
		}

		public void Rebuild(bool? isVR = null)
		{
			Levels.Clear();
			_vr = isVR ?? _vr;
			LoadXml(_path, _desktop, _vr, _quest1);
			foreach (LevelInfo modLevel in ModLevels)
			{
				Levels.Add(modLevel);
			}
		}

		private List<string> GetPartListFromElement(XElement listElement)
		{
			List<string> list = new List<string>();
			if (listElement != null)
			{
				foreach (XElement item in listElement.Elements("Item"))
				{
					string stringAttribute = item.GetStringAttribute("name", string.Empty);
					list.Add(stringAttribute);
				}
			}
			return list;
		}

		private void LoadXml(string path, bool isDesktop, bool isVR, bool quest1)
		{
			List<string> list = new List<string>();
			if (isVR)
			{
				list.Add("TutFirstSolo");
				list.Add("TutLanding");
				list.Add("DesignerTutorial");
				list.Add("TrainingGroundSchool");
				list.Add("TrainingWeapons");
				list.Add("RaceGlider");
				list.Add("RaceCorkscrew");
				list.Add("LevelShortTakeOff");
				list.Add("LevelGoingTheDistance");
				list.Add("LevelMaxGroundSpeed");
				list.Add("SamEvasion");
				if (quest1)
				{
					list.Add("LevelDogfight");
				}
			}
			if (!isDesktop)
			{
				list.Add("RaceDesert");
				list.Add("RaceVortex");
				list.Add("RaceAdrenaline");
				list.Add("RaceMirage");
			}
			if (quest1)
			{
				list.Add("LevelWW2Dogfight");
				list.Add("LevelWW2Torpedo");
				list.Add("LevelBomberEscort");
			}
			XDocument xDocument = XDocument.Load(path);
			try
			{
				foreach (XElement item in xDocument.Element("Levels").Elements("Level"))
				{
					LevelInfo levelInfo = new LevelInfo();
					levelInfo.Name = item.Attribute("name").Value;
					levelInfo.MapName = ((string)item.Attribute("mapName")) ?? "Default Map";
					levelInfo.ModName = null;
					levelInfo.SkipDesigner = item.GetBoolAttribute("skipDesigner");
					levelInfo.DisplayInMenu = item.GetBoolAttribute("displayInMenu", defaultValue: true);
					levelInfo.Id = item.Attribute("id").Value;
					levelInfo.Prefab = item.Attribute("prefab").Value;
					levelInfo.Description = item.Attribute("description").Value;
					levelInfo.Category = item.Attribute("category").Value;
					levelInfo.CarRace = item.GetBoolAttribute("carRace");
					levelInfo.Locked = !Game.Instance.Settings.Cloud.Activities.Unlocked.Contains(levelInfo.Id) && (bool?)item.Attribute("locked") == true;
					string value = (string)item.Attribute("achievementKey");
					levelInfo.AchievementKey = (string.IsNullOrEmpty(value) ? ((AchievementKey?)null) : ((AchievementKey?)Enum.Parse(typeof(AchievementKey), value)));
					levelInfo.Description = levelInfo.Description.Replace("\\n", "\n");
					string stringAttribute = item.GetStringAttribute("restrictedCategories", string.Empty);
					if (!string.IsNullOrEmpty(stringAttribute))
					{
						string[] array = stringAttribute.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
						foreach (string text in array)
						{
							levelInfo.RestrictedCategories.Add(text.Trim());
						}
					}
					levelInfo.RestrictedDesignerParts.AddRange(GetPartListFromElement(item.Element("RestrictedDesignerParts")));
					levelInfo.RestrictedPartIds.AddRange(GetPartListFromElement(item.Element("RestrictedPartIds")));
					levelInfo.RestrictedModifiers.AddRange(GetPartListFromElement(item.Element("RestrictedModifiers")));
					if (!list.Contains(levelInfo.Id) && (isVR || !levelInfo.Id.StartsWith("VR")))
					{
						Levels.Add(levelInfo);
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				throw new Exception("Failed to parse levels XML.");
			}
		}
	}
}
