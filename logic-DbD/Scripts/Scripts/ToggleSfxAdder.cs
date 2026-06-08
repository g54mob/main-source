using UnityEngine;
using UnityEngine.UI;

public class ToggleSfxAdder : MonoBehaviour
{
	private static Notification notification;

	public void Start()
	{
		if (notification == null)
		{
			notification = SoundEffectUtils.GetNotificationPlayer();
		}
		AddToggleListener(GetComponent<Toggle>());
	}

	public void AddToggleListener(Toggle toggle)
	{
		toggle.onValueChanged.AddListener(notification.PlayToggle);
	}
}
