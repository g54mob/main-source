using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services.Save
{
	public class SceneGameLoader : MonoBehaviour
	{
		[Inject]
		private ISaveService _saveService;

		private async void Start()
		{
			Debug.Log("[Active Scene Name:] " + SceneManager.GetActiveScene().name);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("World"));
			Debug.Log("[Active Scene Name:] " + SceneManager.GetActiveScene().name);
			CursorLockKeeper.Ensure();
			CursorLockKeeper.Apply(CursorLockMode.Locked, visible: false);
			await _saveService.LoadAllAsync();
			if (SceneManager.sceneCount > 1)
			{
				Debug.Log("[Scene] Unloading of 0 completed");
				SceneManager.UnloadSceneAsync(0).ToUniTask().Forget();
			}
		}
	}
}
