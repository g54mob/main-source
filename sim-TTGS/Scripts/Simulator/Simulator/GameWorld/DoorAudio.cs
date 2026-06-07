using FMOD.Studio;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class DoorAudio : MonoBehaviour
	{
		[SerializeField]
		private Door m_door;

		private EventInstance m_eventInstance;

		private Vector3 AudioPosition => m_door.transform.position;

		private void OnEnable()
		{
			m_door.OnOpen += OnDoorOpen_PlaySound;
			m_door.OnClose += OnDoorClose_PlaySound;
		}

		private void OnDisable()
		{
			m_door.OnOpen -= OnDoorOpen_PlaySound;
			m_door.OnClose -= OnDoorClose_PlaySound;
		}

		private void OnDoorOpen_PlaySound()
		{
			StopAudio();
			m_eventInstance = AudioManager.PlayPersistentEventAt(WorldAudioSettings.DoorOpen, AudioPosition);
		}

		private void OnDoorClose_PlaySound()
		{
			StopAudio();
			m_eventInstance = AudioManager.PlayPersistentEventAt(WorldAudioSettings.DoorClose, AudioPosition);
		}

		private void StopAudio()
		{
			AudioManager.StopEvent(m_eventInstance);
		}
	}
}
