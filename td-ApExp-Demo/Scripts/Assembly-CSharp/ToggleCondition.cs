using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCondition : DifficultyCondition
{
	[NonSerialized]
	public bool isToggledOn;

	[SerializeField]
	private float tonsValue;

	[field: SerializeField]
	public ToggledDifficultyConditions condition { get; private set; }

	[field: SerializeField]
	public Toggle toggle { get; private set; }

	private void Awake()
	{
		toggle.onValueChanged.AddListener(UpdateCondition);
	}

	public override void UpdateLockState(bool locked)
	{
		base.UpdateLockState(locked);
		isLocked = locked;
		toggle.interactable = !locked;
	}

	public void UpdateCondition(bool isOn)
	{
		if (isLocked)
		{
			return;
		}
		if (isOn)
		{
			isToggledOn = true;
			toggle.isOn = isOn;
			DifficultyManager.Instance.DifficultyUI.UpdateWeightBar(tonsValue);
		}
		else
		{
			isToggledOn = false;
			toggle.isOn = isOn;
			DifficultyManager.Instance.DifficultyUI.UpdateWeightBar(0f - tonsValue);
			foreach (ScalingCondition scalingCondition in DifficultyManager.Instance.DifficultyUI.scalingConditions)
			{
				if (!scalingCondition.isLocked)
				{
					scalingCondition.increaseButton.interactable = true;
				}
			}
			foreach (ToggleCondition toggledCondition in DifficultyManager.Instance.DifficultyUI.toggledConditions)
			{
				if (!toggledCondition.isLocked)
				{
					toggledCondition.toggle.interactable = true;
				}
			}
		}
		if (condition == ToggledDifficultyConditions.MixedWaves)
		{
			UpdateMixedWaves(isOn);
		}
	}

	private void UpdateMixedWaves(bool isOn)
	{
		DifficultyManager.Instance.mixedWaves = isOn;
	}
}
