using System;
using System.Collections.Generic;
using Polarith.AI.Criteria;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class SpatialSensor : Sensor
	{
		private struct Triangle
		{
			public int v0;

			public int v1;

			public int v2;

			public Triangle(int v0, int v1, int v2)
			{
				this.v0 = v0;
				this.v1 = v1;
				this.v2 = v2;
			}
		}

		public override Sensor Clone
		{
			get
			{
				SpatialSensor spatialSensor = new SpatialSensor();
				spatialSensor.receptors = new List<Receptor>();
				for (int i = 0; i < receptors.Count; i++)
				{
					spatialSensor.receptors.Add(receptors[i].Clone);
				}
				return spatialSensor;
			}
		}

		public override Quaternion Rotation => Quaternion.identity;

		public override Quaternion InverseRotation => Quaternion.identity;

		public override VectorProjectionType ProjectionMode => VectorProjectionType.None;

		public static SpatialSensor CreateUvSphere(int segments, int rings, float radius)
		{
			SpatialSensor spatialSensor = new SpatialSensor();
			Vector3[] array = new Vector3[segments * rings + 2];
			List<Triangle> list = new List<Triangle>();
			Quaternion quaternion = Quaternion.Euler(90f, 0f, 0f);
			float num = (float)Math.PI;
			float num2 = (float)Math.PI * 2f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			for (int i = 0; i < rings; i++)
			{
				float f = num * (float)(i + 1) / (float)(rings + 1);
				num3 = Mathf.Sin(f);
				num5 = Mathf.Cos(f);
				for (int j = 0; j < segments; j++)
				{
					float f2 = num2 * (float)((j != segments) ? j : 0) / (float)segments;
					num4 = Mathf.Sin(f2);
					num6 = Mathf.Cos(f2);
					array[j + i * segments + 1] = quaternion * new Vector3(num3 * num6, num5, num3 * num4);
				}
			}
			array[0] = new Vector3(0f, 0f, 1f);
			array[^1] = new Vector3(0f, 0f, -1f);
			for (int k = 0; k < array.Length; k++)
			{
				spatialSensor.AddReceptor().Structure.Direction = array[k];
			}
			for (int l = 0; l < segments - 1; l++)
			{
				list.Add(new Triangle(l + 2, l + 1, 0));
			}
			list.Add(new Triangle(segments, 1, 0));
			int num7 = 0;
			for (int m = 0; m < rings - 1; m++)
			{
				for (int n = 0; n < segments; n++)
				{
					int num8 = n + m * segments + 1;
					int num9 = num8 + segments;
					if (n == 0)
					{
						num7 = num8;
					}
					if (n == segments - 1)
					{
						list.Add(new Triangle(num8, num8 + 1, num7));
						list.Add(new Triangle(num8, num7 + segments, num9));
					}
					else
					{
						list.Add(new Triangle(num8, num8 + 1, num9 + 1));
						list.Add(new Triangle(num8, num9 + 1, num9));
					}
				}
			}
			for (int num10 = 0; num10 < segments - 1; num10++)
			{
				list.Add(new Triangle(array.Length - 1, array.Length - (num10 + 2) - 1, array.Length - (num10 + 1) - 1));
			}
			list.Add(new Triangle(array.Length - 1, array.Length - segments - 1, array.Length - 2));
			BuildAdjacency(spatialSensor, list);
			for (int num11 = 0; num11 < spatialSensor.ReceptorCount; num11++)
			{
				spatialSensor.receptors[num11].Structure.Position = spatialSensor.receptors[num11].Structure.Direction * radius;
			}
			return spatialSensor;
		}

		public static SpatialSensor CreateIcoSphere(int subdivisions, float radius)
		{
			SpatialSensor spatialSensor = new SpatialSensor();
			Dictionary<long, int> vertexCache = new Dictionary<long, int>();
			List<Triangle> list = new List<Triangle>();
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(0f, 0f, 1f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(0.89442f, 0f, 0.44721f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(0.27639f, 0.85064f, 0.44721f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(0.27639f, -0.85064f, 0.44721f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(-0.7236f, 0.52572f, 0.44721f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(-0.7236f, -0.52572f, 0.44721f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(0f, 0f, -1f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(-0.89442f, 0f, -0.44721f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(-0.27639f, 0.85064f, -0.44721f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(-0.27639f, -0.85064f, -0.44721f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(0.7236f, -0.52572f, -0.44721f).normalized;
			spatialSensor.AddReceptor().Structure.Direction = new Vector3(0.7236f, 0.52572f, -0.44721f).normalized;
			list.Add(new Triangle(0, 1, 2));
			list.Add(new Triangle(0, 2, 4));
			list.Add(new Triangle(0, 4, 5));
			list.Add(new Triangle(0, 5, 3));
			list.Add(new Triangle(0, 3, 1));
			list.Add(new Triangle(6, 7, 8));
			list.Add(new Triangle(6, 8, 11));
			list.Add(new Triangle(6, 11, 10));
			list.Add(new Triangle(6, 10, 9));
			list.Add(new Triangle(6, 9, 7));
			list.Add(new Triangle(1, 10, 11));
			list.Add(new Triangle(1, 3, 10));
			list.Add(new Triangle(3, 10, 9));
			list.Add(new Triangle(3, 5, 9));
			list.Add(new Triangle(5, 9, 7));
			list.Add(new Triangle(5, 7, 4));
			list.Add(new Triangle(4, 7, 8));
			list.Add(new Triangle(4, 8, 2));
			list.Add(new Triangle(2, 8, 11));
			list.Add(new Triangle(2, 11, 1));
			for (int i = 0; i < subdivisions; i++)
			{
				List<Triangle> list2 = new List<Triangle>();
				for (int j = 0; j < list.Count; j++)
				{
					int num = CalcMiddlePoint(vertexCache, spatialSensor, list[j].v0, list[j].v1);
					int num2 = CalcMiddlePoint(vertexCache, spatialSensor, list[j].v1, list[j].v2);
					int num3 = CalcMiddlePoint(vertexCache, spatialSensor, list[j].v2, list[j].v0);
					list2.Add(new Triangle(list[j].v0, num, num3));
					list2.Add(new Triangle(list[j].v1, num2, num));
					list2.Add(new Triangle(list[j].v2, num3, num2));
					list2.Add(new Triangle(num, num2, num3));
				}
				list = list2;
			}
			for (int k = 0; k < spatialSensor.ReceptorCount; k++)
			{
				spatialSensor.receptors[k].Structure.Position = spatialSensor.receptors[k].Structure.Direction * radius;
			}
			BuildAdjacency(spatialSensor, list);
			return spatialSensor;
		}

		private static int CalcMiddlePoint(Dictionary<long, int> vertexCache, Sensor sensor, int p1, int p2)
		{
			int value = 0;
			bool num = p1 < p2;
			long num2 = (num ? p1 : p2);
			long num3 = (num ? p2 : p1);
			long key = (num2 << 32) + num3;
			if (vertexCache.TryGetValue(key, out value))
			{
				return value;
			}
			value = InterpolateReceptor(sensor, sensor.GetReceptor(p1).Structure.Direction, sensor.GetReceptor(p2).Structure.Direction);
			vertexCache.Add(key, value);
			return value;
		}

		private static int InterpolateReceptor(Sensor sensor, Vector3 dir1, Vector3 dir2)
		{
			int receptorCount = sensor.ReceptorCount;
			IReceptor<Structure> receptor = sensor.AddReceptor();
			receptor.Structure.Position = Vector3.zero;
			receptor.Structure.Direction = (0.5f * dir1 + 0.5f * dir2).normalized;
			return receptorCount;
		}

		private static void BuildAdjacency(Sensor sensor, List<Triangle> tris)
		{
			for (int i = 0; i < tris.Count; i++)
			{
				IReceptor<Structure> receptor = sensor.GetReceptor(tris[i].v0);
				if (!receptor.NeighbourIDs.Contains(tris[i].v1))
				{
					receptor.NeighbourIDs.Add(tris[i].v1);
				}
				if (!receptor.NeighbourIDs.Contains(tris[i].v2))
				{
					receptor.NeighbourIDs.Add(tris[i].v2);
				}
				receptor = sensor.GetReceptor(tris[i].v1);
				if (!receptor.NeighbourIDs.Contains(tris[i].v0))
				{
					receptor.NeighbourIDs.Add(tris[i].v0);
				}
				if (!receptor.NeighbourIDs.Contains(tris[i].v2))
				{
					receptor.NeighbourIDs.Add(tris[i].v2);
				}
				receptor = sensor.GetReceptor(tris[i].v2);
				if (!receptor.NeighbourIDs.Contains(tris[i].v0))
				{
					receptor.NeighbourIDs.Add(tris[i].v0);
				}
				if (!receptor.NeighbourIDs.Contains(tris[i].v1))
				{
					receptor.NeighbourIDs.Add(tris[i].v1);
				}
			}
		}
	}
}
