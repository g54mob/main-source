using MyBox;
using UnityEngine;
using UnityEngine.Localization.Components;

public class WarningCanvas : MonoBehaviour
{
	[Header("Checkout Warning")]
	[SerializeField]
	private CanvasGroup m_CheckoutNotification;

	[SerializeField]
	private CanvasGroup m_OnlineOrderNotification;

	[SerializeField]
	private CanvasGroup m_NoProfitNotification;

	[SerializeField]
	private CanvasGroup m_SelfCheckoutRepairNotification;

	[SerializeField]
	private CanvasGroup m_DirtyStoreNotification;

	[SerializeField]
	private CanvasGroup m_DLCContentRemovedNotification;

	[SerializeField]
	private float m_CheckoutWarning_FadeIn;

	[SerializeField]
	private float m_CheckoutWarning_FadeOut;

	[SerializeField]
	private float m_CheckoutWarning_Lifetime;

	[SerializeField]
	private float m_NoProfitWarning_Lifetime;

	[SerializeField]
	private float m_WholesaleOfferWarning_Lifetime;

	[SerializeField]
	private float m_DirtyStoreWarning_Lifetime;

	[SerializeField]
	private float m_ScaleWarning_Lifetime;

	[Header("Scale Warning")]
	[SerializeField]
	private CanvasGroup m_ScaleWarning;

	[Header("Wholesale Offer Notification")]
	[SerializeField]
	private CanvasGroup m_WholesaleOfferNotification;

	[SerializeField]
	private CanvasGroup m_WholesaleOfferAcceptedNotification;

	[SerializeField]
	private CanvasGroup m_WholesaleOfferDeclinedNotification;

	[Header("Interaction Warning")]
	[SerializeField]
	private CanvasGroup m_MasterLeaveWarningNotification;

	[SerializeField]
	private CanvasGroup m_InteractionWarningNotification;

	[SerializeField]
	private LocalizeStringEvent m_InteractionWarningLocalizedText;

	[SerializeField]
	private float m_InteractionWarning_FadeIn;

	[SerializeField]
	private float m_InteractionWarning_FadeOut;

	[SerializeField]
	private float m_InteractionWarning_Lifetime;

	[Header("Vehicle Warning")]
	[SerializeField]
	private CanvasGroup m_VehicleWarning;

	[Header("City Edge Warning")]
	[SerializeField]
	private CanvasGroup m_CityEdgeWarning;

	[SerializeField]
	private float m_CityEdgeWarning_Lifetime;

	[Header("Settings")]
	[SerializeField]
	private float m_MinTimeBetweenInteractionWarnings;

	[SerializeField]
	private float m_MinTimeBetweenCheckoutWarnings;

	[SerializeField]
	private float m_MinTimeBetweenOnlineOrderWarnings;

	[SerializeField]
	private float m_MinTimeBetweenNoProfitWarnings;

	[SerializeField]
	private float m_MınTimeBetweenDirtyStoreWarnings;

	[SerializeField]
	private float m_MinTimeBetweenWarnings;

	[SerializeField]
	private float m_MinTimeBetweenScaleWarnings;

	private float m_LastInteractionWarningTime;

	private float m_LastCheckoutWarningTime;

	private float m_LastOnlineOrderWarningTime;

	private float m_LastSelfCheckoutRepairWarningTime;

	private float m_LastNoProfitTime;

	private float m_LastDirtyStoreTime;

	private float m_LastScaleWarning;

	private float m_LastWarningTime;

	private void Start()
	{
	}

	private void ShowDLCContentRemovedWarning()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	private void ShowMasterLeaveWarning()
	{
	}

	private void ShowCityEdgeWarning()
	{
	}

	private void ShowScaleWarning()
	{
	}

	private void ShowVehiclePurchaseWarning()
	{
	}

	private void DirtyStoreWarning()
	{
	}

	private void ShowCheckoutWarning()
	{
	}

	private void ShowOnlineOrderWarning(string customerName)
	{
	}

	private void ShowSelfCheckoutRepairWarning()
	{
	}

	private void ShowNoProfitWarning()
	{
	}

	private void ShowWholesaleOfferWarning()
	{
	}

	private void ShowWholesaleOfferAcceptedWarning()
	{
	}

	private void ShowWholesaleOfferDeclinedWarning()
	{
	}

	private void ShowInteractionWarning(InteractionWarningType warningType, params string[] args)
	{
	}

	private void ShowInteractionWarningWithArgument(InteractionWarningType warningType, params string[] args)
	{
	}

	private void OnDestroy()
	{
	}
}
