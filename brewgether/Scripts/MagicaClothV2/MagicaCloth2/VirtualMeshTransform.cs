using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public struct VirtualMeshTransform
	{
		public FixedString32Bytes name;

		public int index;

		public float4x4 localToWorldMatrix;

		public float4x4 worldToLocalMatrix;

		public int parentIndex;

		public static VirtualMeshTransform Origin => default(VirtualMeshTransform);

		public VirtualMeshTransform(Transform t)
		{
			name = default(FixedString32Bytes);
			index = 0;
			localToWorldMatrix = default(float4x4);
			worldToLocalMatrix = default(float4x4);
			parentIndex = 0;
		}

		public VirtualMeshTransform(Transform t, int index)
		{
			name = default(FixedString32Bytes);
			this.index = 0;
			localToWorldMatrix = default(float4x4);
			worldToLocalMatrix = default(float4x4);
			parentIndex = 0;
		}

		public VirtualMeshTransform Clone()
		{
			return default(VirtualMeshTransform);
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public void Update(Transform t)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 TransformPoint(float3 pos)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 TransformVector(float3 vec)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 TransformDirection(float3 dir)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 InverseTransformPoint(float3 pos)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 InverseTransformVector(float3 vec)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 InverseTransformDirection(float3 dir)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public quaternion InverseTransformRotation(quaternion rot)
		{
			return default(quaternion);
		}

		public VirtualMeshTransform Transform(in VirtualMeshTransform to)
		{
			return default(VirtualMeshTransform);
		}
	}
}
