using System.Collections;
using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
	public static NotificationManager Instance;

	public GameManager gameManager;

	private Coroutine currentNotificationCoroutine;

	private Coroutine currentComputerNotificationCoroutine;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			if (gameManager.UImanager.notificationUI != null)
			{
				gameManager.UImanager.notificationUI.notificationPanel.SetActive(value: false);
				if (gameManager.UImanager.notificationUI.notificationComputerPanel != null)
				{
					gameManager.UImanager.notificationUI.notificationComputerPanel.SetActive(value: false);
				}
			}
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void ShowNotification(string message, bool isComputer = false, float durationTime = -1f)
	{
		if (string.IsNullOrEmpty(message))
		{
			Debug.LogWarning("NotificationManager: Mesaj boş!");
			return;
		}
		float durationTime2 = ((durationTime > 0f) ? durationTime : gameManager.UImanager.notificationUI.displayDuration);
		if (isComputer)
		{
			if (currentComputerNotificationCoroutine != null)
			{
				StopCoroutine(currentComputerNotificationCoroutine);
			}
			currentComputerNotificationCoroutine = StartCoroutine(DisplayNotification(message, durationTime2, isComputer: true));
		}
		else
		{
			if (currentNotificationCoroutine != null)
			{
				StopCoroutine(currentNotificationCoroutine);
			}
			currentNotificationCoroutine = StartCoroutine(DisplayNotification(message, durationTime2, isComputer: false));
		}
	}

	private IEnumerator DisplayNotification(string message, float durationTime, bool isComputer)
	{
		GameObject panel = (isComputer ? gameManager.UImanager.notificationUI.notificationComputerPanel : gameManager.UImanager.notificationUI.notificationPanel);
		TextMeshProUGUI textMeshProUGUI = (isComputer ? gameManager.UImanager.notificationUI.notificationComputerText : gameManager.UImanager.notificationUI.notificationText);
		if (panel == null || textMeshProUGUI == null)
		{
			Debug.LogError("NotificationManager: " + (isComputer ? "notificationComputerPanel/Text" : "notificationPanel/Text") + " null!");
			if (isComputer)
			{
				currentComputerNotificationCoroutine = null;
			}
			else
			{
				currentNotificationCoroutine = null;
			}
			yield break;
		}
		textMeshProUGUI.text = message;
		PlayNotificationSound();
		panel.SetActive(value: true);
		yield return new WaitForSeconds(durationTime);
		panel.SetActive(value: false);
		if (isComputer)
		{
			currentComputerNotificationCoroutine = null;
		}
		else
		{
			currentNotificationCoroutine = null;
		}
	}

	private void PlayNotificationSound()
	{
		if (gameManager.UImanager.notificationUI.audioSource != null && gameManager.UImanager.notificationUI.notificationSound != null)
		{
			gameManager.UImanager.notificationUI.audioSource.PlayOneShot(gameManager.UImanager.notificationUI.notificationSound);
		}
	}

	public void ClearNotificationQueue(bool isComputer = false)
	{
		if (isComputer)
		{
			if (currentComputerNotificationCoroutine != null)
			{
				StopCoroutine(currentComputerNotificationCoroutine);
				currentComputerNotificationCoroutine = null;
			}
			if (gameManager.UImanager.notificationUI.notificationComputerPanel != null)
			{
				gameManager.UImanager.notificationUI.notificationComputerPanel.SetActive(value: false);
			}
		}
		else
		{
			if (currentNotificationCoroutine != null)
			{
				StopCoroutine(currentNotificationCoroutine);
				currentNotificationCoroutine = null;
			}
			if (gameManager.UImanager.notificationUI.notificationPanel != null)
			{
				gameManager.UImanager.notificationUI.notificationPanel.SetActive(value: false);
			}
		}
	}
}
