using Aggro.Core;
using UnityEngine;

[UpdateInGroup(typeof(PhysicsSystemGroup), UpdatePriority.Late)]
public class PhysicsStackCorrectionPostSystem : EntityObjectSystemBase<Grabbable>
{
	protected override void OnUpdateObjectSystem(QueryResults<Grabbable> results)
	{
		for (int i = 0; i < results.count; i++)
		{
			Grabbable grabbable = results[i];
			Rigidbody rigidbody = grabbable.entity.rigidbody;
			if (!rigidbody.isKinematic && (grabbable.stackCorrectionVelocity.sqrMagnitude > 0f || grabbable.stackCorrectionTorque.sqrMagnitude > 0f))
			{
				rigidbody.velocity = PhysicsUtil.RemoveValue(rigidbody.velocity, grabbable.stackCorrectionVelocity);
				rigidbody.angularVelocity = PhysicsUtil.RemoveValue(rigidbody.angularVelocity, grabbable.stackCorrectionTorque);
			}
			grabbable.stackCorrectionVelocity = Vector3.zero;
			grabbable.stackCorrectionTorque = Vector3.zero;
		}
	}
}
