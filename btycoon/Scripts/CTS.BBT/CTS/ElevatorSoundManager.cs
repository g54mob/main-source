using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class ElevatorSoundManager : MonoBehaviour
	{
		[SerializeField]
		private SoundAsset _elevatorOpening;

		[SerializeField]
		private SoundAsset _elevatorClosing;

		private void PlaySoundOneShot(ElevatorPortal elevator, SoundAsset soundAsset)
		{
			elevator.AudioSource.PlaySoundAsset(soundAsset);
		}

		private void OnDisable()
		{
			ElevatorPortal.ElevatorDoorOpening -= OnElevatorDoorOpening;
			ElevatorPortal.ElevatorDoorClosing -= OnElevatorDoorClosing;
		}

		private void OnEnable()
		{
			ElevatorPortal.ElevatorDoorOpening += OnElevatorDoorOpening;
			ElevatorPortal.ElevatorDoorClosing += OnElevatorDoorClosing;
		}

		private void OnElevatorDoorOpening(ElevatorPortal elevator)
		{
			PlaySoundOneShot(elevator, _elevatorOpening);
		}

		private void OnElevatorDoorClosing(ElevatorPortal elevator)
		{
			PlaySoundOneShot(elevator, _elevatorClosing);
		}
	}
}
