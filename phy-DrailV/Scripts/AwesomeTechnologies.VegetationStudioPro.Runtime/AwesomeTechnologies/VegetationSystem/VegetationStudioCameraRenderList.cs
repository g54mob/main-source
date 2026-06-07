using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	public class VegetationStudioCameraRenderList
	{
		[NonSerialized]
		public readonly List<NativeList<MatrixInstance>> VegetationItemMergeMatrixList = new List<NativeList<MatrixInstance>>();

		[NonSerialized]
		public readonly List<NativeList<Matrix4x4>> VegetationItemLOD0MatrixList = new List<NativeList<Matrix4x4>>();

		[NonSerialized]
		public readonly List<NativeList<Matrix4x4>> VegetationItemLOD1MatrixList = new List<NativeList<Matrix4x4>>();

		[NonSerialized]
		public readonly List<NativeList<Matrix4x4>> VegetationItemLOD2MatrixList = new List<NativeList<Matrix4x4>>();

		[NonSerialized]
		public readonly List<NativeList<Matrix4x4>> VegetationItemLOD3MatrixList = new List<NativeList<Matrix4x4>>();

		[NonSerialized]
		public readonly List<NativeList<Matrix4x4>> VegetationItemLOD0ShadowMatrixList = new List<NativeList<Matrix4x4>>();

		[NonSerialized]
		public readonly List<NativeList<Matrix4x4>> VegetationItemLOD1ShadowMatrixList = new List<NativeList<Matrix4x4>>();

		[NonSerialized]
		public readonly List<NativeList<Matrix4x4>> VegetationItemLOD2ShadowMatrixList = new List<NativeList<Matrix4x4>>();

		[NonSerialized]
		public readonly List<NativeList<Matrix4x4>> VegetationItemLOD3ShadowMatrixList = new List<NativeList<Matrix4x4>>();

		[NonSerialized]
		public readonly List<NativeList<Vector4>> VegetationItemLOD0LodFadeList = new List<NativeList<Vector4>>();

		[NonSerialized]
		public readonly List<NativeList<Vector4>> VegetationItemLOD1LodFadeList = new List<NativeList<Vector4>>();

		[NonSerialized]
		public readonly List<NativeList<Vector4>> VegetationItemLOD2LodFadeList = new List<NativeList<Vector4>>();

		[NonSerialized]
		public readonly List<NativeList<Vector4>> VegetationItemLOD3LodFadeList = new List<NativeList<Vector4>>();

		public VegetationStudioCameraRenderList(int vegetationItemCount)
		{
			for (int i = 0; i <= vegetationItemCount - 1; i++)
			{
				NativeList<MatrixInstance> item = new NativeList<MatrixInstance>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemMergeMatrixList.Add(item);
				NativeList<Matrix4x4> item2 = new NativeList<Matrix4x4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD0MatrixList.Add(item2);
				NativeList<Matrix4x4> item3 = new NativeList<Matrix4x4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD1MatrixList.Add(item3);
				NativeList<Matrix4x4> item4 = new NativeList<Matrix4x4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD2MatrixList.Add(item4);
				NativeList<Matrix4x4> item5 = new NativeList<Matrix4x4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD3MatrixList.Add(item5);
				NativeList<Matrix4x4> item6 = new NativeList<Matrix4x4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD0ShadowMatrixList.Add(item6);
				NativeList<Matrix4x4> item7 = new NativeList<Matrix4x4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD1ShadowMatrixList.Add(item7);
				NativeList<Matrix4x4> item8 = new NativeList<Matrix4x4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD2ShadowMatrixList.Add(item8);
				NativeList<Matrix4x4> item9 = new NativeList<Matrix4x4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD3ShadowMatrixList.Add(item9);
				NativeList<Vector4> item10 = new NativeList<Vector4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD0LodFadeList.Add(item10);
				NativeList<Vector4> item11 = new NativeList<Vector4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD1LodFadeList.Add(item11);
				NativeList<Vector4> item12 = new NativeList<Vector4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD2LodFadeList.Add(item12);
				NativeList<Vector4> item13 = new NativeList<Vector4>(1024, Allocator.Persistent)
				{
					Capacity = 1024
				};
				VegetationItemLOD3LodFadeList.Add(item13);
			}
		}

		public void Dispose()
		{
			DisposeMatrixInstanceList(VegetationItemMergeMatrixList);
			DisposeMatrixList(VegetationItemLOD0MatrixList);
			DisposeMatrixList(VegetationItemLOD1MatrixList);
			DisposeMatrixList(VegetationItemLOD2MatrixList);
			DisposeMatrixList(VegetationItemLOD3MatrixList);
			DisposeMatrixList(VegetationItemLOD0ShadowMatrixList);
			DisposeMatrixList(VegetationItemLOD1ShadowMatrixList);
			DisposeMatrixList(VegetationItemLOD2ShadowMatrixList);
			DisposeMatrixList(VegetationItemLOD3ShadowMatrixList);
			DisposeVector4List(VegetationItemLOD0LodFadeList);
			DisposeVector4List(VegetationItemLOD1LodFadeList);
			DisposeVector4List(VegetationItemLOD2LodFadeList);
			DisposeVector4List(VegetationItemLOD3LodFadeList);
		}

		private void DisposeMatrixList(List<NativeList<Matrix4x4>> list)
		{
			for (int i = 0; i <= list.Count - 1; i++)
			{
				list[i].Dispose();
			}
		}

		private void DisposeMatrixInstanceList(List<NativeList<MatrixInstance>> list)
		{
			for (int i = 0; i <= list.Count - 1; i++)
			{
				list[i].Dispose();
			}
		}

		private void DisposeVector4List(List<NativeList<Vector4>> list)
		{
			for (int i = 0; i <= list.Count - 1; i++)
			{
				list[i].Dispose();
			}
		}
	}
}
