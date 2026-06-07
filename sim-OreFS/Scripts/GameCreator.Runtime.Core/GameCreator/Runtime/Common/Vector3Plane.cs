using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class Vector3Plane
	{
		public static Vector3 NormalUp { get; } = new Vector3(1f, 0f, 1f);

		public static Vector3 NormalRight { get; } = new Vector3(0f, 1f, 1f);

		public static Vector3 NormalForward { get; } = new Vector3(1f, 1f, 0f);
	}
}
