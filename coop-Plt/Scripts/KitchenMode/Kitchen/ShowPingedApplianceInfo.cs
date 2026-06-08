using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(MakePing))]
	public class ShowPingedApplianceInfo : InteractionSystem
	{
		private int ApplianceID;

		protected override InteractionType RequiredType => InteractionType.Notify;

		protected override InteractionMode RequiredMode => InteractionMode.Appliances;

		protected override bool IsPossible(ref InteractionData data)
		{
			ApplianceID = 0;
			if (Require<CApplianceBlueprint>(data.Target, out CApplianceBlueprint comp))
			{
				ApplianceID = comp.Appliance;
			}
			else
			{
				if (!Require<CAppliance>(data.Target, out CAppliance comp2))
				{
					return false;
				}
				ApplianceID = comp2.ID;
			}
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
