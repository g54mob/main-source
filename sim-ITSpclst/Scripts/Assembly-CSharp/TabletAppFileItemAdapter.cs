using UnityEngine;
using UnityEngine.EventSystems;

public class TabletAppFileItemAdapter : MonoBehaviour, IPointerUpHandler, IEventSystemHandler
{
	public TabletAppFileCloud tabletAppFileCloud;

	public TabletAppFileStorage tabletAppFileStorage;

	public FileSystemObject item;

	public string storageMode;

	public void SetFileSystemObject(TabletAppFileCloud tabletAppFileCloud, TabletAppFileStorage tabletAppFileStorage, FileSystemObject item, string storageMode)
	{
	}

	public void OpenMenu(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}
}
