using System;
using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class GearPartSim : PartSim<GearPart>, ISimPrePhysicsUpdate, ISimPhysicsUpdate
	{
		public GearVisual gearVisual;

		public CylinderShape bodyShape;

		public TaperedCylinderShape teethShape;

		public LayerMask layerMask;

		public float attachDistance;

		public Dictionary<GearPartSim, GearSimConnection> connections;

		public List<GearPartSim> neighbors;

		public BearingPartSim myHinge;

		private static Collider[] cols;

		private List<GearPartSim> newNeighbors;

		private List<GearPartSim> toAdd;

		private List<GearPartSim> toRemove;

		public override Type GetPartType()
		{
			return null;
		}

		protected override void Setup()
		{
		}

		protected override void BodiesReady()
		{
		}

		public void SimPrePhysicsUpdate()
		{
		}

		public void SimPhysicsUpdate()
		{
		}

		public static bool HasContact(GearPartSim gearA, GearPartSim gearB, out bool inverted)
		{
			inverted = default(bool);
			return false;
		}

		public static bool ContainsInBetween(Transform gear, Vector3 start, Vector3 end, Vector3 point)
		{
			return false;
		}

		public static void DrawMyLine(Vector3 point, Vector3 start, Vector3 end, float attachDistance)
		{
		}

		public static float ProjectPointToSegmentDistance(Vector3 P, Vector3 A, Vector3 B)
		{
			return 0f;
		}

		public static Vector3 ProjectPointToSegment(Vector3 P, Vector3 A, Vector3 B)
		{
			return default(Vector3);
		}

		private void OnDrawGizmos()
		{
		}
	}
}
