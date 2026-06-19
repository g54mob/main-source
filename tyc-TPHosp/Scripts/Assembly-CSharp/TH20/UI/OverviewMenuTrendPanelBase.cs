using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	public class OverviewMenuTrendPanelBase : OverviewMenuTabPanel
	{
		protected enum DisplayMode
		{
			DmNone = 0,
			DmYearly = 1,
			DmQuarterly = 2
		}

		[SerializeField]
		protected OverviewMenuGraphPanelBase.GraphStatDefinition _graphStatDefinition;

		[SerializeField]
		protected GameObject _baselineText;

		[SerializeField]
		protected PanelItemTrendIcon _theTrendIcon;

		[SerializeField]
		private PanelItemRadioButtonsGroup _modeSelectionButtons;

		[SerializeField]
		private LocalisedString[] _baseLineTextLocalised;

		[SerializeField]
		private RectTransform _pickerObject;

		protected DisplayMode _currentDisplayMode;

		protected float _monthFirst;

		protected float _monthLast;

		protected float _quarterFirst;

		protected float _quarterLast;

		private List<TMP_Text> _baselineTextList = new List<TMP_Text>();

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			if ((bool)_modeSelectionButtons)
			{
				PanelItemRadioButtonsGroup modeSelectionButtons = _modeSelectionButtons;
				modeSelectionButtons.OnButtonSelected = (Action<int>)Delegate.Combine(modeSelectionButtons.OnButtonSelected, new Action<int>(OnModeChange));
			}
			if ((bool)_baselineText)
			{
				_baselineText.GetComponentsInChildren(_baselineTextList);
			}
			if ((bool)_pickerObject)
			{
				_pickerObject.gameObject.SetActive(value: false);
			}
			TimelineManager timelineManager = theTabRoot.TheOverviewMenu.TheLevel.TimelineManager;
			double num = (double)timelineManager.Day / (double)GameDate.GetDaysInMonth(timelineManager.Month);
			double monthsPassed = (double)timelineManager.TotalGameMonthsPassed + num;
			_graphStatDefinition.BuildDataFromStat(_levelStatsDatabase, monthsPassed, theTabRoot.TheOverviewMenu.IsEndOfYear);
			_graphStatDefinition.AssignDataToGraphs();
			if ((bool)_modeSelectionButtons)
			{
				_modeSelectionButtons.SelectButton(0);
			}
		}

		protected virtual void SetupGraphData()
		{
		}

		protected override void Update()
		{
			base.Update();
			if ((bool)_graphStatDefinition.Graph)
			{
				_graphStatDefinition.Graph.Update();
				if ((bool)_theTrendIcon)
				{
					_theTrendIcon.gameObject.SetActive(_graphStatDefinition.Graph.IsSettled);
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

		private void OnModeChange(int buttonID)
		{
			DisplayMode displayMode = (DisplayMode)(buttonID + 1);
			if (Enum.IsDefined(typeof(DisplayMode), displayMode) && displayMode != _currentDisplayMode)
			{
				SetMode(displayMode);
			}
		}

		private void SetMode(DisplayMode theMode)
		{
			_currentDisplayMode = theMode;
			switch (_currentDisplayMode)
			{
			case DisplayMode.DmQuarterly:
				if ((bool)_graphStatDefinition.Graph)
				{
					_graphStatDefinition.Graph.ShowQuarterlyData();
				}
				if ((bool)_theTrendIcon)
				{
					_theTrendIcon.SetTrend(_quarterFirst, _quarterLast);
				}
				break;
			case DisplayMode.DmYearly:
				if ((bool)_graphStatDefinition.Graph)
				{
					_graphStatDefinition.Graph.ShowMonthlyData();
				}
				if ((bool)_theTrendIcon)
				{
					_theTrendIcon.SetTrend(_monthFirst, _monthLast);
				}
				break;
			default:
				return;
			}
			Refresh();
			SetBaselineText(theMode);
		}

		private void SetBaselineText(DisplayMode theMode)
		{
			int num = _level.TimelineManager.Month - 3;
			int num2 = _level.TimelineManager.Year;
			if (num < 0)
			{
				num2--;
			}
			if (num2 < 0)
			{
				num = 0;
			}
			float x = ((theMode == DisplayMode.DmQuarterly) ? 0.75f : 1f);
			for (int i = 0; i < _baselineTextList.Count; i++)
			{
				_baselineTextList[i].gameObject.transform.localScale = new Vector3(x, 1f, 1f);
			}
			for (int j = 0; j < _baselineTextList.Count; j++)
			{
				TMP_Text tMP_Text = _baselineTextList[j];
				switch (theMode)
				{
				case DisplayMode.DmQuarterly:
					tMP_Text.text = $"{GameDateUtils.MonthCountToShortName(num + j)}";
					break;
				case DisplayMode.DmYearly:
					if (_baseLineTextLocalised != null && _baseLineTextLocalised.Length > j)
					{
						tMP_Text.text = _baseLineTextLocalised[j].Translation;
					}
					break;
				}
			}
		}
	}
}
