using System.Collections.Generic;
using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Craft
{
	public interface IBodyJoint
	{
		IBodyScript Body { get; }

		bool Broken { get; set; }

		IBodyScript ConnectedBody { get; }

		IReadOnlyList<BodyPhysicsJoint> Joints { get; }

		PartConnection PartConnection { get; }

		void Destroy();

		Joint GetJointForAttachPoint(AttachPoint attachPoint);

		IBodyScript OtherBody(IBodyScript body);
	}
}
