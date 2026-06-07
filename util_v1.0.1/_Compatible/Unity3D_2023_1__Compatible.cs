using UnityEngine;
using System.Collections;
namespace SPACE_COMPATIBLE
{
	public static class RigidBodyCompatibilityExtension
	{
		// --- Linear damping (drag) ---
		public static void setLinearDamping(this Rigidbody rb, float value)
		{
#if UNITY_2023_1_OR_NEWER
			rb.linearDamping = value;
#else
        rb.drag = value;
#endif
		}
		public static float getLinearDamping(this Rigidbody rb)
		{
#if UNITY_2023_1_OR_NEWER
			return rb.linearDamping;
#else
        return rb.drag;
#endif
		}
		// --- Angular damping (angular drag) ---
		public static void setAngularDamping(this Rigidbody rb, float value)
		{
#if UNITY_2023_1_OR_NEWER
			rb.angularDamping = value;
#else
        rb.angularDrag = value;
#endif
		}
		public static float getAngularDamping(this Rigidbody rb)
		{
#if UNITY_2023_1_OR_NEWER
			return rb.angularDamping;
#else
        return rb.angularDrag;
#endif
		}
		// --- Linear velocity ---
		public static void setLinearVelocity(this Rigidbody rb, Vector3 value)
		{
#if UNITY_2023_1_OR_NEWER
			rb.linearVelocity = value;
#else
        rb.velocity = value;
#endif
		}
		public static Vector3 getLinearVelocity(this Rigidbody rb)
		{
#if UNITY_2023_1_OR_NEWER
			return rb.linearVelocity;
#else
        return rb.velocity;
#endif
		}
		// --- Angular velocity (name didn’t change, included for symmetry) ---
		public static void setAngularVelocity(this Rigidbody rb, Vector3 value)
		{
			rb.angularVelocity = value;
		}
		public static Vector3 getAngularVelocity(this Rigidbody rb)
		{
			return rb.angularVelocity;
		}
	}

}