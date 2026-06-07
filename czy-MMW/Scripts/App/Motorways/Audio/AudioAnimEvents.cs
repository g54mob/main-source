using UnityEngine;

namespace Motorways.Audio
{
	public class AudioAnimEvents : MonoBehaviour
	{
		public void FireAudioEvent(int type)
		{
			AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateEvent(AudioSystem.Instance.DspTime, (AudioEventType)(1L << type)));
		}
	}
}
