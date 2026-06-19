using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20.UI
{
	[AddComponentMenu("UI/Line Graph", 102)]
	[ExecuteInEditMode]
	public class LineGraph : UIBehaviour
	{
		[Serializable]
		public struct DataVector2
		{
			public double x;

			public double y;

			public DataVector2(double x, double y)
			{
				this.x = x;
				this.y = y;
			}

			public override string ToString()
			{
				return $"({x}, {y})";
			}
		}

		[Serializable]
		private class DataSet
		{
			public string Label = "";

			public LineGraphic LineGraphic;

			public Func<double, string> Formatter;

			public bool IsDataDirty;

			public List<DataVector2> Data = new List<DataVector2>();
		}

		private static List<Vector2> _cachedList = new List<Vector2>(128);

		[SerializeField]
		private float _lineThickness = 1f;

		[SerializeField]
		private float _lineBorderThickness = 1f;

		[SerializeField]
		private double _minXValue;

		[SerializeField]
		private double _maxXValue = 10.0;

		[SerializeField]
		private double _minYValue;

		[SerializeField]
		private double _maxYValue = 10.0;

		[SerializeField]
		private RectTransform _lines;

		[SerializeField]
		private List<DataSet> _dataSets = new List<DataSet>(4);

		private Func<double, string> _yValueFormatter;

		public double MinXValue
		{
			get
			{
				return _minXValue;
			}
			set
			{
				_minXValue = value;
				MarkAllDataAsDirty();
			}
		}

		public double MaxXValue
		{
			get
			{
				return _maxXValue;
			}
			set
			{
				_maxXValue = value;
				MarkAllDataAsDirty();
			}
		}

		public double MinYValue
		{
			get
			{
				return _minYValue;
			}
			set
			{
				_minYValue = value;
				MarkAllDataAsDirty();
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
				MarkAllDataAsDirty();
			}
		}

		public int NumOfDataSets => _dataSets.Count;

		protected void LateUpdate()
		{
			foreach (DataSet dataSet in _dataSets)
			{
				if (dataSet.IsDataDirty)
				{
					RebuildDataSet(dataSet);
					dataSet.IsDataDirty = false;
				}
			}
		}

		private void MarkAllDataAsDirty()
		{
			foreach (DataSet dataSet in _dataSets)
			{
				dataSet.IsDataDirty = true;
			}
		}

		private void RebuildDataSet(DataSet dataSet)
		{
			dataSet.LineGraphic.Points.Clear();
			_cachedList.Clear();
			for (int i = 0; i < dataSet.Data.Count; i++)
			{
				_cachedList.Add(DataPointToLineNormalisedPosition(dataSet.Data[i]));
			}
			dataSet.LineGraphic.Points = _cachedList;
		}

		public void ClearDataSets()
		{
			_dataSets.Clear();
		}

		public int AddDataSet(string label)
		{
			DataSet dataSet = new DataSet
			{
				Label = label
			};
			GameObject gameObject = new GameObject($"{label} Line Renderer");
			RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
			rectTransform.SetParent(_lines, worldPositionStays: false);
			rectTransform.SetAnchor(AnchorPresets.StretchAll);
			rectTransform.sizeDelta = Vector2.zero;
			dataSet.LineGraphic = gameObject.AddComponent<LineGraphic>();
			dataSet.LineGraphic.Thickness = _lineThickness;
			dataSet.LineGraphic.BorderThickness = _lineBorderThickness;
			_dataSets.Add(dataSet);
			return _dataSets.Count - 1;
		}

		private Vector2 DataPointToLineNormalisedPosition(DataVector2 point)
		{
			double num = (point.x - _minXValue) / (_maxXValue - _minXValue);
			double num2 = (point.y - _minYValue) / (_maxYValue - _minYValue);
			return new Vector2((float)num, (float)num2);
		}

		public Vector2 DataPointToScreenPosition(DataVector2 point)
		{
			Vector2 vector = DataPointToLineNormalisedPosition(point);
			Vector2 vector2 = new Vector2(_lines.rect.width * (vector.x - _lines.pivot.x), _lines.rect.height * (vector.y - _lines.pivot.y));
			return _lines.TransformPoint(vector2);
		}

		public DataVector2 ScreenPositionToDataPoint(Vector2 screenPosition)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_lines, screenPosition, null, out var localPoint);
			Vector2 vector = new Vector2(localPoint.x / _lines.rect.width + _lines.pivot.x, localPoint.y / _lines.rect.height + _lines.pivot.y);
			return new DataVector2(_minXValue + (double)vector.x * (_maxXValue - _minXValue), _minYValue + (double)vector.y * (_maxYValue - _minYValue));
		}

		public void SetLineColor(int dataSetIndex, Color color)
		{
			_dataSets[dataSetIndex].LineGraphic.color = color;
		}

		public void SetLineBorderColor(int dataSetIndex, Color color)
		{
			_dataSets[dataSetIndex].LineGraphic.BorderColor = color;
		}

		public Color GetLineColor(int dataSetIndex)
		{
			return _dataSets[dataSetIndex].LineGraphic.color;
		}

		public Color GetLineBorderColor(int dataSetIndex)
		{
			return _dataSets[dataSetIndex].LineGraphic.BorderColor;
		}

		public void SetData(int dataSetIndex, List<DataVector2> data)
		{
			DataSet dataSet = _dataSets[dataSetIndex];
			dataSet.Data.Clear();
			dataSet.Data.AddRange(data);
			dataSet.IsDataDirty = true;
		}

		public void GetData(int dataSetIndex, List<DataVector2> data)
		{
			data.AddRange(_dataSets[dataSetIndex].Data);
		}

		public DataVector2 GetDataVector(int dataSetIndex, int dataVectorIndex)
		{
			return _dataSets[dataSetIndex].Data[dataVectorIndex];
		}

		public int GetDataCount(int dataSetIndex)
		{
			return _dataSets[dataSetIndex].Data.Count;
		}

		public void SetYValueFormatter(Func<double, string> formatter)
		{
			_yValueFormatter = formatter;
		}

		public void SetYValueFormatter(int dataSetIndex, Func<double, string> formatter)
		{
			_dataSets[dataSetIndex].Formatter = formatter;
		}

		public bool GetYDataValue(int dataSetIndex, double x, out double y)
		{
			List<DataVector2> data = _dataSets[dataSetIndex].Data;
			if (data.Count > 0 && data[0].x <= x && data[data.Count - 1].x >= x)
			{
				for (int i = 0; i < data.Count - 1; i++)
				{
					DataVector2 dataVector = data[i];
					DataVector2 dataVector2 = data[i + 1];
					if (x >= dataVector.x && x <= dataVector2.x)
					{
						double num = (x - dataVector.x) / (dataVector2.x - dataVector.x);
						y = dataVector.y + num * (dataVector2.y - dataVector.y);
						return true;
					}
				}
			}
			y = 0.0;
			return false;
		}

		public string FormatYValue(int dataSetIndex, double y)
		{
			if (_dataSets[dataSetIndex].Formatter != null)
			{
				return _dataSets[dataSetIndex].Formatter(y);
			}
			if (_yValueFormatter != null)
			{
				return _yValueFormatter(y);
			}
			return y.ToString("N");
		}
	}
}
