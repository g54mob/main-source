using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipUI_incomingEnemy : TooltipUI
{
	[SerializeField]
	private TextMeshProUGUI enemyNameText;

	[Header("Bars")]
	[SerializeField]
	private GameObject healthBar;

	[SerializeField]
	private TextMeshProUGUI healthBarText;

	[SerializeField]
	private GameObject armorBar;

	[SerializeField]
	private TextMeshProUGUI armorBarText;

	[SerializeField]
	private GameObject shieldBar;

	[SerializeField]
	private TextMeshProUGUI shieldBarText;

	[Header("Side Stats")]
	[SerializeField]
	private Sprite groundSprite;

	[SerializeField]
	private Sprite flyingSprite;

	[SerializeField]
	private Image typeIcon;

	[SerializeField]
	private TextMeshProUGUI speedText;

	public override void Setup(Dictionary<string, object> data)
	{
		EnemyData enemyData = data["enemyData"] as EnemyData;
		int cycle = (int)data["cycle"];
		UpdateName(enemyData);
		UpdateStatBars(enemyData, cycle);
		UpdateSpeed(enemyData);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private void UpdateName(EnemyData enemyData)
	{
		enemyNameText.text = enemyData.EnemyName;
	}

	private void UpdateStatBars(EnemyData enemyData, int cycle)
	{
		StatsComponent component = enemyData.EnemyPrefab.GetComponent<StatsComponent>();
		int num = (int)component.GetConfigStat(EStats.HealthMax);
		int num2 = (int)component.GetConfigStat(EStats.ArmorMax);
		int num3 = (int)component.GetConfigStat(EStats.ShieldMax);
		float num4 = MatchInfo.instance.CurrentMatchSettings.EnemyLifeMultiplier;
		if (MatchInfo.instance.CurrentMatchMode == EMatchMode.Endless)
		{
			LTGameManager_Endless lTGameManager_Endless = GameManager.instance as LTGameManager_Endless;
			num4 *= lTGameManager_Endless.GetEnemyLifeMultiplierByCycle(cycle);
			if (enemyData.Boss)
			{
				float num5 = (int)lTGameManager_Endless.GetBossTotalLife(cycle) / 100 * 100;
				Enemy enemyPrefab = enemyData.EnemyPrefab;
				float num6 = (float)num * enemyPrefab.BossHealthMultiplier + (float)num2 * enemyPrefab.BossArmorMultiplier + (float)num3 * enemyPrefab.BossShieldMultiplier;
				float num7 = (float)num * enemyPrefab.BossHealthMultiplier / num6;
				float num8 = (float)num2 * enemyPrefab.BossArmorMultiplier / num6;
				float num9 = (float)num3 * enemyPrefab.BossShieldMultiplier / num6;
				num = (int)(num5 * num7 / enemyPrefab.BossHealthMultiplier) / 50 * 50;
				num2 = (int)(num5 * num8 / enemyPrefab.BossArmorMultiplier) / 50 * 50;
				num3 = (int)(num5 * num9 / enemyPrefab.BossShieldMultiplier) / 50 * 50;
			}
		}
		if (num4 != 1f)
		{
			num = (int)((float)num * num4) / 5 * 5;
			num2 = (int)((float)num2 * num4) / 5 * 5;
			num3 = (int)((float)num3 * num4) / 5 * 5;
		}
		healthBarText.text = num.ToString();
		healthBar.SetActive(num > 0);
		armorBarText.text = num2.ToString();
		armorBar.SetActive(num2 > 0);
		shieldBarText.text = num3.ToString();
		shieldBar.SetActive(num3 > 0);
	}

	private void UpdateSpeed(EnemyData enemyData)
	{
		StatsComponent component = enemyData.EnemyPrefab.GetComponent<StatsComponent>();
		typeIcon.sprite = (((enemyData.EnemyPrefab.EnemyType & Enemy.EEnemyType.Ground) > (Enemy.EEnemyType)0) ? groundSprite : flyingSprite);
		float configStat = component.GetConfigStat(EStats.MovementSpeed);
		speedText.text = FunctionLibrary.RoundToDecimals(configStat, 2).ToString();
	}
}
