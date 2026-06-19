using UnityEngine;

public class TriggerPlayerCustomizationUpdateWhenEnabled : MonoBehaviour
{
	public PlayerController player;

	private void OnEnable()
	{
		player.RefreshCustomization();
	}
}
