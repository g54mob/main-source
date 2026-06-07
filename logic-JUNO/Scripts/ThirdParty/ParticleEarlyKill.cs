using UnityEngine;

public class ParticleEarlyKill : MonoBehaviour
{
	private ParticleSystem.Particle[] _parParticleList;

	public AnimationCurve _amcParticleLifeTime;

	[CleanInspectorName]
	public bool _bUseVariableFadeOut;

	[CleanInspectorName("", "_bUseVariableFadeOut")]
	public AnimationCurve _amcParticleFadeOutTime;

	public float _fParticleFadeOutRate;

	protected ParticleSystem _parTargetParticleSystem;

	protected ParticleSystem TargetParticleSystem
	{
		get
		{
			if (_parTargetParticleSystem == null)
			{
				_parTargetParticleSystem = GetComponent<ParticleSystem>();
			}
			return _parTargetParticleSystem;
		}
	}

	private void Update()
	{
		if (_parParticleList == null || _parParticleList.Length != TargetParticleSystem.main.maxParticles)
		{
			_parParticleList = new ParticleSystem.Particle[TargetParticleSystem.main.maxParticles];
		}
		int particles = TargetParticleSystem.GetParticles(_parParticleList);
		for (int i = 0; i < particles; i++)
		{
			float time = (float)_parParticleList[i].randomSeed / 4.2949673E+09f;
			float num = (1f - _amcParticleLifeTime.Evaluate(time)) * _parParticleList[i].startLifetime;
			if (num > _parParticleList[i].remainingLifetime)
			{
				float num2 = 1f;
				num2 = ((!_bUseVariableFadeOut) ? (num2 - 1f / _fParticleFadeOutRate * (num - _parParticleList[i].remainingLifetime)) : (num2 - 1f / (_fParticleFadeOutRate * _amcParticleFadeOutTime.Evaluate(time)) * (num - _parParticleList[i].remainingLifetime)));
				if (num2 < 0f)
				{
					_parParticleList[i].remainingLifetime = -1f;
				}
				Color color = _parParticleList[i].startColor;
				Color color2 = new Color(color.r, color.g, color.b, Mathf.Clamp(color.a, -1f, num2));
				_parParticleList[i].startColor = color2;
			}
		}
		TargetParticleSystem.SetParticles(_parParticleList, particles);
	}
}
