using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_NextWaveDetail_Popup : APopupWindow
{
	[SerializeField]
	private Button button_OK;

	[SerializeField]
	private GameObject prefab_MonsterDetailNameCard;

	[SerializeField]
	private Transform node_SideScrollView;

	[SerializeField]
	private Image image_Monster;

	[SerializeField]
	private TMP_Text text_Name;

	[SerializeField]
	private TMP_Text text_Stats;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	[Header("煉獄裂片額外強化的node")]
	private GameObject node_InfernalShardDescription;

	[SerializeField]
	[Header("煉獄裂片額外強化文字")]
	private TMP_Text text_InfernalShardDescription;

	private List<Obj_UI_MonsterDetailNameCard> list_MonsterDetailNameCard;

	protected override void CloseWindowProc()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	private void Update()
	{
	}

	private void Init()
	{
	}

	private void ClearMonsterDisplay()
	{
	}

	private void OnClickMonsterDetailCard(eMonsterType type)
	{
	}

	private void OnButtonOKClick()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void RebuildNavigationAndSelect()
	{
	}
}
