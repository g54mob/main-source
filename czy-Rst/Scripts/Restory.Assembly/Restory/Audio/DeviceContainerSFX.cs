using FMODUnity;
using Restory.Gameplay.Devices;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class DeviceContainerSFX : MonoBehaviour
	{
		[SerializeField]
		private DeviceContainer deviceContainer;

		[SerializeField]
		private EventReference transferSound;

		[SerializeField]
		private EventReference selectSound;

		[SerializeField]
		private EventReference deselectSound;

		[SerializeField]
		private EventReference clickSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			deviceContainer.OnTransferToOrFromDisassemblyPointStarted += ResolveTransferToOrFromDisassemblyPointStarted;
			deviceContainer.OnDeviceSelected += ResolveSelected;
			deviceContainer.OnDeviceDeselected += ResolveDeselected;
			deviceContainer.OnDeviceActivated += ResolveActivated;
		}

		private void OnDisable()
		{
			if ((bool)deviceContainer)
			{
				deviceContainer.OnTransferToOrFromDisassemblyPointStarted -= ResolveTransferToOrFromDisassemblyPointStarted;
				deviceContainer.OnDeviceSelected -= ResolveSelected;
				deviceContainer.OnDeviceDeselected -= ResolveDeselected;
				deviceContainer.OnDeviceActivated -= ResolveActivated;
			}
		}

		private void ResolveActivated()
		{
			audioPlayer.PlaySoundEventOneShot(clickSound, deviceContainer.Device ? deviceContainer.Device.gameObject : null);
		}

		private void ResolveSelected()
		{
			audioPlayer.PlaySoundEventOneShot(selectSound, deviceContainer.Device ? deviceContainer.Device.gameObject : null);
		}

		private void ResolveDeselected()
		{
			audioPlayer.PlaySoundEventOneShot(deselectSound, deviceContainer.Device ? deviceContainer.Device.gameObject : null);
		}

		private void ResolveTransferToOrFromDisassemblyPointStarted()
		{
			audioPlayer.PlaySoundEventOneShot(transferSound);
		}
	}
}
