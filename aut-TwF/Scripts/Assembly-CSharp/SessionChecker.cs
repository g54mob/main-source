using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SessionChecker : MonoBehaviour
{
	public enum ESessionState
	{
		Running = 0,
		CleanExit = 1
	}

	[Serializable]
	public class SessionMarker
	{
		public ESessionState state;

		public ulong lastUptimeMs;

		public bool crashFlag;

		public bool wasInGame;

		public SessionMarker()
		{
		}

		public SessionMarker(ESessionState state, ulong lastUptimeMs, bool crashFlag, bool wasInGame)
		{
			this.state = state;
			this.lastUptimeMs = lastUptimeMs;
			this.crashFlag = crashFlag;
			this.wasInGame = wasInGame;
		}
	}

	private volatile bool isHeartbeatStopped;

	private Thread heartbeatThread;

	private readonly object securityLock = new object();

	private SessionMarker currentSessionMarker;

	private static string MarkerPath => Path.Combine(Application.persistentDataPath, "session.json");

	private void Start()
	{
		SessionMarker sessionData = LoadMarker();
		if (CheckHasToDeleteGame(sessionData))
		{
			SaveSystem.instance.DeleteSavedGame();
		}
		currentSessionMarker = new SessionMarker(ESessionState.Running, PlatformUptimeMs(), crashFlag: false, wasInGame: false);
		SaveMarker(currentSessionMarker);
		Application.wantsToQuit += OnWantsToQuit;
		Application.quitting += OnQuitting;
		Application.logMessageReceivedThreaded += OnLogMessageThreaded;
		AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
		StartHeartbeat();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if (currentSessionMarker == null)
		{
			currentSessionMarker = LoadMarker() ?? new SessionMarker();
		}
		if (scene.buildIndex == 0)
		{
			currentSessionMarker.wasInGame = false;
			SaveMarker(currentSessionMarker);
		}
		else if (scene.buildIndex >= 3)
		{
			currentSessionMarker.wasInGame = true;
			SaveMarker(currentSessionMarker);
		}
	}

	private void OnDestroy()
	{
		isHeartbeatStopped = true;
		try
		{
			heartbeatThread?.Join(50);
		}
		catch
		{
		}
		Application.wantsToQuit -= OnWantsToQuit;
		Application.quitting -= OnQuitting;
		Application.logMessageReceivedThreaded -= OnLogMessageThreaded;
		AppDomain.CurrentDomain.UnhandledException -= OnUnhandledException;
	}

	private bool OnWantsToQuit()
	{
		MarkCleanExit();
		return true;
	}

	private void OnQuitting()
	{
		MarkCleanExit();
	}

	private void MarkCleanExit()
	{
		isHeartbeatStopped = true;
		lock (securityLock)
		{
			if (currentSessionMarker == null)
			{
				currentSessionMarker = new SessionMarker();
			}
			currentSessionMarker.state = ESessionState.CleanExit;
			currentSessionMarker.lastUptimeMs = PlatformUptimeMs();
			SaveMarker(currentSessionMarker);
		}
	}

	private void StartHeartbeat()
	{
		isHeartbeatStopped = false;
		heartbeatThread = new Thread((ThreadStart)delegate
		{
			while (!isHeartbeatStopped)
			{
				try
				{
					lock (securityLock)
					{
						if (currentSessionMarker != null)
						{
							currentSessionMarker.lastUptimeMs = PlatformUptimeMs();
							SaveMarker(currentSessionMarker);
						}
					}
				}
				catch
				{
				}
				Thread.Sleep(2000);
			}
		});
		heartbeatThread.IsBackground = true;
		heartbeatThread.Name = "SessionGuardHeartbeat";
		heartbeatThread.Start();
	}

	private bool CheckHasToDeleteGame(SessionMarker sessionData)
	{
		if (sessionData == null)
		{
			return false;
		}
		if (!sessionData.wasInGame)
		{
			return false;
		}
		if (sessionData.state == ESessionState.CleanExit)
		{
			return true;
		}
		if (RebootDetected(sessionData))
		{
			return false;
		}
		if (sessionData.crashFlag)
		{
			return false;
		}
		Debug.Log("Asumimos kill voluntario");
		return true;
	}

	private static bool RebootDetected(SessionMarker prev)
	{
		ulong uptimeMs = GetUptimeMs();
		if (prev.lastUptimeMs != 0)
		{
			return uptimeMs + 5000 < prev.lastUptimeMs;
		}
		return false;
	}

	private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		SetCrashFlagBestEffort();
	}

	private void OnLogMessageThreaded(string condition, string stackTrace, LogType type)
	{
		if ((type == LogType.Exception || type == LogType.Error || type == LogType.Assert) && (LooksLikeCrash(condition) || LooksLikeCrash(stackTrace)))
		{
			SetCrashFlagBestEffort();
		}
	}

	private static bool LooksLikeCrash(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return false;
		}
		if (!s.Contains("Crash!!!", StringComparison.OrdinalIgnoreCase) && !s.Contains("SIGSEGV", StringComparison.OrdinalIgnoreCase) && !s.Contains("EXC_BAD_ACCESS", StringComparison.OrdinalIgnoreCase) && !s.Contains("Access violation", StringComparison.OrdinalIgnoreCase) && !s.Contains("Stacktrace:", StringComparison.OrdinalIgnoreCase))
		{
			return s.Contains("Native Crash", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private void SetCrashFlagBestEffort()
	{
		try
		{
			lock (securityLock)
			{
				if (currentSessionMarker == null)
				{
					currentSessionMarker = LoadMarker() ?? new SessionMarker();
				}
				currentSessionMarker.crashFlag = true;
				currentSessionMarker.lastUptimeMs = PlatformUptimeMs();
				SaveMarker(currentSessionMarker);
			}
		}
		catch
		{
		}
	}

	private static SessionMarker LoadMarker()
	{
		try
		{
			if (!File.Exists(MarkerPath))
			{
				return null;
			}
			string text = File.ReadAllText(MarkerPath, Encoding.UTF8);
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}
			return JsonUtility.FromJson<SessionMarker>(text);
		}
		catch
		{
			return null;
		}
	}

	private static void SaveMarker(SessionMarker marker)
	{
		string content = JsonUtility.ToJson(marker);
		WriteAllTextAtomic(MarkerPath, content, Encoding.UTF8);
	}

	public static void WriteAllTextAtomic(string path, string content, Encoding encoding)
	{
		byte[] bytes = encoding.GetBytes(content);
		WriteAllBytesAtomic(path, bytes);
	}

	public static void WriteAllBytesAtomic(string path, byte[] data)
	{
		Directory.CreateDirectory(Path.GetDirectoryName(path) ?? ".");
		string text = path + ".tmp";
		File.WriteAllBytes(text, data);
		try
		{
			if (File.Exists(path))
			{
				TryReplace(text, path);
			}
			else
			{
				File.Move(text, path);
			}
		}
		finally
		{
			try
			{
				if (File.Exists(text))
				{
					File.Delete(text);
				}
			}
			catch
			{
			}
		}
	}

	private static void TryReplace(string srcTmp, string dst)
	{
		try
		{
			File.Replace(srcTmp, dst, null);
		}
		catch
		{
			try
			{
				if (File.Exists(dst))
				{
					File.Delete(dst);
				}
			}
			catch
			{
			}
			File.Move(srcTmp, dst);
		}
	}

	private static ulong PlatformUptimeMs()
	{
		return GetUptimeMs();
	}

	[DllImport("kernel32.dll")]
	private static extern ulong GetTickCount64();

	public static ulong GetUptimeMs()
	{
		return GetTickCount64();
	}
}
