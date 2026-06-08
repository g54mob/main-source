using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(MakePing))]
	public class ShowPingedCrateInfo : InteractionSystem
	{
		private int ApplianceID;

		protected override InteractionType RequiredType => InteractionType.Notify;

		protected override InteractionMode RequiredMode => InteractionMode.Items;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Has<SFranchiseMarker>())
			{
				return false;
			}
			if (!Preferences.Get<bool>(Pref.RequirePingForBlueprintInfo))
			{
				return false;
			}
			ApplianceID = 0;
			if (!Require<CItemHolder>(data.Target, out CItemHolder comp))
			{
				return false;
			}
			if (!Require<CCrateAppliance>((Entity)comp, out CCrateAppliance comp2))
			{
				return false;
			}
			ApplianceID = comp2.Appliance;
			if (Has<CShowApplianceInfo>(data.Target))
			{
				return false;
			}
			if (!GameData.Main.TryGet<Appliance>(ApplianceID, out var output) || output.Name == "")
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			data.Context.Set(data.Target, new CTemporaryApplianceInfo
			{
				RemainingLifetime = 0.2f,
				Interactor = data.Interactor
			});
			CForSale comp;
			bool showPrice = Require<CForSale>(data.Target, out comp);
			data.Context.Set(data.Target, new CShowApplianceInfo
			{
				Appliance = ApplianceID,
				ShowPrice = showPrice,
				Price = comp.Price
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
