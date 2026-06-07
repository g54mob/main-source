using System.IO;
using UnityEngine;

public class MissionPanelLoadBox : MonoBehaviour
{
	public GameObject missionPanelLoadBoxRowPrefab;

	public GameObject container;

	private GameSpace.CATEGORY category;

	private string mapGUID;

	private int colonyID;

	private string specifier;

	private string launchFile;

	public void Init(GameSpace.CATEGORY category, string mapGUID, int colonyID, string specifier, string launchFile)
	{
	}

	private string GetSaveUID()
	{
		return null;
	}

	public void OnRowLoadClicked(FileInfo file)
	{
	}

	private string GetFileName(FileInfo file)
	{
		return null;
	}

	public void RefreshSaveLoadList()
	{
	}
}
