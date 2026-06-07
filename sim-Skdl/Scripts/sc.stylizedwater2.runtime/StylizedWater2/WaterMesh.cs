using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace StylizedWater2
{
	[Serializable]
	public class WaterMesh
	{
		public enum Shape
		{
			Rectangle = 0,
			Disk = 1
		}

		public Shape shape;

		[Range(10f, 1000f)]
		[FormerlySerializedAs("size")]
		public float scale;

		[Tooltip("Distance between vertices")]
		[Range(0.15f, 10f)]
		public float vertexDistance;

		public float UVTiling;

		[Tooltip("Shifts the vertices in a random direction. Definitely use this when using flat shading")]
		[Range(0f, 1f)]
		public float noise;

		[Min(0f)]
		[Tooltip("The surface is normally flat, yet vertex displacement on the GPU such as waves can give the surface artificial height.\n\nThis can cause a Mesh Renderer to be prematurely culled, despite still actually being visible.\n\nThis value adds an artificial amount of height to the generate mesh's bounds, to avoid this from happening.")]
		public float boundsPadding;

		public Mesh mesh;

		private static Vector4 defaultTangent;

		public Mesh Rebuild()
		{
			return null;
		}

		public static Mesh Create(Shape shape, float size, float vertexDistance, float uvTiling = 1f, float noise = 0f)
		{
			return null;
		}

		private int GetPointIndex(int c, int x)
		{
			return 0;
		}

		private Mesh CreateCircle()
		{
			return null;
		}

		private Mesh CreatePlane()
		{
			return null;
		}
	}
}
