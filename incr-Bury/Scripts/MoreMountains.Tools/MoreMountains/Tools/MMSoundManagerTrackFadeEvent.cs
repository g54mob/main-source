namespace MoreMountains.Tools
{
	public struct MMSoundManagerTrackFadeEvent
	{
		public enum Modes
		{
			PlayFade = 0,
			StopFade = 1
		}

		public Modes Mode;

		public MMSoundManager.MMSoundManagerTracks Track;

		public float FadeDuration;

		public float FinalVolume;

		public MMTweenType FadeTween;

		private static MMSoundManagerTrackFadeEvent e;

		public MMSoundManagerTrackFadeEvent(Modes mode, MMSoundManager.MMSoundManagerTracks track, float fadeDuration, float finalVolume, MMTweenType fadeTween)
		{
			Mode = mode;
			Track = track;
			FadeDuration = fadeDuration;
			FinalVolume = finalVolume;
			FadeTween = fadeTween;
		}

		public static void Trigger(Modes mode, MMSoundManager.MMSoundManagerTracks track, float fadeDuration, float finalVolume, MMTweenType fadeTween)
		{
			e.Mode = mode;
			e.Track = track;
			e.FadeDuration = fadeDuration;
			e.FinalVolume = finalVolume;
			e.FadeTween = fadeTween;
			MMEventManager.TriggerEvent(e);
		}
	}
}
