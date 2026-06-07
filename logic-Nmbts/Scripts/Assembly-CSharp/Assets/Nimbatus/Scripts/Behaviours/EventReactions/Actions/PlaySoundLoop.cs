namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class PlaySoundLoop : NimbatusAction
	{
		public string Sound;

		public override void Execute()
		{
			OwnWorldObject.StartSoundLoop(Sound);
		}
	}
}
