namespace Kitchen
{
	public abstract class ItemInteractionSystem : InteractionSystem
	{
		protected override InteractionMode RequiredMode => InteractionMode.Items;

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
