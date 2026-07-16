using MLCN_Localization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
	[SerializeField]
	private GameObject hudObject;

	[SerializeField]
	private GameObject demoLabel;

	[SerializeField]
	private TMP_Text labelTime;

	[SerializeField]
	private TMP_Text labelCafeState;

	[SerializeField]
	private TMP_Text labelCafeCloseTime;

	[SerializeField]
	private TMP_Text labelQueueCount;

	[SerializeField]
	private UIContentAnimator animatorDeliveryArrived;

	[SerializeField]
	private UIContentAnimator animatorNewCustomerArrived;

	[SerializeField]
	private UIContentAnimator animatorCupWasTakenAway;

	[Header("DarkRoom")]
	[SerializeField]
	private UIContentAnimator animatorAnomalyEffectEventBanner;

	[SerializeField]
	private TMP_Text labelAnomalyEffectMessage;

	private void Start()
	{
		Init();
	}

	public void Init()
	{
		if (GameStateManager.IsValidated() && GameStateManager.GetCurrentGameState() == GameStateManager.GameState.TitleScreen)
		{
			hudObject.SetActive(value: false);
			UpdateDemoLabel();
			SceneManager.activeSceneChanged += delegate
			{
				UpdateDemoLabel();
			};
			return;
		}
		SetTimeLabel();
		SetCafeState(open: false);
		SetQueueCount();
		WorldTime.instance.OnGlolbalTimeTickFinished.AddListener(SetTimeLabel);
		CafeShopManager.OnCafeStateChanged.AddListener(SetCafeState);
		CafeShopManager.OnUpdateCustomersInQueue.AddListener(SetQueueCount);
		DeliverSystem.OnDeliveryArrives.AddListener(ShowDeliveryArrived);
		CafeShopManager.OnNewCustomerArrived.AddListener(ShowNewCustomerArrived);
		CafeShopManager.OnCupWasTakenAway.AddListener(ShowCupWasTakenAway);
		animatorDeliveryArrived.BeginWithNormalState();
		animatorNewCustomerArrived.BeginWithNormalState();
		animatorCupWasTakenAway.BeginWithNormalState();
		animatorAnomalyEffectEventBanner.BeginWithNormalState();
		labelCafeCloseTime.gameObject.SetActive(value: false);
		UpdateDemoLabel();
	}

	public void ShowHUD()
	{
		hudObject.SetActive(value: true);
	}

	public void HideHUD()
	{
		hudObject.SetActive(value: false);
	}

	private void UpdateDemoLabel()
	{
		if (!(demoLabel == null))
		{
			if (GameStateManager.IsValidated() && GameStateManager.GetCurrentGameState() == GameStateManager.GameState.TitleScreen)
			{
				demoLabel.gameObject.SetActive(value: true);
			}
			else
			{
				demoLabel.gameObject.SetActive(value: false);
			}
		}
	}

	private void SetTimeLabel()
	{
		labelTime.text = WorldTime.GetGlobalTime().GetTimeFormatted();
	}

	private void SetCafeState(bool open)
	{
		labelCafeState.text = (open ? LocalizationManager.GetLocalizedString("ui_hud_cafestate_open", LocalizationDataTable.Tables.UI) : LocalizationManager.GetLocalizedString("ui_hud_cafestate_closed", LocalizationDataTable.Tables.UI));
		labelCafeCloseTime.text = WorldTime.GetEndOfWorkDayTime().GetTimeFormatted();
		labelCafeCloseTime.gameObject.SetActive(open);
	}

	private void SetQueueCount()
	{
		labelQueueCount.text = CafeShopManager.GetQueueLineOccupationCount().ToString();
	}

	private void ShowDeliveryArrived()
	{
		if (!animatorDeliveryArrived.IsPlaying() && animatorDeliveryArrived.animatorState == UIContentAnimator.AnimatorState.BeginState)
		{
			TweenerManager.TweenTimeAction("NewDeliveryArrived", 3f, delegate
			{
				animatorDeliveryArrived.OnReverse();
			});
			animatorDeliveryArrived.OnPlay();
		}
	}

	private void ShowNewCustomerArrived()
	{
		if (!animatorNewCustomerArrived.IsPlaying() && animatorNewCustomerArrived.animatorState == UIContentAnimator.AnimatorState.BeginState)
		{
			TweenerManager.TweenTimeAction("NewCustomerArrived", 3f, delegate
			{
				animatorNewCustomerArrived.OnReverse();
			});
			animatorNewCustomerArrived.OnPlay();
		}
	}

	private void ShowCupWasTakenAway()
	{
		if (!animatorCupWasTakenAway.IsPlaying() && animatorCupWasTakenAway.animatorState == UIContentAnimator.AnimatorState.BeginState)
		{
			TweenerManager.TweenTimeAction("CupWasTakenAway", 3f, delegate
			{
				animatorCupWasTakenAway.OnReverse();
			});
			animatorCupWasTakenAway.OnPlay();
		}
	}

	public void ShowDarkRoomEventBanner(string msg)
	{
		labelAnomalyEffectMessage.text = msg;
		animatorAnomalyEffectEventBanner.OnPlay();
	}

	public void HideDarkRoomEventBanner()
	{
		labelAnomalyEffectMessage.text = "";
		animatorAnomalyEffectEventBanner.OnReverse();
	}
}
