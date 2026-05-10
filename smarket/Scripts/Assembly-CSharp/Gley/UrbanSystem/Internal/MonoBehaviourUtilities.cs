using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public class MonoBehaviourUtilities : MonoBehaviour
	{
		private static GameObject _parent;

		public static T GetOrCreateSceneInstance<T>(string path, bool addEditorTag) where T : MonoBehaviour
		{
			return null;
		}

		public static T GetOrCreateObjectScript<T>(string holderName, bool addEditorTag) where T : MonoBehaviour
		{
			return null;
		}

		public static T GetOrCreateObjectScript<T>(GameObject holder) where T : MonoBehaviour
		{
			return null;
		}

		public static GameObject GetOrCreateGameObject(string path, bool addEditorTag)
		{
			return null;
		}

		public static GameObject CreateGameObject(string name, Transform parent, Vector3 position, bool addEditorTag)
		{
			return null;
		}

		public static bool TryGetSceneScript<T>(out ExecutionResult<T> result) where T : MonoBehaviour
		{
			result = default(ExecutionResult<T>);
			return false;
		}

		public static bool TryGetObjectScript<T>(string holderName, out ExecutionResult<T> result) where T : MonoBehaviour
		{
			result = default(ExecutionResult<T>);
			return false;
		}

		public static bool TryGetObjectScript<T>(GameObject holder, out ExecutionResult<T> result) where T : MonoBehaviour
		{
			result = default(ExecutionResult<T>);
			return false;
		}

		public static bool TryGetObject(string path, out ExecutionResult<GameObject> result)
		{
			result = default(ExecutionResult<GameObject>);
			return false;
		}

		public static T[] FindObjectsByType<T>() where T : MonoBehaviour
		{
			return null;
		}

		private static Transform FindOrCreate(Transform parent, string gameObjectName, bool editor)
		{
			return null;
		}
	}
}
