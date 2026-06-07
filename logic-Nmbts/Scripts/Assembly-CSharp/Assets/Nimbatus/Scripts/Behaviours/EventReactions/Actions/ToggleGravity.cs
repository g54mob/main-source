namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ToggleGravity : NimbatusAction
	{
		public bool DeactivateGravity;

		public override void Execute()
		{
			OwnWorldObject.DeactivateGravity = DeactivateGravity;
		}
	}
}
