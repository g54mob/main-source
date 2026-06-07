using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using JetBrains.Annotations;
using UnityEngine;

namespace Dissonance.Integrations.FMOD_Playback
{
	internal class FMODChannelGroupLocks : MonoBehaviour
	{
		public struct Handle
		{
			public readonly bool IsValid;

			public readonly GUID GUID;

			public readonly string Name;

			public readonly Bus Bus;

			public readonly ChannelGroup ChannelGroup;

			internal Handle(GUID guid, string name, Bus bus, ChannelGroup channelGroup)
			{
				IsValid = true;
				GUID = guid;
				Name = name;
				Bus = bus;
				ChannelGroup = channelGroup;
			}
		}

		private static readonly Log Log = Logs.Create(LogCategory.Playback, "FMODChannelGroupLocks");

		private static FMODChannelGroupLocks _instance;

		private readonly ConcurrentDictionary<GUID, int> _lockCounter = new ConcurrentDictionary<GUID, int>();

		public static FMODChannelGroupLocks Instance
		{
			get
			{
				if (_instance == null)
				{
					GameObject obj = new GameObject("FMODChannelGroupLocks Singleton");
					obj.hideFlags = HideFlags.HideAndDontSave;
					obj.AddComponent<FMODChannelGroupLocks>();
					_instance = obj.GetComponent<FMODChannelGroupLocks>();
				}
				return _instance;
			}
		}

		[UsedImplicitly]
		private void Awake()
		{
			if (_instance != null && _instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else
			{
				_instance = this;
			}
		}

		[UsedImplicitly]
		private void OnDestroy()
		{
			if (this == _instance)
			{
				_instance = null;
			}
			ReleaseAll();
		}

		private static bool Check(RESULT result, string message)
		{
			if (result != RESULT.OK)
			{
				Log.Warn(message + $" FMOD Result: {result}");
				return false;
			}
			return true;
		}

		public Handle? LockBus(string busID)
		{
			if (string.IsNullOrEmpty(busID))
			{
				return null;
			}
			GUID id;
			try
			{
				id = GUID.Parse(busID);
			}
			catch (FormatException)
			{
				return null;
			}
			if (!Check(RuntimeManager.StudioSystem.getBusByID(id, out var bus), "Failed to get output bus `" + busID + "` from FMOD."))
			{
				return null;
			}
			if (!Check(bus.getID(out var id2), "Failed to get bus ID"))
			{
				return null;
			}
			RESULT rESULT = bus.lockChannelGroup();
			if (rESULT != RESULT.OK && rESULT != RESULT.ERR_ALREADY_LOCKED && !Check(bus.lockChannelGroup(), "Failed to lock bus `" + busID + "` channel group."))
			{
				return null;
			}
			_lockCounter.AddOrUpdate(id2, 1, IncrementLockCount);
			if (!Check(RuntimeManager.StudioSystem.flushCommands(), "Failed to flush FMOD commands."))
			{
				if (_lockCounter.AddOrUpdate(id2, 0, DecrementLockCount) == 0)
				{
					bus.unlockChannelGroup();
				}
				return null;
			}
			if (!Check(bus.getChannelGroup(out var group), "Failed to get bus `" + busID + "` channel group."))
			{
				if (_lockCounter.AddOrUpdate(id2, 0, DecrementLockCount) == 0)
				{
					bus.unlockChannelGroup();
				}
				return null;
			}
			return new Handle(id2, busID, bus, group);
		}

		public void UnlockBus(Handle handle)
		{
			if (handle.IsValid && _lockCounter.AddOrUpdate(handle.GUID, 0, DecrementLockCount) == 0)
			{
				handle.Bus.unlockChannelGroup();
			}
		}

		private void ReleaseAll()
		{
			List<KeyValuePair<GUID, int>> list = _lockCounter.ToList();
			_lockCounter.Clear();
			foreach (KeyValuePair<GUID, int> item in list)
			{
				if (Check(RuntimeManager.StudioSystem.getBusByID(item.Key, out var bus), $"Failed to get Bus by ID `{bus}`"))
				{
					bus.unlockChannelGroup();
				}
			}
		}

		private static int DecrementLockCount(GUID id, int count)
		{
			return count - 1;
		}

		private static int IncrementLockCount(GUID _, int count)
		{
			return count + 1;
		}
	}
}
