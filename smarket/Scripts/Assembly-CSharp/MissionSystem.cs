using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class MissionSystem : NoktaSingletonPunCallbacks<MissionSystem>
{
	[CompilerGenerated]
	private sealed class _003CDelayedObjectiveCheck_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MissionSystem _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CDelayedObjectiveCheck_003Ed__12(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private MissionContainer m_MissionContainer;

	private bool m_CleaningObjectiveStarted;

	[Space]
	[SerializeField]
	private Color m_CompletedObjectiveTextColor;

	[SerializeField]
	private float m_CompletedObjectiveLifetime;

	private bool m_IsInWaiting;

	[Header("Checkout Mission")]
	[SerializeField]
	private GameObject m_CheckoutObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_CheckoutObjectiveCounter;

	[SerializeField]
	private int m_CheckoutObjectiveGoal;

	[Header("Cleaning Mission")]
	[SerializeField]
	private GameObject m_CleaningObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_GarbageObjectiveCounter;

	[SerializeField]
	private int m_GarbageObjectiveGoal;

	[SerializeField]
	private TMP_Text m_DirtObjectiveCounter;

	[SerializeField]
	private int m_DirtObjectiveGoal;

	[SerializeField]
	private TMP_Text m_GlassObjectiveCounter;

	[SerializeField]
	private int m_GlassObjectiveGoal;

	[Header("Shelf Mission")]
	[SerializeField]
	private GameObject m_ShelfObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_ShelfObjectiveCounter;

	[SerializeField]
	private int m_ShelfObjectiveGoal;

	[Header("License Mission")]
	[SerializeField]
	private GameObject m_LicenseObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_LicenseObjectiveCounter;

	[SerializeField]
	private int m_LicenseObjectiveGoal;

	[Header("Section Mission")]
	[SerializeField]
	private GameObject m_SecitonObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_SecitonObjectiveCounter;

	[SerializeField]
	private int m_SecitonObjectiveGoal;

	[Header("Name Mission")]
	[SerializeField]
	private GameObject m_NameObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_NameObjectiveCounterText;

	[Header("Paint Mission")]
	[SerializeField]
	private GameObject m_PaintObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_PaintObjectiveCounterText;

	[SerializeField]
	private int m_PaintObjectiveGoal;

	[Header("Tablet Buy Mission")]
	[SerializeField]
	private GameObject m_TabletBuyObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_TabletBuyObjectiveCounterText;

	[Header("Tablet Order Mission")]
	[SerializeField]
	private GameObject m_TabletOrderObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_TabletOrderObjectiveCounterText;

	[Header("Crate Buy Mission")]
	[SerializeField]
	private GameObject m_CrateBuyObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_CrateBuyObjectiveCounterText;

	[Header("Crate Enable Mission")]
	[SerializeField]
	private GameObject m_CrateEnableObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_CrateEnableObjectiveCounterText;

	[Header("Bat Order Mission")]
	[SerializeField]
	private GameObject m_BatOrderObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_BatOrderObjectiveCounterText;

	[Header("Bat Enable Mission")]
	[SerializeField]
	private GameObject m_ShoplifterObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_BatEnableObjectiveCounterText;

	[SerializeField]
	private TMP_Text m_ShoplifterHitObjectiveCounterText;

	[Header("Veggies Licence Mission")]
	[SerializeField]
	private GameObject m_VeggiesLicenceObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_VeggiesLicenceObjectiveCounterText;

	[Header("Veggies Purchase Mission")]
	[SerializeField]
	private GameObject m_VeggiesPurchaseObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_VegetablePurchaseObjectiveCounterText;

	[SerializeField]
	private TMP_Text m_ScalePurchaseObjectiveCounterText;

	[SerializeField]
	private TMP_Text m_StallPurchaseObjectiveCounterText;

	[SerializeField]
	private TMP_Text m_VegetablePlaceObjectiveCounterText;

	public Action<DisplayType> onVeggiePlaced;

	[SerializeField]
	private OnlineOrderTutorial m_OnlineOrderTutorial;

	[Header("Multiplayer Missions")]
	[Space]
	[Header("Product Buy Mission")]
	[SerializeField]
	private GameObject m_ProductBuyObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_ProductBuyObjectiveCounterText;

	[Header("Product Place Mission")]
	[SerializeField]
	private GameObject m_PlaceProductObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_PlaceProductObjectiveCounterText;

	private int m_PlacedProductCount;

	public Action OnProductPlacedToDisplay;

	[Header("Set Price Mission")]
	[SerializeField]
	private GameObject m_SetPriceObjectiveCanvas;

	[SerializeField]
	private TMP_Text m_SetPriceObjectiveCounterText;

	public bool CanStartTabletObjective => false;

	public bool CompletedCheckoutObjective => false;

	public bool CompletedCleaningObjective => false;

	public bool CompletedShelfObjective => false;

	public bool CompletedLicenseObjective => false;

	public bool CompletedSectionObjective => false;

	public bool CompletedNameObjective => false;

	public bool CompletedPaintObjective => false;

	public bool CompletedTabletBuyObjective => false;

	public bool CompletedTabletOrderObjective => false;

	public bool CompletedCrateBuyObjective => false;

	public bool CompletedCrateEnableObjective => false;

	public bool CompletedBatBuyObjective => false;

	public bool CompletedShoplifterObjective => false;

	public bool CompletedVeggiesLicenceObjective => false;

	public bool CompletedVeggiesPurchaseObjective => false;

	public bool CompletedProductBuyObjective => false;

	public bool CompletedPlaceProductObjective => false;

	public bool CompletedSetPriceObjective => false;

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void CheckSinglePlayerShoplifterProgress()
	{
	}

	private void OnDestroy()
	{
	}

	private bool CheckIfObjectiveCompleted(int goal, int current, TMP_Text counterText)
	{
		return false;
	}

	private void OnStoreLevelChanged(bool obj)
	{
	}

	public void OnObjectiveCompleted()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedObjectiveCheck_003Ed__12))]
	private IEnumerator DelayedObjectiveCheck()
	{
		return null;
	}

	public void LookForNewObjectiveInt(int _)
	{
	}

	public void LookForNewObjective()
	{
	}

	private void StartCheckoutObjective()
	{
	}

	private void OnCheckoutCompleted()
	{
	}

	private void StartCleaningObjective()
	{
	}

	private void OnCleaningComplete(bool isFromGarbage)
	{
	}

	private void UpdateCleaningStatus()
	{
	}

	private void StartShelfObjective()
	{
	}

	private void OnShelfObjectiveCompleted()
	{
	}

	private void StartLicenseObjective()
	{
	}

	private void OnLicensePurchased(int _)
	{
	}

	private void StartSectionObjective()
	{
	}

	private void OnSectionPurchased(int _)
	{
	}

	private void StartNameObjective()
	{
	}

	private void OnNameChanged()
	{
	}

	private void StartPaintObjective()
	{
	}

	private void OnWallPainted()
	{
	}

	private void StartTabletBuyObjective()
	{
	}

	private void OnTabletBought()
	{
	}

	private void StartTabletOrderObjective()
	{
	}

	private void OnTabletOrdered()
	{
	}

	private void StartCrateBuyObjective()
	{
	}

	private void OnCrateBought()
	{
	}

	private void StartCrateEnableObjective()
	{
	}

	private void OnCrateEnabled()
	{
	}

	private void StartBatOrderObjective()
	{
	}

	private void OnBatBought()
	{
	}

	private void StartShoplifterObjective()
	{
	}

	private void OnBatEnabled()
	{
	}

	private void OnShoplifterBeaten()
	{
	}

	private void OnShoplifterTutorial()
	{
	}

	private void StartVeggiesLicenceObjective()
	{
	}

	private void OnVeggiesLicencePurchased(int licence)
	{
	}

	public void StartVeggiesPurchaseObjective()
	{
	}

	private void OnVeggiePurchaseObjective()
	{
	}

	private void OnVeggieBought()
	{
	}

	private void OnScaleBought()
	{
	}

	private void OnStallBought()
	{
	}

	private void OnVeggiePlacedToStall(DisplayType displayType)
	{
	}

	private void SetMultiplayerSaveData()
	{
	}

	public void InitializeMasterMissions()
	{
	}

	public void SyncClientData_Broadcast(string userId)
	{
	}

	[PunRPC]
	public void SetClientData_RPC(object[] data)
	{
	}

	public void InitializeClientMissionState()
	{
	}

	public void NetworkMissionProgress(int missionId, object[] args, bool hasFinished)
	{
	}

	private void CheckNetworkMissionData(int missionId, object[] args)
	{
	}

	public void MissionProgress_Request(int missionId, object[] args, bool hasFinished, string userId)
	{
	}

	[PunRPC]
	public void MissionProgress_Broadcast(int missionId, object[] args, bool hasFinished, string senderUserId)
	{
	}

	[PunRPC]
	public void MissionProgress_RPC(int missionId, object[] args, bool hasFinished, string senderUserId)
	{
	}

	public void StartBuyProductObjective()
	{
	}

	public void OnProductBought(bool _)
	{
	}

	public void StartPlaceProductObjective()
	{
	}

	private void OnProductPlaced()
	{
	}

	private void UpdatePlacedProductData()
	{
	}

	public void StartSetPriceObjective()
	{
	}

	public void OnPriceSet(int _)
	{
	}
}
