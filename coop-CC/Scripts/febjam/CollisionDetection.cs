using System.Collections.Generic;
using Aggro.Core;
using UnityEngine;

public class CollisionDetection : EntityBehaviourBase
{
	private static List<ICollisionEnter> _collisions = new List<ICollisionEnter>();

	private void OnCollisionEnter(Collision collision)
	{
		_collisions.Clear();
		base.entity.GetObjects(_collisions);
		for (int i = 0; i < _collisions.Count; i++)
		{
			_collisions[i].CollisionEnter(collision);
		}
	}
}
