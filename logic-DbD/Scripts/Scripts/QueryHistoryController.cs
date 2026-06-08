using UnityEngine;

public class QueryHistoryController : MonoBehaviour
{
	[SerializeField]
	private GameObject queryHistoryPanel;

	[SerializeField]
	private TaskbarManager taskbarManager;

	[SerializeField]
	private Sprite queryHistoryTaskbarSprite;

	private ClosePanelAudio audioPlayer;

	private void Start()
	{
		audioPlayer = SoundEffectUtils.GetOpenClosePanelPlayer();
	}

	public void CreatePanel()
	{
		if (!taskbarManager.IsMaximumTaskbarButtons(queryHistoryPanel))
		{
			audioPlayer.PlayOpen();
			PanelManager.OpenWindow(queryHistoryPanel);
			taskbarManager.AddTaskbar(queryHistoryPanel, queryHistoryTaskbarSprite, "Query History");
		}
	}
}
