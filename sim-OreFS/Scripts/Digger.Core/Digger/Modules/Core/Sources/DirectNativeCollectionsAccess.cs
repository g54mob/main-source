using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Digger.Modules.Core.Sources
{
	public static class DirectNativeCollectionsAccess
	{
		public unsafe static void CopyTo<T>(NativeSlice<T> slice, T[] destination) where T : struct
		{
			if (slice.Length != destination.Length)
			{
				throw new ArgumentException("Source and destination arrays must have the same length");
			}
			try
			{
				int stride = slice.Stride;
				void* unsafeReadOnlyPtr = slice.GetUnsafeReadOnlyPtr();
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = UnsafeUtility.ReadArrayElementWithStride<T>(unsafeReadOnlyPtr, i, stride);
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Failed to make a direct copy. Falling back to CopyTo method. Exception was: " + ex);
				slice.CopyTo(destination);
			}
		}
	}
}
