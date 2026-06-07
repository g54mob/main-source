using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Utils
{
	public static class DoozyUtils
	{
		public const string BACKGROUND = "Background";

		public const string OVERLAY = "Overlay";

		public static Color BackgroundColor;

		public static Color CheckmarkColor;

		public static Color OverlayColor;

		public static Color TextColor;

		public const int TEXT_FONT_SIZE = 14;

		public static Image AddImageToGameObject(GameObject target)
		{
			return null;
		}

		public static GameObject CreateGameObjectWithAnImageComponent(string objectName, Color color, GameObject parent = null)
		{
			return null;
		}

		public static GameObject CreateBackgroundImage(GameObject parent)
		{
			return null;
		}

		public static GameObject CreateOverlayImage(GameObject parent)
		{
			return null;
		}

		public static T AddToScene<T>(string gameObjectName, bool isSingleton, bool selectGameObjectAfterCreation = false) where T : MonoBehaviour
		{
			return null;
		}

		public static void AddObjectToAsset(Object objectToAdd, Object assetObject)
		{
		}

		public static bool DisplayDialog(string title, string message, string ok)
		{
			return false;
		}

		public static bool DisplayDialog(string title, string message, string ok, string cancel)
		{
			return false;
		}

		public static void DisplayProgressBar(string title, string info, float progress)
		{
		}

		public static bool DisplayCancelableProgressBar(string title, string info, float progress)
		{
			return false;
		}

		public static void ClearProgressBar()
		{
		}

		public static bool MoveAssetToTrash(string path)
		{
			return false;
		}

		public static void SaveAssets()
		{
		}

		public static void SetDirty(Object target)
		{
		}

		public static void SetDirty(Object target, bool saveAssets)
		{
		}

		public static void UndoRecordObject(Object objectToUndo, string undoMessage)
		{
		}

		public static void UndoRecordObject(Object objectToUndo, string undoMessage, bool saveAssets)
		{
		}

		public static void UndoRecordObjects(Object[] objectsToUndo, string undoMessage)
		{
		}

		public static void UndoRecordObjects(Object[] objectsToUndo, string undoMessage, bool saveAssets)
		{
		}
	}
}
