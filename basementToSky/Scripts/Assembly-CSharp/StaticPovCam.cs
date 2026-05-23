using UnityEngine;

public class StaticPovCam : MonoBehaviour
{
	public static StaticPovCam S;

	private void Awake()
	{
		if (S != null && S != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		S = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
	}

	private void OnDestroy()
	{
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
	}

	private void PauseUI_OnSaveAndQuit()
	{
		Object.Destroy(base.gameObject);
	}

	private void Update()
	{
	}
}
