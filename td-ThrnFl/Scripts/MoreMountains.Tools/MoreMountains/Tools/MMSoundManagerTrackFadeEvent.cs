namespace MoreMountains.Tools
{
	public struct MMSoundManagerTrackFadeEvent
	{
		public MMSoundManager.MMSoundManagerTracks Track;

		public float FadeDuration;

		public float FinalVolume;

		public MMTweenType FadeTween;

		private static MMSoundManagerTrackFadeEvent e;

		public MMSoundManagerTrackFadeEvent(MMSoundManager.MMSoundManagerTracks track, float fadeDuration, float finalVolume, MMTweenType fadeTween)
		{
			Track = track;
			FadeDuration = fadeDuration;
			FinalVolume = finalVolume;
			FadeTween = fadeTween;
		}

		public static void Trigger(MMSoundManager.MMSoundManagerTracks track, float fadeDuration, float finalVolume, MMTweenType fadeTween)
		{
			e.Track = track;
			e.FadeDuration = fadeDuration;
			e.FinalVolume = finalVolume;
			e.FadeTween = fadeTween;
			MMEventManager.TriggerEvent(e);
		}
	}
}
