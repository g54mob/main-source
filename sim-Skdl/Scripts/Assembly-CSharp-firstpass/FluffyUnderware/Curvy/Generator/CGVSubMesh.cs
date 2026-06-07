using System;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	public class CGVSubMesh : CGData
	{
		public Material Material;

		private SubArray<int> triangles;

		public SubArray<int> TrianglesList
		{
			get
			{
				return default(SubArray<int>);
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use TrianglesList instead")]
		public int[] Triangles
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override int Count => 0;

		public CGVSubMesh(Material material = null)
		{
		}

		public CGVSubMesh(int[] triangles, Material material = null)
		{
		}

		public CGVSubMesh(SubArray<int> triangles, Material material = null)
		{
		}

		public CGVSubMesh(int triangleCount, Material material = null)
		{
		}

		public CGVSubMesh(CGVSubMesh source)
		{
		}

		protected override bool Dispose(bool disposing)
		{
			return false;
		}

		public override T Clone<T>()
		{
			return null;
		}

		public static CGVSubMesh Get(CGVSubMesh data, int triangleCount, Material material = null)
		{
			return null;
		}

		public void ShiftIndices(int offset, int startIndex = 0)
		{
		}

		public void Add(CGVSubMesh other, int shiftIndexOffset = 0)
		{
		}
	}
}
