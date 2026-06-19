using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class PanelItemGraph : PanelItem
	{
		public enum GraphType
		{
			TypeMoney = 0,
			TypePercentage = 1,
			TypeCount = 2,
			TypePercentage100 = 3
		}

		protected enum DataSets
		{
			DataSetMonthly = 0,
			DataSetQuarterly = 1,
			DataSetYearly = 2
		}

		private class GraphPoint
		{
			public Vector2 CurrentPoint = Vector2.zero;

			public Vector2 DestPoint = Vector2.zero;
		}

		private class DataSet
		{
			public List<LineGraph.DataVector2> Data;

			public DataSet(GraphType type)
			{
				Data = new List<LineGraph.DataVector2>();
			}

			public void AssignData(List<LineGraph.DataVector2> data)
			{
				Data.Clear();
				Data.AddRange(data);
			}
		}

		[SerializeField]
		private GraphType _graphType;

		[SerializeField]
		private PanelItemToggleButton _assignedButton;

		[SerializeField]
		private Color _graphColour;

		[SerializeField]
		private bool _useLocalisedGraphName = true;

		[SerializeField]
		private LocalisedString _graphName;

		[SerializeField]
		private string _nonLocalisedGraphName;

		[SerializeField]
		private UILineRenderer _lineRenderer;

		[SerializeField]
		private UILineRenderer _lineRendererTheSecond;

		[SerializeField]
		private bool _includeFinalMonth = true;

		[NonSerialized]
		[HideInInspector]
		public List<double> GraphData;

		private double _minXValue;

		private double _maxXValue = 12.0;

		[SerializeField]
		private double _minYValue;

		[SerializeField]
		private double _maxYValue = 1.0;

		private DataSets _currentDataSet;

		private static float NextPointTime = 0.025f;

		private static EasingsUtils.Functions EaseFunction = EasingsUtils.Functions.BounceEaseOut;

		private int _graphPointCount;

		private int _graphPointsDisplayed;

		private float _displayTime;

		private float _nextPointDisplayTime;

		private float _graphTrend;

		private float _graphHeight;

		private float _graphYOffset;

		private float _graphWidth;

		private DataSet _monthlyData;

		private DataSet _quarterlyData;

		private DataSet _yearlyData;

		private DynamicButton _dynamicButton;

		private RectTransform _theRectTransform;

		private Rect _currentGraphRect;

		private GraphPoint[] _theGraphPoints;

		private List<Vector2> _pointsList = new List<Vector2>();

		private bool _triggeredAudio;

		private bool _inverted;

		public float FirstGraphValue { get; private set; }

		public float LastGraphValue { get; private set; }

		public double MinYValue
		{
			get
			{
				return _minYValue;
			}
			set
			{
				_minYValue = value;
			}
		}

		public double MaxYValue
		{
			get
			{
				return _maxYValue;
			}
			set
			{
				_maxYValue = value;
			}
		}

		public bool IsSettled { get; private set; }

		public Color GraphColour
		{
			get
			{
				return _graphColour;
			}
			set
			{
				_graphColour = value;
			}
		}

		public PanelItemToggleButton AssignedButton => _assignedButton;

		public override void Setup()
		{
			base.Setup();
			_monthlyData = new DataSet(_graphType);
			_quarterlyData = new DataSet(_graphType);
			_yearlyData = new DataSet(_graphType);
			FirstGraphValue = 0f;
			LastGraphValue = 0f;
			if ((bool)_assignedButton)
			{
				string titleText = (_useLocalisedGraphName ? _graphName.Translation : _nonLocalisedGraphName);
				_assignedButton.SetTitleText(titleText);
				_assignedButton.SetGraphColor(_graphColour);
				_dynamicButton = _assignedButton.GetComponent<DynamicButton>();
				if ((bool)_dynamicButton)
				{
					_dynamicButton.onPrimaryDown.AddListener(ToggleGraph);
				}
			}
			if ((bool)_lineRenderer)
			{
				_lineRenderer.color = _graphColour;
				_lineRenderer.enabled = false;
				_graphYOffset = _lineRenderer.LineThickness * 2f;
			}
			if ((bool)_lineRendererTheSecond)
			{
				_lineRendererTheSecond.enabled = false;
			}
			_maxXValue = (_includeFinalMonth ? 12 : 11);
			int num = (int)_maxXValue + 1;
			_theGraphPoints = new GraphPoint[num];
			for (int i = 0; i < _theGraphPoints.Length; i++)
			{
				_theGraphPoints[i] = new GraphPoint();
			}
			_theRectTransform = base.gameObject.GetComponent<RectTransform>();
			UpdateGraphSizes();
		}

		public void Setup(string graphName, Color graphColor)
		{
			_useLocalisedGraphName = false;
			_nonLocalisedGraphName = graphName;
			_graphColour = graphColor;
			Setup();
		}

		public void Setup(LocalisedString graphName, Color graphColor)
		{
			_useLocalisedGraphName = true;
			_graphName = graphName;
			_graphColour = graphColor;
			Setup();
		}

		private void OnDestroy()
		{
		}

		private void UpdateGraphSizes()
		{
			if ((bool)_theRectTransform)
			{
				_graphWidth = _theRectTransform.rect.width;
				_graphHeight = _theRectTransform.rect.height - _graphYOffset * 2f;
				_currentGraphRect.xMin = _theRectTransform.rect.xMin;
				_currentGraphRect.xMax = _theRectTransform.rect.xMax;
				_currentGraphRect.yMin = _theRectTransform.rect.yMin;
				_currentGraphRect.yMax = _theRectTransform.rect.yMax;
			}
		}

		private void CheckReinitGraphOnRectSizeChange()
		{
			if ((bool)_theRectTransform && _currentGraphRect != _theRectTransform.rect)
			{
				ShowGraph(bImmediate: true);
			}
		}

		public void Update()
		{
			CheckReinitGraphOnRectSizeChange();
			Process();
		}

		private void Process(bool bImmediate = false)
		{
			if (!bImmediate)
			{
				float num = 0.5f;
				if (_lineRenderer.enabled && _displayTime >= 0.4f && !_triggeredAudio)
				{
					_triggeredAudio = true;
					AudioManager.Instance.Play("GraphBoings:UI");
				}
				_displayTime += Time.unscaledDeltaTime * num;
				_nextPointDisplayTime += Time.unscaledDeltaTime * num;
				if (_nextPointDisplayTime >= NextPointTime)
				{
					if (_graphPointsDisplayed < _graphPointCount)
					{
						_graphPointsDisplayed++;
						_nextPointDisplayTime -= NextPointTime;
					}
					else
					{
						_nextPointDisplayTime = NextPointTime;
					}
				}
			}
			_pointsList.Clear();
			float num2 = ((_graphTrend >= 0f) ? 0f : (_graphYOffset + _graphHeight));
			int num3 = Math.Min(_graphPointCount, _theGraphPoints.Length);
			for (int i = 0; i < num3; i++)
			{
				GraphPoint graphPoint = _theGraphPoints[i];
				if (!bImmediate)
				{
					float num4 = EasingsUtils.Interpolate(Mathf.Clamp01(_displayTime - (float)i * NextPointTime), EaseFunction);
					float num5 = graphPoint.DestPoint.y - num2;
					graphPoint.CurrentPoint.x = graphPoint.DestPoint.x;
					graphPoint.CurrentPoint.y = num2 + num5 * num4;
				}
				else
				{
					graphPoint.CurrentPoint.x = graphPoint.DestPoint.x;
					graphPoint.CurrentPoint.y = graphPoint.DestPoint.y;
				}
				_pointsList.Add(graphPoint.CurrentPoint);
			}
			if ((bool)_lineRenderer)
			{
				_lineRenderer.Points = _pointsList.ToArray();
				_lineRenderer.SetAllDirty();
			}
			if ((bool)_lineRendererTheSecond)
			{
				_lineRendererTheSecond.Points = _pointsList.ToArray();
				_lineRendererTheSecond.SetAllDirty();
			}
			if (_graphPointsDisplayed == _graphPointCount)
			{
				IsSettled = true;
			}
			if (bImmediate)
			{
				IsSettled = true;
				_graphPointsDisplayed = _graphPointCount;
				_displayTime = 1f + (float)_graphPointCount * NextPointTime;
			}
		}

		private Vector2 DataPointToLineNormalisedPosition(LineGraph.DataVector2 point, bool invert)
		{
			double num = _maxXValue - _minXValue;
			double num2 = _maxYValue - _minYValue;
			double num3 = ((num.CompareTo(0.0) != 0) ? ((point.x - _minXValue) / num) : 0.0);
			double num4 = ((num2.CompareTo(0.0) != 0) ? ((point.y - _minYValue) / num2) : 0.0);
			if (invert)
			{
				num4 = 1.0 - num4;
			}
			return new Vector2((float)num3, (float)num4);
		}

		private void ShowGraphInternal(DataSets theDataSet)
		{
			_currentDataSet = theDataSet;
			ShowGraph();
		}

		public void ShowGraph(bool bImmediate = false)
		{
			if (((bool)_assignedButton && !_assignedButton.IsDown) || !_lineRenderer)
			{
				return;
			}
			DataSet dataSet = null;
			float x = 1f;
			switch (_currentDataSet)
			{
			case DataSets.DataSetMonthly:
				_maxXValue = (_includeFinalMonth ? 12 : 11);
				dataSet = _monthlyData;
				break;
			case DataSets.DataSetQuarterly:
				_maxXValue = 3.0;
				x = 1.3333334f;
				dataSet = _quarterlyData;
				break;
			case DataSets.DataSetYearly:
				_maxXValue = (_includeFinalMonth ? 12 : 11);
				dataSet = _yearlyData;
				break;
			}
			base.gameObject.transform.localScale = new Vector3(x, 1f, 1f);
			if (dataSet != null && dataSet.Data.Count > 1)
			{
				UpdateGraphSizes();
				Vector2 vector = DataPointToLineNormalisedPosition(dataSet.Data[0], _inverted);
				_graphTrend = (float)(dataSet.Data[dataSet.Data.Count - 1].y - dataSet.Data[0].y);
				_displayTime = 0f;
				_graphPointCount = dataSet.Data.Count;
				_graphPointsDisplayed = 2;
				_nextPointDisplayTime = 0f;
				for (int i = 0; i < dataSet.Data.Count; i++)
				{
					Vector2 vector2 = DataPointToLineNormalisedPosition(dataSet.Data[i], _inverted);
					GraphPoint obj = _theGraphPoints[i];
					float newX = (vector2.x - vector.x) * _graphWidth;
					obj.CurrentPoint.Set(newX, 0f);
					obj.DestPoint.Set(newX, _graphYOffset + vector2.y * _graphHeight);
				}
				IsSettled = false;
				_triggeredAudio = false;
				Process(bImmediate);
				_lineRenderer.enabled = true;
				if ((bool)_lineRendererTheSecond)
				{
					_lineRendererTheSecond.enabled = true;
				}
			}
			else
			{
				_lineRenderer.enabled = false;
				if ((bool)_lineRendererTheSecond)
				{
					_lineRendererTheSecond.enabled = false;
				}
			}
		}

		private void ToggleGraph()
		{
			bool pressedState = !_assignedButton.IsDown;
			_assignedButton.SetPressedState(pressedState);
			if ((bool)_lineRenderer)
			{
				_lineRenderer.enabled = pressedState;
				if ((bool)_lineRendererTheSecond)
				{
					_lineRendererTheSecond.enabled = pressedState;
				}
			}
			ShowGraph();
		}

		public bool GetScreenToDataPoint(Vector2 mousePosition, out Vector2 pickerPos, out string valueText, bool snapToPoints = false)
		{
			if ((bool)_lineRenderer && _lineRenderer.enabled)
			{
				DataSet dataSet = null;
				switch (_currentDataSet)
				{
				case DataSets.DataSetMonthly:
					dataSet = _monthlyData;
					break;
				case DataSets.DataSetQuarterly:
					dataSet = _quarterlyData;
					break;
				case DataSets.DataSetYearly:
					dataSet = _yearlyData;
					break;
				}
				if (dataSet != null)
				{
					Vector2 zero = Vector2.zero;
					RectTransformUtility.ScreenPointToLocalPointInRectangle(_theRectTransform, Input.mousePosition, null, out var localPoint);
					zero.Set(localPoint.x / _theRectTransform.rect.width + _theRectTransform.pivot.x, localPoint.y / _theRectTransform.rect.height + _theRectTransform.pivot.y);
					LineGraph.DataVector2 dataVector = new LineGraph.DataVector2(_minXValue + (double)zero.x * (_maxXValue - _minXValue), _minYValue + (double)zero.y * (_maxYValue - _minYValue));
					int num = (int)Math.Floor(dataVector.x);
					int num2 = (int)Math.Ceiling(dataVector.x);
					float num3 = (float)(dataVector.x - (double)num);
					if (snapToPoints)
					{
						int num4 = 0;
						num4 = ((num >= _graphPointCount || num2 >= _graphPointCount) ? (_graphPointCount - 1) : ((num2 != 0) ? ((num3 < 0.5f) ? num : num2) : 0));
						pickerPos = _theGraphPoints[num4].CurrentPoint;
						double y = dataSet.Data[num4].y;
						switch (_graphType)
						{
						case GraphType.TypeMoney:
							valueText = StringUtils.FormatCurrency((int)Math.Round(y));
							break;
						case GraphType.TypePercentage:
							valueText = StringUtils.FormatPercentageValue((float)y);
							break;
						case GraphType.TypePercentage100:
							valueText = StringUtils.FormatPercentageValue((float)y / 100f);
							break;
						case GraphType.TypeCount:
							valueText = $"{y:0}";
							break;
						default:
							valueText = "";
							break;
						}
						return true;
					}
					if (num2 < _graphPointCount)
					{
						LineGraph.DataVector2 dataVector2 = dataSet.Data[num];
						LineGraph.DataVector2 dataVector3 = dataSet.Data[num2];
						float num5 = Mathf.Lerp((float)dataVector2.y, (float)dataVector3.y, num3);
						pickerPos = Vector2.Lerp(_theGraphPoints[num].CurrentPoint, _theGraphPoints[num2].CurrentPoint, num3);
						if (_graphType == GraphType.TypePercentage100)
						{
							if ((float)dataVector3.y >= 99.9f && num3 >= 0.9925f)
							{
								num5 = (float)dataVector3.y;
							}
							else if ((float)dataVector2.y >= 99.9f && num3 <= 0.0075f)
							{
								num5 = (float)dataVector2.y;
							}
						}
						switch (_graphType)
						{
						case GraphType.TypeMoney:
							valueText = StringUtils.FormatCurrency((int)Math.Round(num5));
							break;
						case GraphType.TypePercentage:
							valueText = StringUtils.FormatPercentageValue(num5);
							break;
						case GraphType.TypePercentage100:
							valueText = StringUtils.FormatPercentageValue(num5 / 100f);
							break;
						case GraphType.TypeCount:
							valueText = $"{num5:0}";
							break;
						default:
							valueText = "";
							break;
						}
						return true;
					}
				}
			}
			valueText = "";
			pickerPos = Vector2.zero;
			return false;
		}

		public void AssignMonthlyData(List<LineGraph.DataVector2> data)
		{
			_monthlyData.AssignData(data);
		}

		public void AssignQuarterlyData(List<LineGraph.DataVector2> data)
		{
			_quarterlyData.AssignData(data);
		}

		public void AssignYearlyData(List<LineGraph.DataVector2> data)
		{
			_yearlyData.AssignData(data);
		}

		public void ShowMonthlyData()
		{
			ShowGraphInternal(DataSets.DataSetMonthly);
		}

		public void ShowQuarterlyData()
		{
			ShowGraphInternal(DataSets.DataSetQuarterly);
		}

		public void ShowYearlyData()
		{
			ShowGraphInternal(DataSets.DataSetYearly);
		}

		public void SetInverted(bool shouldInvertScore)
		{
			_inverted = shouldInvertScore;
		}
	}
}
