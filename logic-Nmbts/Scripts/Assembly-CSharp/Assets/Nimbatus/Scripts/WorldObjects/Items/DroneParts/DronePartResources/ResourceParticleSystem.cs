using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.DronePartResources
{
	public class ResourceParticleSystem : MonoBehaviour
	{
		public float Speed;

		public string SFXLoop;

		private ParticleSystem _particleSystem;

		private Transform _targetPart;

		private Color _color;

		private AudioObject _audioLoop;

		public void Awake()
		{
			_particleSystem = GetComponent<ParticleSystem>();
			_particleSystem.Stop();
		}

		public void Init(Transform targetPart, Color color, float lifetime, bool destroyAfterPlay, bool playSound)
		{
			if (_particleSystem == null)
			{
				_particleSystem = GetComponent<ParticleSystem>();
			}
			_targetPart = targetPart;
			_color = color;
			ParticleSystem.MainModule main = _particleSystem.main;
			main.startColor = _color;
			main.startLifetime = lifetime;
			if (!_particleSystem.isPlaying)
			{
				if (playSound)
				{
					_audioLoop = AudioController.Play(SFXLoop, base.gameObject.transform);
				}
				_particleSystem.Play();
			}
			if (destroyAfterPlay)
			{
				Invoke("Stop", main.duration);
				Object.Destroy(base.gameObject, main.duration + 0.05f);
			}
		}

		public void Stop()
		{
			if (_audioLoop != null)
			{
				_audioLoop.Stop();
				AudioObject audioLoop = _audioLoop;
				if ((object)audioLoop != null)
				{
					audioLoop.DestroyAudioObject();
				}
			}
			if (_particleSystem != null)
			{
				_particleSystem.Stop();
			}
			_audioLoop = null;
			_particleSystem = null;
		}

		public void Update()
		{
			if (_targetPart != null && _particleSystem != null && _particleSystem.isPlaying)
			{
				ParticleSystem.Particle[] array = new ParticleSystem.Particle[_particleSystem.particleCount];
				_particleSystem.GetParticles(array);
				Vector3 position = _targetPart.position;
				position.z = -10f;
				for (int i = 0; i < array.Length; i++)
				{
					Vector3 position2 = array[i].position;
					position2.z = -10f;
					array[i].velocity += Speed * Time.smoothDeltaTime * (position - position2).normalized;
				}
				_particleSystem.SetParticles(array, array.Length);
			}
		}
	}
}
