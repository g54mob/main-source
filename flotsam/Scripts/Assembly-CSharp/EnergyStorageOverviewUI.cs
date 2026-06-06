using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyStorageOverviewUI : EnergyGridOverviewSlotUI
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private TMP_Text _amountText;

	[SerializeField]
	private Slider _slider;

	private EnergyStorage _energyStorage;

	private static List<EnergyStorageOverviewUI> _uiList;

	protected override GameObject SelectionGameObject => _energyStorage.gameObject;

	private void Awake()
	{
		if (_uiList == null)
		{
			_uiList = new List<EnergyStorageOverviewUI>();
		}
		_uiList.Add(this);
	}

	private void OnDestroy()
	{
		_uiList.Remove(this);
	}

	public void Initialize(EnergyStorage storage)
	{
		_energyStorage = storage;
		_image.sprite = storage.Buildable.Properties.IconSprite;
		_energyStorage.OnEnergyUpdateEvent.AddListener(UpdateOverview);
		UpdateOverview();
		base.gameObject.SetActive(value: true);
	}

	private void OnDisable()
	{
		_energyStorage.OnEnergyUpdateEvent.RemoveListener(UpdateOverview);
	}

	protected override void UpdateOverview()
	{
		base.EnergyStorage = _energyStorage.EnergyAmount;
		base.EnergyCapacity = _energyStorage.EnergyCapacity;
		_amountText.text = _energyStorage.EnergyAmount.ToString("F0");
		_slider.value = _energyStorage.NormalizedEnergyAmount;
	}

	public static bool TryReturnAvailableUI(out EnergyStorageOverviewUI ui)
	{
		ui = null;
		if (_uiList == null)
		{
			return false;
		}
		foreach (EnergyStorageOverviewUI ui2 in _uiList)
		{
			if (!ui2.gameObject.activeSelf)
			{
				ui = ui2;
				return true;
			}
		}
		return false;
	}
}
