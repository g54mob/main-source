using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticView : MonoBehaviour
{
	[Header("General Statistic")]
	public TextMeshProUGUI playerTitle;

	public TextMeshProUGUI playerLevel;

	public TextMeshProUGUI currentExp;

	public TextMeshProUGUI expToNewLevel;

	public TextMeshProUGUI difficult;

	public TextMeshProUGUI taskCompleted;

	public TextMeshProUGUI taskFired;

	public TextMeshProUGUI Reputation;

	public int ResultTitlePoints;

	public Sprite[] avatarList;

	public Image avatarImage;

	[Header("Network")]
	[Header("Level 1")]
	public TextMeshProUGUI network_Title;

	public TextMeshProUGUI network_TaskCompleted;

	public TextMeshProUGUI network_TaskFired;

	public TextMeshProUGUI network_Status;

	public string[] network_StatusText;

	public int[] network_ToNextTitle;

	public Image network_Bar;

	public GameObject[] network_unlockOnNot;

	[Header("Computer")]
	public TextMeshProUGUI computers_Title;

	public TextMeshProUGUI computer_TaskCompleted;

	public TextMeshProUGUI computer_TaskFired;

	public TextMeshProUGUI computer_Status;

	public string[] computer_StatusText;

	public int[] computer_ToNextTitle;

	public Image computer_Bar;

	public GameObject[] computer_unlockOnNot;

	[Header("Printer")]
	public TextMeshProUGUI printer_Title;

	public TextMeshProUGUI printer_TaskCompleted;

	public TextMeshProUGUI printer_TaskFired;

	public TextMeshProUGUI printer_Status;

	public string[] printer_StatusText;

	public int[] printer_ToNextTitle;

	public Image printer_Bar;

	public GameObject[] printer_unlockOnNot;

	[Header("RCP")]
	public TextMeshProUGUI rcp_Title;

	public TextMeshProUGUI rcp_TaskCompleted;

	public TextMeshProUGUI rcp_TaskFired;

	public TextMeshProUGUI rcp_Status;

	public string[] rcp_StatusText;

	public int[] rcp_ToNextTitle;

	public Image rcp_Bar;

	public GameObject[] rcp_unlockOnNot;

	[Header("PDA")]
	public TextMeshProUGUI pda_Title;

	public TextMeshProUGUI pda_TaskCompleted;

	public TextMeshProUGUI pda_TaskFired;

	public TextMeshProUGUI pda_Status;

	public string[] pda_StatusText;

	public int[] pda_ToNextTitle;

	public Image pda_Bar;

	public GameObject[] pda_unlockOnNot;

	public void Open()
	{
	}

	public void MainOpen()
	{
	}

	public void CountPoint()
	{
	}

	public void NetworkOpen()
	{
	}

	public void ComputerOpen()
	{
	}

	public void PrinterOpen()
	{
	}

	public void RCPOpen()
	{
	}

	public void PDAOpen()
	{
	}
}
