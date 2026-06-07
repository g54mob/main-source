using System.Collections.Generic;
using DV;
using UnityEngine;

public class HazmatGasEffectsController : HazmatCargoEffectsController
{
	public ParticleSystem gasLeak;

	public ParticleSystem gasWave;

	public ParticleSystem gasWispy;

	public ParticleSystem gasWaveInitial;

	public ParticleSystem[] gasIgnition;

	private bool initialWavePlayed;

	public ParticleSystem flameWave;

	public ParticleSystem flameFireball;

	public ParticleSystem flameStem;

	public Transform fireParticleParent;

	public float smoothTimeLeak = 0.5f;

	public float smoothTimeFlame = 0.5f;

	private List<ParticleSystem> allParticles = new List<ParticleSystem>();

	private float leakParticleStartSpeed;

	private float burnParticleStartSpeed;

	private bool lerpIgnitionShape;

	private float maxLerpTime;

	private float[] shapeRadii;

	private float previousFlowIn;

	private float smoothFlowOut;

	private float smoothFlowIn;

	private float minSmoothFlowOut = 0.2f;

	private float minSmoothFlowIn = 0.2f;

	private float flowOutVelocity;

	private float flowInVelocity;

	private float ignitionElapsedTime;

	private float leakAudioVolume;

	private bool wasFlowOut;

	private bool wasFlowIn;

	private ParticleSystem.MinMaxCurve stemStartSize;

	private ParticleSystem.MainModule main;

	private void Start()
	{
		leakParticleStartSpeed = gasLeak.main.startSpeed.constant;
		if (flameWave != null)
		{
			burnParticleStartSpeed = flameWave.main.startSpeed.constant;
		}
		if (flameStem != null)
		{
			stemStartSize = flameStem.main.startSize;
		}
		allParticles.Add(gasLeak);
		allParticles.Add(gasWave);
		allParticles.Add(gasWispy);
		allParticles.Add(gasWaveInitial);
		if (flameWave != null)
		{
			allParticles.Add(flameWave);
		}
		if (flameFireball != null)
		{
			allParticles.Add(flameFireball);
		}
		if (flameStem != null)
		{
			allParticles.Add(flameStem);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (gasIgnition == null || gasIgnition.Length == 0)
		{
			return;
		}
		shapeRadii = new float[gasIgnition.Length];
		for (int i = 0; i < gasIgnition.Length; i++)
		{
			ParticleSystem particleSystem = gasIgnition[i];
			if (!(particleSystem == null))
			{
				shapeRadii[i] = particleSystem.shape.radius;
				float duration = particleSystem.main.duration;
				if (maxLerpTime < duration)
				{
					maxLerpTime = duration;
				}
			}
		}
	}

	protected override void Update()
	{
		base.Update();
		if (effectsAllowed && TimeUtil.IsFlowing)
		{
			previousFlowIn = flowIn;
		}
	}

	protected override void UpdateEffects()
	{
		UpdateFlowOut();
		UpdateFlowIn();
	}

	private void UpdateFlowOut()
	{
		if (flowOut > float.Epsilon || smoothFlowOut >= minSmoothFlowOut)
		{
			float num = flowOut;
			smoothFlowOut = Mathf.SmoothDamp(target: (!(flowOut > float.Epsilon)) ? 0f : Mathf.Lerp(0.5f, 1f, flowOut), current: smoothFlowOut, currentVelocity: ref flowOutVelocity, smoothTime: smoothTimeLeak);
			float num2 = Mathf.Max(minSmoothFlowOut, smoothFlowOut);
			main = gasLeak.main;
			main.startSpeed = leakParticleStartSpeed * num2;
			main = gasWave.main;
			main.startSpeed = leakParticleStartSpeed * num2;
			main = gasWispy.main;
			main.startSpeed = leakParticleStartSpeed * num2;
			if (smoothFlowOut >= minSmoothFlowOut)
			{
				StartParticleIfNotPlaying(gasLeak);
				StartParticleIfNotPlaying(gasWave);
				StartParticleIfNotPlaying(gasWispy);
				if (!initialWavePlayed)
				{
					StartParticleIfNotPlaying(gasWaveInitial);
					initialWavePlayed = true;
				}
			}
			else
			{
				StopParticleIfPlaying(gasLeak);
				StopParticleIfPlaying(gasWave);
				StopParticleIfPlaying(gasWispy);
			}
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
			StopParticleIfPlaying(gasLeak);
			StopParticleIfPlaying(gasWave);
			StopParticleIfPlaying(gasWispy);
		}
	}

	private void UpdateFlowIn()
	{
		if (flowIn > float.Epsilon || smoothFlowIn >= minSmoothFlowIn)
		{
			float num = flowIn;
			smoothFlowIn = Mathf.SmoothDamp(target: (!(flowIn > float.Epsilon)) ? 0f : Mathf.Lerp(0.5f, 1f, flowIn), current: smoothFlowIn, currentVelocity: ref flowInVelocity, smoothTime: smoothTimeFlame);
			float num2 = Mathf.Max(minSmoothFlowIn, smoothFlowIn);
			main = flameWave.main;
			ParticleSystem.MinMaxCurve minMaxCurve = (main.startSpeed = burnParticleStartSpeed * num2);
			main = flameWave.main;
			main = flameFireball.main;
			minMaxCurve = (main.startSpeed = burnParticleStartSpeed * num2);
			main = flameStem.main;
			ParticleSystem.MinMaxCurve startSize = main.startSize;
			startSize.constantMax = stemStartSize.constantMax * num2;
			startSize.constantMin = stemStartSize.constantMin * num2;
			main.startSize = startSize;
			StartParticleIfNotPlaying(flameWave);
			StartParticleIfNotPlaying(flameFireball);
			StartParticleIfNotPlaying(flameStem);
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
			if (burnAudio != null)
			{
				shouldSilenceBurnAudio = true;
				burnAudioStopVolume = smoothFlowIn;
				burnAudioElapsedSilenceTime = 0f;
			}
			smoothFlowIn = 0f;
			StopParticleIfPlaying(flameWave);
			StopParticleIfPlaying(flameFireball);
			StopParticleIfPlaying(flameStem);
		}
	}

	protected override void UpdateSpecialEffects()
	{
		if (previousFlowIn == 0f && flowIn > float.Epsilon && gasIgnition != null && gasIgnition.Length != 0)
		{
			for (int i = 0; i < gasIgnition.Length; i++)
			{
				ParticleSystem particleSystem = gasIgnition[i];
				if (!(particleSystem == null))
				{
					ParticleSystem.ShapeModule shape = particleSystem.shape;
					shape.radius = shapeRadii[i];
					particleSystem.Play();
					lerpIgnitionShape = true;
				}
			}
		}
		if (!lerpIgnitionShape)
		{
			return;
		}
		for (int j = 0; j < gasIgnition.Length; j++)
		{
			ParticleSystem particleSystem2 = gasIgnition[j];
			if (!(particleSystem2 == null))
			{
				ParticleSystem.ShapeModule shape2 = particleSystem2.shape;
				shape2.radius = Mathf.Lerp(shapeRadii[j], 0f, ignitionElapsedTime / particleSystem2.main.duration);
			}
		}
		ignitionElapsedTime += Time.deltaTime;
		if (!(ignitionElapsedTime < maxLerpTime))
		{
			lerpIgnitionShape = false;
			ignitionElapsedTime = 0f;
		}
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

	protected override Vector3 LeakParticleLocalPosition()
	{
		return Vector3.zero;
	}

	protected override void KillEffects(bool forced = false)
	{
		base.KillEffects(forced);
		previousFlowIn = 0f;
		smoothFlowIn = 0f;
		smoothFlowOut = 0f;
		flowOutVelocity = 0f;
		flowInVelocity = 0f;
		initialWavePlayed = false;
		lerpIgnitionShape = false;
		ignitionElapsedTime = 0f;
		wasFlowOut = false;
		wasFlowIn = false;
		leakAudioVolume = 0f;
		specialEffectsAllowed = false;
		StopParticleIfPlaying(allParticles);
		if (forced)
		{
			ClearAllParticles(allParticles);
		}
	}
}
