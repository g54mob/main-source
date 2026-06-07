using System;

namespace Gh.Tk.UI
{
	public class OpenShopMapMarkerButton : Button3DUIView
	{
		private ShopMapMarker _shopMapMarker;

		public virtual ShopMapMarker ShopMapMarker
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnTradeRouteEstablishedChanged(object sender, EventArgs e)
		{
		}

		public override void CheckState()
		{
		}

		protected override void Start()
		{
		}
	}
}
