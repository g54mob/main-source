namespace Kitchen
{
	public abstract class ApplianceInteractionSystem : InteractionSystem
	{
		protected override InteractionMode RequiredMode => InteractionMode.Appliances;

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
