using AudioSystem;
using UnityEngine;

public class FireworksParticleController : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem _particle;

	private int _currentNumberOfParticles;

	[SerializeField]
	private SoundData _spawnSound;

	[SerializeField]
	private SoundData _deathSound;

	private SoundBuilder _soundBuilder;

	private void Start()
	{
		_soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
	}

	private void Update()
	{
		if (_particle.particleCount < _currentNumberOfParticles)
		{
			_soundBuilder.Play(_deathSound);
		}
		if (_particle.particleCount > _currentNumberOfParticles)
		{
			_soundBuilder.Play(_spawnSound);
		}
		_currentNumberOfParticles = _particle.particleCount;
	}
}
