using System;
using RainbowArt.CleanFlatUI;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	public enum StatType
	{
		Stamina = 0,
		Hunger = 1,
		Knowlege = 2
	}

	public ProgressBar gage;

	public TextMeshProUGUI knowlegeLevelText;

	public StatType statType;

	public float maxValue;

	public float smoothSpeed = 10f;

	private float targetValue;

	private float currentValue;

	private FirstPersonController player;

	private void Awake()
	{
	}

	private void Start()
	{
		player = GameManager.S.player;
		if (statType == StatType.Stamina)
		{
			maxValue = player.maxStamina;
			gage.MaxValue = maxValue;
		}
		else if (statType == StatType.Hunger)
		{
			maxValue = player.maxHunger;
			gage.MaxValue = maxValue;
		}
		else if (statType == StatType.Knowlege)
		{
			GameManager.S.OnPlayerLevelUp += Gm_OnPlayerLevelUp;
			maxValue = player.expTable[player.KnowledgeLevel];
			gage.MaxValue = maxValue;
			knowlegeLevelText.text = player.KnowledgeLevel.ToString();
		}
		else
		{
			maxValue = 0f;
		}
		currentValue = (targetValue = maxValue);
	}

	private void OnDestroy()
	{
		GameManager.S.OnPlayerLevelUp -= Gm_OnPlayerLevelUp;
	}

	private void Gm_OnPlayerLevelUp(object sender, EventArgs e)
	{
		knowlegeLevelText.text = player.KnowledgeLevel.ToString();
		maxValue = player.expTable[player.KnowledgeLevel];
		gage.MaxValue = maxValue;
	}

	private void Update()
	{
		if (statType == StatType.Stamina)
		{
			SetValue(player.stamina);
		}
		else if (statType == StatType.Hunger)
		{
			SetValue(player.hunger);
		}
		else if (statType == StatType.Knowlege)
		{
			SetValue(player.exp);
		}
		currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * smoothSpeed);
		gage.CurrentValue = currentValue;
	}

	public void SetMaxValue(float value)
	{
		maxValue = value;
	}

	public void SetValue(float newValue)
	{
		targetValue = Mathf.Clamp(newValue, 0f, maxValue);
	}

	public void GageInit(float maxGage)
	{
		maxValue = maxGage;
	}
}
