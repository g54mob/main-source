using UnityEngine;

namespace UI.Xml
{
	[RequireComponent(typeof(AudioSource))]
	internal class XmlLayoutOneShotAudio : MonoBehaviour
	{
		private AudioSource _audioSource;

		public void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
			Object.DontDestroyOnLoad(base.gameObject);
		}

		public void Update()
		{
			if (!_audioSource.isPlaying)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
