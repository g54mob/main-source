using Unity.Entities;

namespace Kitchen
{
	public class EmptyBin : InteractionSystem
	{
		private CApplianceBin Bin;

		protected override bool IsPossible(ref InteractionData interaction_data)
		{
			if (!Require<CApplianceBin>(interaction_data.Target, out Bin) || Bin.CurrentAmount == 0 || Bin.EmptyBinItem == 0)
			{
				return false;
			}
			if (!Require<CItemHolder>(interaction_data.Interactor, out CItemHolder comp) || comp.HeldItem != default(Entity))
			{
				return false;
			}
			if (Require<CToolUser>(interaction_data.Interactor, out CToolUser comp2) && comp2.CurrentTool != default(Entity))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			data.Context.Set(data.Context.CreateEntity(), new CCreateItem
			{
				ID = Bin.EmptyBinItem,
				Holder = data.Interactor
			});
			Bin.CurrentAmount = 0;
			data.Context.Set(data.Target, Bin);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
