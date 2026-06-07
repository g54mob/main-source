using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FinalizedMapsManager : MonoBehaviour
{
	public delegate void Function();

	public GameObject finalizedListEntryPrefab;

	public GameObject filePanel;

	public ScrollRect scrollRect;

	public MapEditorConfirmDeletePanel confirmDeletePanel;

	public UploadMapManager uploadMapManager;

	public void OnEnable()
	{
	}

	public void RefreshList()
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

	public void PlayEntryClicked(FinalizedListEntry e)
	{
	}

	public void DeleteEntryClicked(FinalizedListEntry e)
	{
	}

	public void UploadEntryClicked(FinalizedListEntry e)
	{
	}

	public void TimeSortClicked()
	{
	}

	public void NameSortClicked()
	{
	}
}
