using System;
using UnityEngine;

[Serializable]
public class FragileEffect
{
	[SerializeField]
	private float fragileValue;

	private ABaseTower fromTower;

	private float decayTimer;

	public float Value => 0f;

	public ABaseTower FromTower => null;

	public bool IsFinished => false;

	public FragileEffect(float fragileValue, ABaseTower tower)
	{
	}

	public void Update(float deltaTime)
	{
	}
}
