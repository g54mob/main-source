using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(AudioSource))]
	public class IgnoreAudioListenerPause : MonoBehaviour
	{
		private void Awake()
		{
			GetComponent<AudioSource>().ignoreListenerPause = true;
		}
	}
}
