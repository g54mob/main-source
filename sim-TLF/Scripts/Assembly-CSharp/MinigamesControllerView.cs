using Minigames;
using UnityEngine;

public class MinigamesControllerView : MonoBehaviour
{
	[SerializeField]
	private WrenchMinigameView _wrenchMinigameView;

	[SerializeField]
	private ScrewdriverMinigameView _screwdriverMinigameView;

	public ScrewdriverMinigameView ScrewdriverMinigame => _screwdriverMinigameView;

	public WrenchMinigameView WrenchMinigame => _wrenchMinigameView;

	private void Awake()
	{
		_screwdriverMinigameView.Init();
		_wrenchMinigameView.Init();
	}

	public void EnableWrenchMinigame(float progress)
	{
		_wrenchMinigameView.gameObject.SetActive(value: true);
		_wrenchMinigameView.SetProgress(progress);
	}

	public void DisableWrenchMinigame()
	{
		_wrenchMinigameView.gameObject.SetActive(value: false);
	}

	public void EnableScrewdriverMinigame(float progress)
	{
		_screwdriverMinigameView.gameObject.SetActive(value: true);
		_screwdriverMinigameView.SetProgress(progress);
	}

	public void DisableScrewMinigame()
	{
		_screwdriverMinigameView.gameObject.SetActive(value: false);
	}
}
