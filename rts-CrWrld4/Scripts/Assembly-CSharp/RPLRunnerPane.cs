using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RPLRunnerPane : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject rowPrefab;

	public Transform rowContainer;

	public InputField previewInputField;

	public InputField outputInputField;

	public InputField fileInputField;

	public ConfirmDialog confirmDialog;

	private bool loaded;

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnImport()
	{
	}

	public void OnAdd()
	{
	}

	private void LoadFileBrowserOutput(string path)
	{
	}

	private void SaveFileBrowserOutput(string path)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}

	public void OnAddRow(string rowFile, bool createFile, bool setAsFirst = true)
	{
	}

	public int GetRowIndex(string rowFile)
	{
		return 0;
	}

	public ConsoleScriptRow GetRow(string rowFile)
	{
		return null;
	}

	public ConsoleScriptRow GetSelectedRow()
	{
		return null;
	}

	public void UnselectAllRows()
	{
	}

	public void OnClear()
	{
	}

	public void GameUpdate()
	{
	}

	private void LoadScriptsFromTxt()
	{
	}

	public void SaveScriptsToTxt()
	{
	}
}
