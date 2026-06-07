using UltimateReplay;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(ParticlesLifeControl))]
public class ParticlesLifeControlReplay : ReplayBehaviour
{
	private ParticleSystem mainParticleSystem;

	private ParticleSystem longestParticleSystem;

	private ParticleSystem[] allParticleSystems;

	private ParticlesLifeControl particlesLifeControl;

	private bool initialIsExisting;

	private Vector3 initialPosition;

	private Quaternion initialRotation;

	private float initialParticlesTime;

	private bool internalIsExisting;

	private Vector3 targetPosition;

	private Vector3 lastPosition;

	private Quaternion targetRotation;

	private Quaternion lastRotation;

	private float targetParticlesTime;

	private float lastParticlesTime;

	private bool shouldUpdatePosition;

	private bool shouldSaveBornPosition;

	private bool shouldSaveDeathPosition;

	private bool isReplayRunning;

	public override void Awake()
	{
		base.Awake();
		mainParticleSystem = GetComponent<ParticleSystem>();
		allParticleSystems = GetComponentsInChildren<ParticleSystem>(includeInactive: false);
		longestParticleSystem = allParticleSystems[0];
		for (int i = 1; i < allParticleSystems.Length; i++)
		{
			if (allParticleSystems[i].main.duration > longestParticleSystem.main.duration)
			{
				longestParticleSystem = allParticleSystems[i];
			}
		}
		particlesLifeControl = GetComponent<ParticlesLifeControl>();
		lastPosition = (targetPosition = base.transform.position);
		lastRotation = (targetRotation = base.transform.rotation);
		lastParticlesTime = (targetParticlesTime = 0f);
		shouldSaveBornPosition = true;
		shouldSaveDeathPosition = false;
		isReplayRunning = false;
	}

	public override void OnReplayReset()
	{
		base.OnReplayReset();
		lastPosition = targetPosition;
		lastRotation = targetRotation;
		lastParticlesTime = targetParticlesTime;
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		initialParticlesTime = longestParticleSystem.time;
		uint randomSeed = (uint)Random.Range(int.MinValue, int.MaxValue);
		mainParticleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		for (int i = 0; i < allParticleSystems.Length; i++)
		{
			allParticleSystems[i].useAutoRandomSeed = false;
			allParticleSystems[i].randomSeed = randomSeed;
		}
		particlesLifeControl.ShouldStopControl = true;
		initialIsExisting = particlesLifeControl.IsExisting;
		initialPosition = base.transform.position;
		initialRotation = base.transform.rotation;
		initialParticlesTime = longestParticleSystem.time;
		shouldSaveBornPosition = true;
		shouldSaveDeathPosition = false;
		isReplayRunning = true;
	}

	public override void OnReplayEnd()
	{
		base.OnReplayEnd();
		isReplayRunning = false;
		for (int i = 0; i < allParticleSystems.Length; i++)
		{
			allParticleSystems[i].useAutoRandomSeed = true;
		}
		particlesLifeControl.ShouldStopControl = false;
		if (initialIsExisting)
		{
			mainParticleSystem.Simulate(initialParticlesTime, withChildren: true);
		}
		particlesLifeControl.SetExistence(initialIsExisting);
		base.transform.position = initialPosition;
		base.transform.rotation = initialRotation;
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		bool isExisting = particlesLifeControl.IsExisting;
		state.Write(isExisting);
		if (isExisting)
		{
			state.Write(longestParticleSystem.time);
			state.Write(shouldSaveBornPosition);
			if (shouldSaveBornPosition)
			{
				state.Write(base.transform.position);
				state.Write(base.transform.rotation);
				shouldSaveBornPosition = false;
				shouldSaveDeathPosition = true;
			}
			state.Write(particlesLifeControl.ShouldUpdatePosition);
			if (particlesLifeControl.ShouldUpdatePosition)
			{
				state.Write(base.transform.position);
				state.Write(base.transform.rotation);
			}
		}
		else
		{
			shouldSaveBornPosition = true;
			state.Write(shouldSaveDeathPosition);
			if (shouldSaveDeathPosition)
			{
				state.Write(base.transform.position);
				state.Write(base.transform.rotation);
				shouldSaveDeathPosition = false;
			}
		}
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		internalIsExisting = state.ReadBool();
		if (internalIsExisting)
		{
			lastParticlesTime = targetParticlesTime;
			targetParticlesTime = state.ReadFloat();
			if (state.ReadBool())
			{
				base.transform.position = state.ReadVec3();
				base.transform.rotation = state.ReadQuat();
				lastParticlesTime = 0f;
			}
			bool flag = state.ReadBool();
			if (flag)
			{
				lastPosition = targetPosition;
				lastRotation = targetRotation;
				targetPosition = state.ReadVec3();
				targetRotation = state.ReadQuat();
			}
			shouldUpdatePosition = flag;
		}
		else
		{
			mainParticleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
			if (state.ReadBool())
			{
				base.transform.position = state.ReadVec3();
				base.transform.rotation = state.ReadQuat();
				targetParticlesTime = (lastParticlesTime = longestParticleSystem.main.duration);
			}
		}
	}

	public override void OnReplayUpdate()
	{
		base.OnReplayUpdate();
		if (isReplayRunning && internalIsExisting)
		{
			float t = Mathf.Lerp(lastParticlesTime, targetParticlesTime, ReplayTime.Delta);
			mainParticleSystem.Simulate(t, withChildren: true);
			if (shouldUpdatePosition)
			{
				Vector3 vector = targetPosition;
				Quaternion quaternion = targetRotation;
				vector = Vector3.Lerp(lastPosition, targetPosition, ReplayTime.Delta);
				quaternion = Quaternion.Lerp(lastRotation, targetRotation, ReplayTime.Delta);
				base.transform.position = vector;
				base.transform.rotation = quaternion;
			}
		}
	}
}
