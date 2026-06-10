using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace NSMedieval.UI.Statistic
{
	public class StatsView : UIView
	{
		[SerializeField]
		private LayoutGroupView xAxisGroupView;

		[SerializeField]
		private LayoutGroupView yAxisGroupView;

		[SerializeField]
		private LayoutGroupView graphGroupView;

		[SerializeField]
		private UIGridRenderer gridRenderer;

		[SerializeField]
		private LayoutGroupView legendGroupView;

		[SerializeField]
		private LayoutGroupView statsGroupView;

		[SerializeField]
		private TMP_Dropdown categoryDropdown;

		[SerializeField]
		private int[] steps;

		private readonly List<BasicLayoutItemView> xGraphValues = new List<BasicLayoutItemView>();

		private readonly List<BasicLayoutItemView> yGraphValues = new List<BasicLayoutItemView>();

		private readonly List<ButtonLayoutItemView> legendEntries = new List<ButtonLayoutItemView>();

		private readonly List<BasicLayoutItemView> lineRenderers = new List<BasicLayoutItemView>();

		private readonly List<BasicLayoutItemView> statEntries = new List<BasicLayoutItemView>();

		private int currentCategory;

		private float xScale;

		private float yScale;

		private void Awake()
		{
			Rect rect = graphGroupView.GetComponent<RectTransform>().rect;
			xScale = rect.width;
			yScale = rect.height;
		}

		private void Start()
		{
			categoryDropdown.ClearOptions();
			List<string> list = new List<string>();
			StatisticGraphCategory[] statisticGraphCategories = EnumValues.StatisticGraphCategories;
			for (int i = 0; i < statisticGraphCategories.Length; i++)
			{
				switch (statisticGraphCategories[i])
				{
				case StatisticGraphCategory.Population:
					list.Add(base.Localize.GetText("PopulationCount_title"));
					break;
				case StatisticGraphCategory.Wealth:
					list.Add(base.Localize.GetText("TotalWealth_title"));
					break;
				case StatisticGraphCategory.Food:
					list.Add(base.Localize.GetText("FoodAmount_title"));
					break;
				case StatisticGraphCategory.Mood:
					list.Add(base.Localize.GetText("MoodAverage_title"));
					break;
				default:
					throw new ArgumentOutOfRangeException();
				case StatisticGraphCategory.Influence:
					break;
				}
			}
			categoryDropdown.AddOptions(list);
			categoryDropdown.onValueChanged.AddListener(OnCategoryChanged);
		}

		public override void Show()
		{
			base.Show();
			categoryDropdown.value = currentCategory;
			OnCategoryChanged(currentCategory);
			UpdateStatEntries();
		}

		private void UpdateStatEntries()
		{
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			HistoricalRecordsManager instance = MonoSingleton<HistoricalRecordsManager>.Instance;
			statEntries.SetAllActive(active: false);
			foreach (string item in new List<string>
			{
				base.Localize.GetText("menu_village_name") + ": <style=AltColor>" + currentVillageData.Name + "</style>",
				base.Localize.GetText("scenario_map_type") + ": <style=AltColor>" + base.Localize.GetText(currentVillageData.MapTypeID) + "</style>",
				base.Localize.GetText("map_seed") + ": <style=AltColor>" + GlobalSaveController.CurrentVillageData.MapSeed + "</style>",
				string.Empty,
				string.Empty,
				base.Localize.GetText("play_time") + ": <style=AltColor>" + instance.GetTime(),
				string.Format("{0}: <style=AltColor>{1}", base.Localize.GetText("days_from_start"), currentVillageData.DateAndTime.DaysTotal),
				string.Empty,
				string.Empty,
				string.Format("{0}: <style=AltColor>{1}", base.Localize.GetText("number_of_villagers"), WorkerManager.WorkersEverywhere.Count()),
				string.Format("{0}: <style=AltColor>{1}</style>", base.Localize.GetText("lost_villagers"), instance.SaveStats.LostVillagers),
				string.Format("{0}: <style=AltColor>{1}</style>", base.Localize.GetText("max_villagers"), instance.SaveStats.MaxVillagers),
				string.Empty,
				string.Format("{0}: <style=AltColor>{1}</style>", base.Localize.GetText("raids_won"), instance.SaveStats.RaidsWon),
				string.Format("{0}: <style=AltColor>{1}</style>", base.Localize.GetText("raids_lost"), instance.SaveStats.RaidsLost),
				string.Empty,
				string.Format("{0}: <style=AltColor>{1}</style>", base.Localize.GetText("enemies_killed"), instance.SaveStats.EnemiesKilled),
				string.Empty
			})
			{
				statEntries.GetNext(statsGroupView).SetText(item);
			}
		}

		private void OnCategoryChanged(int value)
		{
			currentCategory = value;
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			List<GraphData> list = new List<GraphData>();
			switch (value)
			{
			case 0:
				list.Add(currentVillageData.StatisticsGraphs.FirstOrDefault((GraphData data) => data.GraphType == StatisticGraphType.PopulationCount));
				break;
			case 1:
				list.Add(currentVillageData.StatisticsGraphs.FirstOrDefault((GraphData data) => data.GraphType == StatisticGraphType.BuildingWealth));
				list.Add(currentVillageData.StatisticsGraphs.FirstOrDefault((GraphData data) => data.GraphType == StatisticGraphType.ResourceWealth));
				list.Add(currentVillageData.StatisticsGraphs.FirstOrDefault((GraphData data) => data.GraphType == StatisticGraphType.TotalWealth));
				break;
			case 2:
				list.Add(currentVillageData.StatisticsGraphs.FirstOrDefault((GraphData data) => data.GraphType == StatisticGraphType.FoodAmount));
				break;
			case 3:
				list.Add(currentVillageData.StatisticsGraphs.FirstOrDefault((GraphData data) => data.GraphType == StatisticGraphType.MoodAverage));
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case 4:
				break;
			}
			CreateGraphs(list);
		}

		private void CreateGraphs(List<GraphData> graphs)
		{
			if (graphs == null || graphs.Count == 0)
			{
				return;
			}
			lineRenderers.SetAllActive(active: false);
			legendEntries.SetAllActive(active: false);
			List<float> list = new List<float>();
			foreach (GraphData graph in graphs)
			{
				list.AddRange(graph.NodeValues);
			}
			float max = GetMax(list);
			GetMin(list);
			int count = graphs[0].NodeValues.Count;
			int step = GetStep(count, 20);
			int num = step - count % step;
			int step2 = GetStep(max, 10);
			int num2 = (int)((float)step2 - max % (float)step2);
			Vector2Int correctedMaxValues = new Vector2Int(count + num, (int)max + num2);
			foreach (GraphData graph2 in graphs)
			{
				GraphView component = lineRenderers.GetNext(graphGroupView).GetComponent<GraphView>();
				component.CreateGraph(graph2, correctedMaxValues);
				ButtonLayoutItemView next = legendEntries.GetNext(legendGroupView);
				next.TextObject.SetText(base.Localize.GetText($"{graph2.GraphType}_title"));
				next.ButtonIcon.color = graph2.GraphColor;
				next.Button.AddCleanListener(component.Toggle);
				next.TooltipNew.ClearLines();
				next.TooltipNew.AppendLine(base.Localize.GetText($"{graph2.GraphType}_title"), TooltipStyles.TooltipTitle);
				next.TooltipNew.AppendLine(base.Localize.GetText($"{graph2.GraphType}_info"));
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(legendGroupView.GetComponent<RectTransform>());
			int num3 = (count + num) / step;
			gridRenderer.GridColumns = num3;
			int num4 = (int)((max + (float)num2) / (float)step2);
			gridRenderer.GridRows = num4;
			xGraphValues.SetAllActive(active: false);
			xAxisGroupView.GetComponent<HorizontalLayoutGroup>().spacing = xScale / (float)num3 - xAxisGroupView.Prefab.GetComponent<RectTransform>().rect.width;
			for (int i = 0; i <= num3; i++)
			{
				xGraphValues.GetNext(xAxisGroupView).SetText($"{i * step}");
			}
			yGraphValues.SetAllActive(active: false);
			yAxisGroupView.GetComponent<VerticalLayoutGroup>().spacing = yScale / (float)num4 - yAxisGroupView.Prefab.GetComponent<RectTransform>().rect.height;
			for (int num5 = num4; num5 >= 0; num5--)
			{
				BasicLayoutItemView next2 = yGraphValues.GetNext(yAxisGroupView);
				string text = $"{num5 * step2}";
				if (num5 == 0)
				{
					text = string.Empty;
				}
				next2.SetText(text);
			}
		}

		private float GetMin(List<float> values)
		{
			float num = 2.1474836E+09f;
			foreach (float value in values)
			{
				num = ((value < num) ? value : num);
			}
			return num;
		}

		private float GetMax(List<float> values)
		{
			float num = -2.1474836E+09f;
			foreach (float value in values)
			{
				num = ((value > num) ? value : num);
			}
			return Mathf.Ceil(num);
		}

		private int GetStep(float value, int maxSteps)
		{
			int[] array = steps;
			foreach (int num in array)
			{
				if ((double)(value / (float)maxSteps) * 1.5 <= (double)num)
				{
					return num;
				}
			}
			return steps.Last();
		}

		private void OnEnable()
		{
			MonoSingleton<HistoricalRecordsManager>.Instance.TimerUpdateEvent += OnTimerUpdate;
		}

		private void OnDisable()
		{
			if (MonoSingleton<HistoricalRecordsManager>.IsInstantiated())
			{
				MonoSingleton<HistoricalRecordsManager>.Instance.TimerUpdateEvent -= OnTimerUpdate;
			}
		}

		private void OnTimerUpdate()
		{
			UpdateStatEntries();
		}
	}
}
