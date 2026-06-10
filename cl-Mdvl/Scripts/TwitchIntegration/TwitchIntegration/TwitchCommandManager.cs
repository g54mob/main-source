using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using FoxyVoxel.Logging;
using UnityEngine;

namespace TwitchIntegration
{
	public class TwitchCommandManager : MonoBehaviour
	{
		private static TwitchSettings settings;

		private static Dictionary<string, MethodInfo> methodsDict;

		private static Dictionary<MethodInfo, ParameterInfo[]> methodParameters;

		private static Dictionary<MethodInfo, List<TwitchMonoBehaviour>> methodBehaviours;

		private static Dictionary<string, List<MethodInfo>> typeMethods;

		private static Dictionary<string, string> aliasToCommandName;

		private static TcpClient twitchClient;

		private static StreamReader streamReader;

		private static StreamWriter streamWriter;

		private static bool isConnecting;

		private static bool hadConnectionError;

		private static bool hadTimeoutError;

		private static float timeUntilTimeout;

		private static string channelName;

		private const float Timeout = 10f;

		private static ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();

		private static CancellationTokenSource cts;

		internal bool IsEnabled { get; set; } = true;

		internal static bool IsInitialized { get; private set; }

		internal static bool IsConnected
		{
			get
			{
				if (twitchClient != null)
				{
					return twitchClient.Connected;
				}
				return false;
			}
		}

		internal TwitchCommand[] GetAllAvailableCommands => settings.commandList.Where((TwitchCommand x) => x.enabled).ToArray();

		internal List<string> CommandsOnCooldown { get; private set; }

		internal static void AddBehaviour(TwitchMonoBehaviour behaviour)
		{
			if (!IsInitialized)
			{
				return;
			}
			string key = behaviour.GetType().Name;
			if (!typeMethods.ContainsKey(key))
			{
				return;
			}
			typeMethods[key].ForEach(delegate(MethodInfo method)
			{
				if (methodBehaviours.ContainsKey(method))
				{
					methodBehaviours[method].Add(behaviour);
				}
				else
				{
					methodBehaviours.Add(method, new List<TwitchMonoBehaviour> { behaviour });
				}
			});
		}

		internal static void RemoveBehaviour(TwitchMonoBehaviour behaviour)
		{
			if (!IsInitialized)
			{
				return;
			}
			string key = behaviour.GetType().Name;
			if (!typeMethods.ContainsKey(key))
			{
				return;
			}
			typeMethods[key].ForEach(delegate(MethodInfo method)
			{
				if (methodBehaviours.ContainsKey(method))
				{
					methodBehaviours[method].Remove(behaviour);
				}
			});
		}

		[ContextMenu("Init")]
		public void Init()
		{
			Initialize();
		}

		internal static void Initialize()
		{
			if (IsInitialized)
			{
				Log("Twitch commands are already initialized.", "yellow");
				return;
			}
			Log("Initializing Twitch client...", "yellow");
			methodsDict = new Dictionary<string, MethodInfo>();
			methodParameters = new Dictionary<MethodInfo, ParameterInfo[]>();
			methodBehaviours = new Dictionary<MethodInfo, List<TwitchMonoBehaviour>>();
			typeMethods = new Dictionary<string, List<MethodInfo>>();
			aliasToCommandName = new Dictionary<string, string>();
			foreach (MethodInfo item in from x in (from x in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly x) => x.GetTypes())
					where x.IsClass && typeof(TwitchMonoBehaviour).IsAssignableFrom(x)
					select x).SelectMany((Type x) => x.GetMethods())
				where x.GetCustomAttributes(typeof(TwitchCommandAttribute), inherit: false).FirstOrDefault() != null
				select x)
			{
				TwitchCommandAttribute customAttribute = item.GetCustomAttribute<TwitchCommandAttribute>();
				methodsDict.Add(customAttribute.Name, item);
				if (typeMethods.ContainsKey(item.DeclaringType.Name))
				{
					typeMethods[item.DeclaringType.Name].Add(item);
				}
				else
				{
					typeMethods.Add(item.DeclaringType.Name, new List<MethodInfo> { item });
				}
				string[] aliases = customAttribute.Aliases;
				foreach (string key in aliases)
				{
					aliasToCommandName.Add(key, customAttribute.Name);
				}
				methodParameters[item] = item.GetParameters();
			}
			IsInitialized = true;
			Log("Initialized! Attempting to connect...", "yellow");
			Connect();
		}

		internal static void Connect()
		{
			if (isConnecting)
			{
				return;
			}
			isConnecting = true;
			timeUntilTimeout = 10f;
			ClearStreams();
			if (!PlayerPrefs.HasKey("TwitchAuth__OAuthToken"))
			{
				return;
			}
			OAuth oAuth = JsonUtility.FromJson<OAuth>(PlayerPrefs.GetString("TwitchAuth__OAuthToken"));
			string username = PlayerPrefs.GetString("TwitchAuth__Username");
			channelName = PlayerPrefs.GetString("TwitchAuth__ChannelName");
			Thread thread = new Thread((ThreadStart)delegate
			{
				try
				{
					if (hadTimeoutError)
					{
						twitchClient = new TcpClient("irc.chat.twitch.tv", 80);
						hadTimeoutError = false;
					}
					else
					{
						twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
					}
					streamReader = new StreamReader(twitchClient.GetStream());
					streamWriter = new StreamWriter(twitchClient.GetStream());
					streamWriter.WriteLine("PASS oauth:" + oAuth.accessToken);
					streamWriter.WriteLine("NICK " + username.ToLower());
					streamWriter.WriteLine("JOIN #" + channelName.ToLower());
					streamWriter.WriteLine("CAP REQ :twitch.tv/tags");
					streamWriter.Flush();
					cts?.Cancel();
					cts = new CancellationTokenSource();
					Task.Run(() => ReadChatLoop(cts.Token), cts.Token);
				}
				catch (Exception)
				{
					hadTimeoutError = true;
					hadConnectionError = true;
					isConnecting = false;
				}
			});
			thread.IsBackground = true;
			thread.Start();
		}

		internal static void SendChatMessage(string message)
		{
			if (streamWriter == null)
			{
				return;
			}
			try
			{
				streamWriter.WriteLine("PRIVMSG #" + channelName.ToLower() + " :" + message);
				streamWriter.Flush();
				TwitchManager.OnMessageReceived(new TwitchUser
				{
					displayname = channelName
				}, message);
			}
			catch (Exception ex)
			{
				Log("Send failed: " + ex.Message, "red");
				hadConnectionError = true;
			}
		}

		private static async Task ReadChatLoop(CancellationToken cancellationToken)
		{
			while (twitchClient != null && twitchClient.Connected && !cancellationToken.IsCancellationRequested)
			{
				try
				{
					string text = await streamReader.ReadLineAsync();
					if (text != null)
					{
						messageQueue.Enqueue(text);
					}
				}
				catch (Exception ex)
				{
					if (!cancellationToken.IsCancellationRequested)
					{
						FoxyVoxel.Logging.Log.Error(ex.ToString(), "C:\\GIT\\dev\\Assets\\Externals\\TwitchChatInteractions\\Scripts\\Runtime\\Twitch\\TwitchCommandManager.cs");
					}
					hadConnectionError = true;
					break;
				}
			}
		}

		private void ReadChat()
		{
			int num = 0;
			string result;
			while (messageQueue.TryDequeue(out result) && num < 50)
			{
				num++;
				if (result.StartsWith("PING "))
				{
					try
					{
						streamWriter.WriteLine("PONG " + result.Substring(5));
						streamWriter.Flush();
					}
					catch (Exception)
					{
						hadConnectionError = true;
						break;
					}
				}
				if (result.Contains("PRIVMSG"))
				{
					OnMessageReceived(result);
				}
				else if (result.Contains("JOIN"))
				{
					OnJoinedToChat();
				}
			}
		}

		private void OnMessageReceived(string message)
		{
			string text = message.Split(new char[1] { ':' }, 2, StringSplitOptions.None)[1];
			text = text.Substring(text.IndexOf(':', 1) + 1);
			List<string> list = message.Replace("-", "").Substring(1).Split(';')
				.ToList();
			list[list.Count - 1] = list[list.Count - 1].Replace(text, "");
			string text2 = "{";
			for (int i = 0; i < list.Count; i++)
			{
				string[] array = list[i].Split(new char[1] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length >= 2)
				{
					if (!array[1].All(char.IsDigit))
					{
						array[1] = "\"" + array[1] + "\"";
					}
					text2 = text2 + "\"" + array[0] + "\":" + array[1] + ((i == list.Count - 1) ? ' ' : ',');
				}
			}
			text2 += "}";
			TwitchUser user;
			try
			{
				user = JsonUtility.FromJson<TwitchUser>(text2);
			}
			catch (Exception)
			{
				return;
			}
			string text3 = user.displayname;
			if (!string.IsNullOrEmpty(user.color))
			{
				text3 = "<color=" + user.color + ">" + text3 + "</color>";
			}
			Log("Twitch chat - " + text3 + " : " + text, "white");
			TwitchManager.OnMessageReceived(user, text);
			if (!text.StartsWith(settings.commandPrefix))
			{
				return;
			}
			int num = text.IndexOf(' ');
			string baseCommand = ((num < 0) ? text.Substring(1) : text.Substring(1, num - 1));
			string[] args = ((num < 0) ? new string[0] : text.Substring(num + 1).Split(' '));
			if (aliasToCommandName.TryGetValue(baseCommand, out var value))
			{
				baseCommand = value;
			}
			if (!methodsDict.ContainsKey(baseCommand))
			{
				return;
			}
			TwitchCommand twitchCommand = settings.commandList.Find((TwitchCommand x) => x.name == baseCommand);
			if (!twitchCommand.enabled)
			{
				return;
			}
			if (settings.commandsMode == TwitchCommandsMode.Cooldown)
			{
				if (CommandsOnCooldown.Contains(baseCommand))
				{
					return;
				}
				CommandsOnCooldown.Add(baseCommand);
				StartCoroutine(CooldownCoroutine(baseCommand, twitchCommand.cooldown));
			}
			TwitchManager.OnCommandReceived(user, twitchCommand);
			CallCommand(baseCommand, user, args);
		}

		private static void OnJoinedToChat()
		{
			Log("Twitch client successfully connected to the chat!", "green");
			TwitchManager.OnJoinedToChat();
			isConnecting = false;
		}

		private void CallCommand(string commandName, TwitchUser user, IReadOnlyList<string> args)
		{
			MethodInfo method = methodsDict[commandName];
			ParameterInfo[] array = methodParameters[method];
			object[] filteredArgs = new object[array.Length];
			int num = 0;
			if (array.Length != 0 && array[0].ParameterType == typeof(TwitchUser))
			{
				filteredArgs[0] = user;
				num = 1;
			}
			if (array.Length - num != args.Count)
			{
				return;
			}
			for (int i = 0; i < args.Count; i++)
			{
				object obj;
				if (array[i + num].ParameterType == typeof(int))
				{
					obj = int.Parse(args[i]);
				}
				else if (array[i + num].ParameterType == typeof(float))
				{
					obj = float.Parse(args[i]);
				}
				else if (array[i + num].ParameterType == typeof(bool))
				{
					obj = bool.Parse(args[i]);
				}
				else
				{
					if (!(array[i + num].ParameterType == typeof(string)))
					{
						return;
					}
					obj = args[i];
				}
				filteredArgs[i + num] = obj;
			}
			Log("Calling command: " + commandName, "white");
			if (methodBehaviours.ContainsKey(method))
			{
				methodBehaviours[method].ForEach(delegate(TwitchMonoBehaviour behaviour)
				{
					method.Invoke(behaviour, filteredArgs);
				});
			}
		}

		private IEnumerator CooldownCoroutine(string command, float time)
		{
			yield return new WaitForSeconds(time);
			CommandsOnCooldown.Remove(command);
		}

		private static void Log(string message, string color)
		{
			if (settings.isDebugMode)
			{
				MonoBehaviour.print("<color=" + color + ">" + message + "</color>");
			}
		}

		private void Awake()
		{
			CommandsOnCooldown = new List<string>();
			settings = Resources.Load<TwitchSettings>("TwitchSettings");
			if (settings.initializeOnAwake)
			{
				StartCoroutine(WaitForAuthentication());
			}
		}

		private static IEnumerator WaitForAuthentication()
		{
			yield return new WaitUntil(() => TwitchManager.IsAuthenticated);
			if (!IsInitialized)
			{
				Initialize();
			}
		}

		private void OnDestroy()
		{
			ClearStreams();
		}

		private static void ClearStreams()
		{
			cts?.Cancel();
			cts = null;
			streamReader?.Close();
			streamReader?.Dispose();
			streamReader = null;
			streamWriter?.Close();
			streamWriter?.Dispose();
			streamWriter = null;
			twitchClient?.Close();
			twitchClient?.Dispose();
			twitchClient = null;
		}

		private void Update()
		{
			if (hadConnectionError)
			{
				hadConnectionError = false;
				ClearStreams();
			}
			if (IsInitialized && IsConnected)
			{
				ReadChat();
			}
		}

		private void FixedUpdate()
		{
			if (!IsInitialized || IsConnected)
			{
				return;
			}
			timeUntilTimeout -= Time.fixedDeltaTime;
			if (!(timeUntilTimeout > 0f))
			{
				if (isConnecting)
				{
					Log("Connection timed out, retrying... If several attempts fail, refresh your OAuth token", "red");
					hadTimeoutError = true;
					isConnecting = false;
				}
				TwitchManager.OnFailedToConnect();
				Connect();
			}
		}
	}
}
