using UnityEngine;
using UnityEngine.UI;

public class BootScreen : MonoBehaviour
{
	private const float DELAY_INITIAL_MSG = 2f;

	private const float DELAY_LOGO_FRAME = 0.05f;

	private const float DELAY_START_CHAR = 0.01f;

	private const float DELAY_CLOSE = 0.5f;

	private static bool hasShown;

	public MenuPanelUI menuPanel;

	public Image logo;

	public Text bootSequenceLabel;

	public Text asciiLabel;

	public Text bodyLabel;

	public Canvas progressCanvas;

	public BiosScreen biosScreen;

	private Sprite[] logoSpriteArray;

	private string logoAscii1 = " __  __ _      __ _ _                 _   _   _      ";

	private string logoAscii2 = "|  \\/  (_)    / _(_) |           /\\  | | | | (_)     ";

	private string logoAscii3 = "| \\  / |_ ___| |_ _| |_ ___     /  \\ | |_| |_ _  ___ ";

	private string logoAscii4 = "| |\\/| | / __|  _| | __/ __|   / /\\ \\| __| __| |/ __|";

	private string logoAscii5 = "| |  | | \\__ \\ | | | |_\\__ \\  / ____ \\ |_| |_| | (__ ";

	private string logoAscii6 = "|_|  |_|_|___/_| |_|\\__|___/ /_/    \\_\\__|\\__|_|\\___|";

	private char[] startChars = new char[5] { 'S', 'T', 'A', 'R', 'T' };

	private int currentState;

	private int idxLogoFrame;

	private int idxStartText;

	private float timerTilNextChange;

	private float timerTilSecondTextSound;

	private bool isCursorEnabled;

	private bool isShowingCursor;

	private bool isDelayBeforeSecondTextSound;

	private float timerCursorBlink;

	private Rect cursorRect = new Rect(0f, 0f, 20f, 20f);

	private TypedMessageFormatter msgFormater;

	private string logText = string.Empty;

	private Vector2 scrollPosition = default(Vector2);

	private void Awake()
	{
		if (!hasShown)
		{
			Initialize();
		}
	}

	public void Initialize()
	{
		if (GameSaveFile.IsFileEmpty())
		{
			GameSaveFile.Save("GAME_VER", 1.041f);
		}
		Application.runInBackground = GameSaveFile.Get("O_RIB", false);
		ResourceManager.OneTimeBackgroundLoad();
		logoSpriteArray = Resources.LoadAll<Sprite>("UI/misfitsLogoScanSheet");
		currentState = 0;
		idxLogoFrame = 0;
		idxStartText = 0;
		EnableCursor();
		timerTilNextChange = 2f;
		GameAudio.Initialize();
		GameAudio.Play2DSFX(GameAudio.SoundEnum.BIOSFan);
		bootSequenceLabel.text = "Boot sequence initiated...";
		asciiLabel.text = logoAscii1 + " \n\r" + logoAscii2 + " \n\r" + logoAscii3 + " \n\r" + logoAscii4 + " \n\r" + logoAscii5 + " \n\r" + logoAscii6;
		asciiLabel.gameObject.SetActive(false);
		bodyLabel.text = string.Empty;
		logText = string.Empty;
		msgFormater = new TypedMessageFormatter();
		string text = "Loading BIOS: Salvage Vessel [Cargo Class] Version 5.1\r\n\r\nCheckSum: OK\r\nPC1-222 Single Channel Uplink\r\nPC1-243 Single Channel Uplink\r\nInitializing Quant-End Rounting[.]\r\n     -> Done.\r\nProgram received signal SIGSEGV:\r\nSegmentation fault - invalid memory reference.\r\n\r\nBacktrace for this error:\r\n0 0x7FC5A0B1C117 1 0x7FC5ADB1C6F4 2 0x7FC5AD46C0AF 3\r\n0x44E704 in ffthdu at fitscore.c:6893 4 0x405101 in MAIN__\r\nat Codigo.f90:? Segmentation fault [core dumped]";
		LogManager.ReplaceVariables(ref text);
		msgFormater.SetRawText(text);
		logo.sprite = null;
		logo.color = Color.black;
		if (progressCanvas != null)
		{
			progressCanvas.gameObject.SetActive(false);
		}
		int num = GameSaveFile.Get("Q_VSYNC", QualitySettings.vSyncCount);
		QualitySettings.vSyncCount = 0;
		QualitySettings.vSyncCount = 1;
		if (num != QualitySettings.vSyncCount)
		{
			QualitySettings.vSyncCount = num;
		}
	}

	private void Start()
	{
		if (menuPanel != null)
		{
			menuPanel.gameObject.SetActive(false);
		}
		if (biosScreen != null)
		{
			biosScreen.gameObject.SetActive(false);
		}
		if (HelpManual.Instance != null)
		{
			new HelpManual();
		}
		if (hasShown)
		{
			PostScreen();
		}
	}

	private void OnDestroy()
	{
		if (logo != null)
		{
			logo.sprite = null;
			logo = null;
		}
		bootSequenceLabel = null;
		asciiLabel = null;
		bodyLabel = null;
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			PostScreen();
		}
		else if (Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.F2) || Input.GetKeyDown(KeyCode.F12) || Input.GetKeyDown(KeyCode.Delete))
		{
			LaunchBios();
		}
		timerTilNextChange -= Time.deltaTime;
		if (timerTilNextChange <= 0f)
		{
			switch (currentState)
			{
			case 0:
				currentState++;
				timerTilNextChange = 0.05f;
				GameAudio.Play2DSFX(GameAudio.SoundEnum.BIOSBeep);
				NextLogoFrame();
				break;
			case 1:
				if (NextLogoFrame())
				{
					timerTilNextChange = 0.05f;
					break;
				}
				currentState++;
				asciiLabel.gameObject.SetActive(true);
				idxStartText = 0;
				DisableCursor();
				timerTilNextChange = 0.099999994f;
				GameAudio.Play2DSFX(GameAudio.SoundEnum.BIOSText1);
				break;
			case 2:
				if (idxStartText < startChars.Length)
				{
					bootSequenceLabel.text += startChars[idxStartText];
					timerTilNextChange = 0.01f;
					idxStartText++;
				}
				else
				{
					currentState++;
					isDelayBeforeSecondTextSound = true;
					timerTilSecondTextSound = 1.3f;
				}
				break;
			case 3:
				if (msgFormater.Update(false, true, ref logText))
				{
					currentState++;
					timerTilNextChange = 0.5f;
					GameAudio.Play2DSFX(GameAudio.SoundEnum.BIOSBeep);
				}
				if (isDelayBeforeSecondTextSound)
				{
					timerTilSecondTextSound -= Time.deltaTime;
					if (timerTilSecondTextSound <= 0f)
					{
						isDelayBeforeSecondTextSound = false;
						GameAudio.Play2DSFX(GameAudio.SoundEnum.BIOSText2);
					}
				}
				bodyLabel.text = logText;
				break;
			case 4:
				PostScreen();
				break;
			}
		}
		if (!isCursorEnabled)
		{
			return;
		}
		timerCursorBlink -= Time.deltaTime;
		if (timerCursorBlink <= 0f)
		{
			timerCursorBlink = 0.2f;
			isShowingCursor = !isShowingCursor;
			if (isShowingCursor)
			{
				bootSequenceLabel.text = "Boot sequence initiated..._";
			}
			else
			{
				bootSequenceLabel.text = "Boot sequence initiated...";
			}
		}
	}

	private void PostScreen()
	{
		if (logoSpriteArray != null)
		{
			int num = logoSpriteArray.Length;
			for (int i = 0; i < num; i++)
			{
				Resources.UnloadAsset(logoSpriteArray[i]);
				logoSpriteArray[i] = null;
			}
		}
		if (DeveloperNotificationManager.Instance.HasANewNotification())
		{
			DeveloperNotificationManager.Instance.BeginShowNotification();
			MenuPanelUI.Instance.Disable();
		}
		else
		{
			new MainMenu();
		}
		if (progressCanvas != null)
		{
			progressCanvas.gameObject.SetActive(true);
		}
		hasShown = true;
		base.gameObject.SetActive(false);
		Object.Destroy(this);
	}

	private void LaunchBios()
	{
		base.gameObject.SetActive(false);
		biosScreen.Initialize();
		biosScreen.gameObject.SetActive(true);
	}

	private bool NextLogoFrame()
	{
		if (idxLogoFrame < logoSpriteArray.Length - 1)
		{
			idxLogoFrame++;
			logo.sprite = logoSpriteArray[idxLogoFrame];
			logo.color = Color.white;
			return true;
		}
		return false;
	}

	private void EnableCursor()
	{
		isCursorEnabled = true;
		isShowingCursor = true;
		timerCursorBlink = 0.2f;
		bootSequenceLabel.text = "Boot sequence initiated..._";
	}

	private void DisableCursor()
	{
		isCursorEnabled = false;
		bootSequenceLabel.text = "Boot sequence initiated...";
	}
}
