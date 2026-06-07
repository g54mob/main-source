using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.InfoHandles;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class InformationPanel : UIPanel
	{
		public static InformationPanel Instance;

		public WedgeInfo[] countInfos = new WedgeInfo[4]
		{
			new WedgeInfo
			{
				label = "Bibites",
				color = Color.white
			},
			new WedgeInfo
			{
				label = "Eggs",
				color = new Color(71f / 85f, 0.8431373f, 0.8431373f)
			},
			new WedgeInfo
			{
				label = "Plants",
				color = new Color(0.1529412f, 0.6745098f, 0.1333333f)
			},
			new WedgeInfo
			{
				label = "Meats",
				color = new Color(0.8431373f, 0.1490196f, 0.2392157f)
			}
		};

		public WedgeInfo[] energyInfos = new WedgeInfo[5]
		{
			new WedgeInfo
			{
				label = "Free",
				color = new Color(0.6665637f, 0.735849f, 0.253382f)
			},
			new WedgeInfo
			{
				label = "Bibites",
				color = Color.white
			},
			new WedgeInfo
			{
				label = "Eggs",
				color = new Color(71f / 85f, 0.8431373f, 0.8431373f)
			},
			new WedgeInfo
			{
				label = "Plants",
				color = new Color(0.1529412f, 0.6745098f, 0.1333333f)
			},
			new WedgeInfo
			{
				label = "Meats",
				color = new Color(0.8431373f, 0.1490196f, 0.2392157f)
			}
		};

		public int pelletNumber;

		public int plantNumber;

		public int meatNumber;

		public int bibiteNumber;

		public float plantBiomass;

		public float meatBiomass;

		public float freeBiomass;

		public float bibiteBiomass;

		[SerializeField]
		private GameObject countSection;

		[SerializeField]
		private GameObject energySection;

		[SerializeField]
		private WedgeInfoHandle totalCount;

		[SerializeField]
		private WedgeInfoHandle bibiteCount;

		[SerializeField]
		private WedgeInfoHandle eggCount;

		[SerializeField]
		private WedgeInfoHandle plantCount;

		[SerializeField]
		private WedgeInfoHandle meatCount;

		[SerializeField]
		private PieChartHandle countPieChart;

		[SerializeField]
		private WedgeInfoHandle totalEnergy;

		[SerializeField]
		private WedgeInfoHandle unusedEnergy;

		[SerializeField]
		private WedgeInfoHandle bibiteEnergy;

		[SerializeField]
		private WedgeInfoHandle eggEnergy;

		[SerializeField]
		private WedgeInfoHandle plantEnergy;

		[SerializeField]
		private WedgeInfoHandle meatEnergy;

		[SerializeField]
		private PieChartHandle energyPieChart;

		[SerializeField]
		private Transform tagsInfoHolder;

		[SerializeField]
		private LayoutElement tagSection;

		[SerializeField]
		private GameObject tagItemPrefab;

		private List<TagElementHandle> tagItems = new List<TagElementHandle>();

		[SerializeField]
		private Transform speciesInfoHolder;

		[SerializeField]
		private LayoutElement speciesSection;

		[SerializeField]
		private FloatValueTextHandle NTopSpecies;

		[SerializeField]
		private FloatValueTextHandle NSpecies;

		[SerializeField]
		private GameObject speciesItemPrefab;

		private List<SpeciesInfoHandle> speciesItems = new List<SpeciesInfoHandle>();

		public DataPoint3 GetCountData(bool peek)
		{
			return new DataPoint3(bibiteNumber, plantNumber, meatNumber);
		}

		public DataPoint4 GetBiomassData(bool peek)
		{
			return new DataPoint4(bibiteBiomass, plantBiomass, meatBiomass, freeBiomass);
		}

		public override void InitPanel()
		{
			Instance = this;
			for (int i = 1; i < 6; i++)
			{
				SpeciesInfoHandle component = Object.Instantiate(speciesItemPrefab, speciesInfoHolder).GetComponent<SpeciesInfoHandle>();
				component.UpdateIndex(i);
				speciesItems.Add(component);
			}
			totalCount.InitWedgeInfo(new WedgeInfo("Total", Color.clear), "", 0);
			bibiteCount.InitWedgeInfo(countInfos[0], "", 0);
			eggCount.InitWedgeInfo(countInfos[1], "", 0);
			plantCount.InitWedgeInfo(countInfos[2], "", 0);
			meatCount.InitWedgeInfo(countInfos[3], "", 0);
			countPieChart.InitChart(countInfos);
			totalEnergy.InitWedgeInfo(new WedgeInfo("Total", Color.clear), "E", 0);
			unusedEnergy.InitWedgeInfo(energyInfos[0], "E", 0);
			bibiteEnergy.InitWedgeInfo(energyInfos[1], "E", 0);
			eggEnergy.InitWedgeInfo(energyInfos[2], "E", 0);
			plantEnergy.InitWedgeInfo(energyInfos[3], "E", 0);
			meatEnergy.InitWedgeInfo(energyInfos[4], "E", 0);
			energyPieChart.InitChart(energyInfos);
		}

		public void UpdateInformation(int newPlantCount, int newMeatCount, int newBibiteCount, int newEggCount, float pelletSpawnerE, float pelletE, float bibiteE, float eggE, float plantE, float meatE, Dictionary<string, TagInfo> tags)
		{
			float val = pelletSpawnerE + bibiteE + eggE + meatE + plantE;
			bibiteNumber = newEggCount + newBibiteCount;
			plantNumber = newPlantCount;
			meatNumber = newMeatCount;
			pelletNumber = newPlantCount + newMeatCount;
			bibiteBiomass = bibiteE;
			plantBiomass = plantE;
			meatBiomass = meatE;
			freeBiomass = pelletSpawnerE;
			totalCount.UpdateValue(newBibiteCount + newPlantCount + newEggCount + newMeatCount);
			bibiteCount.UpdateValue(newBibiteCount);
			eggCount.UpdateValue(newEggCount);
			plantCount.UpdateValue(newPlantCount);
			meatCount.UpdateValue(newMeatCount);
			countPieChart.UpdateValues(new float[4] { newBibiteCount, newEggCount, newPlantCount, newMeatCount });
			totalEnergy.UpdateValue(val);
			unusedEnergy.UpdateValue(pelletSpawnerE);
			bibiteEnergy.UpdateValue(bibiteE);
			eggEnergy.UpdateValue(eggE);
			plantEnergy.UpdateValue(plantE);
			meatEnergy.UpdateValue(meatE);
			energyPieChart.UpdateValues(new float[5] { pelletSpawnerE, bibiteE, eggE, plantE, meatE });
			List<TagElementHandle> list = tagItems.ToList();
			foreach (KeyValuePair<string, TagInfo> tagPair in tags)
			{
				TagElementHandle tagElementHandle = tagItems.FirstOrDefault((TagElementHandle t) => t.TagText == tagPair.Key);
				if (tagElementHandle == null)
				{
					tagElementHandle = Object.Instantiate(tagItemPrefab, tagsInfoHolder).GetComponent<TagElementHandle>();
					tagElementHandle.InitTagElement(tagPair.Key);
					tagElementHandle.UpdateInfo(tagPair.Value);
					tagItems.Add(tagElementHandle);
				}
				else
				{
					tagElementHandle.UpdateInfo(tagPair.Value);
					list.Remove(tagElementHandle);
				}
			}
			foreach (TagElementHandle item in list.ToList())
			{
				tagItems.Remove(item);
				Object.Destroy(item.gameObject);
			}
			int num = Mathf.Min(7, tagItems.Count);
			tagSection.preferredHeight = 15f + 30f * (float)num;
			int num2 = 1;
			foreach (TagElementHandle item2 in tagItems.OrderByDescending((TagElementHandle t) => (!countSection.activeSelf) ? t.energy : ((float)t.count)))
			{
				item2.transform.SetAsLastSibling();
				item2.UpdateIndex(num2);
				num2++;
			}
			int num3 = 0;
			foreach (Species item3 in GlobalLineageManager.Instance.activeSpecies.OrderByDescending((Species t) => (!countSection.activeSelf) ? t.energy : ((float)t.count)).Take(5))
			{
				SpeciesInfoHandle speciesInfoHandle = speciesItems[num3];
				if (item3.count < 1)
				{
					break;
				}
				speciesInfoHandle.gameObject.SetActive(value: true);
				speciesInfoHandle.InitElement(item3);
				speciesInfoHandle.UpdateInfo();
				num3++;
			}
			NTopSpecies.UpdateValue(num3);
			NSpecies.UpdateValue(GlobalLineageManager.Instance.activeSpecies.Count((Species s) => s.count > 0));
			for (; num3 < 5; num3++)
			{
				speciesItems[num3].gameObject.SetActive(value: false);
			}
		}

		public int GetCountOfTag(string tagName)
		{
			TagElementHandle tagElementHandle = tagItems.FirstOrDefault((TagElementHandle i) => i.TagText == tagName);
			if (!(tagElementHandle == null))
			{
				return tagElementHandle.count;
			}
			return 0;
		}
	}
}
