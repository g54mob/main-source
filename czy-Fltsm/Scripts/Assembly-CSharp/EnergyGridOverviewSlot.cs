using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyGridOverviewSlot : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _gridName;

	[SerializeField]
	private TMP_Text _energyNet;

	[SerializeField]
	private TMP_Text _storedEnergy;

	[SerializeField]
	private TMP_Text _maxCapacityEnergy;

	[SerializeField]
	private TMP_Text _totalGainText;

	[SerializeField]
	private TMP_Text _totalLossText;

	[SerializeField]
	private Slider _batteryStorage;

	[SerializeField]
	private RectTransform _sliderFillupRectTransform;

	[SerializeField]
	private Transform _gainsTransform;

	[SerializeField]
	private Transform _lossesTransform;

	[SerializeField]
	private Transform _batteriesTransform;

	[SerializeField]
	private EnergyGridEfficiencyUI _gridEfficiency;

	[SerializeField]
	private Image _energyNetImage;

	[SerializeField]
	private Color _positiveColor = new Color(1f, 1f, 1f, 1f);

	[SerializeField]
	private Color _negativeColor = new Color(1f, 1f, 1f, 1f);

	[SerializeField]
	private Sprite _positiveEnergyImage;

	[SerializeField]
	private Sprite _negativeEnergyImage;

	[SerializeField]
	private LocalizedString _gridLocalizedName = "";

	private float _totalGain;

	private float _totalLoss;

	private float _totalStoredEnergy;

	private float _totalEnergyCapacity;

	private EnergyGrid _energyGrid;

	private List<EnergyGridOverviewSlotUI> _entryUIList;

	private void Awake()
	{
		_entryUIList = new List<EnergyGridOverviewSlotUI>();
	}

	private void Update()
	{
		if (base.gameObject.activeSelf)
		{
			UpdateEntries();
		}
	}

	public void Initialize(EnergyGrid grid, int index)
	{
		base.gameObject.SetActive(value: true);
		_energyGrid = grid;
		_gridName.text = ReplaceGridNumber(_gridLocalizedName, index);
		for (int i = 0; i < _entryUIList.Count; i++)
		{
			_entryUIList[i].gameObject.SetActive(value: false);
		}
		for (int j = 0; j < grid.Components.Count; j++)
		{
			EnergyGridOverviewSlotUI energyGridOverviewSlotUI = grid.Components[j].ReturnUI();
			if (!(energyGridOverviewSlotUI == null))
			{
				if (!_entryUIList.Contains(energyGridOverviewSlotUI))
				{
					_entryUIList.Add(energyGridOverviewSlotUI);
				}
				Transform parent = ReturnParent(energyGridOverviewSlotUI.OverviewType);
				energyGridOverviewSlotUI.transform.SetParent(parent, worldPositionStays: false);
			}
		}
		_gridEfficiency.CalculateEfficiency(grid);
		UpdateEntries();
		_sliderFillupRectTransform.anchoredPosition = Vector2.zero;
		LayoutUpdater.ForceRebuild(base.transform);
	}

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.EnergyGridEfficiencyUpdated, OnGridEfficiencyUpdated);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridEfficiencyUpdated, OnGridEfficiencyUpdated);
		for (int i = 0; i < _entryUIList.Count; i++)
		{
			_entryUIList[i].gameObject.SetActive(value: false);
		}
	}

	private void OnGridEfficiencyUpdated(GameEvent gameEvent)
	{
		_gridEfficiency.CalculateEfficiency(_energyGrid);
	}

	private void UpdateEntries()
	{
		ResetTotals();
		foreach (EnergyGridOverviewSlotUI entryUI in _entryUIList)
		{
			if (entryUI.gameObject.activeSelf)
			{
				switch (entryUI.OverviewType)
				{
				case EnergyGridOverviewSlotUI.EnergyOverviewType.Producer:
					_totalGain += entryUI.EnergyAddition;
					break;
				case EnergyGridOverviewSlotUI.EnergyOverviewType.Consumer:
					_totalLoss += entryUI.EnergyAddition;
					break;
				case EnergyGridOverviewSlotUI.EnergyOverviewType.Storage:
					_totalStoredEnergy += entryUI.EnergyStorage;
					_totalEnergyCapacity += entryUI.EnergyCapacity;
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}
		UpdateTotals();
	}

	private void ResetTotals()
	{
		_totalGain = 0f;
		_totalLoss = 0f;
		_totalStoredEnergy = 0f;
		_totalEnergyCapacity = 0f;
	}

	private void UpdateTotals()
	{
		_totalGainText.text = $"+{_totalGain:F0}";
		_totalLossText.text = $"-{_totalLoss:F0}";
		_batteryStorage.value = _totalStoredEnergy / _totalEnergyCapacity;
		_storedEnergy.text = _totalStoredEnergy.ToString("F0");
		_maxCapacityEnergy.text = _totalEnergyCapacity.ToString("F0");
		float amount = _totalGain - _totalLoss;
		SetVisual(_energyNet, amount);
	}

	private void SetVisual(TMP_Text TmpText, float amount)
	{
		if (amount < 0f)
		{
			TmpText.text = amount.ToString("F0") ?? "";
			TmpText.color = _negativeColor;
			_energyNetImage.sprite = _negativeEnergyImage;
		}
		else
		{
			TmpText.text = "+" + amount.ToString("F0");
			TmpText.color = _positiveColor;
			_energyNetImage.sprite = _positiveEnergyImage;
		}
	}

	private string ReplaceGridNumber(string text, int index)
	{
		string replacement = index.ToString().PadLeft(2, '0');
		text = Regex.Replace(text, "%GRIDNUMBER%", replacement, RegexOptions.IgnoreCase);
		return text;
	}

	private Transform ReturnParent(EnergyGridOverviewSlotUI.EnergyOverviewType overviewType)
	{
		return overviewType switch
		{
			EnergyGridOverviewSlotUI.EnergyOverviewType.Producer => _gainsTransform, 
			EnergyGridOverviewSlotUI.EnergyOverviewType.Consumer => _lossesTransform, 
			EnergyGridOverviewSlotUI.EnergyOverviewType.Storage => _batteriesTransform, 
			_ => throw new NotImplementedException(), 
		};
	}
}
