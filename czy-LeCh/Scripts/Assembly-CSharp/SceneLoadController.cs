using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadController : MonoBehaviour
{
	[SerializeField]
	private string sceneToLoad;

	[SerializeField]
	private GameObject loadingPreviewObject;

	[SerializeField]
	private Image loadProgressBar;

	private float _target;

	private void Start()
	{
		LoadScene();
	}

	public async void LoadScene()
	{
		AsyncOperation scene = SceneManager.LoadSceneAsync(sceneToLoad);
		scene.allowSceneActivation = false;
		loadingPreviewObject.SetActive(value: true);
		do
		{
			await Task.Delay(10);
			_target = scene.progress;
		}
		while (scene.progress < 0.9f);
		scene.allowSceneActivation = true;
		loadingPreviewObject.SetActive(value: false);
	}

	private void Update()
	{
		loadProgressBar.fillAmount = Mathf.MoveTowards(loadProgressBar.fillAmount, _target, 3f * Time.deltaTime);
	}
}
