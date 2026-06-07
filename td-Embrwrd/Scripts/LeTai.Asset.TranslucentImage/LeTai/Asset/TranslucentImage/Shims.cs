using System.Runtime.CompilerServices;
using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	public static class Shims
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T FindObjectOfType<T>(bool includeInactive = false, bool sorted = true) where T : Object
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[] FindObjectsOfType<T>(bool includeInactive = false) where T : Object
		{
			return null;
		}
	}
}
