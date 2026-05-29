using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Serializable]
	public class SymbolStyle : ChildComponent
	{
		[SerializeField]
		protected bool m_Show = true;

		[SerializeField]
		protected SymbolType m_Type = SymbolType.EmptyCircle;

		[SerializeField]
		protected float m_Size;

		[SerializeField]
		protected float m_Gap;

		[SerializeField]
		protected float m_Width;

		[SerializeField]
		protected float m_Height;

		[SerializeField]
		protected Vector2 m_Offset = Vector2.zero;

		[SerializeField]
		protected Sprite m_Image;

		[SerializeField]
		protected Image.Type m_ImageType;

		[SerializeField]
		protected Color32 m_Color;

		private List<float> m_AnimationSize = new List<float> { 0f, 5f, 10f };

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

		public SymbolType type
		{
			get
			{
				return m_Type;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Type, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float size
		{
			get
			{
				return m_Size;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Size, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float gap
		{
			get
			{
				return m_Gap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Gap, value))
				{
					SetVerticesDirty();
				}
			}
		}

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
					SetAllDirty();
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
					SetAllDirty();
				}
			}
		}

		public Sprite image
		{
			get
			{
				return m_Image;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Image, value))
				{
					SetAllDirty();
				}
			}
		}

		public Image.Type imageType
		{
			get
			{
				return m_ImageType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ImageType, value))
				{
					SetAllDirty();
				}
			}
		}

		public Vector2 offset
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

		public Color32 color
		{
			get
			{
				return m_Color;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Color, value))
				{
					SetAllDirty();
				}
			}
		}

		public Vector3 offset3 => new Vector3(m_Offset.x, m_Offset.y, 0f);

		public List<float> animationSize => m_AnimationSize;

		public virtual void Reset()
		{
			m_Show = false;
			m_Type = SymbolType.EmptyCircle;
			m_Size = 0f;
			m_Gap = 0f;
			m_Width = 0f;
			m_Height = 0f;
			m_Offset = Vector2.zero;
			m_Image = null;
			m_ImageType = Image.Type.Simple;
		}

		public Color32 GetColor(Color32 defaultColor)
		{
			if (!ChartHelper.IsClearColor(m_Color))
			{
				return m_Color;
			}
			return defaultColor;
		}
	}
}
