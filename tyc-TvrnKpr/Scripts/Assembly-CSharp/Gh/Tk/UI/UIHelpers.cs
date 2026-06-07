using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public static class UIHelpers
	{
		private static int[] _ignoreBoundsLayers;

		public static void PrepareForUI(this GameObject model, GameObjectX gox = null, EntityObject entityObject = null, bool setUILayer = true, string _swatchMaterialIdOverride = null)
		{
		}

		public static void SetDefaultCustomRotation(GameObject model, Vector3 eulerAngles)
		{
		}

		public static void SetUIRotationOffset(GameObject model, Vector3 offset)
		{
		}

		public static Renderer[] GetModelRenderers(Transform transform)
		{
			return null;
		}

		public static void FixLightSizeForUI(BuildableTemplate template, GameObject model)
		{
		}

		public static bool GetRenderersAndTotalBounds(Transform transform, out IEnumerable<Renderer> filteredRenderers, out Bounds totalBounds)
		{
			filteredRenderers = null;
			totalBounds = default(Bounds);
			return false;
		}

		public static bool IsBeingEdited(GameObject gameObject)
		{
			return false;
		}
	}
}
