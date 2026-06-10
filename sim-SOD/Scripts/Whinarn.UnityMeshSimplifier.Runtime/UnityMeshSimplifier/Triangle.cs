using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityMeshSimplifier
{
	public class Triangle : IEquatable<Triangle>
	{
		public int index;

		public int v0;

		public int v1;

		public int v2;

		public int subMeshIndex;

		public int va0;

		public int va1;

		public int va2;

		public double err0;

		public double err1;

		public double err2;

		public double err3;

		public bool deleted;

		public bool dirty;

		public Ref refCached;

		public Vector3d n;

		public Vector3d nCached;

		public HashSet<ToleranceSphere> enclosingSpheres;

		public int this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return 0;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Triangle(int index, int v0, int v1, int v2, int subMeshIndex)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void GetAttributeIndices(int[] attributeIndices)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetAttributeIndex(int index, int value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetAttributeIndex(int index)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void GetErrors(double[] err)
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Triangle other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
