using UnityEngine;
using UnityEngine.UI;

public class EEPROMEditor : MonoBehaviour
{
	private static EEPROMEditor inst;

	public GameObject mainObject;

	public EEPROMDataRow[] dataRows;

	private static byte[] eepromData;

	private static BaseComponent component;

	private static ICMobileTool tool;

	[Header("Scroll View Params")]
	public float rowHeight;

	public RectTransform contentRect;

	private Vector2 contentSize;

	private Vector3 contentPosition;

	public ScrollRect scrollRect;

	public int currentAdr;

	private int prevAdr;

	[Header("Save/Load")]
	public GameObject saveDialogObject;

	public InputField hexNameInput;

	public GameObject hexFileDisplay;

	private string prevFilename;

	private string[] hexList;

	public Transform hexListContentTransform;

	public GameObject hexListTemplate;

	public GameObject noSavedHex;

	public GameObject deleteDialogObject;

	private static int pendingId;

	private void Awake()
	{
	}

	public static void DisplayEditor(byte[] data, BaseComponent comp, ICMobileTool t)
	{
	}

	public void OpenSaveDialog()
	{
	}

	public void CloseSaveDialog()
	{
	}

	public void RemoveIllegalNameCharacters()
	{
	}

	public void Save()
	{
	}

	public void LoadHexFileList()
	{
	}

	private void PopulateHexList()
	{
	}

	public static void DeleteClicked(int id)
	{
	}

	public static void LoadHexData(int id)
	{
	}

	public void CancelDelete()
	{
	}

	public void ConfirmDelete()
	{
	}

	public void CloseHexFileList()
	{
	}

	public static void CentreEdit(int adr, EEPROMDataRow row)
	{
	}

	public void Shift(int adr)
	{
	}

	public void LateUpdate()
	{
	}

	public static void CloseEditor()
	{
	}
}
