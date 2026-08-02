using System;
using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	public class BearingPartSim : PartSim<BearingPart>, ISimTick, ISimPrePhysicsUpdate
	{
		public PoolObject cylinderBodyPrefab;

		public PoolObject boxBodyPrefab;

		public CylinderVisual shaftVisual;

		public CylinderVisual coreVisual;

		public Transform topCollider;

		public Transform bottomCollider;

		public BearingMotorVisual motor;

		public HubReceiver receiver;

		public GuidePointable guidePointable;

		public CylinderShape bodyCylinderShape;

		public BoxShape bodyBoxShape;

		public CustomShape bodyShape;

		public CylinderShape topShape;

		public CylinderShape bottomShape;

		public WorldPointableCollider shaftCollider;

		public float spacing;

		private PoolObject shapeObject;

		private IMotorVisual shapeVisual;

		private float calculatedTorque;

		private float calculatedSpring;

		private MagicController magicController;

		private float lastAngle;

		private int timer;

		public float currentAngle;

		public float maxAngle;

		public HingeJoint joint { get; private set; }

		public ConfigurableJoint detentJoint { get; private set; }

		public ConfigurableJoint onewayJoint { get; private set; }

		public SimShape shaftShape { get; private set; }

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

		public void SimPrePhysicsUpdate()
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
