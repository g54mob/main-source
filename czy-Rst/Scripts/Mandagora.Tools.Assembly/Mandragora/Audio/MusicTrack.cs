using Helpers.Singletons;
using UnityEngine;

namespace Mandragora.Audio
{
	public class MusicTrack : AudioTrack
	{
		private void Awake()
		{
			Object.DontDestroyOnLoad(base.gameObject);
		}

		protected override void Remove()
		{
			SingletonBehaviour<AudioManager>.Instance.RemoveMusic(this);
		}
	}
}
