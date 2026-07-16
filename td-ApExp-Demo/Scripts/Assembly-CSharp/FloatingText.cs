using System;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
	[SerializeField]
	private GameObject floatingTextPrefab;

	[SerializeField]
	private Vector2 startOffset;

	[SerializeField]
	private Vector2 endOffset;

	[SerializeField]
	private float duration;

	public void SpawnFloatingText(Vector2 worldPos, string text)
	{
		GameObject floatingTextGo = UnityEngine.Object.Instantiate(floatingTextPrefab, worldPos, Quaternion.identity, base.transform);
		RectTransform component = floatingTextGo.GetComponent<RectTransform>();
		TextMeshProUGUI floatingText = floatingTextGo.GetComponent<TextMeshProUGUI>();
		floatingText.text = text;
		Vector2 vector = Camera.main.WorldToViewportPoint(worldPos + startOffset);
		_ = base.transform;
		component.anchorMin = vector;
		component.anchorMax = vector;
		component.anchoredPosition = Vector2.zero;
		Vector3 to = component.anchoredPosition + endOffset;
		LeanTween.move(component, to, duration).setEaseOutCubic();
		Color color = floatingText.color;
		LeanTween.value(to: new Color(color.r, color.g, color.b, 0f), gameObject: base.gameObject, from: color, time: duration).setOnUpdate(delegate(Color val)
		{
			floatingText.color = val;
		}).setEaseOutCubic();
		LeanTween.delayedCall(duration, (Action)delegate
		{
			UnityEngine.Object.Destroy(floatingTextGo);
		});
	}
}
