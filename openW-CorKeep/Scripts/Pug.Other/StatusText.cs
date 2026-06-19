using UnityEngine;

public class StatusText : MonoBehaviour
{
	public PugText text;

	public PugText outlineText;

	public GameObject container;

	private const string YOU_ARE_IN_GUEST_MODE = "youAreInGuestMode";

	private void LateUpdate()
	{
		PlayerController player = Manager.main.player;
		if (player != null && player.guestMode)
		{
			container.SetActive(value: true);
			text.Render("youAreInGuestMode");
			outlineText.Render("youAreInGuestMode");
		}
		else
		{
			container.SetActive(value: false);
		}
		container.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
	}
}
