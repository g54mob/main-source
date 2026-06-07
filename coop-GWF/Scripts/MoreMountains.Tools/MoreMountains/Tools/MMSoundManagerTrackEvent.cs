namespace MoreMountains.Tools
{
	public struct MMSoundManagerTrackEvent
	{
		public MMSoundManagerTrackEventTypes TrackEventType;

		public MMSoundManager.MMSoundManagerTracks Track;

		public float Volume;

		private static MMSoundManagerTrackEvent e;

		public MMSoundManagerTrackEvent(MMSoundManagerTrackEventTypes trackEventType, MMSoundManager.MMSoundManagerTracks track = MMSoundManager.MMSoundManagerTracks.Master, float volume = 1f)
		{
			TrackEventType = trackEventType;
			Track = track;
			Volume = volume;
		}

		public static void Trigger(MMSoundManagerTrackEventTypes trackEventType, MMSoundManager.MMSoundManagerTracks track = MMSoundManager.MMSoundManagerTracks.Master, float volume = 1f)
		{
			e.TrackEventType = trackEventType;
			e.Track = track;
			e.Volume = volume;
			MMEventManager.TriggerEvent(e);
		}
	}
}
