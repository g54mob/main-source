using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagersInstance : NetworkSingleton<ManagersInstance>
{
	protected override void OnAwake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "NetworkSetupScene")
		{
			Object.Destroy(base.gameObject);
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
