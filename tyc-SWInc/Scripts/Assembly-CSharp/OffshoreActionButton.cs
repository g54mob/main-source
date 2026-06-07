using System;
using UnityEngine;
using UnityEngine.UI;

public class OffshoreActionButton : MonoBehaviour
{
	public Text MainLabel;

	public Text MoneyLabel;

	public Text HeatLabel;

	public Button Self;

	public GUIToolTipper Tip;

	[NonSerialized]
	private float _cost;

	[NonSerialized]
	private float _minHeat;

	[NonSerialized]
	private float _maxHeat;

	public void Init(string action, string desc, float money, float minHeat, float maxHeat, Action a)
	{
		_cost = money;
		_minHeat = minHeat;
		_maxHeat = maxHeat;
		MainLabel.text = action.Loc();
		MoneyLabel.text = money.Currency();
		HeatLabel.text = _minHeat.ToPercent() + " - " + _maxHeat.ToPercent();
		Tip.TooltipDescription = desc;
		Self.onClick.AddListener(delegate
		{
			if (GameSettings.Instance.OffshoreAccount >= (double)_cost)
			{
				a();
			}
		});
	}

	public void Apply()
	{
		GameSettings.Instance.OffshoreAccount -= _cost;
		GameSettings.Instance.AddHeat(GameSettings.Instance.NextHeatActionAdd.MapRange(0f, 1f, _minHeat, _maxHeat, true), true);
		GameSettings.Instance.NextHeatActionAdd = Utilities.RandomValue;
		GameSettings.Instance.MyCompany.CurrentTaxReport.MakeIllegal();
	}

	private void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			Self.interactable = GameSettings.Instance.OffshoreAccount >= (double)_cost && GameSettings.Instance.Heat <= 10000000f * (1f - _minHeat) - 1f;
		}
	}
}
