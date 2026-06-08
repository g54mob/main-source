using System;
using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class GluePartSim : PartSim<GluePart>
	{
		public Transform body;

		public Collider col;

		private List<SimShape> myShapes;

		public override Type GetPartType()
		{
			return null;
		}

		protected override void Setup()
		{
		}

		protected override void Begin()
		{
		}

		protected override void BodiesReady()
		{
		}
	}
}
