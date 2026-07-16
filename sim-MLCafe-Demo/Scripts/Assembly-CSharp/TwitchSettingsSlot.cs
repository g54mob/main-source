using TMPro;
using UnityEngine;

public class TwitchSettingsSlot : MonoBehaviour
{
	public TMP_Text labelTitle;

	public LocaleStringEvent labelDescription;

	public ToggleSwitch toggleActiveState;

	public SliderField sliderCooldown;

	private int index = -1;

	private TwitchGameSettingsComponent settingsComponent;

	public void InitSlot(int index, TwitchGameSettingsComponent settingsComponent)
	{
		this.index = index;
		this.settingsComponent = settingsComponent;
		labelTitle.text = TW_GlobalCommands.GetPrimaryCommandLetter() + TwitchCommandList.GetCommandByIndex(index).command;
		labelDescription.SetNewKey(TwitchCommandList.GetCommandByIndex(index).description);
	}

	public void OnUpdateActiveState(bool active)
	{
		settingsComponent.OnUpdateCommandActiveState(index, active);
	}

	public void OnUpdateCooldown(float cooldown)
	{
		settingsComponent.OnUpdateCommandCooldown(index, cooldown);
	}
}
