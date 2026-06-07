using System.Collections;
using System.Collections.Generic;
using Enviro;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DayEndPanel : MonoBehaviour
{
	[Header("Panel")]
	[SerializeField]
	private GameObject panelObject;

	[Header("Money Rows (Onceden sahnede ekli)")]
	[Tooltip("Para satirlari - her biri kendi EconomyType'larina gore guncellenir")]
	[SerializeField]
	private List<DayEndRowUI> moneyRows = new List<DayEndRowUI>();

	[Header("Money Totals")]
	[SerializeField]
	private DayEndRowUI totalEarningsRow;

	[SerializeField]
	private DayEndRowUI totalExpensesRow;

	[SerializeField]
	private DayEndRowUI totalProfitRow;

	[Header("XP Rows (Onceden sahnede ekli)")]
	[Tooltip("XP satirlari - her biri kendi EconomyType'larina gore guncellenir")]
	[SerializeField]
	private List<DayEndRowUI> xpRows = new List<DayEndRowUI>();

	[Header("XP Totals & Info")]
	[SerializeField]
	private DayEndRowUI totalXPRow;

	[SerializeField]
	private TMP_Text factoryLevelText;

	[SerializeField]
	private TMP_Text remainingXPText;

	[Header("Server/Client UI")]
	[Tooltip("Sadece server/host'ta gorunur")]
	[SerializeField]
	private GameObject nextDayButtonObject;

	[Tooltip("Sadece client'larda gorunur")]
	[SerializeField]
	private GameObject waitingForHostObject;

	[Header("Events")]
	public UnityEvent onPanelOpened;

	public UnityEvent onPanelClosed;

	public UnityEvent onNextDayStarted;

	private bool _isOpen;

	public bool IsOpen => _isOpen;

	private void Awake()
	{
		if (panelObject != null)
		{
			panelObject.SetActive(value: false);
		}
	}

	private void Start()
	{
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted += OnDayStarted;
		}
	}

	private void OnDestroy()
	{
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted -= OnDayStarted;
		}
	}

	private void OnDayStarted()
	{
		if (_isOpen)
		{
			Close();
		}
	}

	public void Show(DaySummaryData summary)
	{
		if (!_isOpen)
		{
			if (panelObject != null)
			{
				panelObject.SetActive(value: true);
			}
			_isOpen = true;
			UpdatePanel(summary);
			UpdateServerClientUI();
			onPanelOpened?.Invoke();
			Debug.Log($"[DayEndPanel] Gun {summary.gameDay} ozeti gosteriliyor");
		}
	}

	private void UpdateServerClientUI()
	{
		bool active = NetworkServer.active;
		if (nextDayButtonObject != null)
		{
			nextDayButtonObject.SetActive(active);
		}
		if (waitingForHostObject != null)
		{
			waitingForHostObject.SetActive(!active);
		}
	}

	public void Close()
	{
		if (_isOpen)
		{
			if (panelObject != null)
			{
				panelObject.SetActive(value: false);
			}
			_isOpen = false;
			onPanelClosed?.Invoke();
			Debug.Log("[DayEndPanel] Panel kapatildi");
		}
	}

	private void UpdatePanel(DaySummaryData summary)
	{
		foreach (DayEndRowUI moneyRow in moneyRows)
		{
			if (moneyRow != null)
			{
				moneyRow.UpdateFromMoneyData(summary.incomeByType, summary.expenseByType);
			}
		}
		if (totalEarningsRow != null)
		{
			totalEarningsRow.SetValue(summary.totalIncome);
		}
		if (totalExpensesRow != null)
		{
			totalExpensesRow.SetValue(-summary.totalExpense);
		}
		if (totalProfitRow != null)
		{
			totalProfitRow.SetValue(summary.netProfit);
		}
		foreach (DayEndRowUI xpRow in xpRows)
		{
			if (xpRow != null)
			{
				xpRow.UpdateFromXPData(summary.xpByType);
			}
		}
		if (totalXPRow != null)
		{
			totalXPRow.SetValue(summary.totalXP);
		}
		if (factoryLevelText != null)
		{
			factoryLevelText.text = $"{summary.startLevel} > {summary.endLevel}";
		}
		if (remainingXPText != null && FactoryManager.Instance != null)
		{
			int currentXP = FactoryManager.Instance.CurrentXP;
			int requiredXPForNextLevel = FactoryManager.Instance.RequiredXPForNextLevel;
			remainingXPText.text = $"{currentXP}/{requiredXPForNextLevel}";
		}
	}

	public void OnStartNextDayClicked()
	{
		if (NetworkServer.active)
		{
			onNextDayStarted?.Invoke();
			if (DayNightManager.Instance != null)
			{
				DayNightManager.Instance.StartNewDay();
			}
			Close();
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.EndDay, TutorialStepType.EndDay, TutorialSubStepType.EndDaySub);
			}
		}
	}

	public void EndDemoAndKickAllPlayers()
	{
		Debug.Log("[DayEndPanel] Demo bitti! Level 3'e ulasildi. Tum oyunculara bildirim gonderiliyor...");
		NewNetworkManager instance = NewNetworkManager.Instance;
		if (instance != null)
		{
			instance.BroadcastDisconnectAndKickAll(DisconnectReason.DemoFinished);
			instance.ClearLobbyCode();
		}
		NewNetworkManager.SetDisconnectReason(DisconnectReason.DemoFinished);
		PauseMenuManager.LeaveSteamLobby();
		StartCoroutine(StopHostAndReturnToMenu());
	}

	private IEnumerator StopHostAndReturnToMenu()
	{
		LoadingManagerUI.Show(LoadingType.Menu);
		yield return new WaitForSeconds(0.5f);
		NewNetworkManager instance = NewNetworkManager.Instance;
		string offlineScene = ((instance != null) ? instance.offlineScene : "Main Menu");
		if (instance != null)
		{
			instance.StopHost();
		}
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(offlineScene);
	}

	[ContextMenu("Test: Show Sample Data")]
	private void TestShow()
	{
		DaySummaryData summary = new DaySummaryData
		{
			gameDay = 1,
			incomeByType = new Dictionary<EconomyType, int>
			{
				{
					EconomyType.EconomyType_Contract,
					200
				},
				{
					EconomyType.EconomyType_StockSale,
					200
				}
			},
			expenseByType = new Dictionary<EconomyType, int> { 
			{
				EconomyType.EconomyType_Upgrade,
				200
			} },
			xpByType = new Dictionary<EconomyType, int>
			{
				{
					EconomyType.EconomyType_Contract,
					350
				},
				{
					EconomyType.EconomyType_StockSale,
					20
				}
			},
			totalIncome = 400,
			totalExpense = 200,
			netProfit = 200,
			totalXP = 370,
			startLevel = 1,
			endLevel = 1,
			startMoney = 10000,
			endMoney = 10200
		};
		Show(summary);
	}
}
