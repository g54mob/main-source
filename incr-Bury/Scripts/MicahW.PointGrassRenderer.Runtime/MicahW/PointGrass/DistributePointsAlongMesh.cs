using UnityEngine;

namespace MicahW.PointGrass
{
	public static class DistributePointsAlongMesh
	{
		public static PointGrassCommon.MeshPoint[] DistributePoints(PointGrassCommon.MeshData mesh, Vector3 scale, float pointCount, int seed, bool multiplyPointsByArea, Vector3? forcedNormal, bool useColours, bool useDensity, bool useLength, float densityCutoff, Vector2 lengthMapping)
		{
			if (pointCount <= 0f)
			{
				return null;
			}
			if (densityCutoff >= 1f)
			{
				return null;
			}
			useDensity &= mesh.HasAttributes;
			useLength &= mesh.HasAttributes;
			useColours &= mesh.HasColours;
			if (useDensity)
			{
				mesh.ApplyDensityCutoff(densityCutoff);
			}
			if (useLength)
			{
				mesh.ApplyLengthMapping(lengthMapping);
			}
			float totalArea;
			float[] cumulativeTriSizes = GetCumulativeTriSizes(mesh.tris, mesh.verts, mesh.attributes, scale, useDensity, out totalArea);
			int num = (multiplyPointsByArea ? Mathf.FloorToInt(pointCount * totalArea) : Mathf.FloorToInt(pointCount));
			if (num <= 0 || totalArea <= 0f)
			{
				return null;
			}
			return DistributePoints_CPU(mesh, cumulativeTriSizes, num, seed, totalArea, forcedNormal, useColours, useLength);
		}

		private static PointGrassCommon.MeshPoint[] DistributePoints_CPU(PointGrassCommon.MeshData mesh, float[] cumulativeSizes, int pointCount, int seed, float totalArea, Vector3? forcedNormal, bool useColours, bool useLength)
		{
			Random.State state = Random.state;
			Random.InitState(seed);
			PointGrassCommon.MeshPoint[] array = new PointGrassCommon.MeshPoint[pointCount];
			for (int i = 0; i < pointCount; i++)
			{
				float randomSample = Random.Range(0f, totalArea);
				int num = FindTriangleIndex(cumulativeSizes, randomSample);
				int num2 = num + 1;
				int num3 = num + 2;
				num = mesh.tris[num];
				num2 = mesh.tris[num2];
				num3 = mesh.tris[num3];
				Vector3 vector = new Vector3(Random.value, Random.value, 0f);
				if (vector.x + vector.y >= 1f)
				{
					vector.x = 1f - vector.x;
					vector.y = 1f - vector.y;
				}
				vector.z = 1f - vector.x - vector.y;
				PointGrassCommon.MeshPoint meshPoint = default(PointGrassCommon.MeshPoint);
				Vector3 vector2 = mesh.verts[num];
				Vector3 vector3 = mesh.verts[num2];
				Vector3 vector4 = mesh.verts[num3];
				meshPoint.position = vector2 * vector.x + vector3 * vector.y + vector4 * vector.z;
				if (!forcedNormal.HasValue)
				{
					Vector3 vector5 = mesh.normals[num];
					Vector3 vector6 = mesh.normals[num2];
					Vector3 vector7 = mesh.normals[num3];
					meshPoint.normal = vector5 * vector.x + vector6 * vector.y + vector7 * vector.z;
				}
				else
				{
					meshPoint.normal = forcedNormal.Value;
				}
				Vector2 vector8 = mesh.UVs[num];
				Vector2 vector9 = mesh.UVs[num2];
				Vector2 vector10 = mesh.UVs[num3];
				meshPoint.extraData = vector8 * vector.x + vector9 * vector.y + vector10 * vector.z;
				if (useColours)
				{
					Color color = mesh.colours[num];
					Color color2 = mesh.colours[num2];
					Color color3 = mesh.colours[num3];
					meshPoint.color = color * vector.x + color2 * vector.y + color3 * vector.z;
				}
				else
				{
					meshPoint.color = Color.white;
				}
				if (useLength)
				{
					float y = mesh.attributes[num].y;
					float y2 = mesh.attributes[num2].y;
					float y3 = mesh.attributes[num3].y;
					meshPoint.extraData.z = y * vector.x + y2 * vector.y + y3 * vector.z;
				}
				else
				{
					meshPoint.extraData.z = 1f;
				}
				meshPoint.extraData.w = Random.value;
				array[i] = meshPoint;
			}
			Random.state = state;
			return array;
		}

		private static float[] GetCumulativeTriSizes(int[] tris, Vector3[] verts, Vector2[] attributes, Vector3 scale, bool useDensity, out float totalArea)
		{
			useDensity &= attributes != null && attributes.Length == verts.Length;
			float[] array = (useDensity ? GetWeightedTriSizes(tris, verts, attributes, scale) : GetTriSizes(tris, verts, scale));
			if (array == null || array.Length == 0)
			{
				totalArea = 0f;
				return null;
			}
			totalArea = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				totalArea += array[i];
				array[i] = totalArea;
			}
			return array;
		}

		private static float[] GetTriSizes(int[] tris, Vector3[] verts, Vector3 scale)
		{
			int num = tris.Length / 3;
			float[] array = new float[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = tris[i * 3 + 1];
				int num3 = tris[i * 3];
				int num4 = tris[i * 3 + 2];
				Vector3 lhs = verts[num2] - verts[num3];
				lhs.Scale(scale);
				Vector3 rhs = verts[num4] - verts[num3];
				rhs.Scale(scale);
				array[i] = 0.5f * Vector3.Cross(lhs, rhs).magnitude;
			}
			return array;
		}

		private static float[] GetWeightedTriSizes(int[] tris, Vector3[] verts, Vector2[] attributes, Vector3 scale)
		{
			int num = tris.Length / 3;
			float[] array = new float[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = tris[i * 3 + 1];
				int num3 = tris[i * 3];
				int num4 = tris[i * 3 + 2];
				float num5 = (attributes[num2].x + attributes[num3].x + attributes[num4].x) / 3f;
				Vector3 lhs = verts[num2] - verts[num3];
				lhs.Scale(scale);
				Vector3 rhs = verts[num4] - verts[num3];
				rhs.Scale(scale);
				array[i] = num5 * 0.5f * Vector3.Cross(lhs, rhs).magnitude;
			}
			return array;
		}

		private static int FindTriangleIndex(float[] cumulativeTriSizes, float randomSample)
		{
			int num = 0;
			int num2 = cumulativeTriSizes.Length - 1;
			while (num < num2)
			{
				int num3 = (num + num2) / 2;
				if (cumulativeTriSizes[num3] > randomSample)
				{
					num2 = num3;
				}
				else
				{
					num = num3 + 1;
				}
			}
			return num * 3;
		}
	}
}
