using UltimateReplay;
using UnityEngine;

public class CustomReplayParticles : ReplayBehaviour
{
	private float lastTime;

	private float targetTime;

	private bool stopParticlesOnPlaybackEnd;

	private bool simulateDirty;

	public ParticleSystem observedParticleSystem;

	public bool simulateChildren;

	public override void Awake()
	{
		if (observedParticleSystem == null)
		{
			Debug.LogWarning($"No particle system for 'ReplayParticles' component '{base.gameObject.name}'");
			return;
		}
		Debug.Log("Note: ReplayParticles are not working in this version. An update will be released soon to fix this");
		base.Awake();
	}

	public void Play()
	{
		observedParticleSystem.Play(simulateChildren);
	}

	public void Stop()
	{
		observedParticleSystem.Stop(simulateChildren);
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		if (!(observedParticleSystem == null))
		{
			state.Write(observedParticleSystem.time);
		}
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		if (!(observedParticleSystem == null))
		{
			lastTime = targetTime;
			targetTime = state.ReadFloat();
			observedParticleSystem.Simulate(targetTime - lastTime, withChildren: true, restart: false);
		}
	}

	public override void OnReplayStart()
	{
		stopParticlesOnPlaybackEnd = !observedParticleSystem.isPlaying;
		if (!observedParticleSystem.isPlaying)
		{
			observedParticleSystem.Play(simulateChildren);
		}
	}

	public override void OnReplayEnd()
	{
		if (stopParticlesOnPlaybackEnd)
		{
			observedParticleSystem.Stop(simulateChildren);
		}
	}

	public override void OnReplayPlayPause(bool paused)
	{
		if (paused)
		{
			observedParticleSystem.Pause(simulateChildren);
		}
		else
		{
			observedParticleSystem.Play(simulateChildren);
		}
	}

	public override void OnReplayUpdate()
	{
		simulateDirty = true;
	}

	public void InternFixedUpdate()
	{
		if (simulateDirty)
		{
			float num = Mathf.Lerp(lastTime, targetTime, ReplayTime.Delta);
			float num2 = num / observedParticleSystem.duration;
			float t = Mathf.Abs(targetTime - lastTime);
			observedParticleSystem.time = num;
			observedParticleSystem.Clear();
			observedParticleSystem.Simulate(Time.deltaTime, simulateChildren, restart: false);
			observedParticleSystem.Clear();
			observedParticleSystem.time = 0f;
			observedParticleSystem.Simulate(Time.deltaTime, simulateChildren, restart: true);
			while (observedParticleSystem.time < num2)
			{
				observedParticleSystem.Simulate(Time.deltaTime, simulateChildren, restart: false);
			}
			observedParticleSystem.time = num;
			observedParticleSystem.Simulate(t, simulateChildren, restart: false);
			observedParticleSystem.Simulate(targetTime, simulateChildren, restart: false);
			observedParticleSystem.Pause();
			simulateDirty = false;
		}
	}
}
