using FMODUnity;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class ObjectEnableDisableSFX : MonoBehaviour
	{
		[SerializeField]
		private EventReference onEnableSound;

		[SerializeField]
		private EventReference onDisableSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
			if (base.isActiveAndEnabled)
			{
				audioPlayer.PlaySoundEventOneShot(onEnableSound, base.gameObject);
			}
		}

		private void OnEnable()
		{
			if ((audioPlayer is MonoBehaviour monoBehaviour && (bool)monoBehaviour) || audioPlayer != null)
			{
				audioPlayer.PlaySoundEventOneShot(onEnableSound, base.gameObject);
			}
		}

		private void OnDisable()
		{
			if ((audioPlayer is MonoBehaviour monoBehaviour && (bool)monoBehaviour) || audioPlayer != null)
			{
				audioPlayer.PlaySoundEventOneShot(onDisableSound, base.gameObject);
			}
		}
	}
}
