using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class SelectableUI_enemyTower : SelectableUI
{
	[SerializeField]
	private UIList damageCostList;

	[SerializeField]
	private GameObject damageButton;

	[SerializeField]
	private GameObject lineSeparatorGroup;

	[SerializeField]
	private GameObject bossInfoGroup;

	[SerializeField]
	private TextMeshProUGUI nightsToBossText;

	[SerializeField]
	private LocalizedString nightsToBossLS_singular;

	[SerializeField]
	private LocalizedString nightsToBossLS_plural;

	private EnemyTower enemyTower;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			enemyTower = SelectedObject as EnemyTower;
			damageCostList.ClearList();
			damageCostList.LoadList(enemyTower.DamageCost);
			CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
			cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCurrentCycleChanged));
			OnCurrentCycleChanged(LTFunctionLibrary.GetCyclesManager().CurrentCycle, LTFunctionLibrary.GetCyclesManager().CurrentCycleMode);
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}

	private void Update()
	{
		if (LTFunctionLibrary.GetLTGameManager().CanAfford(enemyTower.DamageCost))
		{
			if (!damageButton.activeSelf)
			{
				damageButton.SetActive(value: true);
				GetComponent<AutoTransformRebuild>().RebuildTransform();
			}
		}
		else if (damageButton.activeSelf)
		{
			damageButton.SetActive(value: false);
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}

	private void OnDestroy()
	{
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Remove(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCurrentCycleChanged));
	}

	public void DoDamageButton()
	{
		if (LTFunctionLibrary.GetLTGameManager().CanAfford(enemyTower.DamageCost))
		{
			enemyTower.CombatComponent.DoDamage(null, new FDamageData(1f, EDamageMultiplier.Normal, EDamageMultiplier.Normal, EDamageMultiplier.Normal));
		}
	}

	private void OnCurrentCycleChanged(int cycle, ECycleMode mode)
	{
		if (LTFunctionLibrary.GetMatchInfo().CurrentLevelData == null || LTFunctionLibrary.GetMatchInfo().CurrentLevelData.LevelSpawners.GetLevelBosses().Count <= 0)
		{
			lineSeparatorGroup.SetActive(value: false);
			bossInfoGroup.SetActive(value: false);
			return;
		}
		lineSeparatorGroup.SetActive(value: true);
		bossInfoGroup.SetActive(value: true);
		int num = LTFunctionLibrary.GetMatchInfo().CurrentLevelData.TotalDays() - 1 - cycle;
		if (num == 0)
		{
			nightsToBossText.text = nightsToBossLS_singular.GetLocalizedString();
			return;
		}
		nightsToBossText.text = nightsToBossLS_plural.GetLocalizedString(new Dictionary<string, string> { 
		{
			"value",
			(num + 1).ToString()
		} });
	}
}
