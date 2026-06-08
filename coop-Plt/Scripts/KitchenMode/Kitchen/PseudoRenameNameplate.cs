namespace Kitchen
{
	public class PseudoRenameNameplate : ApplianceInteractionSystem
	{
		private CRenameRestaurant Nameplate;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CRenameRestaurant>(data.Target, out Nameplate))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
