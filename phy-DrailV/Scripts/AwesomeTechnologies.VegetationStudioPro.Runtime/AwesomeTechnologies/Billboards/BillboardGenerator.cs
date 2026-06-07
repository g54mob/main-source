using AwesomeTechnologies.BillboardSystem;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.VegetationSystem;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

namespace AwesomeTechnologies.Billboards
{
	public class BillboardGenerator
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct CreateBillboardMeshJob : IJob
		{
			[ReadOnly]
			public NativeList<MatrixInstance> InstanceList;

			public NativeList<Vector3> VerticeList;

			public NativeList<int> IndexList;

			public NativeList<Vector2> UvList;

			public NativeList<Vector2> Uv2List;

			public NativeList<Vector2> Uv3List;

			public NativeList<Vector3> NormalList;

			public float BoundsYExtent;

			public float VegetationItemSize;

			private Vector3 _srcVert0;

			private Vector3 _srcVert1;

			private Vector3 _srcVert2;

			private Vector3 _srcVert3;

			private Vector2 _srcUVs0;

			private Vector2 _srcUVs1;

			private Vector2 _srcUVs2;

			private Vector2 _srcUVs3;

			private int _srcIndex0;

			private int _srcIndex1;

			private int _srcIndex2;

			private int _srcIndex3;

			private int _srcIndex4;

			private int _srcIndex5;

			public void Execute()
			{
				SetupData();
				int num = 0;
				Vector2 value3 = default(Vector2);
				for (int i = 0; i <= InstanceList.Length - 1; i++)
				{
					MatrixInstance matrixInstance = InstanceList[i];
					Vector3 vector = ExtractScaleFromMatrix(matrixInstance.Matrix) / 2f;
					Vector3 value = ExtractTranslationFromMatrix(matrixInstance.Matrix) + new Vector3(0f, BoundsYExtent * vector.y * 2f, 0f);
					Quaternion quaternion = ExtractRotationFromMatrix(matrixInstance.Matrix);
					VerticeList.Add(value);
					VerticeList.Add(value);
					VerticeList.Add(value);
					VerticeList.Add(value);
					NormalList.Add(_srcVert0);
					NormalList.Add(_srcVert1);
					NormalList.Add(_srcVert2);
					NormalList.Add(_srcVert3);
					UvList.Add(_srcUVs0);
					UvList.Add(_srcUVs1);
					UvList.Add(_srcUVs2);
					UvList.Add(_srcUVs3);
					Vector2 value2 = new Vector2((360f - quaternion.eulerAngles.y) / 360f, 1f);
					Uv2List.Add(value2);
					Uv2List.Add(value2);
					Uv2List.Add(value2);
					Uv2List.Add(value2);
					value3.x = VegetationItemSize * vector.x * 2f;
					value3.y = 0f - BoundsYExtent * vector.y * 2f;
					Uv3List.Add(value3);
					Uv3List.Add(value3);
					Uv3List.Add(value3);
					Uv3List.Add(value3);
					IndexList.Add(_srcIndex0 + num);
					IndexList.Add(_srcIndex1 + num);
					IndexList.Add(_srcIndex2 + num);
					IndexList.Add(_srcIndex3 + num);
					IndexList.Add(_srcIndex4 + num);
					IndexList.Add(_srcIndex5 + num);
					num += 4;
				}
			}

			private void SetupData()
			{
				_srcVert0 = new Vector3(-0.5f, -0.5f, 0f);
				_srcVert1 = new Vector3(0.5f, 0.5f, 0f);
				_srcVert2 = new Vector3(0.5f, -0.5f, 0f);
				_srcVert3 = new Vector3(-0.5f, 0.5f, 0f);
				_srcUVs0 = new Vector2(0f, 0f);
				_srcUVs1 = new Vector2(1f, 1f);
				_srcUVs2 = new Vector2(1f, 0f);
				_srcUVs3 = new Vector2(0f, 1f);
				_srcIndex0 = 0;
				_srcIndex1 = 1;
				_srcIndex2 = 2;
				_srcIndex3 = 1;
				_srcIndex4 = 0;
				_srcIndex5 = 3;
			}

			private Vector3 ExtractTranslationFromMatrix(Matrix4x4 matrix)
			{
				Vector3 result = default(Vector3);
				result.x = matrix.m03;
				result.y = matrix.m13;
				result.z = matrix.m23;
				return result;
			}

			public static Vector3 ExtractScaleFromMatrix(Matrix4x4 matrix)
			{
				return new Vector3(matrix.GetColumn(0).magnitude, matrix.GetColumn(1).magnitude, matrix.GetColumn(2).magnitude);
			}

			public static Quaternion ExtractRotationFromMatrix(Matrix4x4 matrix)
			{
				Vector3 vector = default(Vector3);
				vector.x = matrix.m02;
				vector.y = matrix.m12;
				vector.z = matrix.m22;
				if (vector == Vector3.zero)
				{
					return Quaternion.identity;
				}
				Vector3 upwards = default(Vector3);
				upwards.x = matrix.m01;
				upwards.y = matrix.m11;
				upwards.z = matrix.m21;
				return Quaternion.LookRotation(vector, upwards);
			}
		}

		public static Mesh CreateMeshFromBillboardInstance(BillboardInstance billboardInstance)
		{
			NativeArray<Vector3> nativeArray = billboardInstance.VerticeList;
			NativeArray<int> nativeArray2 = billboardInstance.IndexList;
			NativeArray<Vector2> nativeArray3 = billboardInstance.UvList;
			NativeArray<Vector2> nativeArray4 = billboardInstance.Uv2List;
			NativeArray<Vector2> nativeArray5 = billboardInstance.Uv3List;
			NativeArray<Vector3> nativeArray6 = billboardInstance.NormalList;
			Vector3[] array = new Vector3[billboardInstance.VerticeList.Length];
			int[] array2 = new int[billboardInstance.IndexList.Length];
			Vector2[] array3 = new Vector2[billboardInstance.UvList.Length];
			Vector2[] array4 = new Vector2[billboardInstance.Uv2List.Length];
			Vector2[] array5 = new Vector2[billboardInstance.Uv3List.Length];
			Vector3[] array6 = new Vector3[billboardInstance.NormalList.Length];
			nativeArray.CopyToFast(array);
			nativeArray2.CopyToFast(array2);
			nativeArray3.CopyToFast(array3);
			nativeArray4.CopyToFast(array4);
			nativeArray5.CopyToFast(array5);
			nativeArray6.CopyToFast(array6);
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.DontSave;
			mesh.subMeshCount = 1;
			mesh.indexFormat = IndexFormat.UInt32;
			mesh.vertices = array;
			mesh.SetIndices(array2, MeshTopology.Triangles, 0, calculateBounds: false);
			mesh.uv = array3;
			mesh.uv2 = array4;
			mesh.uv3 = array5;
			mesh.normals = array6;
			mesh.RecalculateBounds();
			return mesh;
		}
	}
}
