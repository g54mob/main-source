using UnityEngine;

namespace Ezereal
{
	public class EzerealSoundController : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private bool useSounds;

		[SerializeField]
		private EzerealCarController ezerealCarController;

		[SerializeField]
		private AudioSource tireAudio;

		[SerializeField]
		private AudioSource engineAudio;

		[Header("Settings")]
		public float maxVolume;

		[Header("Debug")]
		[SerializeField]
		private bool alreadyPlaying;

		private void Start()
		{
		}

		public void TurnOnEngineSound()
		{
		}

		public void TurnOffEngineSound()
		{
		}

		private void Update()
		{
		}
	}
}
