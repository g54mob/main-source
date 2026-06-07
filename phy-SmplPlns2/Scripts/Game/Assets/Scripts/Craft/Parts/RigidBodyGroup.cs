using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class RigidBodyGroup
	{
		public Vector3 AngularVelocity { get; set; }

		public Vector3 CenterOfMass { get; set; }

		public float Mass { get; set; }

		public List<PartData> Parts { get; private set; }

		public Vector3 Position { get; set; }

		public Vector3 Rotation { get; set; }

		public Vector3 Velocity { get; set; }

		public RigidBodyGroup()
		{
			Parts = new List<PartData>();
		}
	}
}
