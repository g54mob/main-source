using System.Numerics;
using Coherence.Common;
using UnityEngine;

namespace Coherence
{
	public static class Vector3dEx
	{
		public static Vector3d ToVector3d(this System.Numerics.Vector3 vector3)
		{
			return default(Vector3d);
		}

		public static Vector3d ToVector3d(this UnityEngine.Vector3 vector3)
		{
			return default(Vector3d);
		}

		public static UnityEngine.Vector3 ToUnityVector3(this Vector3d v)
		{
			return default(UnityEngine.Vector3);
		}
	}
}
