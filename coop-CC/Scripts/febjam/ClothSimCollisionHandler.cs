using Aggro.Core;
using UnityEngine;

public class ClothSimCollisionHandler : EntityBehaviourBase
{
	public Cloth cloth;

	public BoxCollider bc;

	public LayerMask layerMask;

	private static Collider[] _colliders = new Collider[16];

	private ClothSphereColliderPair[] _pairs = new ClothSphereColliderPair[16];

	protected override void OnUpdateSimulation()
	{
		Vector3 center = bc.transform.TransformPoint(bc.center);
		Vector3 halfExtents = bc.size / 2f;
		int num = Physics.OverlapBoxNonAlloc(center, halfExtents, _colliders, base.transform.rotation, layerMask);
		for (int i = 0; i < num; i++)
		{
			Collider collider = _colliders[i];
			ClothSphereColliderPair clothSphereColliderPair = new ClothSphereColliderPair
			{
				first = (collider as SphereCollider),
				second = null
			};
			_pairs[i] = clothSphereColliderPair;
		}
		for (int j = num; j < _pairs.Length; j++)
		{
			_pairs[j] = default(ClothSphereColliderPair);
		}
		cloth.sphereColliders = _pairs;
	}
}
