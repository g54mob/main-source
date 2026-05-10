using System;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.ThirdParty.LibTessDotNet
{
	public static class UnityLibTessUtility
	{
		[Obsolete("No more used in Curvy. Will get removed. Copy it if you still need it")]
		public static ContourVertex[] ToContourVertex(Vector3[] v, bool zeroZ = false)
		{
			return null;
		}

		public static ContourVertex[] ToContourVertex(SubArray<Vector3> v, bool zeroZ = false)
		{
			return null;
		}

		public static void FromContourVertex(ContourVertex[] v, SubArray<Vector3> output)
		{
		}

		public static SubArray<Vector3> ContourVerticesToPositions(ContourVertex[] v)
		{
			return default(SubArray<Vector3>);
		}

		[Obsolete("No more used in Curvy. Will get removed. Copy it if you still need it")]
		public static void SetFromContourVertex(ref Vector3[] v3Array, ref ContourVertex[] cvArray)
		{
		}

		[Obsolete("No more used in Curvy. Will get removed. Copy it if you still need it")]
		public static void SetToContourVertex(ref ContourVertex[] cvArray, ref Vector3[] v3Array)
		{
		}
	}
}
