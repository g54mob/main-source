namespace Kitchen
{
	public class ActivateCardSelectors : ItemInteractionSystem
	{
		private CCardPedestal Pedestal;

		protected override bool IsPossible(ref InteractionData data)
		{
			return Require<CCardPedestal>(data.Target, out Pedestal);
		}

		protected override void Perform(ref InteractionData data)
		{
			if (Pedestal.IsToggleable)
			{
				Pedestal.IsSelected = !Pedestal.IsSelected;
				SetComponent(data.Target, Pedestal);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
