namespace DV.UIFramework
{
	public class PopupResult
	{
		public Popup popup;

		public PopupClosedByAction closedBy;

		public string data;

		public PopupResult(Popup popup, PopupClosedByAction closedBy, string data = null)
		{
			this.popup = popup;
			this.closedBy = closedBy;
			this.data = data;
		}
	}
}
