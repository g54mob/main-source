using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(-1)]
	public class FurnitureShop : MonoSingleton<FurnitureShop>, ILockable
	{
		public static bool IsOpen { get; private set; }

		public static bool IsClosed => !IsOpen;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public static event Action<bool> FurnitureShopStatusChanged;

		public static event Action FurnitureShopOpened;

		public static event Action FurnitureShopClosed;

		private void OnEnable()
		{
			IsOpen = false;
		}

		public void ToggleBuildMode()
		{
			if (ObjectLock.IsUnlocked())
			{
				SetFurnitureShopOpen(!IsOpen);
			}
		}

		public void SetFurnitureShopOpen(bool p_value)
		{
			if (IsOpen != p_value)
			{
				IsOpen = p_value;
				FurnitureShop.FurnitureShopStatusChanged?.Invoke(p_value);
				if (IsOpen)
				{
					FurnitureShop.FurnitureShopOpened?.Invoke();
					WorldSelector.DeselectAll();
				}
				else
				{
					FurnitureShop.FurnitureShopClosed?.Invoke();
				}
			}
		}

		void ILockable.OnLocked()
		{
			if (IsOpen)
			{
				SetFurnitureShopOpen(p_value: false);
			}
		}

		void ILockable.OnUnlocked()
		{
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
			SetFurnitureShopOpen(p_value: false);
		}
	}
}
