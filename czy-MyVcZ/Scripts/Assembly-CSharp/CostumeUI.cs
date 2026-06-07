using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeUI : MonoBehaviour
{
	[Header("cell 갯수를 CostumeID 갯수만큼 만들어주세요!")]
	[SerializeField]
	private List<CostumeCell> _costumeCells;

	[SerializeField]
	private CostumeDetailPanel _costumeDetailPanel;

	[SerializeField]
	private ScrollRect _scrollRect;

	private CostumeID _selectedCostumeID;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnClick_ExitButton();
		}
	}

	public void Show()
	{
		int num = 0;
		foreach (CostumeID value in Enum.GetValues(typeof(CostumeID)))
		{
			_costumeCells[num].Init(value, Handle_OnClickCostumeCell);
			num++;
		}
		SelectCostumeCell(MonoSingleton<CostumeManager>.Instance.EquippedCostumeID);
		switch (MonoSingleton<CostumeManager>.Instance.EquippedCostumeID)
		{
		case CostumeID.Default:
		case CostumeID.Duck:
		case CostumeID.Reindeer:
		case CostumeID.Frog:
			_scrollRect.verticalNormalizedPosition = 1f;
			break;
		case CostumeID.Cat:
			_scrollRect.verticalNormalizedPosition = 0f;
			break;
		}
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_PaperShow);
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Down);
		base.gameObject.SetActive(value: false);
	}

	private void SelectCostumeCell(CostumeID costumeID)
	{
		_selectedCostumeID = costumeID;
		foreach (CostumeCell costumeCell in _costumeCells)
		{
			costumeCell.SetSelect(_selectedCostumeID == costumeCell.CostumeID);
		}
		_costumeDetailPanel.Release();
		_costumeDetailPanel.Init(costumeID);
	}

	private void Handle_OnClickCostumeCell(CostumeID costumeID)
	{
		SelectCostumeCell(costumeID);
	}

	public void OnClick_ExitButton()
	{
		Hide();
	}
}
