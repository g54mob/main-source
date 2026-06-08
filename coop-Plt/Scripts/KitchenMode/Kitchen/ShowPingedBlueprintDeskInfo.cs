using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(MakePing))]
	public class ShowPingedBlueprintDeskInfo : InteractionSystem
	{
		private CGrantsExtraBlueprint GrantsBlueprint;

		private Appliance CachedApplianceInfo;

		protected override InteractionType RequiredType => InteractionType.Notify;

		protected override bool AllowAnyMode => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CGrantsExtraBlueprint>(data.Target, out GrantsBlueprint))
			{
				return false;
			}
			if (!GameData.Main.TryGet<Appliance>(GrantsBlueprint.ID, out CachedApplianceInfo) || CachedApplianceInfo.Name == "")
			{
				return false;
			}
			if (Require<CShowApplianceInfo>(data.Target, out CShowApplianceInfo comp))
			{
				if (Has<CTemporaryApplianceInfo>(data.Target) && comp.Appliance != GrantsBlueprint.ID)
				{
					data.Context.Set(data.Target, new CShowApplianceInfo
					{
						Appliance = GrantsBlueprint.ID,
						ShowPrice = true,
						Price = CachedApplianceInfo.PurchaseCost
					});
				}
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
			data.Context.Set(data.Target, new CShowApplianceInfo
			{
				Appliance = GrantsBlueprint.ID,
				ShowPrice = true,
				Price = CachedApplianceInfo.PurchaseCost
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
