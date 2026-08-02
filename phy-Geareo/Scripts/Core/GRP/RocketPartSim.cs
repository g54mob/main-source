using System;
using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	public class RocketPartSim : PartSim<RocketPart>, ISimPrePhysicsUpdate, ISimPhysicsUpdate
	{
		public PoolObject cylinderBodyPrefab;

		public PoolObject boxBodyPrefab;

		public Transform bottomVisual;

		public ParticleSystem particle;

		public HubReceiver receiver;

		public GuidePointable guidePointable;

		public CylinderShape bodyCylinderShape;

		public BoxShape bodyBoxShape;

		public CustomShape bodyShape;

		public Renderer fireRenderer;

		public float thrust;

		public Color fireColor;

		public float fireIntensity;

		private PoolObject shapeObject;

		private ISizedVisual shapeVisual;

		private float calculatedThrust;

		private float thrustInput;

		private float rateOverTime;

		private float rateOverDistance;

		private MagicController magicController;

		private MaterialPropertyBlock fireMaterialBlock;

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

		public void SimPrePhysicsUpdate()
		{
		}

		public void SimPhysicsUpdate()
		{
		}
	}
}
