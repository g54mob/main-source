using UnityEngine;

namespace Assets.Scripts.Environment.Water
{
	public class WaterSplashManager : MonoBehaviour
	{
		private class SplashParticle
		{
			public GameObject gameObject;

			public ParticleSystem particleSystem;

			public ParticleSystem.MainModule particleSystemMain;

			public Transform transform;
		}

		public GameObject SplashSound;

		private AudioSource _audioSource;

		private int _maxSplashes;

		private int _nextSplash;

		private SplashParticle[] _splashes;

		public void CreateSplash(Vector3 position, Vector3 velocity)
		{
			float magnitude = velocity.magnitude;
			if (!(magnitude > 3f) || !(velocity.y < -0.5f))
			{
				return;
			}
			float value = magnitude / 40f;
			value = Mathf.Clamp(value, 0f, 1f);
			PlaySplash(value, position);
			SplashParticle splashParticle = null;
			for (int i = 0; i < _maxSplashes; i++)
			{
				splashParticle = _splashes[_nextSplash];
				if (!splashParticle.gameObject.activeInHierarchy || splashParticle.particleSystem.time >= 0.2f)
				{
					break;
				}
				if (_nextSplash < _maxSplashes - 1)
				{
					_nextSplash++;
				}
				else
				{
					_nextSplash = 0;
				}
			}
			splashParticle.gameObject.SetActive(value: true);
			splashParticle.particleSystem.Clear();
			splashParticle.particleSystemMain.startSpeed = Mathf.Clamp(magnitude / 4f, 0.5f, 10f);
			position.y = GameWorld.Instance.SeaLevel.GetValueOrDefault() - GameWorld.Instance.FloatingOriginOffset.y;
			splashParticle.transform.position = position;
			splashParticle.particleSystem.Play();
		}

		protected virtual void Start()
		{
			_audioSource = SplashSound.GetComponent<AudioSource>();
			_maxSplashes = (Game.Instance.Device.IsDesktopBuild ? 50 : 25);
			_splashes = new SplashParticle[_maxSplashes];
			Object original = Resources.Load("ParticleEffects/WaterSplashParticles");
			for (int i = 0; i < _splashes.Length; i++)
			{
				_splashes[i] = new SplashParticle();
				GameObject gameObject = Object.Instantiate(original) as GameObject;
				gameObject.transform.parent = base.transform;
				gameObject.SetActive(value: false);
				ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
				_splashes[i].particleSystem = component;
				_splashes[i].particleSystemMain = component.main;
				_splashes[i].gameObject = gameObject;
				_splashes[i].transform = component.transform;
			}
		}

		protected virtual void Update()
		{
			SplashParticle[] splashes = _splashes;
			foreach (SplashParticle splashParticle in splashes)
			{
				if (splashParticle.gameObject.activeInHierarchy && splashParticle.particleSystem.time >= splashParticle.particleSystemMain.duration)
				{
					splashParticle.gameObject.SetActive(value: false);
				}
			}
		}

		private void PlaySplash(float volume, Vector3 position)
		{
			if (!_audioSource.isPlaying || volume > _audioSource.volume * 1.5f)
			{
				_audioSource.volume = volume;
				_audioSource.transform.position = position;
				_audioSource.Play();
			}
		}
	}
}
