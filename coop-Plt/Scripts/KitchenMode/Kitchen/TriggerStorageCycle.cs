namespace Kitchen
{
	public class TriggerStorageCycle : ItemInteractionSystem
	{
		protected override bool IsPossible(ref InteractionData data)
		{
			if (Has<CPreventUse>(data.Target))
			{
				return false;
			}
			if (!Require<CItemStorage>(data.Target, out CItemStorage comp))
			{
				return false;
			}
			if (comp.PreventManualCycling)
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			data.Context.Add<CCycleItemStorage>(data.Target);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
