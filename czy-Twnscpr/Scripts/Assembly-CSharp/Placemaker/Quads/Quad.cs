using System;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Quads
{
	[Serializable]
	public struct Quad
	{
		[SerializeField]
		public byte quadIndex;

		[SerializeField]
		public int2 v0;

		[SerializeField]
		public int2 v1;

		[SerializeField]
		public int2 v2;

		[SerializeField]
		public int2 v3;

		[SerializeField]
		public float2 p0;

		[SerializeField]
		public float2 p1;

		[SerializeField]
		public float2 p2;

		[SerializeField]
		public float2 p3;

		public int2 hexPosSum => default(int2);

		public float2 planePos => default(float2);

		public int2 GetVert(int index)
		{
			return default(int2);
		}

		public float2 GetPlanePos(int index)
		{
			return default(float2);
		}

		public bool ContainsVert(int2 v)
		{
			return false;
		}

		public bool IsValid()
		{
			return false;
		}

		public void Rotate()
		{
		}

		public void Rotate2()
		{
		}

		public void Rotate3()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
