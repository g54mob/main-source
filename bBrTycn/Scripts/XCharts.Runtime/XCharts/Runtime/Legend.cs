using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(LegendHandler), true)]
	public class Legend : MainComponent, IPropertyChanged
	{
		public enum Type
		{
			Auto = 0,
			Custom = 1,
			EmptyCircle = 2,
			Circle = 3,
			Rect = 4,
			Triangle = 5,
			Diamond = 6,
			Candlestick = 7
		}

		public enum SelectedMode
		{
			Multiple = 0,
			Single = 1,
			None = 2
		}

		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private Type m_IconType;

		[SerializeField]
		private SelectedMode m_SelectedMode;

		[SerializeField]
		private Orient m_Orient;

		[SerializeField]
		private Location m_Location = new Location
		{
			align = Location.Align.TopCenter,
			top = 0.125f
		};

		[SerializeField]
		private float m_ItemWidth = 25f;

		[SerializeField]
		private float m_ItemHeight = 12f;

		[SerializeField]
		private float m_ItemGap = 10f;

		[SerializeField]
		private bool m_ItemAutoColor = true;

		[SerializeField]
		private float m_ItemOpacity = 1f;

		[SerializeField]
		private string m_Formatter;

		[SerializeField]
		protected string m_NumericFormatter = "";

		[SerializeField]
		private LabelStyle m_LabelStyle = new LabelStyle();

		[SerializeField]
		private List<string> m_Data = new List<string>();

		[SerializeField]
		private List<Sprite> m_Icons = new List<Sprite>();

		[SerializeField]
		private List<Color> m_Colors = new List<Color>();

		[SerializeField]
		[Since("v3.1.0")]
		protected ImageStyle m_Background = new ImageStyle
		{
			show = false
		};

		[SerializeField]
		[Since("v3.1.0")]
		protected Padding m_Padding = new Padding();

		[SerializeField]
		[Since("v3.6.0")]
		private List<Vector3> m_Positions = new List<Vector3>();

		public LegendContext context = new LegendContext();

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

		public Type iconType
		{
			get
			{
				return m_IconType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_IconType, value))
				{
					SetAllDirty();
				}
			}
		}

		public SelectedMode selectedMode
		{
			get
			{
				return m_SelectedMode;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SelectedMode, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Orient orient
		{
			get
			{
				return m_Orient;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Orient, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Location location
		{
			get
			{
				return m_Location;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Location, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float itemWidth
		{
			get
			{
				return m_ItemWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ItemWidth, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float itemHeight
		{
			get
			{
				return m_ItemHeight;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ItemHeight, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float itemGap
		{
			get
			{
				return m_ItemGap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ItemGap, value))
				{
					SetComponentDirty();
				}
			}
		}

		public bool itemAutoColor
		{
			get
			{
				return m_ItemAutoColor;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ItemAutoColor, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float itemOpacity
		{
			get
			{
				return m_ItemOpacity;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ItemOpacity, value))
				{
					SetComponentDirty();
				}
			}
		}

		public string numericFormatter
		{
			get
			{
				return m_NumericFormatter;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_NumericFormatter, value))
				{
					SetComponentDirty();
				}
			}
		}

		public string formatter
		{
			get
			{
				return m_Formatter;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Formatter, value))
				{
					SetComponentDirty();
				}
			}
		}

		public LabelStyle labelStyle
		{
			get
			{
				return m_LabelStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_LabelStyle, value))
				{
					SetComponentDirty();
				}
			}
		}

		public ImageStyle background
		{
			get
			{
				return m_Background;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Background, value))
				{
					SetAllDirty();
				}
			}
		}

		public Padding padding
		{
			get
			{
				return m_Padding;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Padding, value))
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
					SetComponentDirty();
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
					SetComponentDirty();
				}
			}
		}

		public List<Color> colors
		{
			get
			{
				return m_Colors;
			}
			set
			{
				if (value != null)
				{
					m_Colors = value;
					SetAllDirty();
				}
			}
		}

		public List<Vector3> positions
		{
			get
			{
				return m_Positions;
			}
			set
			{
				if (value != null)
				{
					m_Positions = value;
					SetAllDirty();
				}
			}
		}

		public override bool vertsDirty => false;

		public override bool componentDirty
		{
			get
			{
				if (!m_ComponentDirty && !location.componentDirty)
				{
					return labelStyle.componentDirty;
				}
				return true;
			}
		}

		public override void ClearComponentDirty()
		{
			base.ClearComponentDirty();
			location.ClearComponentDirty();
			labelStyle.ClearComponentDirty();
		}

		public override void ClearData()
		{
			m_Data.Clear();
			SetComponentDirty();
		}

		public bool ContainsData(string name)
		{
			return m_Data.Contains(name);
		}

		public void RemoveData(string name)
		{
			if (m_Data.Contains(name))
			{
				m_Data.Remove(name);
				SetComponentDirty();
			}
		}

		public void AddData(string name)
		{
			if (!m_Data.Contains(name) && !string.IsNullOrEmpty(name))
			{
				m_Data.Add(name);
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

		public int GetIndex(string legendName)
		{
			return m_Data.IndexOf(legendName);
		}

		public void RemoveButton()
		{
			context.buttonList.Clear();
		}

		public void SetButton(string name, LegendItem item, int total)
		{
			context.buttonList[name] = item;
			_ = context.buttonList.Values.Count;
			item.SetIconActive(iconType == Type.Custom);
			item.SetActive(show);
		}

		public void UpdateButtonColor(string name, Color color)
		{
			if (context.buttonList.ContainsKey(name))
			{
				context.buttonList[name].SetIconColor(color);
			}
		}

		public void UpdateContentColor(string name, Color color)
		{
			if (context.buttonList.ContainsKey(name))
			{
				context.buttonList[name].SetContentColor(color);
			}
		}

		public Sprite GetIcon(int index)
		{
			if (index >= 0 && index < m_Icons.Count)
			{
				return m_Icons[index];
			}
			return null;
		}

		public Color GetColor(int index)
		{
			if (index >= 0 && index < m_Colors.Count)
			{
				return m_Colors[index];
			}
			return Color.white;
		}

		public Vector3 GetPosition(int index, Vector3 defaultPos)
		{
			if (index >= 0 && index < m_Positions.Count)
			{
				return m_Positions[index];
			}
			return defaultPos;
		}

		public void OnChanged()
		{
			m_Location.OnChanged();
		}
	}
}
