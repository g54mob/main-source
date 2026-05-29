using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	public class UIComponent : BaseGraph
	{
		[SerializeField]
		private bool m_DebugModel;

		[SerializeField]
		protected UIComponentTheme m_Theme = new UIComponentTheme();

		[SerializeField]
		private ImageStyle m_Background = new ImageStyle
		{
			show = false
		};

		protected bool m_DataDirty;

		public override HideFlags chartHideFlags
		{
			get
			{
				if (!m_DebugModel)
				{
					return HideFlags.HideInHierarchy;
				}
				return HideFlags.None;
			}
		}

		public UIComponentTheme theme
		{
			get
			{
				return m_Theme;
			}
			set
			{
				m_Theme = value;
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
				m_Background = value;
				color = Color.white;
			}
		}

		public bool UpdateTheme(ThemeType theme)
		{
			if (theme == ThemeType.Custom)
			{
				Debug.LogError("UpdateTheme: not support switch to Custom theme.");
				return false;
			}
			if (m_Theme.sharedTheme == null)
			{
				m_Theme.sharedTheme = XCThemeMgr.GetTheme(ThemeType.Default);
			}
			m_Theme.sharedTheme.CopyTheme(theme);
			m_Theme.SetAllDirty();
			return true;
		}

		protected override void InitComponent()
		{
			base.InitComponent();
			if (m_Theme.sharedTheme == null)
			{
				m_Theme.sharedTheme = XCThemeMgr.GetTheme(ThemeType.Default);
			}
			UIHelper.InitBackground(this);
		}

		protected override void CheckComponent()
		{
			base.CheckComponent();
			if (m_Theme.anyDirty)
			{
				if (m_Theme.componentDirty)
				{
					SetAllComponentDirty();
				}
				if (m_Theme.vertsDirty)
				{
					RefreshGraph();
				}
				m_Theme.ClearDirty();
			}
		}

		protected override void SetAllComponentDirty()
		{
			base.SetAllComponentDirty();
			InitComponent();
		}

		protected override void OnDrawPainterBase(VertexHelper vh, Painter painter)
		{
			vh.Clear();
			UIHelper.DrawBackground(vh, this);
		}

		protected override void Update()
		{
			base.Update();
			if (m_DataDirty)
			{
				m_DataDirty = false;
				DataDirty();
			}
		}

		protected virtual void DataDirty()
		{
		}
	}
}
