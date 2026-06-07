using System.Collections.Generic;
using UnityEngine;

public class AppBrowserDownloader : MonoBehaviour
{
	[SerializeField]
	public static Vector2Int speedNetRange;

	[SerializeField]
	private Vector2Int staticValueInspector_speedNetRange;

	[Header("Files Base")]
	public ISOFileBase ISOFileBase;

	public PDFFileBase PDFFileBase;

	[Header("Components")]
	public DirectoryManager directoryManager;

	public ComputerNetwork computerNetwork;

	[Header("UI")]
	public RectTransform UIListDownload;

	[Header("Adapter")]
	public RectTransform downloadAdapterParent;

	public RectTransform downloadAdapterPrefab;

	[Header("File List")]
	public List<AppBrowserDownloadAdapter> files;

	public List<string> lastDownloadFile;

	public FileSystemObject DownloadDir;

	private void OnValidate()
	{
	}

	public void DownloadNewFile(FileSystemObject _file, string file)
	{
	}

	public void Start()
	{
	}

	private void Update()
	{
	}

	public void TerminatedProcesses()
	{
	}

	public void ButtonViewDownloadList()
	{
	}

	public void DownloadFromFileBaseISO(int idFile)
	{
	}

	public void DownloadFromFileBasePDF(int idFile)
	{
	}
}
