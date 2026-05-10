using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools
{
	public static class DTUtility
	{
		public const string HelpUrlBase = "https://curvyeditor.com/doclink/";

		public static bool IsEditorStateChange => false;

		public static bool IsInEditMode => false;

		[Obsolete("Will get removed since it is not used by Curvy, and needs maintenance to be compatible with Unity's Enter Play Mode Settings")]
		[UsedImplicitly]
		public static Material GetDefaultMaterial()
		{
			return null;
		}

		public static float GetHandleSize(Vector3 position)
		{
			return 0f;
		}

		public static float GetHandleSize(Vector3 position, Camera camera, float cameraCenterWidth, float cameraCenterHeight, Vector3 cameraPosition, Vector3 cameraZDirection, Vector3 cameraXDirection)
		{
			return 0f;
		}

		public static void SetPlayerPrefs<T>(string key, T value)
		{
		}

		public static T GetPlayerPrefs<T>(string key, T defaultValue)
		{
			return default(T);
		}

		public static float RandomSign()
		{
			return 0f;
		}

		public static string GetHelpUrl(object forClass)
		{
			return null;
		}

		public static string GetHelpUrl(Type classType)
		{
			return null;
		}

		public static Vector3 GetCenterPosition(Vector3 fallback, params Vector3[] vectors)
		{
			return default(Vector3);
		}

		public static T CreateGameObject<T>(Transform parent, string name) where T : MonoBehaviour
		{
			return null;
		}
	}
}
