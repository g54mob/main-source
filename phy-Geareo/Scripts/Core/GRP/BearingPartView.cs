using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	public class BearingPartView : PartView<BearingPartViewable>
	{
		public PoolObject cylinderBodyPrefab;

		public PoolObject boxBodyPrefab;

		public CylinderVisual shaft;

		public CylinderVisual core;

		public BearingMotorVisual motor;

		public Transform right;

		public Transform left;

		public Transform top;

		public Transform bottom;

		public Transform forward;

		public Transform back;

		public float spacing;

		private PoolObject shapeObject;

		private IMotorVisual shapeVisual;

		private MagicController magicController;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}

		public static void BuildCore(BearingPart part, CylinderVisual coreVisual)
		{
		}
	}
}
