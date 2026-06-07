using System.Collections.Generic;
using UnityEngine;

namespace Placemaker.Ui
{
	public class MenuMusic : MonoBehaviour, UiMaster.IUiSetup
	{
		private AudioSource audioSource;

		private float targetVolume;

		private float speed;

		[SerializeField]
		private List<AudioClip> audioClips;

		private void Update()
		{
		}

		public void StopPlaying(float timer = 1f)
		{
		}

		public void StartPlaying()
		{
		}

		public void StartPlaying(AudioClip clip)
		{
		}

		public void OnStart(UiMaster master)
		{
		}

		public void OnSetup(UiMaster master)
		{
		}
	}
}
