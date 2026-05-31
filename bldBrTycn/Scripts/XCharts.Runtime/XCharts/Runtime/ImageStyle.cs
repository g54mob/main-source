using System;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Serializable]
	public class ImageStyle : ChildComponent, ISerieComponent, ISerieDataComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private Sprite m_Sprite;

		[SerializeField]
		private Image.Type m_Type;

		[SerializeField]
		private bool m_AutoColor;

		[SerializeField]
		private Color m_Color = Color.clear;

		[SerializeField]
		private float m_Width;

		[SerializeField]
		private float m_Height;

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

		public bool autoColor
		{
			get
			{
				return m_AutoColor;
			}
			set
			{
				m_AutoColor = value;
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

		public void Reset()
		{
			m_Show = false;
			m_Type = Image.Type.Simple;
			m_Sprite = null;
			m_AutoColor = false;
			m_Color = Color.white;
			m_Width = 0f;
			m_Height = 0f;
		}

		public ImageStyle Clone()
		{
			return new ImageStyle
			{
				type = type,
				sprite = sprite,
				autoColor = autoColor,
				color = color,
				width = width,
				height = height
			};
		}

		public void Copy(ImageStyle imageStyle)
		{
			type = imageStyle.type;
			sprite = imageStyle.sprite;
			autoColor = imageStyle.autoColor;
			color = imageStyle.color;
			width = imageStyle.width;
			height = imageStyle.height;
		}
	}
}
