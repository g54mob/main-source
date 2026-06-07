using UnityEngine;

public class LoadoutUI : OverlayUI
{
	public static LoadoutUI I;

	public CoolButton BtnClose;

	[Header("Main")]
	public CharInfoPanel CharPanel;

	public CharInfoPanel Char2Panel;

	public GameObject WrapperSecondStarter;

	public EquippedCharBtn[] EquippedChars;

	public CoolButton BtnConfirm;

	private int _selectedPetIdx;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	public void SelectEquippedCharSlot(EquippedCharBtn btn)
	{
	}

	private void OnCloseClicked()
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	private void OnConfirmClicked()
	{
	}
}
