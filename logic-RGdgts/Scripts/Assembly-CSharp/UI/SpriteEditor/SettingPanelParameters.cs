using System;

namespace UI.SpriteEditor
{
	public struct SettingPanelParameters
	{
		public Action OnChangeFilterColor;

		public Action OnChangeBKG1Color;

		public Action OnChangeBKG2Color;

		public Action OnChangeGridColor;

		public Action OnChangeZoomColor;

		public Action<float> OnFilterAlphaChange;

		public Action<float> OnGridAlphaChange;

		public Action<float> OnZoomAlphaChange;

		public Action<bool> OnZoomToggleChange;

		public Action ResetColorFilter;

		public Action ResetColorGrid;

		public Action ResetColorZoomGrid;

		public Action ResetColorBkg;

		public float filter;

		public float grid;

		public float zoom;

		public SettingPanelParameters(Action OnChangeFilterColor, Action OnChangeBKG1Color, Action OnChangeBKG2Color, Action OnChangeGridColor, Action OnChangeZoomColor, Action<float> OnFilterAlphaChange, Action<float> OnGridAlphaChange, Action<float> OnZoomAlphaChange, Action<bool> OnZoomToggleChange, Action ResetColorFilter, Action ResetColorGrid, Action ResetColorZoomGrid, Action ResetColorBkg, float filter, float grid, float zoom)
		{
			this.OnChangeFilterColor = null;
			this.OnChangeBKG1Color = null;
			this.OnChangeBKG2Color = null;
			this.OnChangeGridColor = null;
			this.OnChangeZoomColor = null;
			this.OnFilterAlphaChange = null;
			this.OnGridAlphaChange = null;
			this.OnZoomAlphaChange = null;
			this.OnZoomToggleChange = null;
			this.ResetColorFilter = null;
			this.ResetColorGrid = null;
			this.ResetColorZoomGrid = null;
			this.ResetColorBkg = null;
			this.filter = 0f;
			this.grid = 0f;
			this.zoom = 0f;
		}
	}
}
