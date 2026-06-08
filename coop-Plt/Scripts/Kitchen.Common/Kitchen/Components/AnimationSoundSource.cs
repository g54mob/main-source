using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Components
{
	public class AnimationSoundSource : SoundSource
	{
		public List<AudioClip> SoundList = new List<AudioClip>();

		public void Play(int id)
		{
			if (id >= 0 && id < SoundList.Count)
			{
				AudioClip clip = SoundList[id];
				Configure(SoundCategory.Effects, clip);
				ShouldLoop = false;
				Play();
			}
		}
	}
}
