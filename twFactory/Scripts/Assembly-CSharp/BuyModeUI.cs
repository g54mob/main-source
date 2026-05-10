using System;
using UnityEngine;

public class BuyModeUI : InGameModeUI
{
	[SerializeField]
	private CostUI costUIPrefab;

	[SerializeField]
	private Transform buyingObjectCostsContainer;

	private InGameUI inGameUI;

	private LTHUD ltHud;

	protected override void Start()
	{
		base.Start();
		inGameUI = GetComponentInParent<InGameUI>();
		ltHud = base.Hud as LTHUD;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		BuyModeInputMode buyModeInputMode = LTFunctionLibrary.GetLTPlayerController().LTHUD.LtPlayerController.CurrentInputMode as BuyModeInputMode;
		if ((bool)buyModeInputMode)
		{
			buyModeInputMode.onBuyingObjectChanged = (Action<PlacementComponent>)Delegate.Combine(buyModeInputMode.onBuyingObjectChanged, new Action<PlacementComponent>(OnBuyingObjectChanged));
			buyModeInputMode.LockClicks = false;
			OnBuyingObjectChanged((LTFunctionLibrary.GetLTPlayerController().CurrentInputMode as BuyModeInputMode).BuyingObject);
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		DestroyCostUI();
		if ((bool)((base.Hud as LTHUD).LtPlayerController.CurrentInputMode as BuyModeInputMode))
		{
			BuyModeInputMode obj = (base.Hud as LTHUD).LtPlayerController.CurrentInputMode as BuyModeInputMode;
			obj.onBuyingObjectChanged = (Action<PlacementComponent>)Delegate.Remove(obj.onBuyingObjectChanged, new Action<PlacementComponent>(OnBuyingObjectChanged));
		}
		BuyModeInputMode buyModeInputMode = LTFunctionLibrary.GetLTPlayerController().LTHUD.LtPlayerController.CurrentInputMode as BuyModeInputMode;
		if ((bool)buyModeInputMode)
		{
			buyModeInputMode.StopBuyingObject();
			buyModeInputMode.LockClicks = true;
		}
	}

	private void CreateCostUI(GameplayObjectData buyingObjectData)
	{
		DestroyCostUI();
		Cost[] buyCost = buyingObjectData.BuyCost;
		foreach (Cost data in buyCost)
		{
			UnityEngine.Object.Instantiate(costUIPrefab, buyingObjectCostsContainer).Data = data;
		}
	}

	private void DestroyCostUI()
	{
		buyingObjectCostsContainer.DeleteAllChildren();
	}

	public override bool BackButtonPressed()
	{
		if (base.BackButtonPressed())
		{
			ltHud.ShowStandardModeUI();
			return true;
		}
		return false;
	}

	private void OnBuyingObjectChanged(PlacementComponent placementComponent)
	{
		if ((bool)placementComponent)
		{
			CreateCostUI(placementComponent.MainObject.ObjectData);
		}
	}
}
