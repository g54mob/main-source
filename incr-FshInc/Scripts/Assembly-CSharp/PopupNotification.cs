using System.Collections;
using TMPro;
using UnityEngine;

public class PopupNotification : MonoBehaviour
{
	public float floatSpeed = 1f;

	public float fadeDuration = 1.5f;

	private TextMeshProUGUI notificationText;

	private Color startColor;

	private void Awake()
	{
		notificationText = GetComponent<TextMeshProUGUI>();
		if (notificationText != null)
		{
			startColor = notificationText.color;
		}
	}

	public void Setup(string text, Color color)
	{
		if (notificationText != null)
		{
			notificationText.text = text;
			notificationText.color = color;
			startColor = color;
		}
		StartCoroutine(AnimatePopup());
	}

	private IEnumerator AnimatePopup()
	{
		float timer = 0f;
		while (timer < fadeDuration)
		{
			base.transform.position += Vector3.up * floatSpeed * Time.deltaTime;
			float a = Mathf.Lerp(startColor.a, 0f, timer / fadeDuration);
			notificationText.color = new Color(startColor.r, startColor.g, startColor.b, a);
			timer += Time.deltaTime;
			yield return null;
		}
		Object.Destroy(base.gameObject);
	}
}
