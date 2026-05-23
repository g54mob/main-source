using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public class BE2_AudioManager : MonoBehaviour
	{
		public AudioClip[] audiosArray;

		public static BE2_AudioManager instance;

		public AudioSource source;

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
		}

		public void PlaySound(int audioIndex)
		{
			source.clip = audiosArray[audioIndex];
			source.Play();
		}
	}
}
