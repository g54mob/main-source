using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffectInternal
{
	internal static class MeshExtensions
	{
		internal static readonly InternalObjectPool<Mesh> s_MeshPool;

		public static Mesh Rent()
		{
			return null;
		}

		public static void Return(ref Mesh mesh)
		{
		}

		public static void CopyTo(this Mesh self, Mesh dst)
		{
		}

		public static void CopyTo(this Mesh self, VertexHelper dst)
		{
		}

		public static void CopyTo(this Mesh self, VertexHelper dst, int vertexCount, int indexCount)
		{
		}

		private static T GetOrDefault<T>(this List<T> self, int index)
		{
			return default(T);
		}
	}
}
