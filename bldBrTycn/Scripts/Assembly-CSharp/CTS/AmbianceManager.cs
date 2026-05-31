using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class AmbianceManager : MonoBehaviour
	{
		[SerializeField]
		private AudioSource _audioSource;

		[field: SerializeField]
		public AudioAsset Ambiance { get; private set; }

		private void Start()
		{
			if (_audioSource != null)
			{
				float volume = Ambiance.VolumeRange.RandomInRange();
				_audioSource.PlaySoundAsset(Ambiance, volume);
			}
		}
	}
}
