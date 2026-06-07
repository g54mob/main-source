namespace MoreMountains.Tools
{
	public struct MMSoundManagerSoundFadeEvent
	{
		public int SoundID;

		public float FadeDuration;

		public float FinalVolume;

		public MMTweenType FadeTween;

		private static MMSoundManagerSoundFadeEvent e;

		public MMSoundManagerSoundFadeEvent(int soundID, float fadeDuration, float finalVolume, MMTweenType fadeTween)
		{
			SoundID = soundID;
			FadeDuration = fadeDuration;
			FinalVolume = finalVolume;
			FadeTween = fadeTween;
		}

		public static void Trigger(int soundID, float fadeDuration, float finalVolume, MMTweenType fadeTween)
		{
			e.SoundID = soundID;
			e.FadeDuration = fadeDuration;
			e.FinalVolume = finalVolume;
			e.FadeTween = fadeTween;
			MMEventManager.TriggerEvent(e);
		}
	}
}
