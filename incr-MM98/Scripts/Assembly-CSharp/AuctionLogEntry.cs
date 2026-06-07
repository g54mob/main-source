using System;
using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class AuctionLogEntry : MonoBehaviour, ITooltip, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private LocalizeStringHandler messageHandler;

	[SerializeField]
	private TMP_Text earningsText;

	private bool _tooltipInitialized;

	private StringVariable _itemVariable;

	private DoubleVariable _priceVariable;

	private DoubleVariable _cutVariable;

	private FloatVariable _cutPercentageVariable;

	[field: SerializeField]
	public Tooltip Tooltip { get; private set; }

	public void Setup(AuctionLogMessage log)
	{
		InitializeTooltip();
		messageHandler.SetValue("username", log.Username);
		messageHandler.SetValue("item", log.Item);
		earningsText.SetTextFormat("<#2E8E34>${0:0}</color>", log.Value);
		_itemVariable.Value = log.Item;
		_priceVariable.Value = log.Value;
		_cutVariable.Value = Math.Round(log.Cut, MidpointRounding.AwayFromZero);
		_cutPercentageVariable.Value = log.CutPercentage * 100f;
	}

	private void InitializeTooltip()
	{
		if (!_tooltipInitialized)
		{
			_tooltipInitialized = true;
			_itemVariable = new StringVariable();
			_priceVariable = new DoubleVariable();
			_cutVariable = new DoubleVariable();
			_cutPercentageVariable = new FloatVariable();
			Tooltip.SetVariableTitle("item", _itemVariable);
			Tooltip.SetVariablesDescription(("value", _priceVariable), ("cut", _cutVariable), ("cutPercentage", _cutPercentageVariable));
		}
	}
}
