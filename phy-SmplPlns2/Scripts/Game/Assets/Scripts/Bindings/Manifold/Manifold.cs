using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Assets.Scripts.Bindings.Manifold
{
	public class Manifold<T> : Manifold where T : unmanaged
	{
		public unsafe static Manifold<T> Boolean(Manifold<T> a, Manifold<T> b, OpType operation, Allocator allocator)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_boolean(constructHandle, a.Ptr, b.Ptr, operation));
		}

		public unsafe static Manifold<T> Cube(Allocator allocator, double3 size, bool center)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_cube(constructHandle, size.x, size.y, size.z, center ? 1 : 0));
		}

		public unsafe static Manifold<T> Cylinder(Allocator allocator, double height, double radiusLow, double radiusHigh = -1.0, int circularSegments = 0, bool center = false)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_cylinder(constructHandle, height, radiusLow, (radiusHigh < 0.0) ? radiusLow : radiusHigh, circularSegments, center ? 1 : 0));
		}

		public unsafe static Manifold<T> Empty(Allocator allocator)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_empty(constructHandle));
		}

		public unsafe static Manifold<T> Sphere(Allocator allocator, double radius, int circularSegments = 0)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_sphere(constructHandle, radius, circularSegments));
		}

		public unsafe static Manifold<T> Tetrahedron(Allocator allocator)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_tetrahedron(constructHandle));
		}

		public unsafe Manifold<T> AsOriginal(Allocator allocator)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_as_original(constructHandle, base.Ptr));
		}

		public unsafe Manifold<T> Boolean(Allocator allocator, Manifold<T> second, OpType opType)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_boolean(constructHandle, base.Ptr, second.Ptr, opType));
		}

		public Manifold<T> Subtract(Allocator allocator, Manifold<T> other)
		{
			return Boolean(allocator, other, OpType.SUBTRACT);
		}

		public Manifold<T> Subtract(Manifold<T> other)
		{
			return Boolean(base.Allocator, other, OpType.SUBTRACT);
		}

		public Manifold<T> Add(Allocator allocator, Manifold<T> other)
		{
			return Boolean(allocator, other, OpType.ADD);
		}

		public Manifold<T> Add(Manifold<T> other)
		{
			return Boolean(base.Allocator, other, OpType.ADD);
		}

		public Manifold<T> Intersect(Allocator allocator, Manifold<T> other)
		{
			return Boolean(allocator, other, OpType.INTERSECT);
		}

		public Manifold<T> Intersect(Manifold<T> other)
		{
			return Boolean(base.Allocator, other, OpType.INTERSECT);
		}

		public unsafe Manifold<T> Copy(Allocator allocator)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_copy(constructHandle, base.Ptr));
		}

		public unsafe Manifold<T> Transform(Allocator allocator, float3x4 m)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_transform(constructHandle, base.Ptr, m.c0.x, m.c0.y, m.c0.z, m.c1.x, m.c1.y, m.c1.z, m.c2.x, m.c2.y, m.c2.z, m.c3.x, m.c3.y, m.c3.z));
		}

		public unsafe Manifold<T> Transform(Allocator allocator, float4x4 m)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_transform(constructHandle, base.Ptr, m.c0.x, m.c0.y, m.c0.z, m.c1.x, m.c1.y, m.c1.z, m.c2.x, m.c2.y, m.c2.z, m.c3.x, m.c3.y, m.c3.z));
		}

		public unsafe Manifold<T> TrimByPlane(Allocator allocator, double3 normal, double value)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_trim_by_plane(constructHandle, base.Ptr, normal.x, normal.y, normal.z, value));
		}

		public unsafe (Manifold<T> Intersection, Manifold<T> Difference) Split(Allocator allocator1, Allocator allocator2, Manifold<T> cutter)
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle = Construct(allocator1);
			using ConstructHandle<NativeMethods.Manifold, Manifold<T>> constructHandle2 = Construct(allocator2);
			NativeMethods.ManifoldPair manifoldPair = NativeMethods.manifold_split(constructHandle, constructHandle2, base.Ptr, cutter.Ptr);
			return (Intersection: constructHandle.Complete(manifoldPair.first), Difference: constructHandle2.Complete(manifoldPair.second));
		}

		internal unsafe static ConstructHandle<NativeMethods.Manifold, Manifold<T>> Construct(Allocator allocator)
		{
			return new ConstructHandle<NativeMethods.Manifold, Manifold<T>>(Manifold._size, allocator, (IntPtr p, Allocator allocator2) => new Manifold<T>((NativeMethods.Manifold*)(void*)p, allocator2));
		}

		internal unsafe Manifold(NativeMethods.Manifold* ptr, Allocator allocator)
			: base(ptr, allocator)
		{
		}
	}
	public class Manifold : WrapperBase<NativeMethods.Manifold>
	{
		protected static readonly long _size = (long)(ulong)NativeMethods.manifold_manifold_size();

		public unsafe int Genus => NativeMethods.manifold_genus(base.Ptr);

		public unsafe bool IsEmpty => NativeMethods.manifold_is_empty(base.Ptr) != 0;

		public unsafe ulong NumEdge => (ulong)NativeMethods.manifold_num_edge(base.Ptr);

		public unsafe ulong NumProp => (ulong)NativeMethods.manifold_num_prop(base.Ptr);

		public unsafe ulong NumTri => (ulong)NativeMethods.manifold_num_tri(base.Ptr);

		public unsafe ulong NumVert => (ulong)NativeMethods.manifold_num_vert(base.Ptr);

		public unsafe int OriginalID => NativeMethods.manifold_original_id(base.Ptr);

		public unsafe Error Status => NativeMethods.manifold_status(base.Ptr);

		public unsafe double SurfaceArea => NativeMethods.manifold_surface_area(base.Ptr);

		public unsafe double Volume => NativeMethods.manifold_volume(base.Ptr);

		protected unsafe Manifold(NativeMethods.Manifold* ptr, Allocator allocator)
			: base(ptr, allocator)
		{
		}

		public unsafe static void* AllocNative(Allocator allocator)
		{
			return UnsafeUtility.Malloc((long)(ulong)NativeMethods.manifold_manifold_size(), 8, allocator);
		}

		public unsafe static Manifold<TVert> Create<TVert>(Allocator allocator, MeshGL<TVert> mesh) where TVert : unmanaged
		{
			using ConstructHandle<NativeMethods.Manifold, Manifold<TVert>> constructHandle = Manifold<TVert>.Construct(allocator);
			return constructHandle.Complete(NativeMethods.manifold_of_meshgl(constructHandle, mesh.Ptr));
		}

		public static uint ReserveIDs(uint n)
		{
			return NativeMethods.manifold_reserve_ids(n);
		}

		public unsafe Box BoundingBox()
		{
			Box result = default(Box);
			NativeMethods.manifold_bounding_box(&result, base.Ptr);
			return result;
		}

		public unsafe double MinGap(Manifold other, double searchLength)
		{
			return NativeMethods.manifold_min_gap(base.Ptr, other.Ptr, searchLength);
		}

		protected unsafe override void Destruct()
		{
			NativeMethods.manifold_destruct_manifold(base.Ptr);
		}
	}
}
