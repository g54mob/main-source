using UnityEngine;

[CreateAssetMenu(menuName = "遊戲設定/回收方塊滑鼠按鍵", fileName = "GameSettingData_RecallBlockButton")]
public class GameSettingData_RecallBlockButton : GameSettingData
{
	public enum eRecallBlockButton
	{
		DEFAULT = 0,
		RIGHT_CLICK = 1
	}

	private void Reset()
	{
	}

	protected override void ApplySettingToGame()
	{
	}
}
