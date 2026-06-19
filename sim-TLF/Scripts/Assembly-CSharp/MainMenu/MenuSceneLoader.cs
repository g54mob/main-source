using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
	public class MenuSceneLoader : MonoBehaviour
	{
		[SerializeField]
		private float _loadDelay = 1.5f;

		public async void LoadSceneAsync(string name)
		{
			await UniTask.WaitForSeconds(_loadDelay);
			await LoadSceneAsyncTask(name);
		}

		public async UniTask LoadSceneAsyncTask(string sceneName)
		{
			AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
			asyncOp.allowSceneActivation = false;
			await UniTask.WaitUntil(() => asyncOp.progress >= 0.9f);
			asyncOp.allowSceneActivation = true;
			await asyncOp;
			Debug.Log(sceneName + " loaded additively!");
		}

		public void UnloadSceneAsync(int index)
		{
			SceneManager.UnloadSceneAsync(index);
		}
	}
}
