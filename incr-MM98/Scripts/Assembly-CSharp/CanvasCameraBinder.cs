using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class CanvasCameraBinder : MonoBehaviour
{
	private Canvas _canvas;

	private void Awake()
	{
		_canvas = GetComponent<Canvas>();
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
		BindCamera();
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		BindCamera();
	}

	private void BindCamera()
	{
		_canvas.renderMode = RenderMode.ScreenSpaceCamera;
		_canvas.worldCamera = Camera.main;
	}
}
