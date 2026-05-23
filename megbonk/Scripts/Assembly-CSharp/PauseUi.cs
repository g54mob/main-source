using UnityEngine;

public class PauseUi : MonoBehaviour
{
	public GameObject main;

	public GameObject options;

	public GameObject map;

	private GameObject current;

	public Window mainWindow;

	public Window mapWindow;

	public UpgradeInventoryUI inventory;

	private bool wasGamePaused;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void Pause()
	{
	}

	public void Resume()
	{
	}

	public bool CanPause()
	{
		return false;
	}

	public void Exit()
	{
	}

	public void GoToMain()
	{
	}

	public void GoToOptions()
	{
	}

	public void GoToMap()
	{
	}

	private void GoToWindow(GameObject window)
	{
	}

	public void Restart()
	{
	}

	public void Toggle()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	public bool IsPaused()
	{
		return false;
	}
}
