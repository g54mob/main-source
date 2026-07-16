using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : Menu
{
	[SerializeField]
	private Button startCoopButton;

	[SerializeField]
	private Button stopCoopButton;

	[SerializeField]
	private GameObject startCoopGO;

	[SerializeField]
	private GameObject stopCoopGO;

	[SerializeField]
	private Sprite normalButtonSprite;

	[SerializeField]
	private Sprite disabledButtonSprite;

	private bool blockCoop;

	protected override void OnOpen()
	{
		base.OnOpen();
		if (PlayerManager.Instance.IsCoop)
		{
			SetStopCoop();
		}
		else
		{
			SetStartCoop();
		}
	}

	private void SetStartCoop()
	{
		if (blockCoop)
		{
			stopCoopGO.SetActive(value: false);
			return;
		}
		startCoopGO.SetActive(value: true);
		stopCoopGO.SetActive(value: false);
		bool flag = LevelManager.Instance.sm.CurrentState is LevelStateStation && LevelManager.Instance.CurrentLevel.LevelType == LevelType.Hub;
		startCoopButton.enabled = flag;
		startCoopButton.interactable = flag;
		startCoopButton.image.sprite = (flag ? normalButtonSprite : disabledButtonSprite);
	}

	private void SetStopCoop()
	{
		startCoopGO.SetActive(value: false);
		stopCoopGO.SetActive(value: true);
		bool flag = LevelManager.Instance.sm.CurrentState is LevelStateStation && LevelManager.Instance.CurrentLevel.LevelType == LevelType.Hub;
		stopCoopButton.enabled = flag;
		stopCoopButton.interactable = flag;
		stopCoopButton.image.sprite = (flag ? normalButtonSprite : disabledButtonSprite);
	}

	public void StartCoopClicked()
	{
		MenuManager.Instance.OpenMenu(MenuType.ControllerChoice);
	}

	public void StopCoopClicked()
	{
		blockCoop = true;
		PlayerManager.Instance.TryEndCoop();
	}
}
