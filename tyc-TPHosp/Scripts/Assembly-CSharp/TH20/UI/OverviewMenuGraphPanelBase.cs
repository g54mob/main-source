using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20.UI
{
	[Serializable]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class OverviewMenuGraphPanelBase : OverviewMenuTabPanel, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Serializable]
		public class GraphStatDefinition
		{
			[SerializeField]
			public LevelStatsDatabase.Stat Stat;

			[SerializeField]
			public double MinValue = -100.0;

			[SerializeField]
			public double MaxValue = 100.0;

			[SerializeField]
			public PanelItemGraph Graph;

			[NonSerialized]
			[HideInInspector]
			public List<LineGraph.DataVector2> CachedMonthlyGraphData = new List<LineGraph.DataVector2>(12);

			[NonSerialized]
			[HideInInspector]
			public List<LineGraph.DataVector2> CachedYearlyGraphData = new List<LineGraph.DataVector2>(12);

			[NonSerialized]
			[HideInInspector]
			public List<LineGraph.DataVector2> CachedQuarterlyGraphData = new List<LineGraph.DataVector2>(12);

			private string _queryMonthAssertText = "MonthStats.QueryAsDouble does not support {0} stat";

			private LevelStatsDatabase _levelStatsDatabase;

			private static readonly List<LevelStatsDatabase.MonthStats> _cachedMonthStats = new List<LevelStatsDatabase.MonthStats>(32);

			private static readonly List<LevelStatsDatabase.YearStats> _cachedYearStats = new List<LevelStatsDatabase.YearStats>(12);

			private void AppendCompletedMonthStats(int months, List<LineGraph.DataVector2> graphData)
			{
				if (_levelStatsDatabase == null)
				{
					return;
				}
				_levelStatsDatabase.GetPreviousMonthlyStatsAscendingOrder(months, _cachedMonthStats);
				foreach (LevelStatsDatabase.MonthStats cachedMonthStat in _cachedMonthStats)
				{
					cachedMonthStat.QueryAsDouble(Stat, out var value);
					graphData.Add(new LineGraph.DataVector2(cachedMonthStat.EndGameDate.AsTotalMonths(), value));
					Graph.MinYValue = Math.Min(Graph.MinYValue, value);
					Graph.MaxYValue = Math.Max(Graph.MaxYValue, value);
				}
			}

			private void AppendCompletedYearStats(int years, List<LineGraph.DataVector2> graphData)
			{
				if (_levelStatsDatabase == null)
				{
					return;
				}
				_levelStatsDatabase.GetPreviousYearlyStatsAscendingOrder(years, _cachedYearStats);
				foreach (LevelStatsDatabase.YearStats cachedYearStat in _cachedYearStats)
				{
					cachedYearStat.QueryAsDouble(Stat, out var value);
					graphData.Add(new LineGraph.DataVector2(cachedYearStat.EndGameDate.Year, value));
					Graph.MinYValue = Math.Min(Graph.MinYValue, value);
					Graph.MaxYValue = Math.Max(Graph.MaxYValue, value);
				}
			}

			public void BuildDataFromStat(LevelStatsDatabase levelStatsDatabase, double monthsPassed, bool yearEnd)
			{
				_levelStatsDatabase = levelStatsDatabase;
				if (Stat != LevelStatsDatabase.Stat.None)
				{
					_cachedMonthStats.Clear();
					_cachedYearStats.Clear();
					CachedMonthlyGraphData.Clear();
					CachedYearlyGraphData.Clear();
					Graph.MinYValue = Math.Min(Graph.MinYValue, MinValue);
					Graph.MaxYValue = Math.Max(Graph.MaxYValue, MaxValue);
					AppendCompletedMonthStats(12, CachedMonthlyGraphData);
					AppendCompletedYearStats(12, CachedYearlyGraphData);
					_cachedMonthStats.Clear();
					CachedQuarterlyGraphData.Clear();
					AppendCompletedMonthStats(3, CachedQuarterlyGraphData);
				}
			}

			public void AssignDataToGraphs()
			{
				if ((bool)Graph && Stat != LevelStatsDatabase.Stat.None)
				{
					Graph.AssignMonthlyData(CachedMonthlyGraphData);
					Graph.AssignQuarterlyData(CachedQuarterlyGraphData);
					Graph.AssignYearlyData(CachedYearlyGraphData);
				}
			}
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		private class GraphDefaults
		{
			public GraphDisplayMode graphDisplayMode;

			public PanelItemToggleButton[] EnabledButtons;
		}

		[SerializeField]
		private RectTransform _pickerObject;

		[SerializeField]
		private Image _pickerInner;

		[SerializeField]
		private TMP_Text _pickerText;

		[SerializeField]
		private GameObject _baselineText;

		[SerializeField]
		private Color _activeBaselineTextColour;

		[SerializeField]
		private Color _inactiveBaselineTextColour;

		[SerializeField]
		private RectTransform _graphsRoot;

		[SerializeField]
		private PanelItemRadioButtonsGroup _modeSelectionButtons;

		[SerializeField]
		private GraphDefaults _graphDefaults;

		[InspectorMargin(8)]
		[SerializeField]
		protected List<GraphStatDefinition> _statDefinitions = new List<GraphStatDefinition>();

		protected GraphDisplayMode _currentDisplayMode;

		private bool _isMouseOver;

		private int _startMonth;

		private int _endMonth;

		private int _startYear;

		private int _endYear;

		private List<PanelItemGraph> _thePanelItemGraphs = new List<PanelItemGraph>();

		private List<TMP_Text> _baselineTextList = new List<TMP_Text>();

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			if ((bool)_graphsRoot)
			{
				_graphsRoot.GetComponentsInChildren(_thePanelItemGraphs);
			}
			if ((bool)_baselineText)
			{
				_baselineText.GetComponentsInChildren(_baselineTextList);
			}
			if ((bool)_pickerObject)
			{
				_pickerObject.gameObject.SetActive(value: false);
			}
			_statDefinitions = _statDefinitions ?? new List<GraphStatDefinition>();
			SetupStatDefitionSet(_statDefinitions, theTabRoot.TheOverviewMenu.TheLevel.TimelineManager, theTabRoot.TheOverviewMenu.IsEndOfYear);
			AssignStatDefitionSetToGraphs(_statDefinitions);
			if (_statDefinitions[0] != null)
			{
				List<LineGraph.DataVector2> cachedMonthlyGraphData = _statDefinitions[0].CachedMonthlyGraphData;
				List<LineGraph.DataVector2> cachedYearlyGraphData = _statDefinitions[0].CachedYearlyGraphData;
				if (cachedMonthlyGraphData.Count > 0)
				{
					_startMonth = (int)Math.Floor(cachedMonthlyGraphData[0].x);
					_endMonth = (int)Math.Floor(cachedMonthlyGraphData.Last().x);
				}
				if (cachedYearlyGraphData.Count > 0)
				{
					_startYear = (int)Math.Floor(cachedYearlyGraphData[0].x);
					_endYear = (int)Math.Floor(cachedYearlyGraphData.Last().x);
				}
			}
			if (_graphDefaults != null)
			{
				if (_graphDefaults.EnabledButtons != null)
				{
					PanelItemToggleButton[] enabledButtons = _graphDefaults.EnabledButtons;
					for (int i = 0; i < enabledButtons.Length; i++)
					{
						enabledButtons[i].SetPressedState(state: true);
					}
				}
				SetMode(_graphDefaults.graphDisplayMode);
			}
			if (!_modeSelectionButtons)
			{
				return;
			}
			PanelItemRadioButtonsGroup modeSelectionButtons = _modeSelectionButtons;
			modeSelectionButtons.OnButtonSelected = (Action<int>)Delegate.Combine(modeSelectionButtons.OnButtonSelected, new Action<int>(OnModeChange));
			if (theTabRoot.TheOverviewMenu.IsEndOfYear)
			{
				_currentDisplayMode = GraphDisplayMode.DmNone;
				_modeSelectionButtons.SelectButton(0);
				PanelItemToggleButton[] enabledButtons = _modeSelectionButtons.GetToggleButtons();
				foreach (PanelItemToggleButton panelItem in enabledButtons)
				{
					theTabRoot.TheOverviewMenu.SaveHUDPanelItemState(panelItem);
				}
			}
		}

		protected void OnDestroy()
		{
			if ((bool)_modeSelectionButtons)
			{
				PanelItemRadioButtonsGroup modeSelectionButtons = _modeSelectionButtons;
				modeSelectionButtons.OnButtonSelected = (Action<int>)Delegate.Remove(modeSelectionButtons.OnButtonSelected, new Action<int>(OnModeChange));
			}
		}

		protected void SetupStatDefitionSet(List<GraphStatDefinition> graphStatDefinitions, TimelineManager timelineManager, bool isYearEnd)
		{
			double num = (double)timelineManager.Day / (double)GameDate.GetDaysInMonth(timelineManager.Month);
			double monthsPassed = (double)timelineManager.TotalGameMonthsPassed + num;
			foreach (GraphStatDefinition graphStatDefinition in graphStatDefinitions)
			{
				if (graphStatDefinition.Stat != LevelStatsDatabase.Stat.None)
				{
					graphStatDefinition.BuildDataFromStat(_levelStatsDatabase, monthsPassed, isYearEnd);
				}
			}
		}

		protected void AssignStatDefitionSetToGraphs(List<GraphStatDefinition> graphStatDefinitions)
		{
			foreach (GraphStatDefinition graphStatDefinition in graphStatDefinitions)
			{
				graphStatDefinition.AssignDataToGraphs();
			}
		}

		protected override void Update()
		{
			base.Update();
			foreach (PanelItemGraph thePanelItemGraph in _thePanelItemGraphs)
			{
				thePanelItemGraph.Update();
			}
			bool flag = false;
			if (_isMouseOver)
			{
				Vector2 vector = Input.mousePosition;
				string text = string.Empty;
				float num = float.MaxValue;
				Vector2 zero = Vector2.zero;
				Color color = Color.white;
				PivotPresets preset = PivotPresets.TopCenter;
				foreach (PanelItemGraph thePanelItemGraph2 in _thePanelItemGraphs)
				{
					RectTransform component = thePanelItemGraph2.GetComponent<RectTransform>();
					if (RectTransformUtility.RectangleContainsScreenPoint(component, vector) && thePanelItemGraph2.GetScreenToDataPoint(vector, out var pickerPos, out var valueText))
					{
						RectTransformUtility.ScreenPointToLocalPointInRectangle(component, vector, null, out var localPoint);
						localPoint.y += component.rect.height * 0.5f;
						float num2 = Mathf.Abs(localPoint.y - pickerPos.y);
						if (num2 < num)
						{
							num = num2;
							text = valueText;
							color = thePanelItemGraph2.GraphColour;
							zero.x = pickerPos.x - component.rect.width * 0.5f;
							zero.y = pickerPos.y - component.rect.height * 0.5f;
							preset = ((zero.y > component.rect.height * 0.5f) ? PivotPresets.TopCenter : PivotPresets.BottomCenter);
						}
						flag = true;
					}
				}
				if (flag)
				{
					if ((bool)_pickerText)
					{
						_pickerText.text = text;
						_pickerText.rectTransform.SetPivot(preset);
					}
					if ((bool)_pickerInner)
					{
						_pickerInner.color = color;
					}
					if ((bool)_pickerObject)
					{
						_pickerObject.localPosition = zero;
					}
				}
			}
			if ((bool)_pickerObject)
			{
				GameObjectUtils.SetActive(_pickerObject.gameObject, flag);
			}
		}

		private void OnModeChange(int buttonID)
		{
			GraphDisplayMode graphDisplayMode = (GraphDisplayMode)(buttonID + 1);
			if (Enum.IsDefined(typeof(GraphDisplayMode), graphDisplayMode) && graphDisplayMode != _currentDisplayMode)
			{
				SetMode(graphDisplayMode);
			}
		}

		private void SetBaselineText(GraphDisplayMode theMode)
		{
			switch (theMode)
			{
			case GraphDisplayMode.DmMonthly:
			{
				int num2 = _startMonth;
				{
					foreach (TMP_Text baselineText in _baselineTextList)
					{
						if (num2 != 0 && num2 % 12 == 0)
						{
							baselineText.text = $"{GameDateUtils.MonthCountToShortName(num2)}\n{num2 / 12 + 1:00}";
						}
						else
						{
							baselineText.text = $"{GameDateUtils.MonthCountToShortName(num2)}";
						}
						baselineText.color = ((num2 <= _endMonth) ? _activeBaselineTextColour : _inactiveBaselineTextColour);
						num2++;
					}
					break;
				}
			}
			case GraphDisplayMode.DmYearly:
			{
				int num = _startYear;
				{
					foreach (TMP_Text baselineText2 in _baselineTextList)
					{
						if (num <= _endYear)
						{
							baselineText2.text = $"{num + 1:00}";
						}
						else
						{
							baselineText2.text = "";
						}
						num++;
					}
					break;
				}
			}
			}
		}

		private void SetMode(GraphDisplayMode theMode)
		{
			_currentDisplayMode = theMode;
			switch (_currentDisplayMode)
			{
			case GraphDisplayMode.DmMonthly:
				foreach (PanelItemGraph thePanelItemGraph in _thePanelItemGraphs)
				{
					thePanelItemGraph.ShowMonthlyData();
				}
				break;
			case GraphDisplayMode.DmYearly:
				foreach (PanelItemGraph thePanelItemGraph2 in _thePanelItemGraphs)
				{
					thePanelItemGraph2.ShowYearlyData();
				}
				break;
			default:
				return;
			}
			SetBaselineText(theMode);
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			_isMouseOver = true;
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			_isMouseOver = false;
		}
	}
}
