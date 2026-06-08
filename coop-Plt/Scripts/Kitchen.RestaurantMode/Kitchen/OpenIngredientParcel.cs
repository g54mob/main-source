using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class OpenIngredientParcel : ApplianceInteractionSystem
	{
		private CLetterIngredient Letter;

		private CPosition Position;

		protected override bool AllowActOrGrab => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CLetterIngredient>(data.Target, out Letter))
			{
				return false;
			}
			if (!Require<CPosition>(data.Target, out Position))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			data.Context.Destroy(data.Target);
			int iD = base.Data.ReferableObjects.DefaultProvider.ID;
			if (base.Data.TryGet<Item>(Letter.IngredientID, out var output, warn_if_fail: true))
			{
				Appliance dedicatedProvider = output.DedicatedProvider;
				iD = ((dedicatedProvider == null) ? base.Data.ReferableObjects.DefaultProvider.ID : dedicatedProvider.ID);
			}
			Entity entity = data.Context.CreateEntity();
			data.Context.Set(entity, new CCreateAppliance
			{
				ID = iD
			});
			data.Context.Set(entity, CItemProvider.InfiniteItemProvider(Letter.IngredientID));
			data.Context.Set(entity, new CPosition(Position));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
