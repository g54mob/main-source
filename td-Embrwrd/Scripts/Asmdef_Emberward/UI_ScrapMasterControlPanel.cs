using System.Collections.Generic;
using UnityEngine;

public class UI_ScrapMasterControlPanel : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private ScrapMasterSettingAssetData scrapMasterSettingAssetData;

	[SerializeField]
	private List<Obj_UI_ScrapMasterControlSkillIcon> list_SkillIcons;

	private bool isHideCommonIngameUI;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnHideCommonIngameUI()
	{
	}

	private void Start()
	{
	}

	private void OnRequestShowScrapMasterMachineUI()
	{
	}

	private void OnRequestHideScrapMasterMachineUI()
	{
	}

	private void OnScrapMasterLevelUpComplete()
	{
	}

	private void UpdateIcons()
	{
	}

	private void SetupSkillIcons()
	{
	}
}
