using System;
using System.Collections.Generic;
using System.Linq;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.InfoHandles;
using UIScripts.SettingHandles;
using UnityEngine;
using Utility;

namespace UIScripts
{
	public class SpeciesDistributionPanel : UIPanel
	{
		private Species targetSpecies;

		private LogLikeSpeciesDataArray data;

		public SimZonePreviewer zonePreviewer;

		public SpeciesDistributionItem distributionPreview;

		public GameObject speciesNotAroundDisclaimer;

		public TextMeshProUGUI possibleZonePresenceText;

		public LogLikeTimeSpanSlider timeSlider;

		[NonSerialized]
		public int timeIndex;

		private int min;

		private int max;

		public override void InitPanel()
		{
			base.InitPanel();
			zonePreviewer.InitPreview();
			timeSlider.SetConfig(DataLogger.SerialSpeciesConfig);
			timeSlider.onTimeIndexChange.AddListener(UpdateSelectedTime);
			distributionPreview.Initialize();
		}

		public void SelectSpecies(Species species)
		{
			targetSpecies = species;
			data = species.speciesData;
			FillPanel();
		}

		public override void FillPanel()
		{
			base.FillPanel();
			int totalIndexOfDisappearance = targetSpecies.speciesData.totalIndexOfDisappearance;
			min = ((totalIndexOfDisappearance < 0) ? (-1) : (totalIndexOfDisappearance + 1));
			max = targetSpecies.speciesData.totalIndexOfApparition;
			timeSlider.SetMinMax(min, max);
			UpdateSelectedTime(timeSlider.value);
		}

		public void UpdateSelectedTime(int time)
		{
			if (data == null)
			{
				return;
			}
			timeIndex = time;
			SpeciesDataPoint point = ((timeIndex < 0) ? new SpeciesDataPoint(targetSpecies) : data[timeIndex]);
			List<ZoneSettings> allZones = ScenarioSettings.Instance.allZones;
			zonePreviewer.UpdateSettings(allZones, timeIndex);
			bool flag = point.count > 2 && point.posStdDev.x > 0f;
			speciesNotAroundDisclaimer.SetActive(!flag);
			distributionPreview.gameObject.SetActive(flag);
			if (!flag)
			{
				possibleZonePresenceText.text = "Unknown";
				return;
			}
			distributionPreview.UpdatePoint(point);
			List<ZoneMatch> list = new List<ZoneMatch>();
			foreach (ZoneSettings item in allZones)
			{
				ZoneMatch overlapWithZone = distributionPreview.GetOverlapWithZone(item);
				if (overlapWithZone.overlap > 0.15f)
				{
					list.Add(overlapWithZone);
				}
			}
			string text = "";
			bool flag2 = true;
			foreach (ZoneMatch item2 in list.OrderByDescending((ZoneMatch m) => m.overlap).Take(5))
			{
				text += string.Format("{0}-{1} ({2:F0}%)", flag2 ? "" : "\n", item2.zone.zoneName.val, item2.overlap * 100f);
				flag2 = false;
			}
			possibleZonePresenceText.text = (string.IsNullOrEmpty(text) ? "None" : text);
		}
	}
}
