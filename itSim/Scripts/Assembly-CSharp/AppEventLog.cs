using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppEventLog : PTSMonoBehaviour
{
	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	public WarningDatabase warningDatabase;

	public NotifiSystemManager notifiSystemManager;

	[Header("Component")]
	public AppBase AppBase;

	[HideInInspector]
	public bool isOpen;

	public GameObject warningListView;

	public GameObject XMLView;

	public GameObject preferencesView;

	public GameObject preferecnesButtonView;

	public GameObject filterCurrentLogView;

	public GameObject[] FoldersView;

	public TextMeshProUGUI categoryText;

	public TextMeshProUGUI numberOfEventsText;

	public TMP_InputField eventIdsInput;

	[Header("App Object")]
	public Transform warningPrefabs;

	public Transform warningList;

	[SerializeField]
	private Sprite[] spriteWarning;

	public TextMeshProUGUI xmlns;

	public TextMeshProUGUI systemOne;

	public TextMeshProUGUI provicdername;

	public TextMeshProUGUI eventid;

	public TextMeshProUGUI level;

	public TextMeshProUGUI task;

	public TextMeshProUGUI keywords;

	public TextMeshProUGUI timecreated;

	public TextMeshProUGUI channel;

	public TextMeshProUGUI systemTwo;

	public TextMeshProUGUI eventDataOne;

	public TextMeshProUGUI dataName;

	public TextMeshProUGUI eventDataTwo;

	public TextMeshProUGUI xmlnsTwo;

	private string currentType;

	public bool wasOpened;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void ShowWarningList(string type)
	{
	}

	public int CountWarningByTag(string type)
	{
		return 0;
	}

	public void RenderWarning(string type, string inputIds = "")
	{
	}

	public void RenderListWarning(List<Warning> warnings, string type, string inputIds = "")
	{
	}

	public void ClearWarnings()
	{
	}

	public void ShowPropertiesEvent(Warning warning)
	{
	}

	public void ShowPreferencesObject()
	{
	}

	public void ShowFilterCurrentLog()
	{
	}

	public void CloseFilterCurrentLog()
	{
	}

	public void FilterCurrentLog()
	{
	}

	public void DeletedActuallDB()
	{
	}

	public void ShowFolders(int number)
	{
	}
}
