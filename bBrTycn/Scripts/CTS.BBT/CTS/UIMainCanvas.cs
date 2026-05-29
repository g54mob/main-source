using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(-1)]
	public class UIMainCanvas : MonoSingleton<UIMainCanvas>, ILockable
	{
		private LockToggle _canvasesLock;

		private LockToggle _test;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		protected override void SingletonAwake()
		{
			_test = new LockToggle(this);
			MenusManager.OnMainMenuShown += OnMainMenuShown;
			List<CanvasGroupController> list = new List<CanvasGroupController>();
			GetCanvasesFromTransform(base.transform.GetChild(0), list);
			GetCanvasesFromTransform(base.transform.GetChild(1), list);
			ILockable[] lockables = list.ToArray();
			_canvasesLock = new LockToggle(lockables);
		}

		private static void GetCanvasesFromTransform(Transform parent, ICollection<CanvasGroupController> controllers)
		{
			foreach (Transform child in parent.GetChildren())
			{
				CanvasGroupController[] componentsInChildren = child.GetComponentsInChildren<CanvasGroupController>();
				foreach (CanvasGroupController canvasGroupController in componentsInChildren)
				{
					if ((bool)canvasGroupController && canvasGroupController.CanBeGloballyHidden && !controllers.Contains(canvasGroupController))
					{
						controllers.Add(canvasGroupController);
					}
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void EnableUI()
		{
			_test.Unlock();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void DisableUI()
		{
			_test.Lock();
		}

		protected override void OnSingletonDestroy()
		{
			MenusManager.OnMainMenuShown -= OnMainMenuShown;
		}

		private void OnMainMenuShown(bool value)
		{
			base.gameObject.SetActive(!value);
		}

		void ILockable.OnLocked()
		{
			_canvasesLock.Lock();
		}

		void ILockable.OnUnlocked()
		{
			_canvasesLock.Unlock();
		}
	}
}
