using UnityEngine;

namespace GRP
{
	public class SpringPartSim : PartSim<SpringPart>, ISimPostPhysicsUpdate, ISimPhysicsUpdate
	{
		public BoxShape topShape;

		public BoxShape bottomShape;

		public BoxVisual topVisual;

		public BoxVisual bottomVisual;

		public SpringVisual spring;

		public SpringJoint springJoint { get; private set; }

		public ConfigurableJoint confJoint { get; private set; }

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
		}

		public void SimPostPhysicsUpdate()
		{
		}

		public void SimPhysicsUpdate()
		{
		}

		public override void FreezeTransform()
		{
		}

		protected override void BodiesReady()
		{
		}
	}
}
