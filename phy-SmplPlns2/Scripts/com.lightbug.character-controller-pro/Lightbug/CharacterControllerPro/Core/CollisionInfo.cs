using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	public class CollisionInfo
	{
		public HitInfo hitInfo;

		public Vector3 displacement;

		public float contactSlopeAngle;

		public bool isAnEdge;

		public bool isAStep;

		public Vector3 edgeUpperNormal;

		public Vector3 edgeLowerNormal;

		public float edgeUpperSlopeAngle;

		public float edgeLowerSlopeAngle;

		public float edgeAngle;

		public void Reset()
		{
			hitInfo = default(HitInfo);
			displacement = default(Vector3);
			contactSlopeAngle = 0f;
			edgeUpperNormal = default(Vector3);
			edgeLowerNormal = default(Vector3);
			edgeUpperSlopeAngle = 0f;
			edgeLowerSlopeAngle = 0f;
			edgeAngle = 0f;
			isAnEdge = false;
			isAStep = false;
		}

		public void SetData(in HitInfo hitInfo, Vector3 upDirection, Vector3 displacement)
		{
			this.hitInfo = hitInfo;
			this.displacement = displacement;
			contactSlopeAngle = Vector3.Angle(upDirection, hitInfo.normal);
		}

		public void SetData(in HitInfo hitInfo, Vector3 upDirection, Vector3 displacement, in HitInfo upperHitInfo, in HitInfo lowerHitInfo)
		{
			SetData(in hitInfo, upDirection, displacement);
			edgeUpperNormal = upperHitInfo.normal;
			edgeLowerNormal = lowerHitInfo.normal;
			edgeUpperSlopeAngle = Vector3.Angle(edgeUpperNormal, upDirection);
			edgeLowerSlopeAngle = Vector3.Angle(edgeLowerNormal, upDirection);
			edgeAngle = Vector3.Angle(edgeUpperNormal, edgeLowerNormal);
			isAnEdge = CustomUtilities.isBetween(edgeAngle, 0.5f, 170f, inclusive: true);
			isAStep = CustomUtilities.isBetween(edgeAngle, 85f, 95f, inclusive: true);
		}
	}
}
