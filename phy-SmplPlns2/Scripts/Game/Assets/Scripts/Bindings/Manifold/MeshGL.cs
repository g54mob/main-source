using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Assets.Scripts.Bindings.Manifold
{
	public class MeshGL<TVert> : MeshGLBase where TVert : unmanaged
	{
		private static readonly int _numProps;

		unsafe static MeshGL()
		{
			if (sizeof(TVert) % 4 != 0)
			{
				throw new InvalidOperationException($"MeshGL requires a vertex type constructed entirely of floats, and therefore must have a size that is a multiple of {4}");
			}
			_numProps = sizeof(TVert) / 4;
			if (_numProps < 3)
			{
				throw new InvalidOperationException("MeshGL requires the vertex type to contain at least 3 floats at the beginning for the position");
			}
		}

		private unsafe MeshGL(NativeMethods.MeshGL* ptr, Allocator allocator)
			: base(ptr, allocator)
		{
		}

		public unsafe static void* AllocNative(Allocator allocator)
		{
			return UnsafeUtility.Malloc((long)(ulong)NativeMethods.manifold_meshgl_size(), 8, allocator);
		}

		public unsafe static MeshGL<TVert> Create(Allocator allocator, NativeArray<TVert> vertices, NativeArray<uint3> triangles)
		{
			using ConstructHandle<NativeMethods.MeshGL, MeshGL<TVert>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_meshgl(constructHandle, (float*)vertices.GetUnsafeReadOnlyPtr(), (nuint)vertices.Length, (nuint)_numProps, (uint*)triangles.GetUnsafeReadOnlyPtr(), (nuint)triangles.Length));
		}

		public unsafe static MeshGL<TVert> Create(Allocator allocator, NativeArray<TVert> vertices, NativeArray<uint3> triangles, Span<Run> runs, (NativeArray<uint> From, NativeArray<uint> To)? mergeVerts = null)
		{
			using ConstructHandle<NativeMethods.MeshGL, MeshGL<TVert>> constructHandle = Construct(allocator);
			return constructHandle.Complete(CreateImpl(constructHandle, vertices, triangles, runs, mergeVerts));
		}

		public unsafe static NativeMethods.MeshGL* CreateNative(Allocator allocator, NativeArray<TVert> vertices, NativeArray<uint3> triangles, Span<Run> runs, (NativeArray<uint> From, NativeArray<uint> To)? mergeVerts = null)
		{
			return CreateImpl(UnsafeUtility.Malloc((long)(ulong)NativeMethods.manifold_meshgl_size(), 8, allocator), vertices, triangles, runs, mergeVerts);
		}

		public unsafe static void DestroyNative(NativeMethods.MeshGL* mesh, Allocator allocator)
		{
			NativeMethods.manifold_destruct_meshgl(mesh);
			UnsafeUtility.Free(mesh, allocator);
		}

		public unsafe static MeshGL<TVert> Create(Allocator allocator, Manifold manifold)
		{
			using ConstructHandle<NativeMethods.MeshGL, MeshGL<TVert>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_get_meshgl(constructHandle, manifold.Ptr));
		}

		public unsafe static MeshGL<TVert> Create(Allocator allocator, Manifold manifold, int normalIdx)
		{
			using ConstructHandle<NativeMethods.MeshGL, MeshGL<TVert>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_get_meshgl_w_normals(constructHandle, manifold.Ptr, normalIdx));
		}

		public unsafe MeshGL<TVert> Merge(Allocator allocator)
		{
			using ConstructHandle<NativeMethods.MeshGL, MeshGL<TVert>> constructHandle = Construct(allocator);
			NativeMethods.MeshGL* ptr = NativeMethods.manifold_meshgl_merge(constructHandle, base.Ptr);
			if (ptr == base.Ptr)
			{
				return this;
			}
			return constructHandle.Complete(ptr);
		}

		public unsafe void GetVertices(NativeArray<TVert> dest)
		{
			GetVertices(dest.GetUnsafePtr());
		}

		internal unsafe static ConstructHandle<NativeMethods.MeshGL, MeshGL<TVert>> Construct(Allocator allocator)
		{
			return new ConstructHandle<NativeMethods.MeshGL, MeshGL<TVert>>(MeshGLBase._size, allocator, (IntPtr p, Allocator allocator2) => new MeshGL<TVert>((NativeMethods.MeshGL*)(void*)p, allocator2));
		}

		protected unsafe override void Destruct()
		{
			NativeMethods.manifold_destruct_meshgl(base.Ptr);
		}

		private unsafe static NativeMethods.MeshGL* CreateImpl(void* storage, NativeArray<TVert> vertices, NativeArray<uint3> triangles, Span<Run> runs, (NativeArray<uint> From, NativeArray<uint> To)? mergeVerts)
		{
			NativeMethods.MeshGLOptions meshGLOptions = default(NativeMethods.MeshGLOptions);
			if (runs.Length > 0)
			{
				uint* ptr = (meshGLOptions.run_original_ids = stackalloc uint[runs.Length]);
				meshGLOptions.run_original_ids_length = (nuint)runs.Length;
				uint* ptr2 = (meshGLOptions.run_indices = stackalloc uint[runs.Length + 1]);
				meshGLOptions.run_indices_length = (nuint)runs.Length + (nuint)1u;
				for (int i = 0; i < runs.Length; i++)
				{
					ptr[i] = runs[i].OriginalID;
					ptr2[i] = runs[i].StartIndex;
				}
				ptr2[runs.Length] = runs[runs.Length - 1].EndIndex;
			}
			if (mergeVerts.HasValue)
			{
				(NativeArray<uint> From, NativeArray<uint> To) value = mergeVerts.Value;
				NativeArray<uint> item = value.From;
				NativeArray<uint> item2 = value.To;
				meshGLOptions.merge_from_vert = (uint*)item.GetUnsafePtr();
				meshGLOptions.merge_to_vert = (uint*)item2.GetUnsafePtr();
				meshGLOptions.merge_verts_length = (nuint)Math.Min(item.Length, item2.Length);
			}
			return NativeMethods.manifold_meshgl_w_options(storage, (float*)vertices.GetUnsafeReadOnlyPtr(), (nuint)vertices.Length, (nuint)_numProps, (uint*)triangles.GetUnsafeReadOnlyPtr(), (nuint)triangles.Length, &meshGLOptions);
		}
	}
}
