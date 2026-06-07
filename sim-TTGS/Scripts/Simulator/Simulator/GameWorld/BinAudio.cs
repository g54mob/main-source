using UnityEngine;

namespace Simulator.GameWorld
{
	public class BinAudio : MonoBehaviour
	{
		[SerializeField]
		private Bin m_bin;

		private void OnEnable()
		{
			m_bin.OnInteracted += OnBinInteracted_PlaySound;
		}

		private void OnDisable()
		{
			m_bin.OnInteracted += OnBinInteracted_PlaySound;
		}

		private void OnBinInteracted_PlaySound()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.Bin);
		}
	}
}
