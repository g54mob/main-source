using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Unique.Cthulhu
{
	public class CthulhuSoundEvents : MonoBehaviour
	{
		private AudioSource _audioSource;

		[SerializeField]
		private AudioClip[] _clipsArray;

		private int _randomSeed;

		private CthulhuWaves _waves;

		public void FadeOutWaveLoop()
		{
			_waves.FadeOutWaveLoop();
		}

		public void MonsterRoarNow()
		{
			PlayClip(0);
		}

		public void PlayRandomAmbience()
		{
			int num;
			for (num = _randomSeed; num == _randomSeed; num = Random.Range(0, _clipsArray.Length))
			{
			}
			if (Random.Range(0, 2) == 1)
			{
				PlayClip(num);
			}
		}

		public void PlayWaveLoop()
		{
			_waves.PlayWaveLoop();
		}

		protected virtual void Start()
		{
			_audioSource = GetComponent<AudioSource>();
			_waves = GetComponentInParent<CthulhuWaves>();
		}

		private void PlayClip(int clipID)
		{
			if (!_audioSource.isPlaying)
			{
				_audioSource.clip = _clipsArray[clipID];
				_randomSeed = clipID;
				_audioSource.volume = 0.5f;
				_audioSource.Play();
			}
		}
	}
}
