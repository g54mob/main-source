using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class Location : ChildComponent, IPropertyChanged
	{
		public enum Align
		{
			TopLeft = 0,
			TopRight = 1,
			TopCenter = 2,
			BottomLeft = 3,
			BottomRight = 4,
			BottomCenter = 5,
			Center = 6,
			CenterLeft = 7,
			CenterRight = 8
		}

		[SerializeField]
		private Align m_Align = Align.TopCenter;

		[SerializeField]
		private float m_Left;

		[SerializeField]
		private float m_Right;

		[SerializeField]
		private float m_Top;

		[SerializeField]
		private float m_Bottom;

		private TextAnchor m_TextAlignment;

		private Vector2 m_AnchorMin;

		private Vector2 m_AnchorMax;

		private Vector2 m_Pivot;

		public Align align
		{
			get
			{
				return m_Align;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Align, value))
				{
					SetComponentDirty();
					UpdateAlign();
				}
			}
		}

		public float left
		{
			get
			{
				return m_Left;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Left, value))
				{
					SetComponentDirty();
					UpdateAlign();
				}
			}
		}

		public float right
		{
			get
			{
				return m_Right;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Right, value))
				{
					SetComponentDirty();
					UpdateAlign();
				}
			}
		}

		public float top
		{
			get
			{
				return m_Top;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Top, value))
				{
					SetComponentDirty();
					UpdateAlign();
				}
			}
		}

		public float bottom
		{
			get
			{
				return m_Bottom;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Bottom, value))
				{
					SetComponentDirty();
					UpdateAlign();
				}
			}
		}

		public TextAnchor runtimeTextAlignment => m_TextAlignment;

		public Vector2 runtimeAnchorMin => m_AnchorMin;

		public Vector2 runtimeAnchorMax => m_AnchorMax;

		public Vector2 runtimePivot => m_Pivot;

		public float runtimeLeft { get; private set; }

		public float runtimeRight { get; private set; }

		public float runtimeBottom { get; private set; }

		public float runtimeTop { get; private set; }

		public static Location defaultLeft => new Location
		{
			align = Align.CenterLeft,
			left = 0.03f,
			right = 0f,
			top = 0f,
			bottom = 0f
		};

		public static Location defaultRight => new Location
		{
			align = Align.CenterRight,
			left = 0f,
			right = 0.03f,
			top = 0f,
			bottom = 0f
		};

		public static Location defaultTop => new Location
		{
			align = Align.TopCenter,
			left = 0f,
			right = 0f,
			top = 0.03f,
			bottom = 0f
		};

		public static Location defaultBottom => new Location
		{
			align = Align.BottomCenter,
			left = 0f,
			right = 0f,
			top = 0f,
			bottom = 0.03f
		};

		private void UpdateAlign()
		{
			switch (m_Align)
			{
			case Align.BottomCenter:
				m_TextAlignment = TextAnchor.LowerCenter;
				m_AnchorMin = new Vector2(0.5f, 0f);
				m_AnchorMax = new Vector2(0.5f, 0f);
				m_Pivot = new Vector2(0.5f, 0f);
				break;
			case Align.BottomLeft:
				m_TextAlignment = TextAnchor.LowerLeft;
				m_AnchorMin = new Vector2(0f, 0f);
				m_AnchorMax = new Vector2(0f, 0f);
				m_Pivot = new Vector2(0f, 0f);
				break;
			case Align.BottomRight:
				m_TextAlignment = TextAnchor.LowerRight;
				m_AnchorMin = new Vector2(1f, 0f);
				m_AnchorMax = new Vector2(1f, 0f);
				m_Pivot = new Vector2(1f, 0f);
				break;
			case Align.Center:
				m_TextAlignment = TextAnchor.MiddleCenter;
				m_AnchorMin = new Vector2(0.5f, 0.5f);
				m_AnchorMax = new Vector2(0.5f, 0.5f);
				m_Pivot = new Vector2(0.5f, 0.5f);
				break;
			case Align.CenterLeft:
				m_TextAlignment = TextAnchor.MiddleLeft;
				m_AnchorMin = new Vector2(0f, 0.5f);
				m_AnchorMax = new Vector2(0f, 0.5f);
				m_Pivot = new Vector2(0f, 0.5f);
				break;
			case Align.CenterRight:
				m_TextAlignment = TextAnchor.MiddleRight;
				m_AnchorMin = new Vector2(1f, 0.5f);
				m_AnchorMax = new Vector2(1f, 0.5f);
				m_Pivot = new Vector2(1f, 0.5f);
				break;
			case Align.TopCenter:
				m_TextAlignment = TextAnchor.UpperCenter;
				m_AnchorMin = new Vector2(0.5f, 1f);
				m_AnchorMax = new Vector2(0.5f, 1f);
				m_Pivot = new Vector2(0.5f, 1f);
				break;
			case Align.TopLeft:
				m_TextAlignment = TextAnchor.UpperLeft;
				m_AnchorMin = new Vector2(0f, 1f);
				m_AnchorMax = new Vector2(0f, 1f);
				m_Pivot = new Vector2(0f, 1f);
				break;
			case Align.TopRight:
				m_TextAlignment = TextAnchor.UpperRight;
				m_AnchorMin = new Vector2(1f, 1f);
				m_AnchorMax = new Vector2(1f, 1f);
				m_Pivot = new Vector2(1f, 1f);
				break;
			}
		}

		public bool IsBottom()
		{
			Align align = m_Align;
			if ((uint)(align - 3) <= 2u)
			{
				return true;
			}
			return false;
		}

		public bool IsTop()
		{
			Align align = m_Align;
			if ((uint)align <= 2u)
			{
				return true;
			}
			return false;
		}

		public bool IsCenter()
		{
			Align align = m_Align;
			if ((uint)(align - 6) <= 2u)
			{
				return true;
			}
			return false;
		}

		public void UpdateRuntimeData(float chartWidth, float chartHeight)
		{
			runtimeLeft = ((left <= 1f) ? (left * chartWidth) : left);
			runtimeRight = ((right <= 1f) ? (right * chartWidth) : right);
			runtimeTop = ((top <= 1f) ? (top * chartHeight) : top);
			runtimeBottom = ((bottom <= 1f) ? (bottom * chartHeight) : bottom);
		}

		public Vector3 GetPosition(float chartWidth, float chartHeight)
		{
			UpdateRuntimeData(chartWidth, chartHeight);
			return align switch
			{
				Align.BottomCenter => new Vector3(chartWidth / 2f, runtimeBottom), 
				Align.BottomLeft => new Vector3(runtimeLeft, runtimeBottom), 
				Align.BottomRight => new Vector3(chartWidth - runtimeRight, runtimeBottom), 
				Align.Center => new Vector3(chartWidth / 2f, chartHeight / 2f), 
				Align.CenterLeft => new Vector3(runtimeLeft, chartHeight / 2f), 
				Align.CenterRight => new Vector3(chartWidth - runtimeRight, chartHeight / 2f), 
				Align.TopCenter => new Vector3(chartWidth / 2f, chartHeight - runtimeTop), 
				Align.TopLeft => new Vector3(runtimeLeft, chartHeight - runtimeTop), 
				Align.TopRight => new Vector3(chartWidth - runtimeRight, chartHeight - runtimeTop), 
				_ => Vector2.zero, 
			};
		}

		public void OnChanged()
		{
			UpdateAlign();
		}
	}
}
