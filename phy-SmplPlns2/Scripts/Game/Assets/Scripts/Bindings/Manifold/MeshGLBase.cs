using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Assets.Scripts.Bindings.Manifold
{
	public abstract class MeshGLBase : WrapperBase<NativeMethods.MeshGL>
	{
		public struct Run
		{
			public uint StartIndex;

			public uint EndIndex;

			public uint OriginalID;
		}

		protected static readonly long _size = (long)(ulong)NativeMethods.manifold_meshgl_size();

		public unsafe nuint FaceIdLength => NativeMethods.manifold_meshgl_face_id_length(base.Ptr);

		public unsafe nuint MergeLength => NativeMethods.manifold_meshgl_merge_length(base.Ptr);

		public unsafe nuint NumProp => NativeMethods.manifold_meshgl_num_prop(base.Ptr);

		public unsafe nuint NumTri => NativeMethods.manifold_meshgl_num_tri(base.Ptr);

		public unsafe nuint NumVert => NativeMethods.manifold_meshgl_num_vert(base.Ptr);

		public unsafe nuint RunIndexLength => NativeMethods.manifold_meshgl_run_index_length(base.Ptr);

		public unsafe nuint RunOriginalIdLength => NativeMethods.manifold_meshgl_run_original_id_length(base.Ptr);

		public unsafe nuint RunTransformLength => NativeMethods.manifold_meshgl_run_transform_length(base.Ptr);

		public unsafe nuint TangentLength => NativeMethods.manifold_meshgl_tangent_length(base.Ptr);

		public unsafe nuint IndexCount => NativeMethods.manifold_meshgl_tri_length(base.Ptr);

		public unsafe nuint VertPropertiesLength => NativeMethods.manifold_meshgl_vert_properties_length(base.Ptr);

		protected unsafe MeshGLBase(NativeMethods.MeshGL* ptr, Allocator allocator)
			: base(ptr, allocator)
		{
		}

		public unsafe void GetVertices(void* dest)
		{
			NativeMethods.manifold_meshgl_vert_properties(dest, base.Ptr);
		}

		public unsafe void GetIndices(NativeArray<uint> dest)
		{
			NativeMethods.manifold_meshgl_tri_verts(dest.GetUnsafePtr(), base.Ptr);
		}

		public unsafe void GetRunIndices(NativeArray<int> dest)
		{
			NativeMethods.manifold_meshgl_run_index(dest.GetUnsafePtr(), base.Ptr);
		}

		public unsafe void GetRunOriginalIndices(NativeArray<int> dest)
		{
			NativeMethods.manifold_meshgl_run_original_id(dest.GetUnsafePtr(), base.Ptr);
		}

		public int GetRunDataLength()
		{
			return (int)RunOriginalIdLength;
		}

		public unsafe int GetRunData(Span<Run> dest)
		{
			int num = (int)RunOriginalIdLength;
			int num2 = (int)RunIndexLength;
			if (num2 < num || num > dest.Length)
			{
				return -1;
			}
			uint* ptr = stackalloc uint[num];
			uint* ptr2 = stackalloc uint[num2];
			NativeMethods.manifold_meshgl_run_original_id(ptr, base.Ptr);
			NativeMethods.manifold_meshgl_run_index(ptr2, base.Ptr);
			for (int i = 0; i < num; i++)
			{
				dest[i] = new Run
				{
					StartIndex = ptr2[i],
					EndIndex = (uint)((i + 1 == num2) ? IndexCount : ptr2[i + 1]),
					OriginalID = ptr[i]
				};
			}
			return num;
		}
	}
}
