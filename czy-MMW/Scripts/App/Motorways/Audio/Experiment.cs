namespace Motorways.Audio
{
	public class Experiment : Playback
	{
		public Experiment(AudioEventFilter filter)
			: base(filter, new string[1])
		{
		}

		protected override void OnPulse()
		{
		}

		public override void Update()
		{
		}
	}
}
