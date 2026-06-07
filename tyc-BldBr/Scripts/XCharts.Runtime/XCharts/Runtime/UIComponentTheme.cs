using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class UIComponentTheme : ChildComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private Theme m_SharedTheme;

		[SerializeField]
		private bool m_TransparentBackground;

		public bool show => m_Show;

		public ThemeType themeType => sharedTheme.themeType;

		public string themeName => sharedTheme.themeName;

		public Theme sharedTheme
		{
			get
			{
				return m_SharedTheme;
			}
			set
			{
				m_SharedTheme = value;
				SetAllDirty();
			}
		}

		public Color32 backgroundColor
		{
			get
			{
				if (m_TransparentBackground)
				{
					return ColorUtil.clearColor32;
				}
				return sharedTheme.backgroundColor;
			}
		}
	}
}
