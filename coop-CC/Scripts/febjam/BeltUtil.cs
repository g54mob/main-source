using Aggro.Core;
using UnityEngine;

public static class BeltUtil
{
	private const float RADIUS = 0.1f;

	private static RaycastHit[] _hits = new RaycastHit[8];

	public static Vector3 GetMovingSideWalkVelocity(Vector3 position)
	{
		position.y = 0f;
		int num = Physics.SphereCastNonAlloc(position + Vector3.up, 0.1f, Vector3.down, _hits, 2f, 8192);
		if (num > 0)
		{
			RaycastHit raycastHit = default(RaycastHit);
			float num2 = float.MaxValue;
			for (int i = 0; i < num; i++)
			{
				RaycastHit raycastHit2 = _hits[i];
				Vector3 point = raycastHit2.point;
				point.y = 0f;
				float sqrMagnitude = (point - position).sqrMagnitude;
				if (sqrMagnitude < num2)
				{
					num2 = sqrMagnitude;
					raycastHit = raycastHit2;
				}
			}
			if (raycastHit.collider.TryGetEntity(out var entity) && entity.TryGetObject<ConveyorBelt>(out var obj))
			{
				return entity.transform.forward * obj.forwardsSpeed;
			}
		}
		return Vector3.zero;
	}
}
