using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct MeleeAttackStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple internalTimer;

	public int meleeDamage;

	public int amountOfHitsDone;

	[HideInInspector]
	public int internalState;

	[HideInInspector]
	public float3 hitDirection;

	[HideInInspector]
	public Entity aimingAtEntity;

	[HideInInspector]
	public bool hitDone;

	public bool isDisabled;
}
