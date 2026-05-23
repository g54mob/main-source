using UnityEngine;

public class NotifyPlayer : MonoBehaviour
{
	private PlayerController playerController;

	[TextArea]
	[SerializeField]
	private string notificationText;

	[SerializeField]
	private int notificationDuration;

	[SerializeField]
	private bool destroyAfterNotified = true;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerController.ScreenNoteManagerScript.ShowNoteNotification(notificationText, notificationDuration);
			if (destroyAfterNotified)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
