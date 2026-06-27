using FMODUnity;
using Restory.Gameplay.Equipment;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class InventoryBoxSFX : MonoBehaviour
	{
		[SerializeField]
		private InventoryBox inventoryBox;

		[SerializeField]
		private EventReference itemAddedSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			inventoryBox.OnItemAdded += ResolveItemAdded;
		}

		private void OnDisable()
		{
			if (inventoryBox.MonoShellExists())
			{
				inventoryBox.OnItemAdded -= ResolveItemAdded;
			}
		}

		private void ResolveItemAdded()
		{
			audioPlayer?.PlaySoundEventOneShot(itemAddedSound, base.gameObject);
		}
	}
}
