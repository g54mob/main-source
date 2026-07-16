using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingHullDamageDisplay : MonoBehaviour
{
	[SerializeField]
	private GameObject damageTextPrefab;

	[SerializeField]
	private AnimationCurve sizeCurve;

	[SerializeField]
	private AnimationCurve offsetCurve;

	[SerializeField]
	private AnimationCurve opacityCurve;

	[SerializeField]
	private Gradient colorGradient;

	[SerializeField]
	private float maxDamage = 10f;

	[SerializeField]
	private Vector2 startPoing = new Vector2(0.5f, 0.1f);

	private Vector2 endOffset = new Vector2(0f, 10f);

	[SerializeField]
	private float duration = 1f;

	private float overlapOffset;

	[SerializeField]
	private float overlapTimeBuffer = 0.2f;

	[Header("Shake")]
	[SerializeField]
	private AnimationCurve shakeOverTimeCurve;

	[SerializeField]
	private AnimationCurve shakeDamageFactorCurve;

	private List<GameObject> floatingTexts;

	private float lastFloatingDamageNumberSpawnTime = -1f;

	private void OnEnable()
	{
		Train.Instance.OnHealthBarUpdated += HealthChanged;
		floatingTexts = new List<GameObject>();
	}

	private IEnumerator Start()
	{
		yield return new WaitUntil(() => LevelManager.Instance);
		LevelManager.Instance.LevelCompleted += ClearAllFloatingText;
	}

	private void OnDisable()
	{
		Train.Instance.OnHealthBarUpdated -= HealthChanged;
		LevelManager.Instance.LevelCompleted -= ClearAllFloatingText;
	}

	private void HealthChanged(float changevalue)
	{
		if (!GameManager.Instance.IsPaused && SaveManager.Instance.ShowHullDamageText)
		{
			if (lastFloatingDamageNumberSpawnTime + overlapTimeBuffer > Time.time)
			{
				overlapOffset += 0.01f;
				StartCoroutine(DelaySpawn(0.1f, changevalue));
			}
			else
			{
				overlapOffset = 0f;
				SpawnFloatingText(changevalue);
			}
			lastFloatingDamageNumberSpawnTime = Time.time;
		}
	}

	public void SpawnFloatingText(float healthCnangeValue)
	{
		if (healthCnangeValue == 0f)
		{
			return;
		}
		GameObject damageTextGo = UnityEngine.Object.Instantiate(damageTextPrefab, Vector2.zero, Quaternion.identity, base.transform);
		RectTransform damageTextRt = damageTextGo.GetComponent<RectTransform>();
		TextMeshProUGUI healthChangeText = damageTextGo.GetComponent<TextMeshProUGUI>();
		if (HUD.Instance.IsScrambled)
		{
			healthCnangeValue = UnityEngine.Random.Range(0f - maxDamage, maxDamage);
		}
		float num = Mathf.Clamp(healthCnangeValue, 0f - maxDamage, maxDamage) / maxDamage;
		float time = (num + 1f) / 2f;
		healthChangeText.text = ((healthCnangeValue > 0f) ? "+" : "") + healthCnangeValue.ToString("0.##");
		healthChangeText.color = colorGradient.Evaluate(time);
		healthChangeText.fontSize = sizeCurve.Evaluate(time);
		Vector2 vector = startPoing + new Vector2(UnityEngine.Random.Range(0f - overlapOffset, overlapOffset) * 1.8f, overlapOffset);
		damageTextRt.anchorMin = vector;
		damageTextRt.anchorMax = vector;
		damageTextRt.pivot = new Vector2(0.5f, 1f);
		damageTextRt.anchoredPosition = Vector2.zero;
		if (healthCnangeValue > 0f)
		{
			Vector3 to = damageTextRt.anchoredPosition + endOffset;
			LeanTween.move(damageTextRt, to, duration).setEaseOutCubic();
		}
		else
		{
			float num2 = 0f - num;
			float adjustedShakeIntensity = shakeDamageFactorCurve.Evaluate(num2);
			LeanTween.value(damageTextGo, 0f, 1f, duration + duration * num2).setOnUpdate(delegate(float t)
			{
				float num3 = shakeOverTimeCurve.Evaluate(t);
				float num4 = UnityEngine.Random.Range(-1f, 1f) * adjustedShakeIntensity * num3;
				float num5 = UnityEngine.Random.Range(-1f, 1f) * adjustedShakeIntensity * num3 * 0.1f;
				float num6 = offsetCurve.Evaluate(t);
				damageTextRt.anchoredPosition = new Vector2(num4, num5 + num6);
				damageTextRt.rotation = Quaternion.Euler(0f, 0f, num4);
			});
		}
		Color startColor = healthChangeText.color;
		new Color(startColor.r, startColor.g, startColor.b, 0f);
		LeanTween.value(base.gameObject, 0f, 1f, duration).setOnUpdate(delegate(float t)
		{
			healthChangeText.color = new Color(startColor.r, startColor.g, startColor.b, opacityCurve.Evaluate(t));
		}).setEaseOutCubic();
		LeanTween.delayedCall(duration, (Action)delegate
		{
			UnityEngine.Object.Destroy(damageTextGo);
		});
	}

	private IEnumerator DelaySpawn(float delay, float damage)
	{
		yield return new WaitForSeconds(delay);
		SpawnFloatingText(damage);
	}

	public void ClearAllFloatingText()
	{
		foreach (GameObject floatingText in floatingTexts)
		{
			if (floatingText != null)
			{
				UnityEngine.Object.Destroy(floatingText);
			}
		}
		floatingTexts.Clear();
	}
}
