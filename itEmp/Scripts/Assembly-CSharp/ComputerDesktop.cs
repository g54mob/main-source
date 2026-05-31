using UnityEngine;
using UnityEngine.UI;

public class ComputerDesktop : MonoBehaviour
{
	[Header("Component")]
	public DirectoryManager thisDisc;

	public appExplorer appExplorer;

	public AppBase appBase;

	public appExplorerOpenApps appExplorerOpenApps;

	public AppProperties appProperties;

	[Header("Icons Object")]
	public Transform DesktopParent;

	public GameObject DesktopIconAdapter;

	[Header("UI")]
	public GridLayoutGroup gridLayoutGroup;

	[Header("UI Menu")]
	public RectTransform menuLayout;

	public RectTransform closeLayout;

	[Header("Desktop Dir")]
	public FileSystemObject Desktop;

	public bool DesktopFocus;

	public int iconSize;

	public void Start()
	{
	}

	[ContextMenu("Refresh Desktop")]
	public void RefreshDesktop()
	{
	}

	public void SetDesktopFocus(bool mode)
	{
	}

	private void Update()
	{
	}

	[ContextMenu("FindDesktop")]
	public void FindDesktop()
	{
	}

	public void RenderDesktop()
	{
	}

	[ContextMenu("Clear Desktop")]
	public void ClearDesktop()
	{
	}

	public void SetSizeAllIcon(int size)
	{
	}
}
