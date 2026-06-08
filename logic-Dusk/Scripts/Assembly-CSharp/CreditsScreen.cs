using UnityEngine;
using UnityEngine.UI;

public class CreditsScreen : MonoBehaviour
{
	private const float DELAY_INITIAL_MSG = 2f;

	private const float DELAY_LOGO_FRAME = 0.05f;

	private const float DELAY_START_CHAR = 0.01f;

	private const float DELAY_CLOSE = 0.5f;

	private const string page1Text = "<color=#f0ff00>Tim Keenan</color>[.]Creator Guy (Random idea generator, pointer of fingers)\n\n<color=#f0ff00>Jeremy Phillips</color>[.]Lead Programmer (Breaks game, fixes game)\n\n<color=#f0ff00>Rick Sonderfan</color>[.]Programmer (Father of drones)\n\n<color=#f0ff00>Brendan Mauro</color>[.]Lead Artist (Draws pictures, runs shipyard)\n\n<color=#f0ff00>Jillian Ogle</color>[.]Artist (Views the world like a drone)\n\n<color=#f0ff00>Cale Bradbury</color>[.]Effects (Made it (intentionally) glitchy)\n\n<color=#f0ff00>Ian Hicks</color>[.]Audio (Bleeps and boops)\r\n\r\n<color=#f0ff00>Keith Moore</color>[.]Audio (Blips and blops)\r\n\r\n<color=#f0ff00>Robin Arnott</color>[.]Audio (Bumps in the night)\n\n<color=#f0ff00>Benjamin Hill</color>[.]Story (Speaker for the dead)\n\n\n\n\n\n\n<color=#3f9eef>Use <Enter> or Arrow keys to move between pages</color> \n\n<color=#3f9eef>Press <ESC> to close</color> ";

	private const string page2Text = "IndieFund Investors that made Duskers possible...\n\n\n<color=#f0ff00>Jonathan Blow\t\tColin Northway</color>\n\n<color=#f0ff00>John Bizzarro\t\tSarah Northway</color>\n\n<color=#f0ff00>Ron Carmel\t\t   Tommy Refenes</color>\n\n<color=#f0ff00>Kyle Gabler\t\t  Jeff Rosen</color>\n\n<color=#f0ff00>Zach Gage\t\t    Kellee Santiago</color>\n\n<color=#f0ff00>John Graham\t\t  Nathan Vella</color>\n\n<color=#f0ff00>Cliff Harris\t\t Matthew Wegner</color>\n\n<color=#f0ff00>Aaron Isaksen</color>\n\n\n\n\n\n\n<color=#3f9eef>Use <Enter> or Arrow keys to move between pages</color> \n\n<color=#3f9eef>Press <ESC> to close</color> ";

	private const string page3Text = "Additional Help...\n\n\n<color=#f0ff00>Holly Keenan</color>[.]Pixels and Support\n\n<color=#f0ff00>Travis Koller</color>[.]Concept Art\n\n<color=#f0ff00>George Cochrane</color>[.]Mac & Linux help\n\n<color=#f0ff00>Ryan Paxton</color>[.]Concept Animation\n\n<color=#f0ff00>Brandon Surowiec</color>[.]Help and Testing\n\n<color=#f0ff00>Genevieve Duchesneau</color>[.]Help and Testing\n\n<color=#f0ff00>David York</color>[.]Testing\n\n<color=#f0ff00>Javier Ulloa</color>[.]Testing\n\n\n\n\n\n\n<color=#3f9eef>Use <Enter> or Arrow keys to move between pages</color> \n\n<color=#3f9eef>Press <ESC> to close</color> ";

	private const string page4Text = "Special Thanks...\n\n\n<color=#f0ff00>Double Fine</color>\n\n<color=#f0ff00>Intel</color>\n\n<color=#f0ff00>Duskers Council</color>\n\n<color=#f0ff00>Alex Austin</color>\n\n<color=#f0ff00>Ian Stocker</color>\n\n<color=#f0ff00>Family & Friends</color>\n\n<color=#f0ff00>Community & Fans</color>\n\n\n\n\n\n\n<color=#3f9eef>Use <Enter> or Arrow keys to move between pages</color> \n\n<color=#3f9eef>Press <ESC> to close</color> ";

	public static CreditsScreen Instance;

	public Image logo;

	public Text bootSequenceLabel;

	public Text asciiLabel;

	public Text bodyLabel;

	private Sprite[] logoSpriteArray;

	private string logoAscii1 = " __  __ _      __ _ _                 _   _   _      ";

	private string logoAscii2 = "|  \\/  (_)    / _(_) |           /\\  | | | | (_)     ";

	private string logoAscii3 = "| \\  / |_ ___| |_ _| |_ ___     /  \\ | |_| |_ _  ___ ";

	private string logoAscii4 = "| |\\/| | / __|  _| | __/ __|   / /\\ \\| __| __| |/ __|";

	private string logoAscii5 = "| |  | | \\__ \\ | | | |_\\__ \\  / ____ \\ |_| |_| | (__ ";

	private string logoAscii6 = "|_|  |_|_|___/_| |_|\\__|___/ /_/    \\_\\__|\\__|_|\\___|";

	private char[] startChars = new char[5] { 'F', 'O', 'U', 'N', 'D' };

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

	private int currentPageIdx = 1;

	private void Awake()
	{
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (logo != null)
		{
			logo.sprite = null;
		}
		logo = null;
		bootSequenceLabel = null;
		asciiLabel = null;
		bodyLabel = null;
	}

	public void Show()
	{
		currentPageIdx = 0;
		Show(0, 0);
	}

	private void Show(int page, int startingState)
	{
		base.gameObject.SetActive(true);
		currentState = startingState;
		idxLogoFrame = 0;
		idxStartText = 0;
		timerTilNextChange = 0f;
		timerTilSecondTextSound = 0f;
		isCursorEnabled = false;
		isShowingCursor = false;
		isDelayBeforeSecondTextSound = false;
		timerCursorBlink = 0f;
		logText = string.Empty;
		logoSpriteArray = Resources.LoadAll<Sprite>("UI/misfitsLogoScanSheet");
		EnableCursor();
		if (startingState == 0)
		{
			timerTilNextChange = 2f;
		}
		else
		{
			timerTilNextChange = 0f;
		}
		bootSequenceLabel.text = "Accessing records...";
		asciiLabel.text = logoAscii1 + " \n\r" + logoAscii2 + " \n\r" + logoAscii3 + " \n\r" + logoAscii4 + " \n\r" + logoAscii5 + " \n\r" + logoAscii6;
		asciiLabel.gameObject.SetActive(false);
		bodyLabel.text = string.Empty;
		msgFormater = new TypedMessageFormatter();
		string text = string.Empty;
		switch (page)
		{
		case 0:
			text = "<color=#f0ff00>Tim Keenan</color>[.]Creator Guy (Random idea generator, pointer of fingers)\n\n<color=#f0ff00>Jeremy Phillips</color>[.]Lead Programmer (Breaks game, fixes game)\n\n<color=#f0ff00>Rick Sonderfan</color>[.]Programmer (Father of drones)\n\n<color=#f0ff00>Brendan Mauro</color>[.]Lead Artist (Draws pictures, runs shipyard)\n\n<color=#f0ff00>Jillian Ogle</color>[.]Artist (Views the world like a drone)\n\n<color=#f0ff00>Cale Bradbury</color>[.]Effects (Made it (intentionally) glitchy)\n\n<color=#f0ff00>Ian Hicks</color>[.]Audio (Bleeps and boops)\r\n\r\n<color=#f0ff00>Keith Moore</color>[.]Audio (Blips and blops)\r\n\r\n<color=#f0ff00>Robin Arnott</color>[.]Audio (Bumps in the night)\n\n<color=#f0ff00>Benjamin Hill</color>[.]Story (Speaker for the dead)\n\n\n\n\n\n\n<color=#3f9eef>Use <Enter> or Arrow keys to move between pages</color> \n\n<color=#3f9eef>Press <ESC> to close</color> ";
			break;
		case 1:
			text = "IndieFund Investors that made Duskers possible...\n\n\n<color=#f0ff00>Jonathan Blow\t\tColin Northway</color>\n\n<color=#f0ff00>John Bizzarro\t\tSarah Northway</color>\n\n<color=#f0ff00>Ron Carmel\t\t   Tommy Refenes</color>\n\n<color=#f0ff00>Kyle Gabler\t\t  Jeff Rosen</color>\n\n<color=#f0ff00>Zach Gage\t\t    Kellee Santiago</color>\n\n<color=#f0ff00>John Graham\t\t  Nathan Vella</color>\n\n<color=#f0ff00>Cliff Harris\t\t Matthew Wegner</color>\n\n<color=#f0ff00>Aaron Isaksen</color>\n\n\n\n\n\n\n<color=#3f9eef>Use <Enter> or Arrow keys to move between pages</color> \n\n<color=#3f9eef>Press <ESC> to close</color> ";
			break;
		case 2:
			text = "Additional Help...\n\n\n<color=#f0ff00>Holly Keenan</color>[.]Pixels and Support\n\n<color=#f0ff00>Travis Koller</color>[.]Concept Art\n\n<color=#f0ff00>George Cochrane</color>[.]Mac & Linux help\n\n<color=#f0ff00>Ryan Paxton</color>[.]Concept Animation\n\n<color=#f0ff00>Brandon Surowiec</color>[.]Help and Testing\n\n<color=#f0ff00>Genevieve Duchesneau</color>[.]Help and Testing\n\n<color=#f0ff00>David York</color>[.]Testing\n\n<color=#f0ff00>Javier Ulloa</color>[.]Testing\n\n\n\n\n\n\n<color=#3f9eef>Use <Enter> or Arrow keys to move between pages</color> \n\n<color=#3f9eef>Press <ESC> to close</color> ";
			break;
		case 3:
			text = "Special Thanks...\n\n\n<color=#f0ff00>Double Fine</color>\n\n<color=#f0ff00>Intel</color>\n\n<color=#f0ff00>Duskers Council</color>\n\n<color=#f0ff00>Alex Austin</color>\n\n<color=#f0ff00>Ian Stocker</color>\n\n<color=#f0ff00>Family & Friends</color>\n\n<color=#f0ff00>Community & Fans</color>\n\n\n\n\n\n\n<color=#3f9eef>Use <Enter> or Arrow keys to move between pages</color> \n\n<color=#3f9eef>Press <ESC> to close</color> ";
			break;
		}
		LogManager.ReplaceVariables(ref text);
		msgFormater.SetRawText(text);
		logo.sprite = null;
		logo.color = Color.black;
		int num = GameSaveFile.Get("Q_VSYNC", QualitySettings.vSyncCount);
		QualitySettings.vSyncCount = 0;
		QualitySettings.vSyncCount = 1;
		if (num != QualitySettings.vSyncCount)
		{
			QualitySettings.vSyncCount = num;
		}
		if (startingState > 2)
		{
			LastLogoFrame();
			asciiLabel.gameObject.SetActive(true);
			DisableCursor();
		}
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape) || (currentState != 4 && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))))
		{
			if (currentState == 4)
			{
				PostScreen();
			}
			else
			{
				LastLogoFrame();
				asciiLabel.gameObject.SetActive(true);
				DisableCursor();
				msgFormater.CompleteText(ref logText);
				bodyLabel.text = logText;
				currentState = 4;
			}
		}
		else
		{
			if (Input.GetButtonDown("Right") || (currentState == 4 && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))))
			{
				currentPageIdx++;
				if (currentPageIdx > 3)
				{
					currentPageIdx = 0;
				}
				Show(currentPageIdx, 3);
				return;
			}
			if (Input.GetButtonDown("Left"))
			{
				currentPageIdx--;
				if (currentPageIdx < 0)
				{
					currentPageIdx = 3;
				}
				Show(currentPageIdx, 3);
				return;
			}
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
				bootSequenceLabel.text = "Accessing records......_";
			}
			else
			{
				bootSequenceLabel.text = "Accessing records......";
			}
		}
	}

	private void PostScreen()
	{
		ResourceManager.UnloadAsset("UI/misfitsLogoScanSheet");
		MenuPanelUI.Instance.gameObject.SetActive(true);
		MenuPanelUI.Instance.Enable();
		base.gameObject.SetActive(false);
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

	private void LastLogoFrame()
	{
		if (idxLogoFrame < logoSpriteArray.Length - 1)
		{
			idxLogoFrame = logoSpriteArray.Length - 1;
			logo.sprite = logoSpriteArray[idxLogoFrame];
			logo.color = Color.white;
		}
	}

	private void EnableCursor()
	{
		isCursorEnabled = true;
		isShowingCursor = true;
		timerCursorBlink = 0.2f;
		bootSequenceLabel.text = "Accessing records......_";
	}

	private void DisableCursor()
	{
		isCursorEnabled = false;
		bootSequenceLabel.text = "Accessing records......";
	}
}
