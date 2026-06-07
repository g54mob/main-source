using UnityEngine;
using UnityEngine.UI;

public class GIFExportPanel : MonoBehaviour
{
	public GameObject settingsPane;

	public GameObject statusPane;

	public Text percentText;

	public InputField frameIntervalText;

	public InputField gifFrameRateText;

	public Toggle mp4Toggle;

	public Toggle gifToggle;

	public Toggle size256Toggle;

	public Toggle size512Toggle;

	public Toggle size1024Toggle;

	public Toggle normalQualityToggle;

	public Toggle highQualityToggle;

	public Text playTimeText;

	public GameRecorderViewer grv;

	public GameObject fileBrowserPanelPrefab;

	public int size
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int frameInterval
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int gifFrameRate
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void RefreshPlayTimeText()
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public void StartMaking()
	{
	}

	public void SetPercent(float percent)
	{
	}

	public void Finished()
	{
	}

	public void ExportGIF()
	{
	}

	private void SaveFileBrowserOutput(string[] paths)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}
}
