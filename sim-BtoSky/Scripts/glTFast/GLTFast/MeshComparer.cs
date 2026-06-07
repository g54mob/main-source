using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GLTFast.Schema;

namespace GLTFast
{
	internal class MeshComparer : IEqualityComparer<MeshPrimitiveBase>, IEqualityComparer<IReadOnlyList<MeshPrimitiveBase>>
	{
		public bool Equals(IReadOnlyList<MeshPrimitiveBase> x, IReadOnlyList<MeshPrimitiveBase> y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null)
			{
				return false;
			}
			if (y == null)
			{
				return false;
			}
			if (x.Count != y.Count)
			{
				return false;
			}
			for (int i = 0; i < x.Count; i++)
			{
				if (!Equals(x[i], y[i]))
				{
					return false;
				}
			}
			return true;
		}

		public int GetHashCode(IReadOnlyList<MeshPrimitiveBase> obj)
		{
			HashCode hashCode = default(HashCode);
			foreach (MeshPrimitiveBase item in obj)
			{
				hashCode.Add(GetHashCode(item));
			}
			return hashCode.ToHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(MeshPrimitiveBase x, MeshPrimitiveBase y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null)
			{
				return false;
			}
			if (y == null)
			{
				return false;
			}
			if (x.GetType() != y.GetType())
			{
				return false;
			}
			if (x.indices == y.indices && Equals(x.attributes, y.attributes))
			{
				return Equals(x.targets, y.targets);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(MeshPrimitiveBase primitive)
		{
			return HashCode.Combine(primitive.indices, GetHashCode(primitive.attributes), GetHashCode(primitive.targets));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int GetHashCode(Attributes x)
		{
			if (x == null)
			{
				return 0;
			}
			HashCode hashCode = default(HashCode);
			hashCode.Add(x.POSITION);
			hashCode.Add(x.NORMAL);
			hashCode.Add(x.TANGENT);
			hashCode.Add(x.TEXCOORD_0);
			hashCode.Add(x.TEXCOORD_1);
			hashCode.Add(x.TEXCOORD_2);
			hashCode.Add(x.TEXCOORD_3);
			hashCode.Add(x.TEXCOORD_4);
			hashCode.Add(x.TEXCOORD_5);
			hashCode.Add(x.TEXCOORD_6);
			hashCode.Add(x.TEXCOORD_7);
			hashCode.Add(x.COLOR_0);
			hashCode.Add(x.JOINTS_0);
			hashCode.Add(x.WEIGHTS_0);
			return hashCode.ToHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int GetHashCode(MorphTarget[] x)
		{
			if (x == null)
			{
				return 0;
			}
			HashCode hashCode = default(HashCode);
			hashCode.Add(x.Length);
			foreach (MorphTarget morphTarget in x)
			{
				if (morphTarget == null)
				{
					hashCode.Add(0);
					continue;
				}
				hashCode.Add(morphTarget.POSITION);
				hashCode.Add(morphTarget.NORMAL);
				hashCode.Add(morphTarget.TANGENT);
			}
			return hashCode.ToHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool Equals(MorphTarget[] x, MorphTarget[] y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			if (x.Length != y.Length)
			{
				return false;
			}
			for (int i = 0; i < x.Length; i++)
			{
				if (!Equals(x[i], y[i]))
				{
					return false;
				}
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool Equals(MorphTarget x, MorphTarget y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			if (x.POSITION == y.POSITION && x.NORMAL == y.NORMAL)
			{
				return x.TANGENT == y.TANGENT;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool Equals(Attributes x, Attributes y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			if (x.POSITION == y.POSITION && x.NORMAL == y.NORMAL && x.TANGENT == y.TANGENT && x.TEXCOORD_0 == y.TEXCOORD_0 && x.TEXCOORD_1 == y.TEXCOORD_1 && x.TEXCOORD_2 == y.TEXCOORD_2 && x.TEXCOORD_3 == y.TEXCOORD_3 && x.TEXCOORD_4 == y.TEXCOORD_4 && x.TEXCOORD_5 == y.TEXCOORD_5 && x.TEXCOORD_6 == y.TEXCOORD_6 && x.TEXCOORD_7 == y.TEXCOORD_7 && x.COLOR_0 == y.COLOR_0 && x.JOINTS_0 == y.JOINTS_0)
			{
				return x.WEIGHTS_0 == y.WEIGHTS_0;
			}
			return false;
		}
	}
}
