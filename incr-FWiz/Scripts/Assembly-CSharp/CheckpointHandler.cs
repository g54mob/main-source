using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
	public List<string> CheckpointsUnlocked;

	public Action<string> AnnounceCheckpointUnlocked;

	private Dictionary<string, Action> CallOnCheckPointUnlocked;

	private HashSet<string> CheckpointsUnlockedSet;

	public static CheckpointHandler Instance { get; private set; }

	public void Initiate()
	{
	}

	public void UnlockCheckpoint(string checkpoint)
	{
	}

	public void CallOnCheckpointUnlocked(string checkpoint, Action callback)
	{
	}

	public void CancelCallOnCheckpointUnlocked(string checkpoint, Action callback)
	{
	}

	public void UnlockCheckpoint(ICheckpoint checkpoint)
	{
	}

	public bool CheckpointUnlocked(ICheckpoint checkpoint)
	{
		return false;
	}

	public bool CheckpointUnlocked(string checkpoint)
	{
		return false;
	}

	public void CallOnCheckpointUnlocked(ICheckpoint checkpoint, Action callback)
	{
	}

	public void CancelCallOnCheckpointUnlocked(ICheckpoint checkpoint, Action callback)
	{
	}
}
