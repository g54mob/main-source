using UnityEngine;

public class HelpManualScript : MonoBehaviour
{
	public static HelpManualScript Instance;

	public Color MenuItemColor = Color.white;

	public Color CommandBaseColor = Color.white;

	public Color CommandBaseHighlightColor = Color.white;

	public Color CommandDetailColor = Color.white;

	public GameObject enterKeyHint;

	private bool _menuLoadedOk;

	public string hexBaseColor { get; private set; }

	public string hexBaseHighlightColor { get; private set; }

	public string hexDetailColor { get; private set; }

	public bool IsInitialized { get; private set; }

	private void Awake()
	{
		Instance = this;
		if (!IsInitialized)
		{
			Initialize();
		}
		Color32 color = CommandBaseColor;
		Color32 color2 = CommandBaseHighlightColor;
		Color32 color3 = CommandDetailColor;
		hexBaseColor = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
		hexBaseHighlightColor = color2.r.ToString("X2") + color2.g.ToString("X2") + color2.b.ToString("X2");
		hexDetailColor = color3.r.ToString("X2") + color3.g.ToString("X2") + color3.b.ToString("X2");
	}

	private void Initialize()
	{
		if (!IsInitialized)
		{
			IsInitialized = true;
			Manual.Initalize(base.transform.gameObject);
		}
	}

	private void Update()
	{
		if (DungeonManager.Instance != null && Manual.SelectedMenuItem != null && !Manual.IsAtTop && Manual.SelectedMenuItem.IsCommand)
		{
			if (!enterKeyHint.gameObject.activeSelf)
			{
				enterKeyHint.gameObject.SetActive(true);
			}
			if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && !Manual.IsAtTop)
			{
				HelpManualMenuItem selectedMenuItem = Manual.SelectedMenuItem;
				if (ConsoleWindow3.Instance != null && selectedMenuItem.IsCommand)
				{
					string text = "help " + selectedMenuItem.DisplayText;
					ConsoleWindow3.Instance.InjectCommandText("help " + selectedMenuItem.DisplayText);
				}
				if (GameplayManager.Instance != null)
				{
					GameplayManager.Instance.CloseHelpWindow();
				}
			}
		}
		else if (enterKeyHint.gameObject.activeSelf)
		{
			enterKeyHint.gameObject.SetActive(false);
		}
		Manual.Update();
	}
}
