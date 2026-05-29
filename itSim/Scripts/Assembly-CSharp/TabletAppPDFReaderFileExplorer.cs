using UnityEngine;

public class TabletAppPDFReaderFileExplorer : MonoBehaviour
{
	[Header("Components")]
	public appExplorer appExplorer;

	public TabletAppPDFReader tabletAppPDFReader;

	[Header("Explorer Content")]
	public Transform ParentExplorerContentStorage;

	public GameObject ItemExplorerContent;

	public void RenderStorage(FileSystemObject directory)
	{
	}

	private void ClearExplorerContent()
	{
	}

	public void OpenPDF(FileSystemObject item)
	{
	}
}
