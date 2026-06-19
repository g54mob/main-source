using Unity.Mathematics;
using UnityEngine;

public class IPandPortText : MonoBehaviour
{
	public PugText worldNameText;

	public PugText gameIdText;

	public PugText IPText;

	public PugText PortText;

	public PugText PasswordText;

	public PugText pingText;

	public GameObject divider;

	public GameObject buttonsContainer;

	public RadicalMenuOption_Toggle visibilityToggle;

	public GameObject copyGameInfoButton;

	public GameObject refreshGameIDButton;

	public GameObject refreshGameInfoButton;

	private const string worldNameFormat = "Menu/WorldName";

	private const string gameIdFormat = "Menu/GameID";

	private const string steamGameIdFormat = "Menu/SteamGameID";

	private const string pingFormat = "Menu/Ping";

	private const string ipFormat = "Menu/IP";

	private const string portFormat = "Menu/Port";

	private const string passwordFormat = "Menu/Password";

	private bool prevShowGameID;

	private ServerConnectionInfo oldSessionId;

	private int lastRtt = -1;

	private string prevLanguage;

	private string prevWorldName;

	private bool _updatingName;

	private void LateUpdate()
	{
		int num = 0;
		if (Manager.ecs.ServerWorld == null)
		{
			num = (int)math.round(Manager.networking.rttToServer);
		}
		if (prevShowGameID == visibilityToggle.isOn && !(oldSessionId != Manager.networking.CurrentSession) && lastRtt == num && !(prevLanguage != Manager.prefs.language) && !(prevWorldName != Manager.networking.serverName))
		{
			return;
		}
		UpdateName();
		if (!Manager.platform.hasNetwork || Manager.networking.OfflineSession)
		{
			gameIdText.gameObject.SetActive(value: false);
			pingText.gameObject.SetActive(value: false);
			divider.gameObject.SetActive(value: false);
			IPText.gameObject.SetActive(value: false);
			PortText.gameObject.SetActive(value: false);
			PasswordText.gameObject.SetActive(value: false);
		}
		else
		{
			UpdateConnectionInfo();
			if (num != 0)
			{
				pingText.formatFields = new string[1] { num.ToString() };
				pingText.Render("Menu/Ping");
				if (!pingText.gameObject.activeSelf)
				{
					pingText.gameObject.SetActive(value: true);
				}
			}
			if ((lastRtt == 0 || num == 0) && lastRtt != num)
			{
				pingText.gameObject.SetActive(num != 0);
			}
		}
		prevLanguage = Manager.prefs.language;
		prevWorldName = Manager.networking.serverName;
		prevShowGameID = visibilityToggle.isOn;
		oldSessionId = Manager.networking.CurrentSession;
		lastRtt = num;
	}

	private void UpdateName()
	{
		if (!(prevWorldName == Manager.networking.serverName) && !_updatingName)
		{
			_updatingName = true;
			worldNameText.formatFields = new string[1] { "..." };
			worldNameText.Render("Menu/WorldName");
			Manager.platform.parentalControlManager.IParentalControl.RestrictInput(Manager.networking.serverName, delegate(string result)
			{
				worldNameText.formatFields = new string[1] { result };
				worldNameText.Render("Menu/WorldName");
				_updatingName = false;
			});
		}
	}

	private void UpdateConnectionInfo()
	{
		bool isOn = visibilityToggle.isOn;
		ServerConnectionInfo currentSession = Manager.networking.CurrentSession;
		IPText.gameObject.SetActive(!string.IsNullOrEmpty(currentSession.PublicIP));
		if (!string.IsNullOrEmpty(currentSession.PublicIP))
		{
			IPText.textSuffix = ": " + (isOn ? currentSession.PublicIP : new string('*', 12));
			IPText.Render("Menu/IP");
		}
		PortText.gameObject.SetActive(!string.IsNullOrEmpty(currentSession.Port));
		if (!string.IsNullOrEmpty(currentSession.Port))
		{
			PortText.textSuffix = ": " + (isOn ? currentSession.Port : new string('*', currentSession.Port.Length));
			PortText.Render("Menu/Port");
		}
		PasswordText.gameObject.SetActive(!string.IsNullOrEmpty(currentSession.Password));
		if (!string.IsNullOrEmpty(currentSession.Password))
		{
			PasswordText.textSuffix = ": " + (isOn ? currentSession.Password : new string('*', 12));
			PasswordText.Render("Menu/Password");
		}
		copyGameInfoButton.SetActive(!string.IsNullOrEmpty(currentSession.Password));
		refreshGameInfoButton.SetActive(!string.IsNullOrEmpty(currentSession.Password));
		refreshGameIDButton.SetActive(string.IsNullOrEmpty(currentSession.Password));
		gameIdText.gameObject.SetActive(!string.IsNullOrEmpty(currentSession.GameID));
		if (!string.IsNullOrEmpty(currentSession.GameID))
		{
			string text = (currentSession.IsValid() ? currentSession.GameID : "None");
			string text2 = (isOn ? text : new string('*', 12));
			gameIdText.formatFields = new string[1] { text2 };
			if (Manager.networking.currentSessionIsDedicatedServer)
			{
				gameIdText.Render("Menu/SteamGameID");
			}
			else if (!Manager.prefs.crossPlay)
			{
				gameIdText.Render("Menu/SteamGameID");
			}
			else
			{
				gameIdText.Render("Menu/GameID");
			}
		}
	}
}
