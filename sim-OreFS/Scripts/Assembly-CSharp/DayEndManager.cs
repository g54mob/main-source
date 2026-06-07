using System;
using System.Collections;
using System.Collections.Generic;
using Enviro;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class DayEndManager : NetworkBehaviour
{
	private Dictionary<EconomyType, int> dailyTransactions = new Dictionary<EconomyType, int>();

	private Dictionary<EconomyType, int> dailyXP = new Dictionary<EconomyType, int>();

	private int startOfDayMoney;

	private int startOfDayXP;

	private int startOfDayLevel = 1;

	public static DayEndManager Instance { get; private set; }

	public event Action<DaySummaryData> OnDaySummaryReady;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		InitializeDictionaries();
		StartCoroutine(SubscribeToEvents());
	}

	private IEnumerator SubscribeToEvents()
	{
		while (FactoryManager.Instance == null)
		{
			yield return null;
		}
		FactoryManager.Instance.OnMoneyTransaction += OnMoneyTransaction;
		FactoryManager.Instance.OnXPTransaction += OnXPTransaction;
		startOfDayMoney = FactoryManager.Instance.Money;
		startOfDayXP = FactoryManager.Instance.CurrentXP;
		startOfDayLevel = FactoryManager.Instance.Level;
		while (DayNightManager.Instance == null)
		{
			yield return null;
		}
		DayNightManager.Instance.OnDayEnded += HandleDayEnded;
		DayNightManager.Instance.OnDayStarted += HandleDayStarted;
		Debug.Log("[DayEndManager] Event'lere subscribe olundu.");
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.OnMoneyTransaction -= OnMoneyTransaction;
			FactoryManager.Instance.OnXPTransaction -= OnXPTransaction;
		}
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayEnded -= HandleDayEnded;
			DayNightManager.Instance.OnDayStarted -= HandleDayStarted;
		}
	}

	private void InitializeDictionaries()
	{
		dailyTransactions.Clear();
		dailyXP.Clear();
		foreach (EconomyType value in Enum.GetValues(typeof(EconomyType)))
		{
			dailyTransactions[value] = 0;
			dailyXP[value] = 0;
		}
	}

	private void OnMoneyTransaction(int amount, EconomyType economyType)
	{
		dailyTransactions[economyType] += amount;
	}

	private void OnXPTransaction(int amount, EconomyType economyType)
	{
		if (amount > 0)
		{
			dailyXP[economyType] += amount;
		}
	}

	private void HandleDayEnded()
	{
		Debug.Log("[DayEndManager] Gun sona erdi, ozet paneli icin hazir.");
	}

	private void HandleDayStarted()
	{
		ResetDailyData();
	}

	public void ShowDaySummary()
	{
		if (NetworkServer.active)
		{
			DaySummaryData daySummaryData = CreateSummaryData();
			RpcShowDaySummary(daySummaryData.gameDay, SerializeDictionary(daySummaryData.incomeByType), SerializeDictionary(daySummaryData.expenseByType), SerializeDictionary(daySummaryData.xpByType), daySummaryData.totalIncome, daySummaryData.totalExpense, daySummaryData.netProfit, daySummaryData.startMoney, daySummaryData.endMoney, daySummaryData.totalXP, daySummaryData.startLevel, daySummaryData.endLevel);
		}
	}

	[ClientRpc]
	private void RpcShowDaySummary(int gameDay, EconomyEntry[] incomeEntries, EconomyEntry[] expenseEntries, EconomyEntry[] xpEntries, int totalIncome, int totalExpense, int netProfit, int startMoney, int endMoney, int totalXP, int startLevel, int endLevel)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(gameDay);
		GeneratedNetworkCode._Write_EconomyEntry_005B_005D(writer, incomeEntries);
		GeneratedNetworkCode._Write_EconomyEntry_005B_005D(writer, expenseEntries);
		GeneratedNetworkCode._Write_EconomyEntry_005B_005D(writer, xpEntries);
		writer.WriteVarInt(totalIncome);
		writer.WriteVarInt(totalExpense);
		writer.WriteVarInt(netProfit);
		writer.WriteVarInt(startMoney);
		writer.WriteVarInt(endMoney);
		writer.WriteVarInt(totalXP);
		writer.WriteVarInt(startLevel);
		writer.WriteVarInt(endLevel);
		SendRPCInternal("System.Void DayEndManager::RpcShowDaySummary(System.Int32,EconomyEntry[],EconomyEntry[],EconomyEntry[],System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)", -1931746194, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ResetDailyData()
	{
		InitializeDictionaries();
		if (FactoryManager.Instance != null)
		{
			startOfDayMoney = FactoryManager.Instance.Money;
			startOfDayXP = FactoryManager.Instance.CurrentXP;
			startOfDayLevel = FactoryManager.Instance.Level;
		}
	}

	public DaySummaryData GetCurrentSummary()
	{
		return CreateSummaryData();
	}

	private EconomyEntry[] SerializeDictionary(Dictionary<EconomyType, int> dict)
	{
		if (dict == null || dict.Count == 0)
		{
			return new EconomyEntry[0];
		}
		List<EconomyEntry> list = new List<EconomyEntry>();
		foreach (KeyValuePair<EconomyType, int> item in dict)
		{
			list.Add(new EconomyEntry
			{
				type = item.Key,
				value = item.Value
			});
		}
		return list.ToArray();
	}

	private Dictionary<EconomyType, int> DeserializeToDictionary(EconomyEntry[] entries)
	{
		Dictionary<EconomyType, int> dictionary = new Dictionary<EconomyType, int>();
		if (entries == null)
		{
			return dictionary;
		}
		for (int i = 0; i < entries.Length; i++)
		{
			EconomyEntry economyEntry = entries[i];
			dictionary[economyEntry.type] = economyEntry.value;
		}
		return dictionary;
	}

	private DaySummaryData CreateSummaryData()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		Dictionary<EconomyType, int> dictionary = new Dictionary<EconomyType, int>();
		Dictionary<EconomyType, int> dictionary2 = new Dictionary<EconomyType, int>();
		foreach (KeyValuePair<EconomyType, int> dailyTransaction in dailyTransactions)
		{
			if (dailyTransaction.Value > 0)
			{
				dictionary[dailyTransaction.Key] = dailyTransaction.Value;
				num += dailyTransaction.Value;
			}
			else if (dailyTransaction.Value < 0)
			{
				dictionary2[dailyTransaction.Key] = Mathf.Abs(dailyTransaction.Value);
				num2 += Mathf.Abs(dailyTransaction.Value);
			}
		}
		Dictionary<EconomyType, int> dictionary3 = new Dictionary<EconomyType, int>();
		foreach (KeyValuePair<EconomyType, int> item in dailyXP)
		{
			if (item.Value > 0)
			{
				dictionary3[item.Key] = item.Value;
				num3 += item.Value;
			}
		}
		int endMoney = ((FactoryManager.Instance != null) ? FactoryManager.Instance.Money : 0);
		int endLevel = ((!(FactoryManager.Instance != null)) ? 1 : FactoryManager.Instance.Level);
		int gameDay = ((!(DayNightManager.Instance != null)) ? 1 : DayNightManager.Instance.CurrentGameDay);
		return new DaySummaryData
		{
			gameDay = gameDay,
			incomeByType = dictionary,
			expenseByType = dictionary2,
			xpByType = dictionary3,
			totalIncome = num,
			totalExpense = num2,
			netProfit = num - num2,
			startMoney = startOfDayMoney,
			endMoney = endMoney,
			totalXP = num3,
			startLevel = startOfDayLevel,
			endLevel = endLevel
		};
	}

	[ContextMenu("Test: Show Day Summary")]
	private void TestShowSummary()
	{
		InitializeDictionaries();
		OnMoneyTransaction(5000, EconomyType.EconomyType_Sale);
		OnMoneyTransaction(3000, EconomyType.EconomyType_Contract);
		OnMoneyTransaction(-2000, EconomyType.EconomyType_Purchase);
		OnMoneyTransaction(-1500, EconomyType.EconomyType_Upgrade);
		OnMoneyTransaction(-500, EconomyType.EconomyType_Building);
		OnXPTransaction(100, EconomyType.EconomyType_Sale);
		OnXPTransaction(50, EconomyType.EconomyType_Contract);
		ShowDaySummary();
	}

	[ContextMenu("Test: Reset Daily Data")]
	private void TestReset()
	{
		ResetDailyData();
		Debug.Log("[DayEndManager] Gunluk veriler sifirlandi.");
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcShowDaySummary__Int32__EconomyEntry_005B_005D__EconomyEntry_005B_005D__EconomyEntry_005B_005D__Int32__Int32__Int32__Int32__Int32__Int32__Int32__Int32(int gameDay, EconomyEntry[] incomeEntries, EconomyEntry[] expenseEntries, EconomyEntry[] xpEntries, int totalIncome, int totalExpense, int netProfit, int startMoney, int endMoney, int totalXP, int startLevel, int endLevel)
	{
		DaySummaryData daySummaryData = new DaySummaryData
		{
			gameDay = gameDay,
			incomeByType = DeserializeToDictionary(incomeEntries),
			expenseByType = DeserializeToDictionary(expenseEntries),
			xpByType = DeserializeToDictionary(xpEntries),
			totalIncome = totalIncome,
			totalExpense = totalExpense,
			netProfit = netProfit,
			startMoney = startMoney,
			endMoney = endMoney,
			totalXP = totalXP,
			startLevel = startLevel,
			endLevel = endLevel
		};
		this.OnDaySummaryReady?.Invoke(daySummaryData);
		if (GameManager.Instance != null && GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.dayEndPanel != null)
		{
			GameManager.Instance.UImanager.dayEndPanel.Show(daySummaryData);
		}
		Debug.Log($"[DayEndManager] Gun {gameDay} ozeti alindi (Client)");
	}

	protected static void InvokeUserCode_RpcShowDaySummary__Int32__EconomyEntry_005B_005D__EconomyEntry_005B_005D__EconomyEntry_005B_005D__Int32__Int32__Int32__Int32__Int32__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowDaySummary called on server.");
		}
		else
		{
			((DayEndManager)obj).UserCode_RpcShowDaySummary__Int32__EconomyEntry_005B_005D__EconomyEntry_005B_005D__EconomyEntry_005B_005D__Int32__Int32__Int32__Int32__Int32__Int32__Int32__Int32(reader.ReadVarInt(), GeneratedNetworkCode._Read_EconomyEntry_005B_005D(reader), GeneratedNetworkCode._Read_EconomyEntry_005B_005D(reader), GeneratedNetworkCode._Read_EconomyEntry_005B_005D(reader), reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	static DayEndManager()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(DayEndManager), "System.Void DayEndManager::RpcShowDaySummary(System.Int32,EconomyEntry[],EconomyEntry[],EconomyEntry[],System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)", InvokeUserCode_RpcShowDaySummary__Int32__EconomyEntry_005B_005D__EconomyEntry_005B_005D__EconomyEntry_005B_005D__Int32__Int32__Int32__Int32__Int32__Int32__Int32__Int32);
	}
}
