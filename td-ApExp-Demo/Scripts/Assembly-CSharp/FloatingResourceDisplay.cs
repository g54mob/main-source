using System;
using TMPro;
using UnityEngine;

public class FloatingResourceDisplay : MonoBehaviour
{
	[SerializeField]
	private GameObject resourceTextPrefab;

	[SerializeField]
	private Gradient colorGradient;

	[SerializeField]
	private float maxAmount = 100f;

	[SerializeField]
	private float baseFontSize = 10f;

	[SerializeField]
	private AnimationCurve sizeCurve;

	[SerializeField]
	private Vector2 startOffset = new Vector2(10f, 10f);

	private Vector2 endOffset = new Vector2(0f, 10f);

	[SerializeField]
	private float duration = 1f;

	public void SpawnResourceText(Vector2 worldPos, float amount, ResourceTypes resourceType)
	{
		if (SaveManager.Instance.ShowResourcePickupText && amount != 0f)
		{
			GameObject resourceTextGo = UnityEngine.Object.Instantiate(resourceTextPrefab, worldPos, Quaternion.identity, base.transform);
			RectTransform component = resourceTextGo.GetComponent<RectTransform>();
			TextMeshProUGUI amountText = resourceTextGo.GetComponent<TextMeshProUGUI>();
			if (HUD.Instance.IsScrambled)
			{
				amount = UnityEngine.Random.Range(0f, maxAmount);
			}
			float time = amount / maxAmount;
			amountText.text = string.Format("+{0} <sprite={1}>", amount.ToString("0.##"), (resourceType == ResourceTypes.Scrap) ? '0' : '1');
			amountText.color = colorGradient.Evaluate(time);
			amountText.fontSize = baseFontSize * sizeCurve.Evaluate(time);
			if (worldPos.y < 0f)
			{
				Vector2 vector = new Vector2(1f, -1f);
				startOffset *= vector;
				endOffset *= vector;
			}
			component.anchoredPosition += startOffset;
			Vector3 to = component.anchoredPosition + endOffset;
			LeanTween.move(component, to, duration).setEaseOutCubic();
			Color color = amountText.color;
			LeanTween.value(to: new Color(color.r, color.g, color.b, 0f), gameObject: base.gameObject, from: color, time: duration).setOnUpdate(delegate(Color val)
			{
				amountText.color = val;
			}).setEaseOutCubic();
			LeanTween.delayedCall(duration, (Action)delegate
			{
				UnityEngine.Object.Destroy(resourceTextGo);
			});
		}
	}
}
