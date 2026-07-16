using System;
using UnityEngine;

public class CentipedeArmament : MonoBehaviour
{
	[SerializeField]
	protected GameObject spawnPrefab;

	[NonSerialized]
	public EnemyCentipede enemyCentipede;

	[field: SerializeField]
	public float TimeBetweenShots { get; private set; }

	public Animator Anim { get; private set; }

	protected void Awake()
	{
		Anim = GetComponent<Animator>();
	}

	public virtual bool TryDisarm()
	{
		return true;
	}

	public virtual void Aim()
	{
	}

	public virtual void Fire()
	{
	}

	public virtual void OnSegmentFactionChanged()
	{
	}
}
