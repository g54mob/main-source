using System;
using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	public abstract class PartSim : PoolObject
	{
		public SimShape[] shapes;

		private Vector3[] shapePositions;

		private Quaternion[] shapeRotations;

		public Part part { get; private set; }

		public ProjectSim project { get; private set; }

		public SimShape firstShape => null;

		public SimShape secondShape => null;

		public SimShape thirdShape => null;

		public abstract Type GetPartType();

		protected virtual void Setup()
		{
		}

		protected virtual void Begin()
		{
		}

		protected virtual void BodiesReady()
		{
		}

		protected virtual void End()
		{
		}

		protected override void OnCreated()
		{
		}

		protected override void OnSpawned()
		{
		}

		public void _Setup(ProjectSim project, Part part)
		{
		}

		public virtual void FreezeTransform()
		{
		}

		public void _Begin()
		{
		}

		public void _BodiesReady()
		{
		}

		public void _End()
		{
		}
	}
	public abstract class PartSim<TPart> : PartSim where TPart : Part
	{
		public new TPart part => null;

		public override Type GetPartType()
		{
			return null;
		}
	}
}
