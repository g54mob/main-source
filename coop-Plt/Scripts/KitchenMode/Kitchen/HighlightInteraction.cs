namespace Kitchen
{
	public class HighlightInteraction : ItemInteractionSystem
	{
		protected override bool IsPossible(ref InteractionData data)
		{
			return Has<CEffectWhileBeingUsed>(data.Target);
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
