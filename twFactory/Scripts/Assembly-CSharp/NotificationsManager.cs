using UnityEngine;

public class NotificationsManager : MonoBehaviour
{
	[SerializeField]
	private NotificationUI notificationUI;

	[SerializeField]
	private float defaultNotificationTime = 2f;

	[SerializeField]
	private Color defaultColor = Color.white;

	[SerializeField]
	private AudioData defaultSound;

	[SerializeField]
	private Color errorColor = Color.red;

	[SerializeField]
	private AudioData errorSound;

	[SerializeField]
	private Color moneyColor = Color.red;

	[SerializeField]
	private AudioData moneySound;

	public void ShowNotification(string message, ENotificationType notificationType)
	{
		ShowNotification(message, notificationType, defaultNotificationTime);
	}

	public void ShowNotification(string message, ENotificationType notificationType, float time)
	{
		notificationUI.ShowNotification(message, GetTypeColor(notificationType), time);
		AudioSystem.Instance.PlaySound2D(GetTypeSound(notificationType), AudioSystem.EAudioMixerGroup.UI, 0f, 0f, loop: false, AudioSystem.EAudioPriority.High);
	}

	private Color GetTypeColor(ENotificationType notificationType)
	{
		return notificationType switch
		{
			ENotificationType.Default => defaultColor, 
			ENotificationType.Error => errorColor, 
			ENotificationType.Money => moneyColor, 
			_ => defaultColor, 
		};
	}

	private AudioData GetTypeSound(ENotificationType notificationType)
	{
		return notificationType switch
		{
			ENotificationType.Default => defaultSound, 
			ENotificationType.Error => errorSound, 
			ENotificationType.Money => moneySound, 
			_ => defaultSound, 
		};
	}
}
