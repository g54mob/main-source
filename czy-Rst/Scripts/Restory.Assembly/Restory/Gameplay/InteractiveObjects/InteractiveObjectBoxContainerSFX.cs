using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class InteractiveObjectBoxContainerSFX : MonoBehaviour
	{
		[SerializeField]
		private InteractiveObjectBoxContainer interactiveObjectBoxContainer;

		[SerializeField]
		private EventReference objectsAddedSound;

		[SerializeField]
		private EventReference objectTakenOutSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			interactiveObjectBoxContainer.OnObjectsAdded += ResolveObjectsAddedToBox;
			interactiveObjectBoxContainer.OnInteractiveObjectTakenOut += ResolveObjectTakenOut;
		}

		private void OnDisable()
		{
			if (interactiveObjectBoxContainer.MonoShellExists())
			{
				interactiveObjectBoxContainer.OnObjectsAdded -= ResolveObjectsAddedToBox;
				interactiveObjectBoxContainer.OnInteractiveObjectTakenOut -= ResolveObjectTakenOut;
			}
		}

		private void ResolveObjectsAddedToBox()
		{
			audioPlayer.PlaySoundEventOneShot(objectsAddedSound, base.gameObject);
		}

		private void ResolveObjectTakenOut(InteractiveObject obj)
		{
			audioPlayer.PlaySoundEventOneShot(objectTakenOutSound, base.gameObject);
		}
	}
}
