using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public static class SelectionHighlight
	{
		public static string NameSuffix;

		public static string OutlineIgnoreSuffix;

		private static int[] _invalidLayers;

		public static Color defaultColor;

		public static List<GameObject> CreateSelectionHighlights(GameObject gameObject, Color? outlineColor = null, List<int> hashCodesUsed = null)
		{
			return null;
		}

		private static Mesh GetSharedMesh(Renderer renderer)
		{
			return null;
		}

		public static IEnumerable<Renderer> GetHighlightableRenderers(GameObject gameObject, IEnumerable<int> layersToIgnore = null)
		{
			return null;
		}

		public static IEnumerable<Renderer> GetHighlightableRenderersForEntityObject(GameObject gameObject, GameObjectX parentGox, IEnumerable<int> layersToIgnore = null)
		{
			return null;
		}

		private static bool IsRendererValidForHighlight(GameObject rootGameObject, Renderer renderer, IEnumerable<int> layersToIgnore = null)
		{
			return false;
		}

		private static void ApplyHighlight(Renderer meshRenderer, Color? outlineColor = null)
		{
		}

		private static PrefabObjectPool GetMeshHighlightPool(Renderer highlightable)
		{
			return null;
		}

		private static PrefabObjectPool GetMeshHighlightPool(int hashCode)
		{
			return null;
		}

		public static GameObject GetHighlightForRenderer(Renderer highlightable, Color? outlineColor = null, int? hashCode = null, bool ignoreEnableState = false)
		{
			return null;
		}

		public static void CleanUpHighlights(GameObject go)
		{
		}
	}
}
