using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class SerieSymbol : SymbolStyle, ISerieDataComponent
	{
		[SerializeField]
		private SymbolSizeType m_SizeType;

		[SerializeField]
		private int m_DataIndex = 1;

		[SerializeField]
		private float m_DataScale = 1f;

		[SerializeField]
		private SymbolSizeFunction m_SizeFunction;

		[SerializeField]
		private int m_StartIndex;

		[SerializeField]
		private int m_Interval;

		[SerializeField]
		private bool m_ForceShowLast;

		[SerializeField]
		private bool m_Repeat;

		[SerializeField]
		[Since("v3.3.0")]
		private float m_MinSize;

		[SerializeField]
		[Since("v3.3.0")]
		private float m_MaxSize;

		public SymbolSizeType sizeType
		{
			get
			{
				return m_SizeType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SizeType, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int dataIndex
		{
			get
			{
				return m_DataIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_DataIndex, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float dataScale
		{
			get
			{
				return m_DataScale;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_DataScale, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public SymbolSizeFunction sizeFunction
		{
			get
			{
				return m_SizeFunction;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_SizeFunction, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int startIndex
		{
			get
			{
				return m_StartIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_StartIndex, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int interval
		{
			get
			{
				return m_Interval;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Interval, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool forceShowLast
		{
			get
			{
				return m_ForceShowLast;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ForceShowLast, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool repeat
		{
			get
			{
				return m_Repeat;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Repeat, value))
				{
					SetAllDirty();
				}
			}
		}

		public float minSize
		{
			get
			{
				return m_MinSize;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MinSize, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float maxSize
		{
			get
			{
				return m_MaxSize;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MaxSize, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public override void Reset()
		{
			base.Reset();
			m_SizeType = SymbolSizeType.Custom;
			m_DataIndex = 1;
			m_DataScale = 1f;
			m_SizeFunction = null;
			m_StartIndex = 0;
			m_Interval = 0;
			m_ForceShowLast = false;
			m_Repeat = false;
			m_MinSize = 0f;
			m_MaxSize = 0f;
		}

		public float GetSize(List<double> data, float themeSize)
		{
			switch (m_SizeType)
			{
			case SymbolSizeType.Custom:
				if (base.size != 0f)
				{
					return base.size;
				}
				return themeSize;
			case SymbolSizeType.FromData:
				if (data != null && dataIndex >= 0 && dataIndex < data.Count)
				{
					float num = (float)data[dataIndex] * m_DataScale;
					if (m_MinSize != 0f && num < m_MinSize)
					{
						num = m_MinSize;
					}
					if (m_MaxSize != 0f && num > m_MaxSize)
					{
						num = m_MaxSize;
					}
					return num;
				}
				if (base.size != 0f)
				{
					return base.size;
				}
				return themeSize;
			case SymbolSizeType.Function:
				if (data != null && sizeFunction != null)
				{
					return sizeFunction(data);
				}
				if (base.size != 0f)
				{
					return base.size;
				}
				return themeSize;
			default:
				if (base.size != 0f)
				{
					return base.size;
				}
				return themeSize;
			}
		}

		public bool ShowSymbol(int dataIndex, int dataCount)
		{
			if (!base.show)
			{
				return false;
			}
			if (dataIndex < startIndex)
			{
				return false;
			}
			if (m_Interval <= 0)
			{
				return true;
			}
			if (m_ForceShowLast && dataIndex == dataCount - 1)
			{
				return true;
			}
			return (dataIndex - startIndex) % (m_Interval + 1) == 0;
		}
	}
}
