using UnityEngine;
using UnityEngine.EventSystems;

public class TabletAppPDFReaderItemAdapter : MonoBehaviour, IPointerUpHandler, IEventSystemHandler
{
	public TabletAppPDFReaderFileExplorer tabletAppPDFReaderFileExplorer;

	public FileSystemObject item;

	public void SetFileSystemObject(TabletAppPDFReaderFileExplorer tabletAppPDFReaderFileExplorer, FileSystemObject item)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}
}
