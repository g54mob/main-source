using TMPro;
using UnityEngine;

public class NotificationUI : MonoBehaviour
{
	[Header("Notification Settings")]
	public GameObject notificationPanel;

	public TextMeshProUGUI notificationText;

	public float displayDuration = 2f;

	[Header("Computer Notification Settings")]
	public GameObject notificationComputerPanel;

	public TextMeshProUGUI notificationComputerText;

	[Header("Audio")]
	public AudioSource audioSource;

	public AudioClip notificationSound;
}
