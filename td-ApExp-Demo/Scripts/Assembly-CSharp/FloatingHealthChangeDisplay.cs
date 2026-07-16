using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingHealthChangeDisplay : MonoBehaviour
{
	[SerializeField]
	private GameObject healthChangeTextPrefab;

	[SerializeField]
	private Gradient colorGradient;

	[SerializeField]
	private AnimationCurve sizeCurve;

	[SerializeField]
	private float maxValue = 10f;

	private Vector2 startOffset = new Vector2(0f, 0f);

	private Vector2 endOffset = new Vector2(0f, 10f);

	[SerializeField]
	private float duration = 1f;

	private float overlapOffset;

	private List<GameObject> floatingTexts;

	private void OnEnable()
	{
		CombatManager.Instance.HealthChanged += HealthChanged;
		floatingTexts = new List<GameObject>();
		LevelManager.Instance.LevelCompleted += ClearAllFloatingText;
	}

	private void OnDisable()
	{
		CombatManager.Instance.HealthChanged -= HealthChanged;
		LevelManager.Instance.LevelCompleted -= ClearAllFloatingText;
	}

	private void HealthChanged(HealthChangeInfo info)
	{
		if (!info.Target || !info.ShowDamageNumbers)
		{
			return;
		}
		Unit component = info.Target.GetComponent<Unit>();
		if ((bool)component && (!(component is EnemyBase) || !(component is EnemyComponent)) && component.IsEnemy)
		{
			if (component.GetComponent<E1_3Bomber>() != null)
			{
				startOffset.y = 0.2f;
			}
			else
			{
				startOffset.y = 0f;
			}
			Vector2 worldPos = component.transform.position;
			float healthChange = info.HealthChange;
			if (component.lastFloatingDamageNumberSpawnTime == Time.time)
			{
				overlapOffset += 0.15f;
				StartCoroutine(DelaySpawn(0.1f, worldPos, healthChange));
			}
			else
			{
				overlapOffset = 0f;
				SpawnHealthChangeText(worldPos, healthChange);
			}
			component.lastFloatingDamageNumberSpawnTime = Time.time;
		}
	}

	private void SpawnHealthChangeText(Vector2 worldPos, float amount)
	{
		if (amount != 0f)
		{
			GameObject healthChangeTextGo = UnityEngine.Object.Instantiate(healthChangeTextPrefab, worldPos, Quaternion.identity, base.transform);
			floatingTexts.Add(healthChangeTextGo);
			RectTransform component = healthChangeTextGo.GetComponent<RectTransform>();
			TextMeshProUGUI healthChangeText = healthChangeTextGo.GetComponent<TextMeshProUGUI>();
			if (HUD.Instance.IsScrambled)
			{
				amount = UnityEngine.Random.Range(0f, maxValue);
			}
			float time = (Mathf.Clamp(amount, 0f - maxValue, maxValue) / maxValue + 1f) / 2f;
			healthChangeText.text = amount.ToString(((amount > 0f) ? "+" : "") + "0.##");
			healthChangeText.color = colorGradient.Evaluate(time);
			healthChangeText.fontSize = sizeCurve.Evaluate(time);
			Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
			if (worldPos.y > vector.y)
			{
				startOffset.y = 0f - Mathf.Abs(startOffset.y);
				endOffset.y = 0f - Mathf.Abs(endOffset.y);
			}
			else
			{
				startOffset.y = Mathf.Abs(startOffset.y);
				endOffset.y = Mathf.Abs(endOffset.y);
			}
			float num = Mathf.Abs(worldPos.x - vector.x);
			float maxDistanceFromCenter = GetMaxDistanceFromCenter();
			float num2 = Mathf.Clamp01(num / maxDistanceFromCenter);
			float num3 = 0.5f + num2 * 0.5f + overlapOffset;
			startOffset.x = 0f - num3;
			if (worldPos.x > vector.x)
			{
				startOffset.x -= 0.1f;
			}
			Vector2 vector2 = Camera.main.WorldToViewportPoint(worldPos + startOffset);
			_ = base.transform;
			component.anchorMin = vector2;
			component.anchorMax = vector2;
			component.anchoredPosition = Vector2.zero;
			Vector3 to = component.anchoredPosition + endOffset;
			LeanTween.move(component, to, duration).setEaseOutCubic();
			Color color = healthChangeText.color;
			LeanTween.value(to: new Color(color.r, color.g, color.b, 0f), gameObject: base.gameObject, from: color, time: duration).setOnUpdate(delegate(Color val)
			{
				healthChangeText.color = val;
			}).setEaseOutCubic();
			LeanTween.delayedCall(duration, (Action)delegate
			{
				floatingTexts.Remove(healthChangeTextGo);
				UnityEngine.Object.Destroy(healthChangeTextGo);
			});
		}
	}

	private float GetMaxDistanceFromCenter()
	{
		Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f));
		return Mathf.Abs(Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)).x - vector.x) / 2f;
	}

	private IEnumerator DelaySpawn(float delay, Vector2 worldPos, float amount)
	{
		yield return new WaitForSeconds(delay);
		SpawnHealthChangeText(worldPos, amount);
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
