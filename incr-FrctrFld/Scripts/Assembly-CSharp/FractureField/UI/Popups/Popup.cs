namespace FractureField.UI.Popups
{
	public class Popup : InitableRComponent
	{
		public PopupType PopupType;

		public bool ShowOverlay;

		public bool CloseOnOverlayClick;

		public override bool InitInStart => false;

		protected override void InitHandler()
		{
		}

		private void OnActivePopupsChanged()
		{
		}

		public virtual void Open()
		{
		}

		public virtual void Close()
		{
		}

		public void Toggle()
		{
		}
	}
}
