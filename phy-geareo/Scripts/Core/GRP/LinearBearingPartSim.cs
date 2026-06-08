using System;
using UnityEngine;

namespace GRP
{
	public class LinearBearingPartSim : PartSim<LinearBearingPart>, ISimTick
	{
		public BoxVisual bodyVisual;

		public BoxVisual shaftVisual;

		public BoxVisual coreVisual;

		public Transform topCollider;

		public Transform bottomCollider;

		public LinearBearingMotorVisual motor;

		public HubReceiver receiver;

		public GuidePointable guidePointable;

		public BoxShape bodyShape;

		public BoxShape topShape;

		public BoxShape bottomShape;

		public WorldPointableCollider shaftCollider;

		public float spacing;

		private float calculatedForce;

		private MagicController magicController;

		public ConfigurableJoint joint { get; private set; }

		public override Type GetPartType()
		{
			return null;
		}

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
		}

		public void SimTick()
		{
		}

		private void SetVelocity(float m)
		{
		}

		protected override void BodiesReady()
		{
		}
	}
}
