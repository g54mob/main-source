using System.Collections;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class RandomSoundPlayer : MonoBehaviour
	{
		[SerializeField]
		private AudioSource _audioSource;

		[SerializeField]
		private SoundAsset[] _soundAssets;

		[SerializeField]
		[MinMaxSlider(0f, 180f)]
		private Vector2 _startDelayRange = new Vector2(60f, 60f);

		[SerializeField]
		[MinMaxSlider(0f, 180f)]
		private Vector2 _timeBetweenSoundsRange = new Vector2(60f, 60f);

		private void OnEnable()
		{
			StartCoroutine(UpdateLogic());
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		private IEnumerator UpdateLogic()
		{
			yield return Coroutines.WaitForSeconds(_startDelayRange.RandomInRange());
			while (true)
			{
				_audioSource.PlaySoundAsset(_soundAssets.GetRandom());
				yield return Coroutines.WaitForSeconds(_timeBetweenSoundsRange.RandomInRange());
			}
		}
	}
}
