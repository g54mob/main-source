using UnityEngine;

namespace UltimateReplay.Core.StatePreparer
{
	[ReplayComponentPreparer(typeof(Rigidbody))]
	internal sealed class RigidBodyPreparer : ComponentPreparer<Rigidbody>
	{
		public override void PrepareForPlayback(Rigidbody component, ReplayState additionalData)
		{
			additionalData.Write(component.isKinematic);
			if (!component.isKinematic)
			{
				additionalData.Write(component.velocity);
				additionalData.Write(component.angularVelocity);
			}
			component.isKinematic = true;
		}

		public override void PrepareForGameplay(Rigidbody component, ReplayState additionalData)
		{
			if (!(component.isKinematic = additionalData.ReadBool()))
			{
				component.velocity = additionalData.ReadVec3();
				component.angularVelocity = additionalData.ReadVec3();
			}
		}
	}
}
