using System;

namespace Gh.Tk.UI
{
	public class PriceButtonInfoPanel3DUIView : Button3DUIView
	{
		public GameItemPriceSlider3DUIView priceSlider;

		public PatronTierRatings3DUIView tierRatings;

		private IPriceConfigurable TargetItem => null;

		protected override void Awake()
		{
		}

		public void SetData(IPriceConfigurable target)
		{
		}

		private void PriceChanged(object sender, EventArgs e)
		{
		}

		private void RefreshPriceText()
		{
		}
	}
}
