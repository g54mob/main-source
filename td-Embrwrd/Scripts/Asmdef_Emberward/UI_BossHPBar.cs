using TMPro;
using UnityEngine;

public class UI_BossHPBar : APopupWindow
{
	[SerializeField]
	private TMP_Text text_BossName;

	[SerializeField]
	private TMP_Text text_HPValue;

	[SerializeField]
	private RectTransform rect_BossHPBar;

	[SerializeField]
	private RectTransform rect_BossHPBar_BG;

	[SerializeField]
	private float barWidth;

	private AMonsterBase targetMonster;

	public void Setup(AMonsterBase targetMonster)
	{
	}

	private void OnMonsterHPChange()
	{
	}

	public void UpdateValue(int curHp, int maxHP, float percentage)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
