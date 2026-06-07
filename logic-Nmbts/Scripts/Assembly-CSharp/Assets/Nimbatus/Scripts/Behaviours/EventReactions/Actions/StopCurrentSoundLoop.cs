namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class StopCurrentSoundLoop : NimbatusAction
	{
		public override void Execute()
		{
			OwnWorldObject.StopActiveSoundLoop();
		}
	}
}
