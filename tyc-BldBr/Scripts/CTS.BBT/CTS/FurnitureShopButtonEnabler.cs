using System;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class FurnitureShopButtonEnabler : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroupController _canvasGroupController;

		private void Start()
		{
			ShowModesMenu(MonoSingleton<FurnitureShop>.Instance.ObjectLock.IsUnlocked());
			FurnitureShop instance = MonoSingleton<FurnitureShop>.Instance;
			instance.LockStateChanged = (Action<bool>)Delegate.Combine(instance.LockStateChanged, new Action<bool>(ShowModesMenu));
		}

		private void OnDisable()
		{
			if (MonoSingleton<FurnitureShop>.InstanceExists())
			{
				FurnitureShop instance = MonoSingleton<FurnitureShop>.Instance;
				instance.LockStateChanged = (Action<bool>)Delegate.Remove(instance.LockStateChanged, new Action<bool>(ShowModesMenu));
			}
		}

		private void ShowModesMenu(bool p_value)
		{
			_canvasGroupController.ShowCanvasGroup(p_value);
		}
	}
}
