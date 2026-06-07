using UnityEngine;

namespace Simulator.GameWorld
{
	public class ReserveDeskAudio : MonoBehaviour
	{
		[SerializeField]
		private ReserveDeskWorkshop m_workshop;

		private void OnEnable()
		{
			m_workshop.OnInteracted += OnReserveDeskControlled_PlaySound;
		}

		private void OnDisable()
		{
			m_workshop.OnInteracted -= OnReserveDeskControlled_PlaySound;
		}

		private void OnReserveDeskControlled_PlaySound()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.ReserveDeskOpen);
		}
	}
}
