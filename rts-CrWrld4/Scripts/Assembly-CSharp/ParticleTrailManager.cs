using System;
using UnityEngine;

public class ParticleTrailManager : MonoBehaviour
{
	public enum TRAIL_TYPE
	{
		LINE = 0,
		SMOKE = 1
	}

	protected ParticleSystem partSys;

	[NonSerialized]
	protected bool dead;

	[NonSerialized]
	public GameObject unit;

	[NonSerialized]
	public float unitOffset;

	[NonSerialized]
	public Vector3 unitVectorOffset;

	[NonSerialized]
	public bool hasVectorOffset;

	private int updateCount;

	private int deathCounter;

	private int dieTime;

	[NonSerialized]
	public TRAIL_TYPE trailType;

	[NonSerialized]
	public float startLifetime;

	public static ParticleTrailManager GetTrail(TRAIL_TYPE trailType, GameObject unit, float startLifetime)
	{
		return null;
	}

	private void Awake()
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
