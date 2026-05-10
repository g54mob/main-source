using UnityEngine;

public class EnemyCombatComponent : CombatComponent
{
	[SerializeField]
	private Transform shootTransform;

	public Transform ShootTransform => shootTransform;
}
