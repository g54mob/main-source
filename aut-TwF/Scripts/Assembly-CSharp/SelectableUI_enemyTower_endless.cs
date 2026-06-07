using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class SelectableUI_enemyTower_endless : SelectableUI
{
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
			CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
			cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCurrentCycleChanged));
			OnCurrentCycleChanged(LTFunctionLibrary.GetCyclesManager().CurrentCycle, LTFunctionLibrary.GetCyclesManager().CurrentCycleMode);
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}

	private void OnDestroy()
	{
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Remove(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCurrentCycleChanged));
	}

	private void OnCurrentCycleChanged(int cycle, ECycleMode mode)
	{
		int num = 5 - cycle % 5;
		if (num == 1)
		{
			nightsToBossText.text = nightsToBossLS_singular.GetLocalizedString();
			return;
		}
		nightsToBossText.text = nightsToBossLS_plural.GetLocalizedString(new Dictionary<string, string> { 
		{
			"value",
			num.ToString()
		} });
	}
}
