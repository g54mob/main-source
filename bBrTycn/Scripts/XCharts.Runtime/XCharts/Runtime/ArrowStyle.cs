using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class ArrowStyle : ChildComponent
	{
		[SerializeField]
		private float m_Width = 10f;

		[SerializeField]
		private float m_Height = 15f;

		[SerializeField]
		private float m_Offset;

		[SerializeField]
		private float m_Dent = 3f;

		[SerializeField]
		private Color32 m_Color = Color.clear;

		public float width
		{
			get
			{
				return m_Width;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Width, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float height
		{
			get
			{
				return m_Height;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Height, value))
				{
					SetVerticesDirty();
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
					SetVerticesDirty();
				}
			}
		}

		public float dent
		{
			get
			{
				return m_Dent;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Dent, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 color
		{
			get
			{
				return m_Color;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_Color, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public ArrowStyle Clone()
		{
			return new ArrowStyle
			{
				width = width,
				height = height,
				offset = offset,
				dent = dent,
				color = color
			};
		}

		public void Copy(ArrowStyle arrow)
		{
			width = arrow.width;
			height = arrow.height;
			offset = arrow.offset;
			dent = arrow.dent;
			color = arrow.color;
		}

		public Color32 GetColor(Color32 defaultColor)
		{
			if (ChartHelper.IsClearColor(color))
			{
				return defaultColor;
			}
			return color;
		}
	}
}
