using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyPassiveOverviewUI : EnergyGridOverviewSlotUI
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private TMP_Text _gainText;

	private EnergyPassiveGenerator _generator;

	private static List<EnergyPassiveOverviewUI> _uiList;

	protected override GameObject SelectionGameObject => _generator.gameObject;

	private void Awake()
	{
		if (_uiList == null)
		{
			_uiList = new List<EnergyPassiveOverviewUI>();
		}
		_uiList.Add(this);
	}

	private void OnDestroy()
	{
		_uiList.Remove(this);
	}

	public void Initialize(EnergyPassiveGenerator generator)
	{
		_generator = generator;
		_image.sprite = generator.Buildable.Properties.IconSprite;
		_generator.OnUpdateGeneratingEnergy.AddListener(UpdateOverview);
		_gainText.text = $"+{_generator.EnergyRate:F0}";
		UpdateOverview();
		base.gameObject.SetActive(value: true);
	}

	private void OnDisable()
	{
		_generator.OnUpdateGeneratingEnergy.RemoveListener(UpdateOverview);
	}

	protected override void UpdateOverview()
	{
		if (!(_generator == null))
		{
			float energyRate = _generator.EnergyRate;
			if (_generator.IsRunning)
			{
				base.EnergyAddition = energyRate;
				_gainText.color = base.Activecolor;
			}
			else
			{
				base.EnergyAddition = 0f;
				_gainText.color = base.InactiveColor;
			}
		}
	}

	public static bool TryReturnAvailableUI(out EnergyPassiveOverviewUI ui)
	{
		ui = null;
		if (_uiList == null)
		{
			return false;
		}
		foreach (EnergyPassiveOverviewUI ui2 in _uiList)
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
