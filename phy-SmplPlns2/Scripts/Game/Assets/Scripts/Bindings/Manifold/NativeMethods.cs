using System;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Assets.Scripts.Bindings.Manifold
{
	public static class NativeMethods
	{
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		public struct Manifold
		{
		}

		public struct ManifoldPair
		{
			public unsafe Manifold* first;

			public unsafe Manifold* second;
		}

		[StructLayout(LayoutKind.Explicit, Size = 1)]
		public struct ManifoldVec
		{
		}

		[StructLayout(LayoutKind.Explicit, Size = 1)]
		public struct MeshGL
		{
		}

		public struct MeshGLOptions
		{
			public unsafe uint* run_indices;

			public UIntPtr run_indices_length;

			public unsafe uint* run_original_ids;

			public UIntPtr run_original_ids_length;

			public unsafe uint* merge_from_vert;

			public unsafe uint* merge_to_vert;

			public UIntPtr merge_verts_length;

			public unsafe float* halfedge_tangents;
		}

		public struct MeshGL64Options
		{
			public unsafe ulong* run_indices;

			public UIntPtr run_indices_length;

			public unsafe uint* run_original_ids;

			public UIntPtr run_original_ids_length;

			public unsafe ulong* merge_from_vert;

			public unsafe ulong* merge_to_vert;

			public UIntPtr merge_verts_length;

			public unsafe double* halfedge_tangents;
		}

		[StructLayout(LayoutKind.Explicit, Size = 1)]
		public struct MeshGL64
		{
		}

		[StructLayout(LayoutKind.Explicit, Size = 1)]
		public struct Polygons
		{
		}

		public struct Properties
		{
			public double surface_area;

			public double volume;
		}

		[StructLayout(LayoutKind.Explicit, Size = 1)]
		public struct Rect
		{
		}

		[StructLayout(LayoutKind.Explicit, Size = 1)]
		public struct Section
		{
		}

		[StructLayout(LayoutKind.Explicit, Size = 1)]
		public struct SectionVec
		{
		}

		[StructLayout(LayoutKind.Explicit, Size = 1)]
		public struct SimplePolygon
		{
		}

		[StructLayout(LayoutKind.Explicit, Size = 1)]
		public struct Triangulation
		{
		}

		private const string Library = "manifoldc";

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Box* manifold_alloc_box();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_alloc_cross_section();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern SectionVec* manifold_alloc_cross_section_vec();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_alloc_manifold();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ManifoldVec* manifold_alloc_manifold_vec();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL* manifold_alloc_meshgl();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL64* manifold_alloc_meshgl64();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Polygons* manifold_alloc_polygons();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Rect* manifold_alloc_rect();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern SimplePolygon* manifold_alloc_simple_polygon();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Triangulation* manifold_alloc_triangulation();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_as_original(void* mem, Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_batch_boolean(void* mem, ManifoldVec* ms, OpType op);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_batch_hull(void* mem, ManifoldVec* ms);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_boolean(void* mem, Manifold* a, Manifold* b, OpType op);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Box* manifold_bounding_box(void* mem, Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Box* manifold_box(void* mem, double x1, double y1, double z1, double x2, double y2, double z2);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double3 manifold_box_center(Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_box_contains_box(Box* a, Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_box_contains_pt(Box* b, double x, double y, double z);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double3 manifold_box_dimensions(Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_box_does_overlap_box(Box* a, Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_box_does_overlap_pt(Box* b, double x, double y, double z);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_box_include_pt(Box* b, double x, double y, double z);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_box_is_finite(Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double3 manifold_box_max(Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double3 manifold_box_min(Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Box* manifold_box_mul(void* mem, Box* b, double x, double y, double z);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double manifold_box_scale(Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_box_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Box* manifold_box_transform(void* mem, Box* b, double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, double x4, double y4, double z4);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Box* manifold_box_translate(void* mem, Box* b, double x, double y, double z);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Box* manifold_box_union(void* mem, Box* a, Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_calculate_curvature(void* mem, Manifold* m, int gaussian_idx, int mean_idx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_calculate_normals(void* mem, Manifold* m, int normal_idx, double min_sharp_angle);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_compose(void* mem, ManifoldVec* ms);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_copy(void* mem, Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double manifold_cross_section_area(Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_batch_boolean(void* mem, SectionVec* csv, OpType op);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_batch_hull(void* mem, SectionVec* css);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_boolean(void* mem, Section* a, Section* b, OpType op);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Rect* manifold_cross_section_bounds(void* mem, Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_circle(void* mem, double radius, int circular_segments);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_compose(void* mem, SectionVec* csv);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_copy(void* mem, Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern SectionVec* manifold_cross_section_decompose(void* mem, Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_difference(void* mem, Section* a, Section* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_empty(void* mem);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern SectionVec* manifold_cross_section_empty_vec(void* mem);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_hull(void* mem, Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_hull_polygons(void* mem, Polygons* ps);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_hull_simple_polygon(void* mem, SimplePolygon* ps);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_intersection(void* mem, Section* a, Section* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_cross_section_is_empty(Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_mirror(void* mem, Section* cs, double ax_x, double ax_y);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_cross_section_num_contour(Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_cross_section_num_vert(Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_of_polygons(void* mem, Polygons* p, FillRule fr);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_of_simple_polygon(void* mem, SimplePolygon* p, FillRule fr);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_offset(void* mem, Section* cs, double delta, JoinType jt, double miter_limit, int circular_segments);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_rotate(void* mem, Section* cs, double deg);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_scale(void* mem, Section* cs, double x, double y);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_simplify(void* mem, Section* cs, double epsilon);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_cross_section_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_square(void* mem, double x, double y, int center);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Polygons* manifold_cross_section_to_polygons(void* mem, Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_transform(void* mem, Section* cs, double x1, double y1, double x2, double y2, double x3, double y3);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_translate(void* mem, Section* cs, double x, double y);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_union(void* mem, Section* a, Section* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern SectionVec* manifold_cross_section_vec(void* mem, UIntPtr sz);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_vec_get(void* mem, SectionVec* csv, UIntPtr idx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_cross_section_vec_length(SectionVec* csv);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_cross_section_vec_push_back(SectionVec* csv, Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_cross_section_vec_reserve(SectionVec* csv, UIntPtr sz);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_cross_section_vec_set(SectionVec* csv, UIntPtr idx, Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_cross_section_vec_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_warp(void* mem, Section* cs, delegate* unmanaged[Cdecl]<double, double, double2> fun);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Section* manifold_cross_section_warp_context(void* mem, Section* cs, delegate* unmanaged[Cdecl]<double, double, void*, double2> fun, void* ctx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_cube(void* mem, double x, double y, double z, int center);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_cylinder(void* mem, double height, double radius_low, double radius_high, int circular_segments, int center);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ManifoldVec* manifold_decompose(void* mem, Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_box(Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_cross_section(Section* cs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_cross_section_vec(SectionVec* csv);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_manifold(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_manifold_vec(ManifoldVec* ms);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_meshgl(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_meshgl64(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_polygons(Polygons* p);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_rect(Rect* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_simple_polygon(SimplePolygon* p);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_delete_triangulation(Triangulation* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_box(Box* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_cross_section(Section* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_cross_section_vec(SectionVec* csv);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_manifold(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_manifold_vec(ManifoldVec* ms);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_meshgl(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_meshgl64(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_polygons(Polygons* p);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_rect(Rect* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_simple_polygon(SimplePolygon* p);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_destruct_triangulation(Triangulation* M);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_difference(void* mem, Manifold* a, Manifold* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_empty(void* mem);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double manifold_epsilon(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_extrude(void* mem, Polygons* cs, double height, int slices, double twist_degrees, double scale_x, double scale_y);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_genus(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int manifold_get_circular_segments(double radius);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL* manifold_get_meshgl(void* mem, Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL* manifold_get_meshgl_w_normals(void* mem, Manifold* m, int normalIdx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL64* manifold_get_meshgl64(void* mem, Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL64* manifold_get_meshgl64_w_normals(void* mem, Manifold* m, int normalIdx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_hull(void* mem, Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_hull_pts(void* mem, double3* ps, UIntPtr length);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_intersection(void* mem, Manifold* a, Manifold* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_is_empty(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_level_set(void* mem, delegate* unmanaged[Cdecl]<double, double, double, void*, double> sdf, Box* bounds, double edge_length, double level, double tolerance, void* ctx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_level_set_seq(void* mem, delegate* unmanaged[Cdecl]<double, double, double, void*, double> sdf, Box* bounds, double edge_length, double level, double tolerance, void* ctx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ManifoldVec* manifold_manifold_empty_vec(void* mem);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_manifold_pair_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_manifold_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ManifoldVec* manifold_manifold_vec(void* mem, UIntPtr sz);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_manifold_vec_get(void* mem, ManifoldVec* ms, UIntPtr idx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_manifold_vec_length(ManifoldVec* ms);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_manifold_vec_push_back(ManifoldVec* ms, Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_manifold_vec_reserve(ManifoldVec* ms, UIntPtr sz);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_manifold_vec_set(ManifoldVec* ms, UIntPtr idx, Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_manifold_vec_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL* manifold_meshgl(void* mem, float* vert_props, UIntPtr n_verts, UIntPtr n_props, uint* tri_verts, UIntPtr n_tris);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL* manifold_meshgl_copy(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern uint* manifold_meshgl_face_id(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_face_id_length(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern float* manifold_meshgl_halfedge_tangent(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL* manifold_meshgl_merge(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern uint* manifold_meshgl_merge_from_vert(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_merge_length(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern uint* manifold_meshgl_merge_to_vert(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_num_prop(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_num_tri(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_num_vert(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern uint* manifold_meshgl_run_index(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_run_index_length(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern uint* manifold_meshgl_run_original_id(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_run_original_id_length(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern float* manifold_meshgl_run_transform(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_run_transform_length(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_meshgl_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_tangent_length(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_tri_length(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern uint* manifold_meshgl_tri_verts(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern float* manifold_meshgl_vert_properties(void* mem, MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl_vert_properties_length(MeshGL* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL* manifold_meshgl_w_tangents(void* mem, float* vert_props, UIntPtr n_verts, UIntPtr n_props, uint* tri_verts, UIntPtr n_tris, float* halfedge_tangent);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL* manifold_meshgl_w_options(void* mem, float* vert_props, UIntPtr n_verts, UIntPtr n_props, uint* tri_verts, UIntPtr n_tris, MeshGLOptions* options);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL64* manifold_meshgl64(void* mem, double* vert_props, UIntPtr n_verts, UIntPtr n_props, ulong* tri_verts, UIntPtr n_tris);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL64* manifold_meshgl64_copy(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ulong* manifold_meshgl64_face_id(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_face_id_length(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double* manifold_meshgl64_halfedge_tangent(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL64* manifold_meshgl64_merge(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ulong* manifold_meshgl64_merge_from_vert(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_merge_length(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ulong* manifold_meshgl64_merge_to_vert(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_num_prop(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_num_tri(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_num_vert(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ulong* manifold_meshgl64_run_index(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_run_index_length(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern uint* manifold_meshgl64_run_original_id(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_run_original_id_length(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double* manifold_meshgl64_run_transform(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_run_transform_length(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_meshgl64_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_tangent_length(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_tri_length(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ulong* manifold_meshgl64_tri_verts(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double* manifold_meshgl64_vert_properties(void* mem, MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_meshgl64_vert_properties_length(MeshGL64* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL64* manifold_meshgl64_w_tangents(void* mem, double* vert_props, UIntPtr n_verts, UIntPtr n_props, ulong* tri_verts, UIntPtr n_tris, double* halfedge_tangent);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern MeshGL64* manifold_meshgl64_w_options(void* mem, double* vert_props, UIntPtr n_verts, UIntPtr n_props, ulong* tri_verts, UIntPtr n_tris, MeshGL64Options* options);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double manifold_min_gap(Manifold* m, Manifold* other, double searchLength);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_mirror(void* mem, Manifold* m, double nx, double ny, double nz);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_num_edge(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_num_prop(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_num_tri(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_num_vert(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_of_meshgl(void* mem, MeshGL* mesh);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_of_meshgl64(void* mem, MeshGL64* mesh);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_original_id(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Polygons* manifold_polygons(void* mem, SimplePolygon** ps, UIntPtr length);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double2 manifold_polygons_get_point(Polygons* ps, UIntPtr simple_idx, UIntPtr pt_idx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern SimplePolygon* manifold_polygons_get_simple(void* mem, Polygons* ps, UIntPtr idx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_polygons_length(Polygons* ps);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_polygons_simple_length(Polygons* ps, UIntPtr idx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_polygons_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Polygons* manifold_project(void* mem, Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Rect* manifold_rect(void* mem, double x1, double y1, double x2, double y2);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double2 manifold_rect_center(Rect* r);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_rect_contains_pt(Rect* r, double x, double y);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_rect_contains_rect(Rect* a, Rect* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double2 manifold_rect_dimensions(Rect* r);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_rect_does_overlap_rect(Rect* a, Rect* r);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern void manifold_rect_include_pt(Rect* r, double x, double y);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_rect_is_empty(Rect* r);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int manifold_rect_is_finite(Rect* r);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double2 manifold_rect_max(Rect* r);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double2 manifold_rect_min(Rect* r);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Rect* manifold_rect_mul(void* mem, Rect* r, double x, double y);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double manifold_rect_scale(Rect* r);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_rect_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Rect* manifold_rect_transform(void* mem, Rect* r, double x1, double y1, double x2, double y2, double x3, double y3);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Rect* manifold_rect_translate(void* mem, Rect* r, double x, double y);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Rect* manifold_rect_union(void* mem, Rect* a, Rect* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_refine(void* mem, Manifold* m, int refine);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_refine_to_length(void* mem, Manifold* m, double length);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_refine_to_tolerance(void* mem, Manifold* m, double tolerance);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern uint manifold_reserve_ids(uint n);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern void manifold_reset_to_circular_defaults();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_revolve(void* mem, Polygons* cs, int circular_segments, double revolve_degrees);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_rotate(void* mem, Manifold* m, double x, double y, double z);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_scale(void* mem, Manifold* m, double x, double y, double z);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern void manifold_set_circular_segments(int number);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern void manifold_set_min_circular_angle(double degrees);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern void manifold_set_min_circular_edge_length(double length);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_set_properties(void* mem, Manifold* m, int num_prop, delegate* unmanaged[Cdecl]<double*, double3, double*, void*, void> fun, void* ctx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern SimplePolygon* manifold_simple_polygon(void* mem, double2* ps, UIntPtr length);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double2 manifold_simple_polygon_get_point(SimplePolygon* p, UIntPtr idx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_simple_polygon_length(SimplePolygon* p);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_simple_polygon_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Polygons* manifold_slice(void* mem, Manifold* m, double height);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_smooth(void* mem, MeshGL* mesh, UIntPtr* half_edges, double* smoothness, UIntPtr n_idxs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_smooth_by_normals(void* mem, Manifold* m, int normalIdx);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_smooth_out(void* mem, Manifold* m, double minSharpAngle, double minSmoothness);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_smooth64(void* mem, MeshGL64* mesh, UIntPtr* half_edges, double* smoothness, UIntPtr n_idxs);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_sphere(void* mem, double radius, int circular_segments);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ManifoldPair manifold_split(void* mem_first, void* mem_second, Manifold* a, Manifold* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern ManifoldPair manifold_split_by_plane(void* mem_first, void* mem_second, Manifold* m, double normal_x, double normal_y, double normal_z, double offset);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Error manifold_status(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double manifold_surface_area(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_tetrahedron(void* mem);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_transform(void* mem, Manifold* m, double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, double x4, double y4, double z4);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_translate(void* mem, Manifold* m, double x, double y, double z);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Triangulation* manifold_triangulate(void* mem, Polygons* ps, double epsilon);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern UIntPtr manifold_triangulation_num_tri(Triangulation* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern UIntPtr manifold_triangulation_size();

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern int* manifold_triangulation_tri_verts(void* mem, Triangulation* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_trim_by_plane(void* mem, Manifold* m, double normal_x, double normal_y, double normal_z, double offset);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_union(void* mem, Manifold* a, Manifold* b);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern double manifold_volume(Manifold* m);

		[DllImport("manifoldc", CallingConvention = CallingConvention.Cdecl)]
		internal unsafe static extern Manifold* manifold_warp(void* mem, Manifold* m, delegate* unmanaged[Cdecl]<double, double, double, void*, double3> fun, void* ctx);
	}
}
