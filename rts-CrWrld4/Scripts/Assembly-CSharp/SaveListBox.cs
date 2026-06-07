using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveListBox : MonoBehaviour
{
	public GameObject saveListRowPrefab;

	public GameObject container;

	public ScrollRect scrollView;

	public TMP_InputField saveGameInputField;

	public GameObject loadButton;

	public GameObject saveButton;

	public TextMeshProUGUI errorText;

	private GameSpace.CATEGORY category;

	private string mapGUID;

	private int colonyID;

	private string launchFile;

	private bool canSave;

	public void Init(GameSpace.CATEGORY category, string mapGUID, bool canSave, int colonyID = 0, string launchFile = null)
	{
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}

	private static string GetSaveUID(GameSpace.CATEGORY category, int colonyID, string mapGUID)
	{
		return null;
	}

	public void RefreshSaveLoadList()
	{
	}

	public void OnRowClicked(string name)
	{
	}

	private string GetFileName()
	{
		return null;
	}

	public static string GetFileName(string f, GameSpace.CATEGORY category, int colonyID, string mapGUID)
	{
		return null;
	}

	public void OnLoad()
	{
	}

	public static void OnLoadFile(string fileName, GameSpace.CATEGORY category, int colonyID)
	{
	}

	public void OnSave()
	{
	}

	public static void OnSaveFile(string fileName)
	{
	}
}
