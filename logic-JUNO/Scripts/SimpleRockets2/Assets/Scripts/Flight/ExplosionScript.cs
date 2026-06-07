using ModApi.Flight.GameView;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class ExplosionScript : MonoBehaviour
	{
		private AudioSource _audioSource;

		private ICameraShake _cameraShake;

		private float _duration;

		[SerializeField]
		private float _intensity;

		[SerializeField]
		private float _frequency = 3f;

		[SerializeField]
		private float _frequencyDecay = 1f;

		private ParticleSystem[] _particleSystems;

		private float _timer;

		public bool Alive { get; private set; }

		public Vector3 Velocity { get; private set; }

		public void Initialize(AudioClip audioClip)
		{
			_audioSource = base.gameObject.GetComponent<AudioSource>();
			_audioSource.dopplerLevel = 0f;
			_audioSource.spatialBlend = 1f;
			_audioSource.minDistance = 50f;
			_audioSource.maxDistance = 2500f;
			_audioSource.outputAudioMixerGroup = Game.Instance.AudioPlayer.GetGameMixerGroup();
			_audioSource.clip = audioClip;
			_audioSource.loop = false;
			_audioSource.volume = 1f;
			_particleSystems = GetComponentsInChildren<ParticleSystem>();
			ParticleSystem[] particleSystems = _particleSystems;
			foreach (ParticleSystem particleSystem in particleSystems)
			{
				_duration = Mathf.Max(_duration, particleSystem.main.duration);
			}
			_duration = Mathf.Max(_duration, audioClip.length);
			_cameraShake = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.CameraShake;
		}

		public void Play(Vector3 position, Vector3 velocity, float scale, float volume)
		{
			base.transform.position = position;
			Velocity = velocity;
			base.transform.localScale = new Vector3(scale, scale, scale);
			Alive = true;
			_timer = _duration;
			base.gameObject.SetActive(value: true);
			ParticleSystem[] particleSystems = _particleSystems;
			foreach (ParticleSystem obj in particleSystems)
			{
				obj.time = 0f;
				obj.Play();
			}
			_audioSource.minDistance = 50f * volume;
			_audioSource.maxDistance = 2500f * volume;
			_audioSource.volume = volume;
			_audioSource.time = 0f;
			_audioSource.Play();
			_cameraShake.AddShake(GetShakeIntensity, GetShakeFrequency);
			_intensity = Mathf.Min(5f, scale / 10f);
			_frequency = Mathf.Lerp(10f, 3f, Mathf.Clamp01(0.025f * scale));
			_frequencyDecay = 1f / Mathf.Sqrt(_frequency);
		}

		private void Update()
		{
			if (Alive)
			{
				_timer -= Time.deltaTime;
				if (_timer <= 0f)
				{
					_intensity = 0f;
					base.gameObject.SetActive(value: false);
					_cameraShake.RemoveShake(GetShakeIntensity, GetShakeFrequency);
					Alive = false;
				}
				else
				{
					base.transform.position += Velocity * Time.deltaTime;
					float num = Mathf.Pow(0.75f * _frequencyDecay, Time.deltaTime);
					Velocity *= num;
					_intensity *= num;
				}
			}
		}

		private float GetShakeFrequency()
		{
			return _frequency;
		}

		private float GetShakeIntensity()
		{
			return _intensity;
		}
	}
}
