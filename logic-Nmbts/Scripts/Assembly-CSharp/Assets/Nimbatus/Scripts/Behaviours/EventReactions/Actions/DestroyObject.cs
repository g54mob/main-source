namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class DestroyObject : NimbatusAction
	{
		public override void Execute()
		{
			Behaviour.Release();
			OwnWorldObject.Destroy();
		}
	}
}
