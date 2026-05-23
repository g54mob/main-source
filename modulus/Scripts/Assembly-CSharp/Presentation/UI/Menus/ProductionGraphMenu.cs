#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.ProductionHistory;
using NaughtyAttributes;
using Presentation.UI.Buttons;
using Presentation.UI.LayoutElements;
using Presentation.UI.Menus.MenuEvents.MenuData;
using SRF;
using TMPro;
using UI.Statistics;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.Menus
{
	public class ProductionGraphMenu : UIMenu
	{
		private enum TimeRange
		{
			OneHour = 0,
			TenHours = 1,
			HundredHours = 2,
			Lifetime = 3
		}

		private const int MaxZoomLevel = 3;

		[SerializeField]
		private ProductionHistoryPersistentSO _productionHistoryPersistentSO;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[Header("Buttons")]
		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private Button _zoomInButton;

		[SerializeField]
		private ButtonEnabler _zoomInButtonEnabler;

		[SerializeField]
		private Button _zoomOutButton;

		[SerializeField]
		private ButtonEnabler _zoomOutButtonEnabler;

		[SerializeField]
		private List<Image> _scaleIndicators = new List<Image>();

		[SerializeField]
		private Color _scaleIndicatorColor;

		[Header("Toggles")]
		[SerializeField]
		private SwitchToggle _typeToggle;

		[SerializeField]
		private TextMeshProUGUI _producedText;

		[SerializeField]
		private TextMeshProUGUI _deliveredText;

		[SerializeField]
		private TextMeshProUGUI _horizontalLegendText;

		[Header("Graph")]
		[SerializeField]
		private LineGraph _graph;

		[Header("Panels")]
		[SerializeField]
		private GameObject _graphContent;

		[Header("Line Icons")]
		[SerializeField]
		private RectTransform _iconParent;

		[SerializeField]
		private Image _iconPrefab;

		[SerializeField]
		private Vector2 _iconOffset = new Vector2(-1f, 0.5f);

		[Header("Graph Colors")]
		[SerializeField]
		private List<Color> _producedColors = new List<Color>();

		[SerializeField]
		private List<Color> _deliveredColors = new List<Color>();

		private readonly HashSet<int> _filteredProducedIds = new HashSet<int>();

		private readonly HashSet<int> _filteredDeliveredIds = new HashSet<int>();

		private readonly Dictionary<int, int> _dotCounters = new Dictionary<int, int>();

		private TimeRange _selectedTimeRange;

		private ProductionGraphData _currentGraphData;

		private readonly Dictionary<int, Image> _lastLine = new Dictionary<int, Image>();

		private readonly Dictionary<int, Image> _lastDot = new Dictionary<int, Image>();

		private readonly List<(string, string)> _legendIntervals = new List<(string, string)>
		{
			("1", "ProductionGraph.TimeframeIntervalMinute"),
			("10", "ProductionGraph.TimeframeIntervalMinutes"),
			("1", "ProductionGraph.TimeframeIntervalHour"),
			("5", "ProductionGraph.TimeframeIntervalHours")
		};

		private bool _hasBeenOpened;

		private int _currentZoomLevel;

		public bool IsFilteringByProduced => !_typeToggle.IsOn;

		public bool IsFilteringByDelivered => _typeToggle.IsOn;

		private int CurrentZoomLevel
		{
			get
			{
				return _currentZoomLevel;
			}
			set
			{
				if (value <= 3 && value >= 0)
				{
					_zoomOutButtonEnabler.Interactable = value < 3;
					_zoomInButtonEnabler.Interactable = value > 0;
					_currentZoomLevel = value;
					_horizontalLegendText.SetText(string.Format(LocalizationUtility.GetLocalizedText("ProductionGraph.TimeframeLegend"), _legendIntervals[_currentZoomLevel].Item1, LocalizationUtility.GetLocalizedText(_legendIntervals[_currentZoomLevel].Item2)));
					SetScaleIndicator(value);
					switch (value)
					{
					case 0:
						SetTimeRange(TimeRange.OneHour);
						break;
					case 1:
						SetTimeRange(TimeRange.TenHours);
						break;
					case 2:
						SetTimeRange(TimeRange.HundredHours);
						break;
					case 3:
						SetTimeRange(TimeRange.Lifetime);
						break;
					}
				}
			}
		}

		public event Action OnFilterModeChanged = delegate
		{
		};

		private void Start()
		{
			SetupEventListeners();
		}

		private void OnDestroy()
		{
			CleanupEventListeners();
		}

		private void Update()
		{
			if (_currentZoomLevel != 0)
			{
				return;
			}
			foreach (KeyValuePair<int, Image> item in _lastLine)
			{
				IReadOnlyList<Vector2> points = _currentGraphData.GetPoints(item.Key);
				Vector2 data = points[points.Count - 1];
				data.y = _currentGraphData.GetLastPointValue(item.Key);
				IReadOnlyList<Vector2> points2 = _currentGraphData.GetPoints(item.Key);
				Vector2 data2 = points2[points2.Count - 2];
				Image value = item.Value;
				Image image = _lastDot[item.Key];
				Vector2 vector = _graph.ConvertToUIPos(data);
				_graph.PositionLine(_graph.ConvertToUIPos(data2), vector, value);
				_graph.PositionPoint(vector, image);
				image.GetComponent<ProductionGraphDotTooltipEnabler>().SetAmountText(string.Format("{0} / {1}", data.y, LocalizationUtility.GetLocalizedText("ProductionGraph.TimeframeIntervalMinute")));
			}
		}

		private void SetupEventListeners()
		{
			_zoomInButton.onClick.AddListener(OnZoomInButtonClicked);
			_zoomOutButton.onClick.AddListener(OnZoomOutButtonClicked);
			_typeToggle.OnValueChanged.AddListener(HandleFilterToggle);
			_closeButton.onClick.AddListener(HideMenu);
		}

		private void CleanupEventListeners()
		{
			_zoomInButton.onClick.RemoveListener(OnZoomInButtonClicked);
			_zoomOutButton.onClick.RemoveListener(OnZoomOutButtonClicked);
			_typeToggle.OnValueChanged.RemoveListener(HandleFilterToggle);
			_closeButton.onClick.RemoveListener(HideMenu);
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			base.gameObject.SetActive(value: true);
			_productionHistoryPersistentSO.OnNewNode.RegisterMainThread(PopulateGraph);
			if (!_hasBeenOpened)
			{
				_typeToggle.IsOn = true;
				_hasBeenOpened = true;
				CurrentZoomLevel = 0;
				StartCoroutine(DelayedStart());
			}
			else
			{
				PopulateGraph();
			}
		}

		private IEnumerator DelayedStart()
		{
			yield return new WaitForEndOfFrame();
			HandleFilterToggle(value: true);
		}

		public override void HideMenu()
		{
			_productionHistoryPersistentSO.OnNewNode.UnRegisterMainThread(PopulateGraph);
			base.gameObject.SetActive(value: false);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void PopulateGraph()
		{
			_dotCounters.Clear();
			_lastLine.Clear();
			_lastDot.Clear();
			ClearLineIcons();
			CreateAndPlotGraphData();
		}

		private bool HasAnyActiveFilters()
		{
			if (_filteredProducedIds.Count <= 0)
			{
				return _filteredDeliveredIds.Count > 0;
			}
			return true;
		}

		private void CreateAndPlotGraphData()
		{
			ProductionGraphDatabases databases = new ProductionGraphDatabases(_resourceDatabase, _factoryObjectDatabase);
			ProductionGraphColorConfig colorConfig = new ProductionGraphColorConfig(_producedColors, _deliveredColors);
			ProductionGraphIdLists activeIdLists = GetActiveIdLists();
			_currentGraphData = new ProductionGraphData(GetNodesByTimeRange(), _productionHistoryPersistentSO, activeIdLists, databases, colorConfig);
			_graph.Discretization = new Vector2Int(1, CalculateDiscretizationY(_currentGraphData));
			_graph.PlotGraph(_currentGraphData, DotCreated, LineCreated, null, NormalizedLineDotsCalculated);
		}

		private int CalculateDiscretizationY(ProductionGraphData data)
		{
			float num = data.Max.y - data.Min.y;
			if (num == 0f)
			{
				return 1;
			}
			int num2 = num.ToString().Length - 1;
			num2 = (int)Mathf.Pow(10f, num2);
			if (num > (float)(num2 * 2))
			{
				return num2;
			}
			return num2 / 10;
		}

		private ProductionGraphIdLists GetActiveIdLists()
		{
			List<int> producedResourceIds = (IsFilteringByProduced ? _filteredProducedIds.ToList() : new List<int>());
			List<int> deliveredResourceIds = (IsFilteringByDelivered ? _filteredDeliveredIds.ToList() : new List<int>());
			return new ProductionGraphIdLists(producedResourceIds, deliveredResourceIds);
		}

		private void NormalizedLineDotsCalculated(int lineId, List<Vector2> positions)
		{
			if (positions.Count > 0)
			{
				Vector2 position = positions[0] * _iconParent.rect.size;
				CreateLineIcon(lineId, position);
			}
		}

		private void LineCreated(int lineId, Image line)
		{
			line.color = _currentGraphData.GetLineMetadata(lineId).Color;
			_lastLine[lineId] = line;
		}

		private void DotCreated(int lineId, Image dot)
		{
			ConfigureDotAppearance(lineId, dot);
			SetDotTooltip(lineId, dot);
			_lastDot[lineId] = dot;
		}

		private void ConfigureDotAppearance(int lineId, Image dot)
		{
			dot.color = _currentGraphData.GetLineMetadata(lineId).Color;
			_dotCounters.TryAdd(lineId, 0);
		}

		private void SetDotTooltip(int lineId, Image dot)
		{
			IReadOnlyList<Vector2> points = _currentGraphData.GetPoints(lineId);
			if (_dotCounters[lineId] >= points.Count)
			{
				this.DevException($"Dot index {_dotCounters[lineId]} exceeds plot point count {points.Count} for line {lineId}.", "SetDotTooltip", 325);
				return;
			}
			Vector2 vector = points[_dotCounters[lineId]];
			dot.GetComponent<ProductionGraphDotTooltipEnabler>().SetText(_currentGraphData.GetLineMetadata(lineId).Name, string.Format("{0} / {1}", vector.y, LocalizationUtility.GetLocalizedText("ProductionGraph.TimeframeIntervalMinute")));
			_dotCounters[lineId]++;
		}

		private void SetTimeRange(TimeRange range)
		{
			_selectedTimeRange = range;
			PopulateGraph();
		}

		private IEnumerable<ProductionHistoryNode> GetNodesByTimeRange()
		{
			return _selectedTimeRange switch
			{
				TimeRange.OneHour => _productionHistoryPersistentSO.GetHourNodes(), 
				TimeRange.TenHours => _productionHistoryPersistentSO.GetTenHourNodes(), 
				TimeRange.HundredHours => _productionHistoryPersistentSO.GetHundredHourNodes(), 
				TimeRange.Lifetime => _productionHistoryPersistentSO.GetLifeTimeNodes(), 
				_ => throw new NotImplementedException("_selectedTimeRange"), 
			};
		}

		private void CreateLineIcon(int lineId, Vector2 position)
		{
			Image iconInstance = UnityEngine.Object.Instantiate(_iconPrefab, _iconParent);
			ConfigureLineIcon(iconInstance, lineId, position);
		}

		private void ConfigureLineIcon(Image iconInstance, int lineId, Vector2 position)
		{
			iconInstance.sprite = _currentGraphData.GetLineMetadata(lineId).Icon;
			RectTransform obj = (RectTransform)iconInstance.transform;
			Vector2 vector = Vector2.Scale(obj.sizeDelta, _iconOffset);
			obj.anchoredPosition = position + vector;
		}

		private void ClearLineIcons()
		{
			_iconParent.DestroyChildren();
		}

		internal void SetFilterProducedEnabled(int factoryObjectId, bool enabled)
		{
			SetFilterEnabled(_filteredProducedIds, factoryObjectId, enabled);
			PopulateGraph();
		}

		internal void SetFilterDeliveredEnabled(int factoryObjectId, bool enabled)
		{
			SetFilterEnabled(_filteredDeliveredIds, factoryObjectId, enabled);
			PopulateGraph();
		}

		private void SetFilterEnabled(HashSet<int> filterSet, int id, bool enabled)
		{
			if (enabled)
			{
				filterSet.Add(id);
			}
			else
			{
				filterSet.Remove(id);
			}
		}

		private void HandleFilterToggle(bool value)
		{
			_producedText.color = (value ? Color.white : _producedColors[0]);
			_deliveredText.color = (value ? _deliveredColors[0] : Color.white);
			this.OnFilterModeChanged();
			PopulateGraph();
		}

		private void SetScaleIndicator(int zoomLevel)
		{
			for (int i = 0; i < _scaleIndicators.Count; i++)
			{
				_scaleIndicators[i].color = ((i == zoomLevel) ? _scaleIndicatorColor : Color.white);
			}
		}

		private void OnZoomInButtonClicked()
		{
			CurrentZoomLevel--;
		}

		private void OnZoomOutButtonClicked()
		{
			CurrentZoomLevel++;
		}
	}
}
