using System;

namespace UI.SpriteEditor
{
	public struct FontPanelParameters
	{
		public UIFont uiFont;

		public Action<string> OnValueChange;

		public FontPanelParameters(UIFont uiFont, Action<string> OnValueChange = null)
		{
			this.uiFont = null;
			this.OnValueChange = null;
		}
	}
}
