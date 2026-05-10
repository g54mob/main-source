using System.Collections;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.APITwitch
{
	public class APITwitch : MonoBehaviour
	{
		[ReadOnly]
		private string _user;

		[Header("https://twitchapps.com/tmi/")]
		[ReadOnly]
		private string _oAuth;

		[SerializeField]
		private float _minuteBeforeCleaningListOfNameUsed;

		[SerializeField]
		private int _maxNameInTheList;

		[Foldout("Dev")]
		[SerializeField]
		private TMP_InputField _userNameInputField;

		[Foldout("Dev")]
		[SerializeField]
		private TMP_InputField _passwordInputField;

		[Foldout("Dev")]
		[SerializeField]
		private Toggle _toggleChatModification;

		[Foldout("Dev")]
		[SerializeField]
		private TMP_Text _connectedText;

		[Foldout("Connexion")]
		[SerializeField]
		private GameObject _connectedButton;

		[Foldout("Connexion")]
		[SerializeField]
		private GameObject _disconnectButton;

		[Foldout("Connexion")]
		[SerializeField]
		private GameObject _connectecdText;

		[Foldout("Connexion")]
		[SerializeField]
		private GameObject _disconnectText;

		[Foldout("Dev")]
		[SerializeField]
		private GameObject _connectedPanel;

		[Foldout("Dev")]
		[SerializeField]
		private GameObject _disconnedPanel;

		[Foldout("Dev")]
		[SerializeField]
		private GameObject _usernameInvalidPanel;

		[Foldout("Dev")]
		[SerializeField]
		private GameObject _oAuthInvalidPanel;

		[Foldout("Dev")]
		[SerializeField]
		private GameObject _combinationUserOAuthPanel;

		private float _pingCont;

		private float _timeBeforeCleanList;

		private TcpClient _twitchClient;

		private StreamReader _streamReader;

		private StreamWriter _streamWriter;

		private const string URL = "irc.chat.twitch.tv";

		private const int Port = 6667;

		private bool _connected;

		private bool _checkverification;

		private bool _streamerWantChatModification;

		private Color _color;

		public static EventName ListNameTwitch { get; private set; }

		private void Awake()
		{
			_oAuth = "";
			_user = "";
			_toggleChatModification.isOn = false;
			_connected = false;
			_checkverification = false;
			_connectecdText.SetActive(value: false);
			_disconnectText.SetActive(value: true);
			_connectedButton.SetActive(value: true);
			_disconnectButton.SetActive(value: false);
			_color = _userNameInputField.textComponent.color;
			_streamerWantChatModification = false;
		}

		private void ConnectToTwitch()
		{
			if (_user == "")
			{
				_oAuth = "";
				_user = "";
				_userNameInputField.textComponent.color = Color.red;
				_passwordInputField.textComponent.color = Color.red;
				return;
			}
			if (_oAuth == "" || _oAuth.Contains("\n"))
			{
				_oAuth = "";
				_passwordInputField.textComponent.color = Color.red;
				return;
			}
			_twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
			_streamReader = new StreamReader(_twitchClient.GetStream());
			_streamWriter = new StreamWriter(_twitchClient.GetStream());
			_streamWriter.WriteLine("PASS " + _oAuth);
			_streamWriter.WriteLine("NICK " + _user);
			_streamWriter.WriteLine("JOIN #" + _user.ToLower());
			_streamWriter.Flush();
			_connected = true;
		}

		private async Task SendPing()
		{
			_pingCont += Time.deltaTime;
			_timeBeforeCleanList += Time.deltaTime;
			if (_pingCont > 60f)
			{
				await _streamWriter.WriteLineAsync("PING irc.chat.twitch.tv");
				await _streamWriter.FlushAsync();
				_pingCont = 0f;
			}
			if (_timeBeforeCleanList > 60f * _minuteBeforeCleaningListOfNameUsed && ListNameTwitch != null)
			{
				ListNameTwitch.CleanUsedListName();
				_timeBeforeCleanList = 0f;
			}
		}

		private bool CheckGate(string message)
		{
			string text = message.ToLower();
			string text2 = message.Split(' ')[^3];
			Debug.Log(message);
			if (text.Contains(":invalid nick"))
			{
				_userNameInputField.textComponent.color = Color.red;
				return false;
			}
			if (text.Contains(":login authentication failed") || text.Contains(":improperly formatted auth") || !_oAuth.Contains("oauth:"))
			{
				_passwordInputField.textComponent.color = Color.red;
				return false;
			}
			if (text2 != _user)
			{
				_userNameInputField.textComponent.color = Color.red;
				_passwordInputField.textComponent.color = Color.red;
				return false;
			}
			return true;
		}

		private async Task ReadTwitchMessages()
		{
			if (!_twitchClient.Connected)
			{
				ConnectToTwitch();
			}
			if (_twitchClient.Available <= 0)
			{
				return;
			}
			string text = await _streamReader.ReadLineAsync();
			Debug.Log(text);
			if (!_checkverification)
			{
				bool flag = CheckGate(text);
				if (!flag)
				{
					_checkverification = flag;
					_connected = false;
					return;
				}
				_checkverification = flag;
				_connectecdText.SetActive(value: true);
				_disconnectText.SetActive(value: false);
				_connectedButton.SetActive(value: false);
				_disconnectButton.SetActive(value: true);
			}
			Debug.Log("Je suis passé la checkgate");
			if (text.Contains("PRIVMSG") && _streamerWantChatModification)
			{
				int num = text.IndexOf("!");
				string pChatter = text.Substring(1, num - 1);
				num = text.IndexOf(":", 1);
				string pMessage = text.Substring(num + 1);
				Debug.Log("ICI");
				ListNameTwitch.OnChatMessage(pChatter, pMessage);
			}
		}

		private IEnumerator TimeConnection()
		{
			_user = _userNameInputField.text;
			string text = _passwordInputField.text.Replace(" ", "");
			_oAuth = text.ToLower();
			if (ListNameTwitch == null)
			{
				ListNameTwitch = Resources.Load<EventName>("Scriptables/Twitch/ListNameTwitch");
				ListNameTwitch.ClearTheList();
				Debug.Log(ListNameTwitch);
			}
			else
			{
				ListNameTwitch.ClearTheList();
				Debug.Log(ListNameTwitch);
			}
			ListNameTwitch.ChangeMaxName(_maxNameInTheList);
			yield return new WaitForEndOfFrame();
			ConnectToTwitch();
		}

		public static EventName GiveList()
		{
			return ListNameTwitch;
		}

		public void LaunchTheConnection()
		{
			_userNameInputField.textComponent.color = _color;
			_passwordInputField.textComponent.color = _color;
			StartCoroutine(TimeConnection());
		}

		public void ClearText()
		{
			_passwordInputField.text = "";
		}

		public void Disconnect()
		{
			_oAuth = "";
			_passwordInputField.text = "";
			_connected = false;
			_checkverification = false;
			ListNameTwitch.ClearTheList();
			_connectecdText.SetActive(value: false);
			_disconnectText.SetActive(value: true);
			_connectedButton.SetActive(value: true);
			_disconnectButton.SetActive(value: false);
		}

		public void NeedaOAuth()
		{
			Application.OpenURL("https://twitchapps.com/tmi/");
		}

		public void ActiveChatModification()
		{
			_streamerWantChatModification = !_streamerWantChatModification;
		}

		private async void Update()
		{
			if (_connected)
			{
				if (!_twitchClient.Connected)
				{
					ConnectToTwitch();
				}
				await SendPing();
				await ReadTwitchMessages();
			}
		}
	}
}
