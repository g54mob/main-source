using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Infrastructure.Scenes.Audio
{
	public class AudioTimeScaleService : MonoBehaviour, bfd, bfb
	{
		[SerializeField]
		private AudioMixer m_audioMixer;

		[SerializeField]
		private AudioMixerGroup m_targetMixerGroup;

		private string suz;

		private readonly HashSet<AudioSource> sva;

		public void ipb(AudioSource a)
		{
		}

		public void ipc(AudioSource a)
		{
		}

		public void ipd(float a)
		{
		}

		public IEnumerable<AudioSource> ipe()
		{
			return null;
		}
	}
}
