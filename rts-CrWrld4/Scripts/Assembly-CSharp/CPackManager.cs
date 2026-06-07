using System;
using UnityEngine;
using UnityEngine.UI;

public class CPackManager : MonoBehaviour
{
	public ConfirmDialog confirmDialog;

	public MessageDialog messageDialog;

	public Dropdown dropdown;

	public Button addButton;

	public Button delButton;

	public Button moveCPackUpButton;

	public Button moveCPackDownButton;

	public Button importButton;

	public Button exportButton;

	public Button branchButton;

	public Button wikiButton;

	public GameObject createPane;

	public InputField createPaneName;

	public GameObject branchPanel;

	public GameObject cPackPanes;

	public CAssetsManager cAssetsManager;

	public CModsManager cModsManager;

	public CPackSettings cPackSettings;

	public GameObject cpackPreviewGO;

	public GlobalScriptManager globalScriptManager;

	[NonSerialized]
	public CPack activeCPack;

	private string importPath;

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public void OnUpdateUnitInstances()
	{
	}

	public void OnExport()
	{
	}

	public void OnImport()
	{
	}

	public void AddClicked()
	{
	}

	public void DeleteClicked()
	{
	}

	private void ConfirmImport(bool oldDir)
	{
	}

	public void OnMoveCPackUp()
	{
	}

	public void OnMoveCPackDown()
	{
	}

	public void CreateCPack()
	{
	}

	public void DeleteCPack()
	{
	}

	public void RefreshDropdown()
	{
	}

	public void OnCPackSelected(int val)
	{
	}

	public void ShowSelectedCPack()
	{
	}

	public void OnBranch()
	{
	}

	public void ImportCPackFromFile()
	{
	}

	private void ImportCPack(string path, bool ignoreDuplicate)
	{
	}

	public void ExportCPackToFile()
	{
	}

	public void BranchCPackToFile()
	{
	}

	public void OnWikiHelpClicked()
	{
	}

	private void FileBrowserWindowClosed()
	{
	}
}
