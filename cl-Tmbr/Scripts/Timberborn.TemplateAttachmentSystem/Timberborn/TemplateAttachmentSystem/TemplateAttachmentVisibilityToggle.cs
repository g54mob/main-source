using System;

namespace Timberborn.TemplateAttachmentSystem
{
	public class TemplateAttachmentVisibilityToggle
	{
		public bool IsVisible { get; private set; }

		public event EventHandler VisibilityChanged;

		public void Show()
		{
			IsVisible = true;
			this.VisibilityChanged?.Invoke(this, EventArgs.Empty);
		}

		public void Hide()
		{
			IsVisible = false;
			this.VisibilityChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
