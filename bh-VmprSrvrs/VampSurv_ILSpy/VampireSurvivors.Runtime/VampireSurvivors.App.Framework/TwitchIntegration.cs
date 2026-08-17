using System;
using System.Collections;
using System.Net.Sockets;
using Lexone.UnityTwitchChat;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.App.Framework;

public class TwitchIntegration : IInitializable, IDisposable
{
	private static TwitchIntegration _sInstance;

	private string _username;

	private PlayerOptions _playerOptions;

	public string TwitchUsername
	{
		get
		{
			return _username;
		}
		set
		{
			_username = value;
		}
	}

	public static TwitchIntegration Instance => _sInstance;

	public IRC TwitchClient => IRC._003CInstance_003Ek__BackingField;

	public void Initialize()
	{
		if (_sInstance == null)
		{
			_sInstance = this;
		}
		else
		{
			Debug.LogError("More than one instance of TwitchIntegration is available... FIX THIS!");
		}
	}

	public void Dispose()
	{
		if (_sInstance == this)
		{
			_sInstance = null;
		}
	}

	public void Init()
	{
		IRC twitchClient = TwitchClient;
		if ((object)twitchClient != null && ((UnityEngine.Object)twitchClient).m_CachedPtr != (IntPtr)0)
		{
			IRC twitchClient2 = TwitchClient;
			twitchClient2.channel = _username;
			IRC twitchClient3 = TwitchClient;
			twitchClient3.Connect();
		}
	}

	public void Kill()
	{
		IRC twitchClient = TwitchClient;
		if ((object)twitchClient == null || ((UnityEngine.Object)twitchClient).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		IRC twitchClient2 = TwitchClient;
		if (twitchClient2.connection != null)
		{
			Lexone.UnityTwitchChat.TwitchConnection connection = twitchClient2.connection;
			if (!connection.disconnectCalled)
			{
				IEnumerator routine = twitchClient2.NonBlockingDisconnect();
				Coroutine coroutine = twitchClient2.StartCoroutine(routine);
			}
		}
	}

	public bool IsTwitchOn()
	{
		//IL_00bc: Expected I4, but got O
		string username = _username;
		if (_username != null && username._stringLength > 0)
		{
			if (MultiplayerManager.s_instance != null)
			{
				int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
				if (playerCount > 1)
				{
					return false;
				}
				bool isOnlineMultiplayer = MultiplayerManager.s_instance.IsOnlineMultiplayer;
				return (byte)((isOnlineMultiplayer ? 1u : 0u) ^ 1u) != 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool IsTwitchWorking()
	{
		//IL_015c: Expected I4, but got O
		IRC twitchClient = TwitchClient;
		if ((object)twitchClient != null && ((UnityEngine.Object)twitchClient).m_CachedPtr != (IntPtr)0)
		{
			IRC twitchClient2 = TwitchClient;
			if ((object)twitchClient2 == null)
			{
				goto IL_014e;
			}
			string channel = twitchClient2.channel;
			if (twitchClient2.channel != null && channel._stringLength > 0 && twitchClient2.connection != null)
			{
				Lexone.UnityTwitchChat.TwitchConnection connection = twitchClient2.connection;
				TcpClient tcpClient = connection._003CtcpClient_003Ek__BackingField;
				if (connection._003CtcpClient_003Ek__BackingField != null)
				{
					Socket clientSocket = tcpClient.m_ClientSocket;
					if (tcpClient.m_ClientSocket != null)
					{
						return clientSocket.is_connected;
					}
					goto IL_014e;
				}
			}
		}
		return false;
		IL_014e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
