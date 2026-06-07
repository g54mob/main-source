using System.Collections;
using Mirror;
using TMPro;
using UnityEngine;

public class MVerseSector : MonoBehaviour
{
	public GameObject gameJoinContainer;

	public TMP_InputField keyTextField;

	public TextMeshProUGUI joinGameText;

	public MVerseHostMissionButton[] missionButtons;

	public GameObject playAndHostButton;

	public GameObject connectingPane;

	public TextMeshProUGUI connectingPaneText;

	public TextMeshProUGUI connectionError;

	public TMP_InputField playerNameInputField;

	private bool started;

	private string lastGameStartData;

	private float startTime;

	private float CONNECTTIMEOUT;

	public void OnEnable()
	{
	}

	public void Update()
	{
	}

	public void OnPlayerNameChanged(string val)
	{
	}

	public void OnButtonPressed(int num)
	{
	}

	public void OnPlayAndHost()
	{
	}

	private void PlayAndHost(int mission)
	{
	}

	public void OnKeyChanged()
	{
	}

	public void Refresh()
	{
	}

	public void OnJoinGame()
	{
	}

	private IEnumerator OnJoinGameInternetCo(NetworkManager manager)
	{
		return null;
	}

	public void CloseConnectPane()
	{
	}

	private void OnFinishJoinGameInternet(NetworkManager manager)
	{
	}

	public void OnCancelGame()
	{
	}

	public void OnPasteKey()
	{
	}
}
