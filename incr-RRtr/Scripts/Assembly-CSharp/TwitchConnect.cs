using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class TwitchConnect : MonoBehaviour
{
	public TwitchIntegration twitchIntegration;

	public TMP_InputField userInput;

	public TMP_InputField channelInput;

	public TMP_InputField oAuthInput;

	public TMP_Text statusText;

	public TMP_Text buttonText;

	private TcpClient twitch;

	private StreamReader reader;

	private StreamWriter writer;

	private const string URL = "irc.chat.twitch.tv";

	private const int PORT = 6667;

	public string user = "MisterMorrisGames";

	public string oAuth = "oauth";

	public string channel = "MisterMorrisGames";

	public Dictionary<string, Texture2D> emotes;

	private float timer;

	public void UpdateUserTo(string input)
	{
		user = input;
	}

	public void UpdateOAuthTo(string input)
	{
		oAuth = input;
	}

	public void UpdateChannelTo(string input)
	{
		channel = input;
	}

	public void PasteIntoOAuth()
	{
		TextEditor textEditor = new TextEditor();
		textEditor.Paste();
		oAuth = textEditor.text;
		oAuthInput.SetTextWithoutNotify(oAuth);
		oAuthInput.Select();
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void EnableZoomWithLetters()
	{
		GameManager.ins.canUseLetterShortcuts = true;
	}

	public void DisableZoomWithLetters()
	{
		GameManager.ins.canUseLetterShortcuts = false;
	}

	public void LoadSettings()
	{
		userInput.SetTextWithoutNotify(user);
		channelInput.SetTextWithoutNotify(channel);
		oAuthInput.SetTextWithoutNotify(oAuth);
	}

	public void ClickedConnect()
	{
		if (buttonText.text == "DISCONNECT")
		{
			DisconnectFromTwitch();
		}
		else
		{
			ConnectToTwitch();
		}
	}

	private void ConnectToTwitch()
	{
		try
		{
			twitch = new TcpClient("irc.chat.twitch.tv", 6667);
			reader = new StreamReader(twitch.GetStream());
			writer = new StreamWriter(twitch.GetStream());
			writer.WriteLine("PASS " + oAuth);
			writer.WriteLine("NICK " + user.ToLower());
			writer.WriteLine("JOIN #" + channel.ToLower());
			writer.WriteLine("CAP REQ :twitch.tv/tags");
			writer.WriteLine("CAP REQ :twitch.tv/commands");
			writer.WriteLine("CAP REQ :twitch.tv/membership");
			writer.Flush();
			timer = 0f;
		}
		catch (Exception)
		{
			buttonText.text = "CONNECT";
			statusText.text = "(Failed - timeout)";
		}
	}

	private void DisconnectFromTwitch()
	{
		if (twitch != null)
		{
			twitch.GetStream().Close();
			twitch.Close();
			twitch = null;
			buttonText.text = "CONNECT";
			statusText.text = "(Disconnected)";
			twitchIntegration.DespawnAllChatters();
		}
	}

	private void Update()
	{
		if (timer < 8f)
		{
			timer += Time.deltaTime;
		}
		if (twitch != null && !twitch.Connected && timer > 4f)
		{
			ConnectToTwitch();
		}
		if (twitch == null || twitch.Available <= 0)
		{
			return;
		}
		string text = reader.ReadLine();
		Debug.Log(text);
		if (text.Contains("Welcome, GLHF!"))
		{
			buttonText.text = "DISCONNECT";
			statusText.text = "(Connected)";
			twitchIntegration.AddStreamerBonusMoney();
		}
		if (text.Contains("Login authentication failed"))
		{
			buttonText.text = "CONNECT";
			statusText.text = "(Failed - try again)";
		}
		if (text.Contains("PRIVMSG"))
		{
			int num = text.IndexOf(" ");
			string text2 = text.Substring(0, num);
			bool chatterSub = false;
			if (text2.Contains("@badge-info=subscriber"))
			{
				chatterSub = true;
			}
			if (text2.Contains("@badge-info=founder"))
			{
				chatterSub = true;
			}
			if (text2.Contains("@badges=founder"))
			{
				chatterSub = true;
			}
			int num2 = text.IndexOf("display-name=") + 13;
			int num3 = text.IndexOf(";", num2);
			string text3 = text.Substring(num2, num3 - num2);
			string text4 = text.Substring(num + 1);
			int num4 = text4.IndexOf("!");
			text4.Substring(1, num4 - 1);
			num4 = text4.IndexOf(":", 1);
			string text5 = text4.Substring(num4 + 1);
			twitchIntegration.Command(text3, text5, chatterSub);
			Debug.Log(text5 + " from " + text3 + " who is subbed:" + chatterSub);
			CheckForEmotes(text3, text);
		}
		if (text.Contains("PING :tmi.twitch.tv"))
		{
			writer.WriteLine("PONG tmi.twitch.tv\r\n");
			writer.Flush();
			Debug.Log("replied with PONG");
		}
	}

	private void CheckForEmotes(string chatter, string message)
	{
		if (!message.Contains("emotes=;") && message.Contains("emotes="))
		{
			string[] separator = new string[1] { "emotes=" };
			string[] array = message.Split(separator, StringSplitOptions.None);
			int length = array[1].IndexOf(";", 0);
			string[] array2 = array[1].Substring(0, length).Split('/');
			if (array2.Length != 0)
			{
				int length2 = array2[0].IndexOf(":", 0);
				string text = array2[0].Substring(0, length2);
				StartCoroutine(GetTexture(chatter, "https://static-cdn.jtvnw.net/emoticons/v1/" + text + "/3.0"));
			}
		}
	}

	private IEnumerator GetTexture(string chatter, string url)
	{
		if (emotes == null)
		{
			emotes = new Dictionary<string, Texture2D>();
		}
		if (!emotes.ContainsKey(url))
		{
			UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
			yield return www.SendWebRequest();
			Texture2D content = DownloadHandlerTexture.GetContent(www);
			emotes.Add(url, content);
		}
		if (emotes.TryGetValue(url, out var value))
		{
			twitchIntegration.Emote(chatter, value);
		}
	}
}
