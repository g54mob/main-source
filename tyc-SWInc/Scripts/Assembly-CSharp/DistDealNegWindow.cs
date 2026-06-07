using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistDealNegWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Text BidHistory;

	public Text CurrentBid;

	public Text RejectButton;

	public Slider Slider;

	[NonSerialized]
	private SimulatedCompany _otherCompany;

	private float _currentAIBid;

	private float _currentPlayerBid;

	private float _actualBid;

	private float _maxBid;

	private float _playerMaxBid;

	private float _patience;

	private float _lastPlayerChange;

	private int _bids;

	private bool _firstRound;

	private bool _hasPlayerBid;

	public void Show(SimulatedCompany company, CompanyDetailWindow callback)
	{
	}

	public void MakeOfferClick()
	{
		MakeOffer(true, GetSliderBid());
		RunAILogic();
	}

	private void RunAILogic()
	{
		int num = Mathf.RoundToInt(_otherCompany.BusinessSavy.MapRange(0f, 1f, 8f, 4f));
		if (_bids >= num)
		{
			Reject(true);
			return;
		}
		float num2 = Mathf.Lerp(_currentAIBid, _currentPlayerBid, _otherCompany.BusinessSavy.MapRange(0f, 1f, 0.5f, 0.25f));
		if (num2 >= _maxBid)
		{
			Reject(true);
			return;
		}
		if (!_firstRound)
		{
			_patience += _otherCompany.BusinessSavy.MapRange(0f, 1f, 0.5f, 0.25f) - _lastPlayerChange;
			if (_patience <= 0f)
			{
				Reject(true);
				return;
			}
		}
		_firstRound = false;
		if (_currentPlayerBid < _maxBid && Mathf.Abs(num2 - _currentPlayerBid) < _otherCompany.BusinessSavy.MapRange(0f, 1f, 0.03f, 0.01f))
		{
			WindowManager.Instance.ShowMessageBox("AiCompanyDistDealAccept".LocColor(_otherCompany), true, DialogWindow.DialogType.Information);
			Accept();
		}
		MakeOffer(false, num2);
	}

	public void Reject(bool other)
	{
	}

	private void FailDeal()
	{
	}

	private void MakeOffer(bool player, float offer)
	{
		if (!player)
		{
			BidHistory.text += "BidAction".Loc(_otherCompany.Name, offer.ToPercent());
			_currentAIBid = offer;
		}
		else
		{
			BidHistory.text += "BidAction".Loc(GameSettings.Instance.MyCompany.Name, offer.ToPercent());
			_hasPlayerBid = true;
			RejectButton.text = "Reject".Loc();
			if (!_firstRound)
			{
				_lastPlayerChange = ((_currentPlayerBid == 0f) ? offer : (offer / _currentPlayerBid));
			}
			_playerMaxBid = (_currentPlayerBid = offer);
			_bids++;
		}
		BidHistory.text += "\n";
		_actualBid = offer;
		Slider.value = 1f;
		SliderChange();
	}

	public float GetSliderBid()
	{
		return Slider.value.MapRange(0f, 1f, _actualBid, _playerMaxBid);
	}

	public void SliderChange()
	{
		CurrentBid.text = GetSliderBid().ToPercent();
	}

	public void Accept()
	{
	}

	public float GetMaxWilling()
	{
		double num = GameSettings.Instance.simulation.GetAllCompanies().MaxSafe((Company x) => x.Products.SumSafe((SoftwareProduct z) => z.Sum), 0.0);
		double num2 = ((num == 0.0) ? 1.0 : (_otherCompany.Products.SumSafe((SoftwareProduct x) => x.Sum) / num));
		List<float> playerDigitalShare = GameSettings.Instance.simulation.PlayerDigitalShare;
		return (float)(Utilities.Lerp(0.25 - num2 * 0.25, 1.0, Mathf.Pow(playerDigitalShare[playerDigitalShare.Count - 1], 3f), true) * (double)MarketSimulation.DistributionStandardCut);
	}
}
