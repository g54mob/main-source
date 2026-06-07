using UnityEngine;
using UnityEngine.UI;

public class UI_CustomGameSelect_Popup : APopupWindow
{
	[SerializeField]
	private Image image_ScenePhoto;

	[SerializeField]
	private Transform node_TowerCards;

	[SerializeField]
	private Transform node_TetrisCards;

	[SerializeField]
	private Transform node_Relics;

	[SerializeField]
	private GameObject prefab_Card;

	[SerializeField]
	private GameObject prefab_RelicItem;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public static int GetTodaySeed()
	{
		return 0;
	}

	private void GetDailyChallengeData(int daySeed, eStageDifficulty difficulty)
	{
	}

	private void VisualizeDailyChallengeData(DailyChallengeData data)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
