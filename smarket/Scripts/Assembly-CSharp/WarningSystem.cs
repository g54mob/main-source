using System;
using MyBox;
using Photon.Pun;
using UnityEngine;

public class WarningSystem : NoktaSingletonPunCallbacks<WarningSystem>
{
	public delegate void InteractionWarningRaisedDelegate(InteractionWarningType warningType, params string[] messages);

	[Separator("Customer Speech", false)]
	[SerializeField]
	private CustomerSpeech m_CustomerSpeechPrefab;

	[SerializeField]
	private float m_CustomerSpeechLifetime;

	public Action onMasterLeaveTheGame;

	public Action onCheckoutWarningRaised;

	public Action<string> onOnlineOrderWarningRaised;

	public Action onNoProfitWarningRaised;

	public Action onSelfCheckoutRepairWarningRaised;

	public Action onDirtyStoreWarningRaised;

	public Action onScaleWarningRaised;

	public Action onCityEdgeWarningRaised;

	public Action onShowVehiclePurchaseWarning;

	public Action onDLCContentRemovedWarning;

	public InteractionWarningRaisedDelegate onInteractionWarningRaised;

	public InteractionWarningRaisedDelegate onInteractionWarningWithArgumentRaised;

	public float CustomerSpeechFontSize => 0f;

	public void RaiseMasterLeaveEvent()
	{
	}

	public void RaiseVehiclePurchaseWarning()
	{
	}

	public void RaiseScaleWarning()
	{
	}

	public void RaiseCityEdgeWarning()
	{
	}

	public void RaiseCheckoutWarning()
	{
	}

	public void RaiseOnlineOrderWarning(string customerName)
	{
	}

	public void RaiseDirtyStoreWarning()
	{
	}

	public void RaiseNoProfitWarning()
	{
	}

	public void RaiseSelfCheckoutRepairWarning()
	{
	}

	public void SpawnCustomerSpeech(CustomerSpeechType speechType, Transform customer, params string[] args)
	{
	}

	public void SpawnCustomerSpeech_Broadcast(CustomerSpeechType speechType, Transform customer, params string[] args)
	{
	}

	[PunRPC]
	public void SpawnCustomerSpeech_RPC(int speechTypeInt, int customerViewId, string argsJson)
	{
	}

	public void SpawnCustomerSpeech_Order(CustomerSpeechType speechType, Transform customer, params string[] args)
	{
	}

	public void SpawnGuardSpeech(CustomerSpeechType speechType, Transform customer, float extraHeigh, params string[] args)
	{
	}

	public void SpawnRestockerSpeech(CustomerSpeechType speechType, Transform restocker, params string[] args)
	{
	}

	public void SpawnBakerSpeech(CustomerSpeechType speechType, Transform baker, params string[] args)
	{
	}

	public void SpawnShoplifterSpeech(string entry, Transform customer, params string[] args)
	{
	}

	public void SpawnOnlineOrderCustomerSpeech(string entry, Transform customer, params string[] args)
	{
	}

	public void SpawnIceCreamHelperSpeech(CustomerSpeechType speechType, Transform helper, params string[] args)
	{
	}

	public void SpawnIceCreamHelperSpeech_Broadcast(CustomerSpeechType speechType, Transform customer, params string[] args)
	{
	}

	[PunRPC]
	public void SpawnIceCreamHelperSpeech_RPC(int speechTypeInt, int customerViewId, string argsJson)
	{
	}

	public void SpawnIceCreamHelper_Order(CustomerSpeechType speechType, Transform customer, params string[] args)
	{
	}

	public void RaiseInteractionWarning(InteractionWarningType warningType, params string[] args)
	{
	}

	public void RaiseInteractionWarningWithArgument(InteractionWarningType warningType, params string[] args)
	{
	}

	[PunRPC]
	public void RaiseInteractionWarning_RPC(InteractionWarningType warningType, params string[] args)
	{
	}

	public void RaiseDLCContentRemoveWarning()
	{
	}
}
