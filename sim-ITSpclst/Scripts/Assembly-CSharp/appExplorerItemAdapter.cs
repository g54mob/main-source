using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class appExplorerItemAdapter : MonoBehaviour, IPointerUpHandler, IEventSystemHandler
{
	private appExplorer appExplorer;

	public FileSystemObject item;

	public AppProperties appProperties;

	private appExplorerMenu appExplorerMenu;

	public new TMP_Text name;

	public TMP_InputField renameInput;

	public Image icon;

	public void SetFileSystemObject(appExplorer appExplorer, FileSystemObject item, appExplorerMenu appExplorerMenu)
	{
	}

	public void Open()
	{
	}

	public void Delete()
	{
	}

	public void Paste(FileSystemObject copyItem, bool isCut)
	{
	}

	public bool canCopyCut()
	{
		return false;
	}

	public void Rename()
	{
	}

	public void RenameEnd()
	{
	}

	public void OpenPropertie()
	{
	}

	public void OpenMenu(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}
}
