using UnityEngine;

namespace UltimateReplay.Core.StatePreparer
{
	[ReplayComponentPreparer(typeof(Rigidbody2D))]
	internal sealed class RigidBody2DPreparer : ComponentPreparer<Rigidbody2D>
	{
		public override void PrepareForPlayback(Rigidbody2D component, ReplayState additionalData)
		{
			additionalData.Write(component.isKinematic);
			additionalData.Write(component.simulated);
			component.isKinematic = true;
			component.simulated = false;
		}

		public override void PrepareForGameplay(Rigidbody2D component, ReplayState additionalData)
		{
			bool isKinematic = additionalData.ReadBool();
			bool simulated = additionalData.ReadBool();
			component.isKinematic = isKinematic;
			component.simulated = simulated;
		}
	}
}
