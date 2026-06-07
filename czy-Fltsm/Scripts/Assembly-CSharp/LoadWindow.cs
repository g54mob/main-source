using M4.Session;
using TMPro;
using UnityEngine;

public class LoadWindow : PauseMenuWindow
{
	[SerializeField]
	private CommunitySavesOverview _communitySavesOverview;

	[SerializeField]
	private CommunitySaveGroupOverview _communitySaveGroupOverview;

	[SerializeField]
	private TextMeshProUGUI _path;

	protected override void OnEnable()
	{
		base.OnEnable();
		_communitySavesOverview.OnSelectedEvent.AddListener(OpenCommunitySaveGroup);
		_communitySaveGroupOverview.OnCloseEvent.AddListener(OpenCommunitySaveOverview);
		_path.text = "Obsolete";
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		_communitySavesOverview.OnSelectedEvent.RemoveListener(OpenCommunitySaveGroup);
		_communitySaveGroupOverview.OnCloseEvent.RemoveListener(OpenCommunitySaveOverview);
	}

	public void Open()
	{
		OpenCommunitySaveOverview();
		base.gameObject.SetActive(value: true);
	}

	public void OpenSaveFolder()
	{
		RuntimePlatform platform = Application.platform;
		if (platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor)
		{
			Extensions.ShowExplorer(SaveInfo.PLAYER_SAVES_DIRECTORY);
		}
		else if ((bool)_path)
		{
			_path.gameObject.SetActive(value: true);
			_path.text = SaveInfo.PLAYER_SAVES_DIRECTORY;
		}
	}

	private void OpenCommunitySaveOverview()
	{
		_communitySavesOverview.Open(Session.Runs);
		_communitySaveGroupOverview.gameObject.SetActive(value: false);
	}

	private void OpenCommunitySaveGroup(PlayerRun run)
	{
		_communitySaveGroupOverview.Open(run);
		_communitySavesOverview.gameObject.SetActive(value: false);
	}
}
