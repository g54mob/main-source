using UnityEngine;

public class SoundEffectUtils : MonoBehaviour
{
	private static readonly string SOUND_EFFECT_HIERARCHY = "/Canvas/Audio Controllers";

	public static ClosePanelAudio GetOpenClosePanelPlayer()
	{
		return GameObject.Find(SOUND_EFFECT_HIERARCHY + "/Close Panel").GetComponent<ClosePanelAudio>();
	}

	public static Notification GetNotificationPlayer()
	{
		return GameObject.Find(SOUND_EFFECT_HIERARCHY + "/Notifications").GetComponent<Notification>();
	}

	public static IconClick GetIconClickPlayer()
	{
		return GameObject.Find(SOUND_EFFECT_HIERARCHY + "/Icon Click").GetComponent<IconClick>();
	}
}
