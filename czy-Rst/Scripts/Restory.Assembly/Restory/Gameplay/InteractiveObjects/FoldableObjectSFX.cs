using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class FoldableObjectSFX : MonoBehaviour
	{
		[SerializeField]
		private FoldableObject foldableObject;

		[SerializeField]
		private EventReference objectFoldedSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			foldableObject.OnObjectFolded += ResolveObjectFolded;
		}

		private void OnDisable()
		{
			if (foldableObject.MonoShellExists())
			{
				foldableObject.OnObjectFolded -= ResolveObjectFolded;
			}
		}

		private void ResolveObjectFolded()
		{
			audioPlayer.PlaySoundEventOneShot(objectFoldedSound, base.gameObject);
		}
	}
}
