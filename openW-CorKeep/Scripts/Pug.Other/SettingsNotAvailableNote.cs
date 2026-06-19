using UnityEngine;

public class SettingsNotAvailableNote : MonoBehaviour
{
	public RadicalMenuOption enableWhenOptionIsActive;

	public PugText text;

	private void Update()
	{
		text.gameObject.SetActive(enableWhenOptionIsActive.GetActiveStateInCurrentScene() == OptionActiveState.GRAYED_OUT);
	}
}
