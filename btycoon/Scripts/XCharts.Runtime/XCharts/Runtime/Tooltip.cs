using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(TooltipHandler), true)]
	public class Tooltip : MainComponent
	{
		public enum Type
		{
			Line = 0,
			Shadow = 1,
			None = 2,
			Corss = 3,
			Auto = 4
		}

		public enum Trigger
		{
			Item = 0,
			Axis = 1,
			None = 2,
			Auto = 3
		}

		public enum Position
		{
			Auto = 0,
			Custom = 1,
			FixedX = 2,
			FixedY = 3
		}

		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private Type m_Type = Type.Auto;

		[SerializeField]
		private Trigger m_Trigger = Trigger.Auto;

		[SerializeField]
		[Since("v3.3.0")]
		private Position m_Position;

		[SerializeField]
		private string m_ItemFormatter;

		[SerializeField]
		private string m_TitleFormatter;

		[SerializeField]
		private string m_Marker = "●";

		[SerializeField]
		private float m_FixedWidth;

		[SerializeField]
		private float m_FixedHeight;

		[SerializeField]
		private float m_MinWidth;

		[SerializeField]
		private float m_MinHeight;

		[SerializeField]
		private string m_NumericFormatter = "";

		[SerializeField]
		private int m_PaddingLeftRight = 10;

		[SerializeField]
		private int m_PaddingTopBottom = 10;

		[SerializeField]
		private bool m_IgnoreDataShow;

		[SerializeField]
		private string m_IgnoreDataDefaultContent = "-";

		[SerializeField]
		private bool m_ShowContent = true;

		[SerializeField]
		private bool m_AlwayShowContent;

		[SerializeField]
		private Vector2 m_Offset = new Vector2(18f, -25f);

		[SerializeField]
		private Sprite m_BackgroundImage;

		[SerializeField]
		private Image.Type m_BackgroundType;

		[SerializeField]
		private Color m_BackgroundColor;

		[SerializeField]
		private float m_BorderWidth = 2f;

		[SerializeField]
		private float m_FixedX;

		[SerializeField]
		private float m_FixedY = 0.7f;

		[SerializeField]
		private float m_TitleHeight = 25f;

		[SerializeField]
		private float m_ItemHeight = 25f;

		[SerializeField]
		private Color32 m_BorderColor = new Color32(230, 230, 230, byte.MaxValue);

		[SerializeField]
		private LineStyle m_LineStyle = new LineStyle(LineStyle.Type.None);

		[SerializeField]
		private LabelStyle m_TitleLabelStyle = new LabelStyle
		{
			textStyle = new TextStyle
			{
				alignment = TextAnchor.MiddleLeft
			}
		};

		[SerializeField]
		private List<LabelStyle> m_ContentLabelStyles = new List<LabelStyle>
		{
			new LabelStyle
			{
				textPadding = new TextPadding(0f, 5f, 0f, 0f),
				textStyle = new TextStyle
				{
					alignment = TextAnchor.MiddleLeft
				}
			},
			new LabelStyle
			{
				textPadding = new TextPadding(0f, 20f, 0f, 0f),
				textStyle = new TextStyle
				{
					alignment = TextAnchor.MiddleLeft
				}
			},
			new LabelStyle
			{
				textPadding = new TextPadding(0f, 0f, 0f, 0f),
				textStyle = new TextStyle
				{
					alignment = TextAnchor.MiddleRight
				}
			}
		};

		public TooltipContext context = new TooltipContext();

		public TooltipView view;

		public Dictionary<int, List<int>> runtimeSerieIndex = new Dictionary<int, List<int>>();

		private List<int> m_RuntimeDateIndex = new List<int> { -1, -1 };

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
					SetActive(value);
				}
			}
		}

		public Type type
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

		public Trigger trigger
		{
			get
			{
				return m_Trigger;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Trigger, value))
				{
					SetAllDirty();
				}
			}
		}

		public Position position
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

		public string titleFormatter
		{
			get
			{
				return m_TitleFormatter;
			}
			set
			{
				m_TitleFormatter = value;
			}
		}

		public string itemFormatter
		{
			get
			{
				return m_ItemFormatter;
			}
			set
			{
				m_ItemFormatter = value;
			}
		}

		public string marker
		{
			get
			{
				return m_Marker;
			}
			set
			{
				m_Marker = value;
			}
		}

		public float fixedWidth
		{
			get
			{
				return m_FixedWidth;
			}
			set
			{
				m_FixedWidth = value;
			}
		}

		public float fixedHeight
		{
			get
			{
				return m_FixedHeight;
			}
			set
			{
				m_FixedHeight = value;
			}
		}

		public float minWidth
		{
			get
			{
				return m_MinWidth;
			}
			set
			{
				m_MinWidth = value;
			}
		}

		public float minHeight
		{
			get
			{
				return m_MinHeight;
			}
			set
			{
				m_MinHeight = value;
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

		public int paddingLeftRight
		{
			get
			{
				return m_PaddingLeftRight;
			}
			set
			{
				m_PaddingLeftRight = value;
			}
		}

		public int paddingTopBottom
		{
			get
			{
				return m_PaddingTopBottom;
			}
			set
			{
				m_PaddingTopBottom = value;
			}
		}

		public bool ignoreDataShow
		{
			get
			{
				return m_IgnoreDataShow;
			}
			set
			{
				m_IgnoreDataShow = value;
			}
		}

		public string ignoreDataDefaultContent
		{
			get
			{
				return m_IgnoreDataDefaultContent;
			}
			set
			{
				m_IgnoreDataDefaultContent = value;
			}
		}

		public Sprite backgroundImage
		{
			get
			{
				return m_BackgroundImage;
			}
			set
			{
				m_BackgroundImage = value;
				SetComponentDirty();
			}
		}

		public Image.Type backgroundType
		{
			get
			{
				return m_BackgroundType;
			}
			set
			{
				m_BackgroundType = value;
				SetComponentDirty();
			}
		}

		public Color backgroundColor
		{
			get
			{
				return m_BackgroundColor;
			}
			set
			{
				m_BackgroundColor = value;
				SetComponentDirty();
			}
		}

		public bool alwayShowContent
		{
			get
			{
				return m_AlwayShowContent;
			}
			set
			{
				m_AlwayShowContent = value;
			}
		}

		public bool showContent
		{
			get
			{
				return m_ShowContent;
			}
			set
			{
				m_ShowContent = value;
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
				m_Offset = value;
			}
		}

		public float borderWidth
		{
			get
			{
				return m_BorderWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BorderWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 borderColor
		{
			get
			{
				return m_BorderColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_BorderColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float fixedX
		{
			get
			{
				return m_FixedX;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_FixedX, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float fixedY
		{
			get
			{
				return m_FixedY;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_FixedY, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float titleHeight
		{
			get
			{
				return m_TitleHeight;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_TitleHeight, value))
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

		public LabelStyle titleLabelStyle
		{
			get
			{
				return m_TitleLabelStyle;
			}
			set
			{
				if (value != null)
				{
					m_TitleLabelStyle = value;
					SetComponentDirty();
				}
			}
		}

		public List<LabelStyle> contentLabelStyles
		{
			get
			{
				return m_ContentLabelStyles;
			}
			set
			{
				if (value != null)
				{
					m_ContentLabelStyles = value;
					SetComponentDirty();
				}
			}
		}

		public LineStyle lineStyle
		{
			get
			{
				return m_LineStyle;
			}
			set
			{
				if (value != null)
				{
					m_LineStyle = value;
				}
				SetComponentDirty();
			}
		}

		public override bool componentDirty
		{
			get
			{
				if (!m_ComponentDirty)
				{
					return lineStyle.componentDirty;
				}
				return true;
			}
		}

		public List<int> runtimeDataIndex
		{
			get
			{
				return m_RuntimeDateIndex;
			}
			internal set
			{
				m_RuntimeDateIndex = value;
			}
		}

		public override void ClearComponentDirty()
		{
			base.ClearComponentDirty();
			lineStyle.ClearComponentDirty();
		}

		public void KeepTop()
		{
			base.gameObject.transform.SetAsLastSibling();
		}

		public override void ClearData()
		{
			ClearValue();
		}

		internal void ClearValue()
		{
			for (int i = 0; i < runtimeDataIndex.Count; i++)
			{
				runtimeDataIndex[i] = -1;
			}
		}

		public bool IsActive()
		{
			if (base.gameObject != null)
			{
				return base.gameObject.activeInHierarchy;
			}
			return false;
		}

		public void SetActive(bool flag)
		{
			if ((bool)base.gameObject && base.gameObject.activeInHierarchy != flag)
			{
				base.gameObject.SetActive(alwayShowContent || flag);
			}
			SetContentActive(flag);
		}

		public void UpdateContentPos(Vector2 pos, float width, float height)
		{
			if (view != null)
			{
				switch (m_Position)
				{
				case Position.Custom:
					pos.x = ChartHelper.GetActualValue(m_FixedX, width);
					pos.y = ChartHelper.GetActualValue(m_FixedY, height);
					break;
				case Position.FixedX:
					pos.x = ChartHelper.GetActualValue(m_FixedX, width);
					break;
				case Position.FixedY:
					pos.y = ChartHelper.GetActualValue(m_FixedY, height);
					break;
				}
				view.UpdatePosition(pos);
			}
		}

		public void SetContentActive(bool flag)
		{
			if (view != null)
			{
				view.SetActive(alwayShowContent || flag);
			}
		}

		public bool IsSelected()
		{
			foreach (int item in runtimeDataIndex)
			{
				if (item >= 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsSelected(int index)
		{
			foreach (int item in runtimeDataIndex)
			{
				if (item == index)
				{
					return true;
				}
			}
			return false;
		}

		public void ClearSerieDataIndex()
		{
			foreach (KeyValuePair<int, List<int>> item in runtimeSerieIndex)
			{
				item.Value.Clear();
			}
		}

		public void AddSerieDataIndex(int serieIndex, int dataIndex)
		{
			if (!runtimeSerieIndex.ContainsKey(serieIndex))
			{
				runtimeSerieIndex[serieIndex] = new List<int>();
			}
			runtimeSerieIndex[serieIndex].Add(dataIndex);
		}

		public bool isAnySerieDataIndex()
		{
			foreach (KeyValuePair<int, List<int>> item in runtimeSerieIndex)
			{
				if (item.Value.Count > 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsTriggerItem()
		{
			if (trigger != Trigger.Auto)
			{
				return trigger == Trigger.Item;
			}
			return context.trigger == Trigger.Item;
		}

		public bool IsTriggerAxis()
		{
			if (trigger != Trigger.Auto)
			{
				return trigger == Trigger.Axis;
			}
			return context.trigger == Trigger.Axis;
		}

		public LabelStyle GetContentLabelStyle(int index)
		{
			if (m_ContentLabelStyles.Count == 0)
			{
				return null;
			}
			if (index < 0)
			{
				index = 0;
			}
			else if (index > m_ContentLabelStyles.Count - 1)
			{
				index = m_ContentLabelStyles.Count - 1;
			}
			return m_ContentLabelStyles[index];
		}
	}
}
