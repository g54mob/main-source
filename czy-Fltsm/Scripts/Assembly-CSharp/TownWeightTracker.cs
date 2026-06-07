using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI.PajamaLlama;

public class TownWeightTracker : SceneBehaviour, IComparer<WeightTier>
{
	[SerializeField]
	private FillField _weightBar;

	[SerializeField]
	private TextMeshProUGUI _weightOverCapacityText;

	[SerializeField]
	private TextMeshProUGUI _weightTierIndexLabel;

	[SerializeField]
	private FillField _weightTierThresholdPrefab;

	[SerializeField]
	private float _weightTierThresholdAlpha = 0.5f;

	private bool _initialized;

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.TownWeightUpdated, UpdateTownWeight);
		GameEventDispatcher.AddListener(GameEventType.WeightTierUpdated, UpdateWeightTier);
		InitializeThresholds();
		UpdateTownWeight();
		UpdateWeightTier();
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.TownWeightUpdated, UpdateTownWeight);
		GameEventDispatcher.RemoveListener(GameEventType.WeightTierUpdated, UpdateWeightTier);
	}

	private void LateUpdate()
	{
		_weightBar.Value = Engine.TownUsedTugCapacityPercentage;
	}

	private void InitializeThresholds()
	{
		if (_initialized)
		{
			return;
		}
		WeightTier[] array = Engine.ReturnWeightTiers();
		if (array.IsNullOrEmpty())
		{
			return;
		}
		using ListPool<WeightTier>.List list = ListPool<WeightTier>.Get(array);
		Sorting.SlowSort(list, this);
		foreach (WeightTier item in list)
		{
			FillField fillField = Object.Instantiate(_weightTierThresholdPrefab, _weightTierThresholdPrefab.transform.parent);
			Color color = item.Color * _weightTierThresholdAlpha;
			color.a = 1f;
			fillField.Color = color;
			fillField.Value = item.Limits.Maximum;
			fillField.gameObject.SetActive(value: true);
			fillField.name = item.name;
		}
		_initialized = true;
	}

	private void UpdateTownWeight(GameEvent gameEvent = null)
	{
		_weightOverCapacityText.text = Community.PlayerCommunity.ReturnWeightOverCapacityString();
		_weightTierIndexLabel.text = GameplaySettings.GetCurrentTownWeightTierIndex().ToString();
	}

	private void UpdateWeightTier(GameEvent gameEvent = null)
	{
		if (Engine.WeightTier != null)
		{
			_weightBar.Color = Engine.WeightTier.Color;
		}
	}

	public int Compare(WeightTier x, WeightTier y)
	{
		if (!(x.Limits.Minimum <= y.Limits.Minimum))
		{
			return -1;
		}
		return 1;
	}
}
