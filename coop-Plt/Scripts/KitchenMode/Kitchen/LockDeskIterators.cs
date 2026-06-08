namespace Kitchen
{
	public class LockDeskIterators : ItemInteractionSystem
	{
		private CApplianceDeskIterate Desk;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CApplianceDeskIterate>(data.Target, out Desk))
			{
				return false;
			}
			if (Desk.IsLocked)
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			Desk.IsLocked = true;
			data.Context.Set(data.Target, Desk);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
