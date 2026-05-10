using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class Axis : MainComponent
	{
		public enum AxisType
		{
			Value = 0,
			Category = 1,
			Log = 2,
			Time = 3
		}

		public enum AxisMinMaxType
		{
			Default = 0,
			MinMax = 1,
			Custom = 2,
			MinMaxAuto = 3
		}

		public enum AxisPosition
		{
			Left = 0,
			Right = 1,
			Bottom = 2,
			Top = 3
		}

		[SerializeField]
		protected bool m_Show = true;

		[SerializeField]
		protected AxisType m_Type;

		[SerializeField]
		protected AxisMinMaxType m_MinMaxType;

		[SerializeField]
		protected int m_GridIndex;

		[SerializeField]
		protected int m_PolarIndex;

		[SerializeField]
		protected int m_ParallelIndex;

		[SerializeField]
		protected AxisPosition m_Position;

		[SerializeField]
		protected float m_Offset;

		[SerializeField]
		protected double m_Min;

		[SerializeField]
		protected double m_Max;

		[SerializeField]
		protected int m_SplitNumber;

		[SerializeField]
		protected double m_Interval;

		[SerializeField]
		protected bool m_BoundaryGap = true;

		[SerializeField]
		protected int m_MaxCache;

		[SerializeField]
		protected float m_LogBase = 10f;

		[SerializeField]
		protected bool m_LogBaseE;

		[SerializeField]
		protected double m_CeilRate;

		[SerializeField]
		protected bool m_Inverse;

		[SerializeField]
		private bool m_Clockwise = true;

		[SerializeField]
		private bool m_InsertDataToHead;

		[SerializeField]
		protected List<Sprite> m_Icons = new List<Sprite>();

		[SerializeField]
		protected List<string> m_Data = new List<string>();

		[SerializeField]
		protected AxisLine m_AxisLine = AxisLine.defaultAxisLine;

		[SerializeField]
		protected AxisName m_AxisName = AxisName.defaultAxisName;

		[SerializeField]
		protected AxisTick m_AxisTick = AxisTick.defaultTick;

		[SerializeField]
		protected AxisLabel m_AxisLabel = AxisLabel.defaultAxisLabel;

		[SerializeField]
		protected AxisSplitLine m_SplitLine = AxisSplitLine.defaultSplitLine;

		[SerializeField]
		protected AxisSplitArea m_SplitArea = AxisSplitArea.defaultSplitArea;

		[SerializeField]
		[Since("v3.2.0")]
		protected AxisMinorTick m_MinorTick = AxisMinorTick.defaultMinorTick;

		[SerializeField]
		[Since("v3.2.0")]
		protected AxisMinorSplitLine m_MinorSplitLine = AxisMinorSplitLine.defaultMinorSplitLine;

		[SerializeField]
		[Since("v3.4.0")]
		protected LabelStyle m_IndicatorLabel = new LabelStyle
		{
			numericFormatter = "f2"
		};

		public AxisContext context = new AxisContext();

		public bool show
		{
			get
			{
				return m_Show;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Show, value))
				{
					SetAllDirty();
				}
			}
		}

		public AxisType type
		{
			get
			{
				return m_Type;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Type, value))
				{
					SetAllDirty();
				}
			}
		}

		public AxisMinMaxType minMaxType
		{
			get
			{
				return m_MinMaxType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MinMaxType, value))
				{
					SetAllDirty();
				}
			}
		}

		public int gridIndex
		{
			get
			{
				return m_GridIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_GridIndex, value))
				{
					SetAllDirty();
				}
			}
		}

		public int polarIndex
		{
			get
			{
				return m_PolarIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_PolarIndex, value))
				{
					SetAllDirty();
				}
			}
		}

		public int parallelIndex
		{
			get
			{
				return m_ParallelIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ParallelIndex, value))
				{
					SetAllDirty();
				}
			}
		}

		public AxisPosition position
		{
			get
			{
				return m_Position;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Position, value))
				{
					SetAllDirty();
				}
			}
		}

		public float offset
		{
			get
			{
				return m_Offset;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Offset, value))
				{
					SetAllDirty();
				}
			}
		}

		public double min
		{
			get
			{
				return m_Min;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Min, value))
				{
					SetAllDirty();
				}
			}
		}

		public double max
		{
			get
			{
				return m_Max;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Max, value))
				{
					SetAllDirty();
				}
			}
		}

		public int splitNumber
		{
			get
			{
				return m_SplitNumber;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SplitNumber, value))
				{
					SetAllDirty();
				}
			}
		}

		public double interval
		{
			get
			{
				return m_Interval;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Interval, value))
				{
					SetAllDirty();
				}
			}
		}

		public bool boundaryGap
		{
			get
			{
				if (!IsCategory())
				{
					return false;
				}
				return m_BoundaryGap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BoundaryGap, value))
				{
					SetAllDirty();
				}
			}
		}

		public float logBase
		{
			get
			{
				return m_LogBase;
			}
			set
			{
				if (value <= 0f || value == 1f)
				{
					value = 10f;
				}
				if (PropertyUtil.SetStruct(ref m_LogBase, value))
				{
					SetAllDirty();
				}
			}
		}

		public bool logBaseE
		{
			get
			{
				return m_LogBaseE;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LogBaseE, value))
				{
					SetAllDirty();
				}
			}
		}

		public int maxCache
		{
			get
			{
				return m_MaxCache;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MaxCache, (value >= 0) ? value : 0))
				{
					SetAllDirty();
				}
			}
		}

		public double ceilRate
		{
			get
			{
				return m_CeilRate;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_CeilRate, (value < 0.0) ? 0.0 : value))
				{
					SetAllDirty();
				}
			}
		}

		public bool inverse
		{
			get
			{
				return m_Inverse;
			}
			set
			{
				if (m_Type == AxisType.Value && PropertyUtil.SetStruct(ref m_Inverse, value))
				{
					SetAllDirty();
				}
			}
		}

		public bool clockwise
		{
			get
			{
				return m_Clockwise;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Clockwise, value))
				{
					SetAllDirty();
				}
			}
		}

		public List<string> data
		{
			get
			{
				return m_Data;
			}
			set
			{
				if (value != null)
				{
					m_Data = value;
					SetAllDirty();
				}
			}
		}

		public List<Sprite> icons
		{
			get
			{
				return m_Icons;
			}
			set
			{
				if (value != null)
				{
					m_Icons = value;
					SetAllDirty();
				}
			}
		}

		public AxisLine axisLine
		{
			get
			{
				return m_AxisLine;
			}
			set
			{
				if (value != null)
				{
					m_AxisLine = value;
					SetVerticesDirty();
				}
			}
		}

		public AxisName axisName
		{
			get
			{
				return m_AxisName;
			}
			set
			{
				if (value != null)
				{
					m_AxisName = value;
					SetComponentDirty();
				}
			}
		}

		public AxisTick axisTick
		{
			get
			{
				return m_AxisTick;
			}
			set
			{
				if (value != null)
				{
					m_AxisTick = value;
					SetVerticesDirty();
				}
			}
		}

		public AxisLabel axisLabel
		{
			get
			{
				return m_AxisLabel;
			}
			set
			{
				if (value != null)
				{
					m_AxisLabel = value;
					SetComponentDirty();
				}
			}
		}

		public AxisSplitLine splitLine
		{
			get
			{
				return m_SplitLine;
			}
			set
			{
				if (value != null)
				{
					m_SplitLine = value;
					SetVerticesDirty();
				}
			}
		}

		public AxisSplitArea splitArea
		{
			get
			{
				return m_SplitArea;
			}
			set
			{
				if (value != null)
				{
					m_SplitArea = value;
					SetVerticesDirty();
				}
			}
		}

		public AxisMinorTick minorTick
		{
			get
			{
				return m_MinorTick;
			}
			set
			{
				if (value != null)
				{
					m_MinorTick = value;
					SetVerticesDirty();
				}
			}
		}

		public AxisMinorSplitLine minorSplitLine
		{
			get
			{
				return m_MinorSplitLine;
			}
			set
			{
				if (value != null)
				{
					m_MinorSplitLine = value;
					SetVerticesDirty();
				}
			}
		}

		public LabelStyle indicatorLabel
		{
			get
			{
				return m_IndicatorLabel;
			}
			set
			{
				if (value != null)
				{
					m_IndicatorLabel = value;
					SetComponentDirty();
				}
			}
		}

		public bool insertDataToHead
		{
			get
			{
				return m_InsertDataToHead;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_InsertDataToHead, value))
				{
					SetAllDirty();
				}
			}
		}

		public override bool vertsDirty
		{
			get
			{
				if (!m_VertsDirty && !axisLine.anyDirty && !axisTick.anyDirty && !splitLine.anyDirty && !splitArea.anyDirty && !minorTick.anyDirty)
				{
					return minorSplitLine.anyDirty;
				}
				return true;
			}
		}

		public override bool componentDirty
		{
			get
			{
				if (!m_ComponentDirty && !axisName.anyDirty && !axisLabel.anyDirty)
				{
					return indicatorLabel.anyDirty;
				}
				return true;
			}
		}

		public override void ClearComponentDirty()
		{
			base.ClearComponentDirty();
			axisName.ClearComponentDirty();
			axisLabel.ClearComponentDirty();
			indicatorLabel.ClearComponentDirty();
		}

		public override void ClearVerticesDirty()
		{
			base.ClearVerticesDirty();
			axisLabel.ClearVerticesDirty();
			axisLine.ClearVerticesDirty();
			axisTick.ClearVerticesDirty();
			splitLine.ClearVerticesDirty();
			splitArea.ClearVerticesDirty();
			minorTick.ClearVerticesDirty();
			minorSplitLine.ClearVerticesDirty();
			indicatorLabel.ClearComponentDirty();
		}

		public override void SetComponentDirty()
		{
			context.isNeedUpdateFilterData = true;
			base.SetComponentDirty();
		}

		public Axis Clone()
		{
			Axis obj = new Axis
			{
				show = show,
				type = type,
				gridIndex = 0,
				minMaxType = minMaxType,
				min = min,
				max = max,
				splitNumber = splitNumber,
				interval = interval,
				boundaryGap = boundaryGap,
				maxCache = maxCache,
				logBase = logBase,
				logBaseE = logBaseE,
				ceilRate = ceilRate,
				insertDataToHead = insertDataToHead,
				axisLine = axisLine.Clone(),
				axisName = axisName.Clone(),
				axisTick = axisTick.Clone(),
				axisLabel = axisLabel.Clone(),
				splitLine = splitLine.Clone(),
				splitArea = splitArea.Clone(),
				minorTick = minorTick.Clone(),
				minorSplitLine = minorSplitLine.Clone(),
				indicatorLabel = indicatorLabel.Clone(),
				icons = new List<Sprite>(),
				data = new List<string>()
			};
			ChartHelper.CopyList(obj.data, data);
			return obj;
		}

		public void Copy(Axis axis)
		{
			show = axis.show;
			type = axis.type;
			minMaxType = axis.minMaxType;
			gridIndex = axis.gridIndex;
			min = axis.min;
			max = axis.max;
			splitNumber = axis.splitNumber;
			interval = axis.interval;
			boundaryGap = axis.boundaryGap;
			maxCache = axis.maxCache;
			logBase = axis.logBase;
			logBaseE = axis.logBaseE;
			ceilRate = axis.ceilRate;
			insertDataToHead = axis.insertDataToHead;
			axisLine.Copy(axis.axisLine);
			axisName.Copy(axis.axisName);
			axisTick.Copy(axis.axisTick);
			axisLabel.Copy(axis.axisLabel);
			splitLine.Copy(axis.splitLine);
			splitArea.Copy(axis.splitArea);
			minorTick.Copy(axis.minorTick);
			minorSplitLine.Copy(axis.minorSplitLine);
			indicatorLabel.Copy(axis.indicatorLabel);
			ChartHelper.CopyList(data, axis.data);
			ChartHelper.CopyList(icons, axis.icons);
		}

		public override void ClearData()
		{
			m_Data.Clear();
			m_Icons.Clear();
			context.Clear();
			SetAllDirty();
		}

		public bool IsCategory()
		{
			return m_Type == AxisType.Category;
		}

		public bool IsValue()
		{
			return m_Type == AxisType.Value;
		}

		public bool IsLog()
		{
			return m_Type == AxisType.Log;
		}

		public bool IsTime()
		{
			return m_Type == AxisType.Time;
		}

		public bool IsLeft()
		{
			return m_Position == AxisPosition.Left;
		}

		public bool IsRight()
		{
			return m_Position == AxisPosition.Right;
		}

		public bool IsTop()
		{
			return m_Position == AxisPosition.Top;
		}

		public bool IsBottom()
		{
			return m_Position == AxisPosition.Bottom;
		}

		public bool IsNeedShowLabel(int index, int total = 0)
		{
			if (total == 0)
			{
				total = context.labelValueList.Count;
			}
			return axisLabel.IsNeedShowLabel(index, total);
		}

		public void SetNeedUpdateFilterData()
		{
			context.isNeedUpdateFilterData = true;
		}

		public void AddData(string category)
		{
			if (maxCache > 0)
			{
				while (m_Data.Count >= maxCache)
				{
					RemoveData(m_InsertDataToHead ? (m_Data.Count - 1) : 0);
				}
			}
			if (m_InsertDataToHead)
			{
				m_Data.Insert(0, category);
			}
			else
			{
				m_Data.Add(category);
			}
			SetAllDirty();
		}

		public void RemoveData(int dataIndex)
		{
			context.isNeedUpdateFilterData = true;
			m_Data.RemoveAt(dataIndex);
		}

		public void UpdateData(int index, string category)
		{
			if (index >= 0 && index < m_Data.Count)
			{
				m_Data[index] = category;
				SetComponentDirty();
			}
		}

		public void AddIcon(Sprite icon)
		{
			if (maxCache > 0)
			{
				while (m_Icons.Count > maxCache)
				{
					m_Icons.RemoveAt(m_InsertDataToHead ? (m_Icons.Count - 1) : 0);
				}
			}
			if (m_InsertDataToHead)
			{
				m_Icons.Insert(0, icon);
			}
			else
			{
				m_Icons.Add(icon);
			}
			SetAllDirty();
		}

		public void UpdateIcon(int index, Sprite icon)
		{
			if (index >= 0 && index < m_Icons.Count)
			{
				m_Icons[index] = icon;
				SetComponentDirty();
			}
		}

		public string GetData(int index)
		{
			if (index >= 0 && index < m_Data.Count)
			{
				return m_Data[index];
			}
			return null;
		}

		public string GetData(int index, DataZoom dataZoom)
		{
			List<string> dataList = GetDataList(dataZoom);
			if (index >= 0 && index < dataList.Count)
			{
				return dataList[index];
			}
			return "";
		}

		public Sprite GetIcon(int index)
		{
			if (index >= 0 && index < m_Icons.Count)
			{
				return m_Icons[index];
			}
			return null;
		}

		public float GetDistance(double value, float axisLength)
		{
			if (context.minMaxRange == 0.0)
			{
				return 0f;
			}
			if (IsCategory() && boundaryGap)
			{
				return (float)((double)(axisLength / (float)data.Count) * (value + 0.5));
			}
			return axisLength * (float)((value - context.minValue) / context.minMaxRange);
		}

		public float GetValueLength(double value, float axisLength)
		{
			if (context.minMaxRange > 0.0)
			{
				return axisLength * (float)(value / context.minMaxRange);
			}
			return 0f;
		}

		internal List<string> GetDataList(DataZoom dataZoom)
		{
			if (dataZoom != null && dataZoom.enable && dataZoom.IsContainsAxis(this))
			{
				UpdateFilterData(dataZoom);
				return context.filterData;
			}
			if (m_Data.Count <= 0)
			{
				return context.runtimeData;
			}
			return m_Data;
		}

		internal List<string> GetDataList()
		{
			if (m_Data.Count <= 0)
			{
				return context.runtimeData;
			}
			return m_Data;
		}

		internal void UpdateFilterData(DataZoom dataZoom)
		{
			if (dataZoom != null && dataZoom.enable && dataZoom.IsContainsAxis(this))
			{
				List<string> dataList = GetDataList();
				context.UpdateFilterData(dataList, dataZoom);
			}
		}

		internal int GetDataCount(DataZoom dataZoom)
		{
			if (!IsCategory())
			{
				return 0;
			}
			return GetDataList(dataZoom).Count;
		}

		internal void UpdateLabelText(float coordinateWidth, DataZoom dataZoom, bool forcePercent)
		{
			for (int i = 0; i < context.labelObjectList.Count; i++)
			{
				if (context.labelObjectList[i] != null)
				{
					string labelName = AxisHelper.GetLabelName(this, coordinateWidth, i, context.minValue, context.maxValue, dataZoom, forcePercent);
					context.labelObjectList[i].SetText(labelName);
				}
			}
		}

		internal Vector3 GetLabelObjectPosition(int index)
		{
			if (context.labelObjectList != null && index < context.labelObjectList.Count)
			{
				return context.labelObjectList[index].GetPosition();
			}
			return Vector3.zero;
		}

		internal void UpdateMinMaxValue(double minValue, double maxValue)
		{
			context.minValue = minValue;
			context.maxValue = maxValue;
			double num = maxValue - minValue;
			if (context.minMaxRange != num)
			{
				context.minMaxRange = num;
				if (type == AxisType.Value && interval > 0.0)
				{
					SetComponentDirty();
				}
			}
		}

		public float GetLogValue(double value)
		{
			if (value <= 0.0 || value == 1.0)
			{
				return 0f;
			}
			if (!logBaseE)
			{
				return (float)Math.Log(value, logBase);
			}
			return (float)Math.Log(value);
		}

		public double GetLogMinIndex()
		{
			if (!logBaseE)
			{
				return Math.Log(context.minValue, logBase);
			}
			return Math.Log(context.minValue);
		}

		public double GetLogMaxIndex()
		{
			if (!logBaseE)
			{
				return Math.Log(context.maxValue, logBase);
			}
			return Math.Log(context.maxValue);
		}

		public double GetLabelValue(int index)
		{
			if (index < 0)
			{
				return context.minValue;
			}
			if (index > context.labelValueList.Count - 1)
			{
				return context.maxValue;
			}
			return context.labelValueList[index];
		}

		public double GetLastLabelValue()
		{
			if (context.labelValueList.Count > 0)
			{
				return context.labelValueList[context.labelValueList.Count - 1];
			}
			return 0.0;
		}

		public void UpdateZeroOffset(float axisLength)
		{
			context.offset = ((context.minValue > 0.0 || context.minMaxRange == 0.0) ? 0f : ((context.maxValue < 0.0) ? axisLength : ((float)(Math.Abs(context.minValue) * ((double)axisLength / (Math.Abs(context.minValue) + Math.Abs(context.maxValue)))))));
		}
	}
}
