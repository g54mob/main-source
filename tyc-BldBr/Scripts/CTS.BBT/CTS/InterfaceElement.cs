using System;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(CanvasGroupController))]
	public class InterfaceElement : MonoBehaviour, ILockable
	{
		protected CanvasGroupController _groupController;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		protected virtual void Awake()
		{
			_groupController = GetComponent<CanvasGroupController>();
		}

		void ILockable.OnLocked()
		{
			QuickHide();
		}

		public void QuickHide()
		{
			_groupController.QuickHide();
			OnToggledOff();
		}

		void ILockable.OnUnlocked()
		{
			QuickShow();
		}

		public void QuickShow()
		{
			_groupController.QuickShow();
			OnToggledOn();
		}

		public void InstantToggleOff()
		{
			_groupController.InstantHide();
			OnToggledOff();
		}

		public void InstantToggleOn()
		{
			_groupController.InstantShow();
			OnToggledOn();
		}

		protected virtual void OnToggledOn()
		{
		}

		protected virtual void OnToggledOff()
		{
		}
	}
}
