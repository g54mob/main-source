using UnityEngine;

namespace Assets.ThirdParty.SplineTools
{
	public class ProximityMeshBender : BaseMeshBender
	{
		public float ScaleY;

		public Spline ReferenceSpline;

		public override void Update()
		{
			if (base.transform.hasChanged)
			{
				ToUpdate = true;
			}
			if (ToUpdate)
			{
				base.transform.hasChanged = false;
				ToUpdate = false;
				if (ReferenceSpline != null)
				{
					float closestPosition = GetClosestPosition();
					Vector3 vector = ReferenceSpline.GetLocationAlongSplineAtDistance(closestPosition) + ReferenceSpline.transform.position;
					Vector3 tangentAlongSplineAtDistance = ReferenceSpline.GetTangentAlongSplineAtDistance(closestPosition);
					Vector3 vector2 = base.transform.position - vector;
					float magnitude = vector2.magnitude;
					int num = ((Vector2.SignedAngle(tangentAlongSplineAtDistance, vector2) > 0f) ? 1 : (-1));
					float num2 = ((num == 1) ? (0f - Mathf.Abs(ScaleY)) : Mathf.Abs(ScaleY));
					float d = closestPosition - num2 / 2f;
					Vector3 vector3 = ReferenceSpline.GetLocationAlongSplineAtDistance(d) + ReferenceSpline.transform.position;
					Vector3 tangentAlongSplineAtDistance2 = ReferenceSpline.GetTangentAlongSplineAtDistance(d);
					float d2 = closestPosition + num2 / 2f;
					Vector3 vector4 = ReferenceSpline.GetLocationAlongSplineAtDistance(d2) + ReferenceSpline.transform.position;
					Vector3 tangentAlongSplineAtDistance3 = ReferenceSpline.GetTangentAlongSplineAtDistance(d2);
					Vector3 vector5 = Vector3.Cross(tangentAlongSplineAtDistance2, Vector3.back);
					Vector3 vector6 = Vector3.Cross(tangentAlongSplineAtDistance3, Vector3.back);
					vector5 = vector5.normalized * magnitude * num;
					vector6 = vector6.normalized * magnitude * num;
					OwnSpline.Reset();
					OwnSpline.nodes[0].SetPosition(vector3 + vector5 - base.transform.position);
					OwnSpline.nodes[1].SetPosition(vector4 + vector6 - base.transform.position);
					float num3 = (OwnSpline.nodes[0].position - OwnSpline.nodes[1].position).magnitude / (vector3 - vector4).magnitude;
					float num4 = num2 / 4f * Mathf.Sqrt(2f);
					Vector3 direction = OwnSpline.nodes[0].position + tangentAlongSplineAtDistance2.normalized * num4 * num3;
					Vector3 direction2 = OwnSpline.nodes[1].position + tangentAlongSplineAtDistance3.normalized * num4 * num3;
					OwnSpline.nodes[0].SetDirection(direction);
					OwnSpline.nodes[1].SetDirection(direction2);
				}
				if (TextureMesh != null)
				{
					CreateMesh(TextureMesh);
				}
			}
		}

		private float GetClosestPosition()
		{
			float num = float.MaxValue;
			float result = 0f;
			for (float num2 = 0f; num2 <= ReferenceSpline.Length; num2 += 10f)
			{
				Vector3 vector = ReferenceSpline.GetLocationAlongSplineAtDistance(num2) + ReferenceSpline.transform.position;
				float magnitude = (base.transform.position - vector).magnitude;
				if (magnitude < num)
				{
					num = magnitude;
					result = num2;
				}
			}
			return result;
		}
	}
}
