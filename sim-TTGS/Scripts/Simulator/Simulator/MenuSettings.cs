using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	[Settings("UI/Menus", Scope.Project)]
	public class MenuSettings : CustomSettings<MenuSettings>
	{
		[Header("Cursor")]
		[SerializeField]
		private CursorState m_defaultCursor;

		[SerializeField]
		private CursorState m_hoverCursor;

		[Header("Save And Load button sprites")]
		[Header("Variation 1")]
		[SerializeField]
		private Sprite m_uiMenuSaveFileFullRoundedVariation1;

		[SerializeField]
		private Sprite m_uiMenuSaveFileNotRoundedVariation1;

		[SerializeField]
		private Sprite m_uiMenuSaveFileTopRoundedVariation1;

		[SerializeField]
		private Sprite m_uiMenuSaveFileBotRoundedVariation1;

		[Header("Variation 2")]
		[SerializeField]
		private Sprite m_uiMenuSaveFileNotRoundedVariation2;

		[SerializeField]
		private Sprite m_uiMenuSaveFileTopRoundedVariation2;

		[SerializeField]
		private Sprite m_uiMenuSaveFileBotRoundedVariation2;

		[Header("Save File")]
		[SerializeField]
		private float m_saveFileUnHoverHeight = 70f;

		[SerializeField]
		private float m_saveFileHoverHeight = 140f;

		[SerializeField]
		private float m_saveFileHoverTweenDuration;

		public static CursorState DefaultCursor => CustomSettings<MenuSettings>.I.m_defaultCursor;

		public static CursorState HoverCursor => CustomSettings<MenuSettings>.I.m_hoverCursor;

		public static Sprite SaveFileFullRoundedVariation1 => CustomSettings<MenuSettings>.I.m_uiMenuSaveFileFullRoundedVariation1;

		public static Sprite SaveFileNotRoundedVariation1 => CustomSettings<MenuSettings>.I.m_uiMenuSaveFileNotRoundedVariation1;

		public static Sprite SaveFileTopRoundedVariation1 => CustomSettings<MenuSettings>.I.m_uiMenuSaveFileTopRoundedVariation1;

		public static Sprite SaveFileBotRoundedVariation1 => CustomSettings<MenuSettings>.I.m_uiMenuSaveFileBotRoundedVariation1;

		public static Sprite SaveFileNotRoundedVariation2 => CustomSettings<MenuSettings>.I.m_uiMenuSaveFileNotRoundedVariation2;

		public static Sprite SaveFileTopRoundedVariation2 => CustomSettings<MenuSettings>.I.m_uiMenuSaveFileTopRoundedVariation2;

		public static Sprite SaveFileBotRoundedVariation2 => CustomSettings<MenuSettings>.I.m_uiMenuSaveFileBotRoundedVariation2;

		public static float SaveFileUnHoverHeight => CustomSettings<MenuSettings>.I.m_saveFileUnHoverHeight;

		public static float SaveFileHoverHeight => CustomSettings<MenuSettings>.I.m_saveFileHoverHeight;

		public static float SaveFileHoverTweenDuration => CustomSettings<MenuSettings>.I.m_saveFileHoverTweenDuration;
	}
}
