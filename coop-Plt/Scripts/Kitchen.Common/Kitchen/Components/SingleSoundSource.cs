namespace Kitchen.Components
{
	public class SingleSoundSource : SoundSource
	{
		private bool HasPlayed;

		public bool IsComplete;

		protected override void Update()
		{
			base.Update();
			if (Audio.isPlaying)
			{
				HasPlayed = true;
			}
			else if (HasPlayed)
			{
				IsComplete = true;
			}
		}
	}
}
