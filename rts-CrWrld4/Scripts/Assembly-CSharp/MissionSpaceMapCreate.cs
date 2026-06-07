using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;

public class MissionSpaceMapCreate : MonoBehaviour
{
	public GameObject createButton;

	public TMP_InputField mapName;

	public TMP_InputField mapSizeWidth;

	public TMP_InputField mapSizeHeight;

	public TextMeshProUGUI mapNameError;

	public SwitchAnim height2XImport;

	public GameObject mapSizeContainer;

	public GameObject mapImportContainer;

	private int maxArea;

	public void Show()
	{
	}

	public void Hide()
	{
	}

	public void OnSmall()
	{
	}

	public void OnMedium()
	{
	}

	public void OnLarge()
	{
	}

	public void OnHuge()
	{
	}

	public void OnCreate()
	{
	}

	public void OnMapName(string sval)
	{
	}

	private string CheckName(string nameText)
	{
		return null;
	}

	public void OnMapWidth(string sval)
	{
	}

	public void OnMapHeight(string sval)
	{
	}

	private void CheckMapSize(bool widthChanged)
	{
	}

	public void OnImportMap()
	{
	}

	private void OpenCW3FileBrowserOutput(string[] paths)
	{
	}

	private void ImportCW3Map(string filename)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}
}
