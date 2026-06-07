using System.Collections.Generic;
using UnityEngine;

namespace UI.ThreeDimensional
{
	public static class UIObject3DUtilities
	{
		private static Dictionary<UIObject3D, Vector3> targetContainers;

		public static Vector3 NormalizeRotation(Vector3 rotation)
		{
			return default(Vector3);
		}

		public static float NormalizeAngle(float value)
		{
			return 0f;
		}

		internal static void RegisterTargetContainerPosition(UIObject3D uiObject3D, Vector3 position)
		{
		}

		internal static Vector3 GetTargetContainerPosition(UIObject3D uiObject3d)
		{
			return default(Vector3);
		}

		internal static Vector3 GetNextFreeTargetContainerPosition()
		{
			return default(Vector3);
		}

		internal static void UnRegisterTargetContainer(UIObject3D uiObject3D)
		{
		}
	}
}
