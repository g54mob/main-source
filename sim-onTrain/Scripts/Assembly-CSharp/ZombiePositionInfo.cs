using System;
using UnityEngine;

[Serializable]
public class ZombiePositionInfo
{
	public Vector3 targetPosition;

	public Vector3 attackPosition;

	public bool canAttack;

	public bool shouldMove;

	public bool isInPosition;
}
