using UnityEngine;

public class ModalWindow : MonoBehaviour
{
	private const int MAX_WINDOW_WIDTH = 300;

	private const int MAX_WINDOW_HEIGHT = 150;

	private const int BUTTON_WIDTH = 75;

	private const int BUTTON_HEIGHT = 30;

	private const int BUTTON_MARGIN = 5;

	private const int INPUT_BOX_HEIGHT = 55;

	private Rect overlayWindowRect = new Rect(-50f, -50f, 10000f, 10000f);

	private int modalWindowId = 15;

	private int overlayWindowId = 16;

	private Vector2 scrollPosition = Vector2.zero;

	private static Rect modalWindowRect;

	private static bool showModalWindow = false;

	private static bool showCustomWindow = false;

	private static string titleOfWindow = string.Empty;

	private static GUIStyle messageTextStyle = new GUIStyle();

	private static GUIContent messageContent = new GUIContent();

	private static GUI.WindowFunction customWindowFunction;

	private static ModalWindowType modalWindowType;

	private static bool showInputWindow;

	private static ModalWindowResultDelegate windowResultDelegate;

	private static ModalWindowResult windowResult = ModalWindowResult.None;

	private static string inputStringResult = string.Empty;

	private static int inputTextMaxLength = 200;

	public static bool WindowIsShowing
	{
		get
		{
			return showModalWindow;
		}
	}

	public static int InputTextMaxLength
	{
		get
		{
			return inputTextMaxLength;
		}
		set
		{
			inputTextMaxLength = value;
		}
	}

	public static void ShowModalWindow(string title, string message)
	{
		ShowModalWindow(title, message, ModalWindowType.OK, null, 300, 300);
	}

	public static void ShowModalWindow(string title, string message, ModalWindowType type, ModalWindowResultDelegate resultDelegate, int width, int height)
	{
		ShowModalWindow(title, message, type, false, string.Empty, resultDelegate, width, height);
	}

	public static void ShowModalWindow(string title, string message, ModalWindowType type, bool showInput, string initialText, ModalWindowResultDelegate resultDelegate)
	{
		ShowModalWindow(title, message, type, showInput, initialText, resultDelegate, 300, 150);
	}

	public static void ShowModalWindow(string title, string message, ModalWindowType type, bool showInput, string initialText, ModalWindowResultDelegate resultDelegate, int width, int height)
	{
		if (!WindowIsShowing)
		{
			titleOfWindow = title;
			showCustomWindow = false;
			messageTextStyle.normal.textColor = Color.white;
			messageTextStyle.wordWrap = true;
			messageContent.text = message;
			int num = Screen.width / 2 - width / 2;
			int num2 = Screen.height / 2 - height / 2;
			modalWindowRect = new Rect(num, num2, width, (!showInput) ? height : (height + 55));
			modalWindowType = type;
			showInputWindow = showInput;
			windowResultDelegate = resultDelegate;
			windowResult = ModalWindowResult.None;
			inputStringResult = initialText;
			showModalWindow = true;
		}
	}

	public static void ShowModalWindowCustom(string title, GUI.WindowFunction windowFunction)
	{
		ShowModalWindowCustom(title, 300, 150, windowFunction);
	}

	public static void ShowModalWindowCustom(string title, int width, int height, GUI.WindowFunction windowFunction)
	{
		if (!WindowIsShowing)
		{
			titleOfWindow = title;
			showCustomWindow = true;
			customWindowFunction = windowFunction;
			windowResult = ModalWindowResult.Custom;
			inputStringResult = string.Empty;
			int num = Screen.width / 2 - width / 2;
			int num2 = Screen.height / 2 - height / 2;
			modalWindowRect = new Rect(num, num2, width, height);
			showModalWindow = true;
		}
	}

	public static void CloseModalWindow()
	{
		showModalWindow = false;
	}

	private void OnGUI()
	{
		if (showModalWindow)
		{
			GUI.depth = -1;
			modalWindowRect = CommonMethods.KeepWindowVisible(modalWindowRect);
			if (showCustomWindow)
			{
				modalWindowRect = GUI.Window(modalWindowId, modalWindowRect, customWindowFunction, titleOfWindow);
			}
			else
			{
				modalWindowRect = GUI.Window(modalWindowId, modalWindowRect, DrawModalWindow, titleOfWindow);
			}
			GUI.Window(overlayWindowId, overlayWindowRect, DrawBackgroundOverlay, string.Empty);
		}
	}

	public static bool TestKeyInput()
	{
		ModalWindowResult modalWindowResult = ModalWindowResult.None;
		switch (modalWindowType)
		{
		case ModalWindowType.YesNo:
		case ModalWindowType.YesNoCancel:
			if (Input.GetKeyDown(KeyCode.Y))
			{
				modalWindowResult = ModalWindowResult.Yes;
			}
			else if (Input.GetKeyDown(KeyCode.N) || (modalWindowType == ModalWindowType.YesNo && Input.GetKeyDown(KeyCode.Escape)))
			{
				modalWindowResult = ModalWindowResult.No;
			}
			else if (modalWindowType == ModalWindowType.YesNoCancel && (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Escape)))
			{
				modalWindowResult = ModalWindowResult.Cancel;
			}
			break;
		case ModalWindowType.Pause2:
			if (Input.GetKeyDown(KeyCode.R))
			{
				modalWindowResult = ModalWindowResult.Restart;
			}
			else if (Input.GetKeyDown(KeyCode.M))
			{
				modalWindowResult = ModalWindowResult.Menu;
			}
			else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Escape))
			{
				modalWindowResult = ModalWindowResult.Cancel;
			}
			break;
		case ModalWindowType.OK:
		case ModalWindowType.OKCancel:
			if (Input.GetKeyDown(KeyCode.O))
			{
				modalWindowResult = ModalWindowResult.OK;
			}
			else if (Input.GetKeyDown(KeyCode.Escape))
			{
				modalWindowResult = ModalWindowResult.Cancel;
			}
			else if (modalWindowType == ModalWindowType.OK && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
			{
				modalWindowResult = ModalWindowResult.OK;
			}
			break;
		case ModalWindowType.ContinueExit:
			if (Input.GetKeyDown(KeyCode.C))
			{
				modalWindowResult = ModalWindowResult.Continue;
			}
			else if (Input.GetKeyDown(KeyCode.E) && Input.GetKeyDown(KeyCode.Escape))
			{
				modalWindowResult = ModalWindowResult.Exit;
			}
			break;
		}
		if (modalWindowResult != ModalWindowResult.None)
		{
			CloseDialogWithResult(modalWindowResult);
			Input.ResetInputAxes();
			return true;
		}
		return false;
	}

	private static void CloseDialogWithResult(ModalWindowResult result)
	{
		windowResult = result;
		CloseModalWindow();
		if (windowResultDelegate != null)
		{
			windowResultDelegate(windowResult, inputStringResult);
		}
	}

	private void DrawModalWindow(int windowID)
	{
		GUILayout.Space(5f);
		int num = ((!showInputWindow) ? 65 : 90);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(modalWindowRect.width - 20f), GUILayout.Height(modalWindowRect.height - (float)num));
		GUILayout.BeginVertical();
		GUILayout.Label(messageContent, messageTextStyle);
		GUILayout.EndVertical();
		GUILayout.EndScrollView();
		if (showInputWindow)
		{
			GUI.SetNextControlName("InputTextEntryField");
			inputStringResult = GUILayout.TextField(inputStringResult, GUILayout.Width(modalWindowRect.width - 20f));
			if (inputStringResult.Length > InputTextMaxLength)
			{
				inputStringResult = inputStringResult.Substring(0, InputTextMaxLength);
			}
		}
		DrawButtons();
		GUI.DragWindow();
	}

	private void DrawButtons()
	{
		switch (modalWindowType)
		{
		case ModalWindowType.OK:
		{
			Rect position8 = new Rect(modalWindowRect.width - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position8, "OK [O]"))
			{
				CloseDialogWithResult(ModalWindowResult.OK);
			}
			break;
		}
		case ModalWindowType.OKCancel:
		{
			Rect position8 = new Rect(modalWindowRect.width - 80f - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position8, "OK"))
			{
				CloseDialogWithResult(ModalWindowResult.OK);
			}
			Rect position = new Rect(modalWindowRect.width - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position, "Cancel"))
			{
				CloseDialogWithResult(ModalWindowResult.Cancel);
			}
			break;
		}
		case ModalWindowType.YesNo:
		{
			Rect position4 = new Rect(modalWindowRect.width - 80f - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position4, "Yes [Y]"))
			{
				CloseDialogWithResult(ModalWindowResult.Yes);
			}
			Rect position5 = new Rect(modalWindowRect.width - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position5, "No [N]"))
			{
				CloseDialogWithResult(ModalWindowResult.No);
			}
			break;
		}
		case ModalWindowType.YesNoCancel:
		{
			Rect position4 = new Rect(modalWindowRect.width - 80f - 80f - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position4, "[Y]es"))
			{
				CloseDialogWithResult(ModalWindowResult.Yes);
			}
			Rect position5 = new Rect(modalWindowRect.width - 80f - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position5, "[N]o"))
			{
				CloseDialogWithResult(ModalWindowResult.No);
			}
			Rect position = new Rect(modalWindowRect.width - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position, "[C]ancel"))
			{
				CloseDialogWithResult(ModalWindowResult.Cancel);
			}
			break;
		}
		case ModalWindowType.Pause:
		{
			Rect position6 = new Rect(modalWindowRect.width - 80f - 80f - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position6, "[R]andom"))
			{
				CloseDialogWithResult(ModalWindowResult.Reset_random);
			}
			Rect position7 = new Rect(modalWindowRect.width - 80f - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position7, "[S]ame"))
			{
				CloseDialogWithResult(ModalWindowResult.Reset_same);
			}
			Rect position = new Rect(modalWindowRect.width - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position, "[C]ancel"))
			{
				CloseDialogWithResult(ModalWindowResult.Cancel);
			}
			break;
		}
		case ModalWindowType.Pause2:
		{
			Rect position = new Rect(modalWindowRect.width - 80f - 80f - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position, "Cancel [C]"))
			{
				CloseDialogWithResult(ModalWindowResult.Cancel);
			}
			Rect position2 = new Rect(modalWindowRect.width - 80f - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position2, "Menu [M]"))
			{
				CloseDialogWithResult(ModalWindowResult.Menu);
			}
			Rect position3 = new Rect(modalWindowRect.width - 80f, modalWindowRect.height - 30f - 5f, 75f, 30f);
			if (GUI.Button(position3, "Restart [R]"))
			{
				CloseDialogWithResult(ModalWindowResult.Restart);
			}
			break;
		}
		case ModalWindowType.OKCancelInput:
			break;
		}
	}

	private void DrawBackgroundOverlay(int windowID)
	{
		if (GUI.Button(new Rect(0f, 0f, 10000f, 10000f), string.Empty))
		{
			GUI.BringWindowToFront(modalWindowId);
			GUI.FocusWindow(modalWindowId);
		}
		GUI.DragWindow();
	}
}
