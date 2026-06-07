using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UploadMapManager : MonoBehaviour
{
	public EditorMenuManager editorMenuManager;

	public TextMeshProUGUI mapNameText;

	public TMP_InputField authorText;

	public TMP_InputField emailText;

	public TMP_InputField tagsText;

	public Button okButton;

	public Button cancelButton;

	public GameObject infoPanel;

	public GameObject uploadingPanel;

	public TextMeshProUGUI infoPanelText;

	public TMP_Dropdown tagsDropdown;

	public GameObject warningPane;

	private string mapFile;

	private bool uploadingMap;

	private string mapUploading;

	private bool uploadMapComplete;

	private string uploadMapResult;

	private bool uploadMapSuccess;

	private EditorListEntry editorListEntry;

	private string finalizedeBaseDir;

	private void Update()
	{
	}

	public void Show(string mapFile, EditorListEntry e = null)
	{
	}

	public void Hide()
	{
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private bool IsFileNewer(string fileToCheck, string fileToCompareTo)
	{
		return false;
	}

	private void GetTags()
	{
	}

	public void OnTagDropdown(int ddval)
	{
	}

	private void ResetState()
	{
	}

	public void OnOk()
	{
	}

	public static string CleanTags(string rawTags, out int count, out int maxTagLength)
	{
		count = default(int);
		maxTagLength = default(int);
		return null;
	}

	public void OnInfoPanelClosed()
	{
	}

	private byte[] GetThumbnailData(string mapFile)
	{
		return null;
	}

	private void UploadMap(string mapFile, string mapName, string mapAuthor, string mapEmail, string tags)
	{
	}

	private void UploadMapCallback(object sender, UploadDataCompletedEventArgs e)
	{
	}
}
