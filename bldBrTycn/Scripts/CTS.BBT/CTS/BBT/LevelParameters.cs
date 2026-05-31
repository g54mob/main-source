using System;
using System.Collections.Generic;
using CTS.AI;
using CTS.Core;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT
{
	[DefaultExecutionOrder(1)]
	public class LevelParameters : CTSSingleton<LevelParameters>, ILockable
	{
		[SerializeField]
		private SerializableDictionary<StockItemSO, int> _baseStorage = new SerializableDictionary<StockItemSO, int>();

		[field: SerializeField]
		[field: Inject(false)]
		public BarFurnitures Furnitures { get; private set; }

		[field: SerializeField]
		public MoveTarget ExitTarget { get; private set; }

		[field: SerializeField]
		[field: Inject(false)]
		public CooldownManager GlobalCooldowns { get; private set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public bool UseBaseStorage { get; set; } = true;

		public bool IsOpen { get; private set; }

		public static event Action<bool> OnBarOpenedStatusChanged;

		[Button(null, EButtonEnableMode.Always)]
		private void OpenBar()
		{
			SetOpened(p_value: true);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void CloseBar()
		{
			SetOpened(p_value: false);
		}

		protected override void SingletonAwake()
		{
			UnlockingManager.ClearAll();
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is FreemodeProfile)
			{
				UnlockingManager.AddUnlockKey((EUnlockKey)(-1));
			}
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void Start()
		{
			if (!UseBaseStorage)
			{
				return;
			}
			foreach (KeyValuePair<StockItemSO, int> item in _baseStorage)
			{
				Stocks.ForceAdd(new StockStack(item.Key, item.Value, 5f));
			}
		}

		public void SetOpened(bool p_value)
		{
			if (IsOpen != p_value && (!p_value || !ObjectLock.IsLocked()))
			{
				IsOpen = p_value;
				LevelParameters.OnBarOpenedStatusChanged?.Invoke(IsOpen);
			}
		}

		public void ToggleOpenStatus()
		{
			SetOpened(!IsOpen);
		}

		void ILockable.OnLocked()
		{
			SetOpened(p_value: false);
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
