using UnityEngine;

public class PooledParticleSystem : PoolableSimple
{
	private ParticleSystem[] _particleSystemComponents;

	public void Awake()
	{
		_particleSystemComponents = GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] particleSystemComponents = _particleSystemComponents;
		for (int i = 0; i < particleSystemComponents.Length; i++)
		{
			particleSystemComponents[i].Stop(withChildren: false, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
	}

	public override void OnFree()
	{
		Stop(ParticleSystemStopBehavior.StopEmittingAndClear);
		base.OnFree();
	}

	public void Play()
	{
		ParticleSystem[] particleSystemComponents = _particleSystemComponents;
		for (int i = 0; i < particleSystemComponents.Length; i++)
		{
			particleSystemComponents[i].Play(withChildren: false);
		}
	}

	public void Stop(ParticleSystemStopBehavior stopBehavior = ParticleSystemStopBehavior.StopEmitting)
	{
		ParticleSystem[] particleSystemComponents = _particleSystemComponents;
		for (int i = 0; i < particleSystemComponents.Length; i++)
		{
			particleSystemComponents[i].Stop(withChildren: false, stopBehavior);
		}
	}

	public bool IsAlive()
	{
		ParticleSystem[] particleSystemComponents = _particleSystemComponents;
		for (int i = 0; i < particleSystemComponents.Length; i++)
		{
			if (particleSystemComponents[i].IsAlive(withChildren: false))
			{
				return true;
			}
		}
		return false;
	}

	public void UpdateSimulationSpace(Transform simulationSpace)
	{
		ParticleSystem[] particleSystemComponents = _particleSystemComponents;
		for (int i = 0; i < particleSystemComponents.Length; i++)
		{
			ParticleSystem.MainModule main = particleSystemComponents[i].main;
			if (main.simulationSpace != ParticleSystemSimulationSpace.Local)
			{
				main.simulationSpace = ParticleSystemSimulationSpace.Custom;
				main.customSimulationSpace = simulationSpace;
			}
		}
	}
}
