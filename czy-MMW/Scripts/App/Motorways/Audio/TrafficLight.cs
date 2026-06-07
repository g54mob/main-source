namespace Motorways.Audio
{
	public class TrafficLight : Playback
	{
		public TrafficLight(AudioEventFilter filter)
			: base(filter)
		{
		}

		protected override void OnPulse()
		{
			if (GetEvents())
			{
				audioEvents.ForEach(HandleEvent);
				audioEvents.Clear();
			}
		}

		private void HandleEvent(AudioEvent e)
		{
			double dspTime = AudioSystem.Instance.DspTime;
			switch (e.Type)
			{
			case AudioEventType.TrafficLightAmber:
				AudioPlayer.UI.PlaySample("PeepAppears_EGG", 0.5f, 0.5f, 1f, 0.0, dspTime + 0.4);
				break;
			case AudioEventType.TrafficLightGreen:
				AudioPlayer.UI.PlaySample("PeepAppears_SQUARE", 0.5f, 0.5f, 1f, 0.0, dspTime + 0.6);
				break;
			}
		}
	}
}
