using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class appExplorerSelectorItemAdapter : MonoBehaviour, IPointerUpHandler, IEventSystemHandler
{
	private appExplorerSelector appExplorerSelector;

	public FileSystemObject item;

	public new TMP_Text name;

	public void SetFileSystemObject(appExplorerSelector appExplorerSelector, FileSystemObject item)
	{
	}

	public void Open()
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}
}
