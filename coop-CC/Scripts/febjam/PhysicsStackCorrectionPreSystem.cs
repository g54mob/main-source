using Aggro.Core;
using UnityEngine;

[UpdateInGroup(typeof(PhysicsSystemGroup), UpdatePriority.Early)]
public class PhysicsStackCorrectionPreSystem : EntityObjectSystemBase<Grabbable>
{
	protected override void OnUpdateObjectSystem(QueryResults<Grabbable> results)
	{
		for (int i = 0; i < results.count; i++)
		{
			Grabbable grabbable = results[i];
			Rigidbody rigidbody = grabbable.entity.rigidbody;
			if (rigidbody.isKinematic || (grabbable.stackCorrectionVelocity.sqrMagnitude == 0f && grabbable.stackCorrectionTorque.sqrMagnitude == 0f))
			{
				grabbable.stackCorrectionVelocity = Vector3.zero;
				grabbable.stackCorrectionTorque = Vector3.zero;
				continue;
			}
			Vector3 velocity = rigidbody.velocity;
			velocity += PhysicsUtil.InverseDrag(grabbable.stackCorrectionVelocity, rigidbody.drag);
			Vector3 angularVelocity = rigidbody.angularVelocity;
			angularVelocity += PhysicsUtil.InverseDrag(grabbable.stackCorrectionTorque, rigidbody.angularDrag);
			rigidbody.velocity = velocity;
			rigidbody.angularVelocity = angularVelocity;
		}
	}
}
