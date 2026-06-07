using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using SettingScripts;
using SteamIntegrations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts.UIReferences
{
	public class ScenarioItemReference : MonoBehaviour
	{
		[NonSerialized]
		public FileInfo info;

		private string localPath;

		[SerializeField]
		private TextMeshProUGUI scenarioNameField;

		[SerializeField]
		private TextMeshProUGUI scenarioVersion;

		[SerializeField]
		private GameObject officialIcon;

		[SerializeField]
		private GameObject nonOfficialIcon;

		[SerializeField]
		private GameObject workshopIcon;

		[SerializeField]
		private TooltipTrigger workshopTooltip;

		[SerializeField]
		private GameObject starsSection;

		[SerializeField]
		private List<Image> stars;

		private ScenarioSelectorPanel user;

		[NonSerialized]
		public string scenarioName;

		[NonSerialized]
		public bool isOfficial;

		[NonSerialized]
		public bool isChallenge;

		[NonSerialized]
		public bool isExternal;

		[NonSerialized]
		public bool isShared;

		[NonSerialized]
		public int rank = 1073741823;

		public WorkshopItem workshopItem;

		public bool InitScenarioItemAsExternalWorkshopItem(FileInfo file, ScenarioSelectorPanel userOfItem, WorkshopItem workshopItem)
		{
			this.workshopItem = workshopItem;
			isExternal = this.workshopItem != null;
			return InitScenarioItem(file, userOfItem);
		}

		public bool InitScenarioItem(FileInfo file, ScenarioSelectorPanel userOfItem)
		{
			info = file;
			user = userOfItem;
			localPath = Path.Combine(ScenarioSelectorPanel.DefaultSimulationSettingsPath, info.Name);
			using (ZipArchive zipArchive = ZipFile.Open(info.FullName, ZipArchiveMode.Read))
			{
				JObject jObject = SaveSystem.ReadJObjectFromArchive(zipArchive.GetEntry("scenario.info"));
				scenarioName = jObject["name"].ToString();
				if (jObject["isOfficial"] != null)
				{
					isOfficial = jObject["isOfficial"].ToObject<bool>() && GameManager.defaultScenarios.Contains(scenarioName.ToLower());
				}
				if (jObject["version"] == null || !Utility.Version.CanParse(jObject["version"].ToString()) || Utility.Version.Parse(jObject["version"].ToString()) < new Utility.Version(0, 5, 1))
				{
					return false;
				}
				if (jObject["rank"] != null)
				{
					rank = jObject["rank"].ToObject<int>();
				}
				if (jObject["isChallenge"] != null)
				{
					isChallenge = jObject["isChallenge"].ToObject<bool>();
					int starOfChallenge = ChallengesProgress.GetStarOfChallenge(scenarioName);
					starsSection.SetActive(value: true);
					for (int i = 0; i < 3; i++)
					{
						stars[i].color = ((i < starOfChallenge) ? ChallengesProgress.unlockedStarColor : ChallengesProgress.lockedStarColor);
					}
				}
				else
				{
					starsSection.SetActive(value: false);
				}
				officialIcon.SetActive(isOfficial && !isExternal);
				nonOfficialIcon.SetActive(!isOfficial && !isExternal);
				workshopIcon.SetActive(isExternal);
				if (isExternal)
				{
					workshopTooltip.UpdateText(null, "This scenario comes from one of the workshop items you subscribe to:\n" + workshopItem.title + " by " + workshopItem.creatorName);
				}
				else
				{
					workshopItem = ((SteamWorkshopManager.instance != null) ? SteamWorkshopManager.instance.GetSharedItem(localPath) : null);
					if (workshopItem != null)
					{
						isShared = true;
					}
				}
				scenarioNameField.text = scenarioName;
				scenarioVersion.text = SaveSystem.GetVersionOfFile(jObject).ToString();
			}
			return true;
		}

		public void SelectScenario()
		{
			user.SelectScenarioItem(this);
		}
	}
}
