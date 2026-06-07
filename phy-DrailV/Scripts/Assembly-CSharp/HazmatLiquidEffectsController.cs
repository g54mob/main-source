using System.Collections.Generic;
using UnityEngine;

public class HazmatLiquidEffectsController : HazmatCargoEffectsController
{
	[SerializeField]
	private ParticleSystem[] liquidParticles;

	[SerializeField]
	private ParticleSystem terrainCollisionParticle;

	[SerializeField]
	private ParticleSystem[] burnParticles;

	[SerializeField]
	private Transform fireParticleParent;

	[SerializeField]
	private float smoothTimeLeak = 1f;

	[SerializeField]
	private float smoothTimeFlame = 1f;

	[SerializeField]
	private float minSmoothFlowOut = 0.2f;

	[SerializeField]
	private float minSmoothFlowInFlame = 0.5f;

	[Range(0f, 1f)]
	[SerializeField]
	private float minRandomFactorY;

	[SerializeField]
	[Range(1f, 2f)]
	private float maxRandomFactorY = 2f;

	private List<ParticleSystem> allParticles = new List<ParticleSystem>();

	private float liquidParticleStartSpeed;

	private float burnParticleStartSpeed;

	private float smoothFlowOut;

	private float smoothFlowIn;

	private Vector3 smoothVel = Vector3.zero;

	private float flowOutVelocity;

	private float flowInVelocity;

	private Vector3 fireParticleParentInitialPosition;

	private ParticleSystem.MainModule main;

	private Vector3 distanceOffset = Vector3.zero;

	private float travelTime = 0.2f;

	private float leakAudioVolume;

	private bool wasFlowOut;

	private bool wasFlowIn;

	private void Start()
	{
		if (liquidParticles.Length != 0 && liquidParticles[0] != null)
		{
			liquidParticleStartSpeed = liquidParticles[0].main.startSpeed.constant;
		}
		ParticleSystem[] array;
		if (burnParticles != null && burnParticles.Length != 0 && burnParticles[0] != null)
		{
			burnParticleStartSpeed = burnParticles[0].main.startSpeed.constant;
			fireParticleParentInitialPosition = fireParticleParent.transform.localPosition;
			array = burnParticles;
			foreach (ParticleSystem item in array)
			{
				allParticles.Add(item);
			}
		}
		array = liquidParticles;
		foreach (ParticleSystem item2 in array)
		{
			allParticles.Add(item2);
		}
		if (terrainCollisionParticle != null)
		{
			allParticles.Add(terrainCollisionParticle);
		}
	}

	protected override void UpdateEffects()
	{
		UpdateFlowOut();
		UpdateFlowIn();
	}

	protected override void UpdateSpecialEffects()
	{
	}

	private void UpdateFlowOut()
	{
		if (flowOut > float.Epsilon || smoothFlowOut >= minSmoothFlowOut)
		{
			smoothFlowOut = Mathf.SmoothDamp(smoothFlowOut, flowOut, ref flowOutVelocity, smoothTimeLeak);
			float num = Mathf.Max(minSmoothFlowOut, smoothFlowOut);
			ParticleSystem[] array = liquidParticles;
			foreach (ParticleSystem particleSystem in array)
			{
				main = particleSystem.main;
				main.startSpeed = liquidParticleStartSpeed * num;
			}
			main = terrainCollisionParticle.main;
			main.startSpeed = liquidParticleStartSpeed * num;
			distanceOffset.z = main.startSpeed.constant * travelTime * num;
			float num2 = travelTime * main.startSpeed.constant / liquidParticleStartSpeed;
			distanceOffset.y = Random.Range(minRandomFactorY, maxRandomFactorY) * main.gravityModifier.constant * Physics.gravity.y * num2 * num2 * 0.5f;
			StartParticleIfNotPlaying(liquidParticles);
			StartParticleIfNotPlaying(terrainCollisionParticle);
			if (leakAudio != null)
			{
				leakAudioVolume = Mathf.Clamp01(smoothFlowOut - smoothFlowIn) * leakAudioModifier;
				leakAudio.Set(leakAudioVolume);
				shouldSilenceLeakAudio = false;
			}
			wasFlowOut = true;
		}
		else if (wasFlowOut)
		{
			wasFlowOut = false;
			if (leakAudio != null)
			{
				shouldSilenceLeakAudio = true;
				leakAudioStopVolume = leakAudioVolume;
				leakAudioElapsedSilenceTime = 0f;
			}
			smoothFlowOut = 0f;
			StopParticleIfPlaying(liquidParticles);
			StopParticleIfPlaying(terrainCollisionParticle);
			if (terrainCollisionParticle != null)
			{
				terrainCollisionParticle.Clear();
			}
		}
	}

	private void UpdateFlowIn()
	{
		if (flowIn > float.Epsilon || smoothFlowIn > minSmoothFlowInFlame)
		{
			smoothFlowIn = Mathf.SmoothDamp(smoothFlowIn, flowIn, ref flowInVelocity, smoothTimeFlame);
			Mathf.Max(minSmoothFlowInFlame, smoothFlowIn);
			ParticleSystem[] array = burnParticles;
			foreach (ParticleSystem particleSystem in array)
			{
				main = particleSystem.main;
				ParticleSystem.MinMaxCurve minMaxCurve = (main.startSpeed = burnParticleStartSpeed * Mathf.Max(minSmoothFlowInFlame, smoothFlowIn));
			}
			if (fireParticleParent.localPosition != fireParticleParentInitialPosition)
			{
				fireParticleParent.localPosition = Vector3.SmoothDamp(fireParticleParent.localPosition, fireParticleParentInitialPosition + distanceOffset, ref smoothVel, smoothTimeLeak * 0.7f);
			}
			else
			{
				fireParticleParent.localPosition = fireParticleParentInitialPosition + distanceOffset;
			}
			StartParticleIfNotPlaying(burnParticles);
			if (burnAudio != null)
			{
				burnAudio.Set(smoothFlowIn);
				shouldSilenceBurnAudio = false;
			}
			wasFlowIn = true;
		}
		else if (wasFlowIn)
		{
			wasFlowIn = false;
			burnAudioStopVolume = smoothFlowIn;
			shouldSilenceBurnAudio = true;
			burnAudioElapsedSilenceTime = 0f;
			smoothFlowIn = 0f;
			StopParticleIfPlaying(burnParticles);
		}
	}

	protected override Vector3 LeakParticleLocalPosition()
	{
		if (liquidParticles.Length != 0 && liquidParticles[0] != null)
		{
			return liquidParticles[0].transform.localPosition;
		}
		return Vector3.zero;
	}

	protected override void InitializeAudio()
	{
		if (leakAudio != null)
		{
			leakAudio = AudioManager.InstantiateLayeredAudio(leakAudio, base.transform);
			leakAudio.Set(0f);
		}
		if (burnAudio != null)
		{
			burnAudio = AudioManager.InstantiateLayeredAudio(burnAudio, fireParticleParent.transform);
			burnAudio.Set(0f);
		}
	}

	protected override void KillEffects(bool forced = false)
	{
		base.KillEffects(forced);
		smoothFlowIn = 0f;
		smoothFlowOut = 0f;
		smoothVel = Vector3.zero;
		flowOutVelocity = 0f;
		flowInVelocity = 0f;
		distanceOffset = Vector3.zero;
		leakAudioVolume = 0f;
		wasFlowOut = false;
		wasFlowIn = false;
		StopParticleIfPlaying(allParticles);
		if (forced)
		{
			ClearAllParticles(allParticles);
		}
		else if (terrainCollisionParticle != null)
		{
			terrainCollisionParticle.Clear();
		}
	}
}
