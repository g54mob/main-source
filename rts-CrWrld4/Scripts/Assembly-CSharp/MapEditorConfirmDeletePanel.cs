using System.IO;
using TMPro;
using UnityEngine;

public class MapEditorConfirmDeletePanel : MonoBehaviour
{
	private bool finalized;

	private DirectoryInfo directory;

	public EditorMenuManager editorManager;

	public FinalizedMapsManager finalizedManager;

	public TextMeshProUGUI fileNameText;

	public void Show(DirectoryInfo directory, bool finalized)
	{
	}

	public void Hide()
	{
	}

	public void OnYes()
	{
	}

	public void OnNo()
	{
	}
}
