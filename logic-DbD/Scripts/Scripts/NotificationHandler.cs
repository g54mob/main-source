using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationHandler : MonoBehaviour
{
	public enum Icon
	{
		EMPTY_RESULTS = 0,
		ERROR = 1,
		WARNING = 2,
		DOWNLOAD_SUCCESS = 3,
		GENERIC_SUCCESS = 4
	}

	[SerializeField]
	private GameObject notificationPanelPrefab;

	private Canvas canvas;

	private Notification audioPlayer;

	private const int VERTICAL_MARGIN = 90;

	private const int MIN_HEIGHT = 250;

	private const int HORIZONTAL_SIZE = 565;

	private void Start()
	{
		audioPlayer = SoundEffectUtils.GetNotificationPlayer();
		canvas = UIUtils.FindCanvasFromChild(base.transform);
	}

	public GameObject CreateNotificationPanel()
	{
		return CreateNotificationPanel(string.Empty);
	}

	public GameObject CreateNotificationPanel(string message, bool playError = true)
	{
		if (playError)
		{
			audioPlayer.PlayError();
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(notificationPanelPrefab, base.transform.position, Quaternion.identity, canvas.transform);
		UIUtils.SetPenultimateLayer(gameObject);
		SetNotificationMessage(gameObject, message);
		SetNotificationIcon(gameObject, Icon.ERROR);
		return gameObject;
	}

	public GameObject CreateNotificationPanel(string toolbar, Icon icon, string message)
	{
		if (icon == Icon.EMPTY_RESULTS)
		{
			audioPlayer.PlayEmptyResults();
		}
		else
		{
			audioPlayer.PlayWarning();
		}
		GameObject gameObject = CreateNotificationPanel(message, playError: false);
		SetToolbarName(gameObject, toolbar);
		SetNotificationIcon(gameObject, icon);
		return gameObject;
	}

	public void SetToolbarName(GameObject notificationPanel, string name)
	{
		notificationPanel.transform.Find("Toolbar/Window Name").GetComponent<TextMeshProUGUI>().text = name;
	}

	public void SetNotificationMessage(GameObject notificationPanel, string message)
	{
		notificationPanel.transform.Find("Message").GetComponent<TextMeshProUGUI>().text = message;
	}

	public void SetNotificationIcon(GameObject notificationPanel, Icon icon)
	{
		DisableIcons(notificationPanel);
		GetIcon(notificationPanel, icon).enabled = true;
		ResizePopup(notificationPanel);
	}

	public void ResizePopup(GameObject notificationPanel)
	{
		RectTransform component = notificationPanel.GetComponent<RectTransform>();
		float size = Mathf.Max(notificationPanel.transform.Find("Message").GetComponent<TextMeshProUGUI>().preferredHeight + 90f, 250f);
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 565f);
	}

	private Image GetIcon(GameObject notificationPanel, Icon icon)
	{
		return icon switch
		{
			Icon.EMPTY_RESULTS => notificationPanel.transform.Find("Empty Icon").GetComponent<Image>(), 
			Icon.ERROR => notificationPanel.transform.Find("Error Icon").GetComponent<Image>(), 
			Icon.WARNING => notificationPanel.transform.Find("Warning Icon").GetComponent<Image>(), 
			_ => throw new ArgumentException("Invalid Icon enum given."), 
		};
	}

	private void DisableIcons(GameObject notificationPanel)
	{
		GetIcon(notificationPanel, Icon.EMPTY_RESULTS).enabled = false;
		GetIcon(notificationPanel, Icon.ERROR).enabled = false;
		GetIcon(notificationPanel, Icon.WARNING).enabled = false;
	}
}
