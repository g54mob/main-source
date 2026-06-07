using UltimateReplay;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(SolidRocket))]
[RequireComponent(typeof(SolidRocketVisualEffect))]
public class SolidRocketVEReplay : ReplayBehaviour
{
	private SolidRocket solidRocket;

	private SolidRocketVisualEffect solidRocketVisualEffect;

	private float initialThrust;

	public override void Awake()
	{
		base.Awake();
		solidRocket = GetComponent<SolidRocket>();
		solidRocketVisualEffect = GetComponent<SolidRocketVisualEffect>();
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		initialThrust = solidRocket.CurrentThrust;
		solidRocketVisualEffect.SolidRocketParticleControl.MainParticleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
	}

	public override void OnReplayEnd()
	{
		base.OnReplayEnd();
		if (initialThrust > solidRocketVisualEffect.MinValueToStart)
		{
			solidRocketVisualEffect.SolidRocketParticleControl.MainParticleSystem.Play(withChildren: true);
		}
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		base.OnReplaySerialize(state);
		state.Write(solidRocket.CurrentThrust);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		base.OnReplayDeserialize(state);
		float thrust = state.ReadFloat();
		solidRocketVisualEffect.CheckAndActiveParticles(thrust);
	}
}
