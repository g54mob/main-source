using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public GameObject audioControllerRef;

	public Canvas[] canvases;

	public GameObject settingsPane;

	public GameObject fileBrowserPanelPrefab;

	public GameObject controls;

	public RectTransform mapSizeFrame;

	public InputField mapSizeWidth;

	public InputField mapSizeHeight;

	public Text mapSizeText;

	public Toggle import2xHeightToggle;

	public Text versionText;

	public Text il2cppText;

	public GameRecorderViewer recorderViewer;

	private int lastScreenWidth;

	private int lastScreenHeight;

	private int maxArea;

	private void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void Update()
	{
	}

	private void CheckForResolutionChange()
	{
	}

	public void OnSetRes()
	{
	}

	public void OnUIScaleChanged(float scale)
	{
	}

	public void OnExitGame()
	{
	}

	public void OnSettings()
	{
	}

	public void OnLoadMission(string file)
	{
	}

	public void OnEditMission(string file)
	{
	}

	public void OnCreateMission()
	{
	}

	public void OnLoadBuiltInMission(string builtIn)
	{
	}

	public void OnMapWidthChanged()
	{
	}

	public void OnMapHeightChanged()
	{
	}

	public void BlackBoxClicked()
	{
	}

	private void FileBrowserBlackBoxOutput(string[] paths)
	{
	}

	public void LoadMissionFromFileClicked()
	{
	}

	private void FileBrowserOutput(string[] paths)
	{
	}

	private void ImportCW3Map(string filename)
	{
	}

	public void LoadCW3MissionFromFileClicked()
	{
	}

	private void OpenCW3FileBrowserOutput(string[] paths)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}

	public static void SetDefaultCulture()
	{
	}
}
