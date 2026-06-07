using System;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Graphs
{
	[Serializable]
	public class Square : MonoBehaviour
	{
		[Serializable]
		public struct Relation
		{
			public Square square;

			public sbyte indexInOther;

			public static readonly Relation empty;

			public Relation(Square qube, sbyte indexInOther)
			{
				square = null;
				this.indexInOther = 0;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		public Relation q0;

		public Relation q1;

		public Relation q2;

		public Relation q3;

		public Corner c0;

		public Corner c1;

		public Corner c2;

		public Corner c3;

		public Matrix4x4 m0;

		public Matrix4x4 m1;

		public Matrix4x4 m2;

		public Matrix4x4 m3;

		public byte motivations;

		public byte quadIndex;

		public int3 bitQuadId => default(int3);

		public Corner GetCorner(sbyte index)
		{
			return null;
		}

		public void SetCorner(sbyte index, Corner value)
		{
		}

		public Relation GetRelation(sbyte index)
		{
			return default(Relation);
		}

		public void SetRelation(sbyte index, sbyte indexInOther, Square value)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
