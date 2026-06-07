using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class IncomingEnemiesUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI currentDayText;

	[SerializeField]
	private TextMeshProUGUI nextDayText;

	[SerializeField]
	private Transform currentDayEnemiesContainer;

	[SerializeField]
	private Transform nextDayEnemiesContainer;

	[SerializeField]
	private GameObject nextDayEnemiesGroup;

	[SerializeField]
	private GameObject separator;

	[SerializeField]
	private IncomingEnemiesUI_enemy enemyElementUIPrefab;

	private int totalDays;

	private void Start()
	{
		totalDays = LTFunctionLibrary.GetSpawnersManager().LevelSpanwers.GetTotalCyclesAmount();
		UpdateUI(LTFunctionLibrary.GetCyclesManager().CurrentCycle);
	}

	private void OnEnable()
	{
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
		UpdateUI(LTFunctionLibrary.GetCyclesManager().CurrentCycle);
	}

	private void OnDisable()
	{
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Remove(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
	}

	private void UpdateUI(int currentCycle)
	{
		string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_incomingEnemiesUI_day", null, FallbackBehavior.UseProjectSettings);
		currentDayText.text = string.Format(localizedString, currentCycle + 1);
		currentDayEnemiesContainer.DeleteAllChildren();
		foreach (EnemyData item in LTFunctionLibrary.GetSpawnersManager().LevelSpanwers.GetCycleEnemies(currentCycle).OrderBy(delegate(EnemyData x)
		{
			StatsComponent component = x.EnemyPrefab.GetComponent<StatsComponent>();
			return component.GetConfigStat(EStats.HealthMax) + component.GetConfigStat(EStats.ArmorMax) + component.GetConfigStat(EStats.ShieldMax) + (float)(x.Boss ? 9999999 : 0);
		}).ToList())
		{
			UnityEngine.Object.Instantiate(enemyElementUIPrefab, currentDayEnemiesContainer).SetEnemy(item, currentCycle);
		}
		if (currentCycle + 1 >= totalDays)
		{
			nextDayEnemiesGroup.SetActive(value: false);
			separator.SetActive(value: false);
		}
		else
		{
			nextDayEnemiesGroup.SetActive(value: true);
			separator.SetActive(value: true);
			nextDayText.text = string.Format(localizedString, currentCycle + 2);
			nextDayEnemiesContainer.DeleteAllChildren();
			foreach (EnemyData item2 in LTFunctionLibrary.GetSpawnersManager().LevelSpanwers.GetCycleEnemies(currentCycle + 1).OrderBy(delegate(EnemyData x)
			{
				StatsComponent component = x.EnemyPrefab.GetComponent<StatsComponent>();
				return component.GetConfigStat(EStats.HealthMax) + component.GetConfigStat(EStats.ArmorMax) + component.GetConfigStat(EStats.ShieldMax) + (float)(x.Boss ? 9999999 : 0);
			}).ToList())
			{
				UnityEngine.Object.Instantiate(enemyElementUIPrefab, nextDayEnemiesContainer).SetEnemy(item2, currentCycle + 1);
			}
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private void OnCycleChanged(int cycle, ECycleMode mode)
	{
		if (mode == ECycleMode.Neutral)
		{
			UpdateUI(cycle);
		}
	}
}
