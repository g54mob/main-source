using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UISoftMaskInternal
{
	internal static class MeshExtensions
	{
		internal static readonly ObjectPool<Mesh> s_MeshPool = new ObjectPool<Mesh>(delegate
		{
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
			mesh.MarkDynamic();
			return mesh;
		}, (Mesh mesh) => mesh, delegate(Mesh mesh)
		{
			if ((bool)mesh)
			{
				mesh.Clear();
			}
		});

		public static Mesh Rent()
		{
			return s_MeshPool.Rent();
		}

		public static void Return(ref Mesh mesh)
		{
			s_MeshPool.Return(ref mesh);
		}

		public static void CopyTo(this Mesh self, Mesh dst)
		{
			if ((bool)self && (bool)dst)
			{
				List<Vector3> toRelease = ListPool<Vector3>.Rent();
				List<Vector4> toRelease2 = ListPool<Vector4>.Rent();
				List<Color32> toRelease3 = ListPool<Color32>.Rent();
				List<int> toRelease4 = ListPool<int>.Rent();
				dst.Clear(keepVertexLayout: false);
				self.GetVertices(toRelease);
				dst.SetVertices(toRelease);
				self.GetTriangles(toRelease4, 0);
				dst.SetTriangles(toRelease4, 0);
				self.GetNormals(toRelease);
				dst.SetNormals(toRelease);
				self.GetTangents(toRelease2);
				dst.SetTangents(toRelease2);
				self.GetColors(toRelease3);
				dst.SetColors(toRelease3);
				self.GetUVs(0, toRelease2);
				dst.SetUVs(0, toRelease2);
				self.GetUVs(1, toRelease2);
				dst.SetUVs(1, toRelease2);
				self.GetUVs(2, toRelease2);
				dst.SetUVs(2, toRelease2);
				self.GetUVs(3, toRelease2);
				dst.SetUVs(3, toRelease2);
				dst.RecalculateBounds();
				ListPool<Vector3>.Return(ref toRelease);
				ListPool<Vector4>.Return(ref toRelease2);
				ListPool<Color32>.Return(ref toRelease3);
				ListPool<int>.Return(ref toRelease4);
			}
		}
	}
}
