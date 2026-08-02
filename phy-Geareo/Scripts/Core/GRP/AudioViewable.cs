using System;
using System.Runtime.CompilerServices;
using Rhizomatic.Reactive;
using UnityEngine;
using UnityEngine.Audio;

namespace GRP
{
	public class AudioViewable : Viewable
	{
		public State<AudioClip> clip;

		public State<AudioMixerGroup> output;

		public State<bool> loop;

		public State<float> volume;

		public State<float> pitch;

		public event Action onPlay
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<AudioClip, float> onPlayOneShot
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Play()
		{
		}

		public void PlayOneShot(AudioClip clip, float volumeScale)
		{
		}
	}
}
