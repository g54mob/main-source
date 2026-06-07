using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pathfinding.Drawing
{
	internal static class GeometryBuilder
	{
		public struct CameraInfo
		{
			public float3 cameraPosition;

			public quaternion cameraRotation;

			public float2 cameraDepthToPixelSize;

			public bool cameraIsOrthographic;

			public CameraInfo(Camera camera)
			{
				cameraPosition = default(float3);
				cameraRotation = default(quaternion);
				cameraDepthToPixelSize = default(float2);
				cameraIsOrthographic = false;
			}
		}

		internal unsafe static JobHandle Build(DrawingData gizmos, DrawingData.ProcessedBuilderData.MeshBuffers* buffers, ref CameraInfo cameraInfo, JobHandle dependency)
		{
			return default(JobHandle);
		}

		private static float2 CameraDepthToPixelSize(Camera camera)
		{
			return default(float2);
		}

		private static NativeArray<T> ConvertExistingDataToNativeArray<T>(UnsafeAppendBuffer data) where T : struct
		{
			return default(NativeArray<T>);
		}

		internal unsafe static void BuildMesh(DrawingData gizmos, List<DrawingData.MeshWithType> meshes, DrawingData.ProcessedBuilderData.MeshBuffers* inputBuffers)
		{
		}

		private static Mesh AssignMeshData<VertexType>(DrawingData gizmos, Bounds bounds, UnsafeAppendBuffer vertices, UnsafeAppendBuffer triangles, VertexAttributeDescriptor[] layout) where VertexType : struct
		{
			return null;
		}
	}
}
