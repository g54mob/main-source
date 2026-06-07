using System;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
	protected ParticleSystem partSys;

	[NonSerialized]
	public bool stopped;

	[NonSerialized]
	protected bool dead;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void Init()
	{
	}

	public void GameUpdate()
	{
	}

	public virtual void DestroyParticleSystem()
	{
	}
}
