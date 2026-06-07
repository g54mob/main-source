using UnityEngine;

namespace MoreMountains.Tools
{
	public struct MMSoundManagerSoundControlEvent
	{
		public int SoundID;

		public MMSoundManagerSoundControlEventTypes MMSoundManagerSoundControlEventType;

		public AudioSource TargetSource;

		private static MMSoundManagerSoundControlEvent e;

		public MMSoundManagerSoundControlEvent(MMSoundManagerSoundControlEventTypes eventType, int soundID, AudioSource source = null)
		{
			SoundID = soundID;
			TargetSource = source;
			MMSoundManagerSoundControlEventType = eventType;
		}

		public static void Trigger(MMSoundManagerSoundControlEventTypes eventType, int soundID, AudioSource source = null)
		{
			e.SoundID = soundID;
			e.TargetSource = source;
			e.MMSoundManagerSoundControlEventType = eventType;
			MMEventManager.TriggerEvent(e);
		}
	}
}
