using System;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Serializable]
	[DisallowMultipleComponent]
	[ComponentHandler(typeof(BackgroundHandler), false)]
	public class Background : MainComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private Sprite m_Image;

		[SerializeField]
		private Image.Type m_ImageType;

		[SerializeField]
		private Color m_ImageColor = Color.white;

		[SerializeField]
		private bool m_AutoColor = true;

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
					SetComponentDirty();
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
					SetComponentDirty();
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
					SetComponentDirty();
				}
			}
		}

		public Color imageColor
		{
			get
			{
				return m_ImageColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_ImageColor, value))
				{
					SetComponentDirty();
				}
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
				if (PropertyUtil.SetStruct(ref m_AutoColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public override void SetDefaultValue()
		{
			m_Show = true;
			m_Image = null;
			m_ImageType = Image.Type.Sliced;
			m_ImageColor = Color.white;
			m_AutoColor = true;
		}
	}
}
