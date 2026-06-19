using System;
using System.Collections.Generic;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	public class AmbulanceLeagueMenu : AnimatedMenuBase, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Serializable]
		private struct GraphBounds
		{
			public double MinYValue;

			public double MaxYValue;
		}

		[SerializeField]
		private AmbulanceDepartmentStats.AmbulanceDepartmentStat _statToShow;

		[SerializeField]
		private LocalisedString _statName;

		[SerializeField]
		private TMP_Text _statText;

		[SerializeField]
		private PanelItemGraph _playerGraph;

		[SerializeField]
		private PanelItemGraph[] _rivalGraphs;

		[SerializeField]
		private GraphBounds _defaultGraphBounds;

		[SerializeField]
		private AmbulanceDepartmentLeaderboard _leaderboard;

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
		private PanelItemRadioButtonsGroup _modeSelectionButtons;

		private Level _level;

		private List<AmbulanceDepartmentRecord> _competingDepartments;

		private GraphDisplayMode _currentDisplayMode;

		private List<PanelItemGraph> _panelItemGraphs = new List<PanelItemGraph>();

		private List<TMP_Text> _baselineTextList = new List<TMP_Text>();

		private bool _isMouseOver;

		private int _startMonth;

		private int _startYear;

		private int _endMonth;

		private int _endYear;

		private const int IndexOfFinalEntry = 11;

		public void Setup(Level level)
		{
			_level = level;
			if (_statText != null)
			{
				_statText.text = _statName.Translation;
			}
			if ((bool)_baselineText)
			{
				_baselineText.GetComponentsInChildren(_baselineTextList);
			}
			if ((bool)_modeSelectionButtons)
			{
				_modeSelectionButtons.Setup();
				PanelItemToggleButton[] toggleButtons = _modeSelectionButtons.GetToggleButtons();
				for (int i = 0; i < toggleButtons.Length; i++)
				{
					toggleButtons[i].Setup();
				}
				_modeSelectionButtons.SelectButton(1);
				PanelItemRadioButtonsGroup modeSelectionButtons = _modeSelectionButtons;
				modeSelectionButtons.OnButtonSelected = (Action<int>)Delegate.Combine(modeSelectionButtons.OnButtonSelected, new Action<int>(OnModeChange));
			}
			PlayerAmbulanceDepartment playerAmbulanceDepartment = _level.ChallengeManager.PlayerAmbulanceDepartment;
			AmbulanceDepartmentRecord item = new AmbulanceDepartmentRecord(teamColour: playerAmbulanceDepartment.Config.PlayerFoundationDefinition.Instance.FoundationStyle.Instance.GlobalStyleProperties.FoundationLeagueTableColour, department: playerAmbulanceDepartment, graph: _playerGraph);
			_competingDepartments = new List<AmbulanceDepartmentRecord>(_level.ChallengeManager.RivalAmbulanceDepartments.Count + 1) { item };
			if (_rivalGraphs.Length >= _level.ChallengeManager.RivalAmbulanceDepartments.Count)
			{
				List<RivalAmbulanceDepartment> rivalAmbulanceDepartments = _level.ChallengeManager.RivalAmbulanceDepartments;
				for (int j = 0; j < rivalAmbulanceDepartments.Count; j++)
				{
					Color foundationLeagueTableColour = rivalAmbulanceDepartments[j].FoundationStyle.GlobalStyleProperties.FoundationLeagueTableColour;
					_competingDepartments.Add(new AmbulanceDepartmentRecord(rivalAmbulanceDepartments[j], _rivalGraphs[j], foundationLeagueTableColour));
				}
			}
			_panelItemGraphs = new List<PanelItemGraph>(_rivalGraphs.Length + 1);
			_panelItemGraphs.Add(_playerGraph);
			_panelItemGraphs.AddRange(_rivalGraphs);
			CacheCompetingDepartmentData();
			AssignCachedDataToGraphs();
			_startMonth = 0;
			_endMonth = 11;
			_startYear = 0;
			_endYear = 11;
			if (level.TimelineManager.TotalGameYearsPassed > 0)
			{
				_startMonth = level.TimelineManager.Month;
				_endMonth = ((level.TimelineManager.Month == 0) ? 11 : (level.TimelineManager.Month - 1));
				if (level.TimelineManager.TotalGameYearsPassed > 11)
				{
					_startYear = level.TimelineManager.Year;
					_endYear = ((level.TimelineManager.Year == 0) ? 11 : (level.TimelineManager.Year - 1));
				}
			}
			if (_panelItemGraphs != null)
			{
				foreach (PanelItemGraph panelItemGraph in _panelItemGraphs)
				{
					panelItemGraph.AssignedButton.SetPressedState(state: true);
					panelItemGraph.SetInverted(AmbulanceDepartmentStats.ShouldInvertScore(_statToShow));
				}
				SetMode(GraphDisplayMode.DmMonthly);
			}
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			ChallengeManager challengeManager = _level.ChallengeManager;
			challengeManager.OnAmbulanceLeagueUpdated = (Action<int>)Delegate.Combine(challengeManager.OnAmbulanceLeagueUpdated, new Action<int>(AssignDepartmentsToLeaderboard));
		}

		public void OnDestroy()
		{
			if ((bool)_modeSelectionButtons)
			{
				PanelItemRadioButtonsGroup modeSelectionButtons = _modeSelectionButtons;
				modeSelectionButtons.OnButtonSelected = (Action<int>)Delegate.Remove(modeSelectionButtons.OnButtonSelected, new Action<int>(OnModeChange));
			}
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			ChallengeManager challengeManager = _level.ChallengeManager;
			challengeManager.OnAmbulanceLeagueUpdated = (Action<int>)Delegate.Remove(challengeManager.OnAmbulanceLeagueUpdated, new Action<int>(AssignDepartmentsToLeaderboard));
		}

		protected override void Update()
		{
			base.Update();
			bool flag = false;
			if (_isMouseOver)
			{
				Vector2 vector = Input.mousePosition;
				string text = string.Empty;
				float num = float.MaxValue;
				Vector2 zero = Vector2.zero;
				Color color = Color.white;
				PivotPresets preset = PivotPresets.TopCenter;
				foreach (PanelItemGraph panelItemGraph in _panelItemGraphs)
				{
					RectTransform component = panelItemGraph.GetComponent<RectTransform>();
					if (RectTransformUtility.RectangleContainsScreenPoint(component, vector) && panelItemGraph.GetScreenToDataPoint(vector, out var pickerPos, out var valueText, snapToPoints: true))
					{
						RectTransformUtility.ScreenPointToLocalPointInRectangle(component, vector, null, out var localPoint);
						localPoint.y += component.rect.height * 0.5f;
						float num2 = Mathf.Abs(localPoint.y - pickerPos.y);
						if (num2 < num)
						{
							num = num2;
							text = valueText;
							color = panelItemGraph.GraphColour;
							Rect rect = component.rect;
							zero.x = pickerPos.x - rect.width * 0.5f;
							zero.y = pickerPos.y - rect.height * 0.5f;
							preset = ((zero.y > rect.height * 0.5f) ? PivotPresets.TopCenter : PivotPresets.BottomCenter);
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

		private void CacheCompetingDepartmentData()
		{
			foreach (AmbulanceDepartmentRecord competingDepartment in _competingDepartments)
			{
				List<LineGraph.DataVector2> monthlyHistoryForStat = competingDepartment.Department.Stats.GetMonthlyHistoryForStat(_statToShow);
				List<LineGraph.DataVector2> yearlyHistoryForStat = competingDepartment.Department.Stats.GetYearlyHistoryForStat(_statToShow);
				competingDepartment.CacheMonthlyData(monthlyHistoryForStat);
				competingDepartment.CacheYearlyData(yearlyHistoryForStat);
			}
		}

		private void AssignCachedDataToGraphs()
		{
			SetGraphMinMaxValues();
			foreach (AmbulanceDepartmentRecord competingDepartment in _competingDepartments)
			{
				competingDepartment.AssignCachedDataToGraph();
			}
		}

		private void AssignDepartmentsToLeaderboard(int month)
		{
			if (!(_leaderboard == null))
			{
				_leaderboard.RefreshLeaderboard(_competingDepartments, _statToShow, _currentDisplayMode == GraphDisplayMode.DmMonthly);
			}
		}

		private void SetGraphMinMaxValues()
		{
			if (_panelItemGraphs == null || _panelItemGraphs.Count <= 0)
			{
				return;
			}
			double num = _defaultGraphBounds.MinYValue;
			double num2 = _defaultGraphBounds.MaxYValue;
			foreach (AmbulanceDepartmentRecord competingDepartment in _competingDepartments)
			{
				if (_currentDisplayMode == GraphDisplayMode.DmNone || _currentDisplayMode == GraphDisplayMode.DmMonthly)
				{
					foreach (LineGraph.DataVector2 cachedMonthlyDatum in competingDepartment.CachedMonthlyData)
					{
						num = Math.Min(num, cachedMonthlyDatum.y);
						num2 = Math.Max(num2, cachedMonthlyDatum.y);
					}
					continue;
				}
				foreach (LineGraph.DataVector2 cachedYearlyDatum in competingDepartment.CachedYearlyData)
				{
					num = Math.Min(num, cachedYearlyDatum.y);
					num2 = Math.Max(num2, cachedYearlyDatum.y);
				}
			}
			foreach (PanelItemGraph panelItemGraph in _panelItemGraphs)
			{
				panelItemGraph.MinYValue = num;
				panelItemGraph.MaxYValue = num2;
			}
		}

		private void OnLocalize()
		{
			if (_statText != null)
			{
				_statText.text = _statName.Translation;
			}
			if (_leaderboard != null)
			{
				_leaderboard.RefreshLeaderboard(_competingDepartments, _statToShow, _currentDisplayMode == GraphDisplayMode.DmMonthly);
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
			SetGraphMinMaxValues();
			switch (_currentDisplayMode)
			{
			case GraphDisplayMode.DmMonthly:
				foreach (PanelItemGraph panelItemGraph in _panelItemGraphs)
				{
					panelItemGraph.ShowMonthlyData();
				}
				break;
			case GraphDisplayMode.DmYearly:
				foreach (PanelItemGraph panelItemGraph2 in _panelItemGraphs)
				{
					panelItemGraph2.ShowYearlyData();
				}
				break;
			default:
				return;
			}
			SetBaselineText(theMode);
			AssignDepartmentsToLeaderboard(0);
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
