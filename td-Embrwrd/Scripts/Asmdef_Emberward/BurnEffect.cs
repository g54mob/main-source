using System;
using UnityEngine;

[Serializable]
public class BurnEffect
{
	[SerializeField]
	private float maxDuration;

	[SerializeField]
	private float timer;

	private ABaseTower fromTower;

	public float Timer => 0f;

	public ABaseTower FromTower => null;

	public bool IsFinished => false;

	public BurnEffect(float duration, ABaseTower tower)
	{
	}

	public void Extend(float duration)
	{
	}

	public void Update(float deltaTime)
	{
	}
}
