using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERBend : MonoBehaviour
	{
		public float roundAboutRadius = 10f;

		public float roundAboutResolution = 1f;

		public float rDist = 0f;

		public Vector3 raStartPos;

		public float roundaboutWidth = 5f;

		public float bendAngle = 90f;

		public bool meshInstance = false;

		public float roadWidth = 5f;

		public bool lockLeftRightRoundingRadius = true;

		public float leftRoundingRadius = 2f;

		public float rightRoundingRadius = 2f;

		public int roundingSegments = 5;

		public float connectionLength = 5f;

		public float maxRoadWidth = 0f;

		public float maxRoundingRadius = 0f;

		public List<Vector3> meshVecs = new List<Vector3>();

		public List<Vector3> mainRightPoints = new List<Vector3>();

		public List<Vector3> mainCenterPoints = new List<Vector3>();

		public List<Vector3> mainLeftPoints = new List<Vector3>();

		public List<Vector3> OQCDCOQDQQ = new List<Vector3>();

		public List<Vector3> splinePoints = new List<Vector3>();

		public List<Vector2> mainRightPointsUVs = new List<Vector2>();

		public List<Vector2> mainCenterPointsUVs = new List<Vector2>();

		public List<Vector2> mainLeftPointsUVs = new List<Vector2>();

		public List<Vector2> OQCDCOQDQQUVs = new List<Vector2>();

		public Vector3 leftPoint;

		public Vector3 leftPoint1;

		public Vector3 rightPoint;

		public Vector3 rightPoint1;

		public Vector3 centerOnLine;

		public Vector3 leftOuterPoint;

		public Vector3 rightOuterPoint;

		public Vector3 pl;

		public Vector3 pr;

		public List<Vector3> edgePoints = new List<Vector3>();

		public int newSegmentInt = 0;

		public List<ERRoundaboutElement> connections = new List<ERRoundaboutElement>();

		public string[] QDOOOQOOQQQQD;

		public int selectedConnection = 0;

		public int tmpSelectedConnection = 0;

		public int centerInt = 0;

		public int leftOuterInt = 0;

		public int rightOuterInt = 0;

		public List<Vector3> leftOuterSegments = new List<Vector3>();

		public List<Vector3> leftInnerSegments = new List<Vector3>();

		public List<Vector3> rightOuterSegments = new List<Vector3>();

		public List<Vector3> rightInnerSegments = new List<Vector3>();

		public List<Vector2> leftOuterSegmentsUVs = new List<Vector2>();

		public List<Vector2> leftInnerSegmentsUVs = new List<Vector2>();

		public List<Vector2> rightOuterSegmentsUVs = new List<Vector2>();

		public List<Vector2> rightInnerSegmentsUVs = new List<Vector2>();

		public Material roadMaterial;

		public List<Vector3> innerRoundaboutPoints = new List<Vector3>();

		public List<Vector2> innerRoundaboutUVs = new List<Vector2>();

		public float innerSegmentDistance = 0.5f;

		public bool leftFlag = true;

		public bool rightFlag = true;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void OQDOCODQDD()
		{
			if (base.gameObject.GetComponent<MeshFilter>() == null)
			{
				base.gameObject.AddComponent<MeshFilter>();
			}
			if (base.gameObject.GetComponent<MeshRenderer>() == null)
			{
				base.gameObject.AddComponent<MeshRenderer>();
			}
			if (base.gameObject.GetComponent<MeshCollider>() == null)
			{
				base.gameObject.AddComponent<MeshCollider>();
			}
			Mesh mesh;
			if (base.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				if (!meshInstance)
				{
					mesh = Object.Instantiate(base.gameObject.GetComponent<MeshFilter>().sharedMesh);
					base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
					base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
					meshInstance = true;
				}
				else
				{
					mesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
				}
			}
			else
			{
				mesh = new Mesh();
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
				base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
				meshInstance = true;
			}
			leftOuterSegments.Clear();
			leftInnerSegments.Clear();
			rightOuterSegments.Clear();
			rightInnerSegments.Clear();
			leftOuterSegmentsUVs.Clear();
			leftInnerSegmentsUVs.Clear();
			rightOuterSegmentsUVs.Clear();
			rightInnerSegmentsUVs.Clear();
			splinePoints.Clear();
			float num = roundAboutRadius;
			Vector3 vector = new Vector3(roadWidth * 0.5f, 0f, 0f);
			Vector3 vector2 = new Vector3(roadWidth * 0.5f - innerSegmentDistance, 0f, 0f);
			Vector3 vector3 = new Vector3(roadWidth * -0.5f, 0f, 0f);
			Vector3 vector4 = new Vector3(roadWidth * -0.5f + innerSegmentDistance, 0f, 0f);
			Vector3 pivot = vector + Vector3.right * num;
			float num2 = bendAngle / ((float)roundingSegments * 1f);
			float num3 = 0f;
			rightOuterSegments.Add(vector);
			rightInnerSegments.Add(vector2);
			leftOuterSegments.Add(vector3);
			leftInnerSegments.Add(vector4);
			splinePoints.Add(Vector3.Lerp(rightOuterSegments[0], leftOuterSegments[0], 0.5f));
			for (int i = 0; i <= roundingSegments; i++)
			{
				rightOuterSegments.Add(ERRoundabouts.OCQDOQQQOD(vector, pivot, Quaternion.Euler(0f, num3 + (float)i * num2, 0f)));
				rightInnerSegments.Add(ERRoundabouts.OCQDOQQQOD(vector2, pivot, Quaternion.Euler(0f, num3 + (float)i * num2, 0f)));
				leftOuterSegments.Add(ERRoundabouts.OCQDOQQQOD(vector3, pivot, Quaternion.Euler(0f, num3 + (float)i * num2, 0f)));
				leftInnerSegments.Add(ERRoundabouts.OCQDOQQQOD(vector4, pivot, Quaternion.Euler(0f, num3 + (float)i * num2, 0f)));
				splinePoints.Add(Vector3.Lerp(rightOuterSegments[i + 1], leftOuterSegments[i + 1], 0.5f));
			}
			float num4 = 5f;
			float num5 = 0f;
			List<float> list = new List<float>();
			list.Add(0f);
			List<Vector3> list2 = new List<Vector3>();
			for (int i = 0; i < rightOuterSegments.Count; i++)
			{
				list2.Add(leftOuterSegments[i]);
				list2.Add(rightOuterSegments[i]);
				if (i > 0)
				{
					num5 += Vector3.Distance(splinePoints[i - 1], splinePoints[i]);
					list.Add(num5);
				}
			}
			List<Vector2> list3 = new List<Vector2>();
			for (int i = 0; i < list.Count; i++)
			{
				list3.Add(new Vector2(0f, list[i] / num4));
				list3.Add(new Vector2(1f, list[i] / num4));
			}
			List<int> list4 = new List<int>();
			int count = splinePoints.Count;
			int num6 = 2;
			int num7 = 1;
			for (int j = 0; j < count - 1; j += num7)
			{
				for (int k = 0; k < num6 - 1; k++)
				{
					list4.Add(j * num6 + k);
					list4.Add((j + num7) * num6 + k + 1);
					list4.Add(j * num6 + k + 1);
					list4.Add((j + num7) * num6 + k);
					list4.Add((j + num7) * num6 + k + 1);
					list4.Add(j * num6 + k);
				}
			}
			mesh.Clear();
			mesh.vertices = list2.ToArray();
			mesh.uv = list3.ToArray();
			mesh.tangents = new Vector4[mesh.vertices.Length];
			mesh.triangles = list4.ToArray();
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
		}
	}
}
