using UnityEngine;

namespace Simulator.GameWorld
{
	public class BoxAudio : MonoBehaviour
	{
		[SerializeField]
		private BaseBox m_baseBox;

		private void OnEnable()
		{
			m_baseBox.OnGrabbed += OnGrabbedPlaySound;
			m_baseBox.OnDropped += OnDroppedPlaySound;
			m_baseBox.OnOpened += OnOpenedPlaysSound;
		}

		private void OnDisable()
		{
			m_baseBox.OnGrabbed -= OnGrabbedPlaySound;
			m_baseBox.OnDropped -= OnDroppedPlaySound;
			m_baseBox.OnOpened -= OnOpenedPlaysSound;
		}

		private void OnGrabbedPlaySound()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.BoxGrab);
		}

		private void OnDroppedPlaySound()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.BoxDrop);
		}

		private void OnOpenedPlaysSound()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.BoxOpen);
		}
	}
}
