using System;
using System.Collections.Generic;
using UnityEngine;

public class HazmatSolidEffectsController : HazmatCargoEffectsController
{
	[Serializable]
	public class ParticleSystemRuntimeHelper
	{
		public ParticleSystem particleSystem;

		[NonSerialized]
		public float particleStartSizeMax;

		[NonSerialized]
		public float particleStartSizeMin;
	}

	public ParticleSystemRuntimeHelper[] particleSystemRuntimeHelpers;

	public float smoothTimeFlame = 1f;

	public float minSmoothFlowInFlame = 0.5f;

	private float smoothFlowIn;

	private float flowInVelocity;

	private List<ParticleSystem> allParticles = new List<ParticleSystem>();

	private ParticleSystem.MainModule main;

	private void Start()
	{
		ParticleSystemRuntimeHelper[] array = particleSystemRuntimeHelpers;
		foreach (ParticleSystemRuntimeHelper particleSystemRuntimeHelper in array)
		{
			particleSystemRuntimeHelper.particleStartSizeMax = particleSystemRuntimeHelper.particleSystem.main.startSize.constantMax;
			particleSystemRuntimeHelper.particleStartSizeMin = particleSystemRuntimeHelper.particleSystem.main.startSize.constantMin;
			allParticles.Add(particleSystemRuntimeHelper.particleSystem);
		}
	}

	protected override void UpdateEffects()
	{
		if (flowIn > float.Epsilon || smoothFlowIn > minSmoothFlowInFlame)
		{
			smoothFlowIn = Mathf.SmoothDamp(smoothFlowIn, flowIn, ref flowInVelocity, smoothTimeFlame);
			float num = Mathf.Max(minSmoothFlowInFlame, smoothFlowIn);
			ParticleSystemRuntimeHelper[] array = particleSystemRuntimeHelpers;
			foreach (ParticleSystemRuntimeHelper particleSystemRuntimeHelper in array)
			{
				main = particleSystemRuntimeHelper.particleSystem.main;
				main.startSize = UnityEngine.Random.Range(particleSystemRuntimeHelper.particleStartSizeMin, particleSystemRuntimeHelper.particleStartSizeMax) * num * num;
				StartParticleIfNotPlaying(particleSystemRuntimeHelper.particleSystem);
			}
			if (burnAudio != null)
			{
				burnAudio.Set(smoothFlowIn);
			}
		}
		else
		{
			ParticleSystemRuntimeHelper[] array = particleSystemRuntimeHelpers;
			foreach (ParticleSystemRuntimeHelper particleSystemRuntimeHelper2 in array)
			{
				StopParticleIfPlaying(particleSystemRuntimeHelper2.particleSystem);
			}
		}
	}

	protected override void UpdateSpecialEffects()
	{
	}

	protected override Vector3 LeakParticleLocalPosition()
	{
		return Vector3.zero;
	}

	protected override void InitializeAudio()
	{
		if (burnAudio != null)
		{
			burnAudio = AudioManager.InstantiateLayeredAudio(burnAudio, base.transform);
			burnAudio.Set(0f);
		}
	}

	protected override void KillEffects(bool forced = false)
	{
		base.KillEffects(forced);
		smoothFlowIn = 0f;
		flowInVelocity = 0f;
		StopParticleIfPlaying(allParticles);
		if (forced)
		{
			ClearAllParticles(allParticles);
		}
	}
}
