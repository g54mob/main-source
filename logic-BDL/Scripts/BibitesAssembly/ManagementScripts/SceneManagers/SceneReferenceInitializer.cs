using UnityEngine;
using UnityEngine.UI;

namespace ManagementScripts.SceneManagers
{
	public class SceneReferenceInitializer : MonoBehaviour
	{
		public Text saveSystemStatus;

		public static SceneReferenceInitializer Instance;

		private void Awake()
		{
			Instance = this;
		}
	}
}
