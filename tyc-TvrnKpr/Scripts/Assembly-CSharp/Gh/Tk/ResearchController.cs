using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceIgnoreParent]
	public class ResearchController : MonoBehaviour, IPersistable
	{
		private bool _raiseResearchChangedAtEndOfFrameScheduled;

		public static event EventHandler OnResearchChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Start()
		{
		}

		public bool IsUnlocked(UnlockType unlockType, string key)
		{
			return false;
		}

		public void Unlock(UnlockType unlockType, string key, bool markAsSeen = false)
		{
		}

		private void RaiseResearchChangedAtEndOfFrame()
		{
		}

		public bool IsUnlocked(RoomZone zone)
		{
			return false;
		}

		public bool IsCraftProcessUnlocked(CraftProcess process)
		{
			return false;
		}

		public void Reset()
		{
		}
	}
}
