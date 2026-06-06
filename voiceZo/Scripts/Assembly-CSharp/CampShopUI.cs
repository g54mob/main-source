using System.Collections.Generic;
using UnityEngine;

public class CampShopUI : MonoBehaviour
{
	[SerializeField]
	private List<CampCell> _campCellList;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnClickCloseButton();
		}
	}

	public void Show()
	{
		foreach (CampCell campCell in _campCellList)
		{
			campCell.Init(OnClickCloseButton);
			campCell.UpdateUI();
		}
		base.gameObject.SetActive(value: true);
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_PaperShow);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void UpdateCampCells(long currentGold = 0L)
	{
		foreach (CampCell campCell in _campCellList)
		{
			campCell.UpdateUI();
		}
	}

	public void OnClickCloseButton()
	{
		Hide();
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Down);
	}
}
