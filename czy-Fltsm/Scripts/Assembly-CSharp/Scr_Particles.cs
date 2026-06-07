using System;
using UnityEngine;

[Obsolete]
public class Scr_Particles : MonoBehaviour
{
	public ParticleSystem _particleSystem;

	private float currentTimeScale = 1f;

	private void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
		InitializeReferences();
		currentTimeScale = GameSpeedManager.PausableUnscaledDeltaTime;
	}

	private void InitializeReferences()
	{
		if (_particleSystem == null)
		{
			_particleSystem = GetComponent<ParticleSystem>();
		}
	}

	private void Update()
	{
		if (GameSpeedManager.PausableUnscaledDeltaTime != currentTimeScale)
		{
			UpdateTimeScale();
		}
	}

	private void UpdateTimeScale()
	{
		currentTimeScale = GameSpeedManager.PausableUnscaledDeltaTime;
	}
}
