using UnityEngine;

namespace SkyBrave_Toolkit.Scripts.Scriptable_Game_Events
{
	public class AudioClipGameEventListener : MonoBehaviour
	{
		[Tooltip("Events to register with.")]
		public AudioClipGameEvent gameEvent;

		public AudioSource audioSource;

		private void OnEnable()
		{
			gameEvent.RegisterListener(this);
		}

		private void OnDisable()
		{
			gameEvent.UnregisterListener(this);
		}

		private void Awake()
		{
			if (!audioSource)
			{
				audioSource = GetComponent<AudioSource>();
			}
		}

		public void OnEventRaised(AudioClip clip)
		{
			if (audioSource != null)
			{
				audioSource.clip = clip;
				audioSource.Play();
			}
			else
			{
				Debug.LogWarning("No AudioSource attached to this GameObject!");
			}
		}
	}
}
