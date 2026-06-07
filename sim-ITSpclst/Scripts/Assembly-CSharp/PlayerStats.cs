using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	[Header("Instance")]
	public static PlayerStats instance;

	[Header("ExpBar")]
	public Image expViewPower;

	public TextMeshProUGUI levelText;

	[Header("Avatar")]
	public Image avatarPlayer;

	public Sprite[] avatarList;

	[Header("Variable")]
	public int playerLevel;

	public int playerCurrentExp;

	public int playerExpToNewLvl;

	public int playerAdditionalExpToMax;

	public string mainPlayerTitle;

	public string loginAdmin;

	public string passwordAdmin;

	[Header("ADDITIONAL")]
	public int playerReputation;

	public int taskCompletedCounter;

	public int taskFiredCounter;

	[Header("Task Categorry")]
	public int taskNetworkCompleted;

	public int taskNetworkFired;

	public int taskPrinterCompleted;

	public int taskPrinterFired;

	public int taskPDACompleted;

	public int taskPDAFired;

	public int taskRCPCompleted;

	public int taskRCPFired;

	public int taskComputerCompleted;

	public int taskComputerFired;

	[HideInInspector]
	[Header("Daily Counter")]
	public int daily_taskNetworkCompleted;

	[HideInInspector]
	public int daily_taskNetworkFired;

	[HideInInspector]
	public int daily_taskPrinterCompleted;

	[HideInInspector]
	public int daily_taskPrinterFired;

	[HideInInspector]
	public int daily_taskPDACompleted;

	[HideInInspector]
	public int daily_taskPDAFired;

	[HideInInspector]
	public int daily_taskRCPCompleted;

	[HideInInspector]
	public int daily_taskRCPFired;

	[HideInInspector]
	public int daily_taskComputerCompleted;

	[HideInInspector]
	public int daily_taskComputerFired;

	[HideInInspector]
	public int daily_taskFiredCounter;

	[HideInInspector]
	public int daily_taskCompletedCounter;

	[HideInInspector]
	public int daily_playerReputation;

	[HideInInspector]
	public int daily_playerLevel;

	public void Awake()
	{
	}

	public void Translate()
	{
	}

	public void ResetDailyCounter()
	{
	}

	public void AddExp(int value)
	{
	}

	public void AddReputation(int value)
	{
	}

	public void StartAfterLoadSave()
	{
	}
}
