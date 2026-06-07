using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	internal static class GraphicConnectorExtension
	{
		public static void SetVerticesDirtyEx(this Graphic graphic)
		{
		}

		public static void SetMaterialDirtyEx(this Graphic graphic)
		{
		}

		public static T GetComponentInParentEx<T>(this Component component, bool includeInactive = false) where T : MonoBehaviour
		{
			return null;
		}
	}
}
