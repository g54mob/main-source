using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Inventory
{
	public class InventoryPanelSFX : MonoBehaviour
	{
		[SerializeField]
		private InventoryPanel inventoryPanel;

		[SerializeField]
		private EventReference openInventorySound;

		[SerializeField]
		private EventReference closeInventorySound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			inventoryPanel.OnIsVisibleChanged += ResolveInventoryVisibilityChanged;
		}

		private void OnDisable()
		{
			if (inventoryPanel.MonoShellExists())
			{
				inventoryPanel.OnIsVisibleChanged -= ResolveInventoryVisibilityChanged;
			}
		}

		private void ResolveInventoryVisibilityChanged()
		{
			audioPlayer?.PlaySoundEventOneShot(inventoryPanel.IsVisible ? openInventorySound : closeInventorySound);
		}
	}
}
