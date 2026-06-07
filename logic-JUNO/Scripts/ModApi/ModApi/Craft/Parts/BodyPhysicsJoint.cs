using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class BodyPhysicsJoint
	{
		public AttachPoint AttachPoint { get; private set; }

		public bool IsDestroyed => Joint == null;

		public Joint Joint { get; private set; }

		public BodyPhysicsJoint(Joint joint, AttachPoint attachPoint)
		{
			Joint = joint;
			AttachPoint = attachPoint;
		}
	}
}
