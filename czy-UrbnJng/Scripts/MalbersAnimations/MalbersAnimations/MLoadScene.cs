using UnityEngine;
using UnityEngine.SceneManagement;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Managers/Load Scene")]
	public class MLoadScene : MonoBehaviour
	{
		[HelpBox]
		public string descr = "The Scene must be added to the Build Settings!";

		[HideInInspector]
		public string sceneName;

		[MButton("LoadScene", true)]
		public bool LoadButton;

		public void LoadScene()
		{
			if (!string.IsNullOrEmpty(sceneName))
			{
				SceneManager.LoadScene(sceneName);
			}
		}
	}
}
