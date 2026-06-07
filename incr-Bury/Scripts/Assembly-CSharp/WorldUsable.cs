using UnityEngine;
using UnityEngine.Events;

public class WorldUsable : MonoBehaviour
{
	public UnityEvent OnUse;

	private bool _hasUsed;

	public void Use()
	{
		OnUse?.Invoke();
	}

	public void PiggyBank_RetrieveMoney()
	{
		if (PlayerStats.Singleton.piggyBank_CurrentlyStored > 0)
		{
			PlayerStats.Singleton.IncreaseMoney_Banked(PlayerStats.Singleton.piggyBank_CurrentlyStored);
			PlayerStats.Singleton.piggyBank_CurrentlyStored = 0;
		}
	}

	public void Radio_PowerToggle()
	{
		GameManager.Singleton.radioInScene.ToggleRadio();
	}

	public void Radio_ChannelUp()
	{
		GameManager.Singleton.radioInScene.ChangeRadioChannel_Up();
	}

	public void Radio_ChannelDown()
	{
		GameManager.Singleton.radioInScene.ChangeRadioChannel_Down();
	}

	public void Bed_EndRound()
	{
		if (!_hasUsed)
		{
			_hasUsed = true;
			VcrIntroManager.Singleton.PlayTapeWindDownSFX();
			GameManager.Singleton.ForceEndRound(_fromBed: true);
		}
	}

	public void NarrativeObject_Show(int _uiIndex)
	{
		HudManager.Singleton.ShowUiGroup_Narrative(_uiIndex);
	}

	public void BerryPicker_ButtonUp()
	{
		GameManager.Singleton.berryPickerInScene.Button_Up();
	}

	public void BerryPicker_ButtonDown()
	{
		GameManager.Singleton.berryPickerInScene.Button_Down();
	}
}
