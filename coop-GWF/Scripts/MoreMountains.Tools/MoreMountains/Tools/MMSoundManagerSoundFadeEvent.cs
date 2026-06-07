namespace MoreMountains.Tools
{
	public struct MMSoundManagerSoundFadeEvent
	{
		public enum Modes
		{
			PlayFade = 0,
			StopFade = 1
		}

		public Modes Mode;

		public int SoundID;

		public float FadeDuration;

		public float FinalVolume;

		public MMTweenType FadeTween;

		private static MMSoundManagerSoundFadeEvent e;

		public MMSoundManagerSoundFadeEvent(Modes mode, int soundID, float fadeDuration, float finalVolume, MMTweenType fadeTween)
		{
			Mode = mode;
			SoundID = soundID;
			FadeDuration = fadeDuration;
			FinalVolume = finalVolume;
			FadeTween = fadeTween;
		}

		public static void Trigger(Modes mode, int soundID, float fadeDuration, float finalVolume, MMTweenType fadeTween)
		{
			e.Mode = mode;
			e.SoundID = soundID;
			e.FadeDuration = fadeDuration;
			e.FinalVolume = finalVolume;
			e.FadeTween = fadeTween;
			MMEventManager.TriggerEvent(e);
		}
	}
}
