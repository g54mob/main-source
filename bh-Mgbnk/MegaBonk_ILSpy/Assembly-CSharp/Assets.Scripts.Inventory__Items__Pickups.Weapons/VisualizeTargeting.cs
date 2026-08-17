using Assets.Scripts.Actors.Enemies;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public class VisualizeTargeting : MonoBehaviour
{
	private Enemy target;

	private unsafe void FixedUpdate()
	{
		//IL_0033: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		GameObject exceptObject = default(GameObject);
		Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&obj), 100f, 0, useVision: true, exceptObject);
		target = enemy;
	}

	private void Update()
	{
		if (target != null && target.IsDead())
		{
			target = null;
		}
	}
}
