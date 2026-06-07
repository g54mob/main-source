using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;

namespace DV.OriginShift
{
	public static class OriginShift
	{
		private static Vector3 _currentMove;

		public static Transform parentContainer;

		public static Vector3 currentMove
		{
			get
			{
				return _currentMove;
			}
			set
			{
				_currentMove = value;
				OriginShiftBurst.CurrentMove.Data = value;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void NoDomainReload()
		{
			currentMove = Vector3.zero;
			parentContainer = null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 AbsolutePosition(this Transform transform)
		{
			return transform.position - currentMove;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAbsolutePosition(this Transform transform, Vector3 position)
		{
			transform.position = position + currentMove;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 AbsolutePosition(in TransformAccess transform)
		{
			return (float3)transform.position - OriginShiftBurst.CurrentMove.Data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAbsolutePosition(this ref TransformAccess transform, float3 position)
		{
			transform.position = position + OriginShiftBurst.CurrentMove.Data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 AbsolutePosition(this in Translation translation)
		{
			return translation.Value - OriginShiftBurst.CurrentMove.Data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAbsolutePosition(this ref Translation translation, float3 position)
		{
			translation.Value = position + OriginShiftBurst.CurrentMove.Data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 AbsolutePosition(this in LocalToWorld transform)
		{
			return transform.Position - OriginShiftBurst.CurrentMove.Data;
		}
	}
}
