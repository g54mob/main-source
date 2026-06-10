using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationController : MonoBehaviour
{
	[Header("Components")]
	public TextMeshProUGUI numberText;

	public JuiceController juice;

	public RectTransform glowRect;

	public Image glowImg;

	public RectTransform HUDNotificationsIcon;

	[Header("State")]
	private float time;

	public int notifications;

	private void OnEnable()
	{
	}

	public void AddNotification(int val)
	{
	}

	public void SetNotifications(int val)
	{
	}

	public void UpdateNotifications()
	{
	}

	private void Update()
	{
	}
}
