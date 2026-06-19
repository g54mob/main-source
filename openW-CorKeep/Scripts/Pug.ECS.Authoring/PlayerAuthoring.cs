using Unity.Physics.Authoring;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
	public float walkingReorientationDelay = 1f / 15f;

	public AnimationCurve vehicleDriftingAmountCurve;

	public PhysicsShapeAuthoring collisionCollider;
}
