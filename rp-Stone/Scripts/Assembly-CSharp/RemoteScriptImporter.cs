using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteScriptImporter : MonoBehaviour
{
	public enum Cache
	{
		Optional = 0,
		Force = 1,
		Prevent = 2
	}

	public delegate void CallbackType(UnityWebRequest.Result result, string message);

	private struct QueueEntry
	{
		public string scriptName;

		public string uri;

		public Cache cacheRule;

		public QueueEntry(string scriptName, string uri, Cache cacheRule)
		{
			this.scriptName = scriptName;
			this.uri = uri;
			this.cacheRule = cacheRule;
		}
	}

	private Dictionary<string, string> cachedResultsOptional = new Dictionary<string, string>();

	private Dictionary<string, string> cachedResultsForced = new Dictionary<string, string>();

	private Dictionary<string, List<CallbackType>> pendingCalls = new Dictionary<string, List<CallbackType>>();

	private int busyCount;

	private HashSet<string> pendingPreloadFiles = new HashSet<string>();

	private int preloadCount;

	private List<QueueEntry> coroutineQueue = new List<QueueEntry>();

	public static RemoteScriptImporter singleton { get; private set; }

	private void Awake()
	{
		singleton = this;
	}

	public bool IsBusy()
	{
		return busyCount > 0;
	}

	public bool IsPreloading()
	{
		return preloadCount > 0;
	}

	public void ClearCache()
	{
		if (!SSSystemProperties.remoteFileChachingEnabled)
		{
			cachedResultsOptional.Clear();
		}
		pendingPreloadFiles.Clear();
	}

	public void LoadRemoteScript(string scriptName, Cache cacheRule, CallbackType callback)
	{
		if (cachedResultsForced.ContainsKey(scriptName))
		{
			string message = cachedResultsForced[scriptName];
			callback(UnityWebRequest.Result.Success, message);
		}
		else if (cachedResultsOptional.ContainsKey(scriptName))
		{
			string text = cachedResultsOptional[scriptName];
			if (cacheRule == Cache.Force)
			{
				cachedResultsForced.Add(scriptName, text);
			}
			callback(UnityWebRequest.Result.Success, text);
		}
		else if (pendingCalls.ContainsKey(scriptName))
		{
			pendingCalls[scriptName].Add(callback);
		}
		else
		{
			List<CallbackType> list = new List<CallbackType>();
			pendingCalls.Add(scriptName, list);
			list.Add(callback);
			string uri = Path.Combine(SSSystemProperties.fileUrl, scriptName + ".txt");
			busyCount++;
			coroutineQueue.Add(new QueueEntry(scriptName, uri, cacheRule));
		}
	}

	private void Update()
	{
		while (coroutineQueue.Count > 0)
		{
			QueueEntry queueEntry = coroutineQueue[0];
			coroutineQueue.RemoveAt(0);
			if (queueEntry.uri.Contains("://"))
			{
				StartCoroutine(_LoadRemote(queueEntry));
			}
			else
			{
				_LoadLocal(queueEntry);
			}
		}
	}

	private IEnumerator _LoadRemote(QueueEntry queueEntry)
	{
		string scriptName = queueEntry.scriptName;
		string uri = queueEntry.uri;
		Utils.LogIfEditor("Loading remote: " + uri);
		using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
		yield return webRequest.SendWebRequest();
		busyCount--;
		string[] array = uri.Split('/');
		int num = array.Length - 1;
		switch (webRequest.result)
		{
		case UnityWebRequest.Result.ConnectionError:
		case UnityWebRequest.Result.ProtocolError:
		case UnityWebRequest.Result.DataProcessingError:
			Utils.LogErrorIfEditor(array[num] + ": Error: " + webRequest.error);
			ProcessCallbacks(scriptName, webRequest.result, webRequest.error);
			break;
		case UnityWebRequest.Result.Success:
		{
			string text = webRequest.downloadHandler.text;
			byte[] data = webRequest.downloadHandler.data;
			if (data.Length > 3 && data[0] == 239 && data[1] == 187 && data[2] == 191)
			{
				Debug.LogError("BOM detected at the start of " + scriptName + ". Please convert to UTF-8");
				text = text.Substring(1);
			}
			Utils.LogIfEditor(array[num] + " Loaded: " + text);
			switch (queueEntry.cacheRule)
			{
			case Cache.Optional:
				cachedResultsOptional.Add(scriptName, text);
				break;
			case Cache.Force:
				cachedResultsForced.Add(scriptName, text);
				break;
			}
			ProcessCallbacks(scriptName, UnityWebRequest.Result.Success, text);
			break;
		}
		}
	}

	private void _LoadLocal(QueueEntry queueEntry)
	{
		string scriptName = queueEntry.scriptName;
		string uri = queueEntry.uri;
		busyCount--;
		try
		{
			string text = File.ReadAllText(uri);
			switch (queueEntry.cacheRule)
			{
			case Cache.Optional:
				cachedResultsOptional.Add(scriptName, text);
				break;
			case Cache.Force:
				cachedResultsForced.Add(scriptName, text);
				break;
			}
			ProcessCallbacks(scriptName, UnityWebRequest.Result.Success, text);
		}
		catch
		{
			ProcessCallbacks(scriptName, UnityWebRequest.Result.DataProcessingError, "Error reading file at " + uri);
		}
	}

	private void ProcessCallbacks(string scriptName, UnityWebRequest.Result result, string message)
	{
		if (pendingCalls.ContainsKey(scriptName))
		{
			List<CallbackType> list = pendingCalls[scriptName];
			for (int i = 0; i < list.Count; i++)
			{
				list[i](result, message);
			}
			list.Clear();
			pendingCalls.Remove(scriptName);
		}
	}

	public void PreloadRemoteDependencies(string scriptSource)
	{
		if (SSSystemProperties.IsRemoteFilePath())
		{
			PreloadRemoteDependencies(scriptSource, "import");
			PreloadRemoteDependencies(scriptSource, "new");
		}
	}

	private void PreloadRemoteDependencies(string scriptSource, string commandKey)
	{
		int num = 0;
		while (true)
		{
			num = scriptSource.IndexOf(commandKey + " ", num);
			if (num < 0)
			{
				break;
			}
			num += commandKey.Length;
			int num2 = scriptSource.IndexOf('\n', num);
			if (num2 <= num)
			{
				continue;
			}
			string text = scriptSource.Substring(num, num2 - num);
			text = text.Trim();
			if (text.EndsWith("\""))
			{
				continue;
			}
			Utils.LogIfEditor("Preloading remote file = " + text);
			if (pendingPreloadFiles.Contains(text))
			{
				continue;
			}
			pendingPreloadFiles.Add(text);
			preloadCount++;
			LoadRemoteScript(text, Cache.Force, delegate(UnityWebRequest.Result result, string message)
			{
				preloadCount--;
				if (result == UnityWebRequest.Result.Success)
				{
					PreloadRemoteDependencies(message);
				}
			});
		}
	}
}
