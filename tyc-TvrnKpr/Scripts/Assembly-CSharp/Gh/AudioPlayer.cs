using Gh.Tk;
using UnityEngine;

namespace Gh
{
	[PersistenceIgnoreParent]
	[AllowDynamicRestore]
	public class AudioPlayer : AttachedBehaviour
	{
		[PersistenceOptIn]
		private int _currentTimeSamples;

		private AudioClip _audioClip;

		private AudioSource _audioSource;

		[PersistenceOptIn]
		public string AudioClipName { get; set; }

		[PersistenceOptIn]
		public AudioPlayerMode Mode { get; set; }

		[PersistenceOptIn]
		public bool UseUnscaledTime { get; set; }

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public override void UpdateObject()
		{
		}

		public void Destroy()
		{
		}
	}
}
