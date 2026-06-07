using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EditorMenuManager : MonoBehaviour
{
	public delegate void Function();

	public GameObject editorListEntryPrefab;

	public GameObject filePanel;

	public ScrollRect scrollRect;

	public MapEditorConfirmDeletePanel confirmDeletePanel;

	public UploadMapManager uploadMapManager;

	public void OnEnable()
	{
	}

	public void RefreshEditorList()
	{
	}

	public void InvokeNextFrame(Function function)
	{
	}

	private IEnumerator _InvokeNextFrame(Function function)
	{
		return null;
	}

	public void ScrollToTop()
	{
	}

	public void EditorRowClicked(string file)
	{
	}

	public void PlayEntryClicked(EditorListEntry e)
	{
	}

	public void UploadEntryClicked(EditorListEntry e)
	{
	}

	public void EditEntryClicked(string f)
	{
	}

	public void DeleteEntryClicked(EditorListEntry e)
	{
	}

	public void TimeSortClicked()
	{
	}

	public void NameSortClicked()
	{
	}
}
