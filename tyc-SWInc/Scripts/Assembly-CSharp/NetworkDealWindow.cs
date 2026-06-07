using System;
using System.Collections.Generic;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class NetworkDealWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Text Caption;

	public Text SubCaption;

	public Text PerUnitL;

	public Text UnitLimitL;

	public Text RoyaltyL;

	public InputField OnAccept;

	public InputField OnComplete;

	public InputField PerUnit;

	public Slider UnitLimit;

	public Slider Royalties;

	public Text UnitLimitLabel;

	public Text RoyaltiesLabel;

	public DatePicker EndDate;

	public Toggle UseDate;

	[NonSerialized]
	private WorkItem _target;

	[NonSerialized]
	private NetworkPlayer _player;

	[NonSerialized]
	private bool _disableTextEdit;

	public float OnAcceptValue
	{
		get
		{
			return OnAccept.text.Replace(",", "").ConvertToFloatDef(0f).FromCurrency();
		}
	}

	public float OnCompleteValue
	{
		get
		{
			return OnComplete.text.Replace(",", "").ConvertToFloatDef(0f).FromCurrency();
		}
	}

	public float PerUnitValue
	{
		get
		{
			if (!PerUnit.gameObject.activeSelf)
			{
				return 0f;
			}
			return PerUnit.text.Replace(",", "").ConvertToFloatDef(0f).FromCurrency();
		}
	}

	public uint UnitLimitValue
	{
		get
		{
			if (!UnitLimit.gameObject.activeSelf)
			{
				return 0u;
			}
			return (uint)UnitLimit.value;
		}
	}

	public float RoyaltyValue
	{
		get
		{
			if (!Royalties.gameObject.activeSelf)
			{
				return 0f;
			}
			return Royalties.value / 100f;
		}
	}

	public SDateTime? EndDateValue
	{
		get
		{
			if (!UseDate.isOn)
			{
				return null;
			}
			return EndDate.CurrentDate.SimplifyMore();
		}
	}

	public void EndEdit(InputField field)
	{
		if (!_disableTextEdit)
		{
			_disableTextEdit = true;
			field.text = field.text.Replace(",", "").ConvertToFloatDef(0f).ToString("#,0.##");
			_disableTextEdit = false;
		}
	}

	public void Show(WorkItem target, NetworkPlayer player)
	{
		_target = target;
		_player = player;
		Caption.text = _target.Name;
		SubCaption.text = player.Name;
		IRoyaltyItem royaltyItem = target.GetRoyaltyItem();
		OnAccept.text = "0";
		OnComplete.text = "0";
		PerUnit.text = "0";
		UseDate.isOn = false;
		EndDate.CurrentDate = SDateTime.Now() + 12;
		Royalties.value = 0f;
		if (royaltyItem != null)
		{
			Royalties.gameObject.SetActive(true);
			RoyaltyL.gameObject.SetActive(true);
			Royalties.maxValue = (1f - royaltyItem.GetWorkRoyalties().SumSafe((KeyValuePair<Company, float> x) => x.Value)) * 100f;
		}
		else
		{
			Royalties.gameObject.SetActive(false);
			RoyaltyL.gameObject.SetActive(false);
		}
		if (target.UnitName != null)
		{
			PerUnitL.gameObject.SetActive(true);
			PerUnit.gameObject.SetActive(true);
			PerUnitL.text = "PerUnit".Loc(Utilities.RobustStringFormat(target.UnitName.Loc(), false, false));
			if (target.MaxUnits != 0)
			{
				UnitLimitL.gameObject.SetActive(true);
				UnitLimit.gameObject.SetActive(true);
				UnitLimit.maxValue = target.MaxUnits;
				UnitLimitL.text = "UnitLimit".Loc(Utilities.RobustStringFormat(target.UnitName.Loc(), false, false));
				UnitLimit.value = UnitLimit.maxValue;
			}
			else
			{
				UnitLimitL.gameObject.SetActive(false);
				UnitLimit.gameObject.SetActive(false);
			}
		}
		else
		{
			PerUnitL.gameObject.SetActive(false);
			PerUnit.gameObject.SetActive(false);
			UnitLimitL.gameObject.SetActive(false);
			UnitLimit.gameObject.SetActive(false);
		}
		RoyaltyChange();
		LimitChange();
		Window.Show();
	}

	public float GetCost()
	{
		float num = OnCompleteValue + OnAcceptValue;
		if (_target.UnitName != null && UnitLimitValue != 0)
		{
			num += PerUnitValue * (float)UnitLimitValue;
		}
		return num;
	}

	public void DateToggle(bool toggle)
	{
		EndDate.Interactable = toggle;
	}

	public void RoyaltyChange()
	{
		RoyaltiesLabel.text = (Royalties.value / 100f).ToPercent();
	}

	public void LimitChange()
	{
		UnitLimitLabel.text = _target.UnitName.LocPlural((uint)UnitLimit.value);
	}

	public void Accept()
	{
		if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - GetCost()))
		{
			if (_player.Connected && _target.NetworkDeal == null)
			{
				if (_target.WorkItemID == null)
				{
					NetworkMessaging.GetGlobalNetworkID(delegate(uint x)
					{
						_target.WorkItemID = new NetworkDeal.NetworkWorkItemID(x);
						CreateDeal(_target, _player);
					}, NetworkManager.NetworkIDType.WorkItem);
				}
				else if (NetworkManager.Instance.TradeController.Trades.Values.None((NetworkTrade x) => x.UsingResource(_target.WorkItemID)))
				{
					CreateDeal(_target, _player);
				}
			}
			Window.Close();
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	private void CreateDeal(WorkItem target, NetworkPlayer player)
	{
		NetworkManager.Instance.TradeController.CreateOffer((uint id) => new NetworkDeal(id, NetworkManager.Self, player, target.WorkItemID.ID, OnAcceptValue, OnCompleteValue, PerUnitValue, RoyaltyValue, UnitLimitValue, EndDateValue, target.Name, target.UnitName, target.GetInfo()));
	}
}
