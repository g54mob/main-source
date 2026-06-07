using System;
using UnityEngine;

namespace AwesomeTechnologies.Grass
{
	[Serializable]
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	public class ProceduralGrassPlane : MonoBehaviour
	{
		public enum AnchorPoint
		{
			TopLeft = 0,
			TopHalf = 1,
			TopRight = 2,
			RightHalf = 3,
			BottomRight = 4,
			BottomHalf = 5,
			BottomLeft = 6,
			LeftHalf = 7,
			Center = 8
		}

		public int widthSegments = 5;

		public int heightSegments = 4;

		public float width = 1f;

		public float height = 0.5f;

		public AnchorPoint anchor = AnchorPoint.Center;

		private Vector2 anchorOffset;

		public int Index;

		public float Offset1 = 0.3f;

		public float Offset2 = 0.15f;

		public float MinimumBendHeight = 0.25f;

		public float CurveOffset = 0.25f;

		public int LODLevel;

		public Material Material;

		public bool BakePhase;

		public bool BakeBend;

		public bool BakeAO;

		public float Phase;

		public AnimationCurve BendCurve;

		public AnimationCurve AmbientOcclusionCurve;

		public bool GenerateBackside = true;

		private void Start()
		{
		}

		private void SetAncorPoints()
		{
			switch (anchor)
			{
			case AnchorPoint.TopLeft:
				anchorOffset = new Vector2((0f - width) / 2f, height / 2f);
				break;
			case AnchorPoint.TopHalf:
				anchorOffset = new Vector2(0f, height / 2f);
				break;
			case AnchorPoint.TopRight:
				anchorOffset = new Vector2(width / 2f, height / 2f);
				break;
			case AnchorPoint.RightHalf:
				anchorOffset = new Vector2(width / 2f, 0f);
				break;
			case AnchorPoint.BottomRight:
				anchorOffset = new Vector2(width / 2f, (0f - height) / 2f);
				break;
			case AnchorPoint.BottomHalf:
				anchorOffset = new Vector2(0f, (0f - height) / 2f);
				break;
			case AnchorPoint.BottomLeft:
				anchorOffset = new Vector2((0f - width) / 2f, (0f - height) / 2f);
				break;
			case AnchorPoint.LeftHalf:
				anchorOffset = new Vector2((0f - width) / 2f, 0f);
				break;
			default:
				anchorOffset = Vector2.zero;
				break;
			}
		}

		private void ApplyPhaseAndBend(Mesh mesh, int currentLOD)
		{
			Vector3[] vertices = mesh.vertices;
			Color[] array = ((mesh.colors.Length != 0) ? mesh.colors : new Color[mesh.vertexCount]);
			byte g = byte.MaxValue;
			byte b = byte.MaxValue;
			byte r = byte.MaxValue;
			if (BakePhase)
			{
				g = (byte)(Phase * 255f);
			}
			for (int i = 0; i <= array.Length - 1; i++)
			{
				float value = (vertices[i].y + height / 2f) / height;
				value = Mathf.Clamp(value, 0f, 1f);
				if (BakeBend)
				{
					b = (byte)(Mathf.Clamp(BendCurve.Evaluate(value), 0f, 1f) * 255f);
				}
				if (BakeAO)
				{
					r = (byte)(Mathf.Clamp(AmbientOcclusionCurve.Evaluate(value), 0f, 1f) * 255f);
				}
				array[i] = new Color32(r, g, b, b);
			}
			mesh.colors = array;
		}

		public void CreateGrassPlane(int currentLOD)
		{
			SetAncorPoints();
			MeshFilter meshFilter = base.gameObject.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			Mesh mesh = meshFilter.sharedMesh;
			if (mesh == null)
			{
				mesh = new Mesh();
			}
			mesh.Clear();
			int num = widthSegments + 1;
			int num2 = heightSegments + 1;
			int num3 = widthSegments * heightSegments * 6;
			int num4 = num * num2;
			Vector3[] array = new Vector3[num4];
			Vector2[] array2 = new Vector2[num4];
			int[] array3 = new int[num3];
			Vector4[] array4 = new Vector4[num4];
			Vector4 vector = new Vector4(1f, 0f, 0f, -1f);
			int num5 = 0;
			float num6 = 1f / (float)widthSegments;
			float num7 = 1f / (float)heightSegments;
			float num8 = width / (float)widthSegments;
			float num9 = height / (float)heightSegments;
			for (float num10 = 0f; num10 < (float)num2; num10 += 1f)
			{
				for (float num11 = 0f; num11 < (float)num; num11 += 1f)
				{
					float num12 = num11 * num6;
					float b = Mathf.Lerp(Offset1, Offset2, num11 * num6);
					float num13 = Mathf.Lerp(0f, b, num10 * num7);
					if (num10 * num9 <= MinimumBendHeight)
					{
						num13 = 0f;
					}
					float num14 = 0f;
					num14 = ((!(num12 <= 0.5f)) ? Mathf.Lerp(0f, CurveOffset, num12 * 2f - 0.5f) : Mathf.Lerp(CurveOffset, 0f, num12 * 2f));
					array[num5] = new Vector3(num11 * num8 - width / 2f - anchorOffset.x, num10 * num9 - height / 2f - anchorOffset.y, num13 + num14);
					array4[num5] = vector;
					array2[num5++] = new Vector2(num11 * num6, num10 * num7);
				}
			}
			num5 = 0;
			for (int i = 0; i < heightSegments; i++)
			{
				for (int j = 0; j < widthSegments; j++)
				{
					array3[num5] = i * num + j;
					array3[num5 + 1] = (i + 1) * num + j;
					array3[num5 + 2] = i * num + j + 1;
					array3[num5 + 3] = (i + 1) * num + j;
					array3[num5 + 4] = (i + 1) * num + j + 1;
					array3[num5 + 5] = i * num + j + 1;
					num5 += 6;
				}
			}
			mesh.vertices = array;
			mesh.uv = array2;
			mesh.triangles = array3;
			mesh.tangents = array4;
			mesh.RecalculateNormals();
			if (GenerateBackside)
			{
				BuildBackside(mesh);
				mesh.RecalculateNormals();
			}
			meshFilter.sharedMesh = mesh;
			mesh.RecalculateBounds();
			MeshRenderer component = base.gameObject.GetComponent<MeshRenderer>();
			if ((bool)component)
			{
				component.sharedMaterial = Material;
			}
			if (BakePhase || BakeBend)
			{
				ApplyPhaseAndBend(mesh, currentLOD);
			}
		}

		private void BuildBackside(Mesh mesh)
		{
			Vector3[] vertices = mesh.vertices;
			Vector2[] uv = mesh.uv;
			Vector3[] normals = mesh.normals;
			int num = vertices.Length;
			Vector3[] array = new Vector3[num * 2];
			Vector2[] array2 = new Vector2[num * 2];
			Vector3[] array3 = new Vector3[num * 2];
			for (int i = 0; i < num; i++)
			{
				array[i] = (array[i + num] = vertices[i]);
				array2[i] = (array2[i + num] = uv[i]);
				array3[i] = normals[i];
				array3[i + num] = -normals[i];
			}
			int[] triangles = mesh.triangles;
			int num2 = triangles.Length;
			int[] array4 = new int[num2 * 2];
			for (int j = 0; j < num2; j += 3)
			{
				array4[j] = triangles[j];
				array4[j + 1] = triangles[j + 1];
				array4[j + 2] = triangles[j + 2];
				int num3 = j + num2;
				array4[num3] = triangles[j] + num;
				array4[num3 + 2] = triangles[j + 1] + num;
				array4[num3 + 1] = triangles[j + 2] + num;
			}
			mesh.vertices = array;
			mesh.uv = array2;
			mesh.normals = array3;
			mesh.triangles = array4;
		}
	}
}
