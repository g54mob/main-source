using System;
using System.Collections;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-999)]
public class LoadingScreen : MonoBehaviour
{
	[SerializeField]
	private float loadingScreenDuration = 0.2f;

	[SerializeField]
	private FullScreenPassRendererFeature loadingScreen;

	[SerializeField]
	private Material material;

	[SerializeField]
	private EventSystem eventSystem;

	private void Awake()
	{
		loadingScreen.passMaterial = new Material(material);
	}

	public void LoadScene(string scene, bool instant = false)
	{
		if (instant)
		{
			loadingScreen.passMaterial.SetFloat(Constants.MaterialProperties.State, 1f);
		}
		Debug.Log("Loading scene: " + scene);
		MessagePipeConfiguration.InitializeSceneMessagePipe();
		ShowLoadingScreen(instant ? 0f : loadingScreenDuration, delegate
		{
			StartCoroutine(HandleSceneLoad(scene));
		});
	}

	private IEnumerator HandleSceneLoad(string scene)
	{
		yield return null;
		SceneManager.LoadScene(scene);
		yield return null;
		EventHub.Persistent.Publish(new SceneLoaded(scene));
		HideLoadingScreen(loadingScreenDuration);
	}

	public void ShowLoadingScreen(float duration, Action callback = null)
	{
		eventSystem.enabled = false;
		LMotion.Create(0f, 1f, duration).WithEase(Ease.InQuad).WithOnComplete(delegate
		{
			callback?.Invoke();
		})
			.BindToMaterialFloat(loadingScreen.passMaterial, Constants.MaterialProperties.State);
	}

	public void HideLoadingScreen(float duration, Action callback = null)
	{
		LMotion.Create(1f, 0f, duration).WithEase(Ease.OutQuad).WithOnComplete(delegate
		{
			eventSystem.enabled = true;
			callback?.Invoke();
		})
			.BindToMaterialFloat(loadingScreen.passMaterial, Constants.MaterialProperties.State);
	}
}
