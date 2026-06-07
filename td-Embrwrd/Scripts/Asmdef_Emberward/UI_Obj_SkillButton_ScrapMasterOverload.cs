using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_SkillButton_ScrapMasterOverload : UI_Obj_SkillButton
{
	[SerializeField]
	private Image image_BorderGlow;

	[SerializeField]
	private GameObject node_GuideArrows;

	private bool isUsedScrapMasterBefore;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnScrapMasterMachineControlChanged(bool isInControl)
	{
	}

	protected override void InitProc()
	{
	}

	protected override void OnCharacterChangedProc(eCharacterType characterType)
	{
	}

	protected void UpdateCharacterLimit(eCharacterType characterType)
	{
	}

	protected override bool IsUnlocked()
	{
		return false;
	}

	protected override void OnSkillUsedProc()
	{
	}

	protected override void StartTargetSelectionProc()
	{
	}
}
