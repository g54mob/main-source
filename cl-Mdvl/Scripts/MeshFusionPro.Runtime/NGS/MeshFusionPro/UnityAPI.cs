using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public static class UnityAPI
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[] FindObjectsOfType<T>() where T : Object
		{
			return Object.FindObjectsByType<T>(FindObjectsSortMode.None);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T FindObjectOfType<T>() where T : Object
		{
			return Object.FindAnyObjectByType<T>();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static NativeArray<T> NativeListToArray<T>(this NativeList<T> list) where T : unmanaged
		{
			return list;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetRigidbodyVelocity(Rigidbody rigidbody)
		{
			return rigidbody.velocity;
		}
	}
}
