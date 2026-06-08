using UnityEngine;

public class DeveloperNotificationManager : MonoBehaviour
{
	public const int CurrentNotificationID = 0;

	public static DeveloperNotificationManager Instance;

	private Rect windowRect;

	private string CurrentTitle = "New Update Video";

	private string CurrentMessage = "There's been an update since you last played, here's a video describing the update";

	private string AcceptMessage = "[O]pen Video";

	private string LinkURL = "https://www.youtube.com/watch?v=l_dTsPkMgCE&feature=share&list=PLWHgLfDKHMzy_jZFDOu7nz1ZpeVoic8Mz";

	private string ImagePath = "NotificationThumbnails/notification1";

	private Texture2D thumbTexture;

	private KeyCode AcceptKeyCode = KeyCode.O;

	private bool isDoneShowing;

	public bool IsShowing { get; private set; }

	private void Awake()
	{
		Instance = this;
		base.enabled = false;
	}

	public bool HasANewNotification()
	{
		return false;
	}

	public void BeginShowNotification()
	{
		Instance.enabled = true;
		ResourceManager.OneTimeGalaxyResourceLoad();
		if (!string.IsNullOrEmpty(ImagePath))
		{
			thumbTexture = Resources.Load<Texture2D>(ImagePath);
		}
		if (thumbTexture != null)
		{
			windowRect = new Rect(Screen.width / 2 - (thumbTexture.width + 10) / 2, Screen.height / 2 - (thumbTexture.height + 110) / 2, thumbTexture.width + 10, thumbTexture.height + 110);
		}
		else
		{
			windowRect = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400f, 200f);
		}
		isDoneShowing = false;
		IsShowing = true;
	}

	public void Update()
	{
		IsShowing = !isDoneShowing;
		if (isDoneShowing)
		{
			if (MainMenu.Instance == null)
			{
				new MainMenu();
			}
			MenuPanelUI.Instance.Enable();
			base.enabled = false;
			Object.Destroy(this);
		}
		else
		{
			MenuPanelUI.Instance.Disable();
		}
	}

	public void OnGUI()
	{
		windowRect = GUI.Window(36, windowRect, DrawWindow, CurrentTitle);
	}

	private void DrawWindow(int id)
	{
		GUI.Label(new Rect(5f, 20f, windowRect.width - 10f, 40f), CurrentMessage);
		if (thumbTexture != null)
		{
			GUI.DrawTexture(new Rect(5f, 45f, thumbTexture.width, thumbTexture.height), thumbTexture);
		}
		if (Event.current.keyCode == KeyCode.I)
		{
			IgnoreButtonPressed();
		}
		else if (Event.current.keyCode == AcceptKeyCode)
		{
			AcceptButtonPressed();
		}
		if (GUI.Button(new Rect(5f, windowRect.height - 55f, 100f, 50f), "[I]gnore"))
		{
			IgnoreButtonPressed();
		}
		if (GUI.Button(new Rect(windowRect.width - 105f, windowRect.height - 55f, 100f, 50f), AcceptMessage))
		{
			AcceptButtonPressed();
		}
	}

	private void IgnoreButtonPressed()
	{
		GameSaveFile.Save("NOTIFICATION", string.Format("IGNORED_{0}", 0.ToString()), true);
		isDoneShowing = true;
	}

	private void AcceptButtonPressed()
	{
		GameSaveFile.Save("NOTIFICATION", string.Format("VIEWED_{0}", 0.ToString()), true);
		Application.OpenURL(LinkURL);
		DialogUI.Instance.ShowDialog("Link Opened", string.Format("The link has been opened in your default browser..."), ModalWindowType.OK, null);
		isDoneShowing = true;
	}
}
