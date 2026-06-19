using Aggro.Core;
using Mirror;
using UnityEngine;

public class BoxSafeZone : EntityBehaviourBase
{
	private static Collider[] _colliders = new Collider[256];

	private Transform _transform;

	protected override void OnEntityCreated()
	{
		_transform = base.transform;
	}

	[UpdateInGroup((UpdatePriority)(-9999))]
	protected override void OnUpdateSimulationEarly()
	{
		if (!NetworkServer.active)
		{
			return;
		}
		Vector3 lossyScale = _transform.lossyScale;
		int num = Physics.OverlapBoxNonAlloc(_transform.position, lossyScale / 2f, _colliders, _transform.rotation, 16384);
		for (int i = 0; i < num; i++)
		{
			if (_colliders[i].TryGetEntity(out var entity) && entity.TryGetObject<BoxProps>(out var obj))
			{
				obj.serverIsSafe = true;
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = new Color(0f, 1f, 1f, 0.35f);
		Gizmos.DrawCube(Vector3.zero, new Vector3(1f, 1f, 1f));
	}
}
