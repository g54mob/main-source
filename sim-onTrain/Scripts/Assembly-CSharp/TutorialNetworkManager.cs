using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class TutorialNetworkManager : NetworkBehaviour
{
	public readonly SyncDictionary<string, bool> commonTasksCompletion = new SyncDictionary<string, bool>();

	public readonly SyncDictionary<string, int> commonTasksProgress = new SyncDictionary<string, int>();

	public static TutorialNetworkManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		Debug.Log("TutorialNetworkManager: Server started");
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		commonTasksCompletion.Callback += OnCommonTaskCompletionChanged;
		commonTasksProgress.Callback += OnCommonTaskProgressChanged;
		if (!base.isServer)
		{
			SyncExistingCommonTasks();
		}
		Debug.Log("TutorialNetworkManager: Client started");
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		commonTasksCompletion.Callback -= OnCommonTaskCompletionChanged;
		commonTasksProgress.Callback -= OnCommonTaskProgressChanged;
	}

	private void OnCommonTaskCompletionChanged(SyncIDictionary<string, bool>.Operation op, string key, bool value)
	{
		if ((op != SyncIDictionary<string, bool>.Operation.OP_ADD && (uint)op != 3u) || !value)
		{
			return;
		}
		string[] array = key.Split('_');
		if (array.Length == 2 && int.TryParse(array[0], out var result) && int.TryParse(array[1], out var result2))
		{
			Debug.Log($"TutorialNetworkManager: Common task completed - Group {result}, Task {result2}");
			if (TSPlayerTutorialManager.Instance != null)
			{
				TSPlayerTutorialManager.Instance.CompleteCommonTask(result, result2);
			}
		}
	}

	private void OnCommonTaskProgressChanged(SyncIDictionary<string, int>.Operation op, string key, int value)
	{
		if (op != SyncIDictionary<string, int>.Operation.OP_ADD && (uint)op != 3u)
		{
			return;
		}
		string[] array = key.Split('_');
		if (array.Length == 2 && int.TryParse(array[0], out var result) && int.TryParse(array[1], out var result2))
		{
			Debug.Log($"TutorialNetworkManager: Common task progress updated - Group {result}, Task {result2}, Progress {value}");
			if (TSPlayerTutorialManager.Instance != null)
			{
				TSPlayerTutorialManager.Instance.UpdateCommonTaskProgress(result, result2, value);
			}
		}
	}

	private void SyncExistingCommonTasks()
	{
		foreach (KeyValuePair<string, bool> item in commonTasksCompletion)
		{
			if (item.Value)
			{
				string[] array = item.Key.Split('_');
				if (array.Length == 2 && int.TryParse(array[0], out var result) && int.TryParse(array[1], out var result2) && TSPlayerTutorialManager.Instance != null)
				{
					TSPlayerTutorialManager.Instance.CompleteCommonTask(result, result2);
				}
			}
		}
		foreach (KeyValuePair<string, int> item2 in commonTasksProgress)
		{
			string[] array2 = item2.Key.Split('_');
			if (array2.Length == 2 && int.TryParse(array2[0], out var result3) && int.TryParse(array2[1], out var result4) && TSPlayerTutorialManager.Instance != null)
			{
				TSPlayerTutorialManager.Instance.UpdateCommonTaskProgress(result3, result4, item2.Value);
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdCompleteCommonTask(int groupIndex, int taskIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(groupIndex);
		writer.WriteInt(taskIndex);
		SendCommandInternal("System.Void TutorialNetworkManager::CmdCompleteCommonTask(System.Int32,System.Int32)", -124800669, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdUpdateCommonTaskProgress(int groupIndex, int taskIndex, int progress)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(groupIndex);
		writer.WriteInt(taskIndex);
		writer.WriteInt(progress);
		SendCommandInternal("System.Void TutorialNetworkManager::CmdUpdateCommonTaskProgress(System.Int32,System.Int32,System.Int32)", -312699535, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public bool IsCommonTaskCompleted(int groupIndex, int taskIndex)
	{
		string text = $"{groupIndex}_{taskIndex}";
		if (commonTasksCompletion.ContainsKey(text))
		{
			return commonTasksCompletion[text];
		}
		return false;
	}

	public int GetCommonTaskProgress(int groupIndex, int taskIndex)
	{
		string text = $"{groupIndex}_{taskIndex}";
		if (!commonTasksProgress.ContainsKey(text))
		{
			return 0;
		}
		return commonTasksProgress[text];
	}

	[Server]
	public void LoadCommonTaskStates(Dictionary<string, bool> completionStates, Dictionary<string, int> progressStates)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialNetworkManager::LoadCommonTaskStates(System.Collections.Generic.Dictionary`2<System.String,System.Boolean>,System.Collections.Generic.Dictionary`2<System.String,System.Int32>)' called when server was not active");
		}
		else
		{
			if (!base.isServer)
			{
				return;
			}
			foreach (KeyValuePair<string, bool> completionState in completionStates)
			{
				commonTasksCompletion[completionState.Key] = completionState.Value;
			}
			foreach (KeyValuePair<string, int> progressState in progressStates)
			{
				commonTasksProgress[progressState.Key] = progressState.Value;
			}
			Debug.Log($"TutorialNetworkManager [Server]: Loaded {completionStates.Count} common task completion states and {progressStates.Count} progress states from save");
		}
	}

	[Server]
	public void GetCommonTaskStatesForSave(out Dictionary<string, bool> completionStates, out Dictionary<string, int> progressStates)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialNetworkManager::GetCommonTaskStatesForSave(System.Collections.Generic.Dictionary`2<System.String,System.Boolean>&,System.Collections.Generic.Dictionary`2<System.String,System.Int32>&)' called when server was not active");
			completionStates = null;
			progressStates = null;
		}
		else
		{
			completionStates = new Dictionary<string, bool>(commonTasksCompletion);
			progressStates = new Dictionary<string, int>(commonTasksProgress);
		}
	}

	public TutorialNetworkManager()
	{
		InitSyncObject(commonTasksCompletion);
		InitSyncObject(commonTasksProgress);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdCompleteCommonTask__Int32__Int32(int groupIndex, int taskIndex)
	{
		string text = $"{groupIndex}_{taskIndex}";
		if (!commonTasksCompletion.ContainsKey(text) || !commonTasksCompletion[text])
		{
			commonTasksCompletion[text] = true;
			Debug.Log($"TutorialNetworkManager [Server]: Common task completed by a player - Group {groupIndex}, Task {taskIndex}");
		}
	}

	protected static void InvokeUserCode_CmdCompleteCommonTask__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCompleteCommonTask called on client.");
		}
		else
		{
			((TutorialNetworkManager)obj).UserCode_CmdCompleteCommonTask__Int32__Int32(reader.ReadInt(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdUpdateCommonTaskProgress__Int32__Int32__Int32(int groupIndex, int taskIndex, int progress)
	{
		string text = $"{groupIndex}_{taskIndex}";
		if (!commonTasksProgress.ContainsKey(text) || commonTasksProgress[text] < progress)
		{
			commonTasksProgress[text] = progress;
			Debug.Log($"TutorialNetworkManager [Server]: Common task progress updated - Group {groupIndex}, Task {taskIndex}, Progress {progress}");
		}
	}

	protected static void InvokeUserCode_CmdUpdateCommonTaskProgress__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateCommonTaskProgress called on client.");
		}
		else
		{
			((TutorialNetworkManager)obj).UserCode_CmdUpdateCommonTaskProgress__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
		}
	}

	static TutorialNetworkManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TutorialNetworkManager), "System.Void TutorialNetworkManager::CmdCompleteCommonTask(System.Int32,System.Int32)", InvokeUserCode_CmdCompleteCommonTask__Int32__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TutorialNetworkManager), "System.Void TutorialNetworkManager::CmdUpdateCommonTaskProgress(System.Int32,System.Int32,System.Int32)", InvokeUserCode_CmdUpdateCommonTaskProgress__Int32__Int32__Int32, requiresAuthority: false);
	}
}
