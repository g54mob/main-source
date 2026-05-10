using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Photon.Pun
{
	public static class PunExtensions
	{
		public static Dictionary<MethodInfo, ParameterInfo[]> ParametersOfMethods;

		public static ParameterInfo[] GetCachedParemeters(this MethodInfo mo)
		{
			return null;
		}

		public static PhotonView[] GetPhotonViewsInChildren(this GameObject go)
		{
			return null;
		}

		public static PhotonView GetPhotonView(this GameObject go)
		{
			return null;
		}

		public static bool AlmostEquals(this Vector3 target, Vector3 second, float sqrMagnitudePrecision)
		{
			return false;
		}

		public static bool AlmostEquals(this Vector2 target, Vector2 second, float sqrMagnitudePrecision)
		{
			return false;
		}

		public static bool AlmostEquals(this Quaternion target, Quaternion second, float maxAngle)
		{
			return false;
		}

		public static bool AlmostEquals(this float target, float second, float floatDiff)
		{
			return false;
		}

		public static bool CheckIsAssignableFrom(this Type to, Type from)
		{
			return false;
		}

		public static bool CheckIsInterface(this Type to)
		{
			return false;
		}
	}
}
