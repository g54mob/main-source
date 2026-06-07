using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseParticlesAtNightTime : MonoBehaviour
{
	[SerializeField]
	private List<ParticleSystem> particleSystems;

	private void Start()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Combine(singleton.OnNightTime_Action, new Action(OnNightTime));
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Remove(singleton.OnNightTime_Action, new Action(OnNightTime));
	}

	private void OnNightTime()
	{
		foreach (ParticleSystem particleSystem in particleSystems)
		{
			particleSystem.Pause();
		}
	}
}
