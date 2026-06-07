using UnityEngine;

namespace Simulator.GameWorld
{
	public class ShopSignAudio : MonoBehaviour
	{
		[SerializeField]
		private ShopSign m_shopSign;

		private Vector3 AudioPosition => m_shopSign.transform.position;

		private void OnEnable()
		{
			m_shopSign.OnOpened += OnOpened_PlaySound;
			m_shopSign.OnClosed += OnClosed_PlaySound;
		}

		private void OnDisable()
		{
			m_shopSign.OnOpened -= OnOpened_PlaySound;
			m_shopSign.OnClosed -= OnClosed_PlaySound;
		}

		private void OnOpened_PlaySound()
		{
			AudioManager.PlaySingleEventAt(WorldAudioSettings.SignOpen, AudioPosition);
		}

		private void OnClosed_PlaySound()
		{
			AudioManager.PlaySingleEventAt(WorldAudioSettings.SignClose, AudioPosition);
		}
	}
}
