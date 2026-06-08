using UnityEngine;

namespace Kitchen.Components
{
	[RequireComponent(typeof(AudioSource))]
	public abstract class BaseSoundSource : MonoBehaviour
	{
		public SoundCategory Category;

		protected AudioSource Audio;

		protected float Volume;

		private void Start()
		{
			if (!base.gameObject.TryGetComponent<AudioSource>(out Audio))
			{
				Audio = base.gameObject.AddComponent<AudioSource>();
			}
			Initialise();
			Audio.ignoreListenerPause = true;
			Audio.ignoreListenerVolume = true;
		}

		private void Update()
		{
			SetVolume();
		}

		protected virtual void SetVolume()
		{
			Audio.mute = VolumeManagement.SoundIsPaused;
			Audio.volume = Volume * VolumeManagement.GetVolume(Category);
		}

		protected virtual void Initialise()
		{
		}
	}
}
