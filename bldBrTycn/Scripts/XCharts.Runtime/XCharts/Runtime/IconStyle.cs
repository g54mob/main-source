using System;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Serializable]
	public class IconStyle : ChildComponent
	{
		public enum Layer
		{
			UnderText = 0,
			AboveText = 1
		}

		[SerializeField]
		private bool m_Show;

		[SerializeField]
		private Layer m_Layer;

		[SerializeField]
		private Align m_Align = Align.Left;

		[SerializeField]
		private Sprite m_Sprite;

		[SerializeField]
		private Image.Type m_Type;

		[SerializeField]
		private Color m_Color = Color.white;

		[SerializeField]
		private float m_Width = 20f;

		[SerializeField]
		private float m_Height = 20f;

		[SerializeField]
		private Vector3 m_Offset;

		[SerializeField]
		private bool m_AutoHideWhenLabelEmpty;

		public bool show
		{
			get
			{
				return m_Show;
			}
			set
			{
				m_Show = value;
			}
		}

		public Layer layer
		{
			get
			{
				return m_Layer;
			}
			set
			{
				m_Layer = value;
			}
		}

		public Sprite sprite
		{
			get
			{
				return m_Sprite;
			}
			set
			{
				m_Sprite = value;
			}
		}

		public Image.Type type
		{
			get
			{
				return m_Type;
			}
			set
			{
				m_Type = value;
			}
		}

		public Color color
		{
			get
			{
				return m_Color;
			}
			set
			{
				m_Color = value;
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
				m_Width = value;
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
				m_Height = value;
			}
		}

		public Vector3 offset
		{
			get
			{
				return m_Offset;
			}
			set
			{
				m_Offset = value;
			}
		}

		public Align align
		{
			get
			{
				return m_Align;
			}
			set
			{
				m_Align = value;
			}
		}

		public bool autoHideWhenLabelEmpty
		{
			get
			{
				return m_AutoHideWhenLabelEmpty;
			}
			set
			{
				m_AutoHideWhenLabelEmpty = value;
			}
		}

		public void Reset()
		{
			m_Show = false;
			m_Layer = Layer.UnderText;
			m_Sprite = null;
			m_Color = Color.white;
			m_Width = 20f;
			m_Height = 20f;
			m_Offset = Vector3.zero;
			m_AutoHideWhenLabelEmpty = false;
		}

		public IconStyle Clone()
		{
			return new IconStyle
			{
				show = show,
				layer = layer,
				sprite = sprite,
				type = type,
				color = color,
				width = width,
				height = height,
				offset = offset,
				align = align,
				autoHideWhenLabelEmpty = autoHideWhenLabelEmpty
			};
		}

		public void Copy(IconStyle iconStyle)
		{
			show = iconStyle.show;
			layer = iconStyle.layer;
			sprite = iconStyle.sprite;
			type = iconStyle.type;
			color = iconStyle.color;
			width = iconStyle.width;
			height = iconStyle.height;
			offset = iconStyle.offset;
			align = iconStyle.align;
			autoHideWhenLabelEmpty = iconStyle.autoHideWhenLabelEmpty;
		}
	}
}
