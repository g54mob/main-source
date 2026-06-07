using UltimateReplay;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(MultiThruster))]
[RequireComponent(typeof(MultiThrusterVisualEffect))]
public class MultiThrusterVEReplay : ReplayBehaviour
{
	private MultiThruster multiThruster;

	private MultiThrusterVisualEffect multiThrusterVisualEffect;

	private Vector3 initialThrustVector;

	public override void Awake()
	{
		base.Awake();
		multiThruster = GetComponent<MultiThruster>();
		multiThrusterVisualEffect = GetComponent<MultiThrusterVisualEffect>();
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		initialThrustVector = multiThruster.CurrentThrustVector;
		multiThrusterVisualEffect.ParticleControlPX.MainParticleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		multiThrusterVisualEffect.ParticleControlNX.MainParticleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		multiThrusterVisualEffect.ParticleControlPY.MainParticleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		multiThrusterVisualEffect.ParticleControlNY.MainParticleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
	}

	public override void OnReplayEnd()
	{
		base.OnReplayEnd();
		if (initialThrustVector.x > multiThrusterVisualEffect.MinValueToStart)
		{
			multiThrusterVisualEffect.ParticleControlPX.MainParticleSystem.Play(withChildren: true);
		}
		if (initialThrustVector.x < 0f - multiThrusterVisualEffect.MinValueToStart)
		{
			multiThrusterVisualEffect.ParticleControlNX.MainParticleSystem.Play(withChildren: true);
		}
		if (initialThrustVector.y > multiThrusterVisualEffect.MinValueToStart)
		{
			multiThrusterVisualEffect.ParticleControlPY.MainParticleSystem.Play(withChildren: true);
		}
		if (initialThrustVector.y < 0f - multiThrusterVisualEffect.MinValueToStart)
		{
			multiThrusterVisualEffect.ParticleControlNY.MainParticleSystem.Play(withChildren: true);
		}
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		base.OnReplaySerialize(state);
		state.Write(multiThruster.CurrentThrustVector);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		base.OnReplayDeserialize(state);
		Vector3 vector = state.ReadVec3();
		multiThrusterVisualEffect.CheckAndActiveParticles(vector.x, multiThrusterVisualEffect.ParticleControlPX, multiThrusterVisualEffect.ParticleControlNX);
		multiThrusterVisualEffect.CheckAndActiveParticles(vector.y, multiThrusterVisualEffect.ParticleControlPY, multiThrusterVisualEffect.ParticleControlNY);
	}
}
