using KitchenData;

namespace Kitchen
{
	public class EnableStatusByMapType : RestaurantSystem
	{
		protected override void OnUpdate()
		{
			if (Has<SLayout>() && Require<CSetting>(GetEntity<SLayout>(), out CSetting comp) && comp.RestaurantSetting == AssetReference.JanuarySetting)
			{
				SetStatus(RestaurantStatus.JanuaryRedEnvelopes, active: true);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
