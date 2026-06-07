namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class PlaySoundEffect : NimbatusAction
	{
		public string Sound;

		public bool IndependentOfGameobject;

		public override void Execute()
		{
			OwnWorldObject.PlaySound(Sound, !IndependentOfGameobject);
		}
	}
}
