using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchStationEnergyOverviewUI : EnergyGridOverviewSlotUI
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private TMP_Text _costText;

	private ResearchStation _researchStation;

	private static List<ResearchStationEnergyOverviewUI> _uiList;

	protected override GameObject SelectionGameObject => _researchStation.gameObject;

	private void Awake()
	{
		if (_uiList == null)
		{
			_uiList = new List<ResearchStationEnergyOverviewUI>();
		}
		_uiList.Add(this);
	}

	private void OnDestroy()
	{
		_uiList.Remove(this);
	}

	public void Initialize(ResearchStation researchStation)
	{
		_researchStation = researchStation;
		_image.sprite = researchStation.Buildable.Properties.IconSprite;
		_researchStation.OnStartResearching.AddListener(UpdateOverview);
		_researchStation.OnStopResearching.AddListener(UpdateOverview);
		UpdateOverview();
		base.gameObject.SetActive(value: true);
	}

	private void OnDisable()
	{
		_researchStation.OnStartResearching.RemoveListener(UpdateOverview);
		_researchStation.OnStopResearching.RemoveListener(UpdateOverview);
	}

	protected override void UpdateOverview()
	{
		if (!(_researchStation == null))
		{
			float energyAddition = 0f;
			if (_researchStation.IsResearching)
			{
				base.EnergyAddition = energyAddition;
				_costText.color = base.Activecolor;
			}
			else
			{
				base.EnergyAddition = 0f;
				_costText.color = base.InactiveColor;
			}
		}
	}

	public static bool TryReturnAvailableUI(out ResearchStationEnergyOverviewUI ui)
	{
		ui = null;
		if (_uiList == null)
		{
			return false;
		}
		foreach (ResearchStationEnergyOverviewUI ui2 in _uiList)
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
