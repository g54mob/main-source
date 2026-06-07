using System;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Quads
{
	[Serializable]
	public struct Vert
	{
		[SerializeField]
		public int2 hexPos;

		[SerializeField]
		public float2 planePos;

		[SerializeField]
		public Quad q0;

		[SerializeField]
		public Quad q1;

		[SerializeField]
		public Quad q2;

		[SerializeField]
		public Quad q3;

		[SerializeField]
		public Quad q4;

		[SerializeField]
		public Quad q5;

		[SerializeField]
		public sbyte quadCount;

		[SerializeField]
		public float angle;

		public float3 worldPos => default(float3);

		public bool full => false;

		public bool validPosition => false;

		public void AddQuad(Quad quad)
		{
		}

		public void SetQuad(int index, Quad quad)
		{
		}

		public Quad GetQuad(int index)
		{
			return default(Quad);
		}

		public bool ContainsVert(int2 v)
		{
			return false;
		}
	}
}
