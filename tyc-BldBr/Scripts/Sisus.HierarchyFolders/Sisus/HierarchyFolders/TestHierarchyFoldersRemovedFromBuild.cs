using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sisus.HierarchyFolders
{
	public class TestHierarchyFoldersRemovedFromBuild : MonoBehaviour
	{
		[SerializeField]
		private float delay;

		private void Awake()
		{
			if (delay <= 0f)
			{
				Test();
			}
		}

		private IEnumerator Start()
		{
			if (!(delay <= 0f))
			{
				yield return new WaitForSeconds(delay);
				Test();
			}
		}

		private void Test()
		{
			int num = Object.FindObjectsOfType<HierarchyFolder>().Length;
			Scene activeScene = SceneManager.GetActiveScene();
			if (num > 0)
			{
				Debug.LogError($"Number of Hierarchy Folders in scene: {num}\nScene name: \"{activeScene.name}\"", this);
			}
			else
			{
				Debug.Log($"Number of Hierarchy Folders in scene: 0\nScene name: \"{activeScene.name}\"", this);
			}
			StringBuilder stringBuilder = new StringBuilder();
			GameObject[] rootGameObjects = activeScene.GetRootGameObjects();
			foreach (GameObject gameObject in rootGameObjects)
			{
				stringBuilder.Append('\n');
				stringBuilder.Append(gameObject.name);
			}
			Debug.Log($"{activeScene.name} root GameObjects: {stringBuilder.ToString()}");
		}
	}
}
