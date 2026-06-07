using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Coherence.Toolkit
{
	public static class SceneUtils
	{
		public static T[] FindInScene<T>(Scene scene, FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode) where T : Component
		{
			return null;
		}

		[Obsolete("Use FindInScene overload with FindObjectsInactive and FindObjectsSortMode to avoid sorting when you don't need to.")]
		public static T[] FindInScene<T>(Scene scene, bool includeInactive = false) where T : Component
		{
			return null;
		}

		public static GameObject[] FindInScene(Scene scene, FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode)
		{
			return null;
		}

		[Obsolete("Use FindInScene overload with FindObjectsInactive and FindObjectsSortMode to avoid sorting when you don't need to.")]
		public static GameObject[] FindInScene(Scene scene, bool includeInactive = false)
		{
			return null;
		}

		public static void FindInScene<T>(Scene scene, List<T> result, FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode) where T : Component
		{
		}

		[Obsolete("Use FindInScene overload with FindObjectsInactive and FindObjectsSortMode to avoid sorting when you don't need to.")]
		public static void FindInScene<T>(Scene scene, List<T> result, bool includeInactive = false) where T : Component
		{
		}

		public static void FindInScene(Scene scene, List<GameObject> result, FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode)
		{
		}

		[Obsolete("Use FindInScene overload with FindObjectsInactive and FindObjectsSortMode to avoid sorting when you don't need to.")]
		public static void FindInScene(Scene scene, List<GameObject> result, bool includeInactive = false)
		{
		}
	}
}
