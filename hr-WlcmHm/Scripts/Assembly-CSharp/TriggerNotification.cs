using UnityEngine;

public class TriggerNotification : MonoBehaviour
{
	[SerializeField]
	private bool isWindow = true;

	[SerializeField]
	private string notificationText;

	[SerializeField]
	private int notificationDuration;

	private GameObject busKey;

	private GameObject barnKey;

	private PlayerController playerController;

	private bool isTriggered;

	private void Start()
	{
		busKey = GameObject.Find("BusKey");
		barnKey = GameObject.Find("BarnKeys");
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	private void Update()
	{
		if (isWindow)
		{
			if (busKey == null && !isTriggered)
			{
				playerController.ScreenNoteManagerScript.ShowNoteNotification(notificationText, notificationDuration);
				isTriggered = true;
			}
		}
		else if (barnKey == null && !isTriggered)
		{
			playerController.ScreenNoteManagerScript.ShowNoteNotification(notificationText, notificationDuration);
			isTriggered = true;
		}
	}
}
