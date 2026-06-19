using System;
using System.Collections;
using Pug.UnityExtensions;
using UnityEngine;

public class Geyser : PoolableSimple
{
	[NonSerialized]
	public Transform follow;

	[NonSerialized]
	public bool manualPositionControl;

	[NonSerialized]
	public bool started;

	private bool locked;

	public ParticleSystem[] particleSystems { get; private set; }

	public ParticleSystemRenderer[] particleSystemRenderers { get; private set; }

	private void Awake()
	{
		particleSystems = GetComponentsInChildren<ParticleSystem>();
		particleSystemRenderers = GetComponentsInChildren<ParticleSystemRenderer>();
	}

	public void Play(Transform followTransform)
	{
		if (locked)
		{
			Debug.LogWarning("Trying to Play on a locked Geyser", this);
			return;
		}
		started = true;
		if (followTransform != null)
		{
			follow = followTransform;
			base.transform.position = followTransform.position;
			manualPositionControl = false;
		}
		else
		{
			follow = null;
			manualPositionControl = true;
		}
		ParticleSystem[] array = particleSystems;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Play();
		}
	}

	public void Stop()
	{
		started = false;
		ParticleSystem[] array = particleSystems;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
	}

	private void LateUpdate()
	{
		if (started && !manualPositionControl)
		{
			if (follow == null)
			{
				Stop();
			}
			else
			{
				base.transform.position = follow.position;
			}
		}
	}

	public override void OnFree()
	{
		StopAllCoroutines();
		Stop();
		locked = false;
	}

	public void Dispose(bool delayed = true)
	{
		StopAllCoroutines();
		if (delayed)
		{
			StartCoroutine(Co_DelayedFree());
			return;
		}
		Stop();
		Free();
	}

	private IEnumerator Co_DelayedFree()
	{
		locked = true;
		Stop();
		yield return Yielders.Pause(2f);
		Free();
	}
}
