using System;
using System.Linq;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class UnlockingManager : CTSSingleton<UnlockingManager>
	{
		[SerializeField]
		private EUnlockKey _defaultKeys = EUnlockKey.CheapBarPackage;

		public static EUnlockKey UnlockKey { get; private set; }

		public static event Action<EUnlockKey> OnNewKeyAdded;

		public static void AddUnlockKey(EUnlockKey key)
		{
			EUnlockKey eUnlockKey = UnlockKey | key;
			if (UnlockKey != eUnlockKey)
			{
				UnlockKey = eUnlockKey;
				UnlockingManager.OnNewKeyAdded?.Invoke(key);
			}
		}

		public static void RemoveUnlockKey(EUnlockKey key)
		{
			EUnlockKey eUnlockKey = UnlockKey & ~key;
			if (UnlockKey != eUnlockKey)
			{
				UnlockKey = eUnlockKey;
				UnlockingManager.OnNewKeyAdded?.Invoke(key);
			}
		}

		public static bool ContainKey(EUnlockKey key)
		{
			if (UnlockKey.HasFlagNonAlloc(key))
			{
				return key != (EUnlockKey)0;
			}
			return false;
		}

		public static void ClearAll()
		{
			if (CTSSingleton<UnlockingManager>.InstanceExists())
			{
				UnlockKey = CTSSingleton<UnlockingManager>.Instance._defaultKeys;
			}
			else
			{
				UnlockKey = (EUnlockKey)0;
			}
			UnlockingManager.OnNewKeyAdded?.Invoke(UnlockKey);
		}

		[Button(null, EButtonEnableMode.Always)]
		public static void UnlockAll()
		{
			EUnlockKey eUnlockKey = (EUnlockKey)Enum.GetValues(typeof(EUnlockKey)).Cast<int>().Sum();
			if (UnlockKey != eUnlockKey)
			{
				UnlockKey = eUnlockKey;
				UnlockingManager.OnNewKeyAdded?.Invoke(UnlockKey);
			}
		}

		protected override void SingletonAwake()
		{
			ClearAll();
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
