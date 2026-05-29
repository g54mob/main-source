using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[CGDataInfo(0.98f, 0.5f, 0f, 1f)]
	public class CGVMesh : CGBounds
	{
		public CGVSubMesh[] SubMeshes;

		private SubArray<int>? sortedVertexIndices;

		private readonly object vertexIndicesLock;

		private SubArray<Vector3> vertices;

		private SubArray<Vector2> uvs;

		private SubArray<Vector2> uv2s;

		private SubArray<Vector3> normals;

		private SubArray<Vector4> tangents;

		private bool hasPartialNormals;

		private bool hasPartialTangents;

		public SubArray<Vector3> Vertices
		{
			get
			{
				return default(SubArray<Vector3>);
			}
			set
			{
			}
		}

		public SubArray<Vector2> UVs
		{
			get
			{
				return default(SubArray<Vector2>);
			}
			set
			{
			}
		}

		public SubArray<Vector2> UV2s
		{
			get
			{
				return default(SubArray<Vector2>);
			}
			set
			{
			}
		}

		public SubArray<Vector3> NormalsList
		{
			get
			{
				return default(SubArray<Vector3>);
			}
			set
			{
			}
		}

		public SubArray<Vector4> TangentsList
		{
			get
			{
				return default(SubArray<Vector4>);
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use Vertices instead")]
		public Vector3[] Vertex
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Use UVs instead")]
		[UsedImplicitly]
		public Vector2[] UV
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use UV2s instead")]
		public Vector2[] UV2
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use NormalList instead")]
		public Vector3[] Normals
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use TangentsList instead")]
		public Vector4[] Tangents
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

		public bool HasUV => false;

		public bool HasUV2 => false;

		public bool HasNormals => false;

		public bool HasPartialNormals
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool HasTangents => false;

		public bool HasPartialTangents
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public int TriangleCount => 0;

		public CGVMesh()
		{
		}

		public CGVMesh(int vertexCount, bool addUV = false, bool addUV2 = false, bool addNormals = false, bool addTangents = false)
		{
		}

		public CGVMesh(CGVolume volume)
		{
		}

		public CGVMesh(CGVolume volume, IntRegion subset)
		{
		}

		public CGVMesh(CGVMesh source)
		{
		}

		public CGVMesh([NotNull] CGMeshProperties meshProperties)
		{
		}

		public CGVMesh([NotNull] Mesh source, Material[] materials, Matrix4x4 trsMatrix)
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

		[Obsolete("Member not used by Curvy, will get removed next major version. Use another overload of this method")]
		[UsedImplicitly]
		public static CGVMesh Get(CGVMesh data, CGVolume source, bool addUV, bool reverseNormals)
		{
			return null;
		}

		[Obsolete("Member not used by Curvy, will get removed next major version. Use another overload of this method")]
		[UsedImplicitly]
		public static CGVMesh Get(CGVMesh data, CGVolume source, IntRegion subset, bool addUV, bool reverseNormals)
		{
			return null;
		}

		[NotNull]
		public static CGVMesh Get([CanBeNull] CGVMesh data, CGVolume source, IntRegion subset, bool addUV, bool addUV2, bool reverseNormals)
		{
			return null;
		}

		public void SetSubMeshCount(int count)
		{
		}

		public void AddSubMesh(CGVSubMesh submesh = null)
		{
		}

		public void MergeVMesh(CGVMesh source)
		{
		}

		public void MergeVMesh(CGVMesh source, Matrix4x4 matrix)
		{
		}

		public void MergeVMeshes(List<CGVMesh> vMeshes, int startIndex, int endIndex)
		{
		}

		private void MergeUVsNormalsAndTangents(CGVMesh source, int preMergeVertexCount)
		{
		}

		public CGVSubMesh GetMaterialSubMesh(Material mat, bool createIfMissing = true)
		{
			return null;
		}

		[UsedImplicitly]
		[Obsolete("Use ToMesh instead")]
		public Mesh AsMesh()
		{
			return null;
		}

		public void ToMesh(ref Mesh mesh, bool includeNormals = true, bool includeTangents = true)
		{
		}

		public Material[] GetMaterials()
		{
			return null;
		}

		public override void RecalculateBounds()
		{
		}

		[Obsolete("Method will get remove in next major update. Copy its content if you need it")]
		[UsedImplicitly]
		public void RecalculateUV2()
		{
		}

		public void TRS(Matrix4x4 matrix)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OnVerticesChanged()
		{
		}

		public SubArray<int> GetCachedSortedVertexIndices()
		{
			return default(SubArray<int>);
		}

		private void ClearCachedSortedVertexIndices()
		{
		}
	}
}
