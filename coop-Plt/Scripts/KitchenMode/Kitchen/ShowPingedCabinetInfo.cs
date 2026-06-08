using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(MakePing))]
	public class ShowPingedCabinetInfo : InteractionSystem
	{
		private CBlueprintStore BlueprintStore;

		protected override InteractionType RequiredType => InteractionType.Notify;

		protected override bool AllowAnyMode => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CBlueprintStore>(data.Target, out BlueprintStore))
			{
				return false;
			}
			if (Has<CShowApplianceInfo>(data.Target))
			{
				return false;
			}
			if (!GameData.Main.TryGet<Appliance>(BlueprintStore.ApplianceID, out var output) || output.Name == "")
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
			data.Context.Set(data.Target, new CShowApplianceInfo
			{
				Appliance = BlueprintStore.ApplianceID,
				ShowPrice = true,
				Price = BlueprintStore.Price
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
