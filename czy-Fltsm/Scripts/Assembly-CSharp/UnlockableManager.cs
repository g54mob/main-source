using System;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableManager : MonoBehaviour
{
	[Serializable]
	public class PersistentData
	{
		private string[] _unlocked;

		public PersistentData(UnlockableManager unlockableManager)
		{
			if (!unlockableManager._unlocked.IsNullOrEmpty())
			{
				_unlocked = unlockableManager._unlocked.ToArray();
			}
		}

		public void Restore()
		{
			if (_instance == null)
			{
				throw new NotSupportedException("UnlockableManager cannot be restored when it is null!");
			}
			if (_unlocked != null)
			{
				_instance._unlocked = new List<string>(_unlocked);
			}
		}
	}

	private static UnlockableManager _instance;

	private List<string> _unlocked;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		_instance = this;
		_unlocked = new List<string>(128);
	}

	internal static void Unlock(Unlockable unlockable)
	{
		if (_instance != null && _instance._unlocked.AddUnique(unlockable.Guid))
		{
			new UnlockableEvent(GameEventType.UnlockableUnlocked, unlockable).Dispatch();
		}
	}

	internal static bool IsUnlocked(Unlockable unlockable)
	{
		if (_instance != null)
		{
			return _instance._unlocked.Contains(unlockable.Guid);
		}
		return false;
	}

	internal static bool IsLastUnlocked(TechTreeNode node)
	{
		if (_instance == null || node == null || _instance._unlocked.IsNullOrEmpty() || node.Unlockables.IsNullOrEmpty())
		{
			return false;
		}
		List<string> unlocked = _instance._unlocked;
		string lastUnlocked = unlocked[unlocked.Count - 1];
		return node.Unlockables.Find((ResearchUnlockable unlockable) => unlockable.Guid == lastUnlocked) != null;
	}

	public static PersistentData GetPersistentData()
	{
		if (_instance == null)
		{
			return null;
		}
		return new PersistentData(_instance);
	}
}
