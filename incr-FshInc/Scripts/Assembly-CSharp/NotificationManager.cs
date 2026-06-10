using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
	private struct NotificationRequest
	{
		public string text;

		public Vector3 position;

		public Color color;
	}

	public GameObject notificationPrefab;

	public Canvas parentCanvas;

	private Queue<NotificationRequest> notificationQueue = new Queue<NotificationRequest>();

	private bool isProcessing;

	public float staggerDelay = 0.25f;

	public static NotificationManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	public void ClearQueue()
	{
		notificationQueue.Clear();
	}

	public void ShowNotification(string text, Vector3 worldPosition, Color color)
	{
		float num = ((Random.value > 0.5f) ? 1f : (-1f));
		float x = Random.Range(50f, 150f) * num;
		notificationQueue.Enqueue(new NotificationRequest
		{
			text = text,
			position = new Vector3(x, worldPosition.y, worldPosition.z),
			color = color
		});
		if (!isProcessing)
		{
			StartCoroutine(ProcessQueue());
		}
	}

	private IEnumerator ProcessQueue()
	{
		isProcessing = true;
		while (notificationQueue.Count > 0)
		{
			NotificationRequest request = notificationQueue.Dequeue();
			CreatePopup(request);
			yield return new WaitForSeconds(staggerDelay);
		}
		isProcessing = false;
	}

	private void CreatePopup(NotificationRequest request)
	{
		if (notificationPrefab == null || parentCanvas == null)
		{
			Debug.LogError("Notification Prefab or Parent Canvas not set in NotificationManager!");
			return;
		}
		GameObject obj = Object.Instantiate(notificationPrefab, request.position, Quaternion.identity, parentCanvas.transform);
		obj.GetComponent<RectTransform>().anchoredPosition = request.position;
		PopupNotification component = obj.GetComponent<PopupNotification>();
		if (component != null)
		{
			component.Setup(request.text, request.color);
		}
	}
}
