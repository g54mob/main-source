using UnityEngine;

namespace Simulator.GameWorld
{
	public class FurnitureMoverAudio : MonoBehaviour
	{
		[SerializeField]
		private FurnitureMover m_furnitureMover;

		private void OnEnable()
		{
			m_furnitureMover.OnMoved += OnMoved_PlaySound;
		}

		private void OnDisable()
		{
			m_furnitureMover.OnMoved += OnMoved_PlaySound;
		}

		private void OnMoved_PlaySound()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.FurniturePlace);
		}
	}
}
