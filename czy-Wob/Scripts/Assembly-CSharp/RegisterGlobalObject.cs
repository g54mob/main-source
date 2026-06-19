using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterGlobalObject : MonoBehaviour
{
	public GlobalObject objectType;

	public bool autoRegisterOnSceneLoad;

	private void Start()
	{
		if (autoRegisterOnSceneLoad)
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		ObjectRegistration.GetRegistrationScript().RegisterGlobalObject(base.gameObject, objectType);
	}

	public void Register(ObjectRegistration registry)
	{
		registry.RegisterGlobalObject(base.gameObject, objectType);
	}
}
